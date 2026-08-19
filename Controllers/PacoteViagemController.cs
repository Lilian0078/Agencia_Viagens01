using Microsoft.AspNetCore.Mvc;
using Agencia_Viagens01.Models;
using System.Linq;

namespace Agencia_Viagens01.Controllers
{
    public class PacoteViagemController : Controller
    {
        private readonly AppDbContext _context;

        public PacoteViagemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PacoteViagem/Index
        public IActionResult Index()
        {
            var lista = _context.PacoteViagem.ToList();

            return View(lista);
        }

        // GET: PacoteViagem/Criar
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // POST: PacoteViagem/Criar
        [HttpPost]
        public IActionResult Criar(
            string origem,
            string destino,
            DateTime? dataInicio,
            DateTime? dataFinal,
            decimal? valorTotal)
        {
            var novoPacote = new PacoteViagem
            {
                Origem = origem,
                Destino = destino,
                DataInicio = dataInicio,
                DataFinal = dataFinal,
                ValorTotal = valorTotal
            };

            if (!string.IsNullOrEmpty(origem) &&
                !string.IsNullOrEmpty(destino))
            {
                _context.PacoteViagem.Add(novoPacote);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(novoPacote);
        }

        // GET: PacoteViagem/Editar/5
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var pacote = _context.PacoteViagem
                .FirstOrDefault(p => p.Codigo == id);

            if (pacote == null)
            {
                return NotFound();
            }

            return View(pacote);
        }

        // POST: PacoteViagem/Editar
        [HttpPost]
        public IActionResult Editar(
            int codigo,
            string origem,
            string destino,
            DateTime? dataInicio,
            DateTime? dataFinal,
            decimal? valorTotal)
        {
            var pacoteNoBanco = _context.PacoteViagem
                .FirstOrDefault(p => p.Codigo == codigo);

            if (pacoteNoBanco != null)
            {
                pacoteNoBanco.Origem = origem;
                pacoteNoBanco.Destino = destino;
                pacoteNoBanco.DataInicio = dataInicio;
                pacoteNoBanco.DataFinal = dataFinal;
                pacoteNoBanco.ValorTotal = valorTotal;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        // GET: PacoteViagem/Excluir/5
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var pacote = _context.PacoteViagem
                .FirstOrDefault(p => p.Codigo == id);

            if (pacote == null)
            {
                return NotFound();
            }

            return View(pacote);
        }

        // POST: PacoteViagem/ExcluirConfirmado
        [HttpPost]
        public IActionResult ExcluirConfirmado(int codigo)
        {
            var pacote = _context.PacoteViagem
                .FirstOrDefault(p => p.Codigo == codigo);

            if (pacote != null)
            {
                _context.PacoteViagem.Remove(pacote);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // POST: PacoteViagem/ExcluirConfirmadoModal
        [HttpPost]
        public IActionResult ExcluirConfirmadoModal(int codigo)
        {
            var pacote = _context.PacoteViagem
                .FirstOrDefault(p => p.Codigo == codigo);

            if (pacote != null)
            {
                _context.PacoteViagem.Remove(pacote);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Pacote excluído com sucesso!"
                });
            }

            return Json(new
            {
                success = false,
                message = "Erro ao excluir o pacote."
            });
        }
    }
}
