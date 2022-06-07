### Example 1: Get all backup vaults in a given subscription
```powershell
Get-AzDataProtectionBackupVault
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name                          Type
---- -------------------                  ----------------                     ------------   --------      ----                          ----
<<<<<<< HEAD
     2a21f108-07bc-4c22-a221-f26c9de554ba 72f988bf-86f1-41af-91ab-2d7cd011db47 SystemAssigned westus        adigupt-backupcenter-ga-Vault Microsoft.DataProtection/backupV
     34237b3f-8f2c-4ae7-bbff-2896491976fb 72f988bf-86f1-41af-91ab-2d7cd011db47 SystemAssigned westcentralus BC-Usability-Vault-WCUS       Microsoft.DataProtection/backupV
     41155247-420f-4052-a894-84814f0b983c 72f988bf-86f1-41af-91ab-2d7cd011db47 SystemAssigned centraluseuap NilayBackupVault              Microsoft.DataProtection/backupV
     26da260b-e232-419c-8586-9157e4f6260e 72f988bf-86f1-41af-91ab-2d7cd011db47 SystemAssigned centraluseuap dpprunnervaultus              Microsoft.DataProtection/backupV
=======
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned westus        adigupt-backupcenter-ga-Vault Microsoft.DataProtection/backupVault
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned westcentralus BC-Usability-Vault-WCUS       Microsoft.DataProtection/backupVault
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap NilayBackupVault              Microsoft.DataProtection/backupVault
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap dpprunnervaultus              Microsoft.DataProtection/backupVault
>>>>>>> 8f02f59635 (Added support for Resource Guard create/update/remove)
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

