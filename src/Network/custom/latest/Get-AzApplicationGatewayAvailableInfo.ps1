<#
.Synopsis
Lists all available request headers, response headers, or server variables.
.Description
Lists all available request headers, response headers, or server variables.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewayavailableinfo
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Network.Models.ApplicationGatewayAvailableInfo
.Link
https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewayavailableinfo
#>
function Get-AzApplicationGatewayAvailableInfo {
[Alias('Get-AzApplicationGatewayAvailableServerVariableAndHeader')]
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Network.Models.ApplicationGatewayAvailableInfo')]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
[Microsoft.Azure.PowerShell.Cmdlets.Network.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Network.Description('Lists all available request headers, response headers, or server variables.')]
param(
    [Parameter(Mandatory, HelpMessage='The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(HelpMessage='Includes the available request headers from the application gateway')]
    [Alias('RequestHeader')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Path')]
    [System.Management.Automation.SwitchParameter]
    # Includes the available request headers from the application gateway
    ${IncludeRequestHeaders},

    [Parameter(HelpMessage='Includes the available response headers from the application gateway')]
    [Alias('ResponseHeader')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Path')]
    [System.Management.Automation.SwitchParameter]
    # Includes the available response headers from the application gateway
    ${IncludeResponseHeaders},

    [Parameter(HelpMessage='Includes the available server variables from the application gateway')]
    [Alias('ServerVariable')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Path')]
    [System.Management.Automation.SwitchParameter]
    # Includes the available server variables from the application gateway
    ${IncludeServerVariables},

    [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)
process {
    $result = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.Network.Models.ApplicationGatewayAvailableInfo
    $hasIncludeRequestHeaders = $PSBoundParameters.ContainsKey('IncludeRequestHeaders')
    $hasIncludeResponseHeaders = $PSBoundParameters.ContainsKey('IncludeResponseHeaders')
    $hasIncludeServerVariables = $PSBoundParameters.ContainsKey('IncludeServerVariables')
    if ($hasIncludeRequestHeaders) {
        $null = $PSBoundParameters.Remove('IncludeRequestHeaders')
    }
    if ($hasIncludeResponseHeaders) {
        $null = $PSBoundParameters.Remove('IncludeResponseHeaders')
    }
    if ($hasIncludeServerVariables) {
        $null = $PSBoundParameters.Remove('IncludeServerVariables')
    }
    if ($hasIncludeRequestHeaders) {
        $result.AvailableRequestHeaders = Az.Network.internal\Get-AzApplicationGatewayAvailableRequestHeader @PSBoundParameters
    }
    if ($hasIncludeResponseHeaders) {
        $result.AvailableResponseHeaders = Az.Network.internal\Get-AzApplicationGatewayAvailableResponseHeader @PSBoundParameters
    }
    if ($hasIncludeServerVariables) {
        $result.AvailableServerVariables = Az.Network.internal\Get-AzApplicationGatewayAvailableServerVariable @PSBoundParameters
    }
    $result
}
}
