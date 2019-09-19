function Get-AzKeyVaultCertificate {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IDeletedCertificateItem', 'Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IDeletedCertificateBundle')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Profile('latest-2019-04-30')]
    param(
        [Parameter(HelpMessage='MISSING DESCRIPTION 06')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Uri')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='keyVaultDnsSuffix', PossibleTypes=([System.String]), Description='MISSING DESCRIPTION 06')]
        [System.String]
        # MISSING DESCRIPTION 06
        ${KeyVaultDnsSuffix},

        [Parameter(HelpMessage='MISSING DESCRIPTION 06')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Uri')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime.Info(SerializedName='vaultName', PossibleTypes=([System.String]), Description='MISSING DESCRIPTION 06')]
        [System.String]
        # MISSING DESCRIPTION 06
        ${VaultName},

        [Parameter(ParameterSetName='GetDeleted', Mandatory, HelpMessage='The name of the certificate')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Path')]
        [System.String]
        # The name of the certificate
        ${Name},

        [Parameter(Mandatory, HelpMessage='Signals that deleted key vault certificates should be returned.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        # Signals that deleted key vault certificates should be returned.
        ${InRemovedState},

        [Parameter(ParameterSetName='ListDeleted', HelpMessage='Maximum number of results to return in a page. If not specified the service will return up to 25 results.')]
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Category('Query')]
        [System.Int32]
        # Maximum number of results to return in a page. If not specified the service will return up to 25 results.
        ${MaxResult},

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
        $null = $PSBoundParameters.Add("CertificateName", $Name)
        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Remove("InRemovedState")
        Az.KeyVault.internal\Get-AzKeyVaultDeletedCertificate @PSBoundParameters
    }
}