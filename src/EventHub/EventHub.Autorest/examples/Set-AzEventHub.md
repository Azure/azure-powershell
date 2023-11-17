### Example 1: Set capture on an existing EventHub entity
```powershell
Set-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer container -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId "/subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount"
```

```output
ArchiveNameFormat            : {Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}
BlobContainer                : container
CaptureEnabled               : True
CleanupPolicy                : Delete
CreatedAt                    : 1/1/0001 12:00:00 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              : EventHubArchive.AzureBlockBlob
Encoding                     : Avro
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/namespace3/eventhubs/myEventHub
IntervalInSeconds            : 600
Location                     : eastus
MessageRetentionInDay        : 7
Name                         : myEventHub
PartitionCount               : 5
PartitionId                  : {}
ResourceGroupName            : myResourceGroup
RetentionTimeInHour          : 168
SizeLimitInBytes             : 11000000
SkipEmptyArchive             : True
Status                       : Active
StorageAccountResourceId     : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TombstoneRetentionTimeInHour :
Type                         : Microsoft.EventHub/namespaces/eventhubs
UpdatedAt                    : 1/1/0001 12:00:00 AM
```

Updates EventHub entity `myEventHub` from namespace `myNamespace` to enable capture on it.

### Example 2: Update EventHub EventHub entity using InputObject parameter set
```powershell
$eventhub = Get-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace
Set-AzEventHub -InputObject $eventhub -RetentionTimeInHour 72
```

```output
ArchiveNameFormat            : {Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}
BlobContainer                : container1entHub]>
CaptureEnabled               : True
CleanupPolicy                : Delete
CreatedAt                    : 1/1/0001 12:00:00 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              : EventHubArchive.AzureBlockBlob
Encoding                     : Avro
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub
IntervalInSeconds            : 600
Location                     : eastus
MessageRetentionInDay        : 3
Name                         : myEventHub
PartitionCount               : 5
PartitionId                  : {}
ResourceGroupName            : myResourceGroup
RetentionTimeInHour          : 72
SizeLimitInBytes             : 11000000
SkipEmptyArchive             : True
Status                       : Active
StorageAccountResourceId     : /subscriptions/subscriptionId/resourceGroups/myResourcegroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount
                               1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TombstoneRetentionTimeInHour :
Type                         : Microsoft.EventHub/namespaces/eventhubs
UpdatedAt                    : 1/1/0001 12:00:00 AM
```

Updates `RetentionTimeInHour` in EventHub entity `myEventHub` to 72 hours.
