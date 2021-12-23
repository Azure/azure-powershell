### Example 1: Initiate cutover for the specified in-progress online migration to SQL Managed Instance
```powershell
PS C:\> $miMigration = Get-AzDataMigrationToSqlManagedInstance -ResourceGroupName "MyRG" -ManagedInstanceName "MyMI" -TargetDbName "MyDatabase"
PS C:\> Invoke-AzDataMigrationCutoverToSqlManagedInstance -ResourceGroupName "MyRG" -ManagedInstanceName "MyMI" -TargetDbName "MyDatabase" -MigrationOperationId $miMigration.MigrationOperationId
PS C:\> Get-AzDataMigrationToSqlManagedInstance -InputObject $miMigration 

Name               Type                                       Kind  ProvisioningState MigrationStatus
----               ----                                       ----  ----------------- ---------------
MyDatabase         Microsoft.DataMigration/databaseMigrations SqlMi Completing        Completing
```

This command initiates cutover for the specified in-progress online migration to SQL Managed Instance.

