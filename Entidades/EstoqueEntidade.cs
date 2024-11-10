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
}