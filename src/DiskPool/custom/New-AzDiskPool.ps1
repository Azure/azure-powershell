
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
Create or Update Disk pool.
.Description
Create or Update Disk pool.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPool
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

DISK <IDisk[]>: List of Azure Managed Disks to attach to a Disk Pool.
  Id <String>: Unique Azure Resource ID of the Managed Disk.
.Link
https://docs.microsoft.com/powershell/module/az.diskpool/new-azdiskpool
#>
function New-AzDiskPool {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPool])]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('DiskPoolName')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [System.String]
    # The name of the Disk Pool.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Body')]
    [System.String[]]
    # Logical zone for Disk Pool resource; example: ["1"].
    ${AvailabilityZone},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Body')]
    [System.String]
    # The geo-location where the resource lives.
    ${Location},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Body')]
    [ValidateSet('Standard')]
    [System.String]
    # .
    ${SkuName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Body')]
    [System.String]
    # Azure Resource ID of a Subnet for the Disk Pool.
    ${SubnetId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Body')]
    [System.String[]]
    # List of additional capabilities for a Disk Pool.
    ${AdditionalCapability},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Body')]
    [System.String[]]
    # List of Azure Managed Disk Ids to attach to a Disk Pool.
    # To construct, see NOTES section for DISK properties and create a hash table.
    ${DiskId},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Support.DiskPoolTier])]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Body')]
    [System.String]
    # Tier to use for the Disk Pool.
    ${SkuTier},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IDiskPoolCreateTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

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

    process {
        try {
            if ($PSBoundParameters.ContainsKey("DiskId")){
                $disk = @()
                for ($i = 0; $i -lt $DiskId.Count; $i++) {
                    $diskObject = New-Object -TypeName Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.Disk
                    $diskObject.Id = $DiskId[$i]
                    $disk += $diskObject
                }
                $PSBoundParameters["Disk"] = $disk
                $null = $PSBoundParameters.Remove("DiskId")
            }
            Az.DiskPool.internal\New-AzDiskPool @PSBoundParameters
        } catch {
            throw
        }
    }

}
