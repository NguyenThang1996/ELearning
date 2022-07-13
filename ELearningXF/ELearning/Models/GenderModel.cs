using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Models
{
    public class GenderModel
    {
        [JsonProperty("id")]
        public byte Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
