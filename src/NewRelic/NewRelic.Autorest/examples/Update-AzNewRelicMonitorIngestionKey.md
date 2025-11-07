### Example 1: Refresh ingestion key for a NewRelic monitor
```powershell
Update-AzNewRelicMonitorIngestionKey -MonitorName clientParity-Test-1014 -ResourceGroupName vanshjoshi-clientparity-test
```

```output
True
```

Refreshes the ingestion key for all monitors linked to the same account associated to the underlying monitor.

### Example 2: Refresh ingestion key using pipeline input
```powershell
Get-AzNewRelicMonitor -Name clientParity-Test-1014 -ResourceGroupName vanshjoshi-clientparity-test | Update-AzNewRelicMonitorIngestionKey
```

```output
True
```

Refreshes the ingestion key using pipeline input from Get-AzNewRelicMonitor cmdlet.

