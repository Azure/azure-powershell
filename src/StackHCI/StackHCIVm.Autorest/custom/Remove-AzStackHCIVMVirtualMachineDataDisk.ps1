
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
The operation to delete a data disk from a virtual machine.
.Description
The operation to delete a data disk from a  virtual machine.
.Example
{{ Add code here }}
.Example
{{ Add code here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualMachineInstance
.Link
https://learn.microsoft.com/powershell/module/az.stackhci/remove-azstackhcivmvirtualmachinedatadisk
#>

function Remove-AzStackHCIVmVirtualMachineDataDisk {
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
        # The ARM Resource ID of the virtual machine.
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
        # Data Disks - list of data disks to be removed from  the virtual machine in id format.
        ${DataDiskId},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [System.String[]]
        # Data Disks - list of data disks to be removed from  the virtual machine in name format.
        ${DataDiskName},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [System.String]
        # Resource Group of the Data Disks.
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
            Write-Error "One or more input parameters are invalid. Resource ID is: $ResourceId, name is $name, resource group name is $resourcegroupname, subscription id is $subscriptionid" -ErrorAction Stop
        }
    

        $NewStorageProfileDataDisk =  [System.Collections.ArrayList]::new()
        $diskList =  [System.Collections.ArrayList]::new()
        $VM = Az.StackHCIVm.internal\Get-AzStackHCIVmVirtualMachine -ResourceUri $resourceUri
        if ($VM.StorageProfileDataDisk.Id.GetType() -eq [System.String]){
            [void]$diskList.add($VM.StorageProfileDataDisk.Id)
        } else {
            $diskList = [System.Collections.ArrayList]$VM.StorageProfileDataDisk.Id
        }

        if ($DataDiskId){
            $DataDisks = $PSBoundParameters['DataDiskId']
            $null = $PSBoundParameters.Remove("DataDiskId")          
            
            foreach ($DataDisk in $DataDisks){
                $diskName = ($DataDisk -split "/")[8]
                if ($DataDisk -in $diskList) {
                    [void]$diskList.Remove($DataDisk)
                } elseif ( $diskName -in $diskList){
                    [void]$diskList.Remove($diskName)
                } else {
                    Write-Error "Data Disk is not currently attached: $DataDisk"
                }
            }
    
            $PSBoundParameters.Add('StorageProfileDataDisk',  $StorageProfileDataDisk)
    
        } elseif ($DataDiskName){
            $rg = $ResourceGroupName
            if($DataDiskResourceGroup){
              $rg = $DataDiskResourceGroup
            }
    
            $null = $PSBoundParameters.Remove("DataDiskName")
            $null = $PSBoundParameters.Remove("DataDiskResourceGroup")
            
            foreach ($DiskName in $DataDiskName){
                $DiskId = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.AzureStackHCI/virtualHardDisks/$DiskName"
                if ($DiskId -in  $diskList) {
                    [void]$diskList.Remove($DiskId)
                } elseif  ($DiskName -in  $diskList) {
                    [void]$diskList.Remove($DiskName)
                } else {
                    Write-Error "Data Disk is not currently attached: $DiskName"
                }
            }
            
        }

        foreach ($disk in $diskList){
            $DataDisk = @{Id = $disk}
            [void]$NewStorageProfileDataDisk.Add($DataDisk)
        }
    
        $PSBoundParameters.Add('StorageProfileDataDisk',  $NewStorageProfileDataDisk)


        return Az.StackHCIVm.internal\Update-AzStackHCIVmVirtualMachine @PSBoundParameters
    }
