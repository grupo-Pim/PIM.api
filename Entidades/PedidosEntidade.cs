namespace PIM.api.Entidades
{
    public class PedidosEntidade
    {
        public PedidosEntidade()
        {
        }
        public int ID { get; set; }
        public int EmpresaID { get; set; }
        public EmpresaEntidade Empresa { get; set; }

        public int ProdutoID { get; set; }
        public ProdutoEntidade Produto { get; set; }
        public int ClienteID { get; set; }
        public ClienteEntidade Cliente { get; set; }
        public int Quantidade { get; set; }
        public string? Observacao { get; set; }
        public DateTime DtPedido { get; set; }
        public DateTime? DtEntrega { get; set; }
    }
}
