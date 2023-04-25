using Microsoft.EntityFrameworkCore;
using wb_backend.Models;

namespace wb_backend.Models {

    public class WujuDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        private readonly IConfiguration _config;

        public WujuDbContext(
            DbContextOptions<WujuDbContext> options,
            IConfiguration config
            ) : base(options){
            _config = config;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql(_config["ConnectionString"]);

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<User>()
                .HasMany(e => e.Cursos)
                .WithMany(e => e.Users)
                .UsingEntity("Inscripciones_cursos");
        }
    }
}