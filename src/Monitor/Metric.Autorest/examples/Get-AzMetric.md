### Example 1: List the metric data for a subscription
```powershell
Get-AzMetric -Region eastus -Aggregation count -AutoAdjustTimegrain -Filter "LUN eq '0' and Microsoft.ResourceId eq '*'" -Interval "PT6H" -MetricName "Data Disk Max Burst IOPS" -MetricNamespace "microsoft.compute/virtualmachines" -Orderby "count desc" -Rollupby "LUN" -StartTime "2023-12-08T19:00:00Z" -EndTime "2023-12-12T01:00:00Z" -Top 10
```

```output
Cost           : 2375
Interval       : PT6H
Namespace      : microsoft.compute/virtualmachines
Resourceregion : eastus
Timespan       : 2023-12-10T09:23:01Z/2023-12-12T01:00:00Z
Value          : {{
                   "name": {
                     "value": "Data Disk Max Burst IOPS",
                     "localizedValue": "Data Disk Max Burst IOPS"
                   },
                   "id": "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Insights/metrics/Data Disk Max Burst IOPS",
                   "type": "Microsoft.Insights/metrics",
                   "displayDescription": "Maximum IOPS Data Disk can achieve with bursting",
                   "errorCode": "Success",
                   "unit": "Count",
                   "timeseries": [ ]
                 }}
```

This command lists the metric data for a subscription.

### Example 2: List the metric values for a specified resource URI
```powershell
Get-AzMetric -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281/blobServices/default -Aggregation "average,minimum,maximum" -AutoAdjustTimegrain -Filter "Tier eq '*'" -Interval "PT6H" -MetricName "BlobCount,BlobCapacity" -MetricNamespace "Microsoft.Storage/storageAccounts/blobServices" -Orderby "average asc" -StartTime "2024-03-10T09:00:00Z" -EndTime "2024-03-10T14:00:00Z" -Top 1
```

```output
Cost           : 598
Interval       : PT1H
Namespace      : Microsoft.Storage/storageAccounts/blobServices
Resourceregion : eastus2euap
Timespan       : 2024-03-10T09:00:00Z/2024-03-10T14:00:00Z
Value          : {{
                   "name": {
                     "value": "BlobCount",
                     "localizedValue": "Blob Count"
                   },
                   "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281/blobServices/de 
                 fault/providers/Microsoft.Insights/metrics/BlobCount",
                   "type": "Microsoft.Insights/metrics",
                   "displayDescription": "The number of blob objects stored in the storage account.",
                   "errorCode": "Success",
                   "unit": "Count",
                   "timeseries": [
                     {
                       "metadatavalues": [
                         {
                           "name": {
                             "value": "tier",
                             "localizedValue": "tier"
                           },
                           "value": "Standard"
                         }
                       ],
                       "data": [
                         {
                           "timeStamp": "2024-03-10T09:00:00.0000000Z",
                           "average": 0,
                           "minimum": 0,
                           "maximum": 0
                         },
                         {
                           "timeStamp": "2024-03-10T10:00:00.0000000Z",
                           "average": 0,
                           "minimum": 0,
                           "maximum": 0
                         },
                         {
                           "timeStamp": "2024-03-10T11:00:00.0000000Z",
                           "average": 0,
                           "minimum": 0,
                           "maximum": 0
                         },
                         {
                           "timeStamp": "2024-03-10T12:00:00.0000000Z",
                           "average": 0,
                           "minimum": 0,
                           "maximum": 0
                         },
                         {
                           "timeStamp": "2024-03-10T13:00:00.0000000Z",
                           "average": 0,
                           "minimum": 0,
                           "maximum": 0
                         }
                       ]
                     }
                   ]
                 }, {
                   "name": {
                     "value": "BlobCapacity",
                     "localizedValue": "Blob Capacity"
                   },
                   "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281/blobServices/de 
                 fault/providers/Microsoft.Insights/metrics/BlobCapacity",
                   "type": "Microsoft.Insights/metrics",
                   "displayDescription": "The amount of storage used by the storage account\u0027s Blob service in bytes.",
                   "errorCode": "Success",
                   "unit": "Bytes",
                   "timeseries": [
                     {
                       "metadatavalues": [
                         {
                           "name": {
                             "value": "tier",
                             "localizedValue": "tier"
                           },
                           "value": "Premium"
                         }
                       ],
                       "data": [
                         {
                           "timeStamp": "2024-03-10T09:00:00.0000000Z",
                           "average": 0,
                           "minimum": 0,
                           "maximum": 0
                         },
                         {
                           "timeStamp": "2024-03-10T10:00:00.0000000Z",
                           "average": 0,
                           "minimum": 0,
                           "maximum": 0
                         },
                         {
                           "timeStamp": "2024-03-10T11:00:00.0000000Z",
                           "average": 0,
                           "minimum": 0,
                           "maximum": 0
                         },
                         {
                           "timeStamp": "2024-03-10T12:00:00.0000000Z",
                           "average": 0,
                           "minimum": 0,
                           "maximum": 0
                         },
                         {
                           "timeStamp": "2024-03-10T13:00:00.0000000Z",
                           "average": 0,
                           "minimum": 0,
                           "maximum": 0
                         }
                       ]
                     }
                   ]
                 }}
```

This command lists the metric values for a specified resource URI.

