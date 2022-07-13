using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearningAPI.Infrastructure.Entities
{
    [Table("Admin.Users")]
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }      
    }
}
