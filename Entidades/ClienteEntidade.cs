namespace PIM.api.Entidades
{
    public class ClienteEntidade
    {
        public ClienteEntidade()
        {
        }
        public int ID { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Cep { get; set; }
        public int MunicipioID { get; set; }
        public MunicipioEntidade Municipio { get; set; }
        public int UsuarioID { get; set; }
        public UsuarioEntidade Usuario { get; set; }
    }
}
