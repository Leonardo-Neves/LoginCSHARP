using LoginProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProject.Repository.Contracts
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email);
        void Cadastrar(Usuario usuario);
        void CadastrarSenha(string senha);
        void Remover(Usuario usuario);
        Usuario ObterUsuario(string Id);
    }
}
