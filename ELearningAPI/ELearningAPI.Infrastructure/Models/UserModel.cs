using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearningAPI.Infrastructure.Models
{
    public class UserModel : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }      
    }
}
