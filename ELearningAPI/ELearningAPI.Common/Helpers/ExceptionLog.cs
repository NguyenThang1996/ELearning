namespace ELearningAPI.Common.Helpers
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comment
    /// Nguyen Huy Thang 19/07/2022 created
    /// </Modified>
    public static class ExceptionLog
    {
        /// <summary>Gets the exception.</summary>
        /// <param name="ex">The ex.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="method">The method.</param>
        /// <Modified>
        /// Name Date Comment
        /// Nguyen Huy Thang 19/07/2022 created
        /// </Modified>
        public static void GetException(Exception ex, string controller, string method) {
            try {
                StreamWriter sr = File.AppendText("LogException.txt");
                sr.WriteLine("Controller: " + controller + " - Method: " + method + " - DateTime: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " - An Error occurred: " + ex.StackTrace +
                           " - Message: " + ex.Message + "\n\n");
                sr.Flush();
            }
            catch (Exception _ex)
            {
                GetException(_ex, "ExceptionLog", "GetException");
            }
           
        }                       
    }
}
