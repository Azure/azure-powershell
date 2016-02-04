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
Tests creating new simple public networkinterface and read using expandResource
#>
function Test-NetworkInterfaceExpandResource
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip
        $expectedNic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-NotNull $expectedNic.ResourceGuid
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "Dynamic" $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod

		Assert-Null $expectedNic.IpConfigurations[0].PublicIpAddress.Name
		Assert-Null $expectedNic.IpConfigurations[0].Subnet.Name
        
        # Check publicIp address reference
        $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # Get Nic with expanded Subnet
		$nic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -ExpandResource "IpConfigurations/Subnet"
		Assert-Null $nic.IpConfigurations[0].PublicIpAddress.Name
		Assert-NotNull $nic.IpConfigurations[0].Subnet.Name

		# Get Nic with expanded PublicIPAddress
		$nic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -ExpandResource "IpConfigurations/PublicIPAddress"
		Assert-NotNull $nic.IpConfigurations[0].PublicIpAddress.Name
		Assert-Null $nic.IpConfigurations[0].Subnet.Name

        # Delete NetworkInterface
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
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
Tests creating new simple public networkinterface.
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
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip
        $expectedNic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-NotNull $expectedNic.ResourceGuid
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "Dynamic" $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod

        
        # Check publicIp address reference
        $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # list
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

        # Delete NetworkInterface
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
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
Tests creating new simple public networkinterface.
#>
function Test-NetworkInterfaceCRUDUsingId
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $publicip.Id
        $expectedNic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "Dynamic" $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod

        
        # Check publicIp address reference
        $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # list
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

        # Delete NetworkInterface
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
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
Tests creating new simple virtualNetwork with static allocation.
#>
function Test-NetworkInterfaceCRUDStaticAllocation
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic

        # Create NetworkInterface
        $actualNic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -PrivateIpAddress "10.0.1.5" -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip
        $expectedNic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual "Static" $actualNic.IpConfigurations[0].PrivateIpAllocationMethod
        Assert-AreEqual "10.0.1.5" $actualNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        
        # Check publicIp address reference
        $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id
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
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create NetworkInterface
        $actualNic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]
        $expectedNic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-Null $expectedNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        
        # Check Subnet address reference
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # list
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

        # Delete NetworkInterface
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
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
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $publicip.Id
        $expectedNic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        
        # Check publicIp address reference
        $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # Create the publicip
        $publicip2 = New-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel2
        $nic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname

        # Edit Nic with a new publicIpAddress
        $nic.IpConfigurations[0].PublicIpAddress = $publicip2

        $nic | Set-AzureRmNetworkInterface

        $nic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname

        # Check publicIp address reference
        $publicip2 = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2
        Assert-AreEqual $nic.IpConfigurations[0].PublicIpAddress.Id $publicip2.Id
        Assert-AreEqual $nic.IpConfigurations[0].Id $publicip2.IpConfiguration.Id

        # Check the old publicIp address reference
        $publicip = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-Null $publicip.IpConfiguration

        # Check Subnet address reference
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $nic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $nic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple public networkinterface with Idns.
#>
function Test-NetworkInterfaceIDns
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
        
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create NetworkInterface
        $actualNic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -InternalDnsNameLabel "idnstest"
        $expectedNic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "Dynamic" $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod
        Assert-AreEqual "idnstest" $expectedNic.DnsSettings.InternalDnsNameLabel
        Assert-NotNull $expectedNic.DnsSettings.InternalFqdn
		
        # Delete NetworkInterface
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
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
Tests creating new simple public networkinterface with Idns.
#>
function Test-NetworkInterfaceEnableIPForwarding
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"    
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create NetworkInterface
        $actualNic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -EnableIPForwarding
        $expectedNic = Get-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual true $expectedNic.EnableIPForwarding

		# Create NetworkInterface without IPForwarding
		$nic = New-AzureRmNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -Force
		Assert-AreEqual $expectedNic.Name $nic.Name	
		Assert-AreEqual false $nic.EnableIPForwarding

		# set nic
		$nic.EnableIPForwarding = $true
		$nic =  $nic | Set-AzureRmNetworkInterface

		Assert-AreEqual $expectedNic.Name $nic.Name	
		Assert-AreEqual true $nic.EnableIPForwarding
		
        # Delete NetworkInterface
        $delete = Remove-AzureRmNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzureRmNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}