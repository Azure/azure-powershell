---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorhealthprobesettingobject
schema: 2.0.0
---

# New-AzFrontDoorHealthProbeSettingObject

## SYNOPSIS
Create an in-memory object for HealthProbeSettingsModel.

## SYNTAX

```
New-AzFrontDoorHealthProbeSettingObject [-EnabledState <String>] [-HealthProbeMethod <String>]
 [-IntervalInSeconds <Int32>] [-Name <String>] [-Path <String>] [-Protocol <String>] [-Id <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for HealthProbeSettingsModel.

## EXAMPLES

### Example 1: Create a PSHealthProbeSetting object for Front Door creation
```powershell
New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1"
```

```output
EnabledState      : Enabled
HealthProbeMethod : HEAD
Id                :
IntervalInSeconds : 30
Name              : healthProbeSetting1
Path              : /
Protocol          : Http
ResourceState     :
Type              :
```

Note: HealthProbeMethod setting is not case sensitive.

Create a PSHealthProbeSetting object for Front Door creation

## PARAMETERS

### -EnabledState
Whether to enable health probes to be made against backends defined under backendPools.
Health probes can only be disabled if there is a single enabled backend in single enabled backend pool.

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

### -HealthProbeMethod
Configures which HTTP method to use to probe the backends defined under backendPools.

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

### -IntervalInSeconds
The number of seconds between health probes.

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

### -Path
The path to use for the health probe.
Default is /.

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

### -Protocol
Protocol scheme to use for this probe.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.HealthProbeSettingsModel

## NOTES

## RELATED LINKS
