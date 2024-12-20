﻿namespace PIM.api.Entidades
{
    public class UsuarioEntidade
    {
        public UsuarioEntidade()
        {
            
        }
        public UsuarioEntidade(int empresaID, string Nome, string Login, string Senha, string Telefone, bool SerColaborador, bool Ativo)
        {
            this.EmpresaID = empresaID;
            this.Nome = Nome;
            this.Login = Login;
            this.Senha = Senha;
            this.Telefone = Telefone;
            this.SerColaborador = SerColaborador;
            this.Ativo = Ativo;
        }
        public int ID { get; set; }
        public EmpresaEntidade? Empresa { get; set; }
        public int EmpresaID { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string? Telefone { get; set; }
        public Guid? Acesso { get; set; }
        public bool Ativo { get; set; }
        public bool SerColaborador { get; set; }
    }
    public class UsuarioInput
    {
        public int ID { get; set; }
        public int EmpresaID { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int Funcao { get; set; }
        public bool Ativo { get; set; }
        public bool SerColaborador { get; set; }
        public UsuarioEntidade Converter()
        {
            return new UsuarioEntidade(EmpresaID, Nome, Login, Senha, Telefone, SerColaborador, Ativo);
        }
    }
    public class PermissaoEditarUser
    {
        public bool PodeEditar { get; set; }

        public string Nome { get; set; }
        public string Login { get; set; }
        public bool Ativo { get; set; }
        public string? Telefone { get; set; }
        public int Funcao { get; set; }
    }
}