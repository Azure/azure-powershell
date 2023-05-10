### Example 1: Make disks
```powershell
New-AzMigrateDiskMapping -DiskID a -DiskType Standard -IsOSDisk 'true'
```

```output
DiskEncryptionSetId DiskId   DiskType  IsOSDisk LogStorageAccountId LogStorageAccountSasSecretName  
------------------- ------   --------  -------- ------------------- ------------------------------   
                      a      Standard  true  
```

Get disks object to provide input for New-AzMigrateServerReplication


