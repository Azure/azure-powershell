### Example 1: Create a new ServiceBus subscription
```powershell
New-AzServiceBusSubscription -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -Name mySubscription -DefaultMessageTimeToLive (New-TimeSpan -Days 6) -EnableBatchedOperations
```

```output
AccessedAt                                : 1/1/0001 12:00:00 AM
AutoDeleteOnIdle                          : 10675199.02:48:05.4775807
ClientId                                  :
CountDetailActiveMessageCount             : 0
CountDetailDeadLetterMessageCount         : 0
CountDetailScheduledMessageCount          : 0
CountDetailTransferDeadLetterMessageCount : 0
CountDetailTransferMessageCount           : 0
CreatedAt                                 : 9/23/2022 2:37:46 PM
DeadLetteringOnFilterEvaluationException  : True
DeadLetteringOnMessageExpiration          : False
DefaultMessageTimeToLive                  : 6.00:00:00
DuplicateDetectionHistoryTimeWindow       :
EnableBatchedOperations                   : True
ForwardDeadLetteredMessagesTo             :
ForwardTo                                 :
Id                                        : /subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/damorg/providers/Microsoft.ServiceBus/namespaces/testlatests
                                            bmsi/topics/a/subscriptions/testsub
IsClientAffine                            : False
IsDurable                                 :
IsShared                                  :
Location                                  : westus
LockDuration                              : 00:01:00
MaxDeliveryCount                          : 10
MessageCount                              : 0
Name                                      : testsub
RequiresSession                           : False
ResourceGroupName                         : damorg
Status                                    : Active
```

Creates a new ServiceBus subscription `mySubscription` under topic `myTopic`.

