using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearningAPI.Infrastructure.Entities
{
    [Table("Admin.Parts")]
    public class PartEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
