---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstorageaccount
schema: 2.0.0
---

# New-AzStorageAccount

## SYNOPSIS
Creates a new storage account with the specified parameters.
If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated.
If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

## SYNTAX

### CreateExpandedStorageEncryption (Default)
```
New-AzStorageAccount -Name <String> -ResourceGroupName <String> -Kind <Kind> -Location <String>
 -SkuName <SkuName> [-SubscriptionId <String>] [-AccessTier <AccessTier>] [-AssignIdentity]
 [-CustomDomainName <String>] [-EnableAzureFilesAadIntegration] [-EnableHierarchicalNamespace]
 [-EnableHttpsTrafficOnly] [-EncryptBlobService] [-EncryptFileService] [-EncryptQueueService]
 [-EncryptTableService] [-NetworkRuleSetBypass <Bypass>] [-NetworkRuleSetDefaultAction <DefaultAction>]
 [-NetworkRuleSetIPRule <IIPRule[]>] [-NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>]
 [-SkuKind <Kind>] [-SkuRestriction <IRestriction[]>] [-StorageEncryption] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpandedKeyVaultEncryption
```
New-AzStorageAccount -Name <String> -ResourceGroupName <String> -Kind <Kind> -Location <String>
 -SkuName <SkuName> [-SubscriptionId <String>] [-AccessTier <AccessTier>] [-AssignIdentity]
 [-CustomDomainName <String>] [-EnableAzureFilesAadIntegration] [-EnableHierarchicalNamespace]
 [-EnableHttpsTrafficOnly] [-EncryptBlobService] [-EncryptFileService] [-EncryptQueueService]
 [-EncryptTableService] [-KeyName <String>] [-KeyVaultEncryption] [-KeyVaultUri <String>]
 [-KeyVersion <String>] [-NetworkRuleSetBypass <Bypass>] [-NetworkRuleSetDefaultAction <DefaultAction>]
 [-NetworkRuleSetIPRule <IIPRule[]>] [-NetworkRuleSetVirtualNetworkRule <IVirtualNetworkRule[]>]
 [-SkuKind <Kind>] [-SkuRestriction <IRestriction[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new storage account with the specified parameters.
If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated.
If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

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

### -EnableHierarchicalNamespace
Account HierarchicalNamespace enabled if sets to true.

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

### -KeyName
The name of KeyVault key.

```yaml
Type: System.String
Parameter Sets: CreateExpandedKeyVaultEncryption
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
Parameter Sets: CreateExpandedKeyVaultEncryption
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
Parameter Sets: CreateExpandedKeyVaultEncryption
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
Parameter Sets: CreateExpandedKeyVaultEncryption
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Required.
Indicates the type of storage account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Required.
Gets or sets the location of the resource.
This will be one of the supported and registered Azure Geo Regions (e.g.
West US, East US, Southeast Asia, etc.).
The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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
Parameter Sets: (All)
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
Parameter Sets: CreateExpandedStorageEncryption
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
Parameter Sets: (All)
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
These tags can be used for viewing and grouping this resource (across resource groups).
A maximum of 15 tags can be provided for a resource.
Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IStorageAccount

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

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

