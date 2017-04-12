---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmWcfRelayKey

## SYNOPSIS
Gets the primary and secondary connection strings for the given WcfRelay.

## SYNTAX

```
Get-AzureRmWcfRelayKey [-ResourceGroupName] <String> [-NamespaceName] <String> [-WcfRelayName] <String>
 [-AuthorizationRuleName] <String>
```

## DESCRIPTION
The **Get-AzureRmWcfRelayKey** cmdlet returns the primary and secondary connection strings for the given WcfRelay.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmWcfRelayKey -ResourceGroup Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -WcfRelayName TestWCFRelay1 -AuthorizationRuleName AuthoRule1
```

Returns the primary and secondary connection strings for the specified WcfRelay.

## PARAMETERS

### -AuthorizationRuleName
WcfRelay AuthorizationRule Name.

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