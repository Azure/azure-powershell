<#
.Synopsis
Check the give namespace name availability.
.Description
Check the give namespace name availability.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.servicebus/test-azservicebusnameavailability
#>
function Test-AzServiceBusNameAvailability_DisasterRecoveryConfiguration {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.ICheckNameAvailabilityResult')]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Description('Check the give namespace name availability.')]
param(
    [Parameter(Mandatory, HelpMessage='The namespace name')]
    [Alias('Namespace')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
    [System.String]
    ${NamespaceName},

    [Parameter(Mandatory, HelpMessage='Name of the Resource group within the Azure subscription.')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
    [System.String]
    ${ResourceGroupName},

    [Parameter(HelpMessage='Subscription credentials that uniquely identify a Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Path')]
    [System.String]
    ${SubscriptionId},

    [Parameter(Mandatory, HelpMessage='The Name to check the namespace name availability and The namespace name can contain only letters, numbers, and hyphens. The namespace must start with a letter, and it must end with a letter or number.')]
    [Alias('Alias', 'AliasName', 'DisasterRecoveryConfiguration')]
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Category('Body')]
    [System.String]
    ${DisasterRecoveryConfigurationName},

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

process {
    Az.ServiceBus.internal\Test-AzServiceBusDisasterRecoveryConfigurationNameAvailability @PSBoundParameters
}

}
