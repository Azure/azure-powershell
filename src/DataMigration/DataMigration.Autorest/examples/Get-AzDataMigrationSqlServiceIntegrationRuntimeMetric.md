### Example 1: Get the registered Integration Runtime nodes and their monitoring data for a given Sql Migration Service
```powershell
Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService" | Select-Object *
```

```output
Name       Node
----       ----
default-ir {WIN-AKLAB}
```

This command gets the registered Integration Runtime nodes and their monitoring data for a given Sql Migration Service.

### Example 2: Print the monitoring data for each Integration Runtime node
```powershell
$item = Get-AzDataMigrationSqlServiceIntegrationRuntimeMetric -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
$item.Node[0] 
```

```output
AvailableMemoryInMb ConcurrentJobsLimit ConcurrentJobsRunning CpuUtilization MaxConcurrentJob NodeName     ReceivedByte     SentByte
------------------- ------------------- --------------------- -------------- ---------------- --------     ------------     --------
200138              20                  0                     8                               WIN-AKLAB    9.33309006690979 5.433871746063232
```

First command gets the node monitoring data of a Sql Migration Service. Second command is then used to print the monitoring data for each node.


