using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wb_backend.Models {

    public class User {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public string Nickname { get; set; } = "";
        public int Telefono { get; set; }
        public string? Direccion { get; set; }
        [Required]
        public string Email { get; set; } = "";
        public bool Is_admin { get; set; } = false;
        public bool Is_staff { get; set; } = false;

    }
}