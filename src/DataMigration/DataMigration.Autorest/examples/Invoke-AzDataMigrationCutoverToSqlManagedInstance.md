### Example 1: Initiate cutover for the specified in-progress online migration to SQL Managed Instance
```powershell
PS C:\> $miMigration = Get-AzDataMigrationToSqlManagedInstance -ResourceGroupName "MyResourceGroup" -ManagedInstanceName "MyManagedInstance" -TargetDbName "MyDatabase"
PS C:\> Invoke-AzDataMigrationCutoverToSqlManagedInstance -ResourceGroupName "MyResourceGroup" -ManagedInstanceName "MyManagedInstance" -TargetDbName "MyDatabase" -MigrationOperationId $miMigration.MigrationOperationId
PS C:\> Get-AzDataMigrationToSqlManagedInstance -InputObject $miMigration 

Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
MyDatabase         Microsoft.DataMigration/databaseMigrations SqlMi Completing        Completing
```

This command initiates cutover for the specified in-progress online migration to SQL Managed Instance.

