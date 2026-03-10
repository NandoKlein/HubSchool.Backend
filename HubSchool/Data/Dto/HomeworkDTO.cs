using HubSchool.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Data.Dto
{
    public class HomeworkDTO
    { 
        public long IdAula { get; set; }

        public long IdAluno { get; set; }

        public long IdProfessor { get; set; }
      
        public StatusHomework StatusHomework { get; set; }
       
        public long? Nota { get; set; }
      
        public string? Comentario { get; set; }

        public string? Arquivo { get; set; }

        public DateTime? PrazoDeEntrega { get; set; }
    }
}
