---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/new-azservicebustopic
schema: 2.0.0
---

# New-AzServiceBusTopic

## SYNOPSIS
Creates a topic in the specified namespace.

## SYNTAX

```
New-AzServiceBusTopic -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-AutoDeleteOnIdle <TimeSpan>] [-DefaultMessageTimeToLive <TimeSpan>]
 [-DuplicateDetectionHistoryTimeWindow <TimeSpan>] [-EnableBatchedOperations] [-EnableExpress]
 [-EnablePartitioning] [-MaxMessageSizeInKilobytes <Int64>] [-MaxSizeInMegabytes <Int32>]
 [-RequiresDuplicateDetection] [-Status <EntityStatus>] [-SupportOrdering] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a topic in the specified namespace.

## EXAMPLES

### Example 1: Creates a new ServiceBus topic
```powershell
New-AzServiceBusTopic -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myTopic -DefaultMessageTimeToLive (New-TimeSpan -Days 18) -EnableBatchedOperations
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
DefaultMessageTimeToLive                  : 18.00:00:00
DuplicateDetectionHistoryTimeWindow       : 00:10:00
EnableBatchedOperations                   : True
EnableExpress                             : False
EnablePartitioning                        : False
Id                                        : /subscriptions/000000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/topics/myTopic
Location                                  : westus
MaxMessageSizeInKilobytes                 : 1024
MaxSizeInMegabytes                        : 1024
Name                                      : myTopic
RequiresDuplicateDetection                : False
ResourceGroupName                         : myResourceGroup
SizeInByte                                : 0
Status                                    : Active
SubscriptionCount                         : 0
SupportOrdering                           : True
```

Creates a new ServiceBus topic `myTopic` within namespace `myNamespace`.

## PARAMETERS

### -AutoDeleteOnIdle
Idle interval after which the queue is automatically deleted.
The minimum duration is 5 minutes.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultMessageTimeToLive
This is the duration after which the message expires, starting from when the message is sent to Service Bus.
This is the default value used when TimeToLive is not set on a message itself.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DuplicateDetectionHistoryTimeWindow
Defines the duration of the duplicate detection history.
The default value is 10 minutes.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableBatchedOperations
Value that indicates whether server-side batched operations are enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableExpress
Value that indicates whether Express Entities are enabled.
An express topic holds a message in memory temporarily before writing it to persistent storage.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnablePartitioning
Value that indicates whether the topic to be partitioned across multiple message brokers is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxMessageSizeInKilobytes
Maximum size (in KB) of the message payload that can be accepted by the topic.
This property is only used in Premium today and default is 1024.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxSizeInMegabytes
Maximum size of the topic in megabytes, which is the size of the memory allocated for the topic.
Default is 1024.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The topic name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: TopicName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The namespace name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequiresDuplicateDetection
Value indicating if this topic requires duplicate detection.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Enumerates the possible values for the status of a messaging entity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.EntityStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SupportOrdering
Value that indicates whether the topic supports ordering.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.ISbTopic

## NOTES

ALIASES

## RELATED LINKS

