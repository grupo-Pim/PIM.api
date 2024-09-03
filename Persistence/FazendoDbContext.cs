using PIM.api.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace PIM.api.Persistence;


public class FazendoDbContext : DbContext
{
    public List<EmpresaEntidade> Empresas { get; set; }


    public FazendoDbContext(DbContextOptions<FazendoDbContext> options) : base(options)
    {
    }
    public DbSet<EmpresaEntidade> Empresa { get; set; }
    public DbSet<UsuarioEntidade> Usuarios { get; set; }
    public DbSet<ColaboradorEntidade> Colaboradores { get; set; }
    public DbSet<ClienteEntidade> Clientes { get; set; }
    public DbSet<MunicipioEntidade> Municipios { get; set; }
    public DbSet<EstadoEntidade> Estados { get; set; }
    public DbSet<FornecedorEntidade> Fornecedor { get; set; }
    public DbSet<ProdutoEntidade> Produto { get; set; }
    public DbSet<ProdutoFornecedor> ProdutoFornecedor { get; set; }
    public DbSet<LocalPlantioEntidade> LocalPlantio { get; set; }
    public DbSet<PlantioEntidade> Plantio { get; set; }
    public DbSet<MovimentacoesPlantioEntidade> MovimentacoesPlantio { get; set; }
    public DbSet<PedidosEntidade> Pedidos { get; set; }


