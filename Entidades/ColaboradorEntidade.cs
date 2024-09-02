namespace PIM.api.Entidades
{
    public class ColaboradorEntidade
    {
        public ColaboradorEntidade()
        {
            
        }
        public ColaboradorEntidade(int empresaID, string nome, string login, 
                                string senha, int funcao, bool serColaborador)
        {
            this.Funcao = funcao;
            this.Usuario.SerColaborador = serColaborador;
            this.Usuario.Nome = nome;
            this.Usuario.Login = login;
            this.Usuario.Senha = senha;
            this.Usuario.EmpresaID = empresaID;
        }
        public int ID { get; set; }
        public int Funcao { get; set; }
        public UsuarioEntidade Usuario { get; set; }
        public int UsuarioID { get; set; }
    }
}
