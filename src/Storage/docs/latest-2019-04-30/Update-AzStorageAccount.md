---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/update-azstorageaccount
schema: 2.0.0
---

# Update-AzStorageAccount

## SYNOPSIS
The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account.
It can also be used to map the account to a custom domain.
Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported.
In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set.
The update of multiple properties is supported.
This call does not change the storage keys for the account.
If you want to change the storage account keys, use the regenerate keys operation.
The location and name of the storage account cannot be changed after creation.

## SYNTAX

### UpdateExpanded1 (Default)
```
Update-AzStorageAccount -Name <String> -ResourceGroupName <String> -SkuName <SkuName>
 [-SubscriptionId <String>] [-AccessTier <AccessTier>] [-AssignIdentity] [-CustomDomainName <String>]
 [-EnableAzureFilesAadIntegration] [-EnableHttpsTrafficOnly] [-EncryptBlobService] [-EncryptFileService]
 [-EncryptQueueService] [-EncryptTableService] [-Kind <Kind>] [-NetworkRuleSetBypass <Bypass>]
 [-NetworkRuleSetDefaultAction <DefaultAction>] [-NetworkRuleSetIPRule <IIPRule[]>]
 [-NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>] [-NoEncryption] [-SkuKind <Kind>]
 [-SkuRestriction <IRestriction[]>] [-Tag <Hashtable>] [-UseSubDomain] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1KeyVaultEncryption
```
Update-AzStorageAccount -Name <String> -ResourceGroupName <String> -SkuName <SkuName>
 [-SubscriptionId <String>] [-AccessTier <AccessTier>] [-AssignIdentity] [-CustomDomainName <String>]
 [-EnableAzureFilesAadIntegration] [-EnableHttpsTrafficOnly] [-EncryptBlobService] [-EncryptFileService]
 [-EncryptQueueService] [-EncryptTableService] [-KeyName <String>] [-KeyVaultEncryption]
 [-KeyVaultUri <String>] [-KeyVersion <String>] [-Kind <Kind>] [-NetworkRuleSetBypass <Bypass>]
 [-NetworkRuleSetDefaultAction <DefaultAction>] [-NetworkRuleSetIPRule <IIPRule[]>]
 [-NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>] [-SkuKind <Kind>]
 [-SkuRestriction <IRestriction[]>] [-Tag <Hashtable>] [-UseSubDomain] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1StorageEncryption
```
Update-AzStorageAccount -Name <String> -ResourceGroupName <String> -SkuName <SkuName>
 [-SubscriptionId <String>] [-AccessTier <AccessTier>] [-AssignIdentity] [-CustomDomainName <String>]
 [-EnableAzureFilesAadIntegration] [-EnableHttpsTrafficOnly] [-EncryptBlobService] [-EncryptFileService]
 [-EncryptQueueService] [-EncryptTableService] [-Kind <Kind>] [-NetworkRuleSetBypass <Bypass>]
 [-NetworkRuleSetDefaultAction <DefaultAction>] [-NetworkRuleSetIPRule <IIPRule[]>]
 [-NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>] [-SkuKind <Kind>]
 [-SkuRestriction <IRestriction[]>] [-StorageEncryption] [-Tag <Hashtable>] [-UseSubDomain]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzStorageAccount -InputObject <IStorageIdentity> -SkuName <SkuName> [-AccessTier <AccessTier>]
 [-AssignIdentity] [-CustomDomainName <String>] [-EnableAzureFilesAadIntegration] [-EnableHttpsTrafficOnly]
 [-EncryptBlobService] [-EncryptFileService] [-EncryptQueueService] [-EncryptTableService] [-Kind <Kind>]
 [-NetworkRuleSetBypass <Bypass>] [-NetworkRuleSetDefaultAction <DefaultAction>]
 [-NetworkRuleSetIPRule <IIPRule[]>] [-NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>]
 [-NoEncryption] [-SkuKind <Kind>] [-SkuRestriction <IRestriction[]>] [-Tag <Hashtable>] [-UseSubDomain]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1KeyVaultEncryption
```
Update-AzStorageAccount -InputObject <IStorageIdentity> -SkuName <SkuName> [-AccessTier <AccessTier>]
 [-AssignIdentity] [-CustomDomainName <String>] [-EnableAzureFilesAadIntegration] [-EnableHttpsTrafficOnly]
 [-EncryptBlobService] [-EncryptFileService] [-EncryptQueueService] [-EncryptTableService] [-KeyName <String>]
 [-KeyVaultEncryption] [-KeyVaultUri <String>] [-KeyVersion <String>] [-Kind <Kind>]
 [-NetworkRuleSetBypass <Bypass>] [-NetworkRuleSetDefaultAction <DefaultAction>]
 [-NetworkRuleSetIPRule <IIPRule[]>] [-NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>]
 [-SkuKind <Kind>] [-SkuRestriction <IRestriction[]>] [-Tag <Hashtable>] [-UseSubDomain]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1StorageEncryption
