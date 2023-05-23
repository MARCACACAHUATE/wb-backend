using Microsoft.EntityFrameworkCore;
using wb_backend.Models;

namespace wb_backend.Models {

    public class WujuDbContext : DbContext {
        public DbSet<User> Users { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<TipoUser> TipoUsers { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<EventoSeparacion> EventoSeparacions { get; set; }
        public DbSet<CursoSeparacion> CursoSeparacion { get; set; }

        private readonly IConfiguration _config;

        public WujuDbContext(
            DbContextOptions<WujuDbContext> options
            ) : base(options){
        }

       /* public WujuDbContext(DbContextOptions options) : base(options)
        {
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(); // Habilitar registro de datos sensibles
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
        // modelBuilder.Entity<CursoSeparacion>()
        //             .HasOne(c => c.Cursos)
        //             .WithMany()
        //             .HasForeignKey(c => c.IdCursos);

            // modelBuilder.Entity<User>()
            //     .HasMany(e => e.Cursos)
            //     .WithMany(e => e.Users)
            //     .UsingEntity("UserHasCursos");

            modelBuilder.Entity<User>()
                .HasMany(e => e.Eventos)
                .WithMany(e => e.Users)
                .UsingEntity("UserHasEventos");

            base.OnModelCreating(modelBuilder);    


            
        }
    }
}