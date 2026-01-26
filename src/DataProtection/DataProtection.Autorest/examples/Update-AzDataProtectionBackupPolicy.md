### Example 1: Update a backup policy belonging to a backup vault
```powershell
Update-AzDataProtectionBackupPolicy -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "ResourceGroupName" -VaultName "VaultName" -Name "MyPolicy"
```

```output
Name              Type
----              ----
MyPolicy       Microsoft.DataProtection/backupVaults/backupPolicies
```

Update a backup policy belonging to a backup vault
