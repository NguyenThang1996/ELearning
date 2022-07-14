using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ELearning.Models
{
    /// <summary>
    ///     UserLoginModel
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class UserLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    
}
