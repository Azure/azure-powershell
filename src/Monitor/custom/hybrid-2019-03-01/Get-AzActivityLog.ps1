<#
.Synopsis
Provides the list of records from the activity logs.
.Description
Provides the list of records from the activity logs.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.monitor/get-azactivitylog
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20150401.IEventData
.Link
https://docs.microsoft.com/en-us/powershell/module/az.monitor/get-azactivitylog
#>
function Get-AzActivityLog {
[Alias('Get-AzLog')]
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20150401.IEventData')]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Profile('hybrid-2019-03-01')]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Description('Provides the list of records from the activity logs.')]
param(
    [Parameter(Mandatory, HelpMessage='The Azure subscription Id.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The Azure subscription Id.
    ${SubscriptionId},

    #[Parameter(HelpMessage='Reduces the set of data collected. The **$filter** argument is very restricted and allows only the following patterns. - *List events for a resource group*: $filter=eventTimestamp ge ''2014-07-16T04:36:37.6407898Z'' and eventTimestamp le ''2014-07-20T04:36:37.6407898Z'' and resourceGroupName eq ''resourceGroupName''. - *List events for resource*: $filter=eventTimestamp ge ''2014-07-16T04:36:37.6407898Z'' and eventTimestamp le ''2014-07-20T04:36:37.6407898Z'' and resourceUri eq ''resourceURI''. - *List events for a subscription in a time range*: $filter=eventTimestamp ge ''2014-07-16T04:36:37.6407898Z'' and eventTimestamp le ''2014-07-20T04:36:37.6407898Z''. - *List events for a resource provider*: $filter=eventTimestamp ge ''2014-07-16T04:36:37.6407898Z'' and eventTimestamp le ''2014-07-20T04:36:37.6407898Z'' and resourceProvider eq ''resourceProviderName''. - *List events for a correlation Id*: $filter=eventTimestamp ge ''2014-07-16T04:36:37.6407898Z'' and eventTimestamp le ''2014-07-20T04:36:37.6407898Z'' and correlationId eq ''correlationID''.  **NOTE**: No other syntax is allowed.')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Query')]
    #[System.String]
    ## Reduces the set of data collected.<br>The **$filter** argument is very restricted and allows only the following patterns.<br>- *List events for a resource group*: $filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and resourceGroupName eq 'resourceGroupName'.<br>- *List events for resource*: $filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and resourceUri eq 'resourceURI'.<br>- *List events for a subscription in a time range*: $filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z'.<br>- *List events for a resource provider*: $filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and resourceProvider eq 'resourceProviderName'.<br>- *List events for a correlation Id*: $filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and correlationId eq 'correlationID'.<br><br>**NOTE**: No other syntax is allowed.
    #${Filter},

    #[Parameter(HelpMessage='Used to fetch events with only the given properties. The **$select** argument is a comma separated list of property names to be returned. Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Query')]
    #[System.String]
    ## Used to fetch events with only the given properties.<br>The **$select** argument is a comma separated list of property names to be returned. Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*
    #${Select},

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
    ${ResourceId}
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

    $null = $PSBoundParameters.Add("Filter", $filter)

    $filter

    Az.Monitor.internal\Get-AzActivityLog @PSBoundParameters
}

}
