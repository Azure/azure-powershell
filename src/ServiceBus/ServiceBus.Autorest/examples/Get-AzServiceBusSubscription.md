### Example 1: Get details of the ServiceBus subscription
```powershell
Get-AzServiceBusSubscription -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -Name 'sub$$D' 
```

```output
AccessedAt                                : 1/1/0001 12:00:00 AM
AutoDeleteOnIdle                          : 1.00:03:04
ClientId                                  :
CountDetailActiveMessageCount             : 0
CountDetailDeadLetterMessageCount         : 0
CountDetailScheduledMessageCount          : 0
CountDetailTransferDeadLetterMessageCount : 0
CountDetailTransferMessageCount           : 0
CreatedAt                                 : 9/22/2022 6:17:32 AM
DeadLetteringOnFilterEvaluationException  : False
DeadLetteringOnMessageExpiration          : False
DefaultMessageTimeToLive                  : 14.00:00:00
DuplicateDetectionHistoryTimeWindow       :
EnableBatchedOperations                   : True
ForwardDeadLetteredMessagesTo             :
ForwardTo                                 :
Id                                        : /subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/damorg/providers/Microsoft.ServiceBus/namespaces/testlatestS
                                            BMSI/topics/myTopic/subscriptions/sub$$D
IsClientAffine                            : True
IsDurable                                 : True
IsShared                                  : True
Location                                  : westus
LockDuration                              : 00:00:30
MaxDeliveryCount                          : 10
MessageCount                              : 0
Name                                      : sub$$D
RequiresSession                           : False
ResourceGroupName                         : damorg
Status                                    : Active
```

Get details of subcription `sub$$D` from ServiceBus topic `myTopic`.

### Example 2: List all subscriptions in a topic
```powershell
Get-AzServiceBusSubscription -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic
```

List all subscriptions in ServiceBus topic `myTopic`.

