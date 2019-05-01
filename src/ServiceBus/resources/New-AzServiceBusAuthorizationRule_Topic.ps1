<#
.Synopsis
Creates an authorization rule for the specified topic.
.Description
Creates an authorization rule for the specified topic.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.servicebus/new-azservicebustopicauthorizationrule
#>
function New-AzServiceBusTopicAuthorizationRule {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.ISbAuthorizationRule')]
[CmdletBinding(DefaultParameterSetName='CreateSubscriptionIdViaHost', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Description('Creates an authorization rule for the specified topic.')]
param(
    [Parameter(Mandatory, HelpMessage='The authorization rule name.')]
    [Alias('AuthorizationRuleName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
    [System.String]
    ${Name},

    [Parameter(Mandatory, HelpMessage='The namespace name')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
    [System.String]
    ${NamespaceName},

    [Parameter(Mandatory, HelpMessage='Name of the Resource group within the Azure subscription.')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
    [System.String]
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Create', Mandatory, HelpMessage='Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
    [Parameter(ParameterSetName='CreateExpanded', Mandatory, HelpMessage='Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
    [System.String]
    ${SubscriptionId},

    [Parameter(Mandatory, HelpMessage='The topic name.')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
    [System.String]
    ${TopicName},

    [Parameter(ParameterSetName='Create', ValueFromPipeline, HelpMessage='Description of a namespace authorization rule.')]
    [Parameter(ParameterSetName='CreateSubscriptionIdViaHost', ValueFromPipeline, HelpMessage='Description of a namespace authorization rule.')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.ISbAuthorizationRule]
    ${Parameter},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory, HelpMessage='The rights associated with the rule.')]
    [Parameter(ParameterSetName='CreateSubscriptionIdViaHostExpanded', Mandatory, HelpMessage='The rights associated with the rule.')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.AccessRights[]]
    ${Right},

    [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Azure')]
    [System.Management.Automation.PSObject]
    ${DefaultProfile},

    [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${Break},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Runtime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
    [System.Uri]
    ${Proxy},

    [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    ${ProxyCredential},

    [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PsCmdlet.ParameterSetName
        $mapping = @{
            Create = 'Az.ServiceBus.private\New-AzServiceBusTopicAuthorizationRule_Create';
            CreateExpanded = 'Az.ServiceBus.private\New-AzServiceBusTopicAuthorizationRule_CreateExpanded';
            CreateSubscriptionIdViaHost = 'Az.ServiceBus.private\New-AzServiceBusTopicAuthorizationRule_CreateSubscriptionIdViaHost';
            CreateSubscriptionIdViaHostExpanded = 'Az.ServiceBus.private\New-AzServiceBusTopicAuthorizationRule_CreateSubscriptionIdViaHostExpanded';
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($myInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
