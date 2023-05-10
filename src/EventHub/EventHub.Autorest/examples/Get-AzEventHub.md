### Example 1: Get an EventHub entity
```powershell
Get-AzEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myEventHub
```

```output
ArchiveNameFormat            :
BlobContainer                :
CaptureEnabled               :
CreatedAt                    : 9/13/2022 9:20:38 AM
DataLakeAccountName          :
DataLakeFolderPath           :
DataLakeSubscriptionId       :
DestinationName              :
Encoding                     :
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace/eventhubs/myEventHub
IntervalInSeconds            :
Location                     : australiaeast
MessageRetentionInDays       : 1
Name                         : myEventHub
PartitionCount               : 1
PartitionId                  : {0}
ResourceGroupName            : myResourceGroup
SizeLimitInBytes             :
SkipEmptyArchive             :
Status                       : Active
StorageAccountResourceId     :
```

Gets details of eventhub entity `myEventHub` from namespace `myNamespace`.

### Example 2: List All EventHubs in a namespace
```powershell
Get-AzEventHub -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all EventHub entities from namespace `myNamespace`.