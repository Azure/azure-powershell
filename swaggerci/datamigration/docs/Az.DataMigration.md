---
Module Name: Az.DataMigration
Module Guid: b49682f6-3563-4e8c-b685-8e8facd121e7
Download Help Link: https://docs.microsoft.com/en-us/powershell/module/az.datamigration
Help Version: 1.0.0.0
Locale: en-US
---

# Az.DataMigration Module
## Description
Microsoft Azure PowerShell: DataMigration cmdlets

## Az.DataMigration Cmdlets
### [Get-AzDataMigrationDatabaseMigrationsSqlDb](Get-AzDataMigrationDatabaseMigrationsSqlDb.md)
Retrieve the Database Migration resource.

### [Get-AzDataMigrationDatabaseMigrationsSqlMi](Get-AzDataMigrationDatabaseMigrationsSqlMi.md)
Retrieve the specified database migration for a given SQL Managed Instance.

### [Get-AzDataMigrationDatabaseMigrationsSqlVM](Get-AzDataMigrationDatabaseMigrationsSqlVM.md)
Retrieve the specified database migration for a given SQL VM.

### [Get-AzDataMigrationFile](Get-AzDataMigrationFile.md)
The files resource is a nested, proxy-only resource representing a file stored under the project resource.
This method retrieves information about a file.

### [Get-AzDataMigrationProject](Get-AzDataMigrationProject.md)
The project resource is a nested resource representing a stored migration project.
The GET method retrieves information about a project.

### [Get-AzDataMigrationResourceSku](Get-AzDataMigrationResourceSku.md)
The skus action returns the list of SKUs that DMS supports.

### [Get-AzDataMigrationService](Get-AzDataMigrationService.md)
The services resource is the top-level resource that represents the Database Migration Service.
The GET method retrieves information about a service instance.

### [Get-AzDataMigrationServiceSku](Get-AzDataMigrationServiceSku.md)
The services resource is the top-level resource that represents the Database Migration Service.
The skus action returns the list of SKUs that a service resource can be updated to.

### [Get-AzDataMigrationServiceTask](Get-AzDataMigrationServiceTask.md)
The service tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
The GET method retrieves information about a service task.

### [Get-AzDataMigrationSqlMigrationService](Get-AzDataMigrationSqlMigrationService.md)
Retrieve the Database Migration Service

### [Get-AzDataMigrationSqlMigrationServiceAuthKey](Get-AzDataMigrationSqlMigrationServiceAuthKey.md)
Retrieve the List of Authentication Keys for Self Hosted Integration Runtime.

### [Get-AzDataMigrationSqlMigrationServiceMigration](Get-AzDataMigrationSqlMigrationServiceMigration.md)
Retrieve the List of database migrations attached to the service.

### [Get-AzDataMigrationSqlMigrationServiceMonitoringData](Get-AzDataMigrationSqlMigrationServiceMonitoringData.md)
Retrieve the registered Integration Runtime nodes and their monitoring data for a given Database Migration Service.

### [Get-AzDataMigrationTask](Get-AzDataMigrationTask.md)
The tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
The GET method retrieves information about a task.

### [Get-AzDataMigrationUsage](Get-AzDataMigrationUsage.md)
This method returns region-specific quotas and resource usage information for the Database Migration Service.

### [Invoke-AzDataMigrationCommandTask](Invoke-AzDataMigrationCommandTask.md)
The tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
This method executes a command on a running task.

### [Invoke-AzDataMigrationCutoverDatabaseMigrationSqlMi](Invoke-AzDataMigrationCutoverDatabaseMigrationSqlMi.md)
Initiate cutover for in-progress online database migration to SQL Managed Instance.

### [Invoke-AzDataMigrationCutoverDatabaseMigrationSqlVM](Invoke-AzDataMigrationCutoverDatabaseMigrationSqlVM.md)
Initiate cutover for in-progress online database migration to SQL VM.

### [New-AzDataMigrationDatabaseMigrationSqlDb](New-AzDataMigrationDatabaseMigrationSqlDb.md)
Create or Update Database Migration resource.

### [New-AzDataMigrationDatabaseMigrationSqlMi](New-AzDataMigrationDatabaseMigrationSqlMi.md)
Create a new database migration to a given SQL Managed Instance.

### [New-AzDataMigrationDatabaseMigrationSqlVM](New-AzDataMigrationDatabaseMigrationSqlVM.md)
Create a new database migration to a given SQL VM.

### [New-AzDataMigrationFile](New-AzDataMigrationFile.md)
The PUT method creates a new file or updates an existing one.

### [New-AzDataMigrationProject](New-AzDataMigrationProject.md)
The project resource is a nested resource representing a stored migration project.
The PUT method creates a new project or updates an existing one.

### [New-AzDataMigrationService](New-AzDataMigrationService.md)
The services resource is the top-level resource that represents the Database Migration Service.
The PUT method creates a new service or updates an existing one.
When a service is updated, existing child resources (i.e.
tasks) are unaffected.
Services currently support a single kind, \"vm\", which refers to a VM-based service, although other kinds may be added in the future.
This method can change the kind, SKU, and network of the service, but if tasks are currently running (i.e.
the service is busy), this will fail with 400 Bad Request (\"ServiceIsBusy\").
The provider will reply when successful with 200 OK or 201 Created.
Long-running operations use the provisioningState property.

### [New-AzDataMigrationServiceTask](New-AzDataMigrationServiceTask.md)
The service tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
The PUT method creates a new service task or updates an existing one, although since service tasks have no mutable custom properties, there is little reason to update an existing one.

### [New-AzDataMigrationSqlMigrationService](New-AzDataMigrationSqlMigrationService.md)
Create or Update Database Migration Service.

### [New-AzDataMigrationSqlMigrationServiceAuthKey](New-AzDataMigrationSqlMigrationServiceAuthKey.md)
Regenerate a new set of Authentication Keys for Self Hosted Integration Runtime.

### [New-AzDataMigrationTask](New-AzDataMigrationTask.md)
The tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
The PUT method creates a new task or updates an existing one, although since tasks have no mutable custom properties, there is little reason to update an existing one.

### [Read-AzDataMigrationFile](Read-AzDataMigrationFile.md)
This method is used for requesting storage information using which contents of the file can be downloaded.

### [Read-AzDataMigrationFileWrite](Read-AzDataMigrationFileWrite.md)
This method is used for requesting information for reading and writing the file content.

### [Remove-AzDataMigrationDatabaseMigrationsSqlDb](Remove-AzDataMigrationDatabaseMigrationsSqlDb.md)
Delete Database Migration resource.

### [Remove-AzDataMigrationFile](Remove-AzDataMigrationFile.md)
This method deletes a file.

### [Remove-AzDataMigrationProject](Remove-AzDataMigrationProject.md)
The project resource is a nested resource representing a stored migration project.
The DELETE method deletes a project.

### [Remove-AzDataMigrationService](Remove-AzDataMigrationService.md)
The services resource is the top-level resource that represents the Database Migration Service.
The DELETE method deletes a service.
Any running tasks will be canceled.

### [Remove-AzDataMigrationServiceTask](Remove-AzDataMigrationServiceTask.md)
The service tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
The DELETE method deletes a service task, canceling it first if it's running.

### [Remove-AzDataMigrationSqlMigrationService](Remove-AzDataMigrationSqlMigrationService.md)
Delete Database Migration Service.

### [Remove-AzDataMigrationSqlMigrationServiceNode](Remove-AzDataMigrationSqlMigrationServiceNode.md)
Delete the integration runtime node.

### [Remove-AzDataMigrationTask](Remove-AzDataMigrationTask.md)
The tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
The DELETE method deletes a task, canceling it first if it's running.

### [Start-AzDataMigrationService](Start-AzDataMigrationService.md)
The services resource is the top-level resource that represents the Database Migration Service.
This action starts the service and the service can be used for data migration.

### [Stop-AzDataMigrationDatabaseMigrationsSqlDb](Stop-AzDataMigrationDatabaseMigrationsSqlDb.md)
Stop on going migration for the database.

### [Stop-AzDataMigrationDatabaseMigrationsSqlMi](Stop-AzDataMigrationDatabaseMigrationsSqlMi.md)
Stop in-progress database migration to SQL Managed Instance.

### [Stop-AzDataMigrationDatabaseMigrationsSqlVM](Stop-AzDataMigrationDatabaseMigrationsSqlVM.md)
Stop in-progress database migration to SQL VM.

### [Stop-AzDataMigrationService](Stop-AzDataMigrationService.md)
The services resource is the top-level resource that represents the Database Migration Service.
This action stops the service and the service cannot be used for data migration.
The service owner won't be billed when the service is stopped.

### [Stop-AzDataMigrationServiceTask](Stop-AzDataMigrationServiceTask.md)
The service tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
This method cancels a service task if it's currently queued or running.

### [Stop-AzDataMigrationTask](Stop-AzDataMigrationTask.md)
The tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
This method cancels a task if it's currently queued or running.

### [Test-AzDataMigrationServiceChildNameAvailability](Test-AzDataMigrationServiceChildNameAvailability.md)
This method checks whether a proposed nested resource name is valid and available.

### [Test-AzDataMigrationServiceNameAvailability](Test-AzDataMigrationServiceNameAvailability.md)
This method checks whether a proposed top-level resource name is valid and available.

### [Test-AzDataMigrationServiceStatus](Test-AzDataMigrationServiceStatus.md)
The services resource is the top-level resource that represents the Database Migration Service.
This action performs a health check and returns the status of the service and virtual machine size.

### [Update-AzDataMigrationFile](Update-AzDataMigrationFile.md)
This method updates an existing file.

### [Update-AzDataMigrationProject](Update-AzDataMigrationProject.md)
The project resource is a nested resource representing a stored migration project.
The PATCH method updates an existing project.

### [Update-AzDataMigrationService](Update-AzDataMigrationService.md)
The services resource is the top-level resource that represents the Database Migration Service.
The PATCH method updates an existing service.
This method can change the kind, SKU, and network of the service, but if tasks are currently running (i.e.
the service is busy), this will fail with 400 Bad Request (\"ServiceIsBusy\").

### [Update-AzDataMigrationServiceTask](Update-AzDataMigrationServiceTask.md)
The service tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
The PATCH method updates an existing service task, but since service tasks have no mutable custom properties, there is little reason to do so.

### [Update-AzDataMigrationSqlMigrationService](Update-AzDataMigrationSqlMigrationService.md)
Update Database Migration Service.

### [Update-AzDataMigrationTask](Update-AzDataMigrationTask.md)
The tasks resource is a nested, proxy-only resource representing work performed by a DMS instance.
The PATCH method updates an existing task, but since tasks have no mutable custom properties, there is little reason to do so.

