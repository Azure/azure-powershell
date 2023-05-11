### Example 1: Get an EventHub entity
```powershell
Get-AzEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myEventHub
```

```output
ArchiveNameFormat            : Active
BlobContainer                :
CaptureEnabled               :
CleanupPolicy                : Compact
CreatedAt                    : 4/25/2023 4:05:57 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              :
Encoding                     : Microsoft.EventHub/namespaces/eventhubs
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub
IntervalInSeconds            : est [Az.EventHub]>
Location                     : eastus
MessageRetentionInDay        : 9223372036854775807
Name                         : myEventntHub
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

Gets details of eventhub entity `myEventHub` from namespace `myNamespace`.

### Example 2: List All EventHubs in a namespace
```powershell
Get-AzEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all EventHub entities from namespace `myNamespace`.