---
external help file: Az.Metric.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/get-azmetric
schema: 2.0.0
---

# Get-AzMetric

## SYNOPSIS
**Lists the metric values for a resource**.

## SYNTAX

### List2 (Default)
```
Get-AzMetric -ResourceUri <String> [-Aggregation <String>] [-AutoAdjustTimegrain] [-Filter <String>]
 [-Interval <String>] [-MetricName <String>] [-MetricNamespace <String>] [-OrderBy <String>]
 [-ResultType <String>] [-RollUpBy <String>] [-StartTime <DateTime>] [-EndTime <DateTime>] [-Top <Int32>]
 [-ValidateDimension] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ListExpanded
```
Get-AzMetric [-SubscriptionId <String[]>] [-Aggregation <String>] [-AutoAdjustTimegrain] [-Filter <String>]
 [-Interval <String>] [-MetricName <String>] [-MetricNamespace <String>] [-OrderBy <String>]
 [-ResultType <String>] [-RollUpBy <String>] [-StartTime <DateTime>] [-EndTime <DateTime>] [-Top <Int32>]
 [-ValidateDimension] -Region <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonFilePath
```
Get-AzMetric [-SubscriptionId <String[]>] -Region <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListViaJsonString
```
Get-AzMetric [-SubscriptionId <String[]>] -Region <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
**Lists the metric values for a resource**.

## EXAMPLES

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

## PARAMETERS

### -Aggregation
The list of aggregation types (comma separated) to retrieve.
*Examples: average, minimum, maximum*

```yaml
Type: System.String
Parameter Sets: List2, ListExpanded
Aliases: AggregationType

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoAdjustTimegrain
When set to true, if the timespan passed in is not supported by this metric, the API will return the result using the closest supported timespan.
When set to false, an error is returned for invalid timespan parameters.
Defaults to false.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List2, ListExpanded
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

### -EndTime
[Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Runtime.DefaultInfo(Script = 'DateTime.UtcNow')]
Specifies the end time of the query in local time.
The default is the current time.

```yaml
Type: System.DateTime
Parameter Sets: List2, ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The **$filter** is used to reduce the set of metric data returned.
Example:
Metric contains metadata A, B and C.
- Return all time series of C where A = a1 and B = b1 or b2
**$filter=A eq 'a1' and B eq 'b1' or B eq 'b2' and C eq '*'**
- Invalid variant:
**$filter=A eq 'a1' and B eq 'b1' and C eq '*' or B = 'b2'**
This is invalid because the logical or operator cannot separate two different metadata names.
- Return all time series where A = a1, B = b1 and C = c1:
**$filter=A eq 'a1' and B eq 'b1' and C eq 'c1'**
- Return all time series where A = a1
**$filter=A eq 'a1' and B eq '*' and C eq '*'**.

```yaml
Type: System.String
Parameter Sets: List2, ListExpanded
Aliases: MetricFilter

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Parameter Sets: List2, ListExpanded
Aliases: TimeGrain

Required: False
Position: Named
Default value: PT1M
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the List operation

```yaml
Type: System.String
Parameter Sets: ListViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricName
The names of the metrics (comma separated) to retrieve.

```yaml
Type: System.String
Parameter Sets: List2, ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricNamespace
Metric namespace where the metrics you want reside.

```yaml
Type: System.String
Parameter Sets: List2, ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrderBy
The aggregation to use for sorting results and the direction of the sort.
Only one order can be specified.
*Examples: sum asc*

```yaml
Type: System.String
Parameter Sets: List2, ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Region
The region where the metrics you want reside.

```yaml
Type: System.String
Parameter Sets: ListExpanded, ListViaJsonFilePath, ListViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The identifier of the resource.

```yaml
Type: System.String
Parameter Sets: List2
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResultType
Reduces the set of data collected.
The syntax allowed depends on the operation.
See the operation's description for details.

```yaml
Type: System.String
Parameter Sets: List2, ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RollUpBy
Dimension name(s) to rollup results by.
For example if you only want to see metric values with a filter like 'City eq Seattle or City eq Tacoma' but don't want to see separate values for each city, you can specify 'RollUpBy=City' to see the results for Seattle and Tacoma rolled up into one timeseries.

```yaml
Type: System.String
Parameter Sets: List2, ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
Specifies the start time of the query in local time.
The default is the current local time minus one hour.

```yaml
Type: System.DateTime
Parameter Sets: List2, ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: ListExpanded, ListViaJsonFilePath, ListViaJsonString
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
Parameter Sets: List2, ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateDimension
When set to false, invalid filter parameter values will be ignored.
When set to true, an error is returned for invalid filter parameters.
Defaults to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: List2, ListExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.IResponse

## NOTES

## RELATED LINKS
