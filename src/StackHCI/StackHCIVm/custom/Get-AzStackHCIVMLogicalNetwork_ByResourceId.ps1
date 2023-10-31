
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
Gets a Logical Network 

.Description
Gets a Logical Network 

.Example
PS C:\> {Get-AzStackHciVMLogicalNetwork -Name "testLnet"  -ResourceGroupName "test-rg" }

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.ILogicalNetworks

.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/get-azstackhcivmlogicalnetwork
#>
function Get-AzStackHciVMLogicalNetwork_ByResourceId {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20230901Preview.ILogicalNetworks])]
[CmdletBinding(PositionalBinding=$false)]

param(
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The ARM ID of the logical network.
    ${ResourceId},


    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}

)
  process {
       
        if ($ResourceId -match $lnetRegex){
        
            $subscriptionId = $($Matches['subscriptionId'])
            $resourceGroupName = $($Matches['resourceGroupName'])
            $resourceName = $($Matches['logicalNetworkName'])
            $null = $PSBoundParameters.Remove("ResourceId")
            $PSBoundParameters.Add("Name", $resourceName)
            $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
            $null = $PSBoundParameters.Remove("SubscriptionId")
            $PSBoundParameters.Add("SubscriptionId", $subscriptionId)
            
            return  Az.StackHciVM\Get-AzStackHciVMLogicalNetwork @PSBoundParameters

        } else {             
            Write-Error "Resource ID is invalid: $ResourceId"
        }
        
    }
} 