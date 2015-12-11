namespace Microsoft.CLU.Run
{
    /// <summary>
    /// Represents a mode in which the CluRun can run.
    /// </summary>
    internal interface IRunMode
    {
        /// <summary>
        /// Check if the IRunMode implementation can handle the arguments.
        /// </summary>
        /// <param name="arguments">The argument to inspect to see implementation can handle it</param>
        /// <returns></returns>
        bool CanHandle(string[] arguments);

        /// <summary>
        /// Run a command that is identified by the arguments and supported by this
        /// IRunMode implementation.
        /// </summary>
        /// <param name="arguments">The arguments</param>
        Microsoft.CLU.CommandModelErrorCode Run(string[] arguments);
    }
}
