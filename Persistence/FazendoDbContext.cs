using PIM.api.Entidades;

namespace PIM.api.Persistence;


public class FazendoDbContext //: DbContext
{
    public List<EmpresaEntidade> Empresas { get; set; }


    public FazendoDbContext()
    {
        Empresas = new List<EmpresaEntidade>();

    }


}