namespace PIM.api.Entidades
{
    public class FornecedorEntidade
    {
        public FornecedorEntidade()
        {
        }
        public FornecedorEntidade(int id, int empresaID, string Nome, string CNPJ, string Telefone, string Email, int MunicipioID, bool Ativo)
        {
            this.ID = id;
            this.EmpresaID = empresaID; 
            this.Nome =Nome ; 
            this.CNPJ =CNPJ ; 
            this.Telefone =Telefone ; 
            this.Email =Email ; 
            this.MunicipioID =MunicipioID ;
            this.Ativo = Ativo;
        }
        public int ID { get; set; }
        public EmpresaEntidade Empresa { get; set; }
        public int EmpresaID { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string? Email { get; set; }
        public MunicipioEntidade Municipio { get; set; }
        public int MunicipioID { get; set; }
        public bool Ativo { get; set; }
    }
    public class FonecedorInput
    {
        public int ID { get; set; }
        public int EmpresaID { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string? Email { get; set; }
        public int MunicipioID { get; set; }
    }
}
