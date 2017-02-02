---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmServiceBusTopicAuthorizationRule

## SYNOPSIS
Returns the description of the specified authorization rule description for the given topic.

## SYNTAX

```
Get-AzureRmServiceBusTopicAuthorizationRule [-ResourceGroup] <String> [-NamespaceName] <String>
 [-TopicName] <String> [[-AuthorizationRuleName] <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmServiceBusTopicAuthorizationRule** cmdlet gets the description of the specified authorization rule on the given Service Bus topic.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmServiceBusTopicAuthorizationRule -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -TopicName SB-Topic_example1 -AuthorizationRuleName SBTopicAuthoRule1
```

Returns the description of the specified authorization rule for the given topic.

## PARAMETERS

### -AuthorizationRuleName
The topic authorization rule name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

-ResourceGroup : System.String
-NamespaceName : System.String
-TopicName : System.String
-AuthorizationRuleName : System.String

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.ServiceBus.Models.SharedAccessAuthorizationRuleAttributes, Microsoft.Azure.Commands.ServiceBus, Version=0.0.1.0, Culture=neutral, PublicKeyToken=null]]

Id       : /subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.ServiceBus/namespaces/SB-Example1/topics/SB-Topic_example1/authorizati
           onRules/SBTopicAuthoRule1
Type     : Microsoft.ServiceBus/AuthorizationRules
Name     : SBTopicAuthoRule1
Location : West US
Tags     : 
Rights   : {Listen, Send}


## NOTES

## RELATED LINKS

