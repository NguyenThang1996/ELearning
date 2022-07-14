using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Models
{
    /// <summary>
    ///     <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class GenderModel
    {
        [JsonProperty("id")]
        public byte Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
