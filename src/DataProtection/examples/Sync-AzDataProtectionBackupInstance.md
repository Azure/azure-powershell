### Example 1: Sync backup instance again in case of failure
```powershell
PS C:\> Sync-AzDataProtectionBackupInstance -ResourceGroupName "rgName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName "vaultName" -BackupInstanceName $backupInstance.BackupInstanceName
```
 
 The above command is used to sync backup instance again in case of failure. This action will retry last failed operation and will bring backup instance to valid state.

