---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/new-azeventhubthrottlingpolicyconfig
schema: 2.0.0
---

# New-AzEventHubThrottlingPolicyConfig

## SYNOPSIS
Constructs an IThrottlingPolicy object that can be fed as input to New-AzEventHubApplicationGroup or Set-AzEventHubApplicationGroup

## SYNTAX

```
New-AzEventHubThrottlingPolicyConfig -MetricId <MetricId> -Name <String> -RateLimitThreshold <Int64>
 [<CommonParameters>]
```

## DESCRIPTION
Constructs an IThrottlingPolicy object that can be fed as input to New-AzEventHubApplicationGroup or Set-AzEventHubApplicationGroup

## EXAMPLES

### Example 1: Constructs an IThrottlingPolicy object 
```powershell
New-AzEventHubThrottlingPolicyConfig -Name t1 -RateLimitThreshold 10000 -MetricId IncomingBytes
```

```output
MetricId      Name RateLimitThreshold Type
--------      ---- ------------------ ----
IncomingBytes t1                10000 ThrottlingPolicy
```

Please refer examples for Set-AzEventHubApplicationGroup to know more.

## PARAMETERS

### -MetricId
Metric Id on which the throttle limit should be set, MetricId can be discovered by hovering over Metric in the Metrics section of Event Hub Namespace inside Azure Portal

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Support.MetricId
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Throttling Policy Config

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

### -RateLimitThreshold
The Threshold limit above which the application group will be throttled.Rate limit is always per second.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api20221001Preview.IThrottlingPolicy

## NOTES

ALIASES

## RELATED LINKS

