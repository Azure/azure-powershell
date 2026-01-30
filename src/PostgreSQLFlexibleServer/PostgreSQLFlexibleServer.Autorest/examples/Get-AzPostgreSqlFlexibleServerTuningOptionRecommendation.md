### Example 1: Get tuning option recommendations for a PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
Name                : shared_buffers
CurrentValue        : 128MB
RecommendedValue    : 256MB
ReasonForRecommendation : Current value is too low for your workload pattern
ExpectedImpact      : 20% improvement in query performance
Category           : Memory
Priority           : High
ImplementationEffort : Medium

Name                : work_mem
CurrentValue        : 4MB
RecommendedValue    : 8MB
ReasonForRecommendation : Sort operations are spilling to disk frequently
ExpectedImpact      : 15% improvement in complex query performance
Category           : Memory
Priority           : Medium
ImplementationEffort : Low

Name                : max_connections
CurrentValue        : 100
RecommendedValue    : 150
ReasonForRecommendation : Connection pool exhaustion detected during peak hours
ExpectedImpact      : Eliminate connection bottlenecks
Category           : Connections
Priority           : High
ImplementationEffort : High
```

Retrieves performance tuning recommendations for the specified PostgreSQL Flexible Server based on workload analysis.

### Example 2: Get recommendations for a specific performance issue
```powershell
Get-AzPostgreSqlFlexibleServerTuningOptionRecommendation -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -TuningOptionName "checkpoint_completion_target"
```

```output
Name                : checkpoint_completion_target
CurrentValue        : 0.5
RecommendedValue    : 0.8
ReasonForRecommendation : Checkpoint I/O spikes are causing performance degradation
ExpectedImpact      : Smoother I/O distribution and reduced checkpoint impact
Category           : Disk I/O
Priority           : Medium
ImplementationEffort : Low
RestartRequired    : False
```

Retrieves recommendations for a specific tuning parameter based on performance analysis.

