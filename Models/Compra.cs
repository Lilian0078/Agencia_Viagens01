using System;
using System.ComponentModel.DataAnnotations;

namespace Agencia_Viagens01.Models
{
    public class Compra
    {
        [Key]
        public int Codigo { get; set; }

        public DateTime DataCompra { get; set; }

        public string FormaPagamento { get; set; }

        public decimal? ValorTotal { get; set; }
    }
}