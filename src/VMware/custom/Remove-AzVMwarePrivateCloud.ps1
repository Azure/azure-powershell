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
Delete a private cloud
.Description
Delete a private cloud
.Example
PS C:\> Remove-AzVMwarePrivateCloud -ResourceGroupName azps-test-group -Name azps-test-cloud


.Inputs
Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IVMwareIdentity>: Identity Parameter
  [AuthorizationName <String>]: Name of the ExpressRoute Circuit Authorization in the private cloud
  [ClusterName <String>]: Name of the cluster in the private cloud
  [HcxEnterpriseSiteName <String>]: Name of the HCX Enterprise Site in the private cloud
  [Id <String>]: Resource identity path
  [Location <String>]: Azure region
  [PrivateCloudName <String>]: Name of the private cloud
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [SubscriptionId <String>]: The ID of the target subscription.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.vmware/remove-azvmwareprivatecloud
#>
function Remove-AzVMwarePrivateCloud {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='High')]
    param(
        [Parameter(ParameterSetName='Delete', Mandatory)]
        [Alias('PrivateCloudName')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
        [System.String]
        # Name of the private cloud
        ${Name},
    
        [Parameter(ParameterSetName='Delete', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='Delete')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.IVMwareIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        $message = "Deleting the private cloud is an irreversible operation. Once the private cloud is deleted, the data cannot be recovered, as it terminates all running workloads and components and destroys all private cloud data and configuration settings, including public IP addresses."
        $target = -join($PSBoundParameters['Name'], " in resource group: ", $PSBoundParameters['ResourceGroupName'])
        try {
            Write-Warning $message
            if($PSCmdlet.ShouldProcess($target)){
                Az.VMware.internal\Remove-AzVMwarePrivateCloud @PSBoundParameters
            }
        } catch {
            throw
        }
    }
}
    
    