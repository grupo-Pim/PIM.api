using PIM.api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace PIM.api.Persistence;


public class FazendoDbContext : DbContext
{
    public List<EmpresaEntidade> Empresas { get; set; }


    public FazendoDbContext(DbContextOptions<FazendoDbContext> options) : base(options)
    {
    }
    public DbSet<EmpresaEntidade> Empresa { get; set; }
    public DbSet<UsuarioEntidade> Usuarios { get; set; }
    public DbSet<MunicipioEntidade> Municipios { get; set; }
    public DbSet<EstadoEntidade> Estados { get; set; }
    public DbSet<FornecedorEntidade> Fornecedor { get; set; }
    public DbSet<ProdutoEntidade> Produto { get; set; }


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
            o.Property(UE => UE.Funcao).IsRequired(true);
            o.Property(UE => UE.Acesso).IsRequired(false);
            o.Property(UE => UE.Ativo).IsRequired(true);
        
            o.HasOne(UE => UE.Empresa)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.EmpresaID);
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
            o.Property(UE => UE.ValorKG).IsRequired(false);

            o.HasOne(UE => UE.Empresa)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.EmpresaID)
                .OnDelete(DeleteBehavior.Restrict);
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
                .HasForeignKey(o => o.EmpresaID);
            o.HasOne(UE => UE.Municipio)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.MunicipioID);
        });
        Builder.Entity<ProdutoFornecedor>(o =>
        {
            o.HasKey(PF => PF.ID);
            o.Property(PF => PF.Valor).IsRequired(false);

            o.HasOne(PF => PF.Fornecedor)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.FornecedorID);
            o.HasOne(PF => PF.Produto)
                .WithMany()
                .IsRequired(true)
                .HasForeignKey(o => o.ProdutoID);
        });
    }
}
//dotnet ef migrations add tabelaRelacionamentoN_N -o Persistence/Migrations
//dotnet ef database update