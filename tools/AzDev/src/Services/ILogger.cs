namespace AzDev.Services
{
    /// <summary>
    /// Provides logging methods that can be used by various components.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a debug message.
        /// </summary>
        void Debug(string message);

        /// <summary>
        /// Logs a verbose message.
        /// </summary>
        void Verbose(string message);

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        void Warning(string message);

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        void Information(string message);
    }
}