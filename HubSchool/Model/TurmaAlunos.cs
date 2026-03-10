using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Model
{
    [Table("turmaAlunos")]
    public class TurmaAlunos
    {
        [Required]
        [Column("idTurma")]    
        public long IdTurma { get; set; }

        [Required]
        [Column("idAluno", TypeName = "bigint")]
        public long IdAluno { get; set; }
    }

}
