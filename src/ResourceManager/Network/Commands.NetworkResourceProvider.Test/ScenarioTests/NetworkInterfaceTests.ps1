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
function Test-NetworkInterfaceCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
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
        $vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -AllocationMethod dynamic -Subnet $vnet.Properties.Subnets[0] -PublicIpAddress $publicip
        $expectedNic = Get-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.Properties.ProvisioningState
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Name $actualNic.Properties.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Properties.PublicIpAddress.Id $actualNic.Properties.IpConfigurations[0].Properties.PublicIpAddress.Id
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Properties.Subnet.Id $actualNic.Properties.IpConfigurations[0].Properties.Subnet.Id
        
        # Check publicIp address reference
        $publicip = Get-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Properties.PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Id $publicip.Properties.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Properties.Subnet.Id $vnet.Properties.Subnets[0].Id
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Id $vnet.Properties.Subnets[0].Properties.IpConfigurations[0].Id

        # list
        $list = Get-AzureNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].Properties.ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

        # Delete NetworkInterface
        $delete = Remove-AzureNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureNetworkInterface -ResourceGroupName $rgname
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
Tests creating new simple virtualNetwork without publicIpAddress
#>
function Test-NetworkInterfaceNoPublicIpAddress
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $nicName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create NetworkInterface
        $actualNic = New-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -AllocationMethod dynamic -Subnet $vnet.Properties.Subnets[0]
        $expectedNic = Get-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.Properties.ProvisioningState
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Name $actualNic.Properties.IpConfigurations[0].Name
        Assert-Null $expectedNic.Properties.IpConfigurations[0].Properties.PublicIpAddress.Id
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Properties.Subnet.Id $actualNic.Properties.IpConfigurations[0].Properties.Subnet.Id
        
        # Check Subnet address reference
        $vnet = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Properties.Subnet.Id $vnet.Properties.Subnets[0].Id
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Id $vnet.Properties.Subnets[0].Properties.IpConfigurations[0].Id

        # list
        $list = Get-AzureNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].Properties.ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

        # Delete NetworkInterface
        $delete = Remove-AzureNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureNetworkInterface -ResourceGroupName $rgname
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
Tests creating new simple virtualNetwork.
#>
function Test-NetworkInterfaceSet
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $publicIpName2 = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $domainNameLabel2 = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -AllocationMethod dynamic -SubnetId $vnet.Properties.Subnets[0].Id -PublicIpAddressId $publicip.Id
        $expectedNic = Get-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.Properties.ProvisioningState
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Name $actualNic.Properties.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Properties.PublicIpAddress.Id $actualNic.Properties.IpConfigurations[0].Properties.PublicIpAddress.Id
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Properties.Subnet.Id $actualNic.Properties.IpConfigurations[0].Properties.Subnet.Id
        
        # Check publicIp address reference
        $publicip = Get-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Properties.PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Id $publicip.Properties.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Properties.Subnet.Id $vnet.Properties.Subnets[0].Id
        Assert-AreEqual $expectedNic.Properties.IpConfigurations[0].Id $vnet.Properties.Subnets[0].Properties.IpConfigurations[0].Id

        # Create the publicip
        $publicip2 = New-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2
        $nic = Get-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname

        # Edit Nic with a new publicIpAddress
        $nic.Properties.IpConfigurations[0].Properties.PublicIpAddress.Id = $publicip2.Id

        $nic | Set-AzureNetworkInterface

        $nic = Get-AzureNetworkInterface -Name $nicName -ResourceGroupName $rgname

        # Check publicIp address reference
        $publicip2 = Get-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName2
        Assert-AreEqual $nic.Properties.IpConfigurations[0].Properties.PublicIpAddress.Id $publicip2.Id
        Assert-AreEqual $nic.Properties.IpConfigurations[0].Id $publicip2.Properties.IpConfiguration.Id

        # Check the old publicIp address reference
        $publicip = Get-AzurePublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-Null $publicip.Properties.IpConfiguration

        # Check Subnet address reference
        $vnet = Get-AzurevirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $nic.Properties.IpConfigurations[0].Properties.Subnet.Id $vnet.Properties.Subnets[0].Id
        Assert-AreEqual $nic.Properties.IpConfigurations[0].Id $vnet.Properties.Subnets[0].Properties.IpConfigurations[0].Id

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}