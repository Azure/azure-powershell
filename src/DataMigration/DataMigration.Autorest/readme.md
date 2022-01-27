<!-- region Generated -->
# Az.DataMigration
This directory contains the PowerShell module for the DataMigration service.

---
## Status
[![Az.DataMigration](https://img.shields.io/powershellgallery/v/Az.DataMigration.svg?style=flat-square&label=Az.DataMigration "Az.DataMigration")](https://www.powershellgallery.com/packages/Az.DataMigration/)

## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.2.3 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.DataMigration`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
branch: 7086ee861c3a6196bb98f8b327af11d03e545a05
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file:
  - $(repo)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2021-10-30-preview/sqlmigration.json

title: DataMigration
module-version: 0.1.0

directive:

  #Swagger description changes
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataMigration/sqlMigrationServices/{sqlMigrationServiceName}"].get
    transform: $["description"] = "Retrieve the Database Migration Service."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataMigration/sqlMigrationServices/{sqlMigrationServiceName}/listMonitoringData"].post
    transform: $["description"] = "Retrieve the registered Integration Runtime nodes and their monitoring data for a given Database Migration Service"

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}"].get
    transform: $["description"] = "Retrieve the specified database migration for a given SQL Managed Instance."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}"].get
    transform: $["description"] = "Retrieve the specified database migration for a given SQL VM."
  
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}/cutover"].post
    transform: $["description"] = "Initiate cutover for in-progress online database migration to SQL Managed Instance."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}/cutover"].post
    transform: $["description"] = "Initiate cutover for in-progress online database migration to SQL VM."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataMigration/sqlMigrationServices/{sqlMigrationServiceName}"].put
    transform: $["description"] = "Create or Update Database Migration Service."
  
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}"].put
    transform: $["description"] = "Create a new database migration to a given SQL Managed Instance."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}"].put
    transform: $["description"] = "Create a new database migration to a given SQL VM."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataMigration/sqlMigrationServices/{sqlMigrationServiceName}"].delete
    transform: $["description"] = "Delete Database Migration Service."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}/cancel"].post
    transform: $["description"] = "Stop in-progress database migration to SQL Managed Instance."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/{sqlVirtualMachineName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}/cancel"].post
    transform: $["description"] = "Stop in-progress database migration to SQL VM."
  
  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataMigration/sqlMigrationServices/{sqlMigrationServiceName}"].patch
    transform: $["description"] = "Update Database Migration Service."

  - from: swagger-document
    where: $.definitions.DatabaseMigrationProperties.properties.scope
    transform: $["description"] = "Resource Id of the target resource (SQL VM or SQL Managed Instance)"

  
  #Remove the unexpanded parameter set
  #For New-* cmdlets, ViaIdentity is not required, so CreateViaIdentityExpanded is removed as well
  - where:
      variant: ^Create$|^CreateViaIdentity$|^CreateViaIdentityExpanded$|^Update$|^UpdateViaIdentity$
    remove: true

  - where:
      verb: Remove
      subject: SqlMigrationServiceNode
      variant: 
        ^Delete$|^DeleteViaIdentity$
    remove: true

  - where:
      variant: ^Cutover$|^CutoverViaIdentity$|^CutoverViaIdentityExpanded$
    remove: true

  - where:
      variant: ^Cancel$|^CancelViaIdentity$|^CancelViaIdentityExpanded$
    remove: true

  - where:
      variant: ^Regenerate$|^RegenerateViaIdentity$|^RegenerateViaIdentityExpanded$
    remove: true

  #Changing Naming convention
  - where:
      subject: (DatabaseMigrationSqlMi$)
    set:
      subject: ToSqlManagedInstance

  - where:
      subject: DatabaseMigrationsSqlMi
    set:
      subject: ToSqlManagedInstance

  - where:
      subject: (DatabaseMigrationSqlVM$)
    set:
      subject: ToSqlVM

  - where:
      subject: DatabaseMigrationsSqlVM
    set:
      subject: ToSqlVM
  
  - where:
      subject: (MonitoringData$)
    set:
      subject: IntegrationRuntimeMetric

  - where:
      subject: (^SqlMigrationService)
    set:
      subject: SqlService

  #Changing parameter names
  - where:
      verb: New
      subject: ToSqlVM
      parameter-name: OfflineConfigurationOffline
    set:
      parameter-name: Offline

  - where:
      verb: New
      subject: ToSqlManagedInstance
      parameter-name: OfflineConfigurationOffline
    set:
      parameter-name: Offline

  - where:
      verb: New
      subject: ToSqlVM
      parameter-name: TargetLocationStorageAccountResourceId
    set:
      parameter-name: StorageAccountResourceId

  - where:
      verb: New
      subject: ToSqlManagedInstance
      parameter-name: TargetLocationStorageAccountResourceId
    set:
      parameter-name: StorageAccountResourceId
  
  - where:
      verb: New
      subject: ToSqlVM
      parameter-name: TargetLocationAccountKey
    set:
      parameter-name: StorageAccountKey

  - where:
      verb: New
      subject: ToSqlManagedInstance
      parameter-name: TargetLocationAccountKey
    set:
      parameter-name: StorageAccountKey

  # Remove the set-* cmdlet
  - where:
      verb: Set
    remove: true

  # Formatting
  - where:
      model-name: SqlMigrationService
    set:
      format-table:
        properties:
          - Location
          - Name
          - Type
          - ProvisioningState
          - IntegrationRuntimeState
  - where:
      model-name: DatabaseMigrationSqlMi
    set:
      format-table:
        properties:
          - Name
          - Type
          - Kind
          - ProvisioningState
          - MigrationStatus
  - where:
      model-name: DatabaseMigrationSqlVm
    set:
      format-table:
        properties:
          - Name
          - Type
          - Kind
          - ProvisioningState
          - MigrationStatus
  - where:
      model-name: DatabaseMigration
    set:
      format-table:
        properties:
          - Name
          - Type
          - Kind
          - ProvisioningState
          - MigrationStatus
```
