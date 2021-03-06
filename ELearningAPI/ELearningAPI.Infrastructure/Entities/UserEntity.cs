using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearningAPI.Infrastructure.Entities
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    [Table("Admin.Users")]
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }      
    }
}
