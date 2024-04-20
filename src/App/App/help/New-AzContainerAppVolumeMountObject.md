---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappvolumemountobject
schema: 2.0.0
---

# New-AzContainerAppVolumeMountObject

## SYNOPSIS
Create an in-memory object for VolumeMount.

## SYNTAX

```
New-AzContainerAppVolumeMountObject [-MountPath <String>] [-SubPath <String>] [-VolumeName <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VolumeMount.

## EXAMPLES

### Example 1: Create a VolumeMount object for ContainerApp.
```powershell
New-AzContainerAppVolumeMountObject -MountPath "/mountPath" -VolumeName "VolumeName"
```

```output
MountPath  SubPath VolumeName
---------  ------- ----------
/mountPath         VolumeName
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubPath
Path within the volume from which the container's volume should be mounted.
Defaults to "" (volume's root).

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.VolumeMount

## NOTES

## RELATED LINKS
