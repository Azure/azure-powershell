### Example 1: Start a Database Migration from the on-premise Source Sql Server to target Sql VM
```powershell
$sourcePassword = ConvertTo-SecureString -String $password -AsPlainText -Force
$filesharePassword = ConvertTo-SecureString -String $password -AsPlainText -Force

New-AzDataMigrationToSqlVM -ResourceGroupName "MyResourceGroup" -SqlVirtualMachineName "MyVM" -TargetDbName "MyDb" -Kind "SqlVm" -Scope "/subscriptions/0000-1111-2222-3333-4444/resourceGroups/MyResourceGroup/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachine/MyVM" -MigrationService "/subscriptions/0000-1111-2222-3333-4444/resourceGroups/MyResourceGroup/providers/Microsoft.DataMigration/SqlMigrationServices/MySqlMigrationService" -StorageAccountResourceId "/subscriptions/0000-1111-2222-3333-4444/resourceGroups/MyResourceGroup/providers/Microsoft.Storage/storageAccounts/MyStorageAccount" -StorageAccountKey "aaaaaccccoooouuunnntttkkkeeeyy" -FileSharePath "\\filesharepath.com\SharedBackup\MyBackUps" -FileShareUsername "filesharepath\User" -FileSharePassword $filesharePassword -SourceSqlConnectionAuthentication "SqlAuthentication" -SourceSqlConnectionDataSource "LabServer.database.net" -SourceSqlConnectionUserName "User" -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName "AdventureWorks"
```

```output
Name                 Type                                       Kind  ProvisioningState MigrationStatus
----                 ----                                       ----  ----------------- ---------------
MyDb                 Microsoft.DataMigration/databaseMigrations SqlVm Succeeded         InProgress
```

This command starts a Database Migration from the Source Sql Server to target Sql VM. This example is for online migration. To make it offline add -Offline to the parameters. 
Note :
Create a new database migration to a given SQL VM. Note - For the Scope parameter, use the Scope of the SQL VM (/subscriptions/111-222/resourceGroups/myRG/providers/Microsoft.SqlVirtualMachine/SqlVirtualMachines/xyz-SqlVM) and not the Compute SQL VM (/subscriptions/111-222/resourceGroups/myRG/providers/Microsoft.Compute/virtualMachines/xyz-SqlVM)


