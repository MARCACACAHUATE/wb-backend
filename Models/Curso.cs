using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wb_backend.Models;

namespace wb_backend.Models {

    public class Curso {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Tematica { get; set; }
        [Required]
        public string Direccion { get; set; } = "";
        [Required]
        public DateTime Fecha_inicio { get; set; }
        [Required]
        public DateTime Fecha_finalizacion { get; set; }
        [Required]
        public int Espacios_disponibles { get; set; }
        [Required]
        public int Espacios_restantes { get; set; }
        [Required]
        public float Costo_reservacion { get; set; }
        [Required]
        public float Costo_total { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}