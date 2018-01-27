// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServerConnectionFailedException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Thrown when a server fails to connect
    /// </summary>
    [Serializable]
    class ServerConnectionFailedException : DataMigrationServiceExceptionBase
    {
        public ServerConnectionFailedException()
        : base() { }

        public ServerConnectionFailedException(string message)
        : base(message) { }

        public ServerConnectionFailedException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
