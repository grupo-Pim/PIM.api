namespace PIM.api.Entidades
{
    public class ProdutoFornecedor
    {
        public ProdutoFornecedor()
        {
        }

        public int ID { get; set; }
        public FornecedorEntidade Fornecedor { get; set; }
        public int FornecedorID { get; set; }
        public ProdutoEntidade Produto { get; set; }
        public int ProdutoID { get; set; }
        public float? Valor { get; set; }
    }
}
