using System;
using System.ComponentModel.DataAnnotations;

namespace Agencia_Viagens01.DTOs
{
    public class PacoteViagemCreateDto
    {
        [Required(ErrorMessage = "A origem é obrigatória.")]
        [StringLength(100, ErrorMessage = "A origem não pode exceder 100 caracteres.")]
        public string Origem { get; set; }

        [Required(ErrorMessage = "O destino é obrigatório.")]
        [StringLength(100, ErrorMessage = "O destino não pode exceder 100 caracteres.")]
        public string Destino { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataFinal { get; set; }

        [Range(0, 99999999.99, ErrorMessage = "Informe um valor válido.")]
        public decimal? ValorTotal { get; set; }
    }
}