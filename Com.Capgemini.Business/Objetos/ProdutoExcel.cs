using FluentValidation;
using System;

namespace Com.Capgemini.Business.Objetos
{
    public class ProdutoExcel
    {
        public DateTime? DtEntrega { get; private set; }
        public string NmProduto { get; private set; }
        public int? Quantidade { get; private set; }
        public decimal? VlUnitario { get; private set; }

        public void SetDtEntrada(object data)
        {
            if (data == null)
                DtEntrega = null;
            else
                DtEntrega = Convert.ToDateTime(data);
        }
        public void SetNmProduto(object data) =>
            NmProduto = data?.ToString();
        public void SetQuantidade(object data)
        {
            if (data == null)
                Quantidade = null;
            else
                Quantidade = Convert.ToInt32(data);
        }

        public void SetVlUnitario(object data)
        {
            if (data == null)
                VlUnitario = null;
            else
                VlUnitario = decimal.Round(Convert.ToDecimal(data), 2, MidpointRounding.AwayFromZero); ;
        }

        public bool Validar()
        {
            if (NmProduto != null && DtEntrega != null &&
                Quantidade != null && VlUnitario != null) 
                return true;
            return false;
        }
    }

    public class ProdutoExcelValidator : AbstractValidator<ProdutoExcel>
    {
        public ProdutoExcelValidator()
        {
            RuleFor(x => x.DtEntrega).NotNull().NotEmpty().GreaterThan(DateTime.Now);
            RuleFor(x => x.NmProduto).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Quantidade).NotNull().GreaterThan(0);
            RuleFor(x => x.VlUnitario).NotNull();
        }
    }

}
