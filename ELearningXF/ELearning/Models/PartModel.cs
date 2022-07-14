using Newtonsoft.Json;

namespace ELearning.Models
{
    /// <summary>
    ///     PartModel
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class PartModel : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
