### Example 1: Create an EventHub entity
```powershell
New-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -RetentionTimeInHour 168 -PartitionCount 5 -CleanupPolicy Delete
```

```output
ArchiveNameFormat            :
BlobContainer                :
CaptureEnabled               :
CleanupPolicy                : Delete
CreatedAt                    : 4/25/2023 3:55:45 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              :
Encoding                     :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub
IntervalInSeconds            :
Location                     : eastus
MessageRetentionInDay        : 7
Name                         : myEventHub
PartitionCount               : 5
PartitionId                  : {0, 1, 2, 3…}
ResourceGroupName            : myResourceGroup
RetentionTimeInHour          : 168
SizeLimitInBytes             :
SkipEmptyArchive             :
Status                       : Active
StorageAccountResourceId     :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TombstoneRetentionTimeInHour :
Type                         : Microsoft.EventHub/namespaces/eventhubs
UpdatedAt                    : 4/25/2023 3:55:46 AM
```


Creates a new eventhub entity `myEventHub` on namespace `myNamespace` with CleaupPolicy `Delete`.

### Example 2: Create EventHub with Capture Enabled
```powershell
New-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer container -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId "/subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount -CleanupPolicy Delete"
```

```output
ArchiveNameFormat            : {Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}
BlobContainer                : container
CaptureEnabled               : true
CreatedAt                    : 9/1/2022 5:55:46 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              :
Encoding                     : Avro
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myFirstEventHub
IntervalInSeconds            : 600
Location                     : centralus
MessageRetentionInDays       : 6
Name                         : myFirstEventHub
PartitionCount               : 5
PartitionId                  : {0}
ResourceGroupName            : myResourceGroup
RetentionTimeInHour          : 24
SizeLimitInBytes             : 11000000
SkipEmptyArchive             : true
Status                       : Active
```

Creates a new eventhub entity `myEventHub` on namespace `myNamespace` with capture enabled.

### Example 3: Create an EventHub entity
```powershell
New-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -CleanupPolicy Compact
```

```output
ArchiveNameFormat            :
BlobContainer                :
CaptureEnabled               :
CleanupPolicy                : Compact
CreatedAt                    : 4/25/2023 4:05:57 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              :
Encoding                     :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub
IntervalInSeconds            :
Location                     : eastus
MessageRetentionInDay        : 9223372036854775807
Name                         : myEventHub
PartitionCount               : 4
PartitionId                  : {0, 1, 2, 3}
ResourceGroupName            : myResourceGroup
RetentionTimeInHour          :
SizeLimitInBytes             :
SkipEmptyArchive             :
Status                       : Active
StorageAccountResourceId     :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TombstoneRetentionTimeInHour :
Type                         : Microsoft.EventHub/namespaces/eventhubs
UpdatedAt                    : 4/25/2023 4:05:58 AM
```

Creates a new eventhub entity `myEventHub` on namespace `myNamespace` with CleaupPolicy `Compact`.
