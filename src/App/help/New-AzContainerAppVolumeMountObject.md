---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerappvolumemountobject
schema: 2.0.0
---

# New-AzContainerAppVolumeMountObject

## SYNOPSIS
Create an in-memory object for VolumeMount.

## SYNTAX

```
New-AzContainerAppVolumeMountObject [-MountPath <String>] [-VolumeName <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VolumeMount.

## EXAMPLES

### Example 1: Create a VolumeMount object for ContainerApp.
```powershell
New-AzContainerAppVolumeMountObject -MountPath "/mountPath" -VolumeName "VolumeName"
```

```output
MountPath  VolumeName
---------  ----------
/mountPath VolumeName
```

Create a VolumeMount object for ContainerApp.

## PARAMETERS

### -MountPath
Path within the container at which the volume should be mounted.Must not contain ':'.

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

### -VolumeName
This must match the Name of a Volume.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.VolumeMount

## NOTES

ALIASES

## RELATED LINKS

