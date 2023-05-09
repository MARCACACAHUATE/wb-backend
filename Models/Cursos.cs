using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wb_backend.Models {

    public class Cursos {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCursos { get; set; }

        [MaxLength(45)]
        public string? Nombre { get; set; }

        [MaxLength(100)]
        public string? Tematica { get; set; }

        [MaxLength(100)]
        public string? Detalle { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        public int CostoReservacion { get; set; }

        public int CostoTotal { get; set; }

        [MaxLength(100)]
        public string? Calle { get; set; }

        public int Numero { get; set; }

        [MaxLength(100)]
        public string? Municipio { get; set; }

        public int IdEstadoCurso { get; set; }

        public virtual EstadoCurso EstadoCurso { get; set; }

        //public virtual ICollection<UserHasCursos> UserHasCursos { get; set; } = new List<UserHasCursos>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        
    }
}
