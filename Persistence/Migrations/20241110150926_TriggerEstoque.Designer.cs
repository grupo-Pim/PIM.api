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
    [Migration("20241110150926_TriggerEstoque")]
    partial class TriggerEstoque
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PIM.api.Entidades.ClienteEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MunicipioID")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MunicipioID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PIM.api.Entidades.ColaboradorEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Funcao")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Colaboradores");
                });

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

            modelBuilder.Entity("PIM.api.Entidades.EstoqueEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProdutoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Estoque");
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

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

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

            modelBuilder.Entity("PIM.api.Entidades.MovimentacoesPlantioEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ColaboradorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime2");

                    b.Property<byte>("EtapaAntiga")
                        .HasColumnType("tinyint");

                    b.Property<byte>("EtapaAtualizada")
                        .HasColumnType("tinyint");

                    b.Property<int>("PlantioID")
                        .HasColumnType("int");

                    b.Property<float?>("QntKG")
                        .IsRequired()
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("ColaboradorID");

                    b.HasIndex("PlantioID");

                    b.ToTable("MovimentacoesPlantio", t =>
                        {
                            t.HasTrigger("AtualizarEstoqueMovimentacao");
                        });
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

            modelBuilder.Entity("PIM.api.Entidades.PedidosEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DtEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("EmpresaID");

                    b.HasIndex("ProdutoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("PIM.api.Entidades.PlantioEntidade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("DataColheita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPlantio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaID")
                        .HasColumnType("int");

                    b.Property<byte>("Etapa")
                        .HasColumnType("tinyint");

                    b.Property<int>("LocalID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmpresaID");

                    b.HasIndex("LocalID");

                    b.HasIndex("ProdutoID");

                    b.ToTable("Plantio");
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

                    b.Property<int>("FornecedorID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ValorVendaKG")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmpresaID");

                    b.HasIndex("FornecedorID");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("PIM.api.Entidades.SolicitacaoMateriaPrima", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioSolcitanteID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioSolcitanteID");

                    b.ToTable("SolcitacaoCompraMateriaPrima");
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

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SerColaborador")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PIM.api.Entidades.ClienteEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.MunicipioEntidade", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.UsuarioEntidade", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Municipio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PIM.api.Entidades.ColaboradorEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.UsuarioEntidade", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
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

            modelBuilder.Entity("PIM.api.Entidades.EstoqueEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.ProdutoEntidade", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.UsuarioEntidade", "UsuarioADD")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("UsuarioADD");
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
                        .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity("PIM.api.Entidades.MovimentacoesPlantioEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.ColaboradorEntidade", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.PlantioEntidade", "Plantio")
                        .WithMany()
                        .HasForeignKey("PlantioID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Plantio");
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

            modelBuilder.Entity("PIM.api.Entidades.PedidosEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.ClienteEntidade", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.EmpresaEntidade", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.ProdutoEntidade", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.UsuarioEntidade", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cliente");

                    b.Navigation("Empresa");

                    b.Navigation("Produto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PIM.api.Entidades.PlantioEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.EmpresaEntidade", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.LocalPlantioEntidade", "Local")
                        .WithMany()
                        .HasForeignKey("LocalID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.ProdutoEntidade", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Local");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("PIM.api.Entidades.ProdutoEntidade", b =>
                {
                    b.HasOne("PIM.api.Entidades.EmpresaEntidade", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIM.api.Entidades.FornecedorEntidade", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("PIM.api.Entidades.SolicitacaoMateriaPrima", b =>
                {
                    b.HasOne("PIM.api.Entidades.UsuarioEntidade", "UsuarioSolcitante")
                        .WithMany()
                        .HasForeignKey("UsuarioSolcitanteID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UsuarioSolcitante");
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
#pragma warning restore 612, 618
        }
    }
}
