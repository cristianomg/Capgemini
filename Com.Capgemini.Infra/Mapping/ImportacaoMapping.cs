using Com.Capgemini.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Com.Capgemini.Infra.Mapping
{
    public class ImportacaoMapping : IEntityTypeConfiguration<Importacao>
    {
        public void Configure(EntityTypeBuilder<Importacao> builder)
        {
            builder.ToTable(nameof(Importacao));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.DtImportacao).IsRequired();


            builder.HasMany(x => x.Produtos)
                .WithOne(x => x.Importacao)
                .HasForeignKey(x => x.ImportacaoId);
        }
    }
}
