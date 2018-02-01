// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataMigrationServiceExceptionBase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Base for all Data Migration Service cmdlet Exceptions
    /// </summary>
    [Serializable]
    public class DataMigrationServiceExceptionBase: Exception
    {
        public DataMigrationServiceExceptionBase() { }

        public DataMigrationServiceExceptionBase(string message)
            : base(message) { }

        public DataMigrationServiceExceptionBase(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