    protected override void OnModelCreating(ModelBuilder Builder)
    {
        Builder.Entity<EmpresaEntidade>(o =>
        {
            o.HasKey(EE => EE.ID);
            o.Property(EE => EE.Ativo).IsRequired(true).HasDefaultValue(true);
            o.Property(EE => EE.Nome).IsRequired(true);
            o.Property(EE => EE.CNPJ).IsRequired(true);
            o.Property(EE => EE.RazaoSocial).IsRequired(true);
            o.Property(EE => EE.Email).IsRequired(false);
            o.Property(EE => EE.Telefone).IsRequired(false);
            o.Property(EE => EE.TipoEmpresa).IsRequired(true);
            o.Property(EE => EE.PossuiFilial).IsRequired(true);
            o.Property(EE => EE.Rua).IsRequired(true);
            o.Property(EE => EE.Numero).IsRequired(true);
            o.Property(EE => EE.Cep).IsRequired(true);            
            o.HasOne(Et => Et.Municipio)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.MunicipioID)
                .OnDelete(DeleteBehavior.Restrict);
        });
        Builder.Entity<UsuarioEntidade>(o =>
        {
            o.HasKey(UE => UE.ID);
            o.Property(UE => UE.Nome).IsRequired(true);
            o.Property(UE => UE.Login).IsRequired(true);
            o.Property(UE => UE.Senha).IsRequired(true);
            o.Property(UE => UE.Telefone).IsRequired(false);
            o.Property(UE => UE.Acesso).IsRequired(false);
            o.Property(UE => UE.Ativo).IsRequired(true);
            o.Property(UE => UE.SerColaborador).IsRequired(true);

            o.HasOne(UE => UE.Empresa)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.EmpresaID);
        });
        Builder.Entity<ColaboradorEntidade>(o =>
        {
            o.HasKey(UE => UE.ID);
            o.Property(UE => UE.Funcao).IsRequired(true);

            o.HasOne(UE => UE.Usuario)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.UsuarioID);
        });
        Builder.Entity<ClienteEntidade>(o =>
        {
            o.HasKey(UE => UE.ID);            
            o.Property(UE => UE.Rua).IsRequired(false);
            o.Property(UE => UE.Numero).IsRequired(false);
            o.Property(UE => UE.Cep).IsRequired(false);

            o.HasOne(UE => UE.Usuario)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.UsuarioID);
            o.HasOne(UE => UE.Municipio)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.MunicipioID);
        });
        Builder.Entity<MunicipioEntidade>(o =>
        {
            o.HasKey(EE => EE.ID);
            o.Property(UE => UE.Nome).IsRequired(true);

            o.HasOne(UE => UE.UF)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.UFID);
        });
        Builder.Entity<EstadoEntidade>(o =>
        {
            o.HasKey(EE => EE.ID);
            o.Property(UE => UE.Nome).IsRequired(true);
            o.Property(UE => UE.Nome).IsRequired(true);
        });
        Builder.Entity<ProdutoEntidade>(o =>
        {
            o.HasKey(EE => EE.ID);
            o.Property(UE => UE.Nome).IsRequired(true);
            o.Property(UE => UE.ValorVendaKG).IsRequired(false);
            o.Property(UE => UE.Ativo).IsRequired(true).HasDefaultValue(true);

            o.HasOne(UE => UE.Empresa)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.EmpresaID);
        }); 
        Builder.Entity<FornecedorEntidade>(o =>
        {
            o.HasKey(EE => EE.ID);
            o.Property(UE => UE.Nome).IsRequired(true);
            o.Property(UE => UE.CNPJ).IsRequired(true);
            o.Property(UE => UE.Telefone).IsRequired(true);
            o.Property(UE => UE.Email).IsRequired(false);
            o.Property(UE => UE.Ativo).IsRequired(true).HasDefaultValue(true);

            o.HasOne(UE => UE.Empresa)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.EmpresaID)
                .OnDelete(DeleteBehavior.Restrict);
            o.HasOne(UE => UE.Municipio)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.MunicipioID)
                .OnDelete(DeleteBehavior.Restrict);
        });
        Builder.Entity<ProdutoFornecedor>(o =>
        {
            o.HasKey(PF => new { PF.FornecedorID, PF.ProdutoID });
            o.Property(PF => PF.Valor).IsRequired(false);

            o.HasOne(ac => ac.Produto)
                .WithMany(a => a.ProdutoFornecedor)
                .HasForeignKey(ac => ac.ProdutoID)
                .OnDelete(DeleteBehavior.Restrict);

            o.HasOne(ac => ac.Fornecedor)
                .WithMany(c => c.ProdutoFornecedor)
                .HasForeignKey(ac => ac.FornecedorID)
                .OnDelete(DeleteBehavior.Restrict);
        });
        Builder.Entity<LocalPlantioEntidade>(o =>
        {
            o.HasKey(EE => EE.ID);
            o.Property(UE => UE.Tamanho).IsRequired(true);
            o.Property(UE => UE.Localizacao).IsRequired(true);
            o.Property(UE => UE.Ativo).IsRequired(true).HasDefaultValue(true);
            o.Property(UE => UE.Nome).IsRequired(false);

            o.HasOne(UE => UE.Empresa)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.EmpresaID);
        });
        Builder.Entity<PlantioEntidade>(o =>
        {
            o.HasKey(EE => EE.ID);
            o.Property(UE => UE.Nome).IsRequired(false);
            o.Property(UE => UE.Etapa).IsRequired(true);
            o.Property(UE => UE.DataPlantio).IsRequired(true);
            o.Property(UE => UE.DataColheita).IsRequired(false);
            o.Property(UE => UE.Descricao).IsRequired(false);

            o.HasOne(UE => UE.Empresa)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.EmpresaID);
            o.HasOne(UE => UE.Produto)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.ProdutoID)
                .OnDelete(DeleteBehavior.Restrict);
            o.HasOne(UE => UE.Local)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.LocalID)
                .OnDelete(DeleteBehavior.Restrict);
        });
        Builder.Entity<PedidosEntidade>(o =>
        {
            o.HasKey(EE => EE.ID);
            o.Property(UE => UE.Quantidade).IsRequired(true);
            o.Property(UE => UE.Observacao).IsRequired(false);
            o.Property(UE => UE.Quantidade).IsRequired(true);
            o.Property(UE => UE.DtPedido).IsRequired(true);
            o.Property(UE => UE.DtEntrega).IsRequired(false);

            o.HasOne(UE => UE.Empresa)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.EmpresaID);
            o.HasOne(UE => UE.Produto)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.ProdutoID)
                .OnDelete(DeleteBehavior.Restrict);
            o.HasOne(UE => UE.Cliente)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.ClienteID)
                .OnDelete(DeleteBehavior.Restrict);
        });
        Builder.Entity<ClienteEntidade>(o =>
        {
            o.HasKey(EE => EE.ID);
            o.Property(UE => UE.Rua).IsRequired(false);
            o.Property(UE => UE.Numero).IsRequired(false);
            o.Property(UE => UE.Cep).IsRequired(false);

            o.HasOne(UE => UE.Usuario)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict);
        });
        Builder.Entity<MovimentacoesPlantioEntidade>(o =>
        {
            o.HasKey(EE => EE.ID);
            o.Property(UE => UE.DataModificacao).IsRequired(true);
            o.Property(UE => UE.EtapaAntiga).IsRequired(true);
            o.Property(UE => UE.EtapaAtualizada).IsRequired(true);

            o.HasOne(UE => UE.Colaborador)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.ColaboradorID)
                .OnDelete(DeleteBehavior.Restrict);

            o.HasOne(UE => UE.Plantio)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.PlantioID)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
    }
}
//dotnet ef migrations add addClienteNoPedido -o Persistence/Migrations
//dotnet ef database update
//dotnet ef migrations remove