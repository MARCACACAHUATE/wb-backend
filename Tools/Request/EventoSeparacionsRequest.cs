using System.ComponentModel.DataAnnotations;
using wb_backend.Tools.CustomDataAnnotations;

namespace wb_backend.Tools.Request {

    public class EventoSeparacionsRequest {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [MaxLength(10)]
        [MinLength(10)]
        public string Telefono { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; }  = null!;
        [HourFormat]
        public string HoraEvento { get; set; } = null!;
        [HourFormat]
        public string HoraMontaje { get; set; } = null!;
        [ThreeDaysAfterToday]
        public string Fecha { get; set; } = null!;
        public string Calle { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Colonia { get; set; } = null!;
        public int Id_Evento { get; set; }
    }
}