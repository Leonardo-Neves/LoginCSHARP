using LoginProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProject.Librarys.Login
{
    public class LoginUsuario
    {
        private string Key = "Login.Usuario";
        private Sessao.Sessao _sessao;
        public LoginUsuario(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }

        public void Login(Usuario usuario)
        {
            //Serializar
            string clienteJSONString = JsonConvert.SerializeObject(usuario);

            _sessao.Cadastrar(Key, clienteJSONString);
        }

        public Usuario GetCliente()
        {
            //Deserializar
            if (_sessao.Existe(Key))
            {
                string clienteJSONString = _sessao.Consultar(Key);
                return JsonConvert.DeserializeObject<Usuario>(clienteJSONString); ;
            }
            else
            {
                return null;
            }
        }

        public void Logout()
        {
            _sessao.RemoverTodos();
        }
    }
}
