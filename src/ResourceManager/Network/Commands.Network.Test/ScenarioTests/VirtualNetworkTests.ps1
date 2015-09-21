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
Tests creating new simple virtualNetwork.
#>
function Test-VirtualNetworkCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $actual = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8 -Subnet $subnet
        $expected = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        Assert-AreEqual $expected.ResourceGroupName $rgname	
        Assert-AreEqual $expected.Name $actual.Name	
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual "Succeeded" $expected.ProvisioningState
        Assert-AreEqual "10.0.0.0/16" $expected.AddressSpace.AddressPrefixes[0]
        Assert-AreEqual 1 @($expected.DhcpOptions.DnsServers).Count
        Assert-AreEqual "8.8.8.8" $expected.DhcpOptions.DnsServers[0]
        Assert-AreEqual 1 @($expected.Subnets).Count
        Assert-AreEqual $subnetName $expected.Subnets[0].Name
        Assert-AreEqual "10.0.1.0/24" $expected.Subnets[0].AddressPrefix
        
        # List virtual Network
        $list = Get-AzurevirtualNetwork -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actual.Name	
        Assert-AreEqual $list[0].Location $actual.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual "10.0.0.0/16" $list[0].AddressSpace.AddressPrefixes[0]
        Assert-AreEqual 1 @($list[0].Subnets).Count
        Assert-AreEqual $subnetName $list[0].Subnets[0].Name
        Assert-AreEqual "10.0.1.0/24" $list[0].Subnets[0].AddressPrefix
        Assert-AreEqual $expected.Etag $list[0].Etag
        
        # Delete VirtualNetwork
        $delete = Remove-AzurevirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete
                
        $list = Get-AzurevirtualNetwork -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple virtualNetwork and subnets.
#>
function Test-subnetCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $subnet2Name = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        # Add a subnet
        $vnet | Add-AzureVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.2.0/24
        
        # Set VirtualNetwork
        $vnet | Set-AzureVirtualNetwork
        
        # Get VirtualNetwork
        $vnetExpected = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual "10.0.2.0/24" $vnetExpected.Subnets[1].AddressPrefix
        
        # Edit a subnet
        Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Set-AzureVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.3.0/24 | Set-AzureVirtualNetwork
        
        $vnetExpected = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual "10.0.3.0/24" $vnetExpected.Subnets[1].AddressPrefix
        
        # Get subnet
        $subnet2 = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzureVirtualNetworkSubnetConfig -Name $subnet2Name
        $subnetAll = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzureVirtualNetworkSubnetConfig
        
        Assert-AreEqual 2 @($subnetAll).Count
        Assert-AreEqual $subnetName $subnetAll[0].Name
        Assert-AreEqual $subnet2Name $subnetAll[1].Name
        Assert-AreEqual $subnet2Name $subnet2.Name

        # Remove a subnet
        Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Remove-AzureVirtualNetworkSubnetConfig -Name $subnet2Name | Set-AzureVirtualNetwork
        
        $vnetExpected = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name		
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}