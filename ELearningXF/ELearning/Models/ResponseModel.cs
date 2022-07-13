using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Models
{
    public class ResponseModel<T>
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
        public T Data { get; set; }
    }
}
