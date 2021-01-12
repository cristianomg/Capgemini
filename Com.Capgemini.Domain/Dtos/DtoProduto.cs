using Com.Capgemini.Domain.Entidades;
using System;

namespace Com.Capgemini.Domain.Dtos
{
    public  class DtoProduto
    {
        public Guid ImportacaoId { get; set; }
        public DateTime DtEntrega { get; set; }
        public string NmProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal VlUnitario { get; set; }
    }
}