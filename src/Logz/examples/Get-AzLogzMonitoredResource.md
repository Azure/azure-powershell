### Example 1: List the resources currently being monitored by the Logz monitor resource
```powershell
PS C:\> Get-AzLogzMonitoredResource -ResourceGroupName LPTrials -MonitorName lpatlogz

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
PS C:\> Get-AzLogzMonitoredResource -ResourceGroupName LPTrials -MonitorName lpatlogz -SubAccountName lpslogzsubaccount

ReasonForLogsStatus ReasonForMetricsStatus SendingLog SendingMetric
------------------- ---------------------- ---------- -------------
Other                                      False
```

This command lists the resources currently being monitored by the Logz sub account

