### Example 1: Get all backup vaults in a given subscription
```powershell
Get-AzDataProtectionBackupVault
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name                          Type
---- -------------------                  ----------------                     ------------   --------      ----                          ----
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned westus        adigupt-backupcenter-ga-Vault Microsoft.DataProtection/backupVault
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned westcentralus BC-Usability-Vault-WCUS       Microsoft.DataProtection/backupVault
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap NilayBackupVault              Microsoft.DataProtection/backupVault
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap dpprunnervaultus              Microsoft.DataProtection/backupVault
```

This command gets all backup vaults in current subscription context. Provide SubscriptionId parameter to retrieve backup vaults in a different subscription.

### Example 2: Get all backup vaults in a given resource Group.
```powershell
Get-AzDataProtectionBackupVault -SubscriptionId "xxxx-xxx-xxxx" -ResourceGroupName sarath-rg
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name            Type
---- -------------------                  ----------------                     ------------   --------      ----            ----
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap sarath-dppvault Microsoft.DataProtection/backupVaults
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap sarath-vault    Microsoft.DataProtection/backupVaults
```

This command gets all backup vaults in a given resource group.

### Example 3: Get a specific vault.
```powershell
Get-AzDataProtectionBackupVault -SubscriptionId "xxxx-xxx-xxxx" -ResourceGroupName sarath-rg -VaultName sarath-vault
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name            Type
---- -------------------                  ----------------                     ------------   --------      ----            ----
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap sarath-vault    Microsoft.DataProtection/backupVaults
```

This command gets a specific vault by given vault name.

### Example 4: Get secure score of backup vault.
```powershell
$vault = Get-AzDataProtectionBackupVault -SubscriptionId "xxxx-xxx-xxxx" -ResourceGroupName hiaga-rg -VaultName hiaga-vault
$vault.SecureScore
```

```output
Adequate
```

First command gets a specific vault by given vault name, then we fetch the secure score of the vault which shows Adequate.

### Example 4: Get encryption settings of backup vault.
```powershell
$vault = Get-AzDataProtectionBackupVault -SubscriptionId "xxxx-xxx-xxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName"
$vault.EncryptionSetting |fl
$vault.EncryptionSetting.CmkIdentity |fl
$vault.EncryptionSetting.CmkKeyVaultProperty |fl
```

```output
CmkIdentity                 : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.CmkKekIdentity
CmkInfrastructureEncryption : Enabled
CmkKeyVaultProperty         : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.CmkKeyVaultProperties
State                       : Enabled

IdentityId   : /subscriptions/191973cd-9c54-41e0-ac19-25dd9a92d5a8/resourcegroups/jeevan-wrk-vms/providers/Microsoft.ManagedIdentity/userAssignedIdentities
               /userMSIpstest
IdentityType : UserAssigned

KeyUri : https://jeevantestkeyvaultcmk.vault.azure.net/keys/pstest/3cd5235ad6ac4c11b40a6f35444bcbe1
```

First command gets a specific vault by given vault name, subsequent three commands fetch the specity properites of encryption settings.