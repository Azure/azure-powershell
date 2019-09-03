<#
.Synopsis
Gets the backend health for given combination of backend pool and http setting of the specified application gateway in a resource group.
.Description
Gets the backend health for given combination of backend pool and http setting of the specified application gateway in a resource group.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewaybackendhealth
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayOnDemandProbe
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHealthPool
.Link
https://docs.microsoft.com/en-us/powershell/module/az.network/get-azapplicationgatewaybackendhealth
#>
function Get-AzApplicationGatewayBackendHealth {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendHealthPool')]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
[Microsoft.Azure.PowerShell.Cmdlets.Network.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Network.Description('Gets the backend health for given combination of backend pool and http setting of the specified application gateway in a resource group.')]
param(
    [Parameter(ParameterSetName='DemandExpanded', Mandatory, HelpMessage='The name of the application gateway.')]
    [Alias('ApplicationGatewayName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='applicationGatewayName', Required, PossibleTypes=([System.String]), Description='The name of the application gateway.')]
    [System.String]
    # The name of the application gateway.
    ${Name},

    [Parameter(ParameterSetName='DemandExpanded', Mandatory, HelpMessage='The name of the resource group.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the resource group.')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='DemandExpanded', Mandatory, HelpMessage='The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(Mandatory, HelpMessage='Gets the backend health via an on demand probe.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Path')]
    [System.Management.Automation.SwitchParameter]
    # Gets the backend health via an on demand probe.
    ${AsOnDemand},

    [Parameter(ParameterSetName='DemandViaIdentityExpanded', Mandatory, ValueFromPipeline, HelpMessage='Identity Parameter')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity]
    # Identity Parameter
    ${InputObject},

    [Parameter(HelpMessage='Expands BackendAddressPool and BackendHttpSettings referenced in backend health.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Query')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='$expand', PossibleTypes=([System.String]), Description='Expands BackendAddressPool and BackendHttpSettings referenced in backend health.')]
    [System.String]
    # Expands BackendAddressPool and BackendHttpSettings referenced in backend health.
    ${Expand},

    [Parameter(ParameterSetName='DemandExpanded', HelpMessage='Name of backend http setting of application gateway to be used for test probe')]
    [Parameter(ParameterSetName='DemandViaIdentityExpanded', HelpMessage='Name of backend http setting of application gateway to be used for test probe')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='backendHttpSettingName', PossibleTypes=([System.String]), Description='Name of backend http setting of application gateway to be used for test probe')]
    [System.String]
    # Name of backend http setting of application gateway to be used for test probe
    ${BackendHttpSettingName},

    [Parameter(ParameterSetName='DemandExpanded', HelpMessage='Name of backend pool of application gateway to which probe request will be sent.')]
    [Parameter(ParameterSetName='DemandViaIdentityExpanded', HelpMessage='Name of backend pool of application gateway to which probe request will be sent.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='backendPoolName', PossibleTypes=([System.String]), Description='Name of backend pool of application gateway to which probe request will be sent.')]
    [System.String]
    # Name of backend pool of application gateway to which probe request will be sent.
    ${BackendPoolName},

    [Parameter(ParameterSetName='DemandExpanded', HelpMessage='Host name to send the probe to.')]
    [Parameter(ParameterSetName='DemandViaIdentityExpanded', HelpMessage='Host name to send the probe to.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='host', PossibleTypes=([System.String]), Description='Host name to send the probe to.')]
    [System.String]
    # Host name to send the probe to.
    ${Host},

    [Parameter(ParameterSetName='DemandExpanded', HelpMessage='Body that must be contained in the health response. Default value is empty.')]
    [Parameter(ParameterSetName='DemandViaIdentityExpanded', HelpMessage='Body that must be contained in the health response. Default value is empty.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='body', PossibleTypes=([System.String]), Description='Body that must be contained in the health response. Default value is empty.')]
    [System.String]
    # Body that must be contained in the health response. Default value is empty.
    ${MatchBody},

    [Parameter(ParameterSetName='DemandExpanded', HelpMessage='Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.')]
    [Parameter(ParameterSetName='DemandViaIdentityExpanded', HelpMessage='Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='statusCodes', PossibleTypes=([System.String]), Description='Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.')]
    [System.String[]]
    # Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
    ${MatchStatusCode},

    [Parameter(ParameterSetName='DemandExpanded', HelpMessage='Relative path of probe. Valid path starts from ''/''. Probe is sent to <Protocol>://<host>:<port><path>')]
    [Parameter(ParameterSetName='DemandViaIdentityExpanded', HelpMessage='Relative path of probe. Valid path starts from ''/''. Probe is sent to <Protocol>://<host>:<port><path>')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='path', PossibleTypes=([System.String]), Description='Relative path of probe. Valid path starts from ''/''. Probe is sent to <Protocol>://<host>:<port><path>')]
    [System.String]
    # Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>
    ${Path},

    [Parameter(ParameterSetName='DemandExpanded', HelpMessage='Whether the host header should be picked from the backend http settings. Default value is false.')]
    [Parameter(ParameterSetName='DemandViaIdentityExpanded', HelpMessage='Whether the host header should be picked from the backend http settings. Default value is false.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='pickHostNameFromBackendHttpSettings', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='Whether the host header should be picked from the backend http settings. Default value is false.')]
    [System.Management.Automation.SwitchParameter]
    # Whether the host header should be picked from the backend http settings. Default value is false.
    ${PickHostNameFromBackendHttpSetting},

    [Parameter(ParameterSetName='DemandExpanded', HelpMessage='The protocol used for the probe.')]
    [Parameter(ParameterSetName='DemandViaIdentityExpanded', HelpMessage='The protocol used for the probe.')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol])]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='protocol', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol]), Description='The protocol used for the probe.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ApplicationGatewayProtocol]
    # The protocol used for the probe.
    ${Protocol},

    [Parameter(ParameterSetName='DemandExpanded', HelpMessage='The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable values are from 1 second to 86400 seconds.')]
    [Parameter(ParameterSetName='DemandViaIdentityExpanded', HelpMessage='The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable values are from 1 second to 86400 seconds.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(SerializedName='timeout', PossibleTypes=([System.Int32]), Description='The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable values are from 1 second to 86400 seconds.')]
    [System.Int32]
    # The probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period. Acceptable values are from 1 second to 86400 seconds.
    ${Timeout},

    [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(HelpMessage='Run the command as a job')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter(HelpMessage='Run the command asynchronously')]
    [Microsoft.Azure.PowerShell.Cmdlets.Network.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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
    $null = $PSBoundParameters.Remove('AsOnDemand')
    $healthOnDemand = Az.Network.internal\Get-AzApplicationGatewayBackendHealthOnDemand @PSBoundParameters
    $healthPool = New-Object -TypeName 'Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ApplicationGatewayBackendHealthPool'
    Get-Member -InputObject $healthOnDemand | Where-Object { $_.MemberType -eq 'Property' } | ForEach-Object {
      $propertyName = $_.Name
      if($propertyName -eq 'BackendHealthHttpSetting') {
        $propertyName = 'BackendHttpSettingsCollection'
      }
      $healthPool.$propertyName = $healthOnDemand."$($_.Name)"
    }
    $healthPool
}
}
