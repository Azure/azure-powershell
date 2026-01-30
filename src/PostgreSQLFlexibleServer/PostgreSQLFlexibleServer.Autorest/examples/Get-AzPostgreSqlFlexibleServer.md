### Example 1: List all PostgreSQL Flexible Servers in a subscription
```powershell
Get-AzPostgreSqlFlexibleServer
```

```output
Name                Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----                --------  -------         -------        ------------------ -------------
myserver1           East US   Standard_D2s_v3 GeneralPurpose admin              128
myserver2           West US   Standard_B1ms   Burstable      postgres           32
```

Lists all PostgreSQL Flexible Servers in the current subscription.

### Example 2: Get a specific PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServer -Name "myserver1" -ResourceGroupName "myresourcegroup"
```

```output
Name      Location  SkuName         SkuTier        AdministratorLogin StorageSizeGb
----      --------  -------         -------        ------------------ -------------
myserver1 East US   Standard_D2s_v3 GeneralPurpose admin              128
```

Gets information about the PostgreSQL Flexible Server named 'myserver1' in the specified resource group.

