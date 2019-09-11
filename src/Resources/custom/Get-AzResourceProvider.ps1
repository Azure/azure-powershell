function Get-AzResourceProvider {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IProvider')]
    [CmdletBinding(DefaultParameterSetName='ListRegistered', PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('Gets the specified resource provider.')]
    param(
        [Parameter(ParameterSetName='GetByNamespace', Mandatory, HelpMessage='The namespace of the resource provider.')]
        [Alias('ProviderNamespace')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceProviderNamespace', Required, PossibleTypes=([System.String]), Description='The namespace of the resource provider.')]
        [System.String]
        # The namespace of the resource provider.
        ${ResourceProviderNamespace},

        [Parameter(ParameterSetName='ListAvailable', Mandatory, HelpMessage='If set, signals that all available providers should be returned.')]
        [System.Management.Automation.SwitchParameter]
        # If set, signals that all available providers should be returned.
        ${ListAvailable},

        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        if ($PSBoundParameters.ContainsKey("ListAvailable"))
        {
            $null = $PSBoundParameters.Remove("ListAvailable")
            Az.Resources.internal\Get-AzResourceProvider @PSBoundParameters
        }
        elseif ($PSBoundParameters.ContainsKey("ResourceProviderNamespace"))
        {
            Az.Resources.internal\Get-AzResourceProvider @PSBoundParameters
        }
        else
        {
            Az.Resources.internal\Get-AzResourceProvider @PSBoundParameters | Where-Object { $_.RegistrationState -eq "Registered" }
        }
    }
}