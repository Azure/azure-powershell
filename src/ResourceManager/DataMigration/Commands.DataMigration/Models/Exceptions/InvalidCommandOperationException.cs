// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidCommandOperationException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Thrown when user performs a command that is invalid for the migration task
    /// </summary>
    [Serializable]
    public class InvalidCommandOperationException : DataMigrationServiceExceptionBase
    {
        public InvalidCommandOperationException()
            : base() { }

        public InvalidCommandOperationException(string message)
            : base(message) { }

        public InvalidCommandOperationException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
