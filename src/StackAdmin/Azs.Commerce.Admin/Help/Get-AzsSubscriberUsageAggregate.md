---
external help file: Azs.Commerce.Admin-help.xml
Module Name: Azs.Commerce.Admin
online version: 
schema: 2.0.0
---

# Get-AzsSubscriberUsageAggregate

## SYNOPSIS
Gets a collection of SubscriberUsageAggregate, which are UsageAggregates from direct tenants.

## SYNTAX

```
Get-AzsSubscriberUsageAggregate [-SubscriberId <String>] -ReportedStartTime <DateTime>
 [-AggregationGranularity <String>] -ReportedEndTime <DateTime> [-ContinuationToken <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a collection of SubscriberUsageAggregate, which are UsageAggregates from direct tenants.

## EXAMPLES

### Example 1
```
Get-AzsSubscriberUsageAggregate -ReportedStartTime "2017-09-06T00:00:00Z" -ReportedEndTime "2017-09-07T00:00:00Z"


UsageStartTime       Type                              InstanceData
--------------       ----                              ------------
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourcegroups/derpgroup/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourcegroups/derpgroup/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourceGroups/derpgroup/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourceGroups/derpgroup/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourcegroups/derpgroup/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourcegroups/derpgroup/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourcegroups/derpgroup/providers/Micro...
```

## PARAMETERS

### -AggregationGranularity
The aggregation granularity.

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

### -ContinuationToken
The continuation token.

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

### -ReportedEndTime
The reported end time (exclusive).

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReportedStartTime
The reported start time (inclusive).

```yaml
Type: DateTime
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriberId
The tenant subscription identifier.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Commerce.Admin.Models.UsageAggregate

## NOTES

## RELATED LINKS

