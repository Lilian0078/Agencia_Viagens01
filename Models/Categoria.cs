using System.ComponentModel.DataAnnotations;

namespace Agencia_Viagens01.Models
{
    public class Categoria
    {
        [Key]
        public int Codigo { get; set; }
        public string Hotel { get; set; }
        public string Aviao { get; set; }
        public string Translado { get; set; }
        public string Voucher { get; set; }
    }
}