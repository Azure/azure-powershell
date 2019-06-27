function Add-AzADGroupMember {
    [OutputType('System.Boolean')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    param(
        [Parameter(Mandatory, HelpMessage="The tenant ID.")]
        [System.String]
        ${TenantId},

        [Parameter(ParameterSetName='AddMemberIdToGroupId', Mandatory, HelpMessage='The object ID of the group to add the member(s) to.')]
        [Parameter(ParameterSetName='AddMemberUpnToGroupId', Mandatory, HelpMessage='The object ID of the group to add the member(s) to.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${GroupObjectId},

        [Parameter(ParameterSetName='AddMemberIdToGroupDisplayName', Mandatory, HelpMessage='The display name of the group to add the member(s) to.')]
        [Parameter(ParameterSetName='AddMemberUpnToGroupDisplayName', Mandatory, HelpMessage='The display name of the group to add the member(s) to.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${GroupDisplayName},

        [Parameter(ParameterSetName='AddMemberIdToGroupObject', Mandatory, HelpMessage='The object representation of the group to add the member(s) to.')]
        [Parameter(ParameterSetName='AddMemberUpnToGroupObject', Mandatory, HelpMessage='The object representation of the group to add the member(s) to.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IAdGroup]
        ${GroupObject},

        [Parameter(ParameterSetName='AddMemberIdToGroupId', Mandatory, HelpMessage='The object ID of the member(s) to add to the group.')]
        [Parameter(ParameterSetName='AddMemberIdToGroupDisplayName', Mandatory, HelpMessage='The object ID of the member(s) to add to the group.')]
        [Parameter(ParameterSetName='AddMemberIdToGroupObject', Mandatory, HelpMessage='The object ID of the member(s) to add to the group.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String[]]
        ${MemberObjectId},

        [Parameter(ParameterSetName='AddMemberUpnToGroupId', Mandatory, HelpMessage='The user principal name (UPN) of the member(s) to add to the group.')]
        [Parameter(ParameterSetName='AddMemberUpnToGroupDisplayName', Mandatory, HelpMessage='The user principal name (UPN) of the member(s) to add to the group.')]
        [Parameter(ParameterSetName='AddMemberUpnToGroupObject', Mandatory, HelpMessage='The user principal name (UPN) of the member(s) to add to the group.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String[]]
        ${MemberUserPrincipalName},

        [Parameter(HelpMessage='When specified, PassThru will force the cmdlet return a ''bool'' given that there isn''t a return type by default.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        ${PassThru},

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
        if ($PSBoundParameters.ContainsKey("GroupDisplayName"))
        {
            $Group = Az.Resources\Get-AzADGroup -TenantId $TenantId -DisplayName $GroupDisplayName
            if ($null -ne $Group)
            {
                $PSBoundParameters.Add("GroupObjectId", $Group.ObjectId) | Out-Null
                $PSBoundParameters.Remove("GroupDisplayName") | Out-Null
            }
        }

        if ($PSBoundParameters.ContainsKey("GroupObject"))
        {
            $PSBoundParameters.Add("GroupObjectId", $GroupObject.ObjectId) | Out-Null
            $PSBoundParameters.Remove("GroupObject") | Out-Null
        }

        if ($PSBoundParameters.ContainsKey("MemberObjectId"))
        {
            $TempMemberObjectId = $MemberObjectId
            $PSBoundParameters.Remove("MemberObjectId") | Out-Null
            $TempMemberObjectId | ForEach-Object {
                $GraphEndpoint = (Get-AzContext).Environment.GraphEndpointResourceId
                $Url = '{0}{1}/directoryObjects/{2}' -f $GraphEndpoint, $TenantId, $_
                $PSBoundParameters.Add("Url", $Url) | Out-Null
                Az.Resources\Add-AzADGroupMember @PSBoundParameters
                $PSBoundParameters.Remove("Url") | Out-Null
            }
        }

        if ($PSBoundParameters.ContainsKey("MemberUserPrincipalName"))
        {
            $TempMemberUserPrincipalName = $MemberUserPrincipalName
            $PSBoundParameters.Remove("MemberUserPrincipalName") | Out-Null
            $TempMemberUserPrincipalName | ForEach-Object {
                $User = Az.Resources\Get-AzADUser -TenantId $TenantId -UpnOrObjectId $_
                if ($null -ne $User)
                {
                    $GraphEndpoint = (Get-AzContext).Environment.GraphEndpointResourceId
                    $Url = '{0}{1}/directoryObjects/{2}' -f $GraphEndpoint, $TenantId, $User.ObjectId
                    $PSBoundParameters.Add("Url", $Url) | Out-Null
                    Az.Resources\Add-AzADGroupMember @PSBoundParameters
                    $PSBoundParameters.Remove("Url") | Out-Null
                }
            }
        }

    }
}