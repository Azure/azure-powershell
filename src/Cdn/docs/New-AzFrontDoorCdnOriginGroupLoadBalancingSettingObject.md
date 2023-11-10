---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject
schema: 2.0.0
---

# New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject

## SYNOPSIS
Create an in-memory object for LoadBalancingSettingsParameters.

## SYNTAX

```
New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject [-AdditionalLatencyInMillisecond <Int32>]
 [-SampleSize <Int32>] [-SuccessfulSamplesRequired <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LoadBalancingSettingsParameters.

## EXAMPLES

### Example 1: Create an in-memory object for AzureFrontDoor origin group `LoadBalancingSetting` object
```powershell
New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200  -SampleSize 5 -SuccessfulSamplesRequired 4
```

```output
AdditionalLatencyInMillisecond SampleSize SuccessfulSamplesRequired
------------------------------ ---------- -------------------------
200                            5          4
```

Create an in-memory object for AzureFrontDoor origin group `LoadBalancingSetting` object

## PARAMETERS

### -AdditionalLatencyInMillisecond
The additional latency in milliseconds for probes to fall into the lowest latency bucket.

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

### -SampleSize
The number of samples to consider for load balancing decisions.

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

### -SuccessfulSamplesRequired
The number of samples within the sample period that must succeed.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.LoadBalancingSettingsParameters

## NOTES

ALIASES

## RELATED LINKS

