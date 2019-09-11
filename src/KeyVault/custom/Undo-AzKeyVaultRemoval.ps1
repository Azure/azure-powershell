function Undo-AzKeyVaultRemoval {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20180214.IVault')]
    [CmdletBinding(DefaultParameterSetName='Undo', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Description('Create or update a key vault in the specified subscription.')]
    param(
        [Parameter(Mandatory, HelpMessage='Name of the deleted vault.')]
        [Alias('VaultName')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='vaultName', Required, PossibleTypes=([System.String]), Description='Name of the vault')]
        [System.String]
        # Name of the deleted vault.
        ${Name},

        [Parameter(Mandatory, HelpMessage='Name of the deleted vault resource group.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the Resource Group to which the server belongs.')]
        [System.String]
        # Name of the deleted vault resource group.
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Original Azure region of the deleted vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='location', Required, PossibleTypes=([System.String]), Description='The supported Azure location where the key vault should be created.')]
        [System.String]
        # Original Azure region of the deleted vault.
        ${Location},

        [Parameter(Mandatory, HelpMessage='SKU name to specify whether the key vault is a standard vault or a premium vault.')]
        [Alias('Sku')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.SkuName])]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='name', Required, PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.SkuName]), Description='SKU name to specify whether the key vault is a standard vault or a premium vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Support.SkuName]
        # SKU name to specify whether the key vault is a standard vault or a premium vault.
        ${SkuName},

        [Parameter(Mandatory, HelpMessage='The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='tenantId', Required, PossibleTypes=([System.String]), Description='The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.')]
        [System.String]
        # The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        ${TenantId},

        [Parameter(HelpMessage='The tags that will be assigned to the key vault.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='tags', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IVaultCreateOrUpdateParametersTags]), Description='The tags that will be assigned to the key vault.')]
        [System.Collections.Hashtable]
        # The tags that will be assigned to the key vault.
        ${Tag},

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
        $null = $PSBoundParameters.Add("CreateMode", "Recover")
        Az.KeyVault\New-AzKeyVault @PSBoundParameters
    }
}