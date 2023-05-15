namespace wb_backend.Tools.Request {

    public class EventoRequest {

        public string NombrePaquete { get; set; } = null!;
        public string Ocasion { get; set; } = null!;
        public string Servicios { get; set; } = null!;
        public string Mobiliario { get; set; } = null!;
        public string ColorGlobos { get; set; } = null!;
        public float CostoEnvioMaterial { get; set; }
        public float Costo_reservacion { get; set; }
        public float Costo_total { get; set; }
        public string Estado { get; set; } = "";
        public int Id_Municipio { get; set; }
    }
}