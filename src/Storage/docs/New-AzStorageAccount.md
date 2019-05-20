---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstorageaccount
schema: 2.0.0
---

# New-AzStorageAccount

## SYNOPSIS
Asynchronously creates a new storage account with the specified parameters.
If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated.
If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

## SYNTAX

### Create (Default)
```
New-AzStorageAccount -AccountName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <IStorageAccountCreateParameters>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzStorageAccount -AccountName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-AccessTier <AccessTier>] [-BlobEnabled <Boolean>] -CustomDomainName <String>
 [-CustomDomainUseSubDomainName <Boolean>] [-EnableAzureFilesAadIntegration <Boolean>]
 [-EnableHttpsTrafficOnly <Boolean>] -EncryptionKeySource <KeySource> [-FileEnabled <Boolean>]
 [-IsHnsEnabled <Boolean>] [-KeyvaultpropertiesKeyName <String>] [-KeyvaultpropertiesKeyVaultUri <String>]
 [-KeyvaultpropertiesKeyVersion <String>] -Kind <Kind> -Location <String> [-NetworkAclsBypass <Bypass>]
 -NetworkAclsDefaultAction <DefaultAction> [-NetworkAclsIPRule <IIPRule[]>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-QueueEnabled <Boolean>] [-SkuKind <Kind>]
 -SkuName <SkuName> [-SkuRestriction <IRestriction[]>] [-TableEnabled <Boolean>]
 [-Tag <IStorageAccountCreateParametersTags>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzStorageAccount -InputObject <IStorageIdentity> [-AccessTier <AccessTier>] [-BlobEnabled <Boolean>]
 -CustomDomainName <String> [-CustomDomainUseSubDomainName <Boolean>]
 [-EnableAzureFilesAadIntegration <Boolean>] [-EnableHttpsTrafficOnly <Boolean>]
 -EncryptionKeySource <KeySource> [-FileEnabled <Boolean>] [-IsHnsEnabled <Boolean>]
 [-KeyvaultpropertiesKeyName <String>] [-KeyvaultpropertiesKeyVaultUri <String>]
 [-KeyvaultpropertiesKeyVersion <String>] -Kind <Kind> -Location <String> [-NetworkAclsBypass <Bypass>]
 -NetworkAclsDefaultAction <DefaultAction> [-NetworkAclsIPRule <IIPRule[]>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-QueueEnabled <Boolean>] [-SkuKind <Kind>]
 -SkuName <SkuName> [-SkuRestriction <IRestriction[]>] [-TableEnabled <Boolean>]
 [-Tag <IStorageAccountCreateParametersTags>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzStorageAccount -InputObject <IStorageIdentity> [-Parameter <IStorageAccountCreateParameters>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously creates a new storage account with the specified parameters.
If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated.
If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AccessTier
Required for storage accounts where kind = BlobStorage.
The access tier used for billing.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.AccessTier
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AccountName
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
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobEnabled
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomDomainName
Gets or sets the custom domain name assigned to the storage account.
Name is the CNAME source.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomDomainUseSubDomainName
Indicates whether indirect CName validation is enabled.
Default value is false.
This should only be set on updates.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
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

### -EnableAzureFilesAadIntegration
Enables Azure Files AAD Integration for SMB if sets to true.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableHttpsTrafficOnly
Allows https traffic only to storage service if sets to true.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKeySource
The encryption keySource (provider).
Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.KeySource
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileEnabled
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsHnsEnabled
Account HierarchicalNamespace enabled if sets to true.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyvaultpropertiesKeyName
The name of KeyVault key.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyvaultpropertiesKeyVaultUri
The Uri of KeyVault.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyvaultpropertiesKeyVersion
The version of KeyVault key.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Required.
Indicates the type of storage account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Required.
Gets or sets the location of the resource.
This will be one of the supported and registered Azure Geo Regions (e.g.
West US, East US, Southeast Asia, etc.).
The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAclsBypass
Specifies whether traffic is bypassed for Logging/Metrics/AzureServices.
Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Bypass
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAclsDefaultAction
Specifies the default action of allow or deny when no other rules match.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.DefaultAction
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAclsIPRule
Sets the IP ACL rules

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IIPRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAclsVirtualNetworkRule
Sets the virtual network rules

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IVirtualNetworkRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameters used when creating a storage account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IStorageAccountCreateParameters
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -QueueEnabled
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -SkuKind
Indicates the type of storage account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Gets or sets the SKU name.
Required for account creation; optional for update.
Note that in older versions, SKU name was called accountType.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.SkuName
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuRestriction
The restrictions because of which SKU cannot be used.
This is empty if there are no restrictions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IRestriction[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TableEnabled
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Gets or sets a list of key value pairs that describe the resource.
These tags can be used for viewing and grouping this resource (across resource groups).
A maximum of 15 tags can be provided for a resource.
Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IStorageAccountCreateParametersTags
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IStorageAccount
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstorageaccount](https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstorageaccount)

