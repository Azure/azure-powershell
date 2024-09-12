# Overall
This directory contains management plane service clients of Az.Storage module.

## Run Generation
In this directory, run AutoRest:
```
autorest --reset
autorest --use:@autorest/powershell@4.x
```

### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
isSdkGenerator: true
powershell: true
title: DataMigrationServiceClient
description: Data Migration Client
openapi-type: arm
reflect-api-versions: true
azure-arm: true
license-header: MICROSOFT_MIT_NO_VERSION
clear-output-folder: true
useDateTimeOffset: true
```



###
``` yaml
commit: 0b39f4aa008a0cbd9005c363b84e0e3898898186
input-file:
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/datamigration.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/Commands.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/Common.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/ConnectToSourceMySqlTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/ConnectToSourceSqlServerTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/ConnectToTargetAzureDbForMySqlTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/ConnectToTargetSqlDbTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/ConnectToTargetSqlMITask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/ConnectToTargetSqlSqlDbSyncTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/GetUserTablesSqlSyncTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/GetUserTablesSqlTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/MigrateSchemaSqlServerSqlDbTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/MigrateMySqlAzureDbForMySqlSyncTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/MigratePostgreSqlAzureDbForPostgreSqlSyncTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/MigrateSqlServerSqlDbSyncTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/MigrateSqlServerSqlDbTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/MigrateSqlServerSqlMITask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/MigrationValidation.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/MongoDbTasks.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/GetTdeCertificatesSqlTask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/Projects.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/Services.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/Tasks.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/TasksCommon.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/ValidateMigrationInputSqlServerSqlMITask.json
    - https://github.com/Azure/azure-rest-api-specs/blob/$(commit)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2018-07-15-preview/definitions/ValidateSyncMigrationInputSqlServerTask.json

output-folder: Generated

namespace: Microsoft.Azure.Management.DataMigration

directive:
#   - from: swagger-document
#     where: $.info.x-ms-code-generation-settings

  - from: ConnectToSourceSqlServerTask.json
    where: $.definitions.ConnectToSourceSqlServerTaskOutput
    transform: $['required'] = ['resultType']
  - from: MigrateSchemaSqlServerSqlDbTask.json
    where: $.definitions.MigrateSchemaSqlServerSqlDbTaskOutput
    transform: $['required'] = ['resultType']
  - from: MigrateMySqlAzureDbForMySqlSyncTask.json
    where: $.definitions.MigrateMySqlAzureDbForMySqlSyncTaskOutput
    transform: $['required'] = ['resultType']
  - from: MigratePostgreSqlAzureDbForPostgreSqlSyncTask.json
    where: $.definitions.MigratePostgreSqlAzureDbForPostgreSqlSyncTaskOutput
    transform: $['required'] = ['resultType']
  - from: MigrateSqlServerSqlDbSyncTask.json
    where: $.definitions.MigrateSqlServerSqlDbSyncTaskOutput
    transform: $['required'] = ['resultType']
  - from: MigrateSqlServerSqlDbSyncTask.json
    where: $.definitions.MigrateSqlServerSqlDbTaskOutput
    transform: $['required'] = ['resultType']
  - from: MigrateSqlServerSqlDbTask.json
    where: $.definitions.MigrateSqlServerSqlDbTaskOutput
    transform: $['required'] = ['resultType']
  - from: MigrateSqlServerSqlMITask.json
    where: $.definitions.MigrateSqlServerSqlMITaskOutput
    transform: $['required'] = ['resultType']
  - from: MongoDbTasks.json
    where: $.definitions.MongoDbProgress
    transform: $['discriminator'] = "resultType"
  - from: MigrateSqlServerSqlMiSyncTask.json
    where: $.definitions.MigrateSqlServerSqlMISyncTaskOutput
    transform: $['required'] = ['resultType']
  - from: ConnectToSourceSqlServerTask.json
    where: $.definitions.ConnectToSourceSqlServerTaskOutputTaskLevel.properties.databases
    transform: $['type'] = "object"
  - from: ConnectToSourceSqlServerTask.json
    where: $.definitions.ConnectToSourceSqlServerTaskOutputTaskLevel.properties.logins
    transform: $['type'] = "object"
  - from: ConnectToSourceSqlServerTask.json
    where: $.definitions.ConnectToSourceSqlServerTaskOutputTaskLevel.properties.agentJobs
    transform: $['type'] = "object"
  - from: ConnectToSourceSqlServerTask.json
    where: $.definitions.ConnectToSourceSqlServerTaskOutputTaskLevel.properties.databaseTdeCertificateMapping
    transform: $['type'] = "object"
  - from: ConnectToTargetSqlDbTask.json
    where: $.definitions.ConnectToTargetSqlDbTaskOutput.properties.databases
    transform: $['type'] = "object"
  - from: GetTdeCertificatesSqlTask.json
    where: $.definitions.GetTdeCertificatesSqlTaskOutput.properties.base64EncodedCertificates
    transform: $['type'] = "object"
  - from: GetUserTablesSqlSyncTask.json
    where: $.definitions.GetUserTablesSqlSyncTaskOutput.properties.databasesToSourceTables
    transform: $['type'] = "object"
  - from: GetUserTablesSqlSyncTask.json
    where: $.definitions.GetUserTablesSqlSyncTaskOutput.properties.databasesToTargetTables
    transform: $['type'] = "object"
  - from: GetUserTablesSqlSyncTask.json
    where: $.definitions.GetUserTablesSqlSyncTaskOutput.properties.tableValidationErrors
    transform: $['type'] = "object"
  - from: GetUserTablesSqlTask.json
    where: $.definitions.GetUserTablesSqlTaskOutput.properties.databasesToTables
    transform: $['type'] = "object"
  - from: MigrateSqlServerSqlDbTask.json
    where: $.definitions.MigrateSqlServerSqlDbTaskOutputDatabaseLevel.properties.objectSummary
    transform: $['type'] = "object"
  - from: MigrateSqlServerSqlDbTask.json
    where: $.definitions.MigrateSqlServerSqlDbTaskOutputMigrationLevel.properties.databases
    transform: $['type'] = "object"
  - from: MigrateSqlServerSqlDbTask.json
    where: $.definitions.MigrateSqlServerSqlDbTaskOutputMigrationLevel.properties.databaseSummary
    transform: $['type'] = "object"
  - from: MigrateSqlServerSqlMITask.json
    where: $.definitions.MigrateSqlServerSqlMITaskOutputMigrationLevel.properties.agentJobs
    transform: $['type'] = "object"
  - from: MigrateSqlServerSqlMITask.json
    where: $.definitions.MigrateSqlServerSqlMITaskOutputMigrationLevel.properties.logins
    transform: $['type'] = "object"
  - from: MigrateSqlServerSqlMITask.json
    where: $.definitions.MigrateSqlServerSqlMITaskOutputMigrationLevel.properties.serverRoleResults
    transform: $['type'] = "object"
  - from: MigrateSqlServerSqlMITask.json
    where: $.definitions.MigrateSqlServerSqlMITaskOutputMigrationLevel.properties.databases
    transform: $['type'] = "object"
  - from: TasksCommon.json
    where: $.definitions.NonSqlMigrationTaskOutput.properties.dataMigrationTableResults
    transform: $['type'] = "object"
  - where:
      model-name: ConnectToTargetSqlDbSyncTaskInput
    set:
      model-name: ConnectToTargetSqlSqlDbSyncTaskInput
  - where:
      model-name: ConnectToTargetSqlDbSyncTaskProperties
    set:
      model-name: ConnectToTargetSqlSqlDbSyncTaskProperties
```