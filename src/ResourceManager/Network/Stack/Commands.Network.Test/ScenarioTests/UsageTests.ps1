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
Tests checking usage cmdlet
#>
function Test-NetworkUsage
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/Usages"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        $location = $location -replace " ","";
        $usage = Get-AzureRMNetworkUsage -Location $location;
        $vnetCount = ($usage | Where-Object { $_.name.Value -eq "VirtualNetworks" }).currentValue;
        Assert-AreNotEqual 0 $usage.Length "Usage should return non-empty array";

        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation

        # Create the Virtual Network
        New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8;
        $usage = Get-AzureRMNetworkUsage -Location $location;
        $vnetCount2 = ($usage | Where-Object { $_.name.Value -eq "VirtualNetworks" }).currentValue;

        Assert-AreEqual ($vnetCount + 1) $vnetCount2 "Virtual Networks usage current value should be increased after Virtual Network was created";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
