### Example 1: Stop in-progress migration to SQL Managed Instance
```powershell
PS C:\> $miMigration = Get-AzDataMigrationToSqlManagedInstance -ResourceGroupName "MyRG" -ManagedInstanceName "MyMI" -TargetDbName "MyDatabase"
PS C:\> Stop-AzDataMigrationToSqlManagedInstance -ResourceGroupName "MyRG" -ManagedInstanceName "MyMI" -TargetDbName "MyDatabase" -MigrationOperationId $miMigration.MigrationOperationId
PS C:\> Get-AzDataMigrationToSqlManagedInstance -InputObject $miMigration 

Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
MyDatabase         Microsoft.DataMigration/databaseMigrations SqlMi Canceling         Canceling
```

This command stops the in-progress migration to SQL Managed Instance.
