using System.ComponentModel.DataAnnotations;

namespace Agencia_Viagens01.Models
{
    public class Itens
    {
        [Key]
        public int Codigo { get; set; }

        public int CodProduto { get; set; }

        public int CodPacote { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorUnidade { get; set; }
    }
}