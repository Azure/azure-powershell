// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidMigrationTaskNameException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Thrown when user inputs an invalid migration task name
    /// </summary>
    [Serializable]
    public class InvalidMigrationTaskNameException : DataMigrationServiceExceptionBase
    {
        public InvalidMigrationTaskNameException()
            : base() { }

        public InvalidMigrationTaskNameException(string message)
            : base(message) { }

        public InvalidMigrationTaskNameException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
