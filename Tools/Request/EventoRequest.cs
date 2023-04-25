namespace wb_backend.Tools.Request {

    public class EventoRequest {

        public string Nombre { get; set; } = null!;
        public string Tematica { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Fecha { get; set; } = null!;
        public float Costo_reservacion { get; set; }
        public float Costo_total { get; set; }
    }
}