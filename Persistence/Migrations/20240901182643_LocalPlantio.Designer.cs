﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PIM.api.Persistence;

#nullable disable

namespace PIM.api.Persistence.Migrations
{
    [DbContext(typeof(FazendoDbContext))]
    [Migration("20240901182643_LocalPlantio")]
    partial class LocalPlantio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PIM.api.Entidades.EmpresaEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MunicipioID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("PossuiFilial")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoEmpresa")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MunicipioID");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("PIM.api.Entidades.EstadoEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("PIM.api.Entidades.FornecedorEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<int>("MunicipioID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EmpresaID");

                    b.HasIndex("MunicipioID");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("PIM.api.Entidades.LocalPlantioEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmpresaID");

                    b.ToTable("LocalPlantio");
                });

            modelBuilder.Entity("PIM.api.Entidades.MunicipioEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UFID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UFID");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("PIM.api.Entidades.ProdutoEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ValorVendaKG")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("PIM.api.Entidades.ProdutoFornecedor", b =>
                {
                    b.Property<int>("FornecedorID")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<float?>("Valor")
                        .HasColumnType("real");

                    b.HasKey("FornecedorID", "ProdutoID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("ProdutoFornecedor");
                });

            modelBuilder.Entity("PIM.api.Entidades.UsuarioEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<Guid?>("Acesso")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<int>("Funcao")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PIM.api.Entidades.EmpresaEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.MunicipioEntidade", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("PIM.api.Entidades.FornecedorEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.EmpresaEntidade", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.MunicipioEntidade", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("PIM.api.Entidades.LocalPlantioEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.EmpresaEntidade", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("PIM.api.Entidades.MunicipioEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.EstadoEntidade", "UF")
                        .WithMany()
                        .HasForeignKey("UFID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UF");
                });

            modelBuilder.Entity("PIM.api.Entidades.ProdutoEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.EmpresaEntidade", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("PIM.api.Entidades.ProdutoFornecedor", b =>
                {
                    b.HasOne("PIM.api.Entidades.FornecedorEntidade", "Fornecedor")
                        .WithMany("ProdutoFornecedor")
                        .HasForeignKey("FornecedorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.ProdutoEntidade", "Produto")
                        .WithMany("ProdutoFornecedor")
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("PIM.api.Entidades.UsuarioEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.EmpresaEntidade", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("PIM.api.Entidades.FornecedorEntidade", b =>
                {
                    b.Navigation("ProdutoFornecedor");
                });

            modelBuilder.Entity("PIM.api.Entidades.ProdutoEntidade", b =>
                {
                    b.Navigation("ProdutoFornecedor");
                });
#pragma warning restore 612, 618
        }
    }
}
