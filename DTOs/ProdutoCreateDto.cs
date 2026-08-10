using System.ComponentModel.DataAnnotations;

namespace Agencia_Viagens01.DTOs
{
    public class ProdutoCreateDto
    {
        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        [StringLength(200, ErrorMessage = "A descrição não pode exceder 200 caracteres.")]
        public string Descricao { get; set; }
    }
}