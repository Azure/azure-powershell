### Example 1: Initiate cutover for the specified in-progress online migration to SQL Virtual Machine
```powershell
$vmMigration = Get-AzDataMigrationToSqlVM -ResourceGroupName "MyResourceGroup" -SqlVirtualMachineName "MySqlVM" -TargetDbName "MyDatabase"
Invoke-AzDataMigrationCutoverToSqlVM -ResourceGroupName "MyResourceGroup" -SqlVirtualMachineName "MySqlVM" -TargetDbName "MyDatabase" -MigrationOperationId $vmMigration.MigrationOperationId
Get-AzDataMigrationToSqlVM -InputObject $vmMigration
```

```output
Name                 Type                                       Kind  ProvisioningState MigrationStatus
----                 ----                                       ----  ----------------- ---------------
MyDatabase           Microsoft.DataMigration/databaseMigrations SqlVm Completing        Completing
```

This command initiates cutover for the specified in-progress online migration to SQL Virtual Machine.
