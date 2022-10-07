### Example 1: Get MySql server with default context
```powershell
Get-AzMySqlFlexibleServer
```

```output
Name         Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----         --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_D2ds_v4 GeneralPurpose admin              5.7     32

```

This cmdlet gets MySql servers with default context.

### Example 2: Get MySql server by resource group and server name
```powershell
Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest -Name mysql-test
```

```output
Name         Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----         --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_D2ds_v4 GeneralPurpose admin              5.7     32
```

This cmdlet gets MySql servers by resource group and server name.

### Example 3: Lists all the MySql servers in specified resource group
```powershell
Get-AzMySqlFlexibleServer -ResourceGroupName PowershellMySqlTest
```

```output
Name         Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----         --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_D2ds_v4 GeneralPurpose admin              5.7     32
mysql-test2  West US 2 Standard_D2ds_v4 GeneralPurpose admin              5.7     32
```

This cmdlet lists all the MySql servers in the specified resource group.

### Example 4: Get MySql server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/flexibleServers/mysql-test"
Get-AzMySqlFlexibleServer -InputObject $ID
```

```output
Name         Location  SkuName          SkuTier        AdministratorLogin Version StorageSizeGb
----         --------  -------          -------        ------------------ ------- -------------
mysql-test   West US 2 Standard_D2ds_v4 GeneralPurpose admin              5.7     32
```

This cmdlet lists gets MySql servers by identity.