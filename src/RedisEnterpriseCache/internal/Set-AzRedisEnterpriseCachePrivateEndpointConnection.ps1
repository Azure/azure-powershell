
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
Updates the state of the specified private endpoint connection associated with the RedisEnterprise cluster.
.Description
Updates the state of the specified private endpoint connection associated with the RedisEnterprise cluster.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateEndpointConnection
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

PROPERTY <IPrivateEndpointConnection>: The Private Endpoint Connection resource.
  [PrivateLinkServiceConnectionStateActionsRequired <String>]: A message indicating if changes on the service provider require any updates on the consumer.
  [PrivateLinkServiceConnectionStateDescription <String>]: The reason for approval/rejection of the connection.
  [PrivateLinkServiceConnectionStateStatus <PrivateEndpointServiceConnectionStatus?>]: Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.
.Link
https://docs.microsoft.com/powershell/module/az.redisenterprisecache/set-azredisenterprisecacheprivateendpointconnection
#>
function Set-AzRedisEnterpriseCachePrivateEndpointConnection {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='PutExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
    [System.String]
    # The name of the RedisEnterprise cluster.
    ${ClusterName},

    [Parameter(Mandatory)]
    [Alias('PrivateEndpointConnectionName')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
    [System.String]
    # The name of the private endpoint connection associated with the Azure resource
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Put', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Models.Api10.IPrivateEndpointConnection]
    # The Private Endpoint Connection resource.
    # To construct, see NOTES section for PROPERTY properties and create a hash table.
    ${Property},

    [Parameter(ParameterSetName='PutExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
    [System.String]
    # A message indicating if changes on the service provider require any updates on the consumer.
    ${PrivateLinkServiceConnectionStateActionsRequired},

    [Parameter(ParameterSetName='PutExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
    [System.String]
    # The reason for approval/rejection of the connection.
    ${PrivateLinkServiceConnectionStateDescription},

    [Parameter(ParameterSetName='PutExpanded')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.PrivateEndpointServiceConnectionStatus])]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.RedisEnterpriseCache.Support.PrivateEndpointServiceConnectionStatus]
    # Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.
    ${PrivateLinkServiceConnectionStateStatus},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Put = 'Az.RedisEnterpriseCache.private\Set-AzRedisEnterpriseCachePrivateEndpointConnection_Put';
            PutExpanded = 'Az.RedisEnterpriseCache.private\Set-AzRedisEnterpriseCachePrivateEndpointConnection_PutExpanded';
        }
        if (('Put', 'PutExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
