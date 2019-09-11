function Get-AzRoleAssignment {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180901Preview.IRoleAssignment')]
    [CmdletBinding(DefaultParameterSetName='GetRoleAssignment1', PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('Gets a role assignment by ID.')]
    param(
        [Parameter(ParameterSetName='GetRoleAssignment2', Mandatory, HelpMessage='The name of the role assignment to get.')]
        [Alias('RoleAssignmentName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='roleAssignmentName', Required, PossibleTypes=([System.String]), Description='The name of the role assignment to get.')]
        [System.String]
        # The name of the role assignment to get.
        ${Name},

        [Parameter(ParameterSetName='GetRoleAssignment2', Mandatory, HelpMessage='The scope of the role assignment.')]
        [Parameter(ParameterSetName='ListRoleAssignment7', Mandatory, HelpMessage='The scope of the role assignments.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='scope', Required, PossibleTypes=([System.String]), Description='The scope of the role assignment.')]
        [System.String]
        # The scope of the role assignment.
        ${Scope},

        [Parameter(ParameterSetName='GetRoleAssignment3', Mandatory, HelpMessage='The ID of the role assignment to get.')]
        [Alias('Id')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='roleId', Required, PossibleTypes=([System.String]), Description='The ID of the role assignment to get.')]
        [System.String]
        # The ID of the role assignment to get.
        ${RoleId},

        [Parameter(ParameterSetName='ListRoleAssignment4', Mandatory, HelpMessage='The parent resource identity.')]
        [Alias('ParentResourcePath')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='parentResourcePath', Required, PossibleTypes=([System.String]), Description='The parent resource identity.')]
        [System.String]
        # The parent resource identity.
        ${ParentResourceId},

        [Parameter(ParameterSetName='ListRoleAssignment4', Mandatory, HelpMessage='The name of the resource group.')]
        [Parameter(ParameterSetName='ListRoleAssignment5', Mandatory, HelpMessage='The name of the resource group.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the resource group.')]
        [System.String]
        # The name of the resource group.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ListRoleAssignment4', Mandatory, HelpMessage='The name of the resource to get role assignments for.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceName', Required, PossibleTypes=([System.String]), Description='The name of the resource to get role assignments for.')]
        [System.String]
        # The name of the resource to get role assignments for.
        ${ResourceName},

        [Parameter(ParameterSetName='ListRoleAssignment4', Mandatory, HelpMessage='The namespace of the resource provider.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceProviderNamespace', Required, PossibleTypes=([System.String]), Description='The namespace of the resource provider.')]
        [System.String]
        # The namespace of the resource provider.
        ${ResourceProviderNamespace},

        [Parameter(ParameterSetName='ListRoleAssignment4', Mandatory, HelpMessage='The resource type of the resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceType', Required, PossibleTypes=([System.String]), Description='The resource type of the resource.')]
        [System.String]
        # The resource type of the resource.
        ${ResourceType},

        [Parameter(ParameterSetName='ListRoleAssignment4', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='ListRoleAssignment5', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Parameter(ParameterSetName='ListRoleAssignment6', Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName='ListRoleAssignment4', HelpMessage='The filter to apply on the operation. Use $filter=atScope() to return all role assignments at or above the scope. Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal.')]
        [Parameter(ParameterSetName='ListRoleAssignment5', HelpMessage='The filter to apply on the operation. Use $filter=atScope() to return all role assignments at or above the scope. Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal.')]
        [Parameter(ParameterSetName='ListRoleAssignment6', HelpMessage='The filter to apply on the operation. Use $filter=atScope() to return all role assignments at or above the scope. Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal.')]
        [Parameter(ParameterSetName='ListRoleAssignment7', HelpMessage='The filter to apply on the operation. Use $filter=atScope() to return all role assignments at or above the scope. Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal.')]
        [Alias('ODataQuery')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Query')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='$filter', PossibleTypes=([System.String]), Description='The filter to apply on the operation. Use $filter=atScope() to return all role assignments at or above the scope. Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal.')]
        [System.String]
        # The filter to apply on the operation. Use $filter=atScope() to return all role assignments at or above the scope. Use $filter=principalId eq {id} to return all role assignments at, above or below the scope for the specified principal.
        ${Filter},

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
        $Result = @()
        if (!$PSBoundParameters.ContainsKey("Scope"))
        {
            $Scope = "/subscriptions/{0}" -f (Get-AzContext).Subscription.Id
        }

        $TenantId = (Get-AzContext).Tenant.Id
        $RoleDefinitions = Az.Resources\Get-AzRoleDefinition -Scope $Scope
        $RoleAssignments = Az.Resources.internal\Get-AzRoleAssignment @PSBoundParameters
        $Objects = Az.Resources.internal\Get-AzObject -ObjectId $RoleAssignments.PrincipalId -TenantId $TenantId -AdditionalProperties @{}
        if ($null -ne $RoleAssignments)
        {
            foreach ($Assignment in $RoleAssignments)
            {
                $Object = $Objects | Where-Object { $_.ObjectId -eq $Assignment.PrincipalId }
                if ($null -eq $Object)
                {
                    $Assignment.ObjectId = $Assignment.PrincipalId
                    $Assignment.ObjectType = "Unknown"
                }
                else
                {
                    $Assignment.DisplayName = $Object.DisplayName
                    $Assignment.ObjectId = $Object.ObjectId
                    $Assignment.ObjectType = $Object.Type
                }

                $RoleDefinition = $RoleDefinitions | Where-Object { $_.Id -eq $Assignment.RoleDefinitionId }
                $Assignment.RoleDefinitionName = $RoleDefinition.RoleName
                $Result += $Assignment
            }
        }

        $Result
    }
}