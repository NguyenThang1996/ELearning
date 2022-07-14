using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELearning.Extensions
{
    #region Defnine hàm convert object to string
    /// <summary>
    ///     Extension covert object to string
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public static class ObjectExtension
    {
        public static string ToQueryString(this object obj)
        {
            return string.Join("&", obj.GetType().GetProperties().Where(p => p.GetValue(obj, null) != null).Select(p => $"{Uri.EscapeDataString(p.Name)}={Uri.EscapeDataString(p.GetValue(obj).ToString())}"));
        }
    }
    #endregion
}
