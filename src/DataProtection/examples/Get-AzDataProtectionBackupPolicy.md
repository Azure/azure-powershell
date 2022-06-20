### Example 1: Get all backup policies in a backup vault.
```powershell
Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault"
```

```output
Name              Type
----              ----
DiskPolicy1       Microsoft.DataProtection/backupVaults/backupPolicies
DiskDailyPolicy   Microsoft.DataProtection/backupVaults/backupPolicies
```

This command gets backup policies created in a given backup vault.

### Example 2: Get backup policy by Name
```powershell
Get-AzDataProtectionBackupPolicy -SubscriptionId "xxxx-xxx-xxx" -ResourceGroupName "MyResourceGroup" -VaultName "MyVault" -Name "MyPolicy"
```

```output
Name        Type
----        ----
MyPolicy Microsoft.DataProtection/backupVaults/backupPolicies
```

This command gets a backup policy by name.

