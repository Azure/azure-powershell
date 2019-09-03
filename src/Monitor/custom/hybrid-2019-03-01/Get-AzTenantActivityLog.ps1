function Get-AzTenantActivityLog {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20150401.IEventData')]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Profile('hybrid-2019-03-01')]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Description('Gets the Activity Logs for the Tenant. Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.). One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.')]
param(
    [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials},

    [Parameter(HelpMessage = "The start time filter for the events")]
    [ValidateNotNull()]
    [System.DateTime]
    ${StartTime},

    [Parameter(HelpMessage = "The end time filter for the events")]
    [ValidateNotNull()]
    [System.DateTime]
    ${EndTime},

    [Parameter(HelpMessage='The Status of the events to fetch')]
    [ValidateNotNull()]
    [System.String]
    ${Status},

    [Parameter(HelpMessage = "The Caller of the events to fetch")]
    [ValidateNotNull()]
    [System.String]
    ${Caller},

    [Parameter(ParameterSetName = "CorrelationId", Mandatory, HelpMessage = "The Correlation ID")]
    [ValidateNotNull()]
    [System.String]
    ${CorrelationId},

    [Parameter(ParameterSetName = "ResourceProvider", Mandatory, HelpMessage = "The Resource Provider name")]
    [ValidateNotNull()]
    [System.String]
    ${ResourceProvider},

    [Parameter(ParameterSetName = "ResourceGroupName", Mandatory, HelpMessage = "The Resource group name")]
    [ValidateNotNull()]
    [System.String]
    ${ResourceGroupName},

    [Parameter(ParameterSetName = "ResourceId", Mandatory, HelpMessage = "The Resource ID")]
    [ValidateNotNull()]
    [System.String]
    ${ResourceId},

    [Parameter(HelpMessage = "The event channel. Possible values are 'Admin' and 'Operation'")]
    [ValidateNotNull()]
    [System.String]
    ${EventChannel}
)
process {
    $filter = [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Cmdlets.LogFilterHelper]::GetFilterParameter($PSBoundParameters)
    
    $null = $PSBoundParameters.Remove("StartTime")
    $null = $PSBoundParameters.Remove("EndTime")
    $null = $PSBoundParameters.Remove("Status")
    $null = $PSBoundParameters.Remove("Caller")
    $null = $PSBoundParameters.Remove("CorrelationId")
    $null = $PSBoundParameters.Remove("ResourceProvider")
    $null = $PSBoundParameters.Remove("ResourceGroupName")
    $null = $PSBoundParameters.Remove("ResourceId")
    $null = $PSBoundParameters.Remove("EventChannel")

    $null = $PSBoundParameters.Add("Filter", $filter)

    #Az.Monitor.internal\Get-AzTenantActivityLog @PSBoundParameters
}
}
