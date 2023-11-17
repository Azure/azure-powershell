### Example 1: Create a new ServiceBus queue
```powershell
New-AzServiceBusQueue -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myQueue -AutoDeleteOnIdle (New-TimeSpan -Days 1 -Minutes 3 -Seconds 4) -DefaultMessageTimeToLive (New-TimeSpan -Days 5) -EnablePartitioning
```

```output
AccessedAt                                : 1/1/0001 12:00:00 AM
AutoDeleteOnIdle                          : 1.00:03:04
CountDetailActiveMessageCount             : 0
CountDetailDeadLetterMessageCount         : 0
CountDetailScheduledMessageCount          : 0
CountDetailTransferDeadLetterMessageCount : 0
CountDetailTransferMessageCount           : 0
CreatedAt                                 : 9/22/2022 12:30:45 PM
DeadLetteringOnMessageExpiration          : False
DefaultMessageTimeToLive                  : 5.00:00:00
DuplicateDetectionHistoryTimeWindow       : 00:10:00
EnableBatchedOperations                   : True
EnableExpress                             : False
EnablePartitioning                        : True
ForwardDeadLetteredMessagesTo             :
ForwardTo                                 :
Id                                        : /subscriptions/326100e2-f69d-4268-8503-075374f62b6e/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/queues/myQueue
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
Status                                    : Active
```

Creates a ServiceBus queue `myQueue` in namespace `myNamespace`.

