### Example 1: Get the details of the ServiceBus topic
```powershell
Get-AzServiceBusTopic -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic
```

```output
AccessedAt                                : 9/21/2022 2:30:14 PM
AutoDeleteOnIdle                          : 3.00:00:00
CreatedAt                                 : 9/7/2022 10:05:52 AM
DefaultMessageTimeToLive                  : 10675197.00:00:00
DuplicateDetectionHistoryTimeWindow       : 00:10:00
EnableBatchedOperations                   : True
EnableExpress                             : False
EnablePartitioning                        : False
Id                                        : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/topics/myTopic
Location                                  : westus
MaxMessageSizeInKilobytes                 : 1024
MaxSizeInMegabytes                        : 1024
Name                                      : a
RequiresDuplicateDetection                : False
ResourceGroupName                         : damorg
SizeInByte                                : 0
Status                                    : Active
SubscriptionCount                         : 2
SupportOrdering                           : True
```

Get the details of ServiceBus topic `myTopic` from namespace `myNamespace`.

### Example 2: List all topics in a ServiceBus namespace
```powershell
Get-AzServiceBusTopic -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all topics in ServiceBus namespace `myNamespace`.

