
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
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IVirtualMachineInstance
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/remove-azstackhcivmvirtualmachinenetworkinterface
#>

function Remove-AzStackHCIVMVirtualMachineNetworkInterface {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IVirtualMachineInstance])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Alias('VirtualMachineName')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
        [System.String]
        # Name of the virtual machine
        ${Name},
    
        [Parameter(ParameterSetName='ByName', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},
    
        [Parameter(ParameterSetName='ByResourceId', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
        [System.String]
        # The ARM Resource ID of the virtual machine.
        ${ResourceId},
    
        [Parameter(ParameterSetName='ByName')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
        [System.String[]]
        # NetworkInterfaces - list of network interfaces to be attached from  the virtual machine in id format. 
        ${NicId},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
        [System.String[]]
        # NetworkInterfaces - list of network interfaces to be removed from the virtual machine in name format.
        ${NicName},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
        [System.String]
        # NetworkInterfaces - resource group of the network interfaces 
        ${NicResourceGroup},

        
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
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
        $VM = Az.StackHCIVM.internal\Get-AzStackHCIVMVirtualMachine -ResourceUri $resourceUri

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
        
        return Az.StackHCIVM.internal\Update-AzStackHCIVMVirtualMachine @PSBoundParameters
    }