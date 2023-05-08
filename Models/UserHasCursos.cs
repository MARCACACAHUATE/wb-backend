using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wb_backend.Models
{
    public class UserHasCursos
    {
        [Key]
        [Column(Order = 0)]
        public int CursosId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int UsersId { get; set; }

        [ForeignKey("CursosId")]
        public virtual Cursos Cursos { get; set; }

        [ForeignKey("UsersId")]
        public virtual User User { get; set; }
    }
}
