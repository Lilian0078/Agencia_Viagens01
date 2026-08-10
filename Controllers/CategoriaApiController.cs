using Agencia_Viagens01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agencia_Viagens01.DTOs;
using System.Linq;

namespace Agencia_Viagens01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var categorias = _context.Categoria.ToList();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var categoria = _context.Categoria.FirstOrDefault(c => c.Codigo == id);

            if (categoria == null)
            {
                return NotFound(new
                {
                    message = $"Categoria com código {id} não encontrada."
                });
            }

            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CategoriaCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novaCategoria = new Categoria
            {
                Hotel = dto.Hotel,
                Aviao = dto.Aviao,
                Translado = dto.Translado,
                Voucher = dto.Voucher
            };

            _context.Categoria.Add(novaCategoria);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = novaCategoria.Codigo },
                novaCategoria
            );
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] CategoriaCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoriaNoBanco = _context.Categoria
                .FirstOrDefault(c => c.Codigo == id);

            if (categoriaNoBanco == null)
            {
                return NotFound(new
                {
                    message = $"Categoria de código {id} inexistente para atualização."
                });
            }

            // Mapeando os dados do DTO para a entidade
            categoriaNoBanco.Hotel = dto.Hotel;
            categoriaNoBanco.Aviao = dto.Aviao;
            categoriaNoBanco.Translado = dto.Translado;
            categoriaNoBanco.Voucher = dto.Voucher;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var categoria = _context.Categoria
                .FirstOrDefault(c => c.Codigo == id);

            if (categoria == null)
            {
                return NotFound(new
                {
                    message = $"Categoria de código {id} não encontrada para exclusão."
                });
            }

            _context.Categoria.Remove(categoria);
            _context.SaveChanges();

            return Ok(new
            {
                success = true,
                message = "Categoria excluída com sucesso diretamente pela API!"
            });
        }
    }
}