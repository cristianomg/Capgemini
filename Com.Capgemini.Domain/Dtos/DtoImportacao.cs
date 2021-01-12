using System;
using System.Collections.Generic;

namespace Com.Capgemini.Domain.Dtos
{
    public class DtoImportacao
    {
        public Guid Id { get; set; }
        public DateTime DtImportacao { get; set; }
        public List<DtoProduto> Produtos { get; set; }
    }
}
