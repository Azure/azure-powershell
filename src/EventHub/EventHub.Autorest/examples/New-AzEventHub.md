### Example 1: Create an EventHub entity
```powershell
New-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -MessageRetentionInDays 6 -PartitionCount 5
```

```output
ArchiveNameFormat            :
BlobContainer                :
CaptureEnabled               :
CreatedAt                    : 9/1/2022 5:55:46 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              :
Encoding                     :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub
IntervalInSeconds            :
Location                     : centralus
MessageRetentionInDays       : 6
<<<<<<< HEAD
Name                         : myEventHub
=======
Name                         : myFirstEventHub
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
PartitionCount               : 5
PartitionId                  : {0}
ResourceGroupName            : myResourceGroup
SizeLimitInBytes             :
SkipEmptyArchive             :
Status                       : Active
```


Creates a new eventhub entity `myEventHub` on namespace `myNamespace`.

### Example 2: Create EventHub with Capture Enabled
```powershell
<<<<<<< HEAD
New-AzEventHub -Name myFirstEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer container -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId "/subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount"
=======
New-AzEventHub -Name myEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -ArchiveNameFormat "{Namespace}/{EventHub}/{PartitionId}/{Year}/{Month}/{Day}/{Hour}/{Minute}/{Second}" -BlobContainer container -CaptureEnabled -DestinationName EventHubArchive.AzureBlockBlob -Encoding Avro -IntervalInSeconds 600 -SizeLimitInBytes 11000000 -SkipEmptyArchive -StorageAccountResourceId "/subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.Storage/storageAccounts/myStorageAccount"
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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
SizeLimitInBytes             : 11000000
SkipEmptyArchive             : true
Status                       : Active
```

<<<<<<< HEAD
Creates a new eventhub entity `myFirstEventHub` on namespace `myNamespace` with capture enabled.

### Example 3: Create EventHub with Compact Cleanup Policy
```powershell
New-AzEventHub -Name myFirstEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -PartitionCount 2 -RetentionDescriptionCleanupPolicy Compact
```

```output
ArchiveNameFormat                                :
BlobContainer                                    :
CaptureEnabled                                   :
CreatedAt                                        : 1/10/2023 11:38:54 AM
DataLakeAccountName                              :
DataLakeFolderPath                               :
DataLakeSubscriptionId                           :
DestinationName                                  :
Encoding                                         :
Id                                               : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myFirstEventHub
IntervalInSeconds                                :
Location                                         : eastus
MessageRetentionInDays                           : 9223372036854775807
Name                                             : myFirstEventHub
PartitionCount                                   : 2
PartitionId                                      : {0, 1}
ResourceGroupName                                : myResourceGroup
RetentionDescriptionCleanupPolicy                : Compact
RetentionDescriptionRetentionTimeInHour          :
RetentionDescriptionTombstoneRetentionTimeInHour :
SizeLimitInBytes                                 :
SkipEmptyArchive                                 :
Status                                           : Active
StorageAccountResourceId                         :
SystemDataCreatedAt                              :
SystemDataCreatedBy                              :
SystemDataCreatedByType                          :
SystemDataLastModifiedAt                         :
SystemDataLastModifiedBy                         :
SystemDataLastModifiedByType                     :
Type                                             : Microsoft.EventHub/namespaces/eventhubs
UpdatedAt                                        : 1/10/2023 11:38:56 AM
```
Creates a new eventhub entity `myFirstEventHub` on namespace `myNamespace` with Compact Cleanup Policy.

### Example 4: Create EventHub with Delete Cleanup Policy
```powershell
New-AzEventHub -Name myFirstEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -PartitionCount 2 -RetentionDescriptionCleanupPolicy Delete
```

```output
ArchiveNameFormat                                :
BlobContainer                                    :
CaptureEnabled                                   :
CreatedAt                                        : 1/10/2023 11:38:54 AM
DataLakeAccountName                              :
DataLakeFolderPath                               :
DataLakeSubscriptionId                           :
DestinationName                                  :
Encoding                                         :
Id                                               : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myFirstEventHub
IntervalInSeconds                                :
Location                                         : eastus
MessageRetentionInDays                           : 1
Name                                             : myFirstEventHub
PartitionCount                                   : 2
PartitionId                                      : {0, 1}
ResourceGroupName                                : myResourceGroup
RetentionDescriptionCleanupPolicy                : Delete
RetentionDescriptionRetentionTimeInHour          :
RetentionDescriptionTombstoneRetentionTimeInHour :
SizeLimitInBytes                                 :
SkipEmptyArchive                                 :
Status                                           : Active
StorageAccountResourceId                         :
SystemDataCreatedAt                              :
SystemDataCreatedBy                              :
SystemDataCreatedByType                          :
SystemDataLastModifiedAt                         :
SystemDataLastModifiedBy                         :
SystemDataLastModifiedByType                     :
Type                                             : Microsoft.EventHub/namespaces/eventhubs
UpdatedAt                                        : 1/10/2023 11:38:56 AM
```
Creates a new eventhub entity `myFirstEventHub` on namespace `myNamespace` with Delete Cleanup Policy.
=======
Creates a new eventhub entity `myEventHub` on namespace `myNamespace` with capture enabled.
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
