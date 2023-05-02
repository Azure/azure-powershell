### Example 1: Get MySql server with default context
```powershell
Get-AzMySqlServer
```

```output
Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----          -------- ------------------ ------- ----------------------- -------   -------        --------------
mysql-test-11 eastus   mysql_test         5.7     5120                    GP_Gen5_4 GeneralPurpose Enabled
```

This cmdlet gets MySql server with default context.

### Example 2: Get MySql server by resource group and server name
```powershell
Get-AzMySqlServer -ResourceGroupName PowershellMySqlTest -Name mysql-test
```

```output
Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----          -------- ------------------ ------- ----------------------- -------   -------        --------------
mysql-test    eastus   mysql_test         5.7     5120                    GP_Gen5_4 GeneralPurpose Enabled
```

This cmdlet gets MySql server by resource group and server name.

### Example 3: Lists all the MySql servers in specified resource group
```powershell
Get-AzMySqlServer -ResourceGroupName PowershellMySqlTest
```

```output
Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----          -------- ------------------ ------- ----------------------- -------   -------        ------------
mysql-test    eastus   mysql_test         5.7     5120                    GP_Gen5_4 GeneralPurpose Enabled
```

This cmdlet lists all the MySql servers in specified resource group.

### Example 4: Get MySql server by identity
```powershell
$ID = "/subscriptions/<SubscriptionId>/resourceGroups/PowershellMySqlTest/providers/Microsoft.DBforMySQL/servers/mysql-test"
Get-AzMySqlServer -InputObject $ID
```

```output
Name          Location AdministratorLogin Version StorageProfileStorageMb SkuName   SkuTier        SslEnforcement
----          -------- ------------------ ------- ----------------------- -------   -------        ------------
mysql-test    eastus   mysql_test         5.7     5120                    GP_Gen5_4 GeneralPurpose Enabled
```

This cmdlet lists gets MySql server by identity.

