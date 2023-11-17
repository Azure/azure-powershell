### Example 1: Get Details of a ServiceBus queue
```powershell
Get-AzServiceBusQueue -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myQueue
```

```output
AccessedAt                                : 1/1/0001 12:00:00 AM
AutoDeleteOnIdle                          : 10675199.02:48:05.4775807
CountDetailActiveMessageCount             : 0
CountDetailDeadLetterMessageCount         : 0
CountDetailScheduledMessageCount          : 0
CountDetailTransferDeadLetterMessageCount : 0
CountDetailTransferMessageCount           : 0
CreatedAt                                 : 8/8/2022 10:15:08 AM
DeadLetteringOnMessageExpiration          : False
DefaultMessageTimeToLive                  : 10675199.02:48:05.4775807
DuplicateDetectionHistoryTimeWindow       : 00:10:00
EnableBatchedOperations                   : True
EnableExpress                             : False
EnablePartitioning                        : False
ForwardDeadLetteredMessagesTo             :
ForwardTo                                 :
Id                                        : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/queues/myQueue
Location                                  : westus
LockDuration                              : 00:01:00
MaxDeliveryCount                          : 10
MaxMessageSizeInKilobytes                 : 1024
MaxSizeInMegabytes                        : 1024
MessageCount                              : 0
Name                                      : myQueue
RequiresDuplicateDetection                : False
RequiresSession                           : False
ResourceGroupName                         : myResourceGroup
SizeInByte                                : 0
Status                                    : Disabled
```

Get the details of ServiceBus queue `myQueue` from namespace `myNamespace`.

### Example 2: List all queues in a ServiceBus namespace
```powershell
Get-AzServiceBusQueue -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all queues in ServiceBus namespace `myNamespace`.



