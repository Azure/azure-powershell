---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmServiceBusSubscription

## SYNOPSIS
Create a new Subscription for the provided ServiceBus Topic

## SYNTAX

```
New-AzureRmServiceBusSubscription [-ResourceGroup] <String> [-NamespaceName] <String> [-TopicName] <String>
 [-SubscriptionName] <String> [-AutoDeleteOnIdle <String>]
 [-DeadLetteringOnFilterEvaluationExceptions <Boolean>] [-DeadLetteringOnMessageExpiration <Boolean>]
 [-EnableBatchedOperations <Boolean>] [-IsReadOnly <Boolean>] [-LockDuration <String>]
 [-MaxDeliveryCount <Int32>] [-RequiresSession <Boolean>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The ** New-AzureRmServiceBusSubscription ** cmdlet create a new Subscription for the provided ServiceBus Topic.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmServiceBusSubscription -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -TopicName SB-Topic_exampl1 -SubscriptionName SB-TopicSubscription-Example1
```

Creates	 new subscription 'SB-TopicSubscription-Example1' for the provided ServiceBus Topic 'SB-Topic_exampl1'

## PARAMETERS

### -AutoDeleteOnIdle
Auto Delete On Idle - the TimeSpan idle interval after which the queue is automatically deleted.
The minimum duration is 5 minutes.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
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

### -DeadLetteringOnFilterEvaluationExceptions
DeadLetteringOnFilterEvaluationExceptions - Value that indicates if a subscription has dead letter support when a message expires.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 
Accepted values: TRUE, FALSE

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DeadLetteringOnMessageExpiration
Dead Lettering On Message Expiration

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 
Accepted values: TRUE, FALSE

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableBatchedOperations
Enable Batched Operations - value that indicates whether server-side batched operations are enabled

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 
Accepted values: TRUE, FALSE

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IsReadOnly
IsReadOnly - Value that indicates whether the entity description is read-only.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 
Accepted values: TRUE, FALSE

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LockDuration
Lock Duration

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaxDeliveryCount
MaxDeliveryCount - the maximum delivery count.
A message is automatically deadlettered after this number of deliveries.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NamespaceName
Namespace Name.

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

### -RequiresSession
RequiresSession - the value indicating if this queue requires duplicate detection.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases: 
Accepted values: TRUE, FALSE

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroup
The name of the resource group

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

### -SubscriptionName
Subscription Name

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

### -TopicName
Topic Name.

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

### System.String
System.Nullable\`1\[\[System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\]\] System.Nullable\`1\[\[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\]\]

-ResourceGroup : System.String
-NamespaceName : System.String
-TopicName : System.String
-SubscriptionName : System.String


## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.SubscriptionAttributes

Name                                      : SB-TopicSubscription-Example1
Location                                  : West US
AccessedAt                                : 1/20/2017 3:18:54 AM
AutoDeleteOnIdle                          : 10675199.02:48:05.4775807
CountDetails                              : Microsoft.Azure.Management.ServiceBus.Models.MessageCountDetails
CreatedAt                                 : 1/20/2017 3:18:52 AM
DefaultMessageTimeToLive                  : 10675199.02:48:05.4775807
DeadLetteringOnFilterEvaluationExceptions : True
DeadLetteringOnMessageExpiration          : False
EnableBatchedOperations                   : True
EntityAvailabilityStatus                  : Available
IsReadOnly                                : 
LockDuration                              : 00:01:00
MaxDeliveryCount                          : 10
MessageCount                              : 0
RequiresSession                           : False
Status                                    : Active
UpdatedAt                                 : 1/20/2017 3:18:54 AM

## NOTES

## RELATED LINKS

