---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmWcfRelayKey

## SYNOPSIS
Regenerates the primary or secondary connection strings for the WcfRelay.

## SYNTAX

```
New-AzureRmWcfRelayKey [-ResourceGroup] <String> [-NamespaceName] <String> [-WcfRelayName] <String>
 [-AuthorizationRuleName] <String> -RegenerateKey <String> [-WhatIf] [-Confirm]
```

## DESCRIPTION
The **New-AzureRmWcfRelayKey** cmdlet regenerates the primary or secondary connection strings for the specified WcfRelay and authorization rule.

## EXAMPLES

### Example 1
```
PS C:\>New-AzureRmWcfRelayKey -ResourceGroup Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -WcfRelayName TestWCFRelay1 -AuthorizationRuleName AuthoRule1 -RegenerateKey PrimaryKey
```
Regenerates the primary connection string for the namespace.

### Example 2
```
PS C:\>New-AzureRmWcfRelayKey -ResourceGroup Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -WcfRelayName TestWCFRelay1 -AuthorizationRuleName AuthoRule1 -RegenerateKey SecondaryKey
```
Regenerates the Secondary connection string for the namespace.

## PARAMETERS

### -AuthorizationRuleName
Authorization Rule Name.

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

### -RegenerateKey
Regenerate Keys - 'PrimaryKey'/'SecondaryKey'.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: PrimaryKey, SecondaryKey

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -RegenerateKeys
 System.String

## OUTPUTS
### Microsoft.Azure.Commands.Relay.Models.AuthorizationRuleKeysAttributes

PrimaryConnectionString   : Endpoint=sb://testnamespace-relay1.servicebus.windows.net/;SharedAccessKeyName=AuthoRule1;SharedAccessKey=############################################;Ent
                            ityPath=TestWCFRelay1
SecondaryConnectionString : Endpoint=sb://testnamespace-relay1.servicebus.windows.net/;SharedAccessKeyName=AuthoRule1;SharedAccessKey=############################################;Ent
                            ityPath=TestWCFRelay1
PrimaryKey                : ############################################
SecondaryKey              : ############################################
KeyName                   : AuthoRule1

## NOTES

## RELATED LINKS

