function New-AzRoleAssignment {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180901Preview.IRoleAssignment')]
    [CmdletBinding(DefaultParameterSetName='CreateByScopeAndObjectId', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('Creates a role assignment by ID.')]
    param(
        [Parameter(ParameterSetName='CreateByScopeAndObjectId', Mandatory, HelpMessage='The scope of the role assignment to create. The scope can be any REST resource instance. For example, use ''/subscriptions/{subscription-id}/'' for a subscription, ''/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}'' for a resource group, and ''/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/{resource-provider}/{resource-type}/{resource-name}'' for a resource.')]
        [Parameter(ParameterSetName='CreateByScopeAndSignInName', Mandatory, HelpMessage='The scope of the role assignment to create. The scope can be any REST resource instance. For example, use ''/subscriptions/{subscription-id}/'' for a subscription, ''/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}'' for a resource group, and ''/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/{resource-provider}/{resource-type}/{resource-name}'' for a resource.')]
        [Parameter(ParameterSetName='CreateByScopeAndSPN', Mandatory, HelpMessage='The scope of the role assignment to create. The scope can be any REST resource instance. For example, use ''/subscriptions/{subscription-id}/'' for a subscription, ''/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}'' for a resource group, and ''/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/{resource-provider}/{resource-type}/{resource-name}'' for a resource.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='scope', Required, PossibleTypes=([System.String]), Description='The scope of the role assignment to create. The scope can be any REST resource instance. For example, use ''/subscriptions/{subscription-id}/'' for a subscription, ''/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}'' for a resource group, and ''/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/{resource-provider}/{resource-type}/{resource-name}'' for a resource.')]
        [System.String]
        # The scope of the role assignment to create. The scope can be any REST resource instance. For example, use '/subscriptions/{subscription-id}/' for a subscription, '/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}' for a resource group, and '/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/{resource-provider}/{resource-type}/{resource-name}' for a resource.
        ${Scope},

        [Parameter(ParameterSetName='CreateById', Mandatory, HelpMessage='The ID of the role assignment to create.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='roleId', Required, PossibleTypes=([System.String]), Description='The ID of the role assignment to create.')]
        [System.String]
        # The ID of the role assignment to create.
        ${RoleId},

        [Parameter(HelpMessage='The delegation flag used for creating a role assignment')]
        [Alias('AllowDelegation')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='canDelegate', PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='The delegation flag used for creating a role assignment')]
        [System.Management.Automation.SwitchParameter]
        # The delegation flag used for creating a role assignment
        ${CanDelegate},

        [Parameter(ParameterSetName='CreateByScopeAndObjectId', Mandatory, HelpMessage='The object id assigned to the role.')]
        [System.String]
        # The object id assigned to the role.
        ${ObjectId},

        [Parameter(ParameterSetName='CreateByScopeAndSignInName', Mandatory, HelpMessage='The user principal name assigned to the role.')]
        [Alias('Email', 'UserPrincipalName')]
        [System.String]
        # The user principal name assigned to the role.
        ${SignInName},

        [Parameter(ParameterSetName='CreateByScopeAndSPN', Mandatory, HelpMessage='The name of the service principal assigned to the role.')]
        [Alias('SPN')]
        [System.String]
        # The name of the service principal assigned to the role.
        ${ServicePrincipalName},

        [Parameter(Mandatory, HelpMessage='The name of the role definition used in the role assignment.')]
        [System.String]
        # The name of the role definition usedint he role assignment.
        ${RoleDefinitionName},

        [Parameter(HelpMessage='The principal type of the assigned principal ID.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PrincipalType])]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='principalType', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PrincipalType]), Description='The principal type of the assigned principal ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PrincipalType]
        # The principal type of the assigned principal ID.
        ${PrincipalType},

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
        if ($PSBoundParameters.ContainsKey("Scope"))
        {
            $Name = ([System.Guid]::NewGuid()).ToString()
            $null = $PSBoundParameters.Add("Name", $Name)
        }

        if ($PSBoundParameters.ContainsKey("ObjectId"))
        {
            $null = $PSBoundParameters.Add("PrincipalId", $ObjectId)
            $null = $PSBoundParameters.Remove("ObjectId")
        }
        elseif ($PSBoundParameters.ContainsKey("SignInName"))
        {
            $TenantId = (Get-AzContext).Tenant.Id
            $User = Az.Resources\Get-AzADUser -UpnOrObjectId $SignInName -TenantId $TenantId
            $null = $PSBoundParameters.Add("PrincipalId", $User.ObjectId)
            $null = $PSBoundParameters.Remove("SignInName")
        }
        elseif ($PSBoundParameters.ContainsKey("ServicePrincipalName"))
        {
            $TenantId = (Get-AzContext).Tenant.Id
            $ServicePrincipal = Az.Resources\Get-AzADServicePrincipal -ServicePrincipalName $ServicePrincipalName -TenantId $TenantId
            $null = $PSBoundParameters.Add("PrincipalId", $ServicePrincipal.ObjectId)
            $null = $PSBoundParameters.Remove("ServicePrincipalName")
        }

        $RoleDefinition = Az.Resources\Get-AzRoleDefinition -Name $RoleDefinitionName -Scope $Scope
        $null = $PSBoundParameters.Add("RoleDefinitionId", $RoleDefinition.Id)
        $null = $PSBoundParameters.Remove("RoleDefinitionName")

        Az.Resources.internal\New-AzRoleAssignment @PSBoundParameters
    }
}