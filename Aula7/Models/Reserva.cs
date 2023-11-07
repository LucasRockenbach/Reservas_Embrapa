using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula7.Models

{
    public class Reserva
    {
        [Key]

        public int IdReseva {  get; set; }

        public Usuario Usuario { get; set; } = null!;

        public Sala Sala {  get; set; } = null!;

        public string Descricao { get; set; } = null!;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

    }
}
