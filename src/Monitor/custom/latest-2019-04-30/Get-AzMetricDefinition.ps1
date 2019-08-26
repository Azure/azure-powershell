function Get-AzMetricDefinition {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api201801.IMetricDefinition')]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Description('Lists the metric definitions for the resource.')]
param(
    [Parameter(Mandatory, HelpMessage='The identifier of the resource.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='resourceUri', Required, PossibleTypes=([System.String]), Description='The identifier of the resource.')]
    [System.String]
    # The identifier of the resource.
    ${ResourceId},

    [Parameter(HelpMessage='Metric namespace to query metric definitions for.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Query')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='metricnamespace', PossibleTypes=([System.String]), Description='Metric namespace to query metric definitions for.')]
    [System.String]
    # Metric namespace to query metric definitions for.
    ${Metricnamespace},

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

    # CUSTOM
    [Parameter(HelpMessage="The metric names of the query")]
    [ValidateNotNullOrEmpty()]
    [System.String[]]
    ${MetricName}
    # END CUSTOM
)

process {
    if ($PSBoundParameters.ContainsKey("MetricName")) {
        $metricname = $PSBoundParameters["MetricName"]
        $null = $PSBoundParameters.Remove("MetricName")
    }

    $records = Az.Monitor.internal\Get-AzMetricDefinition @PSBoundParameters
    
    if ($metricname -ne $null) {
        $records | Where-Object {$_.NameValue -in $metricname}
    } else {
        $records
    }
}

}
