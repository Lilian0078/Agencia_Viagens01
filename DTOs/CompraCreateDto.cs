using System;
using System.ComponentModel.DataAnnotations;

namespace Agencia_Viagens01.DTOs
{
    public class CompraCreateDto
    {
        [Required(ErrorMessage = "A data da compra é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime? DataCompra { get; set; }

        [Required(ErrorMessage = "A forma de pagamento é obrigatória.")]
        [StringLength(100, ErrorMessage = "A forma de pagamento não pode exceder 100 caracteres.")]
        public string FormaPagamento { get; set; }

        [Required(ErrorMessage = "O valor total é obrigatório.")]
        [Range(0, 99999999.99, ErrorMessage = "Informe um valor válido.")]
        public decimal? ValorTotal { get; set; }
    }
}
