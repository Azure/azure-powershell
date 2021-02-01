
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
Create a new user.
.Description
Create a new user.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PASSWORDPROFILE <IPasswordProfile>: Password Profile
  [(Any) <Object>]: This indicates any property can be added to this object.
  Password <String>: Password
  [ForceChangePasswordNextLogin <Boolean?>]: Whether to force a password change on next login.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ad/new-azaduser
#>
function New-AzADUser {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IUser])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [System.String]
    # The tenant ID.
    ${TenantId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Whether the account is enabled.
    ${AccountEnabled},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The display name of the user.
    ${DisplayName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The mail alias for the user.
    ${MailNickname},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordProfile]
    # Password Profile
    # To construct, see NOTES section for PASSWORDPROFILE properties and create a hash table.
    ${PasswordProfile},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The user principal name (someuser@contoso.com).
    # It must contain one of the verified domains for the tenant.
    ${UserPrincipalName},

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
            CreateExpanded = 'Az.AD.private\New-AzADUser_CreateExpanded';
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
