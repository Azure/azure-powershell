### Example 1: Resubscribe an Elastic organization to a new Azure subscription
```powershell
Get-AzElasticResubscribeOrganization -ResourceGroupName "myResourceGroup" -MonitorName "myElasticMonitor" -TargetSubscriptionId "87654321-4321-4321-4321-210987654321"
```

```output
Id                   : /subscriptions/87654321-4321-4321-4321-210987654321/resourceGroups/myResourceGroup/providers/Microsoft.Elastic/monitors/myElasticMonitor/resubscribe
Name                 : myElasticMonitor
Type                 : Microsoft.Elastic/monitors/resubscribe
Status               : InProgress
TargetSubscriptionId : 87654321-4321-4321-4321-210987654321
Message              : Resubscription initiated successfully
```

This command resubscribes the specified Elastic monitor to a new Azure subscription, moving the marketplace subscription to the target subscription.

### Example 2: Resubscribe using pipeline from Get-AzElasticMonitor
```powershell
Get-AzElasticMonitor -ResourceGroupName "myResourceGroup" -Name "myElasticMonitor" | Get-AzElasticResubscribeOrganization -TargetSubscriptionId "87654321-4321-4321-4321-210987654321"
```

```output
Id                   : /subscriptions/87654321-4321-4321-4321-210987654321/resourceGroups/myResourceGroup/providers/Microsoft.Elastic/monitors/myElasticMonitor/resubscribe
Name                 : myElasticMonitor
Type                 : Microsoft.Elastic/monitors/resubscribe
Status               : InProgress
TargetSubscriptionId : 87654321-4321-4321-4321-210987654321
Message              : Resubscription initiated successfully
```

This command resubscribes an Elastic monitor to a new subscription by piping the monitor object from Get-AzElasticMonitor.

### Example 3: Resubscribe with additional parameters using parameter expansion
```powershell
$resubscribeParams = @{
    ResourceGroupName = "myResourceGroup"
    MonitorName = "myElasticMonitor"
    TargetSubscriptionId = "87654321-4321-4321-4321-210987654321"
}
Get-AzElasticResubscribeOrganization @resubscribeParams
```

```output
Id                   : /subscriptions/87654321-4321-4321-4321-210987654321/resourceGroups/myResourceGroup/providers/Microsoft.Elastic/monitors/myElasticMonitor/resubscribe
Name                 : myElasticMonitor
Type                 : Microsoft.Elastic/monitors/resubscribe
Status               : InProgress
TargetSubscriptionId : 87654321-4321-4321-4321-210987654321
Message              : Resubscription initiated successfully
```

This command demonstrates using parameter splatting to resubscribe an Elastic organization, which is useful for scripts and automation scenarios.

