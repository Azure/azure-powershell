---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmEventHub

## SYNOPSIS
Creates a new Event Hub.

## SYNTAX

```
New-AzureRmEventHub [-ResourceGroupName] <String> [-NamespaceName] <String> [-Location] <String>
 [-EventHubName] <String> [-EventHubObj <EventHubAttributes>] [-MessageRetentionInDays <Int64>]
 [-PartitionCount <Int64>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmEventHub** cmdlet creates a new Azure Event Hub.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmEventHubNamespace -ResourceGroupName MyResourceGroupName -NamespaceName MyNamespaceName -Location WestUS -EventHubName MyEventHubName -MessageRetentionInDays 3 -PartitionCount 2
```

Creates an Event Hub named `MyEventHubName` with a 3-day message retention period and two partitions, in the `WestUS` location, with resource group `MyResourceGroupName`.

## PARAMETERS

### -EventHubName
The Event Hub name.

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

### -EventHubObj
The Event Hubs object.

```yaml
Type: EventHubAttributes
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Namespace geographic location.

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

### -MessageRetentionInDays
Event Hubs message retention time in days.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
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

### -PartitionCount
Number of partitions in the Event Hub.

```yaml
Type: Int64
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.EventHubAttributes

## NOTES

## RELATED LINKS

