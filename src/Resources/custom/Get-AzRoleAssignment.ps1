function Get-AzRoleAssignment {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20171001Preview.IRoleAssignment', 'Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180901Preview.IRoleAssignment')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(ParameterSetName='ListByScopeExpandPrincipalGroups', Mandatory, HelpMessage='The scope of the role assignments.')]
        [Parameter(ParameterSetName='ListByScopeFilterBySPN', Mandatory, HelpMessage='The scope of the role assignments.')]
        [Parameter(ParameterSetName='ListByScopeFilterBySignInName', Mandatory, HelpMessage='The scope of the role assignments.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${Scope},

        [Parameter(ParameterSetName='ListByComponentsExpandPrincipalGroups', Mandatory, HelpMessage='The parent resource identity.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySPN', Mandatory, HelpMessage='The parent resource identity.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySignInName', Mandatory, HelpMessage='The parent resource identity.')]
        [Alias('ParentResourcePath')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ParentResourceId},

        [Parameter(ParameterSetName='ListByComponentsExpandPrincipalGroups', Mandatory, HelpMessage='The name of the resource group.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySPN', Mandatory, HelpMessage='The name of the resource group.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySignInName', Mandatory, HelpMessage='The name of the resource group.')]
        [Parameter(ParameterSetName='ListByResourceGroupExpandPrincipalGroups', Mandatory, HelpMessage='The name of the resource group.')]
        [Parameter(ParameterSetName='ListByResourceGroupFilterBySPN', Mandatory, HelpMessage='The name of the resource group.')]
        [Parameter(ParameterSetName='ListByResourceGroupFilterBySignInName', Mandatory, HelpMessage='The name of the resource group.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ListByComponentsExpandPrincipalGroups', Mandatory, HelpMessage='The name of the resource to get role assignments for.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySPN', Mandatory, HelpMessage='The name of the resource to get role assignments for.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySignInName', Mandatory, HelpMessage='The name of the resource to get role assignments for.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ResourceName},

        [Parameter(ParameterSetName='ListByComponentsExpandPrincipalGroups', Mandatory, HelpMessage='The namespace of the resource provider.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySPN', Mandatory, HelpMessage='The namespace of the resource provider.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySignInName', Mandatory, HelpMessage='The namespace of the resource provider.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ResourceProviderNamespace},

        [Parameter(ParameterSetName='ListByComponentsExpandPrincipalGroups', Mandatory, HelpMessage='The resource type of the resource.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySPN', Mandatory, HelpMessage='The resource type of the resource.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySignInName', Mandatory, HelpMessage='The resource type of the resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${ResourceType},

        [Parameter(ParameterSetName='ListByComponentsExpandPrincipalGroups', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySPN', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='ListByComponentsFilterBySignInName', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='ListByResourceGroupExpandPrincipalGroups', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='ListByResourceGroupFilterBySPN', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='ListByResourceGroupFilterBySignInName', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='ListBySubscriptionExpandPrincipalGroups', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='ListBySubscriptionFilterBySPN', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='ListBySubscriptionFilterBySignInName', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(ParameterSetName='ListByComponentsExpandPrincipalGroups', Mandatory, HelpMessage='Signals that the role assignments returned should be directly assigned to the principal as well as assignments to the principals groups (transitive).')]
        [Parameter(ParameterSetName='ListByResourceGroupExpandPrincipalGroups', Mandatory, HelpMessage='Signals that the role assignments returned should be directly assigned to the principal as well as assignments to the principals groups (transitive).')]
        [Parameter(ParameterSetName='ListBySubscriptionExpandPrincipalGroups', Mandatory, HelpMessage='Signals that the role assignments returned should be directly assigned to the principal as well as assignments to the principals groups (transitive).')]
        [Parameter(ParameterSetName='ListByScopeExpandPrincipalGroups', Mandatory, HelpMessage='Signals that the role assignments returned should be directly assigned to the principal as well as assignments to the principals groups (transitive).')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.String]
        ${ExpandPrincipalGroups},

        [Parameter(ParameterSetName='ListByComponentsFilterBySPN', Mandatory, HelpMessage='The service principal name (SPN) of the application.')]
        [Parameter(ParameterSetName='ListByResourceGroupFilterBySPN', Mandatory, HelpMessage='The service principal name (SPN) of the application.')]
        [Parameter(ParameterSetName='ListBySubscriptionFilterBySPN', Mandatory, HelpMessage='The service principal name (SPN) of the application.')]
        [Parameter(ParameterSetName='ListByScopeFilterBySPN', Mandatory, HelpMessage='The service principal name (SPN) of the application.')]
        [Alias('SPN')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.String]
        ${ServicePrincipalName},

        [Parameter(ParameterSetName='ListByComponentsFilterBySignInName', Mandatory, HelpMessage='The sign in name of the user.')]
        [Parameter(ParameterSetName='ListByResourceGroupFilterBySignInName', Mandatory, HelpMessage='The sign in name of the user.')]
        [Parameter(ParameterSetName='ListBySubscriptionFilterBySignInName', Mandatory, HelpMessage='The sign in name of the user.')]
        [Parameter(ParameterSetName='ListByScopeFilterBySignInName', Mandatory, HelpMessage='The sign in name of the user.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.String]
        ${SignInName},

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
        if ($PSBoundParameters.ContainsKey("ExpandPrincipalGroups"))
        {

        }

        if ($PSBoundParameters.ContainsKey("ServicePrincipalName"))
        {

        }

        if ($PSBoundParameters.ContainsKey("SignInName"))
        {

        }

        Az.Resources\Get-AzRoleAssignment @PSBoundParameters
    }
}