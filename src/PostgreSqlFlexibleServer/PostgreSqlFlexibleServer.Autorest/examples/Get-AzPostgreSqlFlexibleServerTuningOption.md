### Example 1: List all tuning options and their states in a flexible server
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

Lists all tuning options and their states in an Azure Database for PostgreSQL flexible server with server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 2: Get state of index tuning option in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -TuningOption index
```

```output
Name                           State
----                           -----
index                          
```

Gets the index tuning option and its state in an Azure Database for PostgreSQL flexible server with tuning option, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 3: Get state of configuration tuning option in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -TuningOption configuration
```

```output
Name                           State
----                           -----
configuration                  Disabled
```

Gets the configuration tuning option and its state in an Azure Database for PostgreSQL flexible server with tuning option, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.

### Example 4: Get state of table tuning option in a flexible server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -SubscriptionId aaaa0a0a-bb1b-cc2c-dd3d-eeeeee4e4e4e -ResourceGroup example-resource-group -ServerName example-server -TuningOption table
```

```output
Name                           State
----                           -----
table                          
```

Gets the table tuning option and its state in an Azure Database for PostgreSQL flexible server with tuning option, server name, resource group, and subscription explicitly passed as arguments. If subscription is not passed explicitly, it's taken from default context.
