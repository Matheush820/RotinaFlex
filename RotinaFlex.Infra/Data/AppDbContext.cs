using Microsoft.EntityFrameworkCore;
using RotinaFlex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Recompensa> Recompensas { get; set; }
        public DbSet<Relatorio> Relatorio { get; set; }
        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
