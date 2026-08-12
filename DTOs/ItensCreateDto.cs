using Agencia_Viagens01.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Agencia_Viagens01.DTOs
{
    public class ItensCreateDto
    {
        [Required(ErrorMessage = "O código do produto é obrigatório.")]
        public int CodProduto { get; set; }

        [Required(ErrorMessage = "O código do pacote é obrigatório.")]
        public int CodPacote { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O valor da unidade é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor da unidade deve ser maior que zero.")]
        public decimal ValorUnidade { get; set; }
    }
}