---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridstoragequeueeventsubscriptiondestinationobject
schema: 2.0.0
---

# New-AzEventGridStorageQueueEventSubscriptionDestinationObject

## SYNOPSIS
Create an in-memory object for StorageQueueEventSubscriptionDestination.

## SYNTAX

```
New-AzEventGridStorageQueueEventSubscriptionDestinationObject [-QueueMessageTimeToLiveInSecond <Int64>]
 [-QueueName <String>] [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StorageQueueEventSubscriptionDestination.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -QueueMessageTimeToLiveInSecond
Storage queue message time to live in seconds.
This value cannot be zero or negative with the exception of using -1 to indicate that the Time To Live of the message is Infinite.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueueName
The name of the Storage queue under a storage account that is the destination of an event subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Azure Resource ID of the storage account that contains the queue that is the destination of an event subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.StorageQueueEventSubscriptionDestination

## NOTES

## RELATED LINKS

