using HubSchool.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Model
{
    [Table("turma")]
    public class Turma : BaseEntity
    {      
        [Required]
        [Column("name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [Column("idProfessor", TypeName = "bigint")]        
        public long IdProfessor { get; set; }

        [NotMapped]
        public List<long> IdAlunos { get; set; }

    }
}
