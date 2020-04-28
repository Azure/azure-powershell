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
Tests checking API to list service tags.
#>
function Test-LoadBalancerBackendPoolCRUD
{

    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $lbName = Get-ResourceName
    $frontendName = Get-ResourceName
    $backendAddressPoolName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/loadBalancers"
    $location = Get-ProviderLocation $resourceTypeParent
    $backendAddressConfigName = "TestVNetRef"
    $testIpAddress = "10.0.0.5"

    try
    {
         # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval"} 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create Standard Azure load balancer
        New-AzLoadBalancer -Name $lbName -ResourceGroupName $rgname -Location $location -SKU Standard

        # Create load balancer backend pool
        $backendPoolInitial = New-AzLoadBalancerBackendAddressPool -ResourceGroupName $rgname -LoadBalancerName $lbName -BackendAddressPoolName $backendAddressPoolName


        $ip1 = New-AzLoadBalancerBackendAddressConfig -IpAddress $testIpAddress -Name $backendAddressConfigName -VirtualNetwork $vnet 

        # Add Ip to pool address list
        $backendPoolInitial.LoadBalancerBackendAddresses.Add($ip1)

        $backendPoolSet1 = Set-AzLoadBalancerBackendAddressPool -ResourceGroupName $rgname -LoadBalancerName $lbName -BackendAddressPoolName $backendAddressPoolName -BackendAddressPool $backendPoolInitial 
       
        Assert-NotNull  $backendPoolSet1

        Assert-AreEqual $backendAddressPoolName $backendPoolSet1.Name
        Assert-AreEqual $backendPoolInitial.Id $backendPoolSet1.Id
        Assert-AreEqual "Succeeded" $backendPoolSet1.ProvisioningState

        $listOfBackendAddresses = $backendPoolSet1.LoadBalancerBackendIPAddresses 

        
        Assert-NotNull $listOfBackendAddresses 
        Assert-True { @($listOfBackendAddresses).Count -eq 1 }

        Assert-AreEqual $listOfBackendAddresses[0].Name $backendAddressConfigName
        Assert-AreEqual $listOfBackendAddresses[0].IpAddress $testIpAddress
        Assert-AreEqual $listOfBackendAddresses[0].Id $vnet.Id

        #remove IpAddress from list
        $backendPoolSet1.LoadBalancerBackendAddresses.Remove($backendPoolSet1.LoadBalancerBackendAddresses[0])
        $backendPoolSet2 = Set-AzLoadBalancerBackendAddressPool -ResourceGroupName $rgname -LoadBalancerName $lbName -BackendAddressPoolName $backendAddressPoolName -BackendAddressPool $backendPoolInitial

               
        Assert-NotNull  $backendPoolSet2
        
        $listOfBackendAddresses2 = $backendPoolSet2.LoadBalancerBackendIPAddresses 
        Assert-True { @(listOfBackendAddresses2).Count -eq 0 }
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
