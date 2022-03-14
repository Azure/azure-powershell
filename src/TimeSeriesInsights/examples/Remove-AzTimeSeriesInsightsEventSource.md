### Example 1: Remove a specified event source by name
```powershell
Remove-AzTimeSeriesInsightsEventSource -EnvironmentName tsitest001 -Name iots001 -ResourceGroupName testgroup

```

This removes a specific event source.

### Example 2: Remove a specified event source by object
```powershell
$es = Get-AzTimeSeriesInsightsEventSource -EnvironmentName tsitest001 -ResourceGroupName testgroup -Name iots001
Remove-AzTimeSeriesInsightsEventSource -InputObject $es

```

This removes a specific event source.

