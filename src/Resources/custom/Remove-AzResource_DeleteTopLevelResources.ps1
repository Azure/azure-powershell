function Remove-AzResource_DeleteTopLevelResource {
    [OutputType('System.Boolean')]
    [CmdletBinding(DefaultParameterSetName='DeleteTopLevelResource', PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('Deletes a resource by ID.')]
    param(
        [Parameter(Mandatory, HelpMessage='The name of the resource to delete.')]
        [Alias('ResourceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceName', Required, PossibleTypes=([System.String]), Description='The name of the resource to delete.')]
        [System.String]
        # The name of the resource to delete.
        ${Name},

        [Parameter(Mandatory, HelpMessage='The namespace of the resource provider.')]
        [Alias('ResourceProviderNamespace')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceProviderNamespace', Required, PossibleTypes=([System.String]), Description='The namespace of the resource provider.')]
        [System.String]
        # The namespace of the resource provider.
        ${ProviderNamespace},

        [Parameter(Mandatory, HelpMessage='The name of the resource group that contains the resource to delete. The name is case insensitive.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the resource group that contains the resource to delete. The name is case insensitive.')]
        [System.String]
        # The name of the resource group that contains the resource to delete. The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The resource type.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceType', Required, PossibleTypes=([System.String]), Description='The resource type.')]
        [System.String]
        # The resource type.
        ${ResourceType},

        [Parameter(Mandatory, HelpMessage='The API version to use for the operation.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='api-version', Required, PossibleTypes=([System.String]), Description='The API version to use for the operation.')]
        [System.String]
        # The API version to use for the operation.
        ${ApiVersion},

        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(HelpMessage='When specified, PassThru will force the cmdlet return a ''bool'' given that there isn''t a return type by default.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.
        ${PassThru},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(HelpMessage='Run the command as a job')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

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

        [Parameter(HelpMessage='Run the command asynchronously')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

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
        $ResourceId = "/subscriptions/{0}/resourceGroups/{1}/providers/{2}/{3}/{4}" -f $SubscriptionId, $ResourceGroupName, $ProviderNamespace, $ResourceType, $Name
        $null = $PSBoundParameters.Remove("SubscriptionId")
        $null = $PSBoundParameters.Remove("ResourceGroupName")
        $null = $PSBoundParameters.Remove("ProviderNamespace")
        $null = $PSBoundParameters.Remove("ResourceType")
        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Add("ResourceId", $ResourceId)
        Az.Resources\Remove-AzResource @PSBoundParameters
    }
}