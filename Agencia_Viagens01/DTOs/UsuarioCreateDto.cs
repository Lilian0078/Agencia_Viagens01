using Agencia_Viagens01.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Agencia_Viagens01.DTOs
{
    public class UsuarioCreateDto
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength( 8, ErrorMessage = "A senha deve conter 8 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O código do funcionário é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Informe um código de funcionário válido.")]
        public int CodigoFuncionario { get; set; }
    }
}
