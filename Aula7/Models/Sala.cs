using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Aula7.Data;

namespace Aula7.Models
{
    public class Sala
    {
        [Required]
        [Key]
        public int idSala { get; set; }
        [JsonIgnore]
        public ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public Boolean Disponibilidade { get; set; }
        public String Descricao { get; set;}
        public String Bloco { get; set;}
        public int Andar { get; set;}
        public int Numero { get; set;}
    }
}
