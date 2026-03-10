using HubSchool.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Model
{
    [Table("frequencia")]
    public class Frequencia
    {
        [Required]
        [Column("idAula")]
        public long IdAula { get; set; }

        [Required]
        [Column("idAluno", TypeName = "bigint")]
        public long IdAluno { get; set; }

        [Required]
        [Column("presenca")]
        public Presenca Presenca { get; set; }
    }

}
