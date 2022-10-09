### Example 1: Updates a ServiceBus topic
```powershell
Set-AzServiceBusTopic -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myTopic -DefaultMessageTimeToLive (New-TimeSpan -Days 20) -MaxMessageSizeInKilobytes 102400
```

```output
AccessedAt                                : 1/1/0001 12:00:00 AM
AutoDeleteOnIdle                          : 10675199.02:48:05.4775807
CountDetailActiveMessageCount             : 0
CountDetailDeadLetterMessageCount         : 0
CountDetailScheduledMessageCount          : 0
CountDetailTransferDeadLetterMessageCount : 0
CountDetailTransferMessageCount           : 0
CreatedAt                                 : 1/1/0001 12:00:00 AM
DefaultMessageTimeToLive                  : 20.00:00:00
DuplicateDetectionHistoryTimeWindow       : 00:10:00
EnableBatchedOperations                   : True
EnableExpress                             : False
EnablePartitioning                        : False
Id                                        : /subscriptions/000000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/topics/myTopic
Location                                  : westus
MaxMessageSizeInKilobytes                 : 102400
MaxSizeInMegabytes                        : 1024
Name                                      : myTopic
RequiresDuplicateDetection                : False
ResourceGroupName                         : myResourceGroup
SizeInByte                                : 0
Status                                    : Active
SubscriptionCount                         : 0
SupportOrdering                           : True
```

Updates a ServiceBus topic `myTopic` within namespace `myNamespace`.

### Example 2: Updates a ServiceBus topic using InputObject parameter set
```powershell
$topic = Get-AzServiceBusTopic -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myTopic
Set-AzServiceBusTopic -InputObject $topic -DefaultMessageTimeToLive (New-TimeSpan -Days 20) -MaxMessageSizeInKilobytes 102400
```

```output
AccessedAt                                : 1/1/0001 12:00:00 AM
AutoDeleteOnIdle                          : 10675199.02:48:05.4775807
CountDetailActiveMessageCount             : 0
CountDetailDeadLetterMessageCount         : 0
CountDetailScheduledMessageCount          : 0
CountDetailTransferDeadLetterMessageCount : 0
CountDetailTransferMessageCount           : 0
CreatedAt                                 : 1/1/0001 12:00:00 AM
DefaultMessageTimeToLive                  : 20.00:00:00
DuplicateDetectionHistoryTimeWindow       : 00:10:00
EnableBatchedOperations                   : True
EnableExpress                             : False
EnablePartitioning                        : False
Id                                        : /subscriptions/000000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/topics/myTopic
Location                                  : westus
MaxMessageSizeInKilobytes                 : 102400
MaxSizeInMegabytes                        : 1024
Name                                      : myTopic
RequiresDuplicateDetection                : False
ResourceGroupName                         : myResourceGroup
SizeInByte                                : 0
Status                                    : Active
SubscriptionCount                         : 0
SupportOrdering                           : True
```

Updates a ServiceBus topic `myTopic` within namespace `myNamespace` using InputObject parameter set.

