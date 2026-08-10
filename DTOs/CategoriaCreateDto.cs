using Agencia_Viagens01.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Agencia_Viagens01.DTOs
{
    public class CategoriaCreateDto
    {
        [Required(ErrorMessage = "O hotel é obrigatório.")]
        [StringLength(100, ErrorMessage = "O hotel não pode exceder 100 caracteres.")]
        public string Hotel { get; set; }

        [Required(ErrorMessage = "O avião é obrigatório.")]
        [StringLength(100, ErrorMessage = "O avião não pode exceder 100 caracteres.")]
        public string Aviao { get; set; }

        [Required(ErrorMessage = "O translado é obrigatório.")]
        [StringLength(100, ErrorMessage = "O translado não pode exceder 100 caracteres.")]
        public string Translado { get; set; }

        [Required(ErrorMessage = "O voucher é obrigatório.")]
        [StringLength(100, ErrorMessage = "O voucher não pode exceder 100 caracteres.")]
        public string Voucher { get; set; }
    }
}