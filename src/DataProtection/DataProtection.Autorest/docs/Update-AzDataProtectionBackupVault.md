---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/update-azdataprotectionbackupvault
schema: 2.0.0
---

# Update-AzDataProtectionBackupVault

## SYNOPSIS
Updates a BackupVault resource belonging to a resource group.
For example, updating tags for a resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDataProtectionBackupVault -ResourceGroupName <String> -VaultName <String> [-Token <String>] [-AsJob]
 [-AzureMonitorAlertsForAllJobFailure <AlertsState>] [-CmkEncryptionKeyUri <String>]
 [-CmkEncryptionState <EncryptionState>] [-CmkIdentityType <IdentityType>]
 [-CmkUserAssignedIdentityId <String>] [-CrossRegionRestoreState <CrossRegionRestoreState>]
 [-CrossSubscriptionRestoreState <CrossSubscriptionRestoreState>] [-DefaultProfile <PSObject>]
 [-IdentityType <String>] [-IdentityUserAssignedIdentity <Hashtable>] [-ImmutabilityState <ImmutabilityState>]
 [-NoWait] [-ResourceGuardOperationRequest <String[]>] [-SecureToken <SecureString>]
 [-SoftDeleteRetentionDurationInDay <Double>] [-SoftDeleteState <SoftDeleteState>] [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDataProtectionBackupVault -InputObject <IDataProtectionIdentity> [-Token <String>] [-AsJob]
 [-AzureMonitorAlertsForAllJobFailure <AlertsState>] [-CrossRegionRestoreState <CrossRegionRestoreState>]
 [-CrossSubscriptionRestoreState <CrossSubscriptionRestoreState>] [-DefaultProfile <PSObject>]
 [-EncryptionSetting <IEncryptionSettings>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-ImmutabilityState <ImmutabilityState>] [-NoWait]
 [-ResourceGuardOperationRequest <String[]>] [-SoftDeleteRetentionDurationInDay <Double>]
 [-SoftDeleteState <SoftDeleteState>] [-Tag <Hashtable>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a BackupVault resource belonging to a resource group.
For example, updating tags for a resource.

## EXAMPLES

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

The first command creates a new tag hashtable with tags and their values.
The second command adds the given tags to the backup vault.

### Example 2: Disable Azure monitor alerts for job failures
```powershell
Update-AzDataProtectionBackupVault -ResourceGroupName "rgName" -VaultName "vaultName" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -AzureMonitorAlertsForAllJobFailure 'Disabled'
```

```output
Name          Location      Type                                  IdentityType
----          --------      ----                                  ------------
vaultName southeastasia Microsoft.DataProtection/backupVaults SystemAssigned
```

This command disables the monitor alerts for all the job failures for the backup vault.
Allowed values are: Enabled, Disabled.
Note that by default this setting is enabled.

### Example 3: Update vault ImmutabilityState, CrossSubscriptionRestoreState, soft delete settings
```powershell
Update-AzDataProtectionBackupVault -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -CrossSubscriptionRestoreState Disabled -ImmutabilityState Disabled -SoftDeleteRetentionDurationInDay 99 -SoftDeleteState Off
```

```output
Name          Location      Type                                  IdentityType
----          --------      ----                                  ------------
vaultName southeastasia Microsoft.DataProtection/backupVaults SystemAssigned
```

This command is used to modify Immutability state, cross subscription restore state, soft delete settings of the vault.
These parameters are optional and can be used independently.

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

This command is used to modify CmkIdentityType and CmkEncryptionKeyUri.
These parameters are optional and can be used independently.

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

This command is used to change CmkIdentityType from SystemAssigned to UserAssgined.
CmkIdenityId is a required parameter.

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

First, create a hashtable for the User Assigned Managed Identity (UAMI) object.
This object maps the UAMI resource ID to a new instance of UserAssignedIdentity.
Next, use the Update-AzDataProtectionBackupVault cmdlet to assign the UAMI to the backup vault while keeping the System Assigned Managed Identity.
The -IdentityType parameter specifies that both SystemAssigned and UserAssigned identities are used.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureMonitorAlertsForAllJobFailure
Parameter to Enable or Disable built-in azure monitor alerts for job failures.
Security alerts cannot be disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.AlertsState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CmkEncryptionKeyUri
The Key URI of the CMK key to be used for encryption.
To enable auto-rotation of keys, exclude the version component from the Key URI.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CmkEncryptionState
Enable CMK encryption state for a Backup Vault.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.EncryptionState
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CmkIdentityType
The identity type to be used for CMK encryption - SystemAssigned or UserAssigned Identity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.IdentityType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CmkUserAssignedIdentityId
This parameter is required if the identity type is UserAssigned.
Add the user assigned managed identity id to be used which has access permissions to the Key Vault.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CrossRegionRestoreState
Cross region restore state of the vault.
Allowed values are Disabled, Enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CrossRegionRestoreState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CrossSubscriptionRestoreState
Cross subscription restore state of the vault.
Allowed values are Disabled, Enabled, PermanentlyDisabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.CrossSubscriptionRestoreState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionSetting
Customer Managed Key details of the resource.
To construct, see NOTES section for ENCRYPTIONSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IEncryptionSettings
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identityType which can be either SystemAssigned, UserAssigned, 'SystemAssigned,UserAssigned' or None

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
Gets or sets the user assigned identities.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases: UserAssignedIdentity, AssignUserIdentity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImmutabilityState
Immutability state of the vault.
Allowed values are Disabled, Unlocked, Locked.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ImmutabilityState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGuardOperationRequest
ResourceGuardOperationRequests on which LAC check will be performed

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecureToken
Parameter to authorize operations protected by cross tenant resource guard.
Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -AsSecureString").Token to fetch authorization token for different tenant.

```yaml
Type: System.Security.SecureString
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeleteRetentionDurationInDay
Soft delete retention duration in days.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeleteState
Soft delete state of the vault.
Allowed values are Off, On, AlwaysOn.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.SoftDeleteState
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Token
Parameter to authorize operations protected by cross tenant resource guard.
Use command (Get-AzAccessToken -TenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx").Token to fetch authorization token for different tenant.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VaultName
The name of the backup vault.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupVaultResource

## NOTES

## RELATED LINKS