```
Update-AzStorageAccount -InputObject <IStorageIdentity> -SkuName <SkuName> [-AccessTier <AccessTier>]
 [-AssignIdentity] [-CustomDomainName <String>] [-EnableAzureFilesAadIntegration] [-EnableHttpsTrafficOnly]
 [-EncryptBlobService] [-EncryptFileService] [-EncryptQueueService] [-EncryptTableService] [-Kind <Kind>]
 [-NetworkRuleSetBypass <Bypass>] [-NetworkRuleSetDefaultAction <DefaultAction>]
 [-NetworkRuleSetIPRule <IIPRule[]>] [-NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>]
 [-SkuKind <Kind>] [-SkuRestriction <IRestriction[]>] [-StorageEncryption] [-Tag <Hashtable>] [-UseSubDomain]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account.
It can also be used to map the account to a custom domain.
Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported.
In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set.
The update of multiple properties is supported.
This call does not change the storage keys for the account.
If you want to change the storage account keys, use the regenerate keys operation.
The location and name of the storage account cannot be changed after creation.

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

### -AccessTier
Required for storage accounts where kind = BlobStorage.
The access tier used for billing.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.AccessTier
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AssignIdentity
Specify IdentityType as 'SystemAssigned'

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CustomDomainName
Gets or sets the custom domain name assigned to the storage account.
Name is the CNAME source.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -EnableAzureFilesAadIntegration
Enables Azure Files AAD Integration for SMB if sets to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableHttpsTrafficOnly
Allows https traffic only to storage service if sets to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EncryptBlobService
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EncryptFileService
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EncryptQueueService
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EncryptTableService
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded1KeyVaultEncryption, UpdateViaIdentityExpanded1StorageEncryption
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -KeyName
The name of KeyVault key.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1KeyVaultEncryption, UpdateViaIdentityExpanded1KeyVaultEncryption
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultEncryption


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1KeyVaultEncryption, UpdateViaIdentityExpanded1KeyVaultEncryption
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultUri
The Uri of KeyVault.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1KeyVaultEncryption, UpdateViaIdentityExpanded1KeyVaultEncryption
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVersion
The version of KeyVault key.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1KeyVaultEncryption, UpdateViaIdentityExpanded1KeyVaultEncryption
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Optional.
Indicates the type of storage account.
Currently only StorageV2 value supported by server.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateExpanded1KeyVaultEncryption, UpdateExpanded1StorageEncryption
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkRuleSetBypass
Specifies whether traffic is bypassed for Logging/Metrics/AzureServices.
Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Bypass
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkRuleSetDefaultAction
Specifies the default action of allow or deny when no other rules match.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.DefaultAction
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkRuleSetIPRule
Sets the IP ACL rules
To construct, see NOTES section for NETWORKRULESETIPRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IIPRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkRuleSetVirtualNetworkRule
Sets the virtual network rules
To construct, see NOTES section for NETWORKRULESETVIRTUALNETWORKRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IVirtualNetworkRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoEncryption


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateExpanded1KeyVaultEncryption, UpdateExpanded1StorageEncryption
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuKind
Indicates the type of storage account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
Gets or sets the SKU name.
Required for account creation; optional for update.
Note that in older versions, SKU name was called accountType.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.SkuName
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuRestriction
The restrictions because of which SKU cannot be used.
This is empty if there are no restrictions.
To construct, see NOTES section for SKURESTRICTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IRestriction[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StorageEncryption


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded1StorageEncryption, UpdateViaIdentityExpanded1StorageEncryption
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded1, UpdateExpanded1KeyVaultEncryption, UpdateExpanded1StorageEncryption
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Gets or sets a list of key value pairs that describe the resource.
These tags can be used in viewing and grouping this resource (across resource groups).
A maximum of 15 tags can be provided for a resource.
Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UseSubDomain
Indicates whether indirect CName validation is enabled.
Default value is false.
This should only be set on updates.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IStorageAccount

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

#### NETWORKRULESETIPRULE <IIPRule[]>: Sets the IP ACL rules
  - `IPAddressOrRange <String>`: Specifies the IP or IP range in CIDR format. Only IPV4 address is allowed.
  - `[Action <Action?>]`: The action of IP ACL rule.

#### NETWORKRULESETVIRTUALNETWORKRULE <IVirtualNetworkRule[]>: Sets the virtual network rules
  - `VirtualNetworkResourceId <String>`: Resource ID of a subnet, for example: /subscriptions/{subscriptionId}/resourceGroups/{groupName}/providers/Microsoft.Network/virtualNetworks/{vnetName}/subnets/{subnetName}.
  - `[Action <Action?>]`: The action of virtual network rule.
  - `[State <State?>]`: Gets the state of virtual network rule.

#### SKURESTRICTION <IRestriction[]>: The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
  - `[ReasonCode <ReasonCode?>]`: The reason for the restriction. As of now this can be "QuotaId" or "NotAvailableForSubscription". Quota Id is set when the SKU has requiredQuotas parameter as the subscription does not belong to that quota. The "NotAvailableForSubscription" is related to capacity at DC.

## RELATED LINKS

