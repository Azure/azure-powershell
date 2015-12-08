namespace System.Management.Automation.Runspaces
{
    /// <summary>
    /// Provides a means to create a single runspace.
    /// </summary>
    public static class RunspaceFactory
    {
        /// <summary>
        /// Creates a runspace.
        /// </summary>
        /// <param name="initialSessionState">The initial session state of the runspace.</param>
        /// <returns>Runspace instance</returns>
        public static Runspace CreateRunspace(InitialSessionState initialSessionState)
        {
            if (initialSessionState == null)
            {
                throw new ArgumentNullException("initialSessionState");
            }

            return new CLURunspace(initialSessionState);
        }
    }
}
