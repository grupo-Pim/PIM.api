namespace PIM.api.Entidades
{
    public class FornecedorEntidade
    {
        public FornecedorEntidade()
        {
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

        public ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
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
