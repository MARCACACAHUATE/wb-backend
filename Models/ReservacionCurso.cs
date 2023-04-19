using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wb_backend.Models {

    public class ReservacionCurso {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Id_user { get; set; }
        [ForeignKey("Id_user")]
        public User Users { get; set; } = null!;
        [Required]
        public int Id_curso { get; set; }
        [ForeignKey("Id_curso")]
        public Curso Cursos { get; set; } = null!;
        public string Estado { get; set; } = "Esperando pago";
    }
}