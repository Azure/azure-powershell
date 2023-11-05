
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
Gets a virtual machine 
.Description
Gets a virtual machine 
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20230901Preview.IVirtualMachineInstance
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmvirtualmachine
#>
function Get-AzStackHCIVmVirtualMachine {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20230315Preview.Machine],ParameterSetName='ByResourceGroup' )]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20230901Preview.IVirtualMachineInstance],ParameterSetName='ByName' )]
    [CmdletBinding( PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(

        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Alias('VirtualMachineName')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
        [System.String]
        # Name of the virtual machine
        ${Name},
        
        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Parameter(ParameterSetName='ByResourceGroup', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='ByName')]
        [Parameter(ParameterSetName='ByResourceGroup')]
        [Parameter(ParameterSetName='BySubscription')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName='ByResourceId', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
        [System.String]
        # The ARM ID of the virtual machine.
        ${ResourceId}
 
    )
      process {
        if ($PSCmdlet.ParameterSetName -eq "ByName" -or $PSCmdlet.ParameterSetName -eq "ByResourceId"){
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
                return  Az.StackHciVM.internal\Get-AzStackHciVMVirtualMachine @PSBoundParameters
            } else {             
                Write-Error "One or more input parameters are invalid. Resource ID is: $ResourceId, name is $name, resource group name is $resourcegroupname, subscription id is $subscriptionid"
            }   
        } elseif ($PSCmdlet.ParameterSetName -eq "ByResourceGroup") {
            $allHCIMachines = [System.Collections.ArrayList]::new()
            $machines = Az.StackHciVM.internal\Get-AzStackHciVMMachine -ResourceGroupName $ResourceGroupName
            foreach ($machine in $machines){
                if ($machine.Kind.ToString() -eq "HCI"){
                    [void]$allHCIMachines.Add($machine) 
                }
            }
            return $allHCIMachines 

        } else {
            $allHCIMachines = [System.Collections.ArrayList]::new()
            $machines = Az.StackHciVM.internal\Get-AzStackHciVMMachine -SubscriptionId $SubscriptionId
            foreach ($machine in $machines){
                if ($machine.Kind.ToString() -eq "HCI"){
                    [void]$allHCIMachines.Add($machine) 
                }
            }
            return $allHCIMachines 

        }
    }
}