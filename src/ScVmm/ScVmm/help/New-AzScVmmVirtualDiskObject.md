---
external help file: Az.ScVmm-help.xml
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/Az.ScVmm/new-azscvmmvirtualdiskobject
schema: 2.0.0
---

# New-AzScVmmVirtualDiskObject

## SYNOPSIS
Create an in-memory object for VirtualDisk.

## SYNTAX

```
New-AzScVmmVirtualDiskObject [-Bus <Int32>] [-BusType <String>] [-CreateDiffDisk <String>] [-DiskId <String>]
 [-DiskSizeGb <Int32>] [-Lun <Int32>] [-Name <String>] [-StorageQoSPolicyId <String>]
 [-StorageQoSPolicyName <String>] [-TemplateDiskId <String>] [-VhdType <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VirtualDisk.

## EXAMPLES

### Example 1: Create a VirtualDisk Object in memory
```powershell
New-AzScVmmVirtualDiskObject -Name 'Disk-Obj-1' -lun 0 -bus 0 -VhdType 'Dynamic' -BusType 'SCSI' -StorageQoSPolicyName 'Qos-1'
```

```output
Bus                  : 0
BusType              : SCSI
CreateDiffDisk       :
DiskId               :
DiskSizeGb           :
DisplayName          :
Lun                  : 0
MaxDiskSizeGb        :
Name                 : Disk-Obj-1
StorageQoSPolicyId   :
StorageQoSPolicyName : Qos-1
TemplateDiskId       :
VhdFormatType        :
VhdType              : Dynamic
VolumeType           :
```

Create a VirtualDisk Object in memory.
Used in `New-AzScVmmVM` for Disk value.

## PARAMETERS

### -Bus
Gets or sets the disk bus.

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

### -BusType
Gets or sets the disk bus type.

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

### -CreateDiffDisk
Gets or sets a value indicating diff disk.

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

### -DiskId
Gets or sets the disk id.

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

### -DiskSizeGb
Gets or sets the disk total size.

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

### -Lun
Gets or sets the disk lun.

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
Gets or sets the name of the disk.

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

### -StorageQoSPolicyId
The ID of the QoS policy.

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

### -StorageQoSPolicyName
The name of the policy.

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

### -TemplateDiskId
Gets or sets the disk id in the template.

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

### -VhdType
Gets or sets the disk vhd type.

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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.VirtualDisk

## NOTES

## RELATED LINKS
