### Example 1: Creates Disk to migrate
```powershell
New-AzMigrateHCIDiskMappingObject -DiskID a -IsOSDisk true -IsDynamic true -Size 1 -Format VHDX
```

```output
DiskFileFormat     : VHDX
DiskId             : a
DiskSizeGb         : 1
IsDynamic          : True
IsOSDisk           : True
StorageContainerId : 
```

Get disk object to provide input for New-AzMigrateHCIServerReplication
