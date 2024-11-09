using System.Globalization;

namespace PIM.api.Entidades
{
    public class SolicitacaoMateriaPrima
    {
        public SolicitacaoMateriaPrima()
        {
        }
        public int ID { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int UsuarioSolcitanteID { get; set; }
        public UsuarioEntidade UsuarioSolcitante { get; set; }
    }
    public class SolicitacaoMateriaPrimaInput
    {
        public SolicitacaoMateriaPrimaInput()
        {
        }
        public int ID { get; set; }
        public string Descricao { get; set; }
        public int UsuarioSolcitanteID { get; set; }
        public int FornecedorID { get; set; }
        public int Quantidade { get; set; }
        
        public SolicitacaoMateriaPrima Converter()
        {
            return new SolicitacaoMateriaPrima
            {
                ID = this.ID,
                Descricao = this.Descricao,
                Quantidade = this.Quantidade,
                UsuarioSolcitanteID = this.UsuarioSolcitanteID,                
            };

        }
    }

}
