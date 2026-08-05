using System.ComponentModel.DataAnnotations;

namespace Agencia_Viagens01.Models
{
    public class Usuario
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int CodigoFuncionario { get; set; }
    }
}

