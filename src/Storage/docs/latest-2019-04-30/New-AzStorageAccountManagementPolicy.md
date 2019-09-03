---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstorageaccountmanagementpolicy
schema: 2.0.0
---

# New-AzStorageAccountManagementPolicy

## SYNOPSIS
Sets the managementpolicy to the specified storage account.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageAccountManagementPolicy -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-PolicyRule <IManagementPolicyRule[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzStorageAccountManagementPolicy -Name <String> -ResourceGroupName <String> -Property <IManagementPolicy>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzStorageAccountManagementPolicy -InputObject <IStorageIdentity> -Property <IManagementPolicy>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStorageAccountManagementPolicy -InputObject <IStorageIdentity> [-PolicyRule <IManagementPolicyRule[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Sets the managementpolicy to the specified storage account.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

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
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PolicyRule
The Storage Account ManagementPolicies Rules.
See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
To construct, see NOTES section for POLICYRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IManagementPolicyRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Property
The Get Storage Account ManagementPolicies operation response.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IManagementPolicy
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IManagementPolicy

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IManagementPolicy

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IStorageIdentity>: Identity Parameter
  - `[AccountName <String>]`: The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  - `[BlobServicesName <String>]`: The name of the blob Service within the specified storage account. Blob Service Name must be 'default'
  - `[ContainerName <String>]`: The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  - `[FileServicesName <String>]`: The name of the file Service within the specified storage account. File Service Name must be "default"
  - `[Id <String>]`: Resource identity path
  - `[ImmutabilityPolicyName <String>]`: The name of the blob container immutabilityPolicy within the specified storage account. ImmutabilityPolicy Name must be 'default'
  - `[Location <String>]`: The location of the Azure Storage resource.
  - `[ManagementPolicyName <ManagementPolicyName?>]`: The name of the Storage Account Management Policy. It should always be 'default'
  - `[ResourceGroupName <String>]`: The name of the resource group within the user's subscription. The name is case insensitive.
  - `[ShareName <String>]`: The name of the file share within the specified storage account. File share names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

#### POLICYRULE <IManagementPolicyRule[]>: The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
  - `DeleteDaysAfterCreationGreaterThan <Single>`: Value indicating the age in days after creation
  - `DeleteDaysAfterModificationGreaterThan <Single>`: Value indicating the age in days after last modification
  - `FilterBlobType <String[]>`: An array of predefined enum values. Only blockBlob is supported.
  - `Name <String>`: A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
  - `TierToArchiveDaysAfterModificationGreaterThan <Single>`: Value indicating the age in days after last modification
  - `TierToCoolDaysAfterModificationGreaterThan <Single>`: Value indicating the age in days after last modification
  - `[Enabled <Boolean?>]`: Rule is enabled if set to true.
  - `[FilterPrefixMatch <String[]>]`: An array of strings for prefixes to be match.

#### PROPERTY <IManagementPolicy>: The Get Storage Account ManagementPolicies operation response.
  - `PolicyRule <IManagementPolicyRule[]>`: The Storage Account ManagementPolicies Rules. See more details in: https://docs.microsoft.com/en-us/azure/storage/common/storage-lifecycle-managment-concepts.
    - `DeleteDaysAfterCreationGreaterThan <Single>`: Value indicating the age in days after creation
    - `DeleteDaysAfterModificationGreaterThan <Single>`: Value indicating the age in days after last modification
    - `FilterBlobType <String[]>`: An array of predefined enum values. Only blockBlob is supported.
    - `Name <String>`: A rule name can contain any combination of alpha numeric characters. Rule name is case-sensitive. It must be unique within a policy.
    - `TierToArchiveDaysAfterModificationGreaterThan <Single>`: Value indicating the age in days after last modification
    - `TierToCoolDaysAfterModificationGreaterThan <Single>`: Value indicating the age in days after last modification
    - `[Enabled <Boolean?>]`: Rule is enabled if set to true.
    - `[FilterPrefixMatch <String[]>]`: An array of strings for prefixes to be match.

## RELATED LINKS

