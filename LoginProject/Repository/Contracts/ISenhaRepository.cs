using LoginProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProject.Repository.Contracts
{
    public interface ISenhaRepository
    {
        void Cadastrar(SenhaKeyGenerator senha);
        SenhaKeyGenerator Procurar(string Senha);
    }
}
