﻿using System;

namespace Com.Capgemini.Domain.Dtos
{
    public  class DtoProduto
    {
        public Guid Id { get; set; }
        public DateTime DtEntrega { get; set; }
        public string NmProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal VlUnitario { get; set; }
    }
}