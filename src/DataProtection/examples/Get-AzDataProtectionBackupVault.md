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

