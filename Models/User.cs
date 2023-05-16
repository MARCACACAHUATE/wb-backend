using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wb_backend.Models {

    public class User {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public int Telefono { get; set; }
        public string? Calle { get; set; }
        public string? Numero { get; set; }
        public string? Municipio { get; set; }
        public int Id_EstadoCurso { get; set; }
        [ForeignKey("Id_EstadoCurso")]
        public EstadoCurso EstadoCurso { get; set; } = null!;
        public int Id_TipoUser {get; set; }
        [ForeignKey("Id_TipoUser")]
        public TipoUser TipoUser { get; set; } = null!;
        //public virtual ICollection<UserHasCursos> UserHasCursos { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
        public virtual ICollection<Cursos> Cursos { get; set; } = new List<Cursos>();
    }
}