### Example 1: Get PostgreSql servers in the subscription
```powershell
PS C:\> Get-AzPostgreSqlFlexibleServer

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
postgresql-test-2   East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
postgresql-test-3   East US   Standard_D2s_v3 GeneralPurpose daeunyim           128

```

This cmdlet gets PostgreSql servers with default context.

### Example 2: Get PostgreSql server by resource group and server name
```powershell
PS C:\> Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet gets PostgreSql servers by resource group and server name.

### Example 3: Lists all the PostgreSql servers in specified resource group
```powershell
PS C:\> Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
postgresql-test-2   East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet lists all the PostgreSql servers in the specified resource group.

### Example 4: Get PostgreSql server by identity
```powershell
PS C:\> $ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test"
PS C:\> Get-AzPostgreSqlFlexibleServer -InputObject $ID

Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet lists gets PostgreSql servers by identity.