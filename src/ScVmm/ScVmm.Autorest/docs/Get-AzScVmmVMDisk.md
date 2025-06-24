---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/get-azscvmmvmdisk
schema: 2.0.0
---

# Get-AzScVmmVMDisk

## SYNOPSIS
The operation to Get a virtual machine virtual disk.

## SYNTAX

```
Get-AzScVmmVMDisk -ResourceGroupName <String> -vmName <String> [-DiskId <String>] [-DiskName <String>]
 [-SubscriptionId <String>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to Get a virtual machine virtual disk.

## EXAMPLES

### Example 1: List Disk on Virtual Machine
```powershell
Get-AzScVmmVMDisk -vmName "test-vm" -ResourceGroupName "test-rg-01"
```

```output
Bus                  : 0
BusType              : IDE
CreateDiffDisk       : false
DiskId               : 00000000-1111-2222-0001-000000000000
DiskSizeGb           : 20
DisplayName          : test-vm-disk-1
Lun                  : 0
MaxDiskSizeGb        : 40
Name                 : disk_1
StorageQoSPolicyId   :
StorageQoSPolicyName :
TemplateDiskId       :
VhdFormatType        : VHD
VhdType              : Differencing
VolumeType           : BootAndSystem

Bus                  : 0
BusType              : IDE
CreateDiffDisk       : false
DiskId               : ffb0df4a-af83-4370-8ee2-db75e14b7b82
DiskSizeGb           : 4
DisplayName          : vm-test-disk-2
Lun                  : 0
MaxDiskSizeGb        : 40
Name                 : disk_2
StorageQoSPolicyId   :
StorageQoSPolicyName :
TemplateDiskId       :
VhdFormatType        : VHD
VhdType              : Differencing
VolumeType           : None
```

List all Disk on Virtual Machine.

### Example 2: Get Disk on a Virtual Machine
```powershell
Get-AzScVmmVMDisk -vmName "test-vm" -ResourceGroupName "test-rg-01" -DiskName "disk_1"
```

```output
Bus                  : 0
BusType              : IDE
CreateDiffDisk       : false
DiskId               : 00000000-1111-2222-0001-000000000000
DiskSizeGb           : 20
DisplayName          : test-vm-disk-1
Lun                  : 0
MaxDiskSizeGb        : 40
Name                 : disk_1
StorageQoSPolicyId   :
StorageQoSPolicyName :
TemplateDiskId       :
VhdFormatType        : VHD
VhdType              : Differencing
VolumeType           : BootAndSystem
```

Get Disk with name `DiskName` or id `DiskId` on Virtual Machine.

## PARAMETERS

### -DiskId
The UUID of Virtual Disk

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

### -DiskName
The name of Virtual Disk

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -vmName
The name of the virtual machine.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

