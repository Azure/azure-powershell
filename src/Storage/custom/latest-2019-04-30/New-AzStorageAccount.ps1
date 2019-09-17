function New-AzStorageAccount {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IStorageAccount')]
    [CmdletBinding(DefaultParameterSetName='CreateExpandedStorageEncryption', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Storage.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Storage.Description('Creates a new storage account with the specified parameters. If an account is already created and a subsequent create request is issued with different properties, the account properties will be updated. If an account is already created and a subsequent create or update request is issued with the exact same set of properties, the request will succeed.')]
    param(
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', Mandatory, HelpMessage='The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', Mandatory, HelpMessage='The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [System.String]
        # The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
        ${Name},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', Mandatory, HelpMessage='The name of the resource group within the user''s subscription. The name is case insensitive.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', Mandatory, HelpMessage='The name of the resource group within the user''s subscription. The name is case insensitive.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [System.String]
        # The name of the resource group within the user's subscription. The name is case insensitive.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Specify IdentityType as ''SystemAssigned''')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Specify IdentityType as ''SystemAssigned''')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Specify IdentityType as 'SystemAssigned'
        ${AssignIdentity},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Required for storage accounts where kind = BlobStorage. The access tier used for billing.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Required for storage accounts where kind = BlobStorage. The access tier used for billing.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.AccessTier])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.AccessTier]
        # Required for storage accounts where kind = BlobStorage. The access tier used for billing.
        ${AccessTier},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A boolean indicating whether or not the service encrypts the data as it is stored.
        ${EncryptBlobService},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.String]
        # Gets or sets the custom domain name assigned to the storage account. Name is the CNAME source.
        ${CustomDomainName},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Enables Azure Files AAD Integration for SMB if sets to true.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Enables Azure Files AAD Integration for SMB if sets to true.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Enables Azure Files AAD Integration for SMB if sets to true.
        ${EnableAzureFilesAadIntegration},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Allows https traffic only to storage service if sets to true.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Allows https traffic only to storage service if sets to true.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Allows https traffic only to storage service if sets to true.
        ${EnableHttpsTrafficOnly},

        [Parameter(ParameterSetName='CreateExpandedStorageEncryption')]
        [System.Management.Automation.SwitchParameter]
        ${StorageEncryption},

        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption')]
        [System.Management.Automation.SwitchParameter]
        ${KeyVaultEncryption},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A boolean indicating whether or not the service encrypts the data as it is stored.
        ${EncryptFileService},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Account HierarchicalNamespace enabled if sets to true.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Account HierarchicalNamespace enabled if sets to true.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Account HierarchicalNamespace enabled if sets to true.
        ${EnableHierarchicalNamespace},
    
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='The name of KeyVault key.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.String]
        # The name of KeyVault key.
        ${KeyName},
    
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='The Uri of KeyVault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.String]
        # The Uri of KeyVault.
        ${KeyVaultUri},
    
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='The version of KeyVault key.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.String]
        # The version of KeyVault key.
        ${KeyVersion},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', Mandatory, HelpMessage='Required. Indicates the type of storage account.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', Mandatory, HelpMessage='Required. Indicates the type of storage account.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind]
        # Required. Indicates the type of storage account.
        ${Kind},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', Mandatory, HelpMessage='Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', Mandatory, HelpMessage='Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.String]
        # Required. Gets or sets the location of the resource. This will be one of the supported and registered Azure Geo Regions (e.g. West US, East US, Southeast Asia, etc.). The geo region of a resource cannot be changed once it is created, but if an identical geo region is specified on update, the request will succeed.
        ${Location},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Bypass])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Bypass]
        # Specifies whether traffic is bypassed for Logging/Metrics/AzureServices. Possible values are any combination of Logging|Metrics|AzureServices (For example, "Logging, Metrics"), or None to bypass none of those traffics.
        ${NetworkRuleSetBypass},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Specifies the default action of allow or deny when no other rules match.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Specifies the default action of allow or deny when no other rules match.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.DefaultAction])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.DefaultAction]
        # Specifies the default action of allow or deny when no other rules match.
        ${NetworkRuleSetDefaultAction},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Sets the IP ACL rules')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Sets the IP ACL rules')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IIPRule[]]
        # Sets the IP ACL rules
        ${NetworkRuleSetIPRule},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Sets the virtual network rules')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Sets the virtual network rules')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IVirtualNetworkRule[]]
        # Sets the virtual network rules
        ${NetworkRuleSetVirtualNetworkRule},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A boolean indicating whether or not the service encrypts the data as it is stored.
        ${EncryptQueueService},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Indicates the type of storage account.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Indicates the type of storage account.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Kind]
        # Indicates the type of storage account.
        ${SkuKind},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', Mandatory, HelpMessage='Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', Mandatory, HelpMessage='Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.SkuName])]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.SkuName]
        # Gets or sets the SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        ${SkuName},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IRestriction[]]
        # The restrictions because of which SKU cannot be used. This is empty if there are no restrictions.
        ${SkuRestriction},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='A boolean indicating whether or not the service encrypts the data as it is stored.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # A boolean indicating whether or not the service encrypts the data as it is stored.
        ${EncryptTableService},
    
        [Parameter(ParameterSetName='CreateExpandedStorageEncryption', HelpMessage='Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters.')]
        [Parameter(ParameterSetName='CreateExpandedKeyVaultEncryption', HelpMessage='Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [System.Collections.Hashtable]
        # Gets or sets a list of key value pairs that describe the resource. These tags can be used for viewing and grouping this resource (across resource groups). A maximum of 15 tags can be provided for a resource. Each tag must have a key with a length no greater than 128 characters and a value with a length no greater than 256 characters.
        ${Tag},
    
        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(HelpMessage='Run the command as a job')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
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
        if ($PSBoundParameters.ContainsKey("AsJob")) {
            $null = $PSBoundParameters.Remove("AsJob")
            Start-Job -ScriptBlock {
                param($arg, $modulePath) 
                Import-Module $modulePath
                Az.Storage\New-AzStorageAccount @arg} -ArgumentList $PSBoundParameters, (Join-Path $PSScriptRoot "..\..\Az.Storage.psd1")
        } else {
            if ($PSBoundParameters.ContainsKey("StorageEncryption")) {
                $null = $PSBoundParameters.Add("EncryptionKeySource", "Microsoft.Storage")
                $null = $PSBoundParameters.Remove("StorageEncryption")
            }
            if ($PSBoundParameters.ContainsKey("KeyVaultEncryption")) {
                $null = $PSBoundParameters.Add("EncryptionKeySource", "Microsoft.Keyvault")
                $null = $PSBoundParameters.Remove("KeyVaultEncryption")
            }
            $null = Az.Storage.internal\New-AzStorageAccount @PSBoundParameters
            $commonParams = Get-CommonParameter -PSCmdlet $PSCmdlet -PSBoundParameter $PSBoundParameters
            Az.Storage.internal\Get-AzStorageAccountProperty -Name $PSBoundParameters["Name"] -ResourceGroupName $PSBoundParameters["ResourceGroupName"] -SubscriptionId $PSBoundParameters["SubscriptionId"] @commonParams
        }
    }
}
    