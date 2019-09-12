function New-AzKeyVault_CreateExpandedDefault {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20180214.IVault')]
    [CmdletBinding(DefaultParameterSetName='CreateExpandedDefault', PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Description('Create or update a key vault in the specified subscription.')]
    param(
        [Parameter(Mandatory, HelpMessage='Name of the vault')]
        [Alias('VaultName')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='vaultName', Required, PossibleTypes=([System.String]), Description='Name of the vault')]
        [System.String]
        # Name of the vault
        ${Name},

        [Parameter(Mandatory, HelpMessage='The name of the Resource Group to which the server belongs.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the Resource Group to which the server belongs.')]
        [System.String]
        # The name of the Resource Group to which the server belongs.
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(HelpMessage='The vault''s create mode to indicate whether the vault need to be recovered or not.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.CreateMode])]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='createMode', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.CreateMode]), Description='The vault''s create mode to indicate whether the vault need to be recovered or not.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.CreateMode]
        # The vault's create mode to indicate whether the vault need to be recovered or not.
        ${CreateMode},

        [Parameter(HelpMessage='Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible - that is, the property does not accept false as its value.')]
       [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='enablePurgeProtection', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible - that is, the property does not accept false as its value.')]
        [System.Management.Automation.SwitchParameter]
        # Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible - that is, the property does not accept false as its value.
        ${EnablePurgeProtection},

        [Parameter(HelpMessage='Property to specify whether the ''soft delete'' functionality is enabled for this key vault. It does not accept false value.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='enableSoftDelete', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='Property to specify whether the ''soft delete'' functionality is enabled for this key vault. It does not accept false value.')]
        [System.Management.Automation.SwitchParameter]
        # Property to specify whether the 'soft delete' functionality is enabled for this key vault. It does not accept false value.
        ${EnableSoftDelete},

        [Parameter(HelpMessage='Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='enabledForDeployment', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key vault.')]
        [System.Management.Automation.SwitchParameter]
        # Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key vault.
        ${EnabledForDeployment},

        [Parameter(HelpMessage='Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='enabledForDiskEncryption', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.')]
        [System.Management.Automation.SwitchParameter]
        # Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.
        ${EnabledForDiskEncryption},

        [Parameter(HelpMessage='Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='enabledForTemplateDeployment', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.')]
        [System.Management.Automation.SwitchParameter]
        # Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.
        ${EnabledForTemplateDeployment},

        [Parameter(Mandatory, HelpMessage='The supported Azure location where the key vault should be created.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='location', Required, PossibleTypes=([System.String]), Description='The supported Azure location where the key vault should be created.')]
        [System.String]
        # The supported Azure location where the key vault should be created.
        ${Location},

        [Parameter(HelpMessage='Tells what traffic can bypass network rules. This can be ''AzureServices'' or ''None''. If not specified the default is ''AzureServices''.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.NetworkRuleBypassOptions])]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='bypass', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.NetworkRuleBypassOptions]), Description='Tells what traffic can bypass network rules. This can be ''AzureServices'' or ''None''. If not specified the default is ''AzureServices''.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.NetworkRuleBypassOptions]
        # Tells what traffic can bypass network rules. This can be 'AzureServices' or 'None'. If not specified the default is 'AzureServices'.
        ${NetworkAclsBypass},

        [Parameter(HelpMessage='The default action when no rule from ipRules and from virtualNetworkRules match. This is only used after the bypass property has been evaluated.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.NetworkRuleAction])]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='defaultAction', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.NetworkRuleAction]), Description='The default action when no rule from ipRules and from virtualNetworkRules match. This is only used after the bypass property has been evaluated.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.NetworkRuleAction]
        # The default action when no rule from ipRules and from virtualNetworkRules match. This is only used after the bypass property has been evaluated.
        ${NetworkAclsDefaultAction},

        [Parameter(HelpMessage='The list of IP address rules. To construct, see NOTES section for NETWORKACLSIPRULE properties and create a hash table.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='ipRules', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20180214.IIPRule]), Description='The list of IP address rules.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20180214.IIPRule[]]
        # The list of IP address rules.
        # To construct, see NOTES section for NETWORKACLSIPRULE properties and create a hash table.
        ${NetworkAclsIPRule},

        [Parameter(HelpMessage='The list of virtual network rules. To construct, see NOTES section for NETWORKACLSVIRTUALNETWORKRULE properties and create a hash table.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='virtualNetworkRules', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20180214.IVirtualNetworkRule]), Description='The list of virtual network rules.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20180214.IVirtualNetworkRule[]]
        # The list of virtual network rules.
        # To construct, see NOTES section for NETWORKACLSVIRTUALNETWORKRULE properties and create a hash table.
        ${NetworkAclsVirtualNetworkRule},

        [Parameter(Mandatory, HelpMessage='SKU name to specify whether the key vault is a standard vault or a premium vault.')]
        [Alias('Sku')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.SkuName])]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='name', Required, PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.SkuName]), Description='SKU name to specify whether the key vault is a standard vault or a premium vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.SkuName]
        # SKU name to specify whether the key vault is a standard vault or a premium vault.
        ${SkuName},

        [Parameter(HelpMessage='The tags that will be assigned to the key vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='tags', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVaultCreateOrUpdateParametersTags]), Description='The tags that will be assigned to the key vault.')]
        [System.Collections.Hashtable]
        # The tags that will be assigned to the key vault.
        ${Tag},

        [Parameter(Mandatory, HelpMessage='The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='tenantId', Required, PossibleTypes=([System.String]), Description='The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.')]
        [System.String]
        # The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        ${TenantId},

        [Parameter(HelpMessage='The URI of the vault for performing operations on keys and secrets.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='vaultUri', PossibleTypes=([System.String]), Description='The URI of the vault for performing operations on keys and secrets.')]
        [System.String]
        # The URI of the vault for performing operations on keys and secrets.
        ${VaultUri},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(HelpMessage='Run the command as a job')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(HelpMessage='Run the command asynchronously')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        $null = $PSBoundParameters.Add("AccessPolicy", @())
        Az.KeyVault\New-AzKeyVault @PSBoundParameters
    }
}