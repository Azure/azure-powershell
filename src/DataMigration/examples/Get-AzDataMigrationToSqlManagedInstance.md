### Example 1: Get the details of a given Database Migration to a SQL Managed Instance
```powershell
PS C:\> Get-AzDataMigrationToSqlManagedInstance -ResourceGroupName "MyResourceGroup" -ManagedInstanceName "MyManagedInstance" -TargetDbName "MyDatabase"

Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
MyDatabase         Microsoft.DataMigration/databaseMigrations SqlMi Succeeded         Succeeded
```

This command gets the details of a given Database Migration to a SQL Managed Instance.

### Example 2: Get the expanded details of a given Database Migration to a SQL Managed Instance
```powershell
PS C:\> $miMigration = Get-AzDataMigrationToSqlManagedInstance -ResourceGroupName "MyResourceGroup" -ManagedInstanceName "MyManagedInstance" -TargetDbName "MyDatabase" -Expand MigrationStatusDetails
PS C:\> $miMigration.MigrationStatusDetail

BlobContainerName                    CompleteRestoreErrorMessage CurrentRestoringFilename          FileUploadBlockingError 
-----------------                    --------------------------- ------------------------          ----------------------- 
2673894b-451c-41cv-ae2b-58a8eefe3546                             AdventureWorks.bak                         
```

This command gets the expanded details of a given Database Migration to a SQL Managed Instance.

