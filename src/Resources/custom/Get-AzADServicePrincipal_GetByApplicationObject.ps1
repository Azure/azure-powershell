function Get-AzADServicePrincipal {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IServicePrincipal')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-01")]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory)]
        [System.String]
        # The tenant ID.
        ${TenantId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IApplication]
        # The object representation of the application.
        ${ApplicationObject},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        $PSBoundParameters.Add("Filter", "appId eq '$($ApplicationObject.ApplicationId)'") | Out-Null
        $PSBoundParameters.Remove("ApplicationObject") | Out-Null
        Az.Resources\Get-AzADServicePrincipal @PSBoundParameters
    }
}