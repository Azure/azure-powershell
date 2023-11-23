### Example 1: Get PostgreSql servers in the subscription
```powershell
Get-AzPostgreSqlFlexibleServer
```

```output
Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
postgresql-test-2   East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
postgresql-test-3   East US   Standard_D2s_v3 GeneralPurpose daeunyim           128

```

This cmdlet gets PostgreSql servers with default context.

### Example 2: Get PostgreSql server by resource group and server name
```powershell
Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest -Name postgresql-test
```

```output
Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet gets PostgreSql servers by resource group and server name.

### Example 3: Lists all the PostgreSql servers in specified resource group
```powershell
Get-AzPostgreSqlFlexibleServer -ResourceGroupName PowershellPostgreSqlTest
```

```output
Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
postgresql-test-2   East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet lists all the PostgreSql servers in the specified resource group.

### Example 4: Get PostgreSql server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellPostgreSqlTest/providers/Microsoft.DBforPostgreSQL/flexibleServers/postgresql-test"
Get-AzPostgreSqlFlexibleServer -InputObject $ID
```

```output
Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
postgresql-test     East US   Standard_D2s_v3 GeneralPurpose daeunyim           128
```

This cmdlet lists gets PostgreSql servers by identity.