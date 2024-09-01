namespace PIM.api.Entidades
{
    public class ProdutoEntidade
    {
        public ProdutoEntidade()
        {
        }
        public int ID { get; set; }
        public EmpresaEntidade Empresa { get; set; }
        public int EmpresaID { get; set; }
        public string Nome { get; set; }
        public int? ValorVendaKG { get; set; }
        public bool Ativo { get; set; }

        public ICollection<ProdutoFornecedor> ProdutoFornecedor { get; set; }
    }
}
