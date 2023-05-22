using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wb_backend.Models;

namespace wb_backend.Models
{
    public class CursoSeparacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(45)]
        public string First_name { get; set; }
        
        [Required]
        [StringLength(45)]
        public string Last_name { get; set; }
        
        [Required]  
        public int Edad { get; set; }
        
        public int Telefono { get; set; }
        
        [Required]
        [StringLength(45)]
        public string Email { get; set; }
        
        [Required]
        public int Cantidad_personas_contratadas { get; set; }
        
        [Required]
        public int IdCursos { get; set; }
        
        [ForeignKey("IdCursos")]
        public virtual Cursos Cursos { get; set; }

    }
}
