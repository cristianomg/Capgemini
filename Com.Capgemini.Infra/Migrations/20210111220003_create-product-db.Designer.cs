﻿// <auto-generated />
using System;
using Com.Capgemini.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Com.Capgemini.Infra.Migrations
{
    [DbContext(typeof(CapgeminiContext))]
    [Migration("20210111220003_create-product-db")]
    partial class createproductdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Com.Capgemini.Domain.Entidades.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DtEntrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("NmProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("VlUnitario")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Produto");

                    b.HasCheckConstraint("check_if_qtd_more_then_zero", "[Quantidade] >= 1");
                });
#pragma warning restore 612, 618
        }
    }
}
