using LoginProject.Database;
using LoginProject.Models;
using LoginProject.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProject.Repository
{
    public class SenhaRepository : ISenhaRepository
    {
        private LoginProjectContext _banco;

        public SenhaRepository(LoginProjectContext banco)
        {
            _banco = banco;
        }
        public void Cadastrar(SenhaKeyGenerator senha)
        { 
            _banco.Add(senha);
            _banco.SaveChanges();
        }

        public SenhaKeyGenerator Procurar(string Senha)
        {
            SenhaKeyGenerator result = _banco.SenhaKeyGeneratorss.Where(m => m.Senha == Senha).FirstOrDefault();
            return result;
        }
    }
}
