using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wb_backend.Models {

    public class EventoSeparacion {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Telefono { get; set; } = null!;
        [Required]
        public string Email { get; set; }  = null!;
        public bool ConfirmaciónPago { get; set; } = false;
        public string HoraEvento { get; set; } = null!;
        public string HoraMontaje { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string Calle { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Colonia { get; set; } = null!;
        public int Id_Evento { get; set; }
        [ForeignKey("Id_Evento")]
        public Evento Evento { get; set; } = null!; 
    }
}