---
external help file:
Module Name: Az.Billing
online version: https://docs.microsoft.com/en-us/powershell/module/az.billing/get-azbillingusageaggregate
schema: 2.0.0
---

# Get-AzBillingUsageAggregate

## SYNOPSIS
Query aggregated Azure subscription consumption data for a date range.

## SYNTAX

```
Get-AzBillingUsageAggregate -SubscriptionId <String[]> -ReportedEndTime <DateTime>
 -ReportedStartTime <DateTime> [-AggregationGranularity <AggregationGranularity>]
 [-ContinuationToken <String>] [-ShowDetail] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Query aggregated Azure subscription consumption data for a date range.

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

### -AggregationGranularity
`Daily` (default) returns the data in daily granularity, `Hourly` returns the data in hourly granularity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Billing.Support.AggregationGranularity
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContinuationToken
Used when a continuation token string is provided in the response body of the previous call, enabling paging through a large result set.
If not present, the data is retrieved from the beginning of the day/hour (based on the granularity) passed in.


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

### -ReportedEndTime
The end of the time range to retrieve data for.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ReportedStartTime
The start of the time range to retrieve data for.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ShowDetail
`True` returns usage data in instance-level detail, `false` causes server-side aggregation with fewer details.
For example, if you have 3 website instances, by default you will get 3 line items for website consumption.
If you specify showDetails = false, the data will be aggregated as a single line item for website consumption within the time period (for the given subscriptionId, meterId, usageStartTime and usageEndTime).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
It uniquely identifies Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Billing.Models.Api20150601Preview.IUsageAggregation

## ALIASES

## RELATED LINKS

