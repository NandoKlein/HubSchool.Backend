using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubSchool.Model.Base
{
    public class AuthEntity : BaseEntity
    {
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
