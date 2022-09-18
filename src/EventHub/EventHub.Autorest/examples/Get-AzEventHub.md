### Example 1: Get an EventHub entity
```powershell
Get-AzEventHub -ResourceGroupName {resourceGroup} -NamespaceName {namespace} -Name {eventhub}
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
Id                           : /subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.EventHub/namespaces/{namespace}/eventhubs/{eventhub}
IntervalInSeconds            :
Location                     : australiaeast
MessageRetentionInDays       : 1
Name                         : {eventhub}
PartitionCount               : 1
PartitionId                  : {0}
ResourceGroupName            : {resourceGroup}
SizeLimitInBytes             :
SkipEmptyArchive             :
Status                       : Active
StorageAccountResourceId     :
```

### Example 2: List All EventHubs in a namespace
```powershell
Get-AzEventHub -ResourceGroupName {resourceGroup} -NamespaceName {namespace
```
