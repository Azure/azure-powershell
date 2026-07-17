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

Create a VirtualDiskUpdate Object in memory. Used in `New-AzScVmmVM` for Disk value.

