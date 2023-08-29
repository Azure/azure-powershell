### Example 1: Undelete the soft deleted backup instance
```powershell
$softDeletedBI = Get-AzDataProtectionSoftDeletedBackupInstance -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName
Undo-AzDataProtectionBackupInstanceDeletion -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $softDeletedBI[0].Name 
```

The first comamnd is used to fetch the backup instances which are in soft deleted for a give backup vault.
The second command undeletes the backup instance to enable the protection again, revert the soft deleted state.
