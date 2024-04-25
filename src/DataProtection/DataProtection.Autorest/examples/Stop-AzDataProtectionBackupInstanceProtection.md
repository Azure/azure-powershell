### Example 1: Stop protection for a backup instance
```powershell
Stop-AzDataProtectionBackupInstanceProtection -ResourceGroupName "rgName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -BackupInstanceName $backupInstance.BackupInstanceName
```

The above command can be used to stop protection of a backup instance
