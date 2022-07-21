### Example 1: Add tags to an existing backup vault
```powershell
$tag = @{"Owner"="sarath";"Purpose"="AzureBackupTesting"}
Update-AzDataProtectionBackupVault -SubscriptionId "xxx-xxx-xxx" -ResourceGroupName sarath-rg -VaultName sarath-vault -Tag $tag
```

```output
ETag IdentityPrincipalId                  IdentityTenantId                     IdentityType   Location      Name         Type
---- -------------------                  ----------------                     ------------   --------      ----         ----
     2ca1d5f7-38b3-4b61-aa45-8147d7e0edbc 72f988bf-86f1-41af-91ab-2d7cd011db47 SystemAssigned centraluseuap sarath-vault Microsoft.DataProtection/backupVaults
```

The first command creates a new tag hashtable with tags and their values. The second command adds the given tags to the backup vault.

### Example 2: Disable Azure monitor alerts for job failures
```powershell
PS C:\>  Update-AzDataProtectionBackupVault -ResourceGroupName "rgName" -VaultName "vaultName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -AzureMonitorAlertsForAllJobFailure 'Disabled'

Name          Location      Type                                  IdentityType
----          --------      ----                                  ------------
vaultName southeastasia Microsoft.DataProtection/backupVaults SystemAssigned
```

This command disables the monitor alerts for all the job failures for the backup vault. Allowed values are: Enabled, Disabled. Note that by default this setting is enabled. 
