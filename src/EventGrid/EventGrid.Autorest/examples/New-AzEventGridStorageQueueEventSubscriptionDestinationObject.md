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