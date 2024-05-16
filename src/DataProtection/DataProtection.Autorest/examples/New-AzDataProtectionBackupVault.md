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

### Example 2: Create a new backup vault with ImmutabilityState, CrossSubscriptionRestoreState, soft delete settings
```powershell
$sub = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
$storagesetting = New-AzDataProtectionBackupVaultStorageSettingObject -DataStoreType VaultStore -Type LocallyRedundant
New-AzDataProtectionBackupVault -SubscriptionId $sub -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -Location westus -StorageSetting $storagesetting -CrossSubscriptionRestoreState Enabled -ImmutabilityState Unlocked -SoftDeleteRetentionDurationInDay 100 -SoftDeleteState On
```

```output
ETag IdentityPrincipalId IdentityTenantId IdentityType Location Name    Type
---- ------------------- ---------------- ------------ -------- ----    ----
                                                       westus   MyVault Microsoft.DataProtection/backupVaults
```

This command creates a new backup vault while setting Immutability state, cross subscription restore state, soft delete settings of the vault at creation time.

### Example 3: Create a Backup Vault with CMK
```powershell
$storagesetting = New-AzDataProtectionBackupVaultStorageSettingObject -DataStoreType VaultStore -Type LocallyRedundant
$userAssignedIdentity = @{
    "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/samplerg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sampleuami" = @{
        clientId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
        principalId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
    }
    "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/samplerg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sampleuami2" = @{
        clientId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
        principalId = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
    }
}

$cmkIdentityId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/samplerg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sampleuami"

$cmkKeyUri = "https://samplekvazbckp.vault.azure.net/keys/testkey/3cd5235ad6ac4c11b40a6f35444bcbe1"

New-AzDataProtectionBackupVault -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -Location "location" -StorageSetting $storagesetting -IdentityType UserAssigned -UserAssignedIdentity $userAssignedIdentity -CmkEncryptionState Enabled -CmkIdentityType UserAssigned -CmkUserAssignedIdentityId $cmkIdentityId -CmkEncryptionKeyUri $cmkKeyUri -CmkInfrastructureEncryption Enabled
```

```output
Name      Location   IdentityType
--------  --------   ------------
vaultName location   UserAssigned
```

This command creates a backup vault with CMK encryption enabled


