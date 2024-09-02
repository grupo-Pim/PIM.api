namespace PIM.api.Entidades
{
    public class PlantioEntidade
    {
        public PlantioEntidade()
        {
            
        }
        public int ID { get; set; }
        public int EmpresaID { get; set; }
        public EmpresaEntidade Empresa { get; set; }
        public int ProdutoID { get; set; }
        public ProdutoEntidade Produto { get; set; }
        public string? Descricao { get; set; }
        public string? Nome { get; set; }
        public LocalPlantioEntidade Local { get; set; }
        public int LocalID { get; set; }
        public DateTime DataPlantio { get; set; }
        public DateTime? DataColheita { get; set; }
        public byte Etapa { get; set; }
    }
}
