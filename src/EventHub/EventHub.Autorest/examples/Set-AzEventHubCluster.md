### Example 1: Update EventHubs dedicated cluster
```powershell
Set-AzEventHubCluster -ResourceGroupName myResourceGroup -Name myCluster -Capacity 3
```

```output
Capacity                     : 3
CreatedAt                    : 2022-08-29T09:38:30.453Z
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/clusters/myCluster
Location                     : australiaeast
MetricId                     : PROD-00-000
Name                         : myCluster
ResourceGroupName            : myResourceGroup
SkuName                      : Dedicated
Status                       :
SupportsScaling              : False
Tag                          : {}
```

Updates the capacity of an EventHubs dedicated cluster to 3.

### Example 2: Update EventHubs dedicated cluster using InputObject parameter set
```powershell
$cluster = Get-AzEventHubCluster -ResourceGroupName myResourceGroup -Name myCluster
Set-AzEventHubCluster -InputObject $cluster -Capacity 3
```

```output
Capacity                     : 3
CreatedAt                    : 2022-08-29T09:38:30.453Z
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/clusters/myCluster
Location                     : australiaeast
MetricId                     : PROD-00-000
Name                         : myCluster
ResourceGroupName            : myResourceGroup
SkuName                      : Dedicated
Status                       :
SupportsScaling              : False
Tag                          : {}
```

Updates the capacity of an EventHubs dedicated cluster to 3.