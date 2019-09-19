function New-AzPolicyDefinition {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyDefinition')]
    [CmdletBinding(DefaultParameterSetName='CreateExpandedPolicyRuleString', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('This operation creates or updates a policy definition in the given subscription with the given name.')]
    param(
        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString', Mandatory, HelpMessage='The name of the policy definition to create.')]
        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString1', Mandatory, HelpMessage='The name of the policy definition to create.')]
        [Alias('PolicyDefinitionName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='policyDefinitionName', Required, PossibleTypes=([System.String]), Description='The name of the policy definition to create.')]
        [System.String]
        # The name of the policy definition to create.
        ${Name},

        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString1', Mandatory, HelpMessage='The ID of the management group.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='managementGroupId', Required, PossibleTypes=([System.String]), Description='The ID of the management group.')]
        [System.String]
        # The ID of the management group.
        ${ManagementGroupName},

        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString', HelpMessage='Required if a parameter is used in policy rule.')]
        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString1', HelpMessage='Required if a parameter is used in policy rule.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='parameters', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesParameters]), Description='Required if a parameter is used in policy rule.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesParameters]
        # Required if a parameter is used in policy rule.
        ${DefinitionPropertiesParameter},

        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString', HelpMessage='The policy definition description.')]
        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString1', HelpMessage='The policy definition description.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='description', PossibleTypes=([System.String]), Description='The policy definition description.')]
        [System.String]
        # The policy definition description.
        ${Description},

        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString', HelpMessage='The display name of the policy definition.')]
        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString1', HelpMessage='The display name of the policy definition.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='displayName', PossibleTypes=([System.String]), Description='The display name of the policy definition.')]
        [System.String]
        # The display name of the policy definition.
        ${DisplayName},

        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString', HelpMessage='The policy definition metadata.')]
        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString1', HelpMessage='The policy definition metadata.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='metadata', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesMetadata]), Description='The policy definition metadata.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesMetadata]
        # The policy definition metadata.
        ${Metadata},

        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString', HelpMessage='The policy definition mode. Possible values are NotSpecified, Indexed, and All.')]
        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString1', HelpMessage='The policy definition mode. Possible values are NotSpecified, Indexed, and All.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyMode])]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='mode', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyMode]), Description='The policy definition mode. Possible values are NotSpecified, Indexed, and All.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyMode]
        # The policy definition mode. Possible values are NotSpecified, Indexed, and All.
        ${Mode},

        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString', Mandatory, HelpMessage='The policy rule.')]
        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString1', Mandatory, HelpMessage='The policy rule.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='policyRule', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesPolicyRule]), Description='The policy rule.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesPolicyRule]
        # The policy rule.
        ${PolicyRule},

        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString', HelpMessage='The type of policy definition. Possible values are NotSpecified, BuiltIn, and Custom.')]
        [Parameter(ParameterSetName='CreateExpandedPolicyRuleString1', HelpMessage='The type of policy definition. Possible values are NotSpecified, BuiltIn, and Custom.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyType])]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='policyType', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyType]), Description='The type of policy definition. Possible values are NotSpecified, BuiltIn, and Custom.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyType]
        # The type of policy definition. Possible values are NotSpecified, BuiltIn, and Custom.
        ${PolicyType},

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
        if ($PSBoundParameters.ContainsKey("ManagementGroupName"))
        {
            Az.Resources.private\New-AzPolicyDefinition_CreateExpanded1 @PSBoundParameters
        }
        else
        {
            Az.Resources.private\New-AzPolicyDefinition_CreateExpanded @PSBoundParameters
        }
    }
}