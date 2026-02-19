### Example 1: Get deleted backup vaults in a specific location
```powershell
Get-AzDataProtectionSoftDeletedBackupVault -Location "eastasia" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

```output
Location                             : eastasia
OriginalBackupVaultResourceGroup     : sample-resourcegroup
AzureMonitorAlertsForAllJobFailure   :
BcdrSecurityLevel                    :
CrossRegionRestoreState              :
CrossSubscriptionRestoreState        : Enabled
EncryptionSetting                    : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.EncryptionSettings                                       
Id                                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.DataProtection/locations/eastasia/deletedVaults/yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy                                       
ImmutabilityState                    : Disabled
IsVaultProtectedByResourceGuard      : False
Name                                 : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
OriginalBackupVaultId                : zzzzzzzz-zzzz-zzzz-zzzz-zzzzzzzzzzzz
OriginalBackupVaultName              : sample-backupvault
OriginalBackupVaultResourcePath      : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/sample-resourcegroup/providers/Microsoft.DataProtection/BackupVaults/sample-backupvault
ProvisioningState                    : Succeeded
ReplicatedRegion                     :
ResourceDeletionInfo                 : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.ResourceDeletionInfo
ResourceGuardOperationRequest        :
ResourceMoveDetailCompletionTimeUtc  :
ResourceMoveDetailOperationId        :
ResourceMoveDetailSourceResourcePath :
ResourceMoveDetailStartTimeUtc       :
ResourceMoveDetailTargetResourcePath :
ResourceMoveState                    :
SecureScore                          :
SoftDeleteRetentionDurationInDay     : 14
SoftDeleteState                      : AlwaysOn
StorageSetting                       : {Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.StorageSetting}
SystemData                           : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api50.SystemData
Type                                 : Microsoft.DataProtection/locations/deletedVaults
```

This command retrieves all deleted backup vaults in the "eastasia" location for the specified subscription.