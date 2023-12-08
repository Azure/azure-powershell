### Example 1: Make disks
```powershell
Set-AzMigrateDiskMapping -DiskID "6000C294-1217-dec3-bc18-81f117220424" -DiskName "ContosoDisk_1" -IsOSDisk "True"
```

```output
DiskId                               IsOSDisk TargetDiskName
------                               -------- --------------
6000C294-1217-dec3-bc18-81f117220424 True     ContosoDisk_1
```

Get disks object to provide input for Set-AzMigrateServerReplication
