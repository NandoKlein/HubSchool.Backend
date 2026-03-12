using HubSchool.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Model
{
    [Table("homework")]
    public class Homework
    {
        [Required]
        [Column("idAula")]
        public long IdAula { get; set; }

        [Required]
        [Column("idAluno", TypeName = "bigint")]
        public long IdAluno { get; set; }

        [Required]
        [Column("idProfessor", TypeName = "bigint")]
        public long IdProfessor { get; set; }

        [Required]
        [Column("idTurma", TypeName = "bigint")]
        public long IdTurma { get; set; }

        [Required]
        [Column("statusHomework")]
        public StatusHomework StatusHomework { get; set; }

        [Column("nota", TypeName = "bigint")]
        public long? Nota { get; set; }
        
        [Column("comentario", TypeName = "varchar(1000)")]
        [MaxLength(1000)]
        public string? Comentario { get; set; }

        [Column("arquivo", TypeName = "varchar(200)")]
        public string? Arquivo { get; set; }
        
        [Column("prazoDeEntrega", TypeName = "datetime2(6)")]
        public DateTime? PrazoDeEntrega { get; set; }
    }
}
