// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidConnectionTypeException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Thrown when there is an invalid connection type
    /// </summary>
    [Serializable]
    public class InvalidConnectionTypeException : DataMigrationServiceExceptionBase
    {
        public InvalidConnectionTypeException()
            : base() { }

        public InvalidConnectionTypeException(string message)
            : base(message) { }

        public InvalidConnectionTypeException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
