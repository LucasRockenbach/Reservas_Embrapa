using System.ComponentModel.DataAnnotations;

namespace Aula7.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int IdUsuario { get; set; }
        public ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();
        public string Nome { get; set; }
        [Required(ErrorMessage = "E-mail é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; }
    }
}