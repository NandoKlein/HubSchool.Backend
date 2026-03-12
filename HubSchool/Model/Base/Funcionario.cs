using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Model.Base
{
    public class Funcionario : AuthEntity
    {
        [Required]
        [Column("name", TypeName = "varchar(80)")]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [Column("email", TypeName = "varchar(40)")]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [Column("address", TypeName = "varchar(100)")]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [Column("birthday", TypeName = "datetime2(6)")]
        public DateTime? Birthday { get; set; }

        [Required]
        [Column("phone", TypeName = "varchar(80)")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [Column("dataDaContratacao", TypeName = "datetime2(6)")]
        public DateTime? DataDaContratacao { get; set; }

        [Column("foto", TypeName = "varchar(200)")]
        public string? Foto { get; set; }
    }
}
