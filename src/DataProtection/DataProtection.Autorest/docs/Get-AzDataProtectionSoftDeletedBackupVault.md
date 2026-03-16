---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/get-azdataprotectionsoftdeletedbackupvault
schema: 2.0.0
---

# Get-AzDataProtectionSoftDeletedBackupVault

## SYNOPSIS
Gets a deleted backup vault

## SYNTAX

### List (Default)
```
Get-AzDataProtectionSoftDeletedBackupVault -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDataProtectionSoftDeletedBackupVault -DeletedVaultName <String> -Location <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzDataProtectionSoftDeletedBackupVault -DeletedVaultName <String>
 -LocationInputObject <IDataProtectionIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a deleted backup vault

## EXAMPLES

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

## PARAMETERS

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

### -DeletedVaultName
The name of the DeletedBackupVaultResource

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDeletedBackupVaultResource

## NOTES

## RELATED LINKS

