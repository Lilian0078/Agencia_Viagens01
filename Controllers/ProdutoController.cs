using Microsoft.AspNetCore.Mvc;
using Agencia_Viagens01.Models;
using System.Linq;

namespace Agencia_Viagens01.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Produto
        public IActionResult Index()
        {
            var lista = _context.Produto.ToList();

            return View(lista);
        }

        // GET: Produto/Criar
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // POST: Produto/Criar
        [HttpPost]
        public IActionResult Criar(string descricao)
        {
            // Criamos o objeto manualmente com os dados
            // que vieram do formulário
            var novoProduto = new Produto
            {
                Descricao = descricao
            };

            if (!string.IsNullOrEmpty(descricao))
            {
                _context.Produto.Add(novoProduto);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Produto/Editar/5
        [HttpGet]
        public IActionResult Editar(int id)
        {
            // Busca o produto pelo código (ID)
            var produto = _context.Produto
                .FirstOrDefault(p => p.Codigo == id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/Editar
        [HttpPost]
        public IActionResult Editar(int codigo, string descricao)
        {
            // Busca o registro existente no banco
            var produtoNoBanco = _context.Produto
                .FirstOrDefault(p => p.Codigo == codigo);

            if (produtoNoBanco != null)
            {
                // Atualiza a descrição
                produtoNoBanco.Descricao = descricao;

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Produto/Excluir/5
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            // Busca o produto para mostrar
            // o que será excluído
            var produto = _context.Produto
                .FirstOrDefault(p => p.Codigo == id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produto/ExcluirConfirmado
        [HttpPost]
        public IActionResult ExcluirConfirmado(int codigo)
        {
            var produto = _context.Produto
                .FirstOrDefault(p => p.Codigo == codigo);

            if (produto != null)
            {
                _context.Produto.Remove(produto);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // POST: Produto/ExcluirConfirmadoModal
        [HttpPost]
        public IActionResult ExcluirConfirmadoModal(int codigo)
        {
            var produto = _context.Produto
                .FirstOrDefault(p => p.Codigo == codigo);

            if (produto != null)
            {
                _context.Produto.Remove(produto);
                _context.SaveChanges();

                return Json(new
                {
                    success = true,
                    message = "Produto excluído com sucesso!"
                });
            }

            return Json(new
            {
                success = false,
                message = "Erro ao excluir o produto."
            });
        }
    }
}