// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetProjectArtifactsFailedException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Exception thrown when set project artifacts fails
    /// </summary>
    [Serializable]
    class SetProjectArtifactsFailedException : Exception 
    {
        public SetProjectArtifactsFailedException() { }

        public SetProjectArtifactsFailedException(string message)
            : base(message) { }

        public SetProjectArtifactsFailedException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
