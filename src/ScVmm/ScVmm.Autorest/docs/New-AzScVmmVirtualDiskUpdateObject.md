---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/Az.ScVmm/new-azscvmmvirtualdiskupdateobject
schema: 2.0.0
---

# New-AzScVmmVirtualDiskUpdateObject

## SYNOPSIS
Create an in-memory object for VirtualDiskUpdate.

## SYNTAX

```
New-AzScVmmVirtualDiskUpdateObject [-Bus <Int32>] [-BusType <String>] [-DiskId <String>] [-DiskSizeGb <Int32>]
 [-Lun <Int32>] [-Name <String>] [-StorageQoSPolicyId <String>] [-StorageQoSPolicyName <String>]
 [-VhdType <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for VirtualDiskUpdate.

## EXAMPLES

### Example 1: Create a VirtualDiskUpdate Object in memory
```powershell
New-AzScVmmVirtualDiskUpdateObject -Name 'Disk-Obj-1' -lun 0 -bus 0 -VhdType 'Dynamic' -BusType 'SCSI' -StorageQoSPolicyName 'Qos-1'
```

```output
Bus                  : 0
BusType              : SCSI
DiskId               :
DiskSizeGb           : 
Lun                  : 0
Name                 : Disk-Obj-1
StorageQoSPolicyId   :
StorageQoSPolicyName : Qos-1
VhdType              : Dynamic

```

Create a VirtualDiskUpdate Object in memory.
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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.VirtualDiskUpdate

## NOTES

## RELATED LINKS

