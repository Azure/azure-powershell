### Example 1: Resume protection for a backup instance for which the protection state is ProtectionStopped
```powershell
PS C:\> Resume-AzDataProtectionBackupInstanceProtection -BackupInstanceName $backupInstance.BackupInstanceName -ResourceGroupName "rgName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName"
```

 The above command can be used to resume protection for a stopped or suspended backup instance

