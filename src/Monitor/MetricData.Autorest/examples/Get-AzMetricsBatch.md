### Example 1: Get ingress and egress from storage account
```powershell
$endpoint = 'https://eastus.metrics.monitor.azure.com'
$start = "2023-12-06T07:00:00.000Z"
$end = "2023-12-06T08:00:00.000Z"
Get-AzMetricsBatch -Endpoint $endpoint -Name 'ingress','egress' -Namespace "Microsoft.Storage/storageAccounts" -EndTime $end -StartTime $start -ResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/joyer-monitor/providers/Microsoft.Storage/storageAccounts/psmetric01
```

```output
Endtime        : 2023-12-06T08:00:00Z
Interval       : 00:01:00a
Namespace      : Microsoft.Storage/storageAccounts
Resourceid     : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/joyer-monitor/providers/Microsoft.Storage/storageAccounts/psmetric01
Resourceregion : eastus
Starttime      : 2023-12-06T07:00:00Z
Value          : {{
                   "name": {
                     "value": "Ingress",
                     "localizedValue": "Ingress"
                   },
                   "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/joyer-monitor/providers/Microsoft.Storage/storageAccounts/psmetric01/providers/Microsoft.Insigh 
                 ts/metrics/Ingress",
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
                           "timeStamp": "2023-12-06T07:02:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:03:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:04:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:05:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:06:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:07:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:08:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:09:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:10:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:11:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:12:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:13:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:14:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:15:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:16:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:17:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:18:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:19:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:20:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:21:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:22:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:23:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:24:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:25:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:26:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:27:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:28:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:29:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:30:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:31:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:32:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:33:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:34:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:35:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:36:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:37:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:38:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:39:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:40:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:41:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:42:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:43:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:44:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:45:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:46:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:47:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:48:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:49:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:50:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:51:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:52:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:53:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:54:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:55:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:56:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:57:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:58:00.0000000Z",
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
                   "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/joyer-monitor/providers/Microsoft.Storage/storageAccounts/psmetric01/providers/Microsoft.Insigh 
                 ts/metrics/Egress",
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
                           "timeStamp": "2023-12-06T07:02:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:03:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:04:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:05:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:06:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:07:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:08:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:09:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:10:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:11:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:12:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:13:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:14:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:15:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:16:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:17:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:18:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:19:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:20:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:21:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:22:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:23:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:24:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:25:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:26:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:27:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:28:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:29:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:30:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:31:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:32:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:33:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:34:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:35:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:36:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:37:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:38:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:39:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:40:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:41:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:42:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:43:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:44:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:45:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:46:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:47:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:48:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:49:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:50:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:51:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:52:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:53:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:54:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:55:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:56:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:57:00.0000000Z",
                           "total": 0
                         },
                         {
                           "timeStamp": "2023-12-06T07:58:00.0000000Z",
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

This command lists the metric values for specified resources.

