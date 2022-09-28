### Example 1: Create an application group with 2 Throttling policies
```powershell
$t1 = New-AzEventHubThrottlingPolicyConfig -Name t1 -MetricId IncomingMessages -RateLimitThreshold 10000
$t2 = New-AzEventHubThrottlingPolicyConfig -Name t2 -MetricId OutgoingBytes -RateLimitThreshold 20000
New-AzEventHubApplicationGroup -NamespaceName myNamespace -ResourceGroupName myResourceGroup -Name myAppGroup -ClientAppGroupIdentifier SASKeyName=a -Policy $t1,$t2
```

```output
ClientAppGroupIdentifier     : SASKeyName=a
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/applicationGroups/
                               myAppGroup
IsEnabled                    : True
Location                     : Central US
Name                         : myAppGroup
Policy                       : {{
                                 "name": "t1",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 10000,
                                 "metricId": "IncomingMessages"
                               }, {
                                 "name": "t2",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 20000,
                                 "metricId": "OutgoingBytes"
                               }}
ResourceGroupName            : myResourceGroup
```

Creates a new application group `myAppGroup` on namespace `myNamespace` with 2 throttling policies.