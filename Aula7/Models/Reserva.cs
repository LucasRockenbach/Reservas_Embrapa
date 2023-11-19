using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula7.Models

{
    public class Reserva
    {
        [Key]

        public int IdReseva { get; set; }

        public Usuario Usuario { get; set; } = null!;

        public Sala Sala { get; set; } = null!;
        public int idUsuario { get; set; }
        public int idSala { get; set; }

        public string Descricao { get; set; } = null!;
        public string DataInicio { get; set; }
        public string DataFim { get; set; }

    }
}
