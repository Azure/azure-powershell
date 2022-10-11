### Example 1: Update a ServiceBus subscription
```powershell
Set-AzServiceBusSubscription -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -Name mySubscription -DefaultMessageTimeToLive (New-TimeSpan -Days 10) -EnableBatchedOperations
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
DefaultMessageTimeToLive                  : 10.00:00:00
DuplicateDetectionHistoryTimeWindow       :
EnableBatchedOperations                   : True
ForwardDeadLetteredMessagesTo             :
ForwardTo                                 :
Id                                        : /subscriptions/000000000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/topics/myTopic/subscriptions/mySubscription
IsClientAffine                            : False
IsDurable                                 :
IsShared                                  :
Location                                  : westus
LockDuration                              : 00:01:00
MaxDeliveryCount                          : 10
MessageCount                              : 0
Name                                      : testsub
RequiresSession                           : False
ResourceGroupName                         : myResourceGroup
Status                                    : Active
```

Updates `DefaultMessageTimeToLive` and `EnableBatchedOperations` ServiceBus subscription `mySubscription` under topic `myTopic`.

### Example 1: Update a ServiceBus subscription using InputObject parameter set
```powershell
$subscription = Get-AzServiceBusSubscription -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -Name mySubscription
Set-AzServiceBusSubscription -InputObject $subscription -DefaultMessageTimeToLive (New-TimeSpan -Days 10) -EnableBatchedOperations
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
DefaultMessageTimeToLive                  : 10.00:00:00
DuplicateDetectionHistoryTimeWindow       :
EnableBatchedOperations                   : True
ForwardDeadLetteredMessagesTo             :
ForwardTo                                 :
Id                                        : /subscriptions/000000000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/topics/myTopic/subscriptions/mySubscription
IsClientAffine                            : False
IsDurable                                 :
IsShared                                  :
Location                                  : westus
LockDuration                              : 00:01:00
MaxDeliveryCount                          : 10
MessageCount                              : 0
Name                                      : testsub
RequiresSession                           : False
ResourceGroupName                         : myResourceGroup
Status                                    : Active
```

Updates `DefaultMessageTimeToLive` and `EnableBatchedOperations` ServiceBus subscription `mySubscription` under topic `myTopic` using InputObject parameter set.