#### Get-AzMetricsBatch

#### SYNOPSIS
Lists the metric values for multiple resources.

#### SYNTAX

+ BatchExpanded (Default)
```powershell
Get-AzMetricsBatch -Endpoint <String> -Name <List<String>> -Namespace <String> [-SubscriptionId <String[]>]
 [-Aggregation <String>] [-EndTime <String>] [-Filter <String>] [-Interval <String>] [-Orderby <String>]
 [-Rollupby <String>] [-StartTime <String>] [-Top <Int32>] [-ResourceId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ BatchViaIdentityExpanded
```powershell
Get-AzMetricsBatch -Endpoint <String> -InputObject <IMetricsIdentity> -Name <List<String>> -Namespace <String>
 [-Aggregation <String>] [-EndTime <String>] [-Filter <String>] [-Interval <String>] [-Orderby <String>]
 [-Rollupby <String>] [-StartTime <String>] [-Top <Int32>] [-ResourceId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get ingress and egress from storage account
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


#### Get-AzMetricsMetric

#### SYNOPSIS
**Lists the metric values for a resource**.

#### SYNTAX

+ List1 (Default)
```powershell
Get-AzMetricsMetric -ResourceUri <String> [-Aggregation <String>] [-AutoAdjustTimegrain] [-Filter <String>]
 [-Interval <String>] [-Name <String>] [-Namespace <String>] [-Orderby <String>] [-ResultType <String>]
 [-Rollupby <String>] [-Timespan <String>] [-Top <Int32>] [-ValidateDimension] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

+ ListExpanded
```powershell
Get-AzMetricsMetric -Region <String> [-SubscriptionId <String[]>] [-Aggregation <String>]
 [-AutoAdjustTimegrain] [-Filter <String>] [-Interval <String>] [-Name <String>] [-Namespace <String>]
 [-Orderby <String>] [-ResultType <String>] [-Rollupby <String>] [-Timespan <String>] [-Top <Int32>]
 [-ValidateDimension] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List the metric data for a subscription
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

+ Example 2: List the metric values for a specified resource URI
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


#### Get-AzMetricsMetricDefinition

#### SYNOPSIS
Lists the metric definitions for the subscription.

#### SYNTAX

+ List (Default)
```powershell
Get-AzMetricsMetricDefinition -Region <String> [-SubscriptionId <String[]>] [-Namespace <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List1
```powershell
Get-AzMetricsMetricDefinition -ResourceUri <String> [-Namespace <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List the metric definitions for a storage account resource URI
```powershell
Get-AzMetricsMetricDefinition -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 -Namespace Microsoft.Storage/storageAccounts | Format-List
```

```output
Category                 : Capacity
Dimension                : 
DisplayDescription       : The amount of storage used by the storage account. For standard storage accounts, it's the sum of capacity used by blob, table, file, and        
                           queue. For premium storage accounts and Blob storage accounts, it is the same as BlobCapacity or FileCapacity.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/UsedCapacity
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1H",
                             "retention": "P93D"
                           }}
MetricClass              : 
NameLocalizedValue       : Used capacity
NameValue                : UsedCapacity
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Average
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Average}
Unit                     : Bytes

Category                 : Transaction
Dimension                : {{
                             "value": "ResponseType",
                             "localizedValue": "Response type"
                           }, {
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }…}
DisplayDescription       : The number of requests made to a storage service or the specified API operation. This number includes successful and failed requests, as well    
                           as requests which produced errors. Use ResponseType dimension for the number of different type of response.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/Transactions
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Transactions
NameValue                : Transactions
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Total
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Total}
Unit                     : Count

Category                 : Transaction
Dimension                : {{
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }}
DisplayDescription       : The amount of ingress data, in bytes. This number includes ingress from an external client into Azure Storage as well as ingress within Azure.   
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/Ingress
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Ingress
NameValue                : Ingress
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Total
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Total, Average, Minimum, Maximum}
Unit                     : Bytes

Category                 : Transaction
Dimension                : {{
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }}
DisplayDescription       : The amount of egress data. This number includes egress to external client from Azure Storage as well as egress within Azure. As a result, this   
                           number does not reflect billable egress.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/Egress
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Egress
NameValue                : Egress
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Total
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Total, Average, Minimum, Maximum}
Unit                     : Bytes

Category                 : Transaction
Dimension                : {{
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }}
DisplayDescription       : The average time used to process a successful request by Azure Storage. This value does not include the network latency specified in
                           SuccessE2ELatency.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011
                           /providers/microsoft.insights/metricdefinitions/SuccessServerLatency
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Success Server Latency
NameValue                : SuccessServerLatency
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Average
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Average, Minimum, Maximum}
Unit                     : MilliSeconds

Category                 : Transaction
Dimension                : {{
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }}
DisplayDescription       : The average end-to-end latency of successful requests made to a storage service or the specified API operation, in milliseconds. This value      
                           includes the required processing time within Azure Storage to read the request, send the response, and receive acknowledgment of the response.   
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/SuccessE2ELatency
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Success E2E Latency
NameValue                : SuccessE2ELatency
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Average
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Average, Minimum, Maximum}
Unit                     : MilliSeconds

Category                 : Transaction
Dimension                : {{
                             "value": "GeoType",
                             "localizedValue": "Geo type"
                           }, {
                             "value": "ApiName",
                             "localizedValue": "API name"
                           }, {
                             "value": "Authentication",
                             "localizedValue": "Authentication"
                           }}
DisplayDescription       : The percentage of availability for the storage service or the specified API operation. Availability is calculated by taking the
                           TotalBillableRequests value and dividing it by the number of applicable requests, including those that produced unexpected errors. All
                           unexpected errors result in reduced availability for the storage service or the specified API operation.
Id                       : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
                           /providers/microsoft.insights/metricdefinitions/Availability
IsDimensionRequired      : False
MetricAvailability       : {{
                             "timeGrain": "PT1M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT5M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT15M",
                             "retention": "P93D"
                           }, {
                             "timeGrain": "PT30M",
                             "retention": "P93D"
                           }…}
MetricClass              : 
NameLocalizedValue       : Availability
NameValue                : Availability
Namespace                : Microsoft.Storage/storageAccounts
PrimaryAggregationType   : Average
ResourceId               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/Monitor-Metrics/providers/Microsoft.Storage/storageAccounts/monitortestps0011 
SupportedAggregationType : {Average, Minimum, Maximum}
Unit                     : Percent 
```

This command lists the metric definitions for a storage account resource URI.

+ Example 2: List the metric definitions for a web site resource URI
```powershell
Get-AzMetricsMetricDefinition -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/monitor-metric/providers/Microsoft.Web/sites/metricstest01 -Namespace Microsoft.Web/sites
```

```output
Category DisplayDescription
-------- ------------------                                                                                                                                                                                                                         
         The amount of CPU consumed by the app, in seconds. For more information about this metric. Please see https://aka.ms/website-monitor-cpu-time-vs-cpu-percentage (CPU time vs CPU percentage). For WebApps only.
         The total number of requests regardless of their resulting HTTP status code. For WebApps and FunctionApps.
         The amount of incoming bandwidth consumed by the app, in MiB. For WebApps and FunctionApps.
         The amount of outgoing bandwidth consumed by the app, in MiB. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code 101. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 200 but < 300. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 300 but < 400. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 401 status code. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 403 status code. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 404 status code. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 406 status code. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 400 but < 500. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 500 but < 600. For WebApps and FunctionApps.
         The current amount of memory used by the app, in MiB. For WebApps and FunctionApps.
         The average amount of memory used by the app, in megabytes (MiB). For WebApps and FunctionApps.
         The average time taken for the app to serve requests, in seconds. For WebApps and FunctionApps.
         The time taken for the app to serve requests, in seconds. For WebApps and FunctionApps.
         The number of bound sockets existing in the sandbox (w3wp.exe and its child processes). A bound socket is created by calling bind()/connect() APIs and remains until said socket is closed with CloseHandle()/closesocket(). For WebApps … 
         The total number of handles currently open by the app process. For WebApps and FunctionApps.
         The number of threads currently active in the app process. For WebApps and FunctionApps.
         Private Bytes is the current size, in bytes, of memory that the app process has allocated that can't be shared with other processes. For WebApps and FunctionApps.
         The rate at which the app process is reading bytes from I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is writing bytes to I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing bytes to I/O operations that don't involve data, such as control operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing read I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing write I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing I/O operations that aren't read or write operations. For WebApps and FunctionApps.
         The number of requests in the application request queue. For WebApps and FunctionApps.
         The current number of Assemblies loaded across all AppDomains in this application. For WebApps and FunctionApps.
         The current number of AppDomains loaded in this application. For WebApps and FunctionApps.
         The total number of AppDomains unloaded since the start of the application. For WebApps and FunctionApps.
         The number of times the generation 0 objects are garbage collected since the start of the app process. Higher generation GCs include all lower generation GCs. For WebApps and FunctionApps.
         The number of times the generation 1 objects are garbage collected since the start of the app process. Higher generation GCs include all lower generation GCs. For WebApps and FunctionApps.
         The number of times the generation 2 objects are garbage collected since the start of the app process. For WebApps and FunctionApps.
         Health check status. For WebApps and FunctionApps.
         Percentage of filesystem quota consumed by the app. For WebApps and FunctionApps.
```

This command lists the metric definitions for a web site resource URI.

+ Example 3: List the metric definitions for the subscription
```powershell
Get-AzMetricsMetricDefinition -ResourceUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/monitor-metric/providers/Microsoft.Web/sites/metricstest01 -Namespace Microsoft.Web/sites
```

```output
Category DisplayDescription
-------- ------------------                                                                                                                                                                                                                         
         The amount of CPU consumed by the app, in seconds. For more information about this metric. Please see https://aka.ms/website-monitor-cpu-time-vs-cpu-percentage (CPU time vs CPU percentage). For WebApps only.
         The total number of requests regardless of their resulting HTTP status code. For WebApps and FunctionApps.
         The amount of incoming bandwidth consumed by the app, in MiB. For WebApps and FunctionApps.
         The amount of outgoing bandwidth consumed by the app, in MiB. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code 101. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 200 but < 300. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 300 but < 400. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 401 status code. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 403 status code. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 404 status code. For WebApps and FunctionApps.
         The count of requests resulting in HTTP 406 status code. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 400 but < 500. For WebApps and FunctionApps.
         The count of requests resulting in an HTTP status code >= 500 but < 600. For WebApps and FunctionApps.
         The current amount of memory used by the app, in MiB. For WebApps and FunctionApps.
         The average amount of memory used by the app, in megabytes (MiB). For WebApps and FunctionApps.
         The average time taken for the app to serve requests, in seconds. For WebApps and FunctionApps.
         The time taken for the app to serve requests, in seconds. For WebApps and FunctionApps.
         The number of bound sockets existing in the sandbox (w3wp.exe and its child processes). A bound socket is created by calling bind()/connect() APIs and remains until said socket is closed with CloseHandle()/closesocket(). For WebApps … 
         The total number of handles currently open by the app process. For WebApps and FunctionApps.
         The number of threads currently active in the app process. For WebApps and FunctionApps.
         Private Bytes is the current size, in bytes, of memory that the app process has allocated that can't be shared with other processes. For WebApps and FunctionApps.
         The rate at which the app process is reading bytes from I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is writing bytes to I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing bytes to I/O operations that don't involve data, such as control operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing read I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing write I/O operations. For WebApps and FunctionApps.
         The rate at which the app process is issuing I/O operations that aren't read or write operations. For WebApps and FunctionApps.
         The number of requests in the application request queue. For WebApps and FunctionApps.
         The current number of Assemblies loaded across all AppDomains in this application. For WebApps and FunctionApps.
         The current number of AppDomains loaded in this application. For WebApps and FunctionApps.
         The total number of AppDomains unloaded since the start of the application. For WebApps and FunctionApps.
         The number of times the generation 0 objects are garbage collected since the start of the app process. Higher generation GCs include all lower generation GCs. For WebApps and FunctionApps.
         The number of times the generation 1 objects are garbage collected since the start of the app process. Higher generation GCs include all lower generation GCs. For WebApps and FunctionApps.
         The number of times the generation 2 objects are garbage collected since the start of the app process. For WebApps and FunctionApps.
         Health check status. For WebApps and FunctionApps.
         Percentage of filesystem quota consumed by the app. For WebApps and FunctionApps.
```

This command lists the metric definitions for the subscription.


