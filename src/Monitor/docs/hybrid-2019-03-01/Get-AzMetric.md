---
external help file:
Module Name: Az.Monitor
online version: https://docs.microsoft.com/en-us/powershell/module/az.monitor/get-azmetric
schema: 2.0.0
---

# Get-AzMetric

## SYNOPSIS
**Lists the metric values for a resource**.

## SYNTAX

```
Get-AzMetric -ResourceId <String> [-Aggregation <String>] [-Filter <String>] [-Interval <TimeSpan>]
 [-Metricname <String>] [-Metricnamespace <String>] [-Orderby <String>] [-ResultType <ResultType>]
 [-Timespan <String>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
**Lists the metric values for a resource**.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Aggregation
The list of aggregation types (comma separated) to retrieve.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Filter
The **$filter** is used to reduce the set of metric data returned.
Example:
Metric contains metadata A, B and C.
- Return all time series of C where A = a1 and B = b1 or b2
**$filter=A eq ‘a1’ and B eq ‘b1’ or B eq ‘b2’ and C eq ‘*’**
- Invalid variant:
**$filter=A eq ‘a1’ and B eq ‘b1’ and C eq ‘*’ or B = ‘b2’**
This is invalid because the logical or operator cannot separate two different metadata names.
- Return all time series where A = a1, B = b1 and C = c1:
**$filter=A eq ‘a1’ and B eq ‘b1’ and C eq ‘c1’**
- Return all time series where A = a1
**$filter=A eq ‘a1’ and B eq ‘*’ and C eq ‘*’**.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Interval
The interval (i.e.
timegrain) of the query.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases: TimeGrain

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Metricname
The names of the metrics (comma separated) to retrieve.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Metricnamespace
Metric namespace to query metric definitions for.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Orderby
The aggregation to use for sorting results and the direction of the sort.
Only one order can be specified.
Examples: sum asc.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceId
The identifier of the resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResultType
Reduces the set of data collected.
The syntax allowed depends on the operation.
See the operation's description for details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.Support.ResultType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Timespan
The timespan of the query.
It is a string with the following format 'startDateTime_ISO/endDateTime_ISO'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Top
The maximum number of records to retrieve.
Valid only if $filter is specified.
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api201801.IResponse

## ALIASES

## NOTES

## RELATED LINKS

