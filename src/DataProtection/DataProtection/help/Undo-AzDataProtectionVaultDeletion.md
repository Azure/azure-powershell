---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/undo-azdataprotectionvaultdeletion
schema: 2.0.0
---

# Undo-AzDataProtectionVaultDeletion

## SYNOPSIS
Undeletes a soft deleted backup vault

## SYNTAX

```
Undo-AzDataProtectionVaultDeletion -DeletedVaultName <String> -Location <String> [-SubscriptionId <String>]
 [-ResourceGroupName <String>] [-IdentityType <String>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Undeletes a soft deleted backup vault

## EXAMPLES

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

### -DeletedVaultName
Deleted vault name (GUID) of the soft deleted vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DeletedVaultGUID

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identityType can take values - "SystemAssigned", "UserAssigned", "SystemAssigned,UserAssigned", "None".

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
Aliases: AssignUserIdentity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the deleted vault

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
Resource Group Name to validate against the deleted vault.
Used to ensure the correct vault is selected.

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

### -SubscriptionId
Subscription Id of the deleted vault

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupVaultResource

## NOTES

## RELATED LINKS
