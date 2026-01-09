---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/new-azdataprotectionbackupvault
schema: 2.0.0
---

# New-AzDataProtectionBackupVault

## SYNOPSIS
Creates or updates a BackupVault resource belonging to a resource group.

## SYNTAX

```
New-AzDataProtectionBackupVault -Location <String> -ResourceGroupName <String>
 -StorageSetting <IStorageSetting[]> -VaultName <String> [-AsJob]
 [-AzureMonitorAlertsForAllJobFailure <String>] [-CmkEncryptionKeyUri <String>] [-CmkEncryptionState <String>]
 [-CmkIdentityType <String>] [-CmkInfrastructureEncryption <String>] [-CmkUserAssignedIdentityId <String>]
 [-CrossRegionRestoreState <String>] [-CrossSubscriptionRestoreState <String>] [-DefaultProfile <PSObject>]
 [-EnableSystemAssignedIdentity] [-ETag <String>] [-ImmutabilityState <String>] [-NoWait]
 [-SoftDeleteRetentionDurationInDay <Double>] [-SoftDeleteState <String>] [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a BackupVault resource belonging to a resource group.

## EXAMPLES

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
$storagesetting = New-AzDataProtectionBackupVaultStorageSettingObject -DataStoreType VaultStore -Type LocallyRedundant
$userAssignedIdentity = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/samplerg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sampleuami","/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/samplerg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sampleuami2"

$cmkIdentityId = "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/samplerg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/sampleuami"

$cmkKeyUri = "https://samplekvazbckp.vault.azure.net/keys/testkey/3cd5235ad6ac4c11b40a6f35444bcbe1"

New-AzDataProtectionBackupVault -SubscriptionId xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -ResourceGroupName "resourceGroupName" -VaultName "vaultName" -Location "location" -StorageSetting $storagesetting -UserAssignedIdentity $userAssignedIdentity -CmkEncryptionState Enabled -CmkIdentityType UserAssigned -CmkUserAssignedIdentityId $cmkIdentityId -CmkEncryptionKeyUri $cmkKeyUri -CmkInfrastructureEncryption Enabled
```

```output
Name      Location   IdentityType
--------  --------   ------------
vaultName location   UserAssigned
```

This command creates a backup vault with CMK encryption enabled

## PARAMETERS

### -AsJob


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
Type: System.String
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
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CmkInfrastructureEncryption
Enable infrastructure encryption with CMK on this vault.
Infrastructure encryption must be configured only when creating the vault.

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

### -CmkUserAssignedIdentityId
This parameter is required if the identity type is UserAssigned.
Add the user assigned managed identity id to be used which has access permissions to the Key Vault.

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

### -CrossRegionRestoreState
Cross region restore state of the vault.
Allowed values are Disabled, Enabled.

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

### -CrossSubscriptionRestoreState
Cross subscription restore state of the vault.
Allowed values are Disabled, Enabled, PermanentlyDisabled.

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

### -DefaultProfile


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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

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

### -ETag
Optional ETag.

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

### -ImmutabilityState
Immutability state of the vault.
Allowed values are Disabled, Unlocked, Locked.

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

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait


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
Resource Group Name of the backup vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SoftDeleteRetentionDurationInDay
Soft delete retention duration in days

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
Allowed values are Off, On, AlwaysOn

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

### -StorageSetting
Storage Settings of the vault.
Use New-AzDataProtectionBackupVaultStorageSetting Cmdlet to Create.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IStorageSetting[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription Id of the vault

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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.

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

### -VaultName
Name of the backup vault

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS

