
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
The operation to delete a network interface from a virtual machine.
.Description
The operation to delete a network interface from a  virtual machine.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualMachineInstance
.Link
https://learn.microsoft.com/powershell/module/az.stackhci/remove-azstackhcivmvirtualmachinenetworkinterface
#>

function Remove-AzStackHCIVmVirtualMachineNetworkInterface {
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
        # NetworkInterfaces - list of network interfaces to be attached from  the virtual machine in id format. 
        ${NicId},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [System.String[]]
        # NetworkInterfaces - list of network interfaces to be removed from the virtual machine in name format.
        ${NicName},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
        [System.String]
        # NetworkInterfaces - resource group of the network interfaces 
        ${NicResourceGroup}
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
        
        $NewNetworkProfileNetworkInterface =  [System.Collections.ArrayList]::new()
        $nicList =  [System.Collections.ArrayList]::new()
        $VM = Az.StackHCIVm.internal\Get-AzStackHCIVmVirtualMachine -ResourceUri $resourceUri

        if ($VM.NetworkProfileNetworkInterface.Id.GetType() -eq [System.String]){
            [void]$nicList.add($VM.NetworkProfileNetworkInterface.Id)
        } else {
            $nicList = [System.Collections.ArrayList]$VM.NetworkProfileNetworkInterface.Id
        }

        if ($NicId){
            $NicId = $PSBoundParameters['NicId']
            $null = $PSBoundParameters.Remove("NicId")
            
            foreach ($NId in $NicId){
                $nicName = ($NId -split "/")[8]
                if ($NId -in $nicList){
                    $nicList.Remove($NId)
                } elseif ($nicName -in $nicList){
                    $nicList.Remove($nicName)
                } else {
                    Write-Error "Network Interface not currently attached: $NId"
                }
            }
    
        } elseif ($NicName){
            $rg = $ResourceGroupName
            if($NicResourceGroup){
              $rg = $NicResourceGroup
            }
    
            $null = $PSBoundParameters.Remove("NicName")
            $null = $PSBoundParameters.Remove("NicResourceGroup")

            
            foreach ($NName in $NicName){
                $NId = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.AzureStackHCI/networkInterfaces/$NName"
                if ($NId -in $nicList){
                    [void]$nicList.Remove($NId)
                } elseif ($NName -in $nicList) {
                    $nicList.Remove($NName)
                } else {
                    Write-Error "Network Interface not currently attached: $NName"
                }
            }
    
        }

        foreach ($nic in $nicList){
            $Nic = @{Id = $nic}
            [void]$NewNetworkProfileNetworkInterface.Add($Nic)
        }
       

        $PSBoundParameters.Add('NetworkProfileNetworkInterface',  $NewNetworkProfileNetworkInterface)
        
        return Az.StackHCIVm.internal\Update-AzStackHCIVmVirtualMachine @PSBoundParameters
    }