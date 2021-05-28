
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
Update an iSCSI Target.
.Description
Update an iSCSI Target.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTarget
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

LUN <IIscsiLun[]>: List of LUNs to be exposed through iSCSI Target.
  ManagedDiskAzureResourceId <String>: Azure Resource ID of the Managed Disk.
  Name <String>: User defined name for iSCSI LUN; example: "lun0"

STATICACL <IAcl[]>: Access Control List (ACL) for an iSCSI Target; defines LUN masking policy
  InitiatorIqn <String>: iSCSI initiator IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:client".
  MappedLun <String[]>: List of LUN names mapped to the ACL.
.Link
https://docs.microsoft.com/powershell/module/az.diskpool/update-azdiskpooliscsitarget
#>
function Update-AzDiskPoolIscsiTarget {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiTarget])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [System.String]
    # The name of the Disk Pool.
    ${DiskPoolName},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('IscsiTargetName')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [System.String]
    # The name of the iSCSI Target.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.IDiskPoolIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IIscsiLun[]]
    # List of LUNs to be exposed through iSCSI Target.
    # To construct, see NOTES section for LUN properties and create a hash table.
    ${Lun},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210401Preview.IAcl[]]
    # Access Control List (ACL) for an iSCSI Target; defines LUN masking policy
    # To construct, see NOTES section for STATICACLS properties and create a hash table.
    ${StaticAcl},

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
        if ($PSBoundParameters.ContainsKey("StaticAcl")){
            $PSBoundParameters["StaticAcls"] = $StaticAcl
            $null = $PSBoundParameters.Remove("StaticAcl")
        }
        Az.DiskPool.internal\Update-AzDiskPoolIscsiTarget @PSBoundParameters
    } catch {
        throw
    }
}
}
