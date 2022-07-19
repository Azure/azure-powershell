### Example 1: Create a new backup vault
```powershell
$sub = "xxxx-xxxx-xxxxx"
$storagesetting = New-AzDataProtectionBackupVaultStorageSettingObject -DataStoreType VaultStore -Type LocallyRedundant
New-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName sarath-rg -VaultName "MyVault" -StorageSetting $storagesetting -Location westus
```

```output
ETag IdentityPrincipalId IdentityTenantId IdentityType Location Name    Type
---- ------------------- ---------------- ------------ -------- ----    ----
                                                       westus   MyVault Microsoft.DataProtection/backupVaults
```

This command creates a new backup vault.

