namespace Microsoft.CLU
{
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
        void Run(ConfigurationDictionary commandConfiguration, string[] arguments);
    }
}
