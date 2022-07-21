### Example 1: Suspend backups for a backup instance
```powershell
PS C:\> Suspend-AzDataProtectionBackupInstanceBackup -ResourceGroupName "rgName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -BackupInstanceName $backupInstance.BackupInstanceName
```

 The above command can be used to stop backups of a backup instance, this will move the backup instance to a suspended state.

