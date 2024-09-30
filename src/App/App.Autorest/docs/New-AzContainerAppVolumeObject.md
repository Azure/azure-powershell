---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappvolumeobject
schema: 2.0.0
---

# New-AzContainerAppVolumeObject

## SYNOPSIS
Create an in-memory object for Volume.

## SYNTAX

```
New-AzContainerAppVolumeObject [-MountOption <String>] [-Name <String>] [-Secret <ISecretVolumeItem[]>]
 [-StorageName <String>] [-StorageType <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Volume.

## EXAMPLES

### Example 1: Create a Volume object for ContainerApp.
```powershell
New-AzContainerAppVolumeObject -Name "volumeName" -StorageName "azpssa"
```

```output
MountOption Name       StorageName StorageType
----------- ----       ----------- -----------
            volumeName azpssa
```

Create a Volume object for ContainerApp.

## PARAMETERS

### -MountOption
Mount options used while mounting the AzureFile.
Must be a comma-separated string.

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
Volume name.

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

### -Secret
List of secrets to be added in volume.
If no secrets are provided, all secrets in collection will be added to volume.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.ISecretVolumeItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageName
Name of storage resource.
No need to provide for EmptyDir and Secret.

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

### -StorageType
Storage type for the volume.
If not provided, use EmptyDir.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Volume

## NOTES

## RELATED LINKS

