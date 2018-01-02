// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultTypeEnum.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public enum ResultTypeEnum
    {
        MigrationLevelOutput,
        DatabaseLevelOutput,
        TableLevelOutput,
        MigrationValidationOutput,
        MigrationValidationDatabaseLevelOutput
    }
}
