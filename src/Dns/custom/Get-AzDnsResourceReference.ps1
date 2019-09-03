<#
.Synopsis
Returns the DNS records specified by the referencing targetResourceIds.
.Description
Returns the DNS records specified by the referencing targetResourceIds.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.dns/get-azdnsresourcereference
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IDnsResourceReferenceResultProperties
.Link
https://docs.microsoft.com/en-us/powershell/module/az.dns/get-azdnsresourcereference
#>
function Get-AzDnsResourceReference {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20180501.IDnsResourceReferenceResultProperties')]
[CmdletBinding(DefaultParameterSetName='GetExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
[Microsoft.Azure.PowerShell.Cmdlets.Dns.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Dns.Description('Returns the DNS records specified by the referencing targetResourceIds.')]
param(
    [Parameter(Mandatory, HelpMessage='Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # Specifies the Azure subscription ID, which uniquely identifies the Microsoft Azure subscription.
    ${SubscriptionId},

    [Parameter(HelpMessage='A list of references to azure resources for which referencing dns records need to be queried.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.Info(SerializedName='targetResources', PossibleTypes=([System.String]), Description='A list of references to azure resources for which referencing dns records need to be queried.')]
    [System.String[]]
    # A list of references to azure resources for which referencing dns records need to be queried.
    ${TargetResourceId},

    [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
    [Microsoft.Azure.PowerShell.Cmdlets.Dns.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

process {
    if ($PSBoundParameters.ContainsKey('TargetResourceId')) {
        $null = $PSBoundParameters.Remove('TargetResourceId')
        $PSBoundParameters['TargetResource'] = ($TargetResourceId | ForEach-Object { @{ Id = $_ } })
    }
    Az.Dns.internal\Get-AzDnsResourceReference @PSBoundParameters
}
}
