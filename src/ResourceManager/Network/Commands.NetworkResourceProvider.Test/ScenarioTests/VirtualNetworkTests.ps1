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
        $actual = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $expected = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $expected.Name $actual.Name	
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual "Succeeded" $expected.Properties.ProvisioningState
        Assert-AreEqual "10.0.0.0/16" $expected.Properties.AddressSpace.AddressPrefixes[0]
        Assert-AreEqual 1 @($expected.Properties.Subnets).Count
        Assert-AreEqual $subnetName $expected.Properties.Subnets[0].Name
        Assert-AreEqual "10.0.1.0/24" $expected.Properties.Subnets[0].Properties.AddressPrefix
        
        # List virtual Network
        $list = Get-AzurevirtualNetwork -ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actual.Name	
        Assert-AreEqual $list[0].Location $actual.Location
        Assert-AreEqual "Succeeded" $list[0].Properties.ProvisioningState
        Assert-AreEqual "10.0.0.0/16" $list[0].Properties.AddressSpace.AddressPrefixes[0]
        Assert-AreEqual 1 @($list[0].Properties.Subnets).Count
        Assert-AreEqual $subnetName $list[0].Properties.Subnets[0].Name
        Assert-AreEqual "10.0.1.0/24" $list[0].Properties.Subnets[0].Properties.AddressPrefix
        Assert-AreEqual $expected.Etag $list[0].Etag
        
        # Delete VirtualNetwork
        $delete = Remove-AzurevirtualNetwork -ResourceGroupName $actual.ResourceGroupName -name $vnetName
        Assert-AreEqual "Succeeded" $delete.Status
        Assert-AreEqual "OK" $delete.StatusCode
        
        $list = Get-AzurevirtualNetwork -ResourceGroupName $actual.ResourceGroupName
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

        Assert-AreEqual 2 @($vnetExpected.Properties.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Properties.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Properties.Subnets[1].Name
        Assert-AreEqual "10.0.2.0/24" $vnetExpected.Properties.Subnets[1].Properties.AddressPrefix
        
        # Edit a subnet
        Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Set-AzureVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.3.0/24 | Set-AzureVirtualNetwork
        
        $vnetExpected = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 2 @($vnetExpected.Properties.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Properties.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Properties.Subnets[1].Name
        Assert-AreEqual "10.0.3.0/24" $vnetExpected.Properties.Subnets[1].Properties.AddressPrefix
        
        # Remove a subnet
        Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Remove-AzureVirtualNetworkSubnetConfig -Name $subnet2Name | Set-AzureVirtualNetwork
        
        $vnetExpected = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($vnetExpected.Properties.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Properties.Subnets[0].Name		
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}