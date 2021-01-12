using System;

namespace Com.Capgemini.Domain.Entidades
{
    public class Produto : Entidade<Guid>
    {
        public Guid ImportacaoId { get; set; }
        public DateTime DtEntrega { get; set; }
        public string NmProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal VlUnitario { get; set; }

        public virtual Importacao Importacao{ get; set; }
    }
}
