using LoginProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginProject.Database
{
    public class LoginProjectContext: DbContext
    {
        public LoginProjectContext(DbContextOptions<LoginProjectContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuariioss { get; set; }
        public DbSet<SenhaKeyGenerator> SenhaKeyGeneratorss { get; set; }

    }
}
