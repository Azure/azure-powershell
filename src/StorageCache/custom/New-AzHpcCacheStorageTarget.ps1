
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
Create or update a Storage Target.
This operation is allowed at any time, but if the Cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the Cache is healthy again.
.Description
Create or update a Storage Target.
This operation is allowed at any time, but if the Cache is down or unhealthy, the actual creation/modification of the Storage Target may be delayed until the Cache is healthy again.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.IHpcCacheIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.IStorageTarget
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IHpcCacheIdentity>: Identity Parameter
  [CacheName <String>]: Name of Cache. Length of name must not be greater than 80 and chars must be from the [-0-9a-zA-Z_] char class.
  [Id <String>]: Resource identity path
  [Location <String>]: The name of the region used to look up the operation.
  [OperationId <String>]: The operation id which uniquely identifies the asynchronous operation.
  [ResourceGroupName <String>]: Target resource group.
  [StorageTargetName <String>]: Name of Storage Target.
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

JUNCTION <INamespaceJunction[]>: List of Cache namespace junctions to target for namespace associations.
  [NamespacePath <String>]: Namespace path on a Cache for a Storage Target.
  [NfsAccessPolicy <String>]: Name of the access policy applied to this junction.
  [NfsExport <String>]: NFS export where targetPath exists.
  [TargetPath <String>]: Path in Storage Target to which namespacePath points.
.Link
https://docs.microsoft.com/powershell/module/hpccache/new-azhpccachestoragetarget
#>
function New-AzHpcCacheStorageTarget {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.IStorageTarget])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Path')]
    [System.String]
    # Name of Cache.
    # Length of name must not be greater than 80 and chars must be from the [-0-9a-zA-Z_] char class.
    ${CacheName},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Alias('StorageTargetName')]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Path')]
    [System.String]
    # Name of Storage Target.
    ${Name},

    [Parameter(ParameterSetName='CreateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Path')]
    [System.String]
    # Target resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='CreateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.IHpcCacheIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Body')]
    [System.String]
    # Resource ID of the storage container.
    ${BlobNfTarget},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Body')]
    [System.String]
    # Identifies the StorageCache usage model to be used for this storage target.
    ${BlobNfUsageModel},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Body')]
    [System.String]
    # Resource ID of storage container.
    ${ClfTarget},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Models.Api20210301.INamespaceJunction[]]
    # List of Cache namespace junctions to target for namespace associations.
    # To construct, see NOTES section for JUNCTION properties and create a hash table.
    ${Junction},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Body')]
    [System.String]
    # IP address or host name of an NFSv3 host (e.g., 10.0.44.44).
    ${Nfs3Target},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Body')]
    [System.String]
    # Identifies the StorageCache usage model to be used for this storage target.
    ${Nfs3UsageModel},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Support.ProvisioningStateType])]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Support.ProvisioningStateType]
    # ARM provisioning state, see https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/Addendum.md#provisioningstate-property
    ${ProvisioningState},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Support.StorageTargetType])]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Support.StorageTargetType]
    # Type of the Storage Target.
    ${TargetType},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.HpcCache.Category('Runtime')]
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
            CreateExpanded = 'Az.HpcCache.private\New-AzHpcCacheStorageTarget_CreateExpanded';
            CreateViaIdentityExpanded = 'Az.HpcCache.private\New-AzHpcCacheStorageTarget_CreateViaIdentityExpanded';
        }
        if (('CreateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
