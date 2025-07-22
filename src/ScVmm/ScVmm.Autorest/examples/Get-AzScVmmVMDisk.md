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
