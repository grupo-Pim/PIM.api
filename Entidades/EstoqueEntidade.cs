namespace PIM.api.Entidades
{
    public class EstoqueEntidade
    {
        public EstoqueEntidade()
        {
        }
        public int ID { get; set; }
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public ProdutoEntidade Produto { get; set; }
        public int UsuarioID { get; set; }
        public UsuarioEntidade UsuarioADD { get; set; }
    }
    
    public class EstoqueView
    {
        public EstoqueView()
        {
        }
        public string Quantidade { get; set; }
        public string ProdutoNome { get; set; }
        public string FornecedorNome { get; set; }
        public string ValorKG { get; set; }
    }

}