namespace Microsoft.CLU
{
    public enum CommandModelErrorCode
    {
        Success = 0,
        InternalFailure = -1,
        NonTerminatingError = 1,
        TerminatingError = 2,
        CommandNotFound = 3,

        MissingParameters = 10,

        PackageNotFound = 20
    }

    /// <summary>
    /// The contract that different "Programming Model" model classes needs to implement.
    /// </summary>
    public interface ICommandModel
    {
        /// <summary>
        /// Runs the command programming model given its configuration.
        /// </summary>
        /// <param name="commandConfiguration">Date from the command configuration file.</param>
        /// <param name="arguments">The command-line arguments array</param>
        CommandModelErrorCode Run(ConfigurationDictionary commandConfiguration, string[] arguments);
    }
}
