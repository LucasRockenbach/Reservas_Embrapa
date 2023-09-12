using Microsoft.CodeAnalysis.Editing;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Aula7.Models
{
    public class Evento
    {
        [Required]
        [Key]
        public int IdEvento { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }

        public DateTime dataInicio { get; set; }
        
        public DateTime dataFim { get; set; }
        
    }
}
