using HubSchool.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Data.Dto
{
    public class TurmaDTO
    {    
        public long Id { get; set; }
        public string Name { get; set; }
        public Professor Professor { get; set; }   
        public List<Aluno> Alunos { get; set; }
    }
}
