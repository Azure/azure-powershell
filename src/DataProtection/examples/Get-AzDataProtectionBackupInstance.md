### Example 1: Get all the backup instances protected in a specified backup vault.
```powershell
PS C:\> Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault"
```

```output
Name                                                         Type                                                  BackupInstanceName
----                                                         ----                                                  ------------------
sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx   Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
sarathdisk2-sarathdisk2-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxcc Microsoft.DataProtection/backupVaults/backupInstances sarathdisk2-sarathdisk2-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

This command gets all the backup instances in a vault.

### Example 2: Get a backup instance by name.
```powershell
PS C:\> Get-AzDataProtectionBackupInstance -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault" -Name "BackupInstanceName"
```

```output
Name                                                       Type                                                  BackupInstanceName
----                                                       ----                                                  ------------------
sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.DataProtection/backupVaults/backupInstances sarathdisk-sarathdisk-xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

This command gets a specific backup instance protected in a backup vault.

