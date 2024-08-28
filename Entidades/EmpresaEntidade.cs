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
        public bool PossuiContador { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public int? TipoEmpresa { get; set; }
        public bool? PossuiFilial { get; set; }
        public string? NomeContador { get; set; }
        public string? EmailContador { get; set; }
        public string? NumeroContador { get; set; }

        //endereço
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Cep { get; set; }
        public int MunicipioID { get; set; }
        public MunicipioEntidade? Municipio { get; set; }
    }
}
