// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResultTypeEnum.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public enum ResultTypeEnum
    {
        MigrationLevelOutput,
        DatabaseLevelOutput,
        TableLevelOutput,
        MigrationValidationOutput,
        MigrationValidationDatabaseLevelOutput,
        LoginLevelOutput,
        AgentJobLevelOutput
    }
}
