using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wb_backend.Models {

    public class ReservacionEvento {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Id_user { get; set; }
        [ForeignKey("Id_user")]
        public User Users { get; set; } = null!;
        [Required]
        public int Id_evento { get; set; }
        [ForeignKey("Id_evento")]
        public Evento Eventos { get; set; } = null!;
        public string Estado { get; set; } = "Esperando pago";
    }
}