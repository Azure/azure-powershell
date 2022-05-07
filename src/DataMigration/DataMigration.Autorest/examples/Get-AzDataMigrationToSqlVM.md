### Example 1: Get the details of a given Database Migration to a SQL Virtual Machine
```powershell
Get-AzDataMigrationToSqlVM -ResourceGroupName "MyResourceGroup" -SqlVirtualMachineName "MySqlVM" -TargetDbName "MyDatabase"
```

```output
Name                 Type                                       Kind  ProvisioningState MigrationStatus
----                 ----                                       ----  ----------------- ---------------
MyDatabase           Microsoft.DataMigration/databaseMigrations SqlVm Succeeded         Succeeded
```

This command gets the details of a given Database Migration to a SQL Virtual Machine.

### Example 2: Get the expanded details of a given Database Migration to a SQL Virtual Machine
```powershell
$vmMigration = Get-AzDataMigrationToSqlVM -ResourceGroupName "MyResouceGroup" -SqlVirtualMachineName "MySqlVM" -TargetDbName "MyDatabase" -Expand MigrationStatusDetails
$vmMigration.MigrationStatusDetail
```

```output
BlobContainerName                    CompleteRestoreErrorMessage CurrentRestoringFilename          FileUploadBlockingError 
-----------------                    --------------------------- ------------------------          ----------------------- 
2673894b-451c-41cv-ae2b-58a8eefe3546                             AdventureWorks.bak                         
```

This command gets the expanded details of a given Database Migration to a SQL Virtual Machine.

