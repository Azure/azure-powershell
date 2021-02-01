
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Updates a user.
.Description
Updates a user.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.AD.Models.IAdIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IAdIdentity>: Identity Parameter
  [ApplicationId <String>]: The application ID.
  [ApplicationObjectId <String>]: The object ID of the application for which to get owners.
  [DomainName <String>]: name of the domain.
  [GroupObjectId <String>]: The object ID of the group from which to remove the member.
  [Id <String>]: Resource identity path
  [MemberObjectId <String>]: Member object id
  [NextLink <String>]: Next link for the list operation.
  [ObjectId <String>]: The object ID of the group whose members should be retrieved.
  [OwnerObjectId <String>]: Owner object id
  [TenantId <String>]: The tenant ID.
  [UpnOrObjectId <String>]: The object ID or principal name of the user for which to get information.

PASSWORDPROFILE <IPasswordProfile>: The password profile of the user.
  [(Any) <Object>]: This indicates any property can be added to this object.
  Password <String>: Password
  [ForceChangePasswordNextLogin <Boolean?>]: Whether to force a password change on next login.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ad/update-azaduser
#>
function Update-AzADUser {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [System.String]
    # The tenant ID.
    ${TenantId},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [System.String]
    # The object ID or principal name of the user to update.
    ${UpnOrObjectId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.IAdIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Whether the account is enabled.
    ${AccountEnabled},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The display name of the user.
    ${DisplayName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The given name for the user.
    ${GivenName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # This must be specified if you are using a federated domain for the user's userPrincipalName (UPN) property when creating a new user account.
    # It is used to associate an on-premises Active Directory user account with their Azure AD user object.
    ${ImmutableId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The primary email address of the user.
    ${Mail},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The mail alias for the user.
    ${MailNickname},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordProfile]
    # The password profile of the user.
    # To construct, see NOTES section for PASSWORDPROFILE properties and create a hash table.
    ${PasswordProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The user's surname (family name or last name).
    ${Surname},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # A two letter country code (ISO standard 3166).
    # Required for users that will be assigned licenses due to legal requirement to check for availability of services in countries.
    # Examples include: "US", "JP", and "GB".
    ${UsageLocation},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The user principal name (someuser@contoso.com).
    # It must contain one of the verified domains for the tenant.
    ${UserPrincipalName},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType])]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Support.UserType]
    # A string value that can be used to classify user types in your directory, such as 'Member' and 'Guest'.
    ${UserType},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            UpdateExpanded = 'Az.AD.private\Update-AzADUser_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.AD.private\Update-AzADUser_UpdateViaIdentityExpanded';
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
