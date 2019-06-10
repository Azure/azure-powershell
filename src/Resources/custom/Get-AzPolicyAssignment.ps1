function Get-AzPolicyAssignment {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyAssignment', 'Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20151101.IPolicyAssignment')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(ParameterSetName='ListByPolicyDefinition', Mandatory, HelpMessage='The parent resource path.')]
        [Parameter(ParameterSetName='ListByPolicyDefinition2', Mandatory, HelpMessage='The parent resource path. Use empty string if there is none.')]
        [Parameter(ParameterSetName='ListWithDescendents', Mandatory, HelpMessage='The parent resource path.')]
        [Parameter(ParameterSetName='ListWithDescendents2', Mandatory, HelpMessage='The parent resource path. Use empty string if there is none.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ParentResourcePath},

        [Parameter(ParameterSetName='ListByPolicyDefinition', Mandatory, HelpMessage='The name of the resource group containing the resource.')]
        [Parameter(ParameterSetName='ListByPolicyDefinition1', Mandatory, HelpMessage='The name of the resource group that contains policy assignments.')]
        [Parameter(ParameterSetName='ListByPolicyDefinition2', Mandatory, HelpMessage='The name of the resource group containing the resource.')]
        [Parameter(ParameterSetName='ListWithDescendents', Mandatory, HelpMessage='The name of the resource group containing the resource.')]
        [Parameter(ParameterSetName='ListWithDescendents1', Mandatory, HelpMessage='The name of the resource group that contains policy assignments.')]
        [Parameter(ParameterSetName='ListWithDescendents2', Mandatory, HelpMessage='The name of the resource group containing the resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ListByPolicyDefinition', Mandatory, HelpMessage='The name of the resource.')]
        [Parameter(ParameterSetName='ListByPolicyDefinition2', Mandatory, HelpMessage='The name of the resource.')]
        [Parameter(ParameterSetName='ListWithDescendents', Mandatory, HelpMessage='The name of the resource.')]
        [Parameter(ParameterSetName='ListWithDescendents2', Mandatory, HelpMessage='The name of the resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ResourceName},

        [Parameter(ParameterSetName='ListByPolicyDefinition', Mandatory, HelpMessage='The namespace of the resource provider. For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines)')]
        [Parameter(ParameterSetName='ListByPolicyDefinition2', Mandatory, HelpMessage='The namespace of the resource provider. For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines)')]
        [Parameter(ParameterSetName='ListWithDescendents', Mandatory, HelpMessage='The namespace of the resource provider. For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines)')]
        [Parameter(ParameterSetName='ListWithDescendents2', Mandatory, HelpMessage='The namespace of the resource provider. For example, the namespace of a virtual machine is Microsoft.Compute (from Microsoft.Compute/virtualMachines)')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ResourceProviderNamespace},

        [Parameter(ParameterSetName='ListByPolicyDefinition', Mandatory, HelpMessage='The resource type.')]
        [Parameter(ParameterSetName='ListByPolicyDefinition2', Mandatory, HelpMessage='The resource type name. For example the type name of a web app is ''sites'' (from Microsoft.Web/sites).')]
        [Parameter(ParameterSetName='ListWithDescendents', Mandatory, HelpMessage='The resource type.')]
        [Parameter(ParameterSetName='ListWithDescendents2', Mandatory, HelpMessage='The resource type name. For example the type name of a web app is ''sites'' (from Microsoft.Web/sites).')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ResourceType},

        [Parameter(ParameterSetName='ListWithDescendents', Mandatory, HelpMessage='Indicates that the list of returned policy assignments should include all assignments related to the given scope, including those from ancestor scopes and those from descendent scopes.')]
        [Parameter(ParameterSetName='ListWithDescendents1', Mandatory, HelpMessage='Indicates that the list of returned policy assignments should include all assignments related to the given scope, including those from ancestor scopes and those from descendent scopes.')]
        [Parameter(ParameterSetName='ListWithDescendents2', Mandatory, HelpMessage='Indicates that the list of returned policy assignments should include all assignments related to the given scope, including those from ancestor scopes and those from descendent scopes.')]
        [Parameter(ParameterSetName='ListWithDescendents3', Mandatory, HelpMessage='Indicates that the list of returned policy assignments should include all assignments related to the given scope, including those from ancestor scopes and those from descendent scopes.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.Management.Automation.SwitchParameter]
        ${IncludeDescendent},

        [Parameter(ParameterSetName="ListByPolicyDefinition", Mandatory, HelpMessage='Limits the list of returned policy assignments to those assigning the policy definition identified by this fully qualified ID.')]
        [Parameter(ParameterSetName="ListByPolicyDefinition1", Mandatory, HelpMessage='Limits the list of returned policy assignments to those assigning the policy definition identified by this fully qualified ID.')]
        [Parameter(ParameterSetName="ListByPolicyDefinition2", Mandatory, HelpMessage='Limits the list of returned policy assignments to those assigning the policy definition identified by this fully qualified ID.')]
        [Parameter(ParameterSetName="ListByPolicyDefinition3", Mandatory, HelpMessage='Limits the list of returned policy assignments to those assigning the policy definition identified by this fully qualified ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.String]
        ${PolicyDefinitionId},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Uri]
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${ProxyUseDefaultCredentials}
    )

    process {
        if ($PSBoundParameters.ContainsKey("IncludeDescendent"))
        {
            $PSBoundParameters.Add("Filter", "atScope()") | Out-Null
            $PSBoundParameters.Remove("IncludeDescendent") | Out-Null
        }

        if ($PSBoundParameters.ContainsKey("PolicyDefinitionId"))
        {
            $PSBoundParameters.Add("Filter", "policyDefinitionId eq '$PolicyDefinitionId'") | Out-Null
            $PSBoundParameters.Remove("PolicyDefinitionId") | Out-Null
        }

        Az.Resources\Get-AzPolicyAssignment @PSBoundParameters
    }
}