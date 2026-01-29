### Example 1: Get all tuning options for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name                : shared_buffers
CurrentValue        : 128MB
RecommendedValue    : 256MB
Category           : Memory
Description        : Sets the amount of memory the database server uses for shared memory buffers
RequiresRestart    : True
TuningReason       : Improve query performance

Name                : effective_cache_size
CurrentValue        : 4GB
RecommendedValue    : 6GB
Category           : Memory
Description        : Sets the planner's assumption about the effective size of the disk cache
RequiresRestart    : False
TuningReason       : Better query planning

Name                : max_connections
CurrentValue        : 100
RecommendedValue    : 150
Category           : Connections
Description        : Sets the maximum number of concurrent connections
RequiresRestart    : True
TuningReason       : Handle increased load
```

Retrieves all available tuning options for the specified PostgreSQL Flexible Server.

### Example 2: Get tuning options for a specific category
```powershell
Get-AzPostgreSqlFlexibleServerTuningOption -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -TuningOptionName "shared_buffers"
```

```output
Name                : shared_buffers
CurrentValue        : 256MB
RecommendedValue    : 512MB
Category           : Memory
Description        : Sets the amount of memory the database server uses for shared memory buffers
RequiresRestart    : True
TuningReason       : Optimize for workload characteristics
Impact             : High
```

Retrieves details for a specific tuning option for the PostgreSQL Flexible Server.

