### Example 1: creates a PerfCounterDataSource with Microsoft-InsightsMetrics
```powershell
New-AzPerfCounterDataSourceObject -CounterSpecifier "\\Processor(_Total)\\% Processor Time" -Name perfCounter01 -SamplingFrequencyInSecond 60 -Stream Microsoft-InsightsMetrics
```

```output
CounterSpecifier                        Name          SamplingFrequencyInSecond Stream
----------------                        ----          ------------------------- ------
{\\Processor(_Total)\\% Processor Time} perfCounter01                        60 {Microsoft-InsightsMetrics}
```

This command creates a PerfCounterDataSource with Microsoft-InsightsMetrics.

### Example 2: Create a PerfCounterDataSource with Microsoft-Perf
```powershell
New-AzPerfCounterDataSourceObject -CounterSpecifier "\\Processor(_Total)\\% Processor Time","\\Memory\\Committed Bytes","\\LogicalDisk(_Total)\\Free Megabytes","\\PhysicalDisk(_Total)\\Avg. Disk Queue Length" -Name cloudTeamCoreCounters -SamplingFrequencyInSecond 15 -Stream Microsoft-Perf
```

```output
CounterSpecifier                                                                                                                                          Name                  SamplingFrequencyInSecond Stream
----------------                                                                                                                                          ----                  ------------------------- ------
{\\Processor(_Total)\\% Processor Time, \\Memory\\Committed Bytes, \\LogicalDisk(_Total)\\Free Megabytes, \\PhysicalDisk(_Total)\\Avg. Disk Queue Length} cloudTeamCoreCounters                        15 {Microsoft-Perf}
```

This command creates a PerfCounterDataSource with Microsoft-Perf.

