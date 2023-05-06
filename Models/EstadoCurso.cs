namespace wb_backend.Models {

    public class EstadoCurso {
        public int Id { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}