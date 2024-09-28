namespace PIM.api.Entidades
{
    public class ColaboradorEntidade
    {
        public ColaboradorEntidade()
        {
            
        }
        public int ID { get; set; }
        public int Funcao { get; set; }
        public UsuarioEntidade Usuario { get; set; }
        public int UsuarioID { get; set; }
    }
}
