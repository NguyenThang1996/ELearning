using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Models
{
    public class StaffModel : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("tel")]
        public string Tel { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("gender")]
        public byte Gender { get; set; }
        [JsonProperty("genderName")]
        public string? GenderName { get; set; }
        [JsonProperty("avatar")]
        public string? Avatar { get; set; }
        [JsonProperty("partName")]
        public string? PartName { get; set; }
        [JsonProperty("fK_PartId")]
        public int FK_PartId { get; set; }
    }
}
