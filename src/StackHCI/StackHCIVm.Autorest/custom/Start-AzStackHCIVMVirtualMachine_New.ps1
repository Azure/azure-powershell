
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
The operation to start a virtual machine instance.
.Description
The operation to start a virtual machine instance.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualMachineInstance
.Notes
COMPLEX PARAMETER PROPERTIES


.Link
https://learn.microsoft.com/powershell/module/az.stackhci/start-azstackhcivmvirtualmachine
#>
function Start-AzStackHCIVmVirtualMachine {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IVirtualMachineInstance])]
    [CmdletBinding( PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
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

        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName='ByResourceId', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
        [System.String]
        # The ARM Resource ID of the virtual machine.
        ${ResourceId}

    )       
    if (($ResourceId -match $vmRegex) -or ($Name -and $ResourceGroupName -and $SubscriptionId)){
        if ($ResourceId -match $vmRegex){
            $SubscriptionId = $($Matches['subscriptionId'])
            $ResourceGroupName = $($Matches['resourceGroupName'])
            $Name = $($Matches['machineName'])
        }
        $resourceUri = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.HybridCompute/machines/" + $Name
        $PSBoundParameters.Add("ResourceUri", $resourceUri)
        $null = $PSBoundParameters.Remove("SubscriptionId")
        $null = $PSBoundParameters.Remove("ResourceGroupName")
        $null = $PSBoundParameters.Remove("ResourceId")
        $null = $PSBoundParameters.Remove("Name")
        return  Az.StackHCIVm.internal\Start-AzStackHCIVmVirtualMachine @PSBoundParameters    
        } else {             
            Write-Error "One or more input parameters are invalid. Resource ID is: $ResourceId, name is $name, resource group name is $resourcegroupname, subscription id is $subscriptionid"
        }    
}   