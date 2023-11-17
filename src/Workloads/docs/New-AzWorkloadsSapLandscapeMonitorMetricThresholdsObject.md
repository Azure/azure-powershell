---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/Az.Workloads/new-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject
schema: 2.0.0
---

# New-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject

## SYNOPSIS
Create an in-memory object for SapLandscapeMonitorMetricThresholds.

## SYNTAX

```
New-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject [-Green <Single>] [-Name <String>] [-Red <Single>]
 [-Yellow <Single>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SapLandscapeMonitorMetricThresholds.

## EXAMPLES

### Example 1: Create a new Metrics Threshold for SAP Landscape Monitor
```powershell
New-AzWorkloadsSapLandscapeMonitorMetricThresholdsObject -Green 90 -Name X00 -Red 50 -Yellow 80
```

```output
Green Name Red Yellow
----- ---- --- ------
90    X00  50  80

```

Create a new Metrics Threshold object to be used for creating a SAP Landscape Monitor

## PARAMETERS

### -Green
Gets or sets the threshold value for Green.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Gets or sets the name of the threshold.

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

### -Red
Gets or sets the threshold value for Red.

```yaml
Type: System.Single
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Yellow
Gets or sets the threshold value for Yellow.

```yaml
Type: System.Single
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.SapLandscapeMonitorMetricThresholds

## NOTES

ALIASES

## RELATED LINKS

