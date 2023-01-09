### Example 1: Remove a dynatrace monitor
```powershell
Remove-AzDynatraceMonitor -ResourceGroupName dyobrg -Name dyob-pwsh02
```

```output
```

This command removes a dynatrace monitor.

### Example 2: Remove a dynatrace monitor by pipeline
```powershell
Get-AzDynatraceMonitor -ResourceGroupName dyobrg -Name dyob-pwsh02 | Remove-AzDynatraceMonitor
```

```output
```

This command removes a dynatrace monitor by pipeline.