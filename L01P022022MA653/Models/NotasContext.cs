using Microsoft.EntityFrameworkCore;

namespace L01P022022MA653.Models
{
    public class NotasContext : DbContext
    {
        public NotasContext(DbContextOptions<NotasContext> options) : base(options) { }

        public DbSet<Alumnos> Alumnos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Facultades> Facultades { get; set; }
        public DbSet<Materias> Materias { get; set; }
    }
}
