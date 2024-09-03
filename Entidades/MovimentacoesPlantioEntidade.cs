namespace PIM.api.Entidades
{
    public class MovimentacoesPlantioEntidade
    {
        public MovimentacoesPlantioEntidade()
        {
        }
        public int ID { get; set; }
        public ColaboradorEntidade Colaborador { get; set; }
        public int ColaboradorID { get; set; }
        public PlantioEntidade Plantio { get; set; }
        public int PlantioID { get; set; }
        public DateTime DataModificacao { get; set; }
        public byte EtapaAtualizada { get; set; }
        public byte EtapaAntiga { get; set; }
    }
}
