
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
Get a Disk pool.
.Description
Get a Disk pool.
.Example
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test'
Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
disk-pool-5      eastus2euap Running   Succeeded         {3}
.Example
PS C:\> Get-AzDiskPool -ResourceGroupName 'storagepool-rg-test' -Name 'disk-pool-1'

Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
.Example
PS C:\> Get-AzDiskPool

Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}
disk-pool-5      eastus2euap Running   Succeeded         {3}
.Example
PS C:\>  New-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName 'storagepool-rg-test' -Location 'westeurope' -SkuName 'Standard' -SkuTier 'Standard' -SubnetId '/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/storagepool-rg-test/providers/Microsoft.Network/virtualNetworks/disk-pool-vnet/subnets/default' -AvailabilityZone "1" | Get-AzDiskPool

Name             Location    Status    ProvisioningState AvailabilityZone
----             --------    ------    ----------------- ----------------
disk-pool-1      eastus2euap Running   Succeeded         {3}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPool
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IDiskPoolIdentity>: Identity Parameter
  [DiskPoolName <String>]: The name of the Disk Pool.
  [Id <String>]: Resource identity path
  [IscsiTargetName <String>]: The name of the iSCSI Target.
  [Location <String>]: The location of the resource.
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SubscriptionId <String>]: The ID of the target subscription.
.Link
https://docs.microsoft.com/powershell/module/az.diskpool/get-azdiskpool
#>
function Get-AzDiskPool {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPool])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('DiskPoolName')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [System.String]
    # The name of the Disk Pool.
    ${Name},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Parameter(ParameterSetName='List1', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get')]
    [Parameter(ParameterSetName='List')]
    [Parameter(ParameterSetName='List1')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='GetViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
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
            Get = 'Az.DiskPool.private\Get-AzDiskPool_Get';
            GetViaIdentity = 'Az.DiskPool.private\Get-AzDiskPool_GetViaIdentity';
            List = 'Az.DiskPool.private\Get-AzDiskPool_List';
            List1 = 'Az.DiskPool.private\Get-AzDiskPool_List1';
        }
        if (('Get', 'List', 'List1') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
