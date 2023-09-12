using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula7.Models

{
    public class Reservas
    {

        public int id { get; set; }
        [ForeignKey("idSala")]
        public  int idSala { get; set; }
        [ForeignKey("idUsuario")]
        public int idUsuario { get; set; }
        [ForeignKey("idEvento")]
        public  int idEvento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

    }
}
