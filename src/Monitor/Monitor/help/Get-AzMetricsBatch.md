---
external help file: Az.Metric.psm1-help.xml
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
Get-AzMetricsBatch -Endpoint <String> -InputObject <IMetricIdentity>
 -Name <System.Collections.Generic.List`1[System.String]> -Namespace <String> [-Aggregation <String>]
 [-EndTime <String>] [-Filter <String>] [-Interval <String>] [-Orderby <String>] [-Rollupby <String>]
 [-StartTime <String>] [-Top <Int32>] [-ResourceId <String[]>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Lists the metric values for multiple resources.

## EXAMPLES

### EXAMPLE 1
```
$endpoint = 'https://eastus.metrics.monitor.azure.com'
$start = "2023-12-06T07:00:00.000Z"
$end = "2023-12-06T08:00:00.000Z"
Get-AzMetricsBatch -Endpoint $endpoint -Name 'ingress','egress' -Namespace "Microsoft.Storage/storageAccounts" -EndTime $end -StartTime $start -ResourceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/joyer-monitor/providers/Microsoft.Storage/storageAccounts/psmetric01
```

## PARAMETERS

### -Aggregation
The list of aggregation types (comma separated) to retrieve.
*Examples: average, minimum, maximum*

```yaml
Type: String
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
Type: PSObject
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
Type: String
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
Type: String
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
Type: String
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: IMetricIdentity
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
Type: String
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
Type: String
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
Type: String
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
Type: String[]
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
Type: String
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
Type: String
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
Type: String[]
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
Type: Int32
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.IMetricIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Metric.Models.IMetricResultsResponse
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IMetricIdentity\>: Identity Parameter
  \[Id \<String\>\]: Resource identity path
  \[SubscriptionId \<String\>\]: The subscription identifier for the resources in this batch.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.monitor/get-azmetricsbatch](https://learn.microsoft.com/powershell/module/az.monitor/get-azmetricsbatch)
