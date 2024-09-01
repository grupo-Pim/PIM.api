using System.Reflection.Metadata.Ecma335;

namespace PIM.api.Entidades
{
    public class LocalPlantioEntidade
    {
        public LocalPlantioEntidade(int EmpresaID, int Tamanho, string Localizacao)
        {
            this.EmpresaID = EmpresaID;
            this.Tamanho = Tamanho;
            this.Localizacao = Localizacao;
        }

        public int ID { get; set; }
        public int EmpresaID { get; set; }
        public EmpresaEntidade Empresa { get; set; }
        public int Tamanho { get; set; }
        public string Localizacao { get; set; }
        public string? Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
