using HubSchool.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Model
{
    [Table("turma")]
    public class Turma : BaseEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string Name { get; set; }

        
        [Column("codProfessor", TypeName = "int")]        
        public Professor Professor { get; set; }

        [Required]
        [Column("codAluno", TypeName = "int")]      
        public List<Aluno> Alunos { get; set; }
    }
}
