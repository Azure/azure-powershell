### Example 1: Start a Database Migration from the on-premise Source Sql Server to target Managed Instance
```powershell
$sourcePassword = ConvertTo-SecureString -String $password -AsPlainText -Force
$filesharePassword = ConvertTo-SecureString -String $password -AsPlainText -Force
New-AzDataMigrationToSqlManagedInstance -ResourceGroupName "MyResourceGroup" -ManagedInstanceName "MyManagedInstance" -TargetDbName "MyDb" -Kind "SqlMI" -Scope "/subscriptions/0000-1111-2222-3333-4444/resourceGroups/MyResourceGroup/providers/Microsoft.Sql/managedInstances/MyManagedInstance" -MigrationService "/subscriptions/0000-1111-2222-3333-4444/resourceGroups/MyRG/providers/Microsoft.DataMigration/SqlMigrationServices/MySqlMigrationService" -StorageAccountResourceId "/subscriptions/0000-1111-2222-3333-4444/resourceGroups/MyResourceGroup/providers/Microsoft.Storage/storageAccounts/MyStorageAccount" -StorageAccountKey "aaaaacccccoouunntkkkkeeeyyy" -FileSharePath "\\filesharepath.com\SharedBackup\MyBackUps" -FileShareUsername "filesharepath\User" -FileSharePassword $filesharePassword -SourceSqlConnectionAuthentication "SqlAuthentication" -SourceSqlConnectionDataSource "LabServer.database.net" -SourceSqlConnectionUserName "User" -SourceSqlConnectionPassword $sourcePassword -SourceDatabaseName "AdventureWorks"
```

```output
Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
MyDb               Microsoft.DataMigration/databaseMigrations SqlMi Succeeded         InProgress
```

This command starts a Database Migration from the Source Sql Server to target Managed Instance. This example is for online migration. To make it offline add -Offline to the parameters.

### Example 2: Start a Database Migration from Azure Blob to target Managed Instance using target's SystemAssigned Managed Identity

```powershell
TODO
```

```output
Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
MyDb               Microsoft.DataMigration/databaseMigrations SqlMi Succeeded         InProgress
```

This command starts a Database Migration from the Azure Blob to target Managed Instance. This example is for online migration. To make it offline add -Offline to the parameters.

### Example 3: Start a Database Migration from Azure Blob to target Managed Instance using a User Assigned Managed Identity

```powershell
TODO
```

```output
Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
MyDb               Microsoft.DataMigration/databaseMigrations SqlMi Succeeded         InProgress
```

This command starts a Database Migration from the Azure Blob to target Managed Instance. This example is for online migration. To make it offline add -Offline to the parameters.

### Example 4: Start a Database Migration from Azure Blob to target Managed Instance using the Storage Account Key

```powershell
TODO
```

```output
Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
MyDb               Microsoft.DataMigration/databaseMigrations SqlMi Succeeded         InProgress
```

This command starts a Database Migration from the Azure Blob to target Managed Instance. This example is for online migration. To make it offline add -Offline to the parameters.
