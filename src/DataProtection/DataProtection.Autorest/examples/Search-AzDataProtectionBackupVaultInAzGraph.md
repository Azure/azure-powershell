### Example 1: Get a specific vault with its name.
```powershell
Search-AzDataProtectionBackupVaultInAzGraph -Subscription "xxxxxxxx-xxxx-xxxxxxxxxxxx" -ResourceGroup $resourceGroupName -Vault $vaultName
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name            Type
---- -------------------                  ----------------                     ------------   --------      ----            ----
     xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx SystemAssigned centraluseuap sarath-vault    Microsoft.DataProtection/backupVaults
```

This command gets a specific vault by given vault name from ARG (Azure Resource Graph).

