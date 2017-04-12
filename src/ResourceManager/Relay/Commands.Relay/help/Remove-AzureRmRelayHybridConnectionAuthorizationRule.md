---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmRelayHybridConnectionAuthorizationRule

## SYNOPSIS
Removes the authorization rule of a HybridConnection from the specified Relay namespace.

## SYNTAX

```
Remove-AzureRmRelayHybridConnectionAuthorizationRule [-ResourceGroupName] <String> [-NamespaceName] <String>
 [-HybridConnectionsName] <String> [-AuthorizationRuleName] <String> [-WhatIf] [-Confirm]
```

## DESCRIPTION
The **Remove-AzureRmRelayHybridConnectionAuthorizationRule** cmdlet removes the authorization rule of a HybridConnection from the specified Relay namespace.

## EXAMPLES

### Example 1
```
PS C:\> Remove-AzureRmRelayHybridConnectionAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -HybridConnectionsName TestHybridConnection
```

Removes the authorization rule `AuthoRule1` of the HybridConnection `TestHybridConnection` from the namespace `TestNameSpace-Relay1`.

## PARAMETERS

### -AuthorizationRuleName
HybridConnections AuthorizationRule Name.

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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

