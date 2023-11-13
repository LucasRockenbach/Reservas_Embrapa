using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Aula7.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int IdUsuario { get; set; }
        [JsonIgnore]
        public ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();
        public string Nome { get; set; } = null!;
        [Required(ErrorMessage = "E-mail é obrigatório")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; } = null!;
    }
}