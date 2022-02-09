### Example 1: Initiate cutover for the specified in-progress online migration to SQL Virtual Machine
```powershell
PS C:\> $vmMigration = Get-AzDataMigrationToSqlVM -ResourceGroupName "MyResourceGroup" -SqlVirtualMachineName "MySqlVM" -TargetDbName "MyDatabase"
PS C:\> Invoke-AzDataMigrationCutoverToSqlVM -ResourceGroupName "MyResourceGroup" -SqlVirtualMachineName "MySqlVM" -TargetDbName "MyDatabase" -MigrationOperationId $vmMigration.MigrationOperationId
PS C:\> Get-AzDataMigrationToSqlVM -InputObject $vmMigration

Name                 Type                                       Kind  ProvisioningState MigrationStatus
----                 ----                                       ----  ----------------- ---------------
MyDatabase           Microsoft.DataMigration/databaseMigrations SqlVm Completing        Completing
```

This command initiates cutover for the specified in-progress online migration to SQL Virtual Machine.
