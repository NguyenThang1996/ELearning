using System.ComponentModel.DataAnnotations;

namespace ELearningAPI.Infrastructure.Models
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class StaffModel : BaseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public byte Gender { get; set; }
        public string? GenderName { get; set; }
        public string? Avatar { get; set; }
        public string? PartName { get; set; }
        public int FK_PartId { get; set; }
    }
}
