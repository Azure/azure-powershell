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
Update-AzDataProtectionBackupVault -ResourceGroupName "rgName" -VaultName "vaultName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -AzureMonitorAlertsForAllJobFailure 'Disabled'
```

```output
Name          Location      Type                                  IdentityType
----          --------      ----                                  ------------
vaultName southeastasia Microsoft.DataProtection/backupVaults SystemAssigned
```

This command disables the monitor alerts for all the job failures for the backup vault. Allowed values are: Enabled, Disabled. Note that by default this setting is enabled. 

### Example 3: Update vault ImmutabilityState, CrossSubscriptionRestoreState, soft delete settings
```powershell
Update-AzDataProtectionBackupVault -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -CrossSubscriptionRestoreState Disabled -ImmutabilityState Disabled -SoftDeleteRetentionDurationInDay 99 -SoftDeleteState Off
```

```output
Name          Location      Type                                  IdentityType
----          --------      ----                                  ------------
vaultName southeastasia Microsoft.DataProtection/backupVaults SystemAssigned
```

This command is used to modify Immutability state, cross subscription restore state, soft delete settings of the vault. These parameters are optional and can be used independently.

### Example 4: Update vault CmkIdentityType from UserAssignedManagedIdentity to SystemAssignedManagedIdentity and CmkEncryptionKeyUri
```powershell
$cmkKeyUri = "https://samplekvazbckp.vault.azure.net/keys/testkey/3cd5235ad6ac4c11b40a6f35444bcbe1"

Update-AzDataProtectionBackupVault -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -CmkIdentityType SystemAssigned -CmkEncryptionKeyUri $cmkKeyUri
```

```output
Name          Location      Type                                  IdentityType
----          --------      ----                                  ------------
vaultName southeastasia Microsoft.DataProtection/backupVaults SystemAssigned
```

This command is used to modify CmkIdentityType and CmkEncryptionKeyUri. These parameters are optional and can be used independently.

### Example 5: Update vault CmkIdentityType from SystemAssignedManagedIdentity to UserAssignedManagedIdentity
```powershell
$cmkIdentityId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/samplerg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sampleuami"

Update-AzDataProtectionBackupVault -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -CmkIdentityType UserAssigned -CmkUserAssignedIdentityId $cmkIdentityId
```

```output
Name          Location      Type                                  IdentityType
----          --------      ----                                  ------------
vaultName southeastasia Microsoft.DataProtection/backupVaults UserAssigned
```

This command is used to change CmkIdentityType from SystemAssigned to UserAssgined. CmkIdenityId is a required parameter.

### Example 6: Update vault to assign a User Assigned Managed Identity (UAMI)
```powershell
$UAMI = @{"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/resourceGroupName/providers/Microsoft.ManagedIdentity/userAssignedIdentities/userAssignedIdentityName"=[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api40.UserAssignedIdentity]::new()}

$vault = Update-AzDataProtectionBackupVault -AssignUserIdentity $UAMI -SubscriptionId "00000000-0000-0000-0000-000000000000" -VaultName "vaultName" -ResourceGroupName "resourceGroupName" -IdentityType 'SystemAssigned,UserAssigned'
```

```output
Name          Location      Type                                  IdentityType
----          --------      ----                                  ------------
vaultName southeastasia Microsoft.DataProtection/backupVaults SystemAssigned, UserAssigned
```

First, create a hashtable for the User Assigned Managed Identity (UAMI) object. This object maps the UAMI resource ID to a new instance of UserAssignedIdentity.
Next, use the Update-AzDataProtectionBackupVault cmdlet to assign the UAMI to the backup vault while keeping the System Assigned Managed Identity. The -IdentityType parameter specifies that both SystemAssigned and UserAssigned identities are used.
