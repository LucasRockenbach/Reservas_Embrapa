using Aula7.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula7.Data
{
    public class AulaDbContext : DbContext
    {
        public AulaDbContext (DbContextOptions <AulaDbContext> options): base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Salas> Salas { get; set; }
    }
}
