### Example 1: Get PostgreSql server with default context
```powershell
PS C:\> Get-AzPostgreSqlFlexibleServer

Name            Location AdministratorLogin Version StorageProfileStorageMb SkuName          SkuTier        
----            -------- ------------------ ------- ----------------------- ---------------- -------------
postgresql-test eastus   postgresql-test     12     32768                   Standard_D2s_v3 GeneralPurpose
```

This cmdlet gets PostgreSql servers with default context.

### Example 2: Get PostgreSql server by resource group and server name
```powershell
PS C:\> Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test

Name            Location AdministratorLogin Version StorageProfileStorageMb SkuName          SkuTier        
----            -------- ------------------ ------- ----------------------- ---------------- -------------
postgresql-test eastus   postgresql-test     12     32768                   Standard_D2s_v3 GeneralPurpose
```

This cmdlet gets PostgreSql servers by resource group and server name.

### Example 3: Lists all the PostgreSql servers in specified resource group
```powershell
PS C:\> Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest

Name             Location AdministratorLogin Version StorageProfileStorageMb SkuName          SkuTier        
----             -------- ------------------ ------- ----------------------- ---------------- -------------
postgresql-test  eastus   postgresql-test     12     32768                   Standard_D2s_v3 GeneralPurpose
postgresql-test2 eastus   postgresql-test     12     32768                   Standard_42s_v3 GeneralPurpose
```

This cmdlet lists all the PostgreSql servers in the specified resource group.

### Example 4: Get PostgreSql server by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBForPostgreSql/flexibleServers/postgresql-test"
PS C:\> Get-AzPostgreSqlFlexibleServer -InputObject $ID

Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName          SkuTier        
----          -------- ------------------ ------- ----------------------- ---------------- -------------
postgresql-test eastus   postgresql-test         12     32768                    Standard_D2s_v3 GeneralPurpose
```

This cmdlet lists gets PostgreSql servers by identity.