using System.Globalization;
namespace ELearningAPI.Common.Helpers
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class AppException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="AppException" /> class.</summary>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public AppException() : base() { }

        /// <summary>Initializes a new instance of the <see cref="AppException" /> class.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public AppException(string message) : base(message) { }

        /// <summary>Initializes a new instance of the <see cref="AppException" /> class.</summary>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
