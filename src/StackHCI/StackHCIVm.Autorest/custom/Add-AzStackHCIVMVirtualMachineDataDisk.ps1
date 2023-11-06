
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
The operation to add a data disk to a virtual machine. 
.Description
The operation to add a data disk to a virtual machine. 
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualMachineInstances

.Notes
COMPLEX PARAMETER PROPERTIES

.Link
https://learn.microsoft.com/powershell/module/az.stackhci/add-azstackhcivmvirtualmachinedatadisk
#>

function Add-AzStackHCIVmVirtualMachineDataDisk {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualMachineInstance])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Alias('VirtualMachineName')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
        [System.String]
        # Name of the virtual machine
        ${Name},
    
        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='ByResourceId', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
        [System.String]
        # The ARM Resource ID of the VM
        ${ResourceId},
    
        [Parameter(ParameterSetName='ByName')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [System.String[]]
        # List of data disks to be attached to the virtual machine passed in Id format
        ${DataDiskId},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [System.String[]]
        # List of data disks to be attached to the virtual machine passed by Name 
        ${DataDiskName},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [System.String]
        # Resource Group of the Data Disks
        ${DataDiskResourceGroup}
    )
    
    if (($ResourceId -match $vmRegex) -or ($Name -and $ResourceGroupName -and $SubscriptionId)){
        if ($ResourceId -match $vmRegex){
            $SubscriptionId = $($Matches['subscriptionId'])
            $ResourceGroupName = $($Matches['resourceGroupName'])
            $Name = $($Matches['machineName'])
        }
        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Remove("ResourceGroupName")
        $null = $PSBoundParameters.Remove("SubscriptionId")
        $null = $PSBoundParameters.Remove("ResourceId")
        $resourceUri = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.HybridCompute/machines/" + $Name
        $PSBoundParameters.Add("ResourceUri", $resourceUri)
        } else {
            Write-Error "One or more input parameters are invalid. Resource ID is: $ResourceId, name is $name, resource group name is $resourcegroupname, subscription id is $subscriptionid" 
        }
        $StorageProfileDataDisk =  [System.Collections.ArrayList]::new()
    
        if($DataDiskId){
            foreach ($DiskId in $DataDiskId){
                if ($DiskId -notmatch $vhdRegex){
                    Write-Error "Invalid Data Disk Id provided: $DiskId." -ErrorAction Stop
                }
                $DataDisk = @{Id = $DiskId}
                [void]$StorageProfileDataDisk.Add($DataDisk)
            }
    
            $null = $PSBoundParameters.Remove("DataDiskId")
          
        } elseif ($DataDiskName){
            $rg = $ResourceGroupName
            if($DataDiskResourceGroup){
              $rg = $DataDiskResourceGroup
            }
    
            foreach ($DiskName in $DataDiskName){
                $DataDiskId = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.AzureStackHCI/virtualharddisks/$DiskName"
                $DataDisk = @{Id = $DataDiskId}
                [void]$StorageProfileDataDisk.Add($DataDisk)
            }
    
            $null = $PSBoundParameters.Remove("DataDiskName")
            $null = $PSBoundParameters.Remove("DataDiskResourceGroup")
        }
    
        $vm = Az.StackHCIVm.internal\Get-AzStackHCIVmVirtualMachine @PSBoundParameters
        $disks = $vm.StorageProfileDataDisk
    
        foreach ($disk in $disks){
            $DataDisk = @{Id = $disk.Id}
            [void]$StorageProfileDataDisk.Add($DataDisk)
        }
    
        $PSBoundParameters.Add('StorageProfileDataDisk',  $StorageProfileDataDisk)
        return Az.StackHCIVm.internal\Update-AzStackHCIVmVirtualMachine @PSBoundParameters
    }