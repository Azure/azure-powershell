function Get-AzProviderFeature {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20151201.IFeatureResult')]
    [CmdletBinding(DefaultParameterSetName='ListRegistered', PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('Gets the preview feature with the specified name.')]
    param(
        [Parameter(ParameterSetName='GetByFeature', Mandatory, HelpMessage='The name of the feature to get.')]
        [Alias('FeatureName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='featureName', Required, PossibleTypes=([System.String]), Description='The name of the feature to get.')]
        [System.String]
        # The name of the feature to get.
        ${Name},

        [Parameter(ParameterSetName='GetByFeature', Mandatory, HelpMessage='The resource provider namespace for the feature.')]
        [Parameter(ParameterSetName='ListByNamespace', Mandatory, HelpMessage='The namespace of the resource provider for getting features.')]
        [Alias('ProviderNamespace')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceProviderNamespace', Required, PossibleTypes=([System.String]), Description='The resource provider namespace for the feature.')]
        [System.String]
        # The resource provider namespace for the feature.
        ${ResourceProviderNamespace},

        [Parameter(ParameterSetName='ListAvailable', Mandatory, HelpMessage='If set, signals that all available features should be returned.')]
        [System.Management.Automation.SwitchParameter]
        # If set, signals that all available features should be returned.
        ${ListAvailable},

        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline, HelpMessage='Identity Parameter')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity]
        # Identity Parameter
        ${InputObject},

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
            Az.Resources.internal\Get-AzProviderFeature @PSBoundParameters
        }
        elseif ($PSBoundParameters.ContainsKey("ResourceProviderNamespace"))
        {
            Az.Resources.internal\Get-AzProviderFeature @PSBoundParameters
        }
        else
        {
            Az.Resources.internal\Get-AzProviderFeature @PSBoundParameters | Where-Object { $_.State -eq "Registered" }
        }
    }
}