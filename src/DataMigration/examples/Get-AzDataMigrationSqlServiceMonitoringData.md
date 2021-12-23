### Example 1: Get the Monitoring Data for a given Sql Migration Service
```powershell
PS C:\> Get-AzDataMigrationSqlServiceMonitoringData -ResourceGroupName "MyRG" -SqlMigrationServiceName "MySqlMS" | Select *

Name       Node
----       ----
default-ir {WIN-AKLAB}
```

This command gets the Monitoring Data for a given Sql Migration Service.

### Example 2: Print the monitoring data for each node
```powershell
PS C:\> $item = Get-AzDataMigrationSqlServiceMonitoringData -ResourceGroupName "MyRG" -SqlMigrationService "MySqlMS"
PS C:\> $item.Node[0] 

AvailableMemoryInMb ConcurrentJobsLimit ConcurrentJobsRunning CpuUtilization MaxConcurrentJob NodeName     ReceivedByte     SentByte
------------------- ------------------- --------------------- -------------- ---------------- --------     ------------     --------
200138              20                  0                     8                               WIN-AKLAB    9.33309006690979 5.433871746063232
```

First command gets the Monitoring Data of a Sql Migration Service. Second command is then used to print the monitoring data for each node.

