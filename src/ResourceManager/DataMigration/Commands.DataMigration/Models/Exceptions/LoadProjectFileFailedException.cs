// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadProjectFileFailedException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Thrown when load project file scenario fails
    /// </summary>
    [Serializable]
    class LoadProjectFileFailedException : DataMigrationServiceExceptionBase
    {
        public LoadProjectFileFailedException()
        : base() { }

        public LoadProjectFileFailedException(string message)
        : base(message) { }

        public LoadProjectFileFailedException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
