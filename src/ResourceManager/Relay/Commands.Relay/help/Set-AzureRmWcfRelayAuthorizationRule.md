---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmWcfRelayAuthorizationRule

## SYNOPSIS
Updates the specified authorization rule description for the given WcfRelay.

## SYNTAX

```
Set-AzureRmWcfRelayAuthorizationRule [-ResourceGroupName] <String> [-NamespaceName] <String>
 [-WcfRelayName] <String> [-AuthRuleObj] <AuthorizationRuleAttributes> [-AuthorizationRuleName] <String>
 [-Rights <String[]>] [-WhatIf] [-Confirm]
```

## DESCRIPTION
The **Set-AzureRmWcfRelayAuthorizationRule** cmdlet updates the description for the specified authorization rule of the given WcfRelay.

## EXAMPLES

### Example 1
```
PS C:\> $getWcfRelayAutho = Get-AzureRmWcfRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -WcfRelayName TestWCFRe
lay1 -AuthorizationRuleName AuthoRule1
PS C:\> $getWcfRelayAutho.Rights.Add("Manage")
PS C:\> Set-AzureRmWcfRelayAuthorizationRule -ResourceGroupName Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -WcfRelayName TestWCFRelay1 -AuthorizationR
uleName AuthoRule1 -AuthRuleObj $getWcfRelayAutho
```

Adds **Manage** to the access rights of the authorization rule `AuthoRule1` of the WcfRelay `TestWCFRelay1`.

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

### -AuthRuleObj
WcfRelay AuthorizationRule Object.

```yaml
Type: AuthorizationRuleAttributes
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
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
Required if 'AuthruleObj' not specified.
Rights - e.g. 
@("Listen","Send","Manage")

```yaml
Type: String[]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WcfRelayName
WcfRelay Name.

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

### -ResourceGroupName
 System.String 

### -NamespaceName
 System.String 
 
### -WcfRelayName
 System.String 

### -AuthorizationRuleName
 System.String

### -AuthRuleObj
 Microsoft.Azure.Commands.Relay.Models.AuthorizationRuleAttributes
 
## OUTPUTS
### Microsoft.Azure.Commands.Relay.Models.AuthorizationRuleAttributes

Rights : {Listen, Send, Manage}
Name   : AuthoRule1
Type   : Microsoft.Relay/AuthorizationRules
Id     : /subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.Relay/namespaces/TestNameSpace-Relay1/WcfRelays/TestWCFRelay
         1/authorizationRules/AuthoRule1

## NOTES

## RELATED LINKS

