
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
Updates a ResourceOperationGatekeeper resource belonging to a resource group.
For example, updating tags for a resource.
.Description
Updates a ResourceOperationGatekeeper resource belonging to a resource group.
For example, updating tags for a resource.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IPatchResourceRequestInput
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IResourceOperationGateKeeperResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IDataProtectionIdentity>: Identity Parameter
  [BackupInstanceName <String>]: The name of the backup instance
  [BackupPolicyName <String>]: 
  [Id <String>]: Resource identity path
  [JobId <String>]: The Job ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  [Location <String>]: The location in which uniqueness will be verified.
  [OperationId <String>]: 
  [RecoveryPointId <String>]: 
  [ResourceGroupName <String>]: The name of the resource group where the backup vault is present.
  [ResourceOperationGateKeepersName <String>]: The name of the ResourceOperationGateKeeper
  [SubscriptionId <String>]: The subscription Id.
  [VaultName <String>]: The name of the backup vault.

PARAMETER <IPatchResourceRequestInput>: Patch Request content for Microsoft.DataProtection resources
  [IdentityType <String>]: The identityType which can be either SystemAssigned or None
  [Tag <IPatchResourceRequestInputTags>]: Resource tags.
    [(Any) <String>]: This indicates any property can be added to this object.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.dataprotection/update-azdataprotectionresourceoperationgatekeeper
#>
function Update-AzDataProtectionResourceOperationGatekeeper {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IResourceOperationGateKeeperResource])]
[CmdletBinding(DefaultParameterSetName='PatchExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Patch', Mandatory)]
    [Parameter(ParameterSetName='PatchExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of the resource group where the backup vault is present.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Patch', Mandatory)]
    [Parameter(ParameterSetName='PatchExpanded', Mandatory)]
    [Alias('ResourceOperationGateKeepersName')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [System.String]
    # The name of ResourceOperationGatekeeper
    ${SName},

    [Parameter(ParameterSetName='Patch')]
    [Parameter(ParameterSetName='PatchExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The subscription Id.
    ${SubscriptionId},

    [Parameter(ParameterSetName='PatchViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataProtectionIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Patch', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='PatchViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IPatchResourceRequestInput]
    # Patch Request content for Microsoft.DataProtection resources
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [System.String]
    # The identityType which can be either SystemAssigned or None
    ${IdentityType},

    [Parameter(ParameterSetName='PatchExpanded')]
    [Parameter(ParameterSetName='PatchViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IPatchResourceRequestInputTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Category('Runtime')]
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
            Patch = 'Az.DataProtection.private\Update-AzDataProtectionResourceOperationGatekeeper_Patch';
            PatchExpanded = 'Az.DataProtection.private\Update-AzDataProtectionResourceOperationGatekeeper_PatchExpanded';
            PatchViaIdentity = 'Az.DataProtection.private\Update-AzDataProtectionResourceOperationGatekeeper_PatchViaIdentity';
            PatchViaIdentityExpanded = 'Az.DataProtection.private\Update-AzDataProtectionResourceOperationGatekeeper_PatchViaIdentityExpanded';
        }
        if (('Patch', 'PatchExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
