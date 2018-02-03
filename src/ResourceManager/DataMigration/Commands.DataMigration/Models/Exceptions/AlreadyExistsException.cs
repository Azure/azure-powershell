// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AlreadyExistsException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Exception thrown when user attempts to create a DMS object that already exists
    /// </summary>
    [Serializable]
    class AlreadyExistsException : DataMigrationServiceExceptionBase
    {
        public AlreadyExistsException() { }

        public AlreadyExistsException(string message)
            : base(message) { }

        public AlreadyExistsException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
