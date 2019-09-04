function New-AzManagedApplication {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180601.IApplication')]
    [CmdletBinding(DefaultParameterSetName='CreateRGExpanded1', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('Creates a new managed application.')]
    param(
        [Parameter(ParameterSetName='CreateRGExpanded', Mandatory, HelpMessage='The name of the managed application.')]
        [Alias('ApplicationName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='applicationName', Required, PossibleTypes=([System.String]), Description='The name of the managed application.')]
        [System.String]
        # The name of the managed application.
        ${Name},

        [Parameter(ParameterSetName='CreateRGExpanded', Mandatory, HelpMessage='The name of the resource group. The name is case insensitive.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the resource group. The name is case insensitive.')]
        [System.String]
        # The name of the resource group. The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='CreateRGExpanded', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName='CreateRGExpanded1', Mandatory, HelpMessage='The fully qualified ID of the managed application, including the managed application name and the managed application resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applications/{application-name}')]
        [Alias('ApplicationId')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='applicationId', Required, PossibleTypes=([System.String]), Description='The fully qualified ID of the managed application, including the managed application name and the managed application resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applications/{application-name}')]
        [System.String]
        # The fully qualified ID of the managed application, including the managed application name and the managed application resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applications/{application-name}
        ${Id},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The fully qualified path of managed application definition Id.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The fully qualified path of managed application definition Id.')]
        [Alias('ManagedApplicationDefinitionId')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='applicationDefinitionId', PossibleTypes=([System.String]), Description='The fully qualified path of managed application definition Id.')]
        [System.String]
        # The fully qualified path of managed application definition Id.
        ${ApplicationDefinitionId},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='Name and value pairs that define the managed application parameters. It can be a JObject or a well formed JSON string.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='Name and value pairs that define the managed application parameters. It can be a JObject or a well formed JSON string.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='parameters', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationPropertiesParameters]), Description='Name and value pairs that define the managed application parameters. It can be a JObject or a well formed JSON string.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationPropertiesParameters]
        # Name and value pairs that define the managed application parameters. It can be a JObject or a well formed JSON string.
        ${ApplicationPropertiesParameter},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The identity type.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The identity type.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ResourceIdentityType])]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='type', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ResourceIdentityType]), Description='The identity type.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ResourceIdentityType]
        # The identity type.
        ${IdentityType},

        [Parameter(ParameterSetName='CreateRGExpanded', Mandatory, HelpMessage='The kind of the managed application. Allowed values are MarketPlace and ServiceCatalog.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', Mandatory, HelpMessage='The kind of the managed application. Allowed values are MarketPlace and ServiceCatalog.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='kind', Required, PossibleTypes=([System.String]), Description='The kind of the managed application. Allowed values are MarketPlace and ServiceCatalog.')]
        [System.String]
        # The kind of the managed application. Allowed values are MarketPlace and ServiceCatalog.
        ${Kind},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='Resource location')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='Resource location')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='location', PossibleTypes=([System.String]), Description='Resource location')]
        [System.String]
        # Resource location
        ${Location},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='ID of the resource that manages this resource.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='ID of the resource that manages this resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='managedBy', PossibleTypes=([System.String]), Description='ID of the resource that manages this resource.')]
        [System.String]
        # ID of the resource that manages this resource.
        ${ManagedBy},

        [Parameter(ParameterSetName='CreateRGExpanded', Mandatory, HelpMessage='The managed resource group name.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', Mandatory, HelpMessage='The managed resource group name.')]
        [System.String]
        # The managed resource group name..
        ${ManagedResourceGroupName},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The plan name.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The plan name.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='name', PossibleTypes=([System.String]), Description='The plan name.')]
        [System.String]
        # The plan name.
        ${PlanName},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The product code.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The product code.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='product', PossibleTypes=([System.String]), Description='The product code.')]
        [System.String]
        # The product code.
        ${PlanProduct},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The promotion code.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The promotion code.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='promotionCode', PossibleTypes=([System.String]), Description='The promotion code.')]
        [System.String]
        # The promotion code.
        ${PlanPromotionCode},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The publisher ID.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The publisher ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='publisher', PossibleTypes=([System.String]), Description='The publisher ID.')]
        [System.String]
        # The publisher ID.
        ${PlanPublisher},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The plan''s version.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The plan''s version.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='version', PossibleTypes=([System.String]), Description='The plan''s version.')]
        [System.String]
        # The plan's version.
        ${PlanVersion},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The SKU capacity.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The SKU capacity.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='capacity', PossibleTypes=([System.Int32]), Description='The SKU capacity.')]
        [System.Int32]
        # The SKU capacity.
        ${SkuCapacity},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The SKU family.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The SKU family.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='family', PossibleTypes=([System.String]), Description='The SKU family.')]
        [System.String]
        # The SKU family.
        ${SkuFamily},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The SKU model.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The SKU model.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='model', PossibleTypes=([System.String]), Description='The SKU model.')]
        [System.String]
        # The SKU model.
        ${SkuModel},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The SKU name.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The SKU name.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='name', PossibleTypes=([System.String]), Description='The SKU name.')]
        [System.String]
        # The SKU name.
        ${SkuName},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The SKU size.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The SKU size.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='size', PossibleTypes=([System.String]), Description='The SKU size.')]
        [System.String]
        # The SKU size.
        ${SkuSize},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='The SKU tier.')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='The SKU tier.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='tier', PossibleTypes=([System.String]), Description='The SKU tier.')]
        [System.String]
        # The SKU tier.
        ${SkuTier},

        [Parameter(ParameterSetName='CreateRGExpanded', HelpMessage='Resource tags')]
        [Parameter(ParameterSetName='CreateRGExpanded1', HelpMessage='Resource tags')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='tags', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901Preview.IResourceTags]), Description='Resource tags')]
        [System.Collections.Hashtable]
        # Resource tags
        ${Tag},

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
        $Subscription = (Get-AzContext).Subscription.Id
        $ManagedResourceGroupId = "/subscriptions/{0}/resourcegroups/{1}" -f $Subscription, $ManagedResourceGroupName
        $null = $PSBoundParameters.Add("ManagedResourceGroupId", $ManagedResourceGroupId)
        $null = $PSBoundParameters.Remove("ManagedResourceGroupName")
        Az.Resources\New-AzManagedApplication @PSBoundParameters
    }
}