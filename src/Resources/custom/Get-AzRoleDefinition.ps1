function Get-AzRoleDefinition {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api201801Preview.IRoleDefinition')]
    [CmdletBinding(DefaultParameterSetName='ListRoleDefinition', PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('Gets a role definition by ID.')]
    param(
        [Parameter(ParameterSetName='GetRoleDefinition2', Mandatory, HelpMessage='The ID of the role definition.')]
        [Alias('RoleDefinitionId')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='roleDefinitionId', Required, PossibleTypes=([System.String]), Description='The fully qualified role definition ID. Use the format, /subscriptions/{guid}/providers/Microsoft.Authorization/roleDefinitions/{roleDefinitionId} for subscription level role definitions, or /providers/Microsoft.Authorization/roleDefinitions/{roleDefinitionId} for tenant level role definitions.')]
        [System.String]
        # The fully qualified role definition ID. Use the format, /subscriptions/{guid}/providers/Microsoft.Authorization/roleDefinitions/{roleDefinitionId} for subscription level role definitions, or /providers/Microsoft.Authorization/roleDefinitions/{roleDefinitionId} for tenant level role definitions.
        ${Id},

        [Parameter(ParameterSetName='GetRoleDefinition2', Mandatory, HelpMessage='The scope of the role definition.')]
        [Parameter(ParameterSetName='ListRoleDefinition1', Mandatory, HelpMessage='The scope of the role definition.')]
        [Parameter(ParameterSetName='GetRoleDefinitionByCustom', Mandatory, HelpMessage='The scope of the role definition.')]
        [Parameter(ParameterSetName='GetRoleDefinitionByName', Mandatory, HelpMessage='The scope of the role definition.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='scope', Required, PossibleTypes=([System.String]), Description='The scope of the role definition.')]
        [System.String]
        # The scope of the role definition.
        ${Scope},

        [Parameter(ParameterSetName='ListRoleDefinition1', HelpMessage='The filter to apply on the operation. Use atScopeAndBelow filter to search below the given scope as well.')]
        [Alias('ODataQuery')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='$filter', PossibleTypes=([System.String]), Description='The filter to apply on the operation. Use atScopeAndBelow filter to search below the given scope as well.')]
        [System.String]
        # The filter to apply on the operation. Use atScopeAndBelow filter to search below the given scope as well.
        ${Filter},

        [Parameter(ParameterSetName='GetRoleDefinitionByCustom', Mandatory, HelpMessage='If set, signals that only custom created roles in the directory should be returned.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [System.Management.Automation.SwitchParameter]
        # If set, signals that only custom created roles in the directory should be returned.
        ${Custom},

        [Parameter(ParameterSetName='GetRoleDefinitionByName', Mandatory, HelpMessage='The name of the role definition.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        # The name of the role definition.
        [System.String]
        ${Name},

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
        if ($PSCmdlet.ParameterSetName -eq "ListRoleDefinition")
        {
            $null = $PSBoundParameters.Add("Scope", "/")
        }
        else
        {
            if ($PSBoundParameters.ContainsKey("Custom"))
            {
                $null = $PSBoundParameters.Add("Filter", "type eq 'CustomRole'")
                $null = $PSBoundParameters.Remove("Custom")
            }
            elseif ($PSBoundParameters.ContainsKey("Name"))
            {
                $null = $PSBoundParameters.Add("Filter", "roleName eq '$Name'")
                $null = $PSBoundParameters.Remove("Name")
            }
        }

        Az.Resources.internal\Get-AzRoleDefinition @PSBoundParameters
    }
}