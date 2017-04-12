---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmRelayHybridConnectionAuthorizationRule

## SYNOPSIS
Gets the description of a specified authorization rule for a given HybridConnection.

## SYNTAX

```
Get-AzureRmRelayHybridConnectionAuthorizationRule [-ResourceGroupName] <String> [-NamespaceName] <String>
 [-HybridConnectionsName] <String> [[-AuthorizationRuleName] <String>]
```

## DESCRIPTION
The **Get-AzureRmRelayHybridConnectionAuthorizationRule** cmdlet gets the description of a specified authorization rule on the given HybridConnection.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmRelayHybridConnectionAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -HybridConnectionsName TestHybridConnection
```

Returns the specified authorization rule description for a given HybridConnection.

## PARAMETERS

### -AuthorizationRuleName
HybridConnections AuthorizationRule Name.

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

### -HybridConnectionsName
HybridConnections Name.

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
### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### -ResourceGroupName
 System.String 

### -NamespaceName
 System.String 
 
### -HybridConnectionsName
 System.String 

### -AuthorizationRuleName
 System.String

## OUTPUTS
### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Relay.Models.AuthorizationRuleAttributes, Microsoft.Azure.Commands.Relay, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null]]

Rights : {Listen, Send}
Name   : AuthoRule1
Type   : Microsoft.Relay/AuthorizationRules
Id     : /subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.Relay/namespaces/TestNameSpace-Relay1/HybridConnections/Test
         HybridConnection/authorizationRules/AuthoRule1

## NOTES

## RELATED LINKS

