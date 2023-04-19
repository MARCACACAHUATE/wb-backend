using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wb_backend.Models;

namespace wb_backend.Models {
    public class Evento {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Tematica { get; set; }
        [Required]
        public string Direccion { get; set; } = "";
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public float Costo_reservacion { get; set; }
        [Required]
        public float Costo_total { get; set; }
    }
}