### Example 1: Create a Sql Migration Service in a given Resource Group
```powershell
PS C:\> New-AzDataMigrationSqlService -ResourceGroupName "MyRG" -SqlMigrationServiceName "MySqlMS" -Location "eastus2"

Location  Name    Type                                         ProvisioningState IntegrationRuntimeState
--------  ----    ----                                         ----------------- -----------------------
eastus2   MySqlMS Microsoft.DataMigration/sqlMigrationServices Succeeded         NeedRegistration
```

This command creates a Sql Migration Service in a given Resource Group.


