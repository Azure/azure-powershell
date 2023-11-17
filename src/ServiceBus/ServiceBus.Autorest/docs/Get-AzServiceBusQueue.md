---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/get-azservicebusqueue
schema: 2.0.0
---

# Get-AzServiceBusQueue

## SYNOPSIS
Returns a description for the specified queue.

## SYNTAX

### List (Default)
```
Get-AzServiceBusQueue -NamespaceName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Skip <Int32>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzServiceBusQueue -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzServiceBusQueue -InputObject <IServiceBusIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns a description for the specified queue.

## EXAMPLES

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

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The queue name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: QueueName

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skip is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skip parameter that specifies a starting point to use for subsequent calls.

```yaml
Type: System.Int32
Parameter Sets: List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
May be used to limit the number of results to the most recent N usageDetails.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.ISbQueue

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IServiceBusIdentity>`: Identity Parameter
  - `[Alias <String>]`: The Disaster Recovery configuration name
  - `[AuthorizationRuleName <String>]`: The authorization rule name.
  - `[ConfigName <MigrationConfigurationName?>]`: The configuration name. Should always be "$default".
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The namespace name
  - `[PrivateEndpointConnectionName <String>]`: The PrivateEndpointConnection name
  - `[QueueName <String>]`: The queue name.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[RuleName <String>]`: The rule name.
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[SubscriptionName <String>]`: The subscription name.
  - `[TopicName <String>]`: The topic name.

## RELATED LINKS

