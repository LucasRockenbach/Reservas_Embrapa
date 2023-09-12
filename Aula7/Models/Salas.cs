using System.ComponentModel.DataAnnotations;
using Aula7.Data;

namespace Aula7.Models
{
    public class Salas
    {
        [Required]
        [Key]
        public int idSala { get; set; }
        public string name { get; set; }
        public int capacidade { get; set; }

        public Boolean disponibilidade { get; set; }
        public String descricao { get; set;}
        public String bloco { get; set;}

        public int andar { get; set;}

        public int numero { get; set;}
    }
}
