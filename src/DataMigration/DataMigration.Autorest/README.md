<!-- region Generated -->
# Az.DataMigration
This directory contains the PowerShell module for the DataMigration service.

---
## Info
- Modifiable: yes
- Generated: all
- Committed: yes
- Packaged: yes

---
## Detail
This module was primarily generated via [AutoRest](https://github.com/Azure/autorest) using the [PowerShell](https://github.com/Azure/autorest.powershell) extension.

## Module Requirements
- [Az.Accounts module](https://www.powershellgallery.com/packages/Az.Accounts/), version 2.7.5 or greater

## Authentication
AutoRest does not generate authentication code for the module. Authentication is handled via Az.Accounts by altering the HTTP payload before it is sent.

## Development
For information on how to develop for `Az.DataMigration`, see [how-to.md](how-to.md).
<!-- endregion -->

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
commit: e8c359d8821038f133695c9b1f4cf40d330cbc80
require:
  - $(this-folder)/../../readme.azure.noprofile.md
input-file: 
  - $(repo)/specification/datamigration/resource-manager/Microsoft.DataMigration/preview/2022-03-30-preview/sqlmigration.json

title: DataMigration
module-version: 0.1.0

# For new modules, please avoid setting 3.x using the use-extension method and instead, use 4.x as the default option
use-extension:
  "@autorest/powershell": "3.x"

directive:

  #Swagger description changes
  #- from: swagger-document
  #  where: $.info
  #  transform: $["version"] = "2022-01-30-preview"
    
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
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDbInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}"].get
    transform: $["description"] = "Retrieve the specified database migration for a given SQL Db."
  
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
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDbInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}"].put
    transform: $["description"] = "Create a new database migration to a given SQL Db. This command can migrate data from the selected source database tables to the target database tables. If the target database have no table existing, please use [New-AzDataMigrationSqlServerSchema](https://learn.microsoft.com/powershell/module/az.datamigration/new-azdatamigrationsqlserverschema) command to migrate schema objects from source database to target databse."

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
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDbInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}/cancel"].post
    transform: $["description"] = "Stop in-progress database migration to SQL Db."

  - from: swagger-document
    where: $.paths["/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{sqlDbInstanceName}/providers/Microsoft.DataMigration/databaseMigrations/{targetDbName}"].delete
    transform: $["description"] = "Remove the specified database migration for a given SQL Db."
  
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
      subject: (DatabaseMigrationSqlDb$)
    set:
      subject: ToSqlDb

  - where:
      subject: DatabaseMigrationsSqlDb
    set:
      subject: ToSqlDb
  
  - where:
      subject: (MonitoringData$)
    set:
      subject: IntegrationRuntimeMetric

  - where:
      subject: (^SqlMigrationService)
    set:
      subject: SqlService

  #Deleting parameters :
  - where:
      verb: New
      subject: ToSqlDb
      parameter-name: MigrationOperationId
    hide: true

  - where:
      verb: New
      subject: ToSqlManagedInstance
      parameter-name: MigrationOperationId
    hide: true

  - where:
      verb: New
      subject: ToSqlVM
      parameter-name: MigrationOperationId
    hide: true

  - where:
      verb: New
      subject: ToSqlDb
      parameter-name: ProvisioningError
    hide: true

  - where:
      verb: New
      subject: ToSqlManagedInstance
      parameter-name: ProvisioningError
    hide: true

  - where:
      verb: New
      subject: ToSqlVM
      parameter-name: ProvisioningError
    hide: true

  - where:
      verb: Get
      subject: ToSqlDb
      parameter-name: PassThru
    hide: true

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

  # Changing parameter description
  - where:
      parameter-name: Scope
      verb: New
      subject: ToSqlVM
    set:
      parameter-description: Resource Id of the target resource (SQL VM). For the Scope parameter, use the Scope of the SQL VM (/subscriptions/111-222/resourceGroups/myRG/providers/Microsoft.SqlVirtualMachine/SqlVirtualMachines/xyz-SqlVM) and not the Compute SQL VM (/subscriptions/111-222/resourceGroups/myRG/providers/Microsoft.Compute/virtualMachines/xyz-SqlVM)

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
      model-name: DatabaseMigrationSqlDb
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

  # Giving preview message to each command
  - where:
      subject: (^SqlService)
    set:
      preview-announcement:
        preview-message: This is a SQL Service resource and can only be accessed using cmdlets that have SqlService in their name. (For example Get-AzDataMigrationSqlService should be used to access a data migration SQL Service and NOT Get-AzDataMigrationService)
  - where:
      subject: (^ToSqlManagedInstance)
    set:
      preview-announcement:
        preview-message: Only use cmdlets containing ToSqlManagedInstance in their name for getting or deleting or performing cutover on a migration created using New-AzDataMigrationToSqlManagedInstance
  - where:
      subject: (^ToSqlVM)
    set:
      preview-announcement:
        preview-message: Only use cmdlets containing ToSqlVM in their name for getting or deleting or performing cutover on a migration created using New-AzDataMigrationToSqlVM
  - where:
      subject: (^ToSqlDb)
    set:
      preview-announcement:
        preview-message: Only use cmdlets containing ToSqlDb in their name for getting or stopping or deleting a migration created using New-AzDataMigrationToSqlDb

  # Making parameters required/optional
  - from: swagger-document
    where: $.definitions.MigrationOperationInput
    transform: $['required'] = ['migrationOperationId']

```
