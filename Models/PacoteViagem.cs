using System.ComponentModel.DataAnnotations;

namespace Agencia_Viagens01.Models
{
    public class PacoteViagem
    {
        [Key]
        public int Codigo { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public decimal ValorTotal { get; set; }

    }
}
