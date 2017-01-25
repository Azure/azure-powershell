---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmServiceBusSubscription

## SYNOPSIS
Removes the Subscription of Topic from the provided Servicebus Namespace

## SYNTAX

```
Remove-AzureRmServiceBusSubscription [-ResourceGroup] <String> [-NamespaceName] <String> [-TopicName] <String>
 [-SubscriptionName] <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The ** Remove-AzureRmServiceBusSubscription ** cmdlet removes the Subscription of Topic from the given ServiceBus Namespace

## EXAMPLES

### Example 1
```
PS C:\> Remove-AzureRmServiceBusSubscription -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -TopicName SB-Topic_exampl1 -SubscriptionName SB-TopicSubscription-Example1
```

Removes the Subscription 'SB-TopicSubscription-Example1' of Topic 'SB-Topic_exampl1' for the provided ServiceBus Namespace 'SB-Example1'

## PARAMETERS

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
Subscription Name.

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

-ResourceGroup : System.String

-NamespaceName : System.String

-TopicName : System.String

-SubscriptionName : System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

