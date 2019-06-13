function Remove-AzADGroupMember {
    [OutputType('System.Boolean')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(SupportsShouldProcess, PositionalBinding = $false)]
    param(
        [Parameter(Mandatory, HelpMessage='The tenant ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${TenantId},

        [Parameter(ParameterSetName='DeleteByMemberUpnAndGroupDisplayName', Mandatory, HelpMessage='The display name of the group that the member should be removed from.')]
        [Parameter(ParameterSetName='DeleteByMemberIdAndGroupDisplayName', Mandatory, HelpMessage='The display name of the group that the member should be removed from.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${GroupDisplayName},

        [Parameter(ParameterSetName='DeleteByMemberUpnAndGroupId', Mandatory, HelpMessage='The object ID of the group that the member should be removed from.')]
        [Parameter(ParameterSetName='DeleteByMemberIdAndGroupId', Mandatory, HelpMessage='The object ID of the group that the member should be removed from.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${GroupObjectId},

        [Parameter(ParameterSetName='DeleteByMemberUpnAndGroupObject', Mandatory, HelpMessage='The object representation of the group that the member should be removed from.')]
        [Parameter(ParameterSetName='DeleteByMemberIdAndGroupObject', Mandatory, HelpMessage='The object representation of the group that the member should be removed from.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IAdGroup]
        ${GroupObject},

        [Parameter(ParameterSetName='DeleteByMemberUpnAndGroupDisplayName', Mandatory, HelpMessage='The UPN of the member to remove.')]
        [Parameter(ParameterSetName='DeleteByMemberUpnAndGroupId', Mandatory, HelpMessage='The UPN of the member to remove.')]
        [Parameter(ParameterSetName='DeleteByMemberUpnAndGroupObject', Mandatory, HelpMessage='The UPN of the member to remove.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${MemberUserPrincipalName},

        [Parameter(ParameterSetName='DeleteByMemberIdAndGroupDisplayName', Mandatory, HelpMessage='Member object id.')]
        [Parameter(ParameterSetName='DeleteByMemberIdAndGroupId', Mandatory, HelpMessage='Member object id.')]
        [Parameter(ParameterSetName='DeleteByMemberIdAndGroupObject', Mandatory, HelpMessage='Member object id.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${MemberObjectId},

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
        if ($PSBoundParameters.ContainsKey("MemberUserPrincipalName"))
        {
            $User = Az.Resources\Get-AzADUser -TenantId $TenantId -UserPrincipalName $MemberUserPrincipalName
            $PSBoundParameters.Add("MemberObjectId", $User.ObjectId) | Out-Null
            $PSBoundParameters.Remove("MemberUserPrincipalName") | Out-Null
        }

        if ($PSBoundParameters.ContainsKey("GroupDisplayName"))
        {
            $Group = Az.Resources\Get-AzADGroup -TenantId $TenantId -DisplayName $GroupDisplayName
            $PSBoundParameters.Add("GroupObjectId", $Group.ObjectId) | Out-Null
            $PSBoundParameters.Remove("GroupDisplayName") | Out-Null
        }

        if ($PSBoundParameters.ContainsKey("GroupObject"))
        {
            $PSBoundParameters.Add("GroupObjectId", $GroupObject.ObjectId) | Out-Null
            $PSBoundParameters.Remove("GroupObject") | Out-Null
        }

        Az.Resources\Remove-AzADGroupMember @PSBoundParameters
    }
}