### Example 1: Get soft deleted backup instances for a backup vault
```powershell
Get-AzDataProtectionSoftDeletedBackupInstance -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName
```

```output
Name
----
alrpstestvm-datadisk-000-xxxxxxxx-xxxx-alrpstestvm-datadisk-000-xxxx-xxxx-xxxxxxxx-066c-xxxx-91fc-xxxxxxxxxxxx
```

This cmdlet is used to fetch the list of backup instances which are in soft deleted state for the backup vault.
