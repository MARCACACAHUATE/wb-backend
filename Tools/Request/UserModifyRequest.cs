using System.ComponentModel.DataAnnotations;

namespace wb_backend.Tools.Request;

public class UserModifyRequest{
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        [EmailAddress]
        public string Email { get; set; } = null!;
        [MinLength(10)]
        [MaxLength(10)]
        public string Telefono { get; set; } = null!;
        public string? Calle { get; set; }
        public string? Numero { get; set; }
        public string? Municipio { get; set; }
}