using Newtonsoft.Json;

namespace ELearning.Models
{
    public class PartModel : BaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
