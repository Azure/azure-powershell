function Get-AzADApplication_GetDeleted {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IApplication')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory, HelpMessage='The tenant ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${TenantId},

        [Parameter(HelpMessage='The filter to apply to the operation.')]
        [Alias('ODataQuery')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.String]
        ${Filter},

        [Parameter(Mandatory, HelpMessage='Signals that deleted applications should be returned as well.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        ${IncludeDeleted},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Uri]
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${ProxyUseDefaultCredentials}
    )

    process {
        $PSBoundParameters.Remove("IncludeDeleted") | Out-Null
        Az.Resources.internal\Get-AzADDeletedApplication @PSBoundParameters
    }
}