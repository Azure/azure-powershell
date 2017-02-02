---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmServiceBusQueueKey

## SYNOPSIS
Gets the primary and secondary connection strings for the given Service Bus queue.

## SYNTAX

```
Get-AzureRmServiceBusQueueKey [-ResourceGroup] <String> [-NamespaceName] <String> [-QueueName] <String>
 [-AuthorizationRuleName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmServiceBusQueueKey** cmdlet returns the primary and secondary connection strings for the given Service Bus queue. 

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmServiceBusQueueKey -ResourceGroup Default-ServiceBus-WestUS -NamespaceName SB-Example1 -QueueName SB-Queue_exampl1 -AuthorizationRuleName SBAuthoRule1
```

The primary and secondary connection strings are returned for the given Service Bus queue.

## PARAMETERS

### -AuthorizationRuleName
The queue authorization rule name.

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

### -QueueName
The Service Bus queue name.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

###-ResourceGroup
 System.String
 
###-NamespaceName
 System.String
 
###-QueueName
 System.String
 
###-AuthorizationRuleName
 System.String

## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.ListKeysAttributes

PrimaryConnectionString   : Endpoint=sb://sb-example1.servicebus.windows.net/;SharedAccessKeyName=SBAuthoRule1;SharedAccessKey=g6DJcu86tcYnKiLUZ2rSsxZUK0AfDmzfIr/VVpaYH2c=;EntityPath=SB-Queue_e
                            xampl1
SecondaryConnectionString : Endpoint=sb://sb-example1.servicebus.windows.net/;SharedAccessKeyName=SBAuthoRule1;SharedAccessKey=7JoY2k/4yc99TFlh0j5JrRMaWNhk5bJUmK0f2gcCWYw=;EntityPath=SB-Queue_e
                            xampl1
PrimaryKey                : g6DJcu86tcYnKiLUZ2rSsxZUK0AfDmzfIr/VVpaYH2c=
SecondaryKey              : 7JoY2k/4yc99TFlh0j5JrRMaWNhk5bJUmK0f2gcCWYw=
KeyName                   : SBAuthoRule1

## NOTES

## RELATED LINKS

