### Example 1: List the metric data for a subscription
```powershell
Get-AzMetricsMetric -Region eastus -Aggregation count -AutoAdjustTimegrain -Filter "LUN eq '0' and Microsoft.ResourceId eq '*'" -Interval "PT6H" -Name "Data Disk Max Burst IOPS" -Namespace "microsoft.compute/virtualmachines" -Orderby "count desc" -Rollupby "LUN" -Timespan "2023-12-08T19:00:00Z/2023-12-12T01:00:00Z" -Top 10 
```

```output
Cost           : 4679
Interval       : PT6H
Namespace      : microsoft.compute/virtualmachines
Resourceregion : eastus
Timespan       : 2023-12-08T19:00:00Z/2023-12-12T01:00:00Z
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
Get-AzMetricsMetric -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metric/providers/Microsoft.Storage/storageAccounts/monitortestps001/blobServices/default -Aggregation "average,minimum,maximum" -AutoAdjustTimegrain -Filter "Tier eq '*'" -Interval "PT6H" -Name "BlobCount,BlobCapacity" -Namespace "Microsoft.Storage/storageAccounts/blobServices" -Orderby "average asc" -Timespan "2023-12-12T09:00:00Z/2023-12-12T14:00:00Z" -Top 5
```

```output
Cost           : 598
Interval       : PT1H
Namespace      : Microsoft.Storage/storageAccounts/blobServices
Resourceregion : eastus
Timespan       : 2023-12-12T09:00:00Z/2023-12-12T14:00:00Z
Value          : {{
                   "name": {
                     "value": "BlobCount",
                     "localizedValue": "Blob Count"
                   },
                   "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metric/providers/Microsoft.Storage/storageAccounts/monitortestps001/bl 
                 obServices/default/providers/Microsoft.Insights/metrics/BlobCount",
                   "type": "Microsoft.Insights/metrics",
                   "displayDescription": "The number of blob objects stored in the storage account.",
                   "errorCode": "Success",
                   "unit": "Count",
                   "timeseries": [ ]
                 }, {
                   "name": {
                     "value": "BlobCapacity",
                     "localizedValue": "Blob Capacity"
                   },
                   "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metric/providers/Microsoft.Storage/storageAccounts/monitortestps001/bl 
                 obServices/default/providers/Microsoft.Insights/metrics/BlobCapacity",
                   "type": "Microsoft.Insights/metrics",
                   "displayDescription": "The amount of storage used by the storage account\u0027s Blob service in bytes.",
                   "errorCode": "Success",
                   "unit": "Bytes",
                   "timeseries": [ ]
                 }}
```

This command lists the metric values for a specified resource URI.

