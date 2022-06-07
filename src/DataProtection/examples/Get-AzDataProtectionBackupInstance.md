### Example 1: Get all the backup instances protected in a specified backup vault.
```powershell
<<<<<<< HEAD
Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault"
```
=======
PS C:\> Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault"
>>>>>>> 8f02f59635 (Added support for Resource Guard create/update/remove)

```output
Name                                                         Type                                                  BackupInstanceName
----                                                         ----                                                  ------------------
<<<<<<< HEAD
sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f166   Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-3df6ac08-9496-4839-8fb5-8b78e594f
sarathdisk2-sarathdisk2-74b127dc-7bf0-48ef-bcef-dab186cc6f10 Microsoft.DataProtection/backupVaults/backupInstances sarathdisk2-sarathdisk2-74b127dc-7bf0-48ef-bcef-dab186c
=======
sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx   Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
sarathdisk2-sarathdisk2-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxcc Microsoft.DataProtection/backupVaults/backupInstances sarathdisk2-sarathdisk2-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
>>>>>>> 8f02f59635 (Added support for Resource Guard create/update/remove)

```

This command gets all the backup instances in a vault.

### Example 2: Get a backup instance by name.
```powershell
<<<<<<< HEAD
Get-AzDataProtectionBackupInstance -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault" -Name "BackupInstanceName"
```
=======
PS C:\> Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault" -Name "BackupInstanceName"
>>>>>>> 8f02f59635 (Added support for Resource Guard create/update/remove)

```output
Name                                                       Type                                                  BackupInstanceName
----                                                       ----                                                  ------------------
sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

This command gets a specific backup instance protected in a backup vault.

