namespace wb_backend.Tools.Request {

    public class CursoRequest {

        public string Nombre { get; set; } = null!;
        public string Tematica { get; set; } = null!;
        public string FechaInicio { get; set; } = null!;
        public string FechaFin { get; set; } = null!;
        public string Costo_reservacion { get; set; } = null!;
        public float Costo_total { get; set; }
        public float Calle { get; set; }
        public float Detalle { get; set; }
        public string IdEstadoCurso { get; set; } = "";
        public int Municipio { get; set; }
    }
}