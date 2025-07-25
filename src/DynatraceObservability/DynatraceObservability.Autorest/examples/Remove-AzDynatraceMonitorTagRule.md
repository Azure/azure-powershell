### Example 1: Remove a tag rule for the dynatrace monitor
```powershell
Remove-AzDynatraceMonitorTagRule -ResourceGroupName dyobrg -MonitorName dyob-pwsh01
```

```output
```

This command removes a tag rule for the dynatrace monitor

### Example 2: Remove a tag rule for the dynatrace monitor by pipeline
```powershell
Get-AzDynatraceMonitorTagRule -ResourceGroupName dyobrg -MonitorName dyob-pwsh01 | Remove-AzDynatraceMonitorTagRule
```

```output
```

This command remove a tag rule for the dynatrace monitor by pipeline.

