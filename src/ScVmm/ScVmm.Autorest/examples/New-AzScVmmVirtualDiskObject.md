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

Create a VirtualDisk Object in memory. Used in `New-AzScVmmVM` for Disk value.

