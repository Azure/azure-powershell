---
external help file: Az.Metricdata.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azmetricsbatch
schema: 2.0.0
---

# Get-AzMetricsBatch

## SYNOPSIS
Lists the metric values for multiple resources.

## SYNTAX

### BatchExpanded (Default)
```
Get-AzMetricsBatch -Endpoint <String> [-SubscriptionId <String[]>]
 -Name <System.Collections.Generic.List`1[System.String]> -Namespace <String> [-Aggregation <String>]
 [-EndTime <String>] [-Filter <String>] [-Interval <String>] [-Orderby <String>] [-Rollupby <String>]
 [-StartTime <String>] [-Top <Int32>] [-ResourceId <String[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BatchViaIdentityExpanded
```
Get-AzMetricsBatch -Endpoint <String> -InputObject <IMetricdataIdentity>
 -Name <System.Collections.Generic.List`1[System.String]> -Namespace <String> [-Aggregation <String>]
 [-EndTime <String>] [-Filter <String>] [-Interval <String>] [-Orderby <String>] [-Rollupby <String>]
 [-StartTime <String>] [-Top <Int32>] [-ResourceId <String[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Lists the metric values for multiple resources.

## EXAMPLES

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

## PARAMETERS

### -Aggregation
The list of aggregation types (comma separated) to retrieve.
*Examples: average, minimum, maximum*

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The regional endpoint to use, for example https://eastus.metrics.monitor.azure.com.
The region should match the region of the requested resources.
For global resources, the region should be 'global'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTime
The end time of the query.
It is a string in the format 'yyyy-MM-ddTHH:mm:ss.fffZ'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The filter is used to reduce the set of metric data returned.
Example:
Metric contains metadata A, B and C.
- Return all time series of C where A = a1 and B = b1 or b2
**filter=A eq 'a1' and B eq 'b1' or B eq 'b2' and C eq '*'**
- Invalid variant:
**filter=A eq 'a1' and B eq 'b1' and C eq '*' or B = 'b2'**
This is invalid because the logical or operator cannot separate two different metadata names.
- Return all time series where A = a1, B = b1 and C = c1:
**filter=A eq 'a1' and B eq 'b1' and C eq 'c1'**
- Return all time series where A = a1
**filter=A eq 'a1' and B eq '*' and C eq '*'**.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.IMetricdataIdentity
Parameter Sets: BatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Interval
The interval (i.e.
timegrain) of the query in ISO 8601 duration format.
Defaults to PT1M.
Special case for 'FULL' value that returns single datapoint for entire time span requested.
*Examples: PT15M, PT1H, P1D, FULL*

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The names of the metrics (comma separated) to retrieve.

```yaml
Type: System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases: MetricName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
Metric namespace that contains the requested metric names.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: MetricNamespace

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Orderby
The aggregation to use for sorting results and the direction of the sort.
Only one order can be specified.
*Examples: sum asc*

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The list of resource IDs to query metrics for.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rollupby
Dimension name(s) to rollup results by.
For example if you only want to see metric values with a filter like 'City eq Seattle or City eq Tacoma' but don't want to see separate values for each city, you can specify 'RollUpBy=City' to see the results for Seattle and Tacoma rolled up into one timeseries.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
The start time of the query.
It is a string in the format 'yyyy-MM-ddTHH:mm:ss.fffZ'.
If you have specified the endtime parameter, then this parameter is required.
If only starttime is specified, then endtime defaults to the current time.
If no time interval is specified, the default is 1 hour.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier for the resources in this batch.

```yaml
Type: System.String[]
Parameter Sets: BatchExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The maximum number of records to retrieve per resource ID in the request.
Valid only if filter is specified.
Defaults to 10.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.IMetricdataIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.IMetricResultsResponse

## NOTES

## RELATED LINKS

## PARAMETERS

### -Aggregation
The list of aggregation types (comma separated) to retrieve.
*Examples: average, minimum, maximum*

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The regional endpoint to use, for example https://eastus.metrics.monitor.azure.com.
The region should match the region of the requested resources.
For global resources, the region should be 'global'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndTime
The end time of the query.
It is a string in the format 'yyyy-MM-ddTHH:mm:ss.fffZ'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The filter is used to reduce the set of metric data returned.
Example:
Metric contains metadata A, B and C.
- Return all time series of C where A = a1 and B = b1 or b2
**filter=A eq 'a1' and B eq 'b1' or B eq 'b2' and C eq '*'**
- Invalid variant:
**filter=A eq 'a1' and B eq 'b1' and C eq '*' or B = 'b2'**
This is invalid because the logical or operator cannot separate two different metadata names.
- Return all time series where A = a1, B = b1 and C = c1:
**filter=A eq 'a1' and B eq 'b1' and C eq 'c1'**
- Return all time series where A = a1
**filter=A eq 'a1' and B eq '*' and C eq '*'**.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.IMetricdataIdentity
Parameter Sets: BatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Interval
The interval (i.e.
timegrain) of the query in ISO 8601 duration format.
Defaults to PT1M.
Special case for 'FULL' value that returns single datapoint for entire time span requested.
*Examples: PT15M, PT1H, P1D, FULL*

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The names of the metrics (comma separated) to retrieve.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases: MetricName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
Metric namespace that contains the requested metric names.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: MetricNamespace

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Orderby
The aggregation to use for sorting results and the direction of the sort.
Only one order can be specified.
*Examples: sum asc*

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The list of resource IDs to query metrics for.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rollupby
Dimension name(s) to rollup results by.
For example if you only want to see metric values with a filter like 'City eq Seattle or City eq Tacoma' but don't want to see separate values for each city, you can specify 'RollUpBy=City' to see the results for Seattle and Tacoma rolled up into one timeseries.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
The start time of the query.
It is a string in the format 'yyyy-MM-ddTHH:mm:ss.fffZ'.
If you have specified the endtime parameter, then this parameter is required.
If only starttime is specified, then endtime defaults to the current time.
If no time interval is specified, the default is 1 hour.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier for the resources in this batch.

```yaml
Type: System.String[]
Parameter Sets: BatchExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The maximum number of records to retrieve per resource ID in the request.
Valid only if filter is specified.
Defaults to 10.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
