
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
The operation to delete a virtual hard disk.
.Description
The operation to delete a virtual hard disk.
.Example
{{ Add code here }}
.Example
{{ Add code here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IStackHciVMIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IStackHciVMIdentity>: Identity Parameter
  [ExtensionName <String>]: The name of the machine extension.
  [GalleryImageName <String>]: Name of the gallery image
  [Id <String>]: Resource identity path
  [MarketplaceGalleryImageName <String>]: Name of the marketplace gallery image
  [MetadataName <String>]: Name of the hybridIdentityMetadata.
  [Name <String>]: The name of the machine where the extension should be created or updated.
  [NetworkInterfaceName <String>]: Name of the network interface
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [StorageContainerName <String>]: Name of the storage container
  [SubscriptionId <String>]: The ID of the target subscription.
  [VirtualHardDiskName <String>]: Name of the virtual hard disk
  [VirtualMachineName <String>]: Name of the virtual machine
  [VirtualNetworkName <String>]: Name of the virtual network
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/remove-azstackhcivmvirtualharddisk
#>
function Remove-AzStackHciVMVirtualHardDisk {
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess=$true, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='ByName',Mandatory)]
        [Alias('VirtualHardDiskName')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
        [System.String]
        # Name of the virtual hard disk
        ${Name},
    
        [Parameter(ParameterSetName='ByName',Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName='ByResourceId',Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
        [System.String]
        # The ARM Resource ID of the virtual hard disk.
        ${ResourceId},

        [Parameter(HelpMessage='Forces the cmdlet to remove the virtual hard disk without prompting for confirmation.')]
        [System.Management.Automation.SwitchParameter]
        ${Force},

        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IStackHciVMIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},
    
        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru},

        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    

    
    process {

        Write-Warning("Running this command will delete the virtual hard disk.")

        if ($PSCmdlet.ParameterSetName -eq "ByResourceId"){
            if ($ResourceId -match $vhdRegex){
        
                $subscriptionId = $($Matches['subscriptionId'])
                $resourceGroupName = $($Matches['resourceGroupName'])
                $resourceName = $($Matches['vhdName'])
                $null = $PSBoundParameters.Remove("ResourceId")
                $PSBoundParameters.Add("Name", $resourceName)
                $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
                $null = $PSBoundParameters.Remove("SubscriptionId")
                $PSBoundParameters.Add("SubscriptionId", $subscriptionId)
    
            } else {             
                Write-Error "Resource ID is invalid: $ResourceId" -ErrorAction Stop
            }
        }
        if ($PSCmdlet.ShouldProcess($PSBoundParameters['Name']) -and ($Force -or $PSCmdlet.ShouldContinue("Delete this virtual hard disk?", "Confirm")))
        {
            if ($PSBoundParameters.ContainsKey("Force")) {
                $null = $PSBoundParameters.Remove("Force")
            }

            Az.StackHciVM.internal\Remove-AzStackHciVMVirtualHardDisk @PSBoundParameters
        }

    }
    
    

}
    