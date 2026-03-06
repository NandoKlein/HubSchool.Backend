using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Model.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("login", TypeName = "varchar(40)")]
        [MaxLength(80)]
        public string Login { get; set; }

        [Required]
        [Column("senha", TypeName = "varchar(40)")]
        [MaxLength(80)]
        public string Senha { get; set; }

    }

}
