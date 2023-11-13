---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.Cdn/new-AzFrontDoorCdnOriginGroupHealthProbeSettingObject
schema: 2.0.0
---

# New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject

## SYNOPSIS
Create an in-memory object for HealthProbeParameters.

## SYNTAX

```
New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject [-ProbeIntervalInSecond <Int32>] [-ProbePath <String>]
 [-ProbeProtocol <ProbeProtocol>] [-ProbeRequestType <HealthProbeRequestType>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for HealthProbeParameters.

## EXAMPLES

### Example 1: Create an in-memory object for AzureFrontDoor origin group `HealthProbeSetting` object
```powershell
New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" -ProbeProtocol "Https" -ProbeRequestType "GET"
```

```output
ProbeIntervalInSecond ProbePath ProbeProtocol ProbeRequestType
--------------------- --------- ------------- ----------------
1                     /         Https         GET
```

Create an in-memory object for AzureFrontDoor origin group `HealthProbeSetting` object

## PARAMETERS

### -ProbeIntervalInSecond
The number of seconds between health probes.Default is 240sec.

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

### -ProbePath
The path relative to the origin that is used to determine the health of the origin.

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

### -ProbeProtocol
Protocol to use for health probe.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ProbeProtocol
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProbeRequestType
The type of health probe request that is made.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.HealthProbeRequestType
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.HealthProbeParameters

## NOTES

ALIASES

## RELATED LINKS

