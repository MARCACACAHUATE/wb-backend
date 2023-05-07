using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wb_backend.Models;

namespace wb_backend.Models {
    public class Evento {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? NombrePaquete { get; set; }
        public string? Ocasion { get; set; }
        public string? Servicios { get; set; }
        public string? Mobiliario { get; set; }
        public string ColorGlobos { get; set; } = "";
        public float CostoEnvioMaterial { get; set; }
        [Required]
        public string Estado { get; set; } = "";
        [Required]
        public float Costo_reservacion { get; set; }
        [Required]
        public float Costo_total { get; set; }
        public int Id_Municipio { get; set; }
        [ForeignKey("Id_Municipio")]
        public Municipio Municipio { get; set; } = null!;
        public EventoSeparacion? Separacion { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}