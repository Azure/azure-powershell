---
external help file: Az.EventGrid-help.xml
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

### Example 1: Create an in-memory object for StorageQueueEventSubscriptionDestination.
```powershell
New-AzEventGridStorageQueueEventSubscriptionDestinationObject -QueueMessageTimeToLiveInSecond 7 -QueueName testQueue -ResourceId "/subscriptions/{subId}/resourceGroups/azps_test_group_eventgrid/providers/Microsoft.Storage/storageAccounts/azpssa"
```

```output
EndpointType
------------
StorageQueue
```

Create an in-memory object for StorageQueueEventSubscriptionDestination.

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
