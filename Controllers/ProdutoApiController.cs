using Agencia_Viagens01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agencia_Viagens01.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Agencia_Viagens01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var produtos = _context.Produto.ToList();
            return Ok(produtos); // Status HTTP 200 OK com o JSON da lista
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var produto = _context.Produto.FirstOrDefault(p => p.Codigo == id);

            if (produto == null)
            {
                return NotFound(new
                {
                    message = $"Produto com código {id} não encontrado."
                }); // HTTP 404
            }

            return Ok(produto); // HTTP 200 OK
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] ProdutoCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // HTTP 400 Bad Request
            }

            var novoProduto = new Produto
            {
                Descricao = dto.Descricao
            };

            _context.Produto.Add(novoProduto);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = novoProduto.Codigo },
                novoProduto
            );
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] ProdutoCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var produtoNoBanco = _context.Produto.FirstOrDefault(p => p.Codigo == id);

            if (produtoNoBanco == null)
            {
                return NotFound(new
                {
                    message = $"Produto de código {id} inexistente para atualização."
                });
            }

            // Mapeando dados do DTO para a entidade monitorada pelo EF
            produtoNoBanco.Descricao = dto.Descricao;

            _context.SaveChanges();

            return NoContent(); // HTTP 204 No Content
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var produto = _context.Produto.FirstOrDefault(p => p.Codigo == id);

            if (produto == null)
            {
                return NotFound(new
                {
                    message = $"Produto de código {id} não encontrado para exclusão."
                });
            }

            _context.Produto.Remove(produto);
            _context.SaveChanges();

            return Ok(new
            {
                success = true,
                message = "Produto excluído com sucesso diretamente pela API!"
            }); // HTTP 200
        }
    }
}
