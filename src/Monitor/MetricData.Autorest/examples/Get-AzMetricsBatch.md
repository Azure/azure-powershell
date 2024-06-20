### Example 1: Get ingress and egress from storage account
```powershell
$endpoint = 'https://eastus2euap.metrics.monitor.azure.com'
$start = [DateTime]::UtcNow.ToString("O").AddHours(-2) #2024-04-08T06:45:37.1895068Z
$end = [DateTime]::UtcNow.ToString("O") #2024-04-08T08:45:54.1180593Z
Get-AzMetricsBatch -Endpoint $endpoint -Name 'ingress','egress' -Namespace Microsoft.Storage/storageAccounts -StartTime $start -EndTime $end -ResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281 -Interval PT15M
```

```output
Endtime        : 2024-04-08T08:45:54Z
Interval       : PT15M
Namespace      : Microsoft.Storage/storageAccounts
Resourceid     : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281
Resourceregion : eastus2euap
Starttime      : 2024-04-08T06:45:37Z
Value          : {{
                   "name": {
                     "value": "Ingress",
                     "localizedValue": "Ingress"
                   },
                   "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281/providers/Microsoft.Insights/metrics/Ingress",
                   "type": "Microsoft.Insights/metrics",
                   "displayDescription": "The amount of ingress data, in bytes. This number includes ingress from an external client into Azure Storage as well as ingress within Azure.",
                   "unit": "Bytes",
                   "timeseries": [
                     {
                       "metadatavalues": [ ],
                       "data": [
                         {
                           "timeStamp": "2024-04-08T06:45:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T07:00:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T07:15:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T07:30:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T07:45:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T08:00:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T08:15:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T08:30:00.0000000Z",
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
                   "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/joyer-test/providers/Microsoft.Storage/storageAccounts/storagetasktest202402281/providers/Microsoft.Insights/metrics/Egress",
                   "type": "Microsoft.Insights/metrics",
                   "displayDescription": "The amount of egress data. This number includes egress to external client from Azure Storage as well as egress within Azure. As a result, this number does not reflect billable egress.",        
                   "unit": "Bytes",
                   "timeseries": [
                     {
                       "metadatavalues": [ ],
                       "data": [
                         {
                           "timeStamp": "2024-04-08T06:45:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T07:00:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T07:15:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T07:30:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T07:45:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T08:00:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T08:15:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2024-04-08T08:30:00.0000000Z",
                           "total": 0
                         }
                       ]
                     }
                   ]
                 }}
```

This command lists the metric values for specified resources.

