### Example 1: Update tag of SQL Migration Service
```powershell
Update-AzDataMigrationSqlService -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService" -Tag @{Tag="Service"}
```

```output
Location  Name    Type                                         ProvisioningState IntegrationRuntimeState
--------  ----    ----                                         ----------------- -----------------------
eastus2   MySqlMS Microsoft.DataMigration/sqlMigrationServices Succeeded         Online
```

This command updates tag of SQL Migration Service.

### Example 2: Update tag of SQL Migration Service using InputObject
```powershell
$mySqlMS = Get-AzDataMigrationSqlService -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
Update-AzDataMigrationSqlService -InputObject $mySqlMS -Tag @{Tag="Service"}
```

```output
Location  Name    Type                                         ProvisioningState IntegrationRuntimeState
--------  ----    ----                                         ----------------- -----------------------
eastus2   MySqlMS Microsoft.DataMigration/sqlMigrationServices Succeeded         Online
```

This command updates tag of SQL Migration Service using InputObject.

