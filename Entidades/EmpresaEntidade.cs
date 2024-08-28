using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace PIM.api.Entidades
{
    public class EmpresaEntidade
    {
        public EmpresaEntidade()
        {
            
        }

        public int ID { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int? TipoEmpresa { get; set; }
        public bool? PossuiFilial { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Cep { get; set; }
        public int MunicipioID { get; set; }
        public MunicipioEntidade? Municipio { get; set; }
    }
    public class EmpresaInput
    {
        public int ID { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int? TipoEmpresa { get; set; }
        public bool? PossuiFilial { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Cep { get; set; }
        public int MunicipioID { get; set; }
    }
}
