using System.ComponentModel.DataAnnotations;

namespace Agencia_Viagens01.Models
{
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
