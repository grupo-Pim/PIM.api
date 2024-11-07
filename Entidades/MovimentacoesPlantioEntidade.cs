using PIM.api.Persistence.Migrations;

namespace PIM.api.Entidades
{
    public class MovimentacoesPlantioEntidade
    {
        public MovimentacoesPlantioEntidade()
        {
        }
        public MovimentacoesPlantioEntidade(int PlantioID, DateTime DataModificacao, byte EtapaAtualizada, byte EtapaAntiga, int ColaboradorID, float QntKG)
        {
            this.PlantioID = PlantioID;
            this.DataModificacao = DataModificacao;
            this.EtapaAtualizada = EtapaAtualizada;
            this.EtapaAntiga = EtapaAntiga;
            this.ColaboradorID = ColaboradorID;
            this.QntKG = QntKG;
        }
        public int ID { get; set; }
        public ColaboradorEntidade Colaborador { get; set; }
        public int ColaboradorID { get; set; }
        public PlantioEntidade Plantio { get; set; }
        public int PlantioID { get; set; }
        public DateTime DataModificacao { get; set; }
        public byte EtapaAtualizada { get; set; }
        public byte EtapaAntiga { get; set; }
        public float? QntKG { get; set; }
    }
    public class MovimentacoesPlantioEntidadeInput
    {
        public int ID { get; set; }
        public int ColaboradorID { get; set; }
        public int PlantioID { get; set; }
        public DateTime DataModificacao { get; set; }
        public byte EtapaAtualizada { get; set; }
        public byte EtapaAntiga { get; set; }
        public float QntKG { get; set; }
    }
}
