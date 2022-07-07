
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
Forcibly removes the link to the specified database resource.
.Description
Forcibly removes the link to the specified database resource.
.Example
{{ Add code here }}
.Example
{{ Add code here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api202201.IForceUnlinkParameters
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IRedisEnterpriseCacheIdentity>: Identity Parameter
  [ClusterName <String>]: The name of the RedisEnterprise cluster.
  [DatabaseName <String>]: The name of the database.
  [Id <String>]: Resource identity path
  [Location <String>]: The region the operation is in.
  [OperationId <String>]: The operation's unique identifier.
  [PrivateEndpointConnectionName <String>]: The name of the private endpoint connection associated with the Azure resource
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SubscriptionId <String>]: The ID of the target subscription.

PARAMETER <IForceUnlinkParameters>: Parameters for a Redis Enterprise Active Geo Replication Force Unlink operation.
  Id <String[]>: The resource IDs of the database resources to be unlinked.
.Link
https://docs.microsoft.com/powershell/module/az.redisenterprisecache/invoke-azredisenterprisecacheforcedatabaseunlink
#>
function Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='ForceExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Force', Mandatory)]
    [Parameter(ParameterSetName='ForceExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
    [System.String]
    # The name of the RedisEnterprise cluster.
    ${ClusterName},

    [Parameter(ParameterSetName='Force', Mandatory)]
    [Parameter(ParameterSetName='ForceExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Force')]
    [Parameter(ParameterSetName='ForceExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ForceViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='ForceViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.IRedisEnterpriseCacheIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Force', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='ForceViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api202201.IForceUnlinkParameters]
    # Parameters for a Redis Enterprise Active Geo Replication Force Unlink operation.
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter(ParameterSetName='ForceExpanded', Mandatory)]
    [Parameter(ParameterSetName='ForceViaIdentityExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
    [System.String[]]
    # The resource IDs of the database resources to be unlinked.
    ${Id},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

    process {
        $null = $PSBoundParameters.Add("DatabaseName", "default")
        Az.RedisEnterpriseCache.internal\Invoke-AzRedisEnterpriseCacheForceDatabaseUnlink @PSBoundParameters
    }
}
