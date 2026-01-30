---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/search-azdataprotectionsoftdeletedvaultbackupinstanceinazgraph
schema: 2.0.0
---

# Search-AzDataProtectionSoftDeletedVaultBackupInstanceInAzGraph

## SYNOPSIS
Gets soft deleted backup instances from a deleted vault using Azure Resource Graph

## SYNTAX

```
Search-AzDataProtectionSoftDeletedVaultBackupInstanceInAzGraph [-Subscription <String[]>]
 [-DeletedVaultName <String>] [-DeletedVaultId <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets soft deleted backup instances from a deleted vault using Azure Resource Graph

## EXAMPLES

### Example 1: Search for soft-deleted backup instances using vault GUID from deleted vault
```powershell
$deletedVaults = Get-AzDataProtectionSoftDeletedBackupVault -Location "westus" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
$vaultGuid = $deletedVaults[0].Name
$deletedBI = Search-AzDataProtectionSoftDeletedVaultBackupInstanceInAzGraph -Subscription "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -DeletedVaultName $vaultGuid
$deletedBI | Format-List
```

```output
CurrentProtectionState        : SoftDeleted
DataSourceInfo                : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.Datasource
DataSourceSetInfo             : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.DatasourceSet
DatasourceAuthCredentials     : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.AuthCredentials
DeletionInfo                  : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.DeletionInfo
FriendlyName                  : postgres-db-production-backup-vault-01\postgres-db-production
Id                            : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.DataProtection/locations/westus/deletedVaults/b7e6f8a9-c5d4-4e3f-9a8b-1c2d3e4f5a6b/deletedBackupInstances/postgres-db-production-backup-vault-01-a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d
IdentityDetail                : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.IdentityDetails
Name                          : postgres-db-production-backup-vault-01-a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d
ObjectType                    : DeletedBackupInstance
PolicyInfo                    : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.PolicyInfo
ProtectionErrorDetail         : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.UserFacingError
ProtectionStatus              : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20250901.ProtectionStatusDetails
ProvisioningState             : Succeeded
ResourceGuardOperationRequest :
SystemData                    : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api50.SystemData
Type                          : microsoft.dataprotection/locations/deletedvaults/deletedbackupinstances
ValidationType                :
```

Retrieves deleted backup vaults, extracts the vault GUID (Name property), and searches for soft-deleted backup instances within that vault.

### Example 2: Search for soft-deleted backup instances using deleted vault object
```powershell
$deletedVaults = Get-AzDataProtectionSoftDeletedBackupVault -Location "westus" -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
$deletedBI = Search-AzDataProtectionSoftDeletedVaultBackupInstanceInAzGraph -DeletedVaultId $deletedVaults[0].Id -Subscription "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
$deletedBI | Select-Object Name, FriendlyName, CurrentProtectionState
```

```output
Name                                                                                                 FriendlyName                      CurrentProtectionState
----                                                                                                 ------------                      ----------------------
vm-backup-vault-vm-backup-vault-f1e2d3c4-b5a6-4789-a0b1-c2d3e4f5a6b7                               backup-vault-01\vm-prod-server    SoftDeleted
disk-backup-vault-disk-backup-vault-a9b8c7d6-e5f4-4321-9876-543210fedcba                           backup-vault-01\disk-data-01      SoftDeleted
```

Retrieves deleted backup vaults first, then searches for all soft-deleted backup instances within the first deleted vault by passing the vault ID from the deleted vault object.

## PARAMETERS

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

### -DeletedVaultId
Deleted Vault ARM Id

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

### -DeletedVaultName
Name of the deleted vault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DeletedVaultGUID

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subscription
Subscription of Deleted Vault

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS
