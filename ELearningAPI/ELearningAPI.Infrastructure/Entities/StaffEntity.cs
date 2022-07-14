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
    [Table("Admin.Staffs")]
    public class StaffEntity : BaseEntity
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public byte Gender { get; set; }
        public string? Avatar { get; set; }
        //[ForeignKey("FK_Admin.Staffs_Admin.Parts")]
        public int FK_PartId { get; set; }       
    }
}
