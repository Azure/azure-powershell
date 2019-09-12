function Update-AzStorageAccount {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IStorageAccount')]
    [CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Storage.Profile('hybrid-2019-03-01')]
    [Microsoft.Azure.PowerShell.Cmdlets.Storage.Description('The update operation can be used to update the SKU, encryption, access tier, or tags for a storage account. It can also be used to map the account to a custom domain. Only one custom domain is supported per storage account; the replacement/change of custom domain is not supported. In order to replace an old custom domain, the old value must be cleared/unregistered before a new value can be set. The update of multiple properties is supported. This call does not change the storage keys for the account. If you want to change the storage account keys, use the regenerate keys operation. The location and name of the storage account cannot be changed after creation.')]
    param(
        [Parameter(ParameterSetName='UpdateExpanded', Mandatory, HelpMessage='The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', Mandatory, HelpMessage='The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', Mandatory, HelpMessage='The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [System.String]
        # The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
        ${Name},
    
        [Parameter(ParameterSetName='UpdateExpanded', Mandatory, HelpMessage='The name of the resource group within the user''s subscription. The name is case insensitive.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', Mandatory, HelpMessage='The name of the resource group within the user''s subscription. The name is case insensitive.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', Mandatory, HelpMessage='The name of the resource group within the user''s subscription. The name is case insensitive.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [System.String]
        # The name of the resource group within the user's subscription. The name is case insensitive.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='UpdateExpanded', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline, HelpMessage='Identity Parameter')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', Mandatory, ValueFromPipeline, HelpMessage='Identity Parameter')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', Mandatory, ValueFromPipeline, HelpMessage='Identity Parameter')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity]
        # Identity Parameter
        ${InputObject},

        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Specify IdentityType as ''SystemAssigned''')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Specify IdentityType as ''SystemAssigned''')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Specify IdentityType as ''SystemAssigned''')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Specify IdentityType as ''SystemAssigned''')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Specify IdentityType as ''SystemAssigned''')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Specify IdentityType as ''SystemAssigned''')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Specify IdentityType as 'SystemAssigned'
        ${AssignIdentity},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Required for storage accounts where kind = BlobStorage. The access tier used for billing.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Required for storage accounts where kind = BlobStorage. The access tier used for billing.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Required for storage accounts where kind = BlobStorage. The access tier used for billing.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Required for storage accounts where kind = BlobStorage. The access tier used for billing.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Required for storage accounts where kind = BlobStorage. The access tier used for billing.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Required for storage accounts where kind = BlobStorage. The access tier used for billing.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.AccessTier])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.AccessTier]
        # Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        ${AccessTier},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A boolean indicating whether or not the service encrypts the data as it is stored.
        ${EncryptBlobService},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.String]
        # Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        ${CustomDomainName},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Allows https traffic only to storage service if sets to true.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Allows https traffic only to storage service if sets to true.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Allows https traffic only to storage service if sets to true.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Allows https traffic only to storage service if sets to true.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Allows https traffic only to storage service if sets to true.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Allows https traffic only to storage service if sets to true.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Allows https traffic only to storage service if sets to true.
        ${EnableHttpsTrafficOnly},
        
        [Parameter(ParameterSetName='UpdateExpanded')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded')]
        [System.Management.Automation.SwitchParameter]
        ${NoEncryption},

        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption')]
        [System.Management.Automation.SwitchParameter]
        ${StorageEncryption},

        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption')]
        [System.Management.Automation.SwitchParameter]
        ${KeyVaultEncryption},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A boolean indicating whether or not the service encrypts the data as it is stored.
        ${EncryptFileService},


        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='The name of KeyVault key.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='The name of KeyVault key.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.String]
        # The name of KeyVault key.
        ${KeyName},
    
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='The Uri of KeyVault.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='The Uri of KeyVault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.String]
        # The Uri of KeyVault.
        ${KeyVaultUri},
    
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='The version of KeyVault key.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='The version of KeyVault key.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.String]
        # The version of KeyVault key.
        ${KeyVersion},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind]
        # Optional. Indicates the type of storage account. Currently only StorageV2 value supported by server.
        ${Kind},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Bypass])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Bypass]
        # Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        ${NetworkRuleSetBypass},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Specifies the default action of allow or deny when no other rules match.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Specifies the default action of allow or deny when no other rules match.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Specifies the default action of allow or deny when no other rules match.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Specifies the default action of allow or deny when no other rules match.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Specifies the default action of allow or deny when no other rules match.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Specifies the default action of allow or deny when no other rules match.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.DefaultAction])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.DefaultAction]
        # Specifies the default action of allow or deny when no other rules match.
        ${NetworkRuleSetDefaultAction},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Sets the IP ACL rules')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Sets the IP ACL rules')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Sets the IP ACL rules')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Sets the IP ACL rules')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Sets the IP ACL rules')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Sets the IP ACL rules')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IIPRule[]]
        # Sets the IP ACL rules
        ${NetworkRuleSetIPRule},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Sets the virtual network rules')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Sets the virtual network rules')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Sets the virtual network rules')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Sets the virtual network rules')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Sets the virtual network rules')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Sets the virtual network rules')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IVirtualNetworkRule[]]
        # Sets the virtual network rules
        ${NetworkRuleSetVirtualNetworkRule},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A boolean indicating whether or not the service encrypts the data as it is stored.
        ${EncryptQueueService},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Indicates the type of storage account.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Indicates the type of storage account.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Indicates the type of storage account.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Indicates the type of storage account.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Indicates the type of storage account.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Indicates the type of storage account.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind]
        # Indicates the type of storage account.
        ${SkuKind},
    
        [Parameter(ParameterSetName='UpdateExpanded', Mandatory, HelpMessage='Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', Mandatory, HelpMessage='Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', Mandatory, HelpMessage='Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, HelpMessage='Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', Mandatory, HelpMessage='Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', Mandatory, HelpMessage='Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.SkuName])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.SkuName]
        # Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        ${SkuName},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IRestriction[]]
        # The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        ${SkuRestriction},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A boolean indicating whether or not the service encrypts the data as it is stored.
        ${EncryptTableService},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Collections.Hashtable]
        # Gets or sets a list of key value pairs that describe the resource. These tags can be used in viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key no greater in length than 128 characters and a value no greater in length than 256 characters.
        ${Tag},
    
        [Parameter(ParameterSetName='UpdateExpanded', HelpMessage='Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.')]
        [Parameter(ParameterSetName='UpdateExpandedStorageEncryption', HelpMessage='Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.')]
        [Parameter(ParameterSetName='UpdateExpandedKeyVaultEncryption', HelpMessage='Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpanded', HelpMessage='Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedStorageEncryption', HelpMessage='Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.')]
        [Parameter(ParameterSetName='UpdateViaIdentityExpandedKeyVaultEncryption', HelpMessage='Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Indicates whether indirect CName validation is enabled. Default value is false. This should only be set on updates.
        ${UseSubDomain},
    
        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        if ($PSBoundParameters.ContainsKey("StorageEncryption")) {
            $null = $PSBoundParameters.Add("EncryptionKeySource", "Microsoft.Storage")
            $null = $PSBoundParameters.Remove("StorageEncryption")
        }
        if ($PSBoundParameters.ContainsKey("KeyVaultEncryption")) {
            $null = $PSBoundParameters.Add("EncryptionKeySource", "Microsoft.Keyvault")
            $null = $PSBoundParameters.Remove("KeyVaultEncryption")
        }
        if ($PSBoundParameters.ContainsKey("NoEncryption")) {
            $null = $PSBoundParameters.Add("EncryptionKeySource", "")
            $null = $PSBoundParameters.Remove("NoEncryption")
        }
        $null = Az.Storage.internal\Update-AzStorageAccount @PSBoundParameters
        $commonParams = Get-CommonParameter -PSCmdlet $PSCmdlet -PSBoundParameter $PSBoundParameters
        if ($PSBoundParameters.ContainsKey("InputObject")) {
            $PSBoundParameters["InputObject"] | Az.Storage.internal\Get-AzStorageAccountProperty @commonParams
        } else {
            Az.Storage.internal\Get-AzStorageAccountProperty -Name $PSBoundParameters["Name"] -ResourceGroupName $PSBoundParameters["ResourceGroupName"] -SubscriptionId $PSBoundParameters["SubscriptionId"] @commonParams
        }
    }
}
    