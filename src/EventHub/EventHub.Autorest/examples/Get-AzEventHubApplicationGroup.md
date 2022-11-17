### Example 1: Get an application group from an EventHub namespace
```powershell
Get-AzEventHubApplicationGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAppGroup
```

```output
ClientAppGroupIdentifier     : SASKeyName=RootManageSharedAccessKey
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/applicationGroups/
                               myAppGroup
IsEnabled                    : True
Location                     : Central US
Name                         : myAppGroup
Policy                       : {{
                                 "name": "throttlingPolicy1",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 10000,
                                 "metricId": "OutgoingMessages"
                               }, {
                                 "name": "throttlingPolicy2",
                                 "type": "ThrottlingPolicy",
                                 "rateLimitThreshold": 11111,
                                 "metricId": "OutgoingBytes"
                               }}
ResourceGroupName            : myResourceGroup
```

Gets details of application group `myAppGroup` from namespace `myNamespace`.

### Example 2: Lists all application groups in an EventHub namespace
```powershell
Get-AzEventHubApplicationGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all application groups from namespace `myNamespace`.