### Example 1: Add throttling policies to an Application Group
```powershell
$t3 = New-AzEventHubThrottlingPolicyConfig -Name t3 -MetricId OutgoingMessages -RateLimitThreshold 12000
$appGroup = Get-AzEventHubApplicationGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAppGroup
$appGroup.Policy += $t3
Set-AzEventHubApplicationGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAppGroup -Policy $appGroup.Policy
```

```output
ClientAppGroupIdentifier     : SASKeyName=a
Id                           : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/applicationGroups/
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
                               }, {
                                 "name": "t3",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 12000,
                                 "metricId": "OutgoingMessages"
                               }}
ResourceGroupName            : myResourceGroup
```

`-Policy` takes an array of Policy objects. It represents the entire set of throttling policies defined on the appplication group and not just the one. If you want to add or remove throttling policies, the right way to do it is to get the application group and query the Policy data member of the object returned as shown above.

### Example 2: Update application group using InputObject parameter set
```powershell
$appGroup = Get-AzEventHubApplicationGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAppGroup
Set-AzEventHubApplicationGroup -InputObject $appGroup -IsEnabled:$false
```

```output
ClientAppGroupIdentifier     : SASKeyName=a
Id                           : /subscriptions/{subscriptionId}/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/applicationGroups/
                               myAppGroup
IsEnabled                    : False
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
                               }, {
                                 "name": "t3",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 12000,
                                 "metricId": "OutgoingMessages"
                               }}
ResourceGroupName            : myResourceGroup
```

Disables application group `myAppGroup`.

