
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
The operation to update a virtual machine instance.
.Description
The operation to update a virtual machine instance.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IStackHciVMIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualMachineInstance
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IStackHciVMIdentity>: Identity Parameter
  [ExtensionName <String>]: The name of the machine extension.
  [ExtensionType <String>]: The extensionType of the Extension being received.
  [GalleryImageName <String>]: Name of the gallery image
  [Id <String>]: Resource identity path
  [Location <String>]: The location of the Extension being received.
  [LogicalNetworkName <String>]: Name of the logical network
  [MachineName <String>]: The name of the hybrid machine.
  [MarketplaceGalleryImageName <String>]: Name of the marketplace gallery image
  [MetadataName <String>]: Name of the HybridIdentityMetadata.
  [NetworkInterfaceName <String>]: Name of the network interface
  [OSType <String>]: Defines the os type.
  [Publisher <String>]: The publisher of the Extension being received.
  [ResourceGroupName <String>]: The name of the resource group. The name is case insensitive.
  [ResourceUri <String>]: The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended.
  [StorageContainerName <String>]: Name of the storage container
  [SubscriptionId <String>]: The ID of the target subscription.
  [Version <String>]: The version of the Extension being received.
  [VirtualHardDiskName <String>]: Name of the virtual hard disk

NETWORKPROFILENETWORKINTERFACE <INetworkProfileUpdateNetworkInterfacesItem[]>: NetworkInterfaces - list of network interfaces to be attached to the virtual machine instance
  [Id <String>]: ID - Resource ID of the network interface

STORAGEPROFILEDATADISK <IStorageProfileUpdateDataDisksItem[]>: adds data disks to the virtual machine instance for the update call
  [Id <String>]: 
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/update-azstackhcivmvirtualmachine
#>
function Update-AzStackHciVMVirtualMachine {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20230901Preview.IVirtualMachineInstance])]
    [CmdletBinding(PositionalBinding=$false)]    

    param( 
        [Parameter(ParameterSetName='ByResourceId', Mandatory)]  
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
        [System.String]
        # The ARM Resource ID of the virtual network.
        ${ResourceId},

        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Alias('VirtualMachineName')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
        [System.String]
        # Name of the virtual machine
        ${Name},
        
        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [System.Int64]
        # RAM in MB for the virtual machine instance
        ${VmMemory},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [System.Int32]
        # number of processors for the virtual machine instance
        ${VmProcessors},
    
        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum])]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.VMSizeEnum]
        # .
        ${VmSize},

        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IGalleryImagesUpdateRequestTags]))]
        [System.Collections.Hashtable]
        ${Tags},

        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    
    )
      process {

        if (($ResourceId -match $vmRegex) -or ($Name -and $ResourceGroupName -and $SubscriptionId)){
            if ($ResourceId -match $vmRegex){
                $SubscriptionId = $($Matches['subscriptionId'])
                $ResourceGroupName = $($Matches['resourceGroupName'])
                $Name = $($Matches['machineName'])
            }
            $resourceUri = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.HybridCompute/machines/" + $Name
            $PSBoundParameters.Add("ResourceUri", $resourceUri)
            if ($VmMemory)
            {
                $PSBoundParameters.Add("HardwareProfileMemoryMb", $VmMemory)
                $null = $PSBoundParameters.Remove("VmMemory")
            }
            if ($VmProcessors)
            {
                $PSBoundParameters.Add("HardwareProfileProcessor", $VmProcessors)
                $null = $PSBoundParameters.Remove("VmProcessors")
            }
            if ($VmSize)
            {
                $PSBoundParameters.Add("HardwareProfileVMSize", $VmSize)    
                $null = $PSBoundParameters.Remove("VmSize")
            }
            $null = $PSBoundParameters.Remove("SubscriptionId")
            $null = $PSBoundParameters.Remove("ResourceGroupName")
            $null = $PSBoundParameters.Remove("ResourceId")
            $null = $PSBoundParameters.Remove("Name")
            return  Az.StackHciVM.internal\Update-AzStackHciVMVirtualMachine @PSBoundParameters   
            } else {             
                Write-Error "One or more input parameters are invalid. Resource ID is: $ResourceId, name is $name, resource group name is $resourcegroupname, subscription id is $subscriptionid"
            }  
    }
} 