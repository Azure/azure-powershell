### Example 1: List the resources currently being monitored by the Logz monitor resource
```powershell
<<<<<<< HEAD
Get-AzLogzMonitoredResource -ResourceGroupName LPTrials -MonitorName lpatlogz
```

```output
=======
PS C:\> Get-AzLogzMonitoredResource -ResourceGroupName LPTrials -MonitorName lpatlogz

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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
<<<<<<< HEAD
Get-AzLogzMonitoredResource -ResourceGroupName LPTrials -MonitorName lpatlogz -SubAccountName lpslogzsubaccount
```

```output
=======
PS C:\> Get-AzLogzMonitoredResource -ResourceGroupName LPTrials -MonitorName lpatlogz -SubAccountName lpslogzsubaccount

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ReasonForLogsStatus ReasonForMetricsStatus SendingLog SendingMetric
------------------- ---------------------- ---------- -------------
Other                                      False
```

This command lists the resources currently being monitored by the Logz sub account

