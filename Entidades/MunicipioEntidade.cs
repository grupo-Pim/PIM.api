namespace PIM.api.Entidades
{
    public class MunicipioEntidade
    {
        public MunicipioEntidade()
        {

        }
        public int ID { get; set; }
        public string Nome { get; set; }
        public int UFID { get; set; }
        public EstadoEntidade UF { get; set; }
    }
}
