---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmServiceBusNamespaceKey

## SYNOPSIS
Gets the primary and secondary connection strings for the namespace.

## SYNTAX

```
Get-AzureRmServiceBusNamespaceKey [-ResourceGroup] <String> [-NamespaceName] <String>
 [-AuthorizationRuleName] <String> [<CommonParameters>]
```

## DESCRIPTION
The ** Get-AzureRmServiceBusNamespaceKey ** cmdlet returns the primary and secondary connection strings for the given namespace. 

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmServiceBusNamespaceKey -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -AuthorizationRuleName AuthoRule1
```

Primary and Secondary Connection string to the given namespace

## PARAMETERS

### -AuthorizationRuleName
ServiceBus Namespace AuthorizationRule Name.

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
ServiceBus Namespace Name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

-ResourceGroup : System.String
-NamespaceName : System.String
-AuthorizationRuleName : System.String

## OUTPUTS

### Microsoft.Azure.Management.ServiceBus.Models.ResourceListKeys

PrimaryConnectionString   : Endpoint=sb://sb-example1.servicebus.windows.net/;SharedAccessKeyName=AuthoRule1;SharedAccessKey=qg0UZch987+8/R0AiDZ5rJvxA9ZqVZfgAFBNevoxhY8=
SecondaryConnectionString : Endpoint=sb://sb-example1.servicebus.windows.net/;SharedAccessKeyName=AuthoRule1;SharedAccessKey=0Ovukkl5pzyffid7IVFPXEoXmRUXaf3hNq9dzVS89/4=
PrimaryKey                : qg0UZch987+8/R0AiDZ5rJvxA9ZqVZfgAFBNevoxhY8=
SecondaryKey              : 0Ovukkl5pzyffid7IVFPXEoXmRUXaf3hNq9dzVS89/4=
KeyName                   : AuthoRule1

## NOTES

## RELATED LINKS

