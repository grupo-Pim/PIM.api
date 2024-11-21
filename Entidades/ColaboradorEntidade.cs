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
    public class ColaboradorInput
    {
        public ColaboradorInput()
        {
        }
        public int ID { get; set; }
        public int Funcao { get; set; }
        public UsuarioInput Usuario { get; set; }
        public int UsuarioID { get; set; }
        public ColaboradorEntidade Converter()
        {
            return new ColaboradorEntidade
            {
                Funcao = this.Funcao,
                Usuario = this.Usuario.Converter(),
                UsuarioID = this.UsuarioID,
            };
        } 
    }
}
