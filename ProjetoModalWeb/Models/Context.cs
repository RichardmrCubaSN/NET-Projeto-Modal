using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoModalWeb.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Function> Functions { get; set; }

    }
}
