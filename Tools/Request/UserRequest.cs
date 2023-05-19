using System.ComponentModel.DataAnnotations;

namespace wb_backend.Tools.Request;

public class UserRequest {

        public string First_name { get; set; } = null!;
        public string Last_name { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Telefono { get; set; } = null!;
        public string? Calle { get; set; }
        public string? Numero { get; set; }
        public string? Municipio { get; set; }
}