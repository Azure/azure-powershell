### Example 1: Add monitoring for a subscription
```powershell
Set-AzDatadogMonitoredSubscriptionCreateor -ResourceGroupName "myResourceGroup" -MonitorName "myDatadogMonitor" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Operation "Add"
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Datadog.Models.Api20250611.MonitoringTagRules
```

This command adds a subscription to the Datadog monitor for monitoring, enabling log and metric collection from the specified subscription.
