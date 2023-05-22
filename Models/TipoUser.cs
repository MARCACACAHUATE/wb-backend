using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wb_backend.Tools;

namespace wb_backend.Models {

    public class TipoUser {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TypeUser { get; set; } = Role.Cliente.ToString();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}