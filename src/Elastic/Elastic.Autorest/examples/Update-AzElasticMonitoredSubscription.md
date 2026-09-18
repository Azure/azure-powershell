### Example 1: Enable monitoring for a subscription
```powershell
Update-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Operation "Add"
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command adds a subscription to the Elastic monitor for monitoring, enabling log and metric collection from the specified subscription.

### Example 2: Disable monitoring for a subscription
```powershell
Update-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -SubscriptionId "12345678-1234-1234-1234-123456789012" -Operation "Delete"
```

```output
SubscriptionId                        Status     Error TagRules
--------------                        ------     ----- --------
12345678-1234-1234-1234-123456789012 Disabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command removes a subscription from monitoring, disabling log and metric collection from the specified subscription.

### Example 3: Update monitored subscription using pipeline from Get-AzElasticMonitor
```powershell
Get-AzElasticMonitor -ResourceGroupName "myResourceGroup" -Name "myElasticMonitor" | Update-AzElasticMonitoredSubscription -SubscriptionId "12345678-1234-1234-1234-123456789012" -Operation "Add"
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command updates monitored subscription configuration by piping an Elastic monitor object from Get-AzElasticMonitor.

### Example 4: Update multiple subscriptions in batch
```powershell
$subscriptions = @("12345678-1234-1234-1234-123456789012", "87654321-4321-4321-4321-210987654321")
foreach ($sub in $subscriptions) {
    Update-AzElasticMonitoredSubscription -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -SubscriptionId $sub -Operation "Add"
}
```

```output
SubscriptionId                        Status    Error TagRules
--------------                        ------    ----- --------
12345678-1234-1234-1234-123456789012 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
87654321-4321-4321-4321-210987654321 Enabled         Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.Api20200701.MonitoringTagRules
```

This command demonstrates updating monitoring configuration for multiple subscriptions in a batch operation, useful for managing monitoring at scale.

