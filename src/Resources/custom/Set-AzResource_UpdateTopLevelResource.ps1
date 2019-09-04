function Set-AzResource_UpdateTopLevelResource {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IGenericResource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('Creates a resource.')]
    param(
        [Parameter(Mandatory, HelpMessage='The name of the resource to create.')]
        [Alias('ResourceName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceName', Required, PossibleTypes=([System.String]), Description='The name of the resource to create.')]
        [System.String]
        # The name of the resource to create.
        ${Name},

        [Parameter(Mandatory, HelpMessage='The namespace of the resource provider.')]
        [Alias('ResourceProviderNamespace')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceProviderNamespace', Required, PossibleTypes=([System.String]), Description='The namespace of the resource provider.')]
        [System.String]
        # The namespace of the resource provider.
        ${ProviderNamespace},

        [Parameter(Mandatory, HelpMessage='The name of the resource group for the resource. The name is case insensitive.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the resource group for the resource. The name is case insensitive.')]
        [System.String]
        # The name of the resource group for the resource. The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The resource type of the resource to create.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceType', Required, PossibleTypes=([System.String]), Description='The resource type of the resource to create.')]
        [System.String]
        # The resource type of the resource to create.
        ${ResourceType},

        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The API version to use for the operation.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='api-version', Required, PossibleTypes=([System.String]), Description='The API version to use for the operation.')]
        [System.String]
        # The API version to use for the operation.
        ${ApiVersion},

        [Parameter(HelpMessage='The identity type.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ResourceIdentityType])]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='type', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ResourceIdentityType]), Description='The identity type.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ResourceIdentityType]
        # The identity type.
        ${IdentityType},

        [Parameter(HelpMessage='The list of user identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: ''/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}''.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='userAssignedIdentities', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IIdentityUserAssignedIdentities]), Description='The list of user identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: ''/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}''.')]
        [System.Collections.Hashtable]
        # The list of user identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        ${IdentityUserAssignedIdentity},

        [Parameter(HelpMessage='The kind of the resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='kind', PossibleTypes=([System.String]), Description='The kind of the resource.')]
        [System.String]
        # The kind of the resource.
        ${Kind},

        [Parameter(HelpMessage='Resource location')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='location', PossibleTypes=([System.String]), Description='Resource location')]
        [System.String]
        # Resource location
        ${Location},

        [Parameter(HelpMessage='ID of the resource that manages this resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='managedBy', PossibleTypes=([System.String]), Description='ID of the resource that manages this resource.')]
        [System.String]
        # ID of the resource that manages this resource.
        ${ManagedBy},

        [Parameter(HelpMessage='The plan name.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='name', PossibleTypes=([System.String]), Description='The plan name.')]
        [System.String]
        # The plan name.
        ${PlanName},

        [Parameter(HelpMessage='The product code.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='product', PossibleTypes=([System.String]), Description='The product code.')]
        [System.String]
        # The product code.
        ${PlanProduct},

        [Parameter(HelpMessage='The promotion code.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='promotionCode', PossibleTypes=([System.String]), Description='The promotion code.')]
        [System.String]
        # The promotion code.
        ${PlanPromotionCode},

        [Parameter(HelpMessage='The publisher ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='publisher', PossibleTypes=([System.String]), Description='The publisher ID.')]
        [System.String]
        # The publisher ID.
        ${PlanPublisher},

        [Parameter(HelpMessage='The plan''s version.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='version', PossibleTypes=([System.String]), Description='The plan''s version.')]
        [System.String]
        # The plan's version.
        ${PlanVersion},

        [Parameter(HelpMessage='The resource properties.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='properties', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IGenericResourceProperties]), Description='The resource properties.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IGenericResourceProperties]
        # The resource properties.
        ${Property},

        [Parameter(HelpMessage='The SKU capacity.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='capacity', PossibleTypes=([System.Int32]), Description='The SKU capacity.')]
        [System.Int32]
        # The SKU capacity.
        ${SkuCapacity},

        [Parameter(HelpMessage='The SKU family.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='family', PossibleTypes=([System.String]), Description='The SKU family.')]
        [System.String]
        # The SKU family.
        ${SkuFamily},

        [Parameter(HelpMessage='The SKU model.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='model', PossibleTypes=([System.String]), Description='The SKU model.')]
        [System.String]
        # The SKU model.
        ${SkuModel},

        [Parameter(HelpMessage='The SKU name.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='name', PossibleTypes=([System.String]), Description='The SKU name.')]
        [System.String]
        # The SKU name.
        ${SkuName},

        [Parameter(HelpMessage='The SKU size.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='size', PossibleTypes=([System.String]), Description='The SKU size.')]
        [System.String]
        # The SKU size.
        ${SkuSize},

        [Parameter(HelpMessage='The SKU tier.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='tier', PossibleTypes=([System.String]), Description='The SKU tier.')]
        [System.String]
        # The SKU tier.
        ${SkuTier},

        [Parameter(HelpMessage='Resource tags')]
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
        $null = $PSBoundParameters.Add("ParentResourcePath", "/")
        Az.Resources\Set-AzResource @PSBoundParameters
    }
}