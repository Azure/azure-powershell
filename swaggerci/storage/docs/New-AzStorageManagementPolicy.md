---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstoragemanagementpolicy
schema: 2.0.0
---

# New-AzStorageManagementPolicy

## SYNOPSIS
Sets the managementpolicy to the specified storage account.

## SYNTAX

```
New-AzStorageManagementPolicy -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-PolicyRule <IManagementPolicyRule[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Sets the managementpolicy to the specified storage account.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -PolicyRule
The Storage Account ManagementPolicies Rules.
See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
To construct, see NOTES section for POLICYRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210901.IManagementPolicyRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20210901.IManagementPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


POLICYRULE <IManagementPolicyRule[]>: The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
  - `DefinitionAction <IManagementPolicyAction>`: An object that defines the action set.
    - `[BaseBlobDeleteDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after blob creation.
    - `[BaseBlobDeleteDaysAfterLastTierChangeGreaterThan <Single?>]`: Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions and requires daysAfterModificationGreaterThan to be set for baseBlobs based actions. The blob will be archived if both the conditions are satisfied.
    - `[BaseBlobEnableAutoTierToHotFromCool <Boolean?>]`: This property enables auto tiering of a blob from cool to hot on a blob access. This property requires tierToCool.daysAfterLastAccessTimeGreaterThan.
    - `[BaseBlobTierToArchiveDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after blob creation.
    - `[BaseBlobTierToArchiveDaysAfterLastTierChangeGreaterThan <Single?>]`: Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions and requires daysAfterModificationGreaterThan to be set for baseBlobs based actions. The blob will be archived if both the conditions are satisfied.
    - `[BaseBlobTierToCoolDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after blob creation.
    - `[BaseBlobTierToCoolDaysAfterLastTierChangeGreaterThan <Single?>]`: Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions and requires daysAfterModificationGreaterThan to be set for baseBlobs based actions. The blob will be archived if both the conditions are satisfied.
    - `[DeleteDaysAfterLastAccessTimeGreaterThan <Single?>]`: Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
    - `[DeleteDaysAfterModificationGreaterThan <Single?>]`: Value indicating the age in days after last modification
    - `[SnapshotDeleteDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[SnapshotDeleteDaysAfterLastTierChangeGreaterThan <Single?>]`: Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions and requires daysAfterCreationGreaterThan to be set for snapshots and blob version based actions. The blob will be archived if both the conditions are satisfied.
    - `[SnapshotTierToArchiveDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[SnapshotTierToArchiveDaysAfterLastTierChangeGreaterThan <Single?>]`: Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions and requires daysAfterCreationGreaterThan to be set for snapshots and blob version based actions. The blob will be archived if both the conditions are satisfied.
    - `[SnapshotTierToCoolDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[SnapshotTierToCoolDaysAfterLastTierChangeGreaterThan <Single?>]`: Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions and requires daysAfterCreationGreaterThan to be set for snapshots and blob version based actions. The blob will be archived if both the conditions are satisfied.
    - `[TierToArchiveDaysAfterLastAccessTimeGreaterThan <Single?>]`: Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
    - `[TierToArchiveDaysAfterModificationGreaterThan <Single?>]`: Value indicating the age in days after last modification
    - `[TierToCoolDaysAfterLastAccessTimeGreaterThan <Single?>]`: Value indicating the age in days after last blob access. This property can only be used in conjunction with last access time tracking policy
    - `[TierToCoolDaysAfterModificationGreaterThan <Single?>]`: Value indicating the age in days after last modification
    - `[VersionDeleteDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[VersionDeleteDaysAfterLastTierChangeGreaterThan <Single?>]`: Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions and requires daysAfterCreationGreaterThan to be set for snapshots and blob version based actions. The blob will be archived if both the conditions are satisfied.
    - `[VersionTierToArchiveDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[VersionTierToArchiveDaysAfterLastTierChangeGreaterThan <Single?>]`: Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions and requires daysAfterCreationGreaterThan to be set for snapshots and blob version based actions. The blob will be archived if both the conditions are satisfied.
    - `[VersionTierToCoolDaysAfterCreationGreaterThan <Single?>]`: Value indicating the age in days after creation
    - `[VersionTierToCoolDaysAfterLastTierChangeGreaterThan <Single?>]`: Value indicating the age in days after last blob tier change time. This property is only applicable for tierToArchive actions and requires daysAfterCreationGreaterThan to be set for snapshots and blob version based actions. The blob will be archived if both the conditions are satisfied.
  - `Name <String>`: A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
  - `[Enabled <Boolean?>]`: Rule is enabled if set to true.
  - `[FilterBlobIndexMatch <ITagFilter[]>]`: An array of blob index tag based filters, there can be at most 10 tag filters
    - `Name <String>`: This is the filter tag name, it can have 1 - 128 characters
    - `Op <String>`: This is the comparison operator which is used for object comparison and filtering. Only == (equality operator) is currently supported
    - `Value <String>`: This is the filter tag value field used for tag based filtering, it can have 0 - 256 characters
  - `[FilterBlobType <String[]>]`: An array of predefined enum values. Currently blockBlob supports all tiering and delete actions. Only delete actions are supported for appendBlob.
  - `[FilterPrefixMatch <String[]>]`: An array of strings for prefixes to be match.

## RELATED LINKS

