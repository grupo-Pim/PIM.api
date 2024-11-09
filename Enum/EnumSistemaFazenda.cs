using System.ComponentModel;

namespace PIM.api.Enum
{
    public class EnumSistemaFazenda
    {
        public enum EnumTipoUsuario
        {
            Produtor = 0,
            Coordenador = 1,
            Diretor = 2,
        }
        public enum EnumEtapaPlantio
        {
            [Description("Planejando")]
            Planejando = 0,
            [Description("Plantado")]
            Plantado = 1,
            [Description("Colhido (Manter)")]
            Colhido_Manter = 2,
            [Description("Colhido")]
            Colhido = 3,
            [Description("Danificado")]
            Danificado = 4
        }



    }
}
