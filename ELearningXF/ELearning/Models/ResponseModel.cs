using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Models
{
    /// <summary>
    ///     ResponseModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class ResponseModel<T>
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
        public T Data { get; set; }
    }
}
