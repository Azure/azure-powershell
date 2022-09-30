### Example 1: Get an EventHub cluster
```powershell
Get-AzEventHubCluster -ResourceGroupName myResourceGroup -Name DefaultCluster-11
```

```output
Capacity                     : 1
CreatedAt                    : 2022-08-29T09:38:30.453Z
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/clusters/DefaultCluster-11
Location                     : australiaeast
MetricId                     : PROD-00-000
Name                         : DefaultCluster-11
ResourceGroupName            : myResourceGroup
SkuName                      : Dedicated
Status                       :
SupportsScaling              : False
Tag                          : {}
```

Gets details of EventHubs dedicated cluster by the name `DefaultCluster-11`.
