### Example 1: List the resources currently being monitored by the Logz monitor resource
```powershell
Get-AzLogzMonitoredResource -ResourceGroupName LPTrials -MonitorName lpatlogz
```

```output
ReasonForLogsStatus            ReasonForMetricsStatus SendingLog SendingMetric
-------------------            ---------------------- ---------- -------------
CapturedByRules                                       True
CapturedByRules                                       True
CapturedByRules                                       True
CapturedByRules                                       True
CapturedByRules                                       True
```

This command lists the resources currently being monitored by the Logz monitor resource.

### Example 2: List the resources currently being monitored by the Logz sub account
```powershell
Get-AzLogzMonitoredResource -ResourceGroupName LPTrials -MonitorName lpatlogz -SubAccountName lpslogzsubaccount
```

```output
ReasonForLogsStatus ReasonForMetricsStatus SendingLog SendingMetric
------------------- ---------------------- ---------- -------------
Other                                      False
```

This command lists the resources currently being monitored by the Logz sub account

