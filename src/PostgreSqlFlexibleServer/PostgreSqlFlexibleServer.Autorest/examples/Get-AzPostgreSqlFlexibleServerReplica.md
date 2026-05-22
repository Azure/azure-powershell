### Example 1: List all tuning options in a server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
Name                           State
----                           -----
index                          
configuration                  Disabled
table                          
```

Lists all tuning options in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 2: Get all tuning options in a server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server
```

```output
Name                           State
----                           -----
index                          
configuration                  Disabled
table                          
```

Lists all tuning options in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as an arguments. If subscription is not passed explicitly, it's taken from default context.
