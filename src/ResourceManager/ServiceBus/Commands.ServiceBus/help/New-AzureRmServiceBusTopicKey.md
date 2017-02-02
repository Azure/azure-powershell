---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmServiceBusTopicKey

## SYNOPSIS
Regenerates the primary or secondary connection strings for the Service Bus topic.

## SYNTAX

```
New-AzureRmServiceBusTopicKey [-ResourceGroup] <String> [-NamespaceName] <String> [-TopicName] <String>
 [-AuthorizationRuleName] <String> [-RegenerateKeys] <String> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmServiceBusTopicKey** cmdlet regenerates a new  primary or secondary connection string for the specified Service Bus topic and authorization rule.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmServiceBusTopicKey -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -TopicName SB-Topic_exampl1 -AuthorizationRuleName SBTopicAuthoRule1 -RegenerateKeys PrimaryKey
```

Regenerates the primary connection string for the namespace.

### Example 2
```
PS C:\> New-AzureRmServiceBusTopicKey -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -TopicName SB-Topic_exampl1 -AuthorizationRuleName SBTopicAuthoRule1 -RegenerateKeys SecondaryKey
```

Regenerates the secondary connection string for the namespace.


## PARAMETERS

### -AuthorizationRuleName
The authorization rule name.

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

### -RegenerateKeys
Specifies whether to regenerate the primary or secondary keys.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: PrimaryKey, SecondaryKey

Required: True
Position: 4
Default value: None
Accept pipeline input: False
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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

-ResourceGroup : System.String
-NamespaceName : System.String
-AuthorizationRuleName : System.String
-TopicName : System.String
-RegenerateKeys : System.String

## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.ListKeysAttributes

PrimaryConnectionString   : Endpoint=sb://sb-example1.servicebus.windows.net/;SharedAccessKeyName=SBTopicAuthoRule1;SharedAccessKey=Yc+gDnGOLNMTR1RFZXtzhy9BxBp+6/ZMNCsKcQNE7Z0=;EntityPath=SB-Topi
                            c_exampl1
SecondaryConnectionString : Endpoint=sb://sb-example1.servicebus.windows.net/;SharedAccessKeyName=SBTopicAuthoRule1;SharedAccessKey=E/k/LwYrPVgY0RIx/GWJfTzpvgaUBfMweJJceQcvk3M=;EntityPath=SB-Topi
                            c_exampl1
PrimaryKey                : Yc+gDnGOLNMTR1RFZXtzhy9BxBp+6/ZMNCsKcQNE7Z0=
SecondaryKey              : E/k/LwYrPVgY0RIx/GWJfTzpvgaUBfMweJJceQcvk3M=
KeyName                   : SBTopicAuthoRule1

## NOTES

## RELATED LINKS

