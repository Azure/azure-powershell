
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
Gets the directory objects specified in a list of object IDs.
You can also specify which resource collections (users, groups, etc.) should be searched by specifying the optional types parameter.
.Description
Gets the directory objects specified in a list of object IDs.
You can also specify which resource collections (users, groups, etc.) should be searched by specifying the optional types parameter.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGetObjectsParameters
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.AD.Models.IAdIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject
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

PARAMETER <IGetObjectsParameters>: Request parameters for the GetObjectsByObjectIds API.
  [(Any) <Object>]: This indicates any property can be added to this object.
  [IncludeDirectoryObjectReference <Boolean?>]: If true, also searches for object IDs in the partner tenant.
  [ObjectId <String[]>]: The requested object IDs.
  [Type <String[]>]: The requested object types.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.ad/get-azadobject
#>
function Get-AzADObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IDirectoryObject])]
[CmdletBinding(DefaultParameterSetName='GetExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='Get1', Mandatory)]
    [Parameter(ParameterSetName='GetExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [System.String]
    # The tenant ID.
    ${TenantId},

    [Parameter(ParameterSetName='Get1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [System.String]
    # Next link for the list operation.
    ${NextLink},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='GetViaIdentity1', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='GetViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.IAdIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Get', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IGetObjectsParameters]
    # Request parameters for the GetObjectsByObjectIds API.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='GetExpanded')]
    [Parameter(ParameterSetName='GetViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Collections.Hashtable]
    # Additional Parameters
    ${AdditionalProperties},

    [Parameter(ParameterSetName='GetExpanded')]
    [Parameter(ParameterSetName='GetViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # If true, also searches for object IDs in the partner tenant.
    ${IncludeDirectoryObjectReference},

    [Parameter(ParameterSetName='GetExpanded')]
    [Parameter(ParameterSetName='GetViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String[]]
    # The requested object IDs.
    ${ObjectId},

    [Parameter(ParameterSetName='GetExpanded')]
    [Parameter(ParameterSetName='GetViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AD.Category('Body')]
    [System.String[]]
    # The requested object types.
    ${Type},

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
            Get = 'Az.AD.private\Get-AzADObject_Get';
            Get1 = 'Az.AD.private\Get-AzADObject_Get1';
            GetExpanded = 'Az.AD.private\Get-AzADObject_GetExpanded';
            GetViaIdentity = 'Az.AD.private\Get-AzADObject_GetViaIdentity';
            GetViaIdentity1 = 'Az.AD.private\Get-AzADObject_GetViaIdentity1';
            GetViaIdentityExpanded = 'Az.AD.private\Get-AzADObject_GetViaIdentityExpanded';
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
