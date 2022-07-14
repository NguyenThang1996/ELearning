using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Models
{
    /// <summary>
    ///     UserModel
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class UserModel : BaseModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
    
}
