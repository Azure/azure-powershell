### Example 1: Undo deletion of a backup vault using deleted vault properties
```powershell
$deletedVaults = Get-AzDataProtectionSoftDeletedBackupVault -Location "westus" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
$restoredVault = Undo-AzDataProtectionVaultDeletion -DeletedVaultName $deletedVaults[0].Name -Location $deletedVaults[0].Location -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName $deletedVaults[0].OriginalBackupVaultResourceGroup
$restoredVault | Format-List
```

```output
AzureMonitorAlertsForAllJobFailure   :
BcdrSecurityLevel                    : Good
CrossRegionRestoreState              :
CrossSubscriptionRestoreState        : Enabled
ETag                                 :
EncryptionSetting                    : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.EncryptionSettings
Id                                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/backup-rg/providers/Microsoft.DataProtection/backupVaults/backup-vault-01
IdentityPrincipalId                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
IdentityTenantId                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
IdentityType                         : SystemAssigned
IdentityUserAssignedIdentity         : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api50.DppIdentityDetailsUserAssignedIdentities
ImmutabilityState                    : Disabled
IsVaultProtectedByResourceGuard      : False
Location                             : westus
Name                                 : backup-vault-01
ProvisioningState                    : Succeeded
ReplicatedRegion                     : {}
ResourceGuardOperationRequest        :
ResourceMoveDetailCompletionTimeUtc  :
ResourceMoveDetailOperationId        :
ResourceMoveDetailSourceResourcePath :
ResourceMoveDetailStartTimeUtc       :
ResourceMoveDetailTargetResourcePath :
ResourceMoveState                    :
SecureScore                          : Adequate
SoftDeleteRetentionDurationInDay     : 120
SoftDeleteState                      : ALWAYSON
StorageSetting                       : {Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.StorageSetting}
SystemData                           : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api50.SystemData
Tag                                  : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api50.TrackedResourceTags
Type                                 : Microsoft.DataProtection/backupVaults
```

Retrieves deleted backup vaults from a location, selects the first vault, and undeletes it by undoing the deletion using the original vault properties.

### Example 2: Verify vault restoration workflow
```powershell
$deletedVaults = Get-AzDataProtectionSoftDeletedBackupVault -Location "eastus" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
Write-Host "Found $($deletedVaults.Count) deleted vault(s)"
$deletedVaults | Select-Object Name, OriginalBackupVaultName, OriginalBackupVaultResourceGroup

# Undo the deletion
$restoredVault = Undo-AzDataProtectionVaultDeletion -DeletedVaultName $deletedVaults[-1].Name -Location $deletedVaults[-1].Location -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName $deletedVaults[-1].OriginalBackupVaultResourceGroup

# Verify the vault is restored
$activeVault = Get-AzDataProtectionBackupVault -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -VaultName $deletedVaults[-1].OriginalBackupVaultName -ResourceGroupName $deletedVaults[-1].OriginalBackupVaultResourceGroup
$activeVault.Name
```

```output
Found 2 deleted vault(s)

Name                                 OriginalBackupVaultName      OriginalBackupVaultResourceGroup
----                                 -----------------------      --------------------------------
b7e6f8a9-c5d4-4e3f-9a8b-1c2d3e4f5a6b backup-vault-prod            backup-rg
a9b8c7d6-e5f4-4321-9876-543210fedcba backup-vault-dev             dev-rg

backup-vault-dev
```

Shows a complete workflow: lists deleted vaults with their original properties, restores the last deleted vault, and verifies restoration by querying the active vault.

