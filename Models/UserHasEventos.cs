/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wb_backend.Models
{
    public class UserHasEventos
    {
        [Key, Column(Order = 0)]
        public int EventosId { get; set; }

        [Key, Column(Order = 1)]
        public int UsersId { get; set; }

        [ForeignKey("EventosId")]
        public Evento Evento { get; set; }

        [ForeignKey("UsersId")]
        public User User { get; set; }
    }
}
*/