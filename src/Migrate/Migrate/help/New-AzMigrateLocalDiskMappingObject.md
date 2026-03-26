---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/new-azmigratelocaldiskmappingobject
schema: 2.0.0
---

# New-AzMigrateLocalDiskMappingObject

## SYNOPSIS
Creates a new disk mapping

## SYNTAX

```
New-AzMigrateLocalDiskMappingObject -DiskID <String> -IsOSDisk <String> -IsDynamic <String> -Size <Int64>
 -Format <String> [-PhysicalSectorSize <Int64>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzMigrateLocalDiskMappingObject cmdlet creates a mapping of the source disk attached to the server to be migrated

## EXAMPLES

### Example 1: Creates Disk to migrate
```powershell
New-AzMigrateLocalDiskMappingObject -DiskID a -IsOSDisk true -IsDynamic true -Size 1 -Format VHDX
```

```output
DiskFileFormat     : VHDX
DiskId             : a
DiskSizeGb         : 1
IsDynamic          : True
IsOSDisk           : True
StorageContainerId :
```

Get disk object to provide input for New-AzMigrateLocalServerReplication

## PARAMETERS

### -DiskID
Specifies the disk ID of the disk attached to the discovered server to be migrated.

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

### -Format
Specifies the disk format.
'VHD' or 'VHDX' for Hyper-V Generation 1; 'VHDX' for Hyper-V Generation 2.

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

### -IsDynamic
Specifies whether the disk is dynamic.

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

### -IsOSDisk
Specifies whether the disk contains the Operating System for the source server to be migrated.

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

### -PhysicalSectorSize
Specifies the disk physical sector size in bytes.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Size
Specifies the disk size in GB.

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

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20240901.AzLocalDiskInput

## NOTES

## RELATED LINKS
