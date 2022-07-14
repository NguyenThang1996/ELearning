using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Models
{
    /// <summary>
    ///     BaseModel
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class BaseModel
    {
        [JsonProperty("pK_Id")]
        public int PK_Id { get; set; }
        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }
        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }
        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }
        [JsonProperty("createdBy")]
        public int? CreatedBy { get; set; }
        [JsonProperty("updatedDate")]
        public DateTime? UpdatedDate { get; set; }
        [JsonProperty("updatedBy")]
        public int? UpdatedBy { get; set; }
    }
}
