---
external help file:
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

### Create1 (Default)
```
New-AzStorageAccount -AccountName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <IStorageAccountCreateParameters>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateExpanded1
```
New-AzStorageAccount -AccountName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -CustomDomainName <String> -EncryptionKeySource <KeySource> -Kind <Kind> -Location <String>
 -NetworkAclsDefaultAction <DefaultAction> -SkuName <SkuName> [-AccessTier <AccessTier>] [-BlobEnabled]
 [-EnableHttpsTrafficOnly] [-FileEnabled] [-KeyvaultpropertyKeyName <String>]
 [-KeyvaultpropertyKeyVaultUri <String>] [-KeyvaultpropertyKeyVersion <String>] [-NetworkAclsBypass <Bypass>]
 [-NetworkAclsIPRule <IIPRule[]>] [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-QueueEnabled]
 [-SkuKind <Kind>] [-SkuRestriction <IRestriction[]>] [-TableEnabled]
 [-Tag <IStorageAccountCreateParametersTags>] [-UseSubDomain] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzStorageAccount -InputObject <IStorageIdentity> -CustomDomainName <String>
 -EncryptionKeySource <KeySource> -Kind <Kind> -Location <String> -NetworkAclsDefaultAction <DefaultAction>
 -SkuName <SkuName> [-AccessTier <AccessTier>] [-BlobEnabled] [-EnableHttpsTrafficOnly] [-FileEnabled]
 [-KeyvaultpropertyKeyName <String>] [-KeyvaultpropertyKeyVaultUri <String>]
 [-KeyvaultpropertyKeyVersion <String>] [-NetworkAclsBypass <Bypass>] [-NetworkAclsIPRule <IIPRule[]>]
 [-NetworkAclsVirtualNetworkRule <IVirtualNetworkRule[]>] [-QueueEnabled] [-SkuKind <Kind>]
 [-SkuRestriction <IRestriction[]>] [-TableEnabled] [-Tag <IStorageAccountCreateParametersTags>]
 [-UseSubDomain] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity1
```
New-AzStorageAccount -InputObject <IStorageIdentity> [-Parameter <IStorageAccountCreateParameters>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously creates a new storage account with the specified parameters.
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
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases:

Required: True
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BlobEnabled
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CustomDomainName
Gets or sets the custom domain name assigned to the storage account.
Name is the CNAME source.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: True
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

### -EnableHttpsTrafficOnly
Allows https traffic only to storage service if sets to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EncryptionKeySource
The encryption keySource (provider).
Possible values (case-insensitive): Microsoft.Storage, Microsoft.Keyvault

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.KeySource
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FileEnabled
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: CreateViaIdentityExpanded1, CreateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -KeyvaultpropertyKeyName
The name of KeyVault key.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyvaultpropertyKeyVaultUri
The Uri of KeyVault.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyvaultpropertyKeyVersion
The version of KeyVault key.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
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
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
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
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkAclsBypass
Specifies whether traffic is bypassed for Logging/Metrics/AzureServices.
Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Bypass
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkAclsDefaultAction
Specifies the default action of allow or deny when no other rules match.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.DefaultAction
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkAclsIPRule
Sets the IP ACL rules

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IIPRule[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkAclsVirtualNetworkRule
Sets the virtual network rules

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IVirtualNetworkRule[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The parameters used when creating a storage account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IStorageAccountCreateParameters
Parameter Sets: Create1, CreateViaIdentity1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -QueueEnabled
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
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
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
Gets or sets the sku name.
Required for account creation; optional for update.
Note that in older versions, sku name was called accountType.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.SkuName
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IRestriction[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TableEnabled
A boolean indicating whether or not the service encrypts the data as it is stored.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IStorageAccountCreateParametersTags
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
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
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IStorageAccountCreateParameters

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IStorageAccount

## ALIASES

## RELATED LINKS

