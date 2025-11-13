### Example 1: Remove monitored subscription from a Datadog monitor
```powershell
Remove-AzDatadogMonitoredSubscription -ConfigurationName default -MonitorName ddmonitor01 -ResourceGroupName datadog-rg
```

```output
Empty output indicates the command succeeded.
```

Removed the subscriptions currently being monitored by the specified Datadog monitor resource.
