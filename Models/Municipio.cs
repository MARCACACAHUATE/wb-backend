namespace wb_backend.Models {

    public class Municipio {
        public int Id { get; set; }
        public string NombreMunicipio { get; set; } = "";
        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }
}