---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmRelayHybridConnectionAuthorizationRule

## SYNOPSIS
Creates a new authorization rule for the specified HybridConnection .

## SYNTAX

```
New-AzureRmRelayHybridConnectionAuthorizationRule [-ResourceGroupName] <String> [-NamespaceName] <String>
 [-HybridConnectionsName] <String> [-AuthorizationRuleName] <String> -Rights <String[]> [-WhatIf] [-Confirm]
```

## DESCRIPTION
The **New-AzureRmRelayHybridConnectionAuthorizationRule** cmdlet creates a new authorization rule for the specified HybridConnection.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmRelayHybridConnectionAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -HybridConnectionsName TestHybridConnection -AuthorizationRuleName AuthoRule1 -Rights @("Listen","Send")
```

Creates authorization rule `AuthoRule1` with **Listen and Send** rights for the HybridConnection `TestHybridConnection`.

## PARAMETERS

### -AuthorizationRuleName
AuthorizationRule Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
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

### -Rights
Rights, e.g. 
@("Listen","Send","Manage")

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: True
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

### -ResourceGroupName
 System.String 

### -NamespaceName
 System.String 
 
### -HybridConnectionsName
 System.String 

### -AuthorizationRuleName
 System.String

### -Rights
 System.String []

## OUTPUTS
### Microsoft.Azure.Commands.Relay.Models.AuthorizationRuleAttributes

Rights : {Listen, Send}
Name   : AuthoRule1
Type   : Microsoft.Relay/AuthorizationRules
Id     : /subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.Relay/namespaces/TestNameSpace-Relay1/HybridConnections/Test
         HybridConnection/authorizationRules/AuthoRule1

## NOTES

## RELATED LINKS

