### Example 1: Get the details of a given Sql Migration Service
```powershell
Get-AzDataMigrationSqlService  -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
```

```output
Location  Name                   Type                                         ProvisioningState IntegrationRuntimeState
--------  ----                   ----                                         ----------------- -----------------------
eastus2   MySqlMigrationService  Microsoft.DataMigration/sqlMigrationServices Succeeded         Online
```

This command gets the details of a given Sql Migration Service.

### Example 2: Get all Sql Migration Services in a given Resource Group
```powershell
Get-AzDataMigrationSqlService  -ResourceGroupName "MyResourceGroup"
```

```output
Location  Name                   Type                                         ProvisioningState IntegrationRuntimeState
--------  ----                   ----                                         ----------------- -----------------------
eastus    MySqlMigrationService1 Microsoft.DataMigration/sqlMigrationServices Succeeded
eastus2   MySqlMigrationService  Microsoft.DataMigration/sqlMigrationServices Succeeded
```

This command gets all Sql Migration Services in a given Resource Group.

### Example 3: Get all Sql Migration Services in a given Subscription
```powershell
Get-AzDataMigrationSqlService 
```

```output
Location  Name                      Type                                         ProvisioningState IntegrationRuntimeState
--------  ----                      ----                                         ----------------- -----------------------
eastus    MySqlMigrationService1    Microsoft.DataMigration/sqlMigrationServices Succeeded
eastus2   MySqlMigrationService     Microsoft.DataMigration/sqlMigrationServices Succeeded
uksouth   MySqlMigrationService-UK  Microsoft.DataMigration/sqlMigrationServices Succeeded
```

This command gets all Sql Migration Services in a given Subscription.

