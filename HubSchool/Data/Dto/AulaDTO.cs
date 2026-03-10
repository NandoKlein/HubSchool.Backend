using HubSchool.Model;
using HubSchool.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Data.Dto
{
    public class AulaDTO
    {
        public long Id { get; set; }
        public long IdTurma { get; set; }
        public long IdProfessor { get; set; }
        public Capitulo Capitulo { get; set; }   
        public StatusAula Status { get; set; }   
        public string Resumo { get; set; }
        public DateTime DataDaAula { get; set; }
        public List<Frequencia>? Frequencias { get; set; }
    }
}
