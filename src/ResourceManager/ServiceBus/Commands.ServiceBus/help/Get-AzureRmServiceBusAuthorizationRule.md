---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmServiceBusAuthorizationRule

## SYNOPSIS
Gets a description of the specified authorization rule for a given Namespace or Queue or Topic. 

## SYNTAX

### NamespaceAuthorizationRuleSet (Default)
```
Get-AzureRmServiceBusAuthorizationRule [-ResourceGroupName] <String> [-Namespace] <String> [[-Name] <String>]
```

### QueueAuthorizationRuleSet
```
Get-AzureRmServiceBusAuthorizationRule [-ResourceGroupName] <String> [[-Namespace] <String>] [-Queue] <String>
 [[-Name] <String>]
```

### TopicAuthorizationRuleSet
```
Get-AzureRmServiceBusAuthorizationRule [-ResourceGroupName] <String> [[-Namespace] <String>] [-Topic] <String>
 [[-Name] <String>]
```

## DESCRIPTION
The **Get-AzureRmServiceBusAuthorizationRule** cmdlet gets the description of the specified authorization rule in the given Namespace or Queue or Topic.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmServiceBusAuthorizationRule -ResourceGroup Default-ServiceBus-WestUS -Namespace SB-Example1 -Name AuthoRule1
```

Returns the specified authorization rule description for a specified namespace.

### Example 2
```
PS C:\> Get-AzureRmServiceBusAuthorizationRule -ResourceGroup Default-ServiceBus-WestUS -Namespace SB-Example1 -Queue SBQueue -Name AuthoRule1
```

Returns the specified authorization rule description for a specified queue.

### Example 3
```
PS C:\> Get-AzureRmServiceBusAuthorizationRule -ResourceGroup Default-ServiceBus-WestUS -Namespace SB-Example1 -Topic SBTopic -Name AuthoRule1
```

Returns the specified authorization rule description for a specified topic.

## PARAMETERS

### -Name
AuthorizationRule Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: AuthorizationRuleName

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Namespace
Namespace Name.

```yaml
Type: String
Parameter Sets: NamespaceAuthorizationRuleSet
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: QueueAuthorizationRuleSet, TopicAuthorizationRuleSet
Aliases: NamespaceName

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Queue
Queue Name.

```yaml
Type: String
Parameter Sets: QueueAuthorizationRuleSet
Aliases: QueueName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

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

### -Topic
Topic Name.

```yaml
Type: String
Parameter Sets: TopicAuthorizationRuleSet
Aliases: TopicName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.ServiceBus.Models.SharedAccessAuthorizationRuleAttributes, Microsoft.Azure.Commands.ServiceBus, Version=0.4.2.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS