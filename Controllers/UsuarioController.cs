using Microsoft.AspNetCore.Mvc;
using Agencia_Viagens01.Models;
using System.Linq;

namespace Agencia_Viagens01.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;
        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lista = _context.Usuario.ToList();
            return View(lista); // Passa a lista para a View
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(string nome, string senha, string email, int codigoFuncionario)
        {
            // Criamos o objeto manualmente com os dados que vieram do formulário
            var novoUsuario = new Usuario
            {
                Nome = nome,
                Senha = senha,
                Email = email,
                CodigoFuncionario = codigoFuncionario
            };

            if (!string.IsNullOrEmpty(nome))
            {
                _context.Usuario.Add(novoUsuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Usuario/Editar/5
        [HttpGet]
        public IActionResult Editar(int id)
        {
            // Busca o usuário pelo código (ID)
            var usuario = _context.Usuario.FirstOrDefault(u => u.Codigo == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario); // Passa o objeto para a View preencher os campos
        }

        // POST: Usuario/Editar
        [HttpPost]
        public IActionResult Editar(int codigo, string nome, string senha, string email, int codigoFuncionario)
        {
            // Busca o registro existente no banco
            var usuarioNoBanco = _context.Usuario.FirstOrDefault(u => u.Codigo == codigo);

            if (usuarioNoBanco != null)
            {
                // Atualiza os atributos manualmente
                usuarioNoBanco.Nome = nome;
                usuarioNoBanco.Senha = senha;
                usuarioNoBanco.Email = email;
                usuarioNoBanco.CodigoFuncionario = codigoFuncionario;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Usuario/Excluir/5
        [HttpGet]
        public IActionResult Excluir(int id)
        {
            // Busca o usuário para mostrar ao usuário o que ele está prestes a apagar
            var usuario = _context.Usuario.FirstOrDefault(u => u.Codigo == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/ExcluirConfirmado
        [HttpPost]
        public IActionResult ExcluirConfirmado(int codigo)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Codigo == codigo);

            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ExcluirConfirmadoModal(int codigo)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Codigo == codigo);

            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
                return Json(new { success = true, message = "Usuário excluído com sucesso!" });
            }

            return Json(new { success = false, message = "Erro ao excluir o usuário." });
        }
    }
}
