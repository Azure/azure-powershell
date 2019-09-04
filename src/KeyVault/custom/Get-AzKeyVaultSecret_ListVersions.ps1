function Get-AzKeyVaultSecret_ListVersions {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ISecretBundle', 'Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.ISecretItem')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Profile('latest-2019-04-30')]
    param(
        [Parameter(HelpMessage='MISSING DESCRIPTION 06')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Uri')]
        [System.String]
        # MISSING DESCRIPTION 06
        ${VaultBaseUrl},

        [Parameter(Mandatory, HelpMessage='The name of the secret.')]
        [Alias('SecretName')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Path')]
        [System.String]
        # The name of the secret.
        ${Name},

        [Parameter(Mandatory, HelpMessage='Signals to include versions of the secret in the output.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Signals to include versions of the secret in the output.
        ${IncludeVersions},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

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
        $null = $PSBoundParameters.Add("Version", [string]::Empty)
        $null = $PSBoundParameters.Remove("IncludeVersions")
        Az.KeyVault\Get-AzKeyVaultSecret @PSBoundParameters
    }
}