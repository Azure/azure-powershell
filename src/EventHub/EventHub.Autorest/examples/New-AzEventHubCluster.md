### Example 1: Create a self-serve cluster
```powershell
New-AzEventHubCluster -ResourceGroupName myResourceGroup -Name myCluster -Location "eastasia" -SupportsScaling -Capacity 2
```

```output
Capacity                     : 2
CreatedAt                    : 2022-08-29T09:38:30.453Z
Id                           : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/clusters/myCluster
Location                     : australiaeast
MetricId                     : PROD-00-000
Name                         : myCluster
ResourceGroupName            : myResourceGroup
SkuName                      : Dedicated
Status                       :
SupportsScaling              : True
Tag                          : {}
```

### Example 2: Create an EventHubs dedicated cluster of Capacity 1CU
```powershell
New-AzEventHubCluster -ResourceGroupName myResourceGroup -Name myCluster -Location "eastasia"
```

```output
Capacity                     : 1
CreatedAt                    : 2022-08-29T09:38:30.453Z
Id                           : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/clusters/myCluster
Location                     : australiaeast
MetricId                     : PROD-00-000
Name                         : myCluster
ResourceGroupName            : myResourceGroup
SkuName                      : Dedicated
Status                       :
SupportsScaling              :
Tag                          : {}
```

