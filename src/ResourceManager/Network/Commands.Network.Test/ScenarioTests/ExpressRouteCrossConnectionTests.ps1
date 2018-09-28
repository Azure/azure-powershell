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
.SYNOPSIS
Tests ExpressRouteCircuitCRUD.
#>
function Test-ExpressRouteCrossConnectionApis
{
   # Setup
    $rgname = Get-ResourceGroupName
    $circuitName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/expressRouteCircuits"
    $location = Get-ProviderLocation $resourceTypeParent
    $location = "brazilSouth"
    try 
    {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation
      # Create the ExpressRouteCircuit
      $circuit = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 500;
      
      $circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname

      # Verify that an associated cross connection is created
      $crossConnectionName = $circuit.ServiceKey
      $crossConnectionResourceGroupName = "CrossConnection-SiliconValley"
    }
    finally
    {
      # Cleanup
      # Delete Circuit
      $job = Remove-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force -AsJob
      $job | Wait-Job
      $delete = $job | Receive-Job
      Assert-AreEqual true $delete
    }
}
