// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PreConditionFailedException.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.DataMigration.Models.Exceptions
{
    /// <summary>
    /// Exception thrown for Bad Request Response
    /// </summary>
    [Serializable]
    class PreConditionFailedException : DataMigrationServiceExceptionBase
    {
        public PreConditionFailedException() { }

        public PreConditionFailedException(string message)
        : base(message) { }

        public PreConditionFailedException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
