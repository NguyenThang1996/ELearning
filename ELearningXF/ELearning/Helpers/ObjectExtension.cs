using ELearning.Helpers;
using System;
using System.Linq;

namespace ELearning.Extensions
{
    #region Defnine hàm convert object to string
    /// <summary>
    ///     ObjectExtension
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public static class ObjectExtension
    {
        /// <summary>Convert object to string</summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <Modified>
        /// Name Date Comment
        /// Nguyen Huy Thang 19/07/2022 created
        /// </Modified>
        public static string ToQueryString(this object obj)
        {
            try
            {
                if (obj != null)
                {
                    return string.Join("&", obj.GetType().GetProperties().Where(p => p.GetValue(obj, null) != null).Select(p => $"{Uri.EscapeDataString(p.Name)}={Uri.EscapeDataString(p.GetValue(obj).ToString())}"));
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionLog.GetException(ex, "ObjectExtension", "ToQueryString");
                return null;
            }
         
        }
    }
    #endregion
}
