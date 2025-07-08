### Example 1: Get ingress and egress from storage account
```powershell
$endpoint = 'https://eastus.metrics.monitor.azure.com'
$start = "2023-12-06T07:00:00.000Z"
$end = "2023-12-06T08:00:00.000Z"
Get-AzMetricsBatch -Endpoint $endpoint -Name 'ingress','egress' -Namespace "Microsoft.Storage/storageAccounts" -EndTime $end -StartTime $start -ResourceId '/subscriptions/{subid}/resourcegroups/{groupname}/providers/Microsoft.Storage/storageAccounts/{account}'
```

```output
Endtime        : 2023-12-06T08:00:00Z
Interval       : 00:01:00a
Namespace      : Microsoft.Storage/storageAccounts
Resourceid     : /subscriptions/subid/resourcegroups/groupname/providers/Microsoft.Storage/storageAccounts/account
Resourceregion : eastus
Starttime      : 2023-12-06T07:00:00Z
Value          : {{
                   "name": {
                     "value": "Ingress",
                     "localizedValue": "Ingress"
                   },
                   "id": "/subscriptions/subid/resourcegroups/groupname/providers/Microsoft.Storage/storageAccounts/account/providers/Microsoft.Insights/metrics/Ingress",
                   "type": "Microsoft.Insights/metrics",
                   "displayDescription": "The amount of ingress data, in bytes. This number includes ingress from an external client into Azure Storage as well as ingress within Azure.",   
                   "errorCode": "Success",
                   "unit": "Bytes",
                   "timeseries": [
                     {
                       "metadatavalues": [ ],
                       "data": [
                         {
                           "timeStamp": "2023-12-06T07:00:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:01:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:59:00.0000000Z",
                           "total": 0
                         }
                       ]
                     }
                   ]
                 }, {
                   "name": {
                     "value": "Egress",
                     "localizedValue": "Egress"
                   },
                   "id": "/subscriptions/subid/resourcegroups/groupname/providers/Microsoft.Storage/storageAccounts/account/providers/Microsoft.Insights/metrics/Egress",
                   "type": "Microsoft.Insights/metrics",
                   "displayDescription": "The amount of egress data. This number includes egress to external client from Azure Storage as well as egress within Azure. As a result, this     
                 number does not reflect billable egress.",
                   "errorCode": "Success",
                   "unit": "Bytes",
                   "timeseries": [
                     {
                       "metadatavalues": [ ],
                       "data": [
                         {
                           "timeStamp": "2023-12-06T07:00:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:01:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:59:00.0000000Z",
                           "total": 0
                         }
                       ]
                     }
                   ]
                 }}
```

This command lists the metric values for specified resources. Example deleted data of long time series.

