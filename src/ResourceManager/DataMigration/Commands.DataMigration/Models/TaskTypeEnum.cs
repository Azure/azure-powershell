// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskTypeEnum.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public enum TaskTypeEnum
    {
        MigrateSqlServerSqlDb,
        ConnectToSourceSqlServer,
        ConnectToTargetSqlDb,
        GetUserTablesSql,
        ConnectToTargetSqlDbMi,
        MigrateSqlServerSqlDbMi,
        ValidateMigrationInputSqlServerSqlDbMi
    }
}
