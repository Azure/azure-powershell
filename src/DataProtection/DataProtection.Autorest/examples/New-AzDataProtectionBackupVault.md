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
$storagesetting = New-AzDataProtectionBackupVaultStorageSettingObject -DataStoreType "<DataStoreType>" -Type "<Type>"
$userAssignedIdentity = @{
    "<userAssignedId1>" = @{
        clientId = "<clientId1>"
        principalId = "<principalId1>"
    }
    "<userAssignedId2>" = @{
        clientId = "<clientId2>"
        principalId = "<principalId2>"
    }
}
New-AzDataProtectionBackupVault -SubscriptionId <subscriptionId> -ResourceGroupName <resourceGroupName> -VaultName <vaultName> -Location <location> -StorageSetting $storagesetting -IdentityType UserAssigned -UserAssignedIdentity $userAssignedIdentity -CmkEncryptionState Enabled -CmkIdentityType UserAssigned -CmkUserAssignedIdentityId <cmkUserAssignedIdentityId> -CmkEncryptionKeyUri <cmkEncryptionKeyUri>  -CmkInfrastructureEncryption Enabled
```

```output
Name      Location   IdentityType
--------  --------   ------------
vaultName location   UserAssigned
```

This command creates a backup vault with CMK encryption enabled


