---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azperfcounterdatasourceobject
schema: 2.0.0
---

# New-AzPerfCounterDataSourceObject

## SYNOPSIS
Create an in-memory object for PerfCounterDataSource.

## SYNTAX

```
New-AzPerfCounterDataSourceObject [-CounterSpecifier <String[]>] [-Name <String>]
 [-SamplingFrequencyInSecond <Int32>] [-Stream <String[]>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PerfCounterDataSource.

## EXAMPLES

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

## PARAMETERS

### -CounterSpecifier
A list of specifier names of the performance counters you want to collect.
        Use a wildcard (*) to collect a counter for all instances.
        To get a list of performance counters on Windows, run the command 'typeperf'.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
A friendly name for the data source.
        This name should be unique across all data sources (regardless of type) within the data collection rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SamplingFrequencyInSecond
The number of seconds between consecutive counter measurements (samples).

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Stream
List of streams that this data source will be sent to.
        A stream indicates what schema will be used for this data and usually what table in Log Analytics the data will be sent to.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.PerfCounterDataSource

## NOTES

## RELATED LINKS
