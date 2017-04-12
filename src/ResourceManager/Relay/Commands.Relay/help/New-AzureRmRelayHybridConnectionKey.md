---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmRelayHybridConnectionKey

## SYNOPSIS
Regenerates the primary or secondary connection strings for the HybridConnection.

## SYNTAX

```
New-AzureRmRelayHybridConnectionKey [-ResourceGroup] <String> [-NamespaceName] <String>
 [-HybridConnectionsName] <String> [-AuthorizationRuleName] <String> -RegenerateKey <String> [-WhatIf]
 [-Confirm]
```

## DESCRIPTION
The **New-AzureRmRelayHybridConnectionKey** cmdlet regenerates the primary or secondary connection strings for the specified HybridConnection and authorization rule.

## EXAMPLES

### Example 1

```
PS C:\>New-AzureRmRelayHybridConnectionKey -ResourceGroup Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -HybridConnectionsName TestHybridConnection -AuthorizationRuleName AuthoRule1 -RegenerateKey PrimaryKey
```

Regenerates the Primary connection string for the namespace.

```
PS C:\>New-AzureRmRelayHybridConnectionKey -ResourceGroup Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -HybridConnectionsName TestHybridConnection -AuthorizationRuleName AuthoRule1 -RegenerateKey SecondaryKey
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

## INPUTS

### System.String

## OUTPUTS
### Microsoft.Azure.Commands.Relay.Models.AuthorizationRuleKeysAttributes

PrimaryConnectionString   : Endpoint=sb://testnamespace-relay1.servicebus.windows.net/;SharedAccessKeyName=AuthoRule1;SharedAccessKey=############################################;Ent
                            ityPath=TestHybridConnection
SecondaryConnectionString : Endpoint=sb://testnamespace-relay1.servicebus.windows.net/;SharedAccessKeyName=AuthoRule1;SharedAccessKey=############################################;Ent
                            ityPath=TestHybridConnection
PrimaryKey                : ############################################
SecondaryKey              : ############################################
KeyName                   : AuthoRule1

## NOTES

## RELATED LINKS

