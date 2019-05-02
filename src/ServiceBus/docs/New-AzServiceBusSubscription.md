---
external help file: Az.ServiceBus-help.xml
Module Name: Az.ServiceBus
online version: https://docs.microsoft.com/en-us/powershell/module/az.servicebus/new-azservicebussubscription
schema: 2.0.0
---

# New-AzServiceBusSubscription

## SYNOPSIS
Creates a topic subscription.

## SYNTAX

### CreateSubscriptionIdViaHost (Default)
```
New-AzServiceBusSubscription -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 -TopicName <String> [-Parameter <ISbSubscription>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzServiceBusSubscription -Id <String> -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 -TopicName <String> [-AutoDeleteOnIdle <TimeSpan>] [-DeadLetteringOnFilterEvaluationException <Boolean>]
 [-DeadLetteringOnMessageExpiration <Boolean>] [-DefaultMessageTimeToLive <TimeSpan>]
 [-DuplicateDetectionHistoryTimeWindow <TimeSpan>] [-EnableBatchedOperation <Boolean>]
 [-ForwardDeadLetteredMessagesTo <String>] [-ForwardTo <String>] [-LockDuration <TimeSpan>]
 [-MaxDeliveryCount <Int32>] [-RequiresSession <Boolean>] [-Status <EntityStatus>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzServiceBusSubscription -Id <String> -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 -TopicName <String> [-Parameter <ISbSubscription>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateSubscriptionIdViaHostExpanded
```
New-AzServiceBusSubscription -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 -TopicName <String> [-AutoDeleteOnIdle <TimeSpan>] [-DeadLetteringOnFilterEvaluationException <Boolean>]
 [-DeadLetteringOnMessageExpiration <Boolean>] [-DefaultMessageTimeToLive <TimeSpan>]
 [-DuplicateDetectionHistoryTimeWindow <TimeSpan>] [-EnableBatchedOperation <Boolean>]
 [-ForwardDeadLetteredMessagesTo <String>] [-ForwardTo <String>] [-LockDuration <TimeSpan>]
 [-MaxDeliveryCount <Int32>] [-RequiresSession <Boolean>] [-Status <EntityStatus>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a topic subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AutoDeleteOnIdle
ISO 8061 timeSpan idle interval after which the topic is automatically deleted.
The minimum duration is 5 minutes.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadLetteringOnFilterEvaluationException
Value that indicates whether a subscription has dead letter support on filter evaluation exceptions.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadLetteringOnMessageExpiration
Value that indicates whether a subscription has dead letter support when a message expires.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultMessageTimeToLive
ISO 8061 Default message timespan to live value.
This is the duration after which the message expires, starting from when the message is sent to Service Bus.
This is the default value used when TimeToLive is not set on a message itself.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
ISO 8601 timeSpan structure that defines the duration of the duplicate detection history.
The default value is 10 minutes.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableBatchedOperation
Value that indicates whether server-side batched operations are enabled.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForwardDeadLetteredMessagesTo
Queue/Topic name to forward the Dead Letter message

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForwardTo
Queue/Topic name to forward the messages

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Create
Aliases: SubscriptionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LockDuration
ISO 8061 lock duration timespan for the subscription.
The default value is 1 minute.

```yaml
Type: System.TimeSpan
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxDeliveryCount
Number of maximum deliveries.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The subscription name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SubscriptionName

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
Aliases: Namespace

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Description of subscription resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.ISbSubscription
Parameter Sets: CreateSubscriptionIdViaHost, Create
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RequiresSession
Value indicating if a subscription supports the concept of sessions.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: False
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicName
The topic name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Topic

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.ISbSubscription
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.servicebus/new-azservicebussubscription](https://docs.microsoft.com/en-us/powershell/module/az.servicebus/new-azservicebussubscription)

