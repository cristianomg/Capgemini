using Com.Capgemini.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Com.Capgemini.Infra.Mapping
{
    public sealed class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto));

            builder.HasKey(produto => produto.Id);


            builder.Property(produto => produto.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(produto => produto.DtEntrega).IsRequired();

            builder.Property(produto => produto.NmProduto).IsRequired().HasMaxLength(50);

            builder.Property(produto => produto.Quantidade).IsRequired();

            builder.HasCheckConstraint("check_if_qtd_more_then_zero", "[Quantidade] >= 1");

            builder.Property(produto => produto.VlUnitario).IsRequired().HasColumnType("decimal(10,2)");


            builder.HasOne(x => x.Importacao)
                .WithMany(x => x.Produtos)
                .HasForeignKey(x => x.ImportacaoId);

        }
    }
}
