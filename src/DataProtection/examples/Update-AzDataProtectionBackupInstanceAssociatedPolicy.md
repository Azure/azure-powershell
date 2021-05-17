### Example 1: Update Associated policy of a backup instance
```powershell
PS C:\> $sub = "xxxx-xxxx-xxxx"
PS C:\> $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault
PS C:\> $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault
PS C:\> Update-AzDataProtectionBackupInstanceAssociatedPolicy -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName sarath-vault -BackupInstanceName $instance[0].Name -PolicyId $policy[1].Id

Name                                                         Type                                                  BackupInstanceName
----                                                         ----                                                  ------------------
sarathdisk2-sarathdisk2-2ba3c708-3648-45e2-809d-9f75e66d404f Microsoft.DataProtection/backupVaults/backupInstances sarathdisk2-sarathdisk2-2ba3c708-3648-45e2-809d-9f75e66
```

This command updates the associated policy of a backup instance

