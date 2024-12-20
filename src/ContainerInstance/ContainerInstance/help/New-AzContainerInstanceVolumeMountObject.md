---
external help file: Az.ContainerInstance-help.xml
Module Name: Az.ContainerInstance
online version: https://learn.microsoft.com/powershell/module/az.ContainerInstance/new-AzContainerInstanceVolumeMountObject
schema: 2.0.0
---

# New-AzContainerInstanceVolumeMountObject

## SYNOPSIS
Create a in-memory object for VolumeMount

## SYNTAX

```
New-AzContainerInstanceVolumeMountObject -MountPath <String> -Name <String> [-ReadOnly <Boolean>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for VolumeMount

## EXAMPLES

### Example 1: Specify a volume mount available to a container instance
```powershell
New-AzContainerInstanceVolumeMountObject -Name "mnt" -MountPath "/mnt/azfile" -ReadOnly $true
```

```output
MountPath   Name ReadOnly
---------   ---- --------
/mnt/azfile mnt  True
```

This command specifies a volume mount available to a container instance

## PARAMETERS

### -MountPath
The path within the container where the volume should be mounted.
Must not contain colon (:).

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

### -Name
The name of the volume mount.

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

### -ReadOnly
The flag indicating whether the volume mount is read-only.

```yaml
Type: System.Boolean
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.VolumeMount

## NOTES

## RELATED LINKS
