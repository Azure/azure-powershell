### Example 1: Update tag of SQL Migration Service
```powershell
PS C:\> Update-AzDataMigrationSqlService -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService" -Tag @{Tag="Service"}

Location  Name    Type                                         ProvisioningState IntegrationRuntimeState
--------  ----    ----                                         ----------------- -----------------------
eastus2   MySqlMS Microsoft.DataMigration/sqlMigrationServices Succeeded         Online
```

This command updates tag of SQL Migration Service.

### Example 2: Update tag of SQL Migration Service using InputObject
```powershell
PS C:\> $mySqlMS = Get-AzDataMigrationSqlService -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
PS C:\> Update-AzDataMigrationSqlService -InputObject $mySqlMS -Tag @{Tag="Service"}

Location  Name    Type                                         ProvisioningState IntegrationRuntimeState
--------  ----    ----                                         ----------------- -----------------------
eastus2   MySqlMS Microsoft.DataMigration/sqlMigrationServices Succeeded         Online
```

This command updates tag of SQL Migration Service using InputObject.

