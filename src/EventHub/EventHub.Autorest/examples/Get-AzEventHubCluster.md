### Example 1: Get an EventHub cluster
```powershell
Get-AzEventHubCluster -ResourceGroupName myResourceGroup -Name myCluster
```

```output
Capacity                     : 1
CreatedAt                    : 2022-08-29T09:38:30.453Z
Id                           : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/clusters/myCluster
Location                     : australiaeast
MetricId                     : PROD-00-000
Name                         : TestClusterAutomatic
ResourceGroupName            : AutomatedPowershellTesting
SkuName                      : Dedicated
Status                       :
SupportsScaling              : False
Tag                          : {}
```
