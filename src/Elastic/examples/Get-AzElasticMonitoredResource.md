### Example 1: List the resources currently being monitored by the Elastic monitor resource
```powershell
Get-AzElasticMonitoredResource -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01
```

```output
ReasonForLogsStatus            SendingLog
-------------------            ----------
CapturedByRules                True
CapturedByRules                True
CapturedByRules                True
DiagnosticSettingsLimitReached False
DiagnosticSettingsLimitReached False
```

List the resources currently being monitored by the Elastic monitor resource.

### Example 2: List the resources currently being monitored by the Elastic monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor01 | Get-AzElasticMonitoredResource
```

```output
ReasonForLogsStatus            SendingLog
-------------------            ----------
CapturedByRules                True
CapturedByRules                True
CapturedByRules                True
DiagnosticSettingsLimitReached False
DiagnosticSettingsLimitReached False
```

List the resources currently being monitored by the Elastic monitor resource via pipeline.
