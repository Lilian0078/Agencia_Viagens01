using Microsoft.AspNetCore.Mvc;
using Agencia_Viagens01.Models;
using System.Linq;

namespace Agencia_Viagens01.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lista = _context.Categoria.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(string hotel, string aviao, string translado, string voucher)
        {
          
            var novaCategoria = new Categoria
            {
                Hotel = hotel,
                Aviao = aviao,
                Translado = translado,
                Voucher = voucher
            };

            if (!string.IsNullOrEmpty(hotel))
            {
                _context.Categoria.Add(novaCategoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            
            var categoria = _context.Categoria.FirstOrDefault(c => c.Codigo == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        
        [HttpPost]
        public IActionResult Editar(int codigo, string hotel, string aviao, string translado, string voucher)
        {
            
            var categoriaNoBanco = _context.Categoria.FirstOrDefault(c => c.Codigo == codigo);

            if (categoriaNoBanco != null)
            {
               
                categoriaNoBanco.Hotel = hotel;
                categoriaNoBanco.Aviao = aviao;
                categoriaNoBanco.Translado = translado;
                categoriaNoBanco.Voucher = voucher;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        
        [HttpGet]
        public IActionResult Excluir(int id)
        {
          
            var categoria = _context.Categoria.FirstOrDefault(c => c.Codigo == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categoria/ExcluirConfirmado
        [HttpPost]
        public IActionResult ExcluirConfirmado(int codigo)
        {
            var categoria = _context.Categoria.FirstOrDefault(c => c.Codigo == codigo);

            if (categoria != null)
            {
                _context.Categoria.Remove(categoria);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ExcluirConfirmadoModal(int codigo)
        {
            var categoria = _context.Categoria.FirstOrDefault(c => c.Codigo == codigo);

            if (categoria != null)
            {
                _context.Categoria.Remove(categoria);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Categoria excluída com sucesso!"
                });
            }

            return Json(new
            {
                success = false,
                message = "Erro ao excluir a categoria."
            });
        }
    }
}