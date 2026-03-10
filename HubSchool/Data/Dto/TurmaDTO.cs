using HubSchool.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Data.Dto
{
    public class TurmaDTO
    {    
        public long Id { get; set; }
        public string Name { get; set; }
        public long IdProfessor { get; set; }
        public List<long> IdAlunos { get; set; }

    }
}
