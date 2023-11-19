using System;

namespace Aula7.Models

{
    public class ReservaPostDto
    {


        public int IdReseva { get; set; }
        public string nomeUsuario { get; set; }
        public string nomeSala { get; set; }
        public string Descricao { get; set; } = null!;
        public string DataInicio { get; set; }
        public string DataFim { get; set; }

    }
}
