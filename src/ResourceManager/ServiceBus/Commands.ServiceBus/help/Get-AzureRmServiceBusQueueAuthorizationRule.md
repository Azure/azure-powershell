---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmServiceBusQueueAuthorizationRule

## SYNOPSIS
Gets the Description of a specified AuthorizationRule for a given ServiceBus Queue. 

## SYNTAX

```
Get-AzureRmServiceBusQueueAuthorizationRule [-ResourceGroup] <String> [-NamespaceName] <String>
 [-QueueName] <String> [[-AuthorizationRuleName] <String>] [<CommonParameters>]
```

## DESCRIPTION
The ** Get-AzureRmServiceBusQueueAuthorizationRule ** cmdlet gets the description of specified authorizationrule of the given servicebus queue.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmServiceBusQueueAuthorizationRule -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -QueueName SB-Queue_exampl1 -AuthorizationRuleName SBAuthoRule1
```

Returns the specified AuthorizationRule description for a given ServiceBus Queue.

## PARAMETERS

### -AuthorizationRuleName
EventHub AuthorizationRule Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
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

### -QueueName
Queue Name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

-ResourceGroup : System.String
-NamespaceName : System.String
-QueueName : System.String
-AuthorizationRuleName : System.String

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.ServiceBus.Models.SharedAccessAuthorizationRuleAttributes, Microsoft.Azure.Commands.ServiceBus, Version=0.0.1.0, Culture=neutral, PublicKeyToken=null]]

Id       : /subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.ServiceBus/namespaces/SB-Example1/queues/SB-Queue_exampl1/authorizati
           onRules/SBAuthoRule1
Type     : Microsoft.ServiceBus/AuthorizationRules
Name     : SBAuthoRule1
Location : West US
Tags     : 
Rights   : {Listen, Send}


## NOTES

## RELATED LINKS

