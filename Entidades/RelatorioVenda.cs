namespace PIM.api.Entidades
{
    public class RelatorioVenda
    {
        public RelatorioVenda()
        {
        }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public float ValorVenda { get; set; }
        public int QntProdutoVendido { get; set; }
        public int? UsuarioID { get; set; }
        public int? ProdutoID { get; set; }
        public ProdutoEntidade? Produto { get; set; }
    }
    public class RelatorioInput
    {
        public RelatorioInput()
        {
        }
        public int? ProdutoID { get; set; }
        public int? UsuarioID { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
    }
}
