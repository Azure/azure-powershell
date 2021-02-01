
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
Grants OAuth2 permissions for the relevant resource Ids of an app.
.Description
Grants OAuth2 permissions for the relevant resource Ids of an app.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ad/new-azadoauth2permissiongrant
#>
function New-AzADOAuth2PermissionGrant {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IOAuth2PermissionGrant])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [System.String]
    # The tenant ID.
    ${TenantId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The id of the resource's service principal granted consent to impersonate the user when accessing the resource (represented by the resourceId property).
    ${ClientId},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType])]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Support.ConsentType]
    # Indicates if consent was provided by the administrator (on behalf of the organization) or by an individual.
    ${ConsentType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # Expiry time for TTL
    ${ExpiryTime},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # The id of the permission grant
    ${ObjectId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # Microsoft.DirectoryServices.OAuth2PermissionGrant
    ${OdataType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # When consent type is Principal, this property specifies the id of the user that granted consent and applies only for that user.
    ${PrincipalId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # Object Id of the resource you want to grant
    ${ResourceId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # Specifies the value of the scope claim that the resource application should expect in the OAuth 2.0 access token.
    # For example, User.Read
    ${Scope},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String]
    # Start time for TTL
    ${StartTime},

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
            CreateExpanded = 'Az.AD.private\New-AzADOAuth2PermissionGrant_CreateExpanded';
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
