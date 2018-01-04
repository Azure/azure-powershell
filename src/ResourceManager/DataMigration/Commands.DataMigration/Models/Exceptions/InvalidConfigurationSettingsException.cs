// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidConfigurationSettingsException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Thrown when user inputs invalid settings for migration
    /// </summary>
    [Serializable]
    public class InvalidConfigurationSettingsException : DataMigrationServiceExceptionBase
    {
        public InvalidConfigurationSettingsException()
            : base() { }

        public InvalidConfigurationSettingsException(string message)
            : base(message) { }

        public InvalidConfigurationSettingsException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
