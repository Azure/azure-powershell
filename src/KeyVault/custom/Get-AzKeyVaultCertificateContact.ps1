function Get-AzKeyVaultCertificateContact {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001.IContact')]
    [CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Description('The GetCertificateContacts operation returns the set of certificate contact resources in the specified key vault. This operation requires the certificates/managecontacts permission.')]
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
        try
        {
            (Az.KeyVault.internal\Get-AzKeyVaultCertificateContact @PSBoundParameters).ContactList
        }
        catch
        {

        }

    }
}