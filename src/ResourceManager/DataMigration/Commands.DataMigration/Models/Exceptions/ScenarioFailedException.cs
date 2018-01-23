using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Thrown when a scenario does not run successfully
    /// </summary>
    [Serializable]
    class ScenarioFailedException : DataMigrationServiceExceptionBase
    {
        public ScenarioFailedException()
        : base() { }

        public ScenarioFailedException(string message)
        : base(message) { }

        public ScenarioFailedException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
