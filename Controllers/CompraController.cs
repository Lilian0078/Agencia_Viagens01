using Microsoft.AspNetCore.Mvc;
using Agencia_Viagens01.Models;
using System;
using System.Linq;

namespace Agencia_Viagens01.Controllers
{
    public class CompraController : Controller
    {
        private readonly AppDbContext _context;

        public CompraController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Compra/Index
        public IActionResult Index()
        {
            var lista = _context.Compra.ToList();

            return View(lista);
        }

        // GET: Compra/Criar
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // POST: Compra/Criar
        [HttpPost]
        public IActionResult Criar(
            DateTime dataCompra,
            string formaPagamento,
            decimal? valorTotal)
        {
            var novaCompra = new Compra
            {
                DataCompra = dataCompra,
                FormaPagamento = formaPagamento,
                ValorTotal = valorTotal
            };

            if (!string.IsNullOrEmpty(formaPagamento) &&
                valorTotal != null)
            {
                _context.Compra.Add(novaCompra);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(novaCompra);
        }

        // GET: Compra/Editar/5
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var compra = _context.Compra
                .FirstOrDefault(c => c.Codigo == id);

            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compra/Editar
        [HttpPost]
        public IActionResult Editar(
            int codigo,
            DateTime dataCompra,
            string formaPagamento,
            decimal? valorTotal)
        {
            var compraNoBanco = _context.Compra
                .FirstOrDefault(c => c.Codigo == codigo);

            if (compraNoBanco != null)
            {
                compraNoBanco.DataCompra = dataCompra;
                compraNoBanco.FormaPagamento = formaPagamento;
                compraNoBanco.ValorTotal = valorTotal;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        // GET: Compra/Excluir/5
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var compra = _context.Compra
                .FirstOrDefault(c => c.Codigo == id);

            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compra/ExcluirConfirmado
        [HttpPost]
        public IActionResult ExcluirConfirmado(int codigo)
        {
            var compra = _context.Compra
                .FirstOrDefault(c => c.Codigo == codigo);

            if (compra != null)
            {
                _context.Compra.Remove(compra);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // POST: Compra/ExcluirConfirmadoModal
        [HttpPost]
        public IActionResult ExcluirConfirmadoModal(int codigo)
        {
            var compra = _context.Compra
                .FirstOrDefault(c => c.Codigo == codigo);

            if (compra != null)
            {
                _context.Compra.Remove(compra);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Compra excluída com sucesso!"
                });
            }

            return Json(new
            {
                success = false,
                message = "Erro ao excluir a compra."
            });
        }
    }
}
