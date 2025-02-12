### Example 1: Make Standard disks
```powershell
New-AzMigrateDiskMapping -DiskID a -DiskType Standard_LRS -IsOSDisk 'true'
```

```output
DiskEncryptionSetId DiskId DiskType     IsOSDisk LogStorageAccountId LogStorageAccountSasSecretName  
------------------- ------ --------     -------- ------------------- ------------------------------   
                    a      Standard_LRS true
```

### Example 2: Make Premium V2 disks
```powershell
New-AzMigrateDiskMapping -DiskID b -DiskType PremiumV2_LRS -IsOSDisk 'false'
```

```output
DiskEncryptionSetId DiskId DiskType      IsOSDisk LogStorageAccountId LogStorageAccountSasSecretName  
------------------- ------ --------      -------- ------------------- ------------------------------   
                    b      PremiumV2_LRS false
```

Get disks object to provide input for New-AzMigrateServerReplication
