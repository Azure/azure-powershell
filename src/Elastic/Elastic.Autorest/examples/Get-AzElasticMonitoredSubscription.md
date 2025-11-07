### Example 1: List all monitored subscriptions for an Elastic monitor
```powershell
Get-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor"
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
87654321-4321-4321-4321-210987654321 Disabled        Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command lists all subscriptions that are being monitored by the specified Elastic monitor.

### Example 2: Get a specific monitored subscription by subscription ID
```powershell
Get-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -SubscriptionId "12345678-1234-1234-1234-123456789012"
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command gets the monitoring status for a specific subscription within the Elastic monitor.

### Example 3: Get monitored subscription using pipeline from Get-AzElasticMonitor
```powershell
Get-AzElasticMonitor -ResourceGroupName "myResourceGroup" -Name "myElasticMonitor" | Get-AzElasticMonitoredSubscription
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
87654321-4321-4321-4321-210987654321 Disabled        Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command gets all monitored subscriptions by piping an Elastic monitor object from Get-AzElasticMonitor.

