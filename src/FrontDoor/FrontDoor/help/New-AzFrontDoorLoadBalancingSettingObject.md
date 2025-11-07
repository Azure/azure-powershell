---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorloadbalancingsettingobject
schema: 2.0.0
---

# New-AzFrontDoorLoadBalancingSettingObject

## SYNOPSIS
Create an in-memory object for LoadBalancingSettingsModel.

## SYNTAX

```
New-AzFrontDoorLoadBalancingSettingObject [-AdditionalLatencyInMilliseconds <Int32>] [-Name <String>]
 [-SampleSize <Int32>] [-SuccessfulSamplesRequired <Int32>] [-Id <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LoadBalancingSettingsModel.

## EXAMPLES

### Example 1: Create a PSLoadBalancingSetting object for Front Door creation
```powershell
New-AzFrontDoorLoadBalancingSettingObject -Name "loadbalancingsetting1"
```

```output
AdditionalLatencyInMilliseconds : 0
Id                              :
Name                            : loadbalancingsetting1
ResourceState                   :
SampleSize                      : 4
SuccessfulSamplesRequired       : 2
Type                            :
```

Create a PSLoadBalancingSetting object for Front Door creation

## PARAMETERS

### -AdditionalLatencyInMilliseconds
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

### -Id
Resource ID.

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
Resource name.

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.LoadBalancingSettingsModel

## NOTES

## RELATED LINKS
