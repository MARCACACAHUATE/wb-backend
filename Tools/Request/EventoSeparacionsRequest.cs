namespace wb_backend.Tools.Request {

    public class EventoSeparacionsRequest {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Email { get; set; }  = null!;
        public string HoraEvento { get; set; } = null!;
        public string HoraMontaje { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string Calle { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Colonia { get; set; } = null!;
        public int Id_Evento { get; set; }
    }
}