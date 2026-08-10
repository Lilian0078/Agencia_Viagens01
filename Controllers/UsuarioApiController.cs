using Agencia_Viagens01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agencia_Viagens01.DTOs;
using System.Linq;

namespace Agencia_Viagens01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var usuarios = _context.Usuario.ToList();
            return Ok(usuarios); // Status HTTP 200 OK com o JSON da lista
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Codigo == id);

            if (usuario == null)
            {
                return NotFound(new { message = $"Usuário com código {id} não encontrado." }); // HTTP 404
            }

            return Ok(usuario); // HTTP 200 OK
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // HTTP 400 Bad Request
            }

            var novoUsuario = new Usuario
            {
                Nome = dto.Nome,
                Senha = dto.Senha,
                Email = dto.Email,
                CodigoFuncionario = dto.CodigoFuncionario
            };

            _context.Usuario.Add(novoUsuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarPorId), new { id = novoUsuario.Codigo }, novoUsuario);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioNoBanco = _context.Usuario.FirstOrDefault(u => u.Codigo == id);

            if (usuarioNoBanco == null)
            {
                return NotFound(new { message = $"Usuário de código {id} inexistente para atualização." });
            }

            // Mapeando dados do DTO para a entidade monitorada pelo EF
            usuarioNoBanco.Nome = dto.Nome;
            usuarioNoBanco.Senha = dto.Senha;
            usuarioNoBanco.Email = dto.Email;
            usuarioNoBanco.CodigoFuncionario = dto.CodigoFuncionario;

            _context.SaveChanges();

            return NoContent(); // HTTP 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.Codigo == id);

            if (usuario == null)
            {
                return NotFound(new { message = $"Usuário de código {id} não encontrado para exclusão." });
            }

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();

            return Ok(new
            {
                success = true,
                message = "Usuário excluído com sucesso diretamente pela API!"
            }); // HTTP 200
        }
    }
}




