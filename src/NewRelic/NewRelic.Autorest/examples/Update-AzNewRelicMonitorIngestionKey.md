### Example 1: Refresh ingestion key for a NewRelic monitor
```powershell
Update-AzNewRelicMonitorIngestionKey -MonitorName myNewRelicMonitor -ResourceGroupName myResourceGroup
```

```output
True
```

Refreshes the ingestion key for all monitors linked to the same account associated to the underlying monitor.

### Example 2: Refresh ingestion key using pipeline input
```powershell
Get-AzNewRelicMonitor -Name myNewRelicMonitor -ResourceGroupName myResourceGroup | Update-AzNewRelicMonitorIngestionKey
```

```output
True
```

Refreshes the ingestion key using pipeline input from Get-AzNewRelicMonitor cmdlet.
