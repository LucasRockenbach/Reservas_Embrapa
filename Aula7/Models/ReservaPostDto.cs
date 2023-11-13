using System;

namespace Aula7.Models

{
    public class ReservaPostDto
    {


        public int IdReseva { get; set; }
        public int idUsuario { get; set; }
        public int idSala { get; set; }
        public string Descricao { get; set; } = null!;
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

    }
}
