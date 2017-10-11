---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmServiceBusSubscription

## SYNOPSIS
Updates a subscription description for a Service Bus topic in the specified Service Bus namespace.

## SYNTAX

```
Set-AzureRmServiceBusSubscription [-ResourceGroup] <String> [-NamespaceName] <String> [-TopicName] <String>
 [-SubscriptionObj] <SubscriptionAttributes> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmServiceBusSubscription** cmdlet updates the description of the subscription for the Service Bus topic in the specified Service Bus namespace.

## EXAMPLES

### Example 1
```
PS C:\> $subscriptionObj = Get-AzureRmServiceBusSubscription -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -TopicName SB-Topic_exampl1 -SubscriptionName SB-TopicSubscription-Example1

PS C:\> $subscriptionObj.DeadLetteringOnMessageExpiration = $True
PS C:\> $subscriptionObj.MaxDeliveryCount = 9

PS C:\> Set-AzureRmServiceBusSubscription -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -TopicName SB-Topic_exampl1 -SubscriptionObj $subscriptionObj
```

Updates the description for the specified subscription to the given topic. This example updates the **DeadLetteringOnMessageExpiration** property to **true** and **MaxDeliveryCount** to 9.

## PARAMETERS

### -NamespaceName
The Service Bus namespace name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroup
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionObj
The Service Bus subscription definition.

```yaml
Type: SubscriptionAttributes
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TopicName
The Service Bus topic name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### -ResourceGroup
 System.String

### -NamespaceName
 System.String

### -TopicName
 System.String

### -SubscriptionObj
 Microsoft.Azure.Commands.ServiceBus.Models.SubscriptionAttributes

## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.SubscriptionAttributes
Name                                      : SB-TopicSubscription-Example1
Location                                  : West US
AccessedAt                                : 1/1/0001 12:00:00 AM
AutoDeleteOnIdle                          : 10675199.02:48:05.4775807
CountDetails                              : 
CreatedAt                                 : 1/20/2017 9:59:15 PM
DefaultMessageTimeToLive                  : 10675199.02:48:05.4775807
DeadLetteringOnFilterEvaluationExceptions : True
DeadLetteringOnMessageExpiration          : True
EnableBatchedOperations                   : True
EntityAvailabilityStatus                  : Available
IsReadOnly                                : 
LockDuration                              : 00:01:00
MaxDeliveryCount                          : 9
MessageCount                              : 0
RequiresSession                           : False
Status                                    : Active
UpdatedAt                                 : 1/20/2017 9:59:15 PM

## NOTES

## RELATED LINKS

