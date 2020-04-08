using LoginProject.Database;
using LoginProject.Librarys.Texto;
using LoginProject.Models;
using LoginProject.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProject.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private LoginProjectContext _banco;

        public UsuarioRepository(LoginProjectContext banco)
        {
            _banco = banco;

        }
        public void Cadastrar(Usuario usuario)
        {
            _banco.Add(usuario);
            _banco.SaveChanges();
        }
        public void CadastrarSenha(string senha)
        {
            _banco.Add(senha);
            _banco.SaveChanges();
        }
        public Usuario Login(string email)
        {

            Usuario usuario = _banco.Usuariioss.Where(m => m.Email == email).FirstOrDefault();
            return usuario;
        }
        public Usuario ObterUsuario(string Id)
        {
            return _banco.Usuariioss.Find(Id);
        }

        public void Remover(Usuario usuario)
        {
            _banco.Remove(usuario);
            _banco.SaveChanges();
        }
    }
}
