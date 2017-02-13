---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmEventHubConsumerGroup

## SYNOPSIS
Gets the details of a specified Event Hubs consumer group, or gets a list of consumer groups in an Event Hub.

## SYNTAX

```
Get-AzureRmEventHubConsumerGroup [-ResourceGroupName] <String> [-NamespaceName] <String>
 [-EventHubName] <String> [[-ConsumerGroupName] <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmEventHubConsumerGroup** cmdlet gets either the details of a specified Event Hubs consumer group, or a list of consumer groups in a given Event Hub. If the name of a consumer group is provided, the details of a single consumer group details are returned. If the name of a consumer group is not provided, a list of consumer groups in the specified Event Hub is returned.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventHubConsumerGroup -ResourceGroupName MyResourceGroupName -NamespaceName MyNamespaceName -EventHubName MyEventHubName -ConsumerGroupName MyConsumerGroupName
```

Gets the consumer group `MyConsumerGroupName` in the Event Hub `MyEventHubName`, which exists in the namespace `MyNamespaceName` with resource group `MyResourceGroupName`.

### Example 2
```
PS C:\> Get-AzureRmEventHubConsumerGroup -ResourceGroupName MyResourceGroupName -NamespaceName MyNamespaceName -EventHubName MyEventHubName
```

Gets a list of consumer groups in the Event Hub `MyEventHubName`, which exists in the namespace `MyNamespaceName` with resource group `MyResourceGroupName`.

## PARAMETERS

### -ConsumerGroupName
The specified consumer group name.

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

### -EventHubName
The Event Hub name.

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
The Event Hubs namespace name.

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
Resource group name.

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

### System.String

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.EventHub.Models.ConsumerGroupAttributes, Microsoft.Azure.Commands.EventHub, Version=0.0.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

