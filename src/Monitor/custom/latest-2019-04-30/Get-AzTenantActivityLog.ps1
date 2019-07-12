<#
.Synopsis
Gets the Activity Logs for the Tenant.<br>Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).<br>One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.
.Description
Gets the Activity Logs for the Tenant.<br>Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.).<br>One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.monitor/get-aztenantactivitylog
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20150401.IEventData
.Link
https://docs.microsoft.com/en-us/powershell/module/az.monitor/get-aztenantactivitylog
#>
function Get-AzTenantActivityLog {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20150401.IEventData')]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Description('Gets the Activity Logs for the Tenant. Everything that is applicable to the API to get the Activity Logs for the subscription is applicable to this API (the parameters, $filter, etc.). One thing to point out here is that this API does *not* retrieve the logs at the individual subscription of the tenant but only surfaces the logs that were generated at the tenant level.')]
param(
    #[Parameter(HelpMessage='Reduces the set of data collected.  The **$filter** is very restricted and allows only the following patterns. - List events for a resource group: $filter=eventTimestamp ge ''<Start Time>'' and eventTimestamp le ''<End Time>'' and eventChannels eq ''Admin, Operation'' and resourceGroupName eq ''<ResourceGroupName>''. - List events for resource: $filter=eventTimestamp ge ''<Start Time>'' and eventTimestamp le ''<End Time>'' and eventChannels eq ''Admin, Operation'' and resourceUri eq ''<ResourceURI>''. - List events for a subscription: $filter=eventTimestamp ge ''<Start Time>'' and eventTimestamp le ''<End Time>'' and eventChannels eq ''Admin, Operation''. - List events for a resource provider: $filter=eventTimestamp ge ''<Start Time>'' and eventTimestamp le ''<End Time>'' and eventChannels eq ''Admin, Operation'' and resourceProvider eq ''<ResourceProviderName>''. - List events for a correlation Id: api-version=2014-04-01&$filter=eventTimestamp ge ''2014-07-16T04:36:37.6407898Z'' and eventTimestamp le ''2014-07-20T04:36:37.6407898Z'' and eventChannels eq ''Admin, Operation'' and correlationId eq ''<CorrelationID>''. **NOTE**: No other syntax is allowed.')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Query')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='$filter', PossibleTypes=([System.String]), Description='Reduces the set of data collected.  The **$filter** is very restricted and allows only the following patterns. - List events for a resource group: $filter=eventTimestamp ge ''<Start Time>'' and eventTimestamp le ''<End Time>'' and eventChannels eq ''Admin, Operation'' and resourceGroupName eq ''<ResourceGroupName>''. - List events for resource: $filter=eventTimestamp ge ''<Start Time>'' and eventTimestamp le ''<End Time>'' and eventChannels eq ''Admin, Operation'' and resourceUri eq ''<ResourceURI>''. - List events for a subscription: $filter=eventTimestamp ge ''<Start Time>'' and eventTimestamp le ''<End Time>'' and eventChannels eq ''Admin, Operation''. - List events for a resource provider: $filter=eventTimestamp ge ''<Start Time>'' and eventTimestamp le ''<End Time>'' and eventChannels eq ''Admin, Operation'' and resourceProvider eq ''<ResourceProviderName>''. - List events for a correlation Id: api-version=2014-04-01&$filter=eventTimestamp ge ''2014-07-16T04:36:37.6407898Z'' and eventTimestamp le ''2014-07-20T04:36:37.6407898Z'' and eventChannels eq ''Admin, Operation'' and correlationId eq ''<CorrelationID>''. **NOTE**: No other syntax is allowed.')]
    #[System.String]
    ## Reduces the set of data collected. <br>The **$filter** is very restricted and allows only the following patterns.<br>- List events for a resource group: $filter=eventTimestamp ge '<Start Time>' and eventTimestamp le '<End Time>' and eventChannels eq 'Admin, Operation' and resourceGroupName eq '<ResourceGroupName>'.<br>- List events for resource: $filter=eventTimestamp ge '<Start Time>' and eventTimestamp le '<End Time>' and eventChannels eq 'Admin, Operation' and resourceUri eq '<ResourceURI>'.<br>- List events for a subscription: $filter=eventTimestamp ge '<Start Time>' and eventTimestamp le '<End Time>' and eventChannels eq 'Admin, Operation'.<br>- List events for a resource provider: $filter=eventTimestamp ge '<Start Time>' and eventTimestamp le '<End Time>' and eventChannels eq 'Admin, Operation' and resourceProvider eq '<ResourceProviderName>'.<br>- List events for a correlation Id: api-version=2014-04-01&$filter=eventTimestamp ge '2014-07-16T04:36:37.6407898Z' and eventTimestamp le '2014-07-20T04:36:37.6407898Z' and eventChannels eq 'Admin, Operation' and correlationId eq '<CorrelationID>'.<br>**NOTE**: No other syntax is allowed.
    #${Filter},

    #[Parameter(HelpMessage='Used to fetch events with only the given properties. The **$select** argument is a comma separated list of property names to be returned. Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Query')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='$select', PossibleTypes=([System.String]), Description='Used to fetch events with only the given properties. The **$select** argument is a comma separated list of property names to be returned. Possible values are: *authorization*, *claims*, *correlationId*, *description*, *eventDataId*, *eventName*, *eventTimestamp*, *httpRequest*, *level*, *operationId*, *operationName*, *properties*, *resourceGroupName*, *resourceProviderName*, *resourceId*, *status*, *submissionTimestamp*, *subStatus*, *subscriptionId*')]
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
