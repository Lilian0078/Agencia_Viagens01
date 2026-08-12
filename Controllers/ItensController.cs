using Microsoft.AspNetCore.Mvc;
using Agencia_Viagens01.Models;
using System.Linq;

namespace Agencia_Viagens01.Controllers
{
    public class ItensController : Controller
    {
        private readonly AppDbContext _context;

        public ItensController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lista = _context.Itens.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(
            int codProduto,
            int codPacote,
            int quantidade,
            decimal valorUnidade)
        {
            var novosItens = new Itens
            {
                CodProduto = codProduto,
                CodPacote = codPacote,
                Quantidade = quantidade,
                ValorUnidade = valorUnidade
            };

            if (quantidade > 0)
            {
                _context.Itens.Add(novosItens);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Itens/Editar/5
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var itens = _context.Itens
                .FirstOrDefault(i => i.CodProduto == id);

            if (itens == null)
            {
                return NotFound();
            }

            return View(itens);
        }

        // POST: Itens/Editar
        [HttpPost]
        public IActionResult Editar(
            int codProduto,
            int codPacote,
            int quantidade,
            decimal valorUnidade)
        {
            var itensNoBanco = _context.Itens
                .FirstOrDefault(i => i.CodProduto == codProduto);

            if (itensNoBanco != null)
            {
                itensNoBanco.CodPacote = codPacote;
                itensNoBanco.Quantidade = quantidade;
                itensNoBanco.ValorUnidade = valorUnidade;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Itens/Excluir/5
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var itens = _context.Itens
                .FirstOrDefault(i => i.CodProduto == id);

            if (itens == null)
            {
                return NotFound();
            }

            return View(itens);
        }

        // POST: Itens/ExcluirConfirmado
        [HttpPost]
        public IActionResult ExcluirConfirmado(int codProduto)
        {
            var itens = _context.Itens
                .FirstOrDefault(i => i.CodProduto == codProduto);

            if (itens != null)
            {
                _context.Itens.Remove(itens);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // POST: Itens/ExcluirConfirmadoModal
        [HttpPost]
        public IActionResult ExcluirConfirmadoModal(int codProduto)
        {
            var itens = _context.Itens
                .FirstOrDefault(i => i.CodProduto == codProduto);

            if (itens != null)
            {
                _context.Itens.Remove(itens);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Item excluído com sucesso!"
                });
            }

            return Json(new
            {
                success = false,
                message = "Erro ao excluir o item."
            });
        }
    }
}