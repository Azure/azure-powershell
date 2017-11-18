// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotFoundException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Exception thrown when the user requests a DMS object that does not exist
    /// </summary>
    [Serializable]
    class NotFoundException : DataMigrationServiceExceptionBase
    {
        public NotFoundException() { }

        public NotFoundException(string message)
        : base(message) { }

        public NotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
