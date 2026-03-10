using HubSchool.Model.Base;
using HubSchool.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Model
{
    [Table("aula")]
    public class Aula : BaseEntity
    {
        [Required]
        [Column("idTurma")]
        [ForeignKey("Turma")]
        public long IdTurma { get; set; }

        [Required]
        [Column("idProfessor", TypeName = "bigint")]
        public long IdProfessor { get; set; }

        [Required]
        [Column("capitulo")]        
        public Capitulo Capitulo { get; set; }

        [Required]
        [Column("statusAula")]
        public StatusAula Status { get; set; }

        [Required]
        [Column("resumo", TypeName = "varchar(1000)")]
        [MaxLength(1000)]
        public string Resumo { get; set; }
       
        [Column("dataDaAula", TypeName = "datetime2(6)")]
        public DateTime DataDaAula { get; set; }

        [NotMapped]
        public List<Frequencia>? Frequencias { get; set; }

    }
}
