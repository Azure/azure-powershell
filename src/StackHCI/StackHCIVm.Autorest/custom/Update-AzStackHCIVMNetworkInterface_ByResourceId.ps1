
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
The operation to update a network interface.
.Description
The operation to update a network interface.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.INetworkInterfaces

.Link
https://learn.microsoft.com/powershell/module/az.stackhci/update-azstackhcivmnetworkinterface
#>
function Update-AzStackHCIVmNetworkInterface_ByResourceId {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.INetworkInterfaces])]
[CmdletBinding(PositionalBinding=$false)]

param(
 
    
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [System.String]
    # The ARM Resource ID of the network interface.
    ${ResourceId},

    
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.INetworkInterfacesUpdateRequestTags]))]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tag}

)
  process {
    
        if ($ResourceId -match $nicRegex){
            
            $subscriptionId = $($Matches['subscriptionId'])
            $resourceGroupName = $($Matches['resourceGroupName'])
            $resourceName = $($Matches['nicName'])
            $null = $PSBoundParameters.Remove("ResourceId")
            $PSBoundParameters.Add("Name", $resourceName)
            $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
            $null = $PSBoundParameters.Remove("SubscriptionId")
            $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

            return  Az.StackHCIVm\Update-AzStackHCIVmNetworkInterface @PSBoundParameters

        } else {             
            Write-Error "Resource ID is invalid: $ResourceId"
        }
        
    }
} 