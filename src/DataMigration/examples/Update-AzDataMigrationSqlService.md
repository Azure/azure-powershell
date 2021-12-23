### Example 1: Update tag of SQL Migration Service
```powershell
PS C:\> Update-AzDataMigrationSqlService -ResourceGroupName "MyRG" -SqlMigrationServiceName "MySqlMS" -Tag @{Tag="Service"}

Location  Name    Type                                         ProvisioningState IntegrationRuntimeState
--------  ----    ----                                         ----------------- -----------------------
eastus2   MySqlMS Microsoft.DataMigration/sqlMigrationServices Succeeded         Online
```

This command updates tag of SQL Migration Service.

### Example 2: Update tag of SQL Migration Service using InputObject
```powershell
PS C:\> $mySqlMS = Get-AzDataMigrationSqlService -ResourceGroupName "MyRG" -SqlMigrationServiceName "MySqlMS"
PS C:\> Update-AzDataMigrationSqlService -InputObject $mySqlMS -Tag @{Tag="Service"}

Location  Name    Type                                         ProvisioningState IntegrationRuntimeState
--------  ----    ----                                         ----------------- -----------------------
eastus2   MySqlMS Microsoft.DataMigration/sqlMigrationServices Succeeded         Online
```

This command updates tag of SQL Migration Service using InputObject.

