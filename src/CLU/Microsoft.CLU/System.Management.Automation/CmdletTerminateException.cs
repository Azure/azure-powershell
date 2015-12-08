namespace System.Management.Automation
{
    /// <summary>
    /// Represents terminating error when the cmdlet cannot continue, or when you do not want the
    /// cmdlet to continue to process records.
    /// </summary>
    internal class CmdletTerminateException : Exception
    {
        /// <summary>
        /// The error record containing details of the terminating conditions.
        /// </summary>
        public ErrorRecord ErrorRecord { get; private set; }

        /// <summary>
        /// Creates an instance of CmdletTerminateException.
        /// </summary>
        /// <param name="errorRecord">The error record</param>
        public CmdletTerminateException(ErrorRecord errorRecord)
        {
            ErrorRecord = errorRecord;
        }
    }
}
