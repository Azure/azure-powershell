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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $job = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip -AsJob
        $job | Wait-Job
		$actualNic = $job | Receive-Job
		$expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

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
        $publicip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # Get Nic with expanded Subnet
        $nic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -ExpandResource "IpConfigurations/Subnet"
        Assert-Null $nic.IpConfigurations[0].PublicIpAddress.Name
        Assert-NotNull $nic.IpConfigurations[0].Subnet.Name

        # Get Nic with expanded PublicIPAddress
        $nic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -ExpandResource "IpConfigurations/PublicIPAddress"
        Assert-NotNull $nic.IpConfigurations[0].PublicIpAddress.Name
        Assert-Null $nic.IpConfigurations[0].Subnet.Name

        # Get Nic with expanded Subnet
        $nic = Get-AzNetworkInterface -ResourceId $expectedNic.Id -ExpandResource "IpConfigurations/Subnet"
        Assert-Null $nic.IpConfigurations[0].PublicIpAddress.Name
        Assert-NotNull $nic.IpConfigurations[0].Subnet.Name

        # Get Nic with expanded PublicIPAddress
        $nic = Get-AzNetworkInterface -ResourceId $expectedNic.Id -ExpandResource "IpConfigurations/PublicIPAddress"
        Assert-NotNull $nic.IpConfigurations[0].PublicIpAddress.Name
        Assert-Null $nic.IpConfigurations[0].Subnet.Name

        # Delete NetworkInterface
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
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
    $rglocation = Get-ProviderLocation ResourceManagement "East US 2 EUAP"
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent "East US 2 EUAP"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip -EnableAcceleratedNetworking -Tag @{ fastpathenabled = "true"}
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-NotNull $expectedNic.ResourceGuid
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
        Assert-NotNull $expectedNic.DefaultOutboundConnectivityEnabled
        Assert-AreEqual $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod $actualNic.IpConfigurations[0].PrivateIpAllocationMethod

        $expectedNic = Get-AzNetworkInterface -ResourceId $actualNic.Id

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName
        Assert-AreEqual $expectedNic.Name $actualNic.Name
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-NotNull $expectedNic.ResourceGuid
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod $actualNic.IpConfigurations[0].PrivateIpAllocationMethod

        # Check publicIp address reference
        $publicip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # list
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

        # Delete NetworkInterface
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $publicip.Id
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod $actualNic.IpConfigurations[0].PrivateIpAllocationMethod

        
        # Check publicIp address reference
        $publicip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # list
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

        # Delete NetworkInterface
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
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
function Test-NetworkInterface-GatewayLoadBalancerConsumer
{
    # Setup
    $rgname = Get-ResourceGroupName

    $vnetProviderName = Get-ResourceName
    $subnetProviderName = Get-ResourceName
    $lbProviderName = Get-ResourceName
    $frontendProviderName = Get-ResourceName

    $vnetConsumerName = Get-ResourceName
    $subnetConsumerName = Get-ResourceName
    $publicIpConsumerName = Get-ResourceName
    $nicConsumerName = Get-ResourceName
    $ipconfigConsumerName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create Provider Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetProviderName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetProviderName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create Provider LoadBalancer
        $frontendProvider = New-AzLoadBalancerFrontendIpConfig -Name $frontendProviderName -Subnet $vnet.Subnets[0]
        $lbProvider = New-AzLoadBalancer -Name $lbProviderName -ResourceGroupName $rgname -Location $location -FrontendIpConfiguration $frontendProvider -Sku Gateway

        # Create Consumer Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetConsumerName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetConsumerName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create Consumer publicip
        $publicipConsumer = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpConsumerName -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel

		# Create the ipconfiguration
        $ipconfig1 = New-AzNetworkInterfaceIpConfig -Name $ipconfigConsumerName -Subnet $vnet.Subnets[0] -PublicIpAddress $publicipConsumer -GatewayLoadBalancerId $frontendProvider.Id

        # Create NetworkInterface
        $nicConsumer = New-AzNetworkInterface -Name $nicConsumerName -ResourceGroupName $rgname -Location $location -IpConfiguration $ipconfig1 -Tag @{ testtag = "testval" }

        # Get NetworkInterface
        $expectedNicConsumer = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        # Verification
        Assert-AreEqual $frontendProvider.Id $expectedNicConsumer.ipconfigurations[0].GatewayLoadBalancer    
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static

        # Create NetworkInterface
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -PrivateIpAddress "10.0.1.5" -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip -AuxiliaryMode None
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod $actualNic.IpConfigurations[0].PrivateIpAllocationMethod
        Assert-AreEqual "10.0.1.5" $actualNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        
        # Check publicIp address reference
        $publicip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create NetworkInterface
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0]
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-Null $expectedNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        
        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # list
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

        # Delete NetworkInterface
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -SubnetId $vnet.Subnets[0].Id -PublicIpAddressId $publicip.Id
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        
        # Check publicIp address reference
        $publicip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # Create the publicip
        $publicip2 = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2 -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel2
        $nic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        # Edit Nic with a new publicIpAddress
        $nic.IpConfigurations[0].PublicIpAddress = $publicip2

        $job = $nic | Set-AzNetworkInterface -AsJob
	$job | Wait-Job

        $nic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        # Check publicIp address reference
        $publicip2 = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName2
        Assert-AreEqual $nic.IpConfigurations[0].PublicIpAddress.Id $publicip2.Id
        Assert-AreEqual $nic.IpConfigurations[0].Id $publicip2.IpConfiguration.Id

        # Check the old publicIp address reference
        $publicip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-Null $publicip.IpConfiguration

        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create NetworkInterface
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -InternalDnsNameLabel "idnstest"
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

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
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create NetworkInterface
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -EnableIPForwarding
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

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
		$nic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -Force
		Assert-AreEqual $expectedNic.Name $nic.Name	
		Assert-AreEqual false $nic.EnableIPForwarding

		# set nic
		$nic.EnableIPForwarding = $true
		$nic =  $nic | Set-AzNetworkInterface

		Assert-AreEqual $expectedNic.Name $nic.Name	
		Assert-AreEqual true $nic.EnableIPForwarding
		
        # Delete NetworkInterface
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
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
Tests creating new Ipv6 networkinterface.
#>
function Test-NetworkInterfaceIpv6
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
	$subnet2Name = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
	$ipconfigName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
		$subnet2 = New-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.2.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet,$subnet2
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        # Check publicIp address reference
        $publicip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # list
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

		# Add a ipv6 ipconfig
		$nic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname | Add-AzNetworkInterfaceIpConfig -Name $ipconfigName -PrivateIpAddressVersion ipv6 | Set-AzNetworkInterface
		Assert-AreEqual 2 @($nic.IpConfigurations).Count

		Assert-AreEqual $expectedNic.IpConfigurations[0].Name $nic.IpConfigurations[0].Name
        Assert-AreEqual $publicip.Id $nic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $vnet.Subnets[0].Id $nic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $nic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "Dynamic" $nic.IpConfigurations[1].PrivateIpAllocationMethod
		Assert-AreEqual $nic.IpConfigurations[0].PrivateIpAddressVersion IPv4

		Assert-AreEqual $ipconfigName $nic.IpConfigurations[1].Name
        Assert-Null $nic.IpConfigurations[1].PublicIpAddress
        Assert-Null $nic.IpConfigurations[1].Subnet
        Assert-AreEqual $nic.IpConfigurations[1].PrivateIpAddressVersion IPv6

		# Set Ipconfig
		$nic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname | Set-AzNetworkInterfaceIpConfig -Name $nic.IpConfigurations[0].Name -Subnet $vnet.Subnets[1] -PrivateIpAddress "10.0.2.10" | Set-AzNetworkInterface
		Assert-AreEqual 2 @($nic.IpConfigurations).Count

		Assert-AreEqual $expectedNic.IpConfigurations[0].Name $nic.IpConfigurations[0].Name
        Assert-Null $nic.IpConfigurations[0].PublicIpAddress
        Assert-AreEqual $vnet.Subnets[1].Id $nic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $nic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "Static" $nic.IpConfigurations[0].PrivateIpAllocationMethod
		Assert-AreEqual $nic.IpConfigurations[0].PrivateIpAddressVersion IPv4

		Assert-AreEqual $ipconfigName $nic.IpConfigurations[1].Name
        Assert-Null $nic.IpConfigurations[1].PublicIpAddress
        Assert-Null $nic.IpConfigurations[1].Subnet
        Assert-AreEqual $nic.IpConfigurations[1].PrivateIpAddressVersion IPv6

		# Get IpConfig
		$ipconfigv6 = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname | Get-AzNetworkInterfaceIpConfig -Name $ipconfigName
	
		Assert-AreEqual $ipconfigName $ipconfigv6.Name
        Assert-Null $ipconfigv6.PublicIpAddress
        Assert-Null $ipconfigv6.Subnet
        Assert-AreEqual $ipconfigv6.PrivateIpAddressVersion IPv6

		# List IpConfig
		$ipconfigList = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname | Get-AzNetworkInterfaceIpConfig
	
		Assert-AreEqual 2 @($ipconfigList).Count

		Assert-AreEqual $expectedNic.IpConfigurations[0].Name $ipconfigList[0].Name
        Assert-Null $ipconfigList[0].PublicIpAddress.Id
        Assert-NotNull $ipconfigList[0].PrivateIpAddress
		Assert-AreEqual $ipconfigList[0].PrivateIpAddressVersion IPv4

		Assert-AreEqual $ipconfigName $ipconfigList[1].Name
        Assert-Null $ipconfigList[1].PublicIpAddress
        Assert-Null $ipconfigList[1].Subnet
        Assert-AreEqual $ipconfigList[1].PrivateIpAddressVersion IPv6

		# Remove IpConfig
		$nic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname | Remove-AzNetworkInterfaceIpConfig -Name $ipconfigName | Set-AzNetworkInterface

		Assert-AreEqual 1 @($nic.IpConfigurations).Count

		Assert-AreEqual $expectedNic.IpConfigurations[0].Name $nic.IpConfigurations[0].Name
        Assert-Null $nic.IpConfigurations[0].PublicIpAddress
        Assert-AreEqual $vnet.Subnets[1].Id $nic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $nic.IpConfigurations[0].PrivateIpAddress
		Assert-AreEqual $nic.IpConfigurations[0].PrivateIpAddressVersion IPv4

        # Delete NetworkInterface
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
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
Tests creating new networkinterface with multiple ipconfigurations.
#>
function Test-NetworkInterfaceWithIpConfiguration
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
	$ipconfig1Name = Get-ResourceName
	$ipconfig2Name = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

		# Create the ipconfiguration
		$ipconfig1 = New-AzNetworkInterfaceIpConfig -Name $ipconfig1Name -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip
		$ipconfig2 = New-AzNetworkInterfaceIpConfig -Name $ipconfig2Name -PrivateIpAddressVersion IPv6

        # Create NetworkInterface
        $nic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -IpConfiguration $ipconfig1,$ipconfig2 -Tag @{ testtag = "testval" }

        Assert-AreEqual $rgname $nic.ResourceGroupName	
        Assert-AreEqual $nicName $nic.Name	
        Assert-NotNull $nic.ResourceGuid
        Assert-AreEqual "Succeeded" $nic.ProvisioningState
        Assert-AreEqual $nic.IpConfigurations[0].Name $nic.IpConfigurations[0].Name
        Assert-AreEqual $nic.IpConfigurations[0].PublicIpAddress.Id $nic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $nic.IpConfigurations[0].Subnet.Id $nic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $nic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "Dynamic" $nic.IpConfigurations[0].PrivateIpAllocationMethod
		        
        # Check publicIp address reference
        $publicip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $nic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $nic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $nic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $nic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

		# Verify ipconfigs
		Assert-AreEqual 2 @($nic.IpConfigurations).Count

		Assert-AreEqual $ipconfig1Name $nic.IpConfigurations[0].Name
        Assert-AreEqual $publicip.Id $nic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $vnet.Subnets[0].Id $nic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $nic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "Dynamic" $nic.IpConfigurations[0].PrivateIpAllocationMethod
		Assert-AreEqual $nic.IpConfigurations[0].PrivateIpAddressVersion IPv4

		Assert-AreEqual $ipconfig2Name $nic.IpConfigurations[1].Name
        Assert-Null $nic.IpConfigurations[1].PublicIpAddress
        Assert-Null $nic.IpConfigurations[1].Subnet
        Assert-AreEqual $nic.IpConfigurations[1].PrivateIpAddressVersion IPv6

        # Delete NetworkInterface
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
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
function Test-NetworkInterfaceWithAcceleratedNetworking
{
   # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "West Central US"
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent "West Central US"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip -EnableAcceleratedNetworking
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-NotNull $expectedNic.ResourceGuid
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
		Assert-AreEqual $expectedNic.EnableAcceleratedNetworking $true
        Assert-AreEqual $actualNic.IpConfigurations[0].PrivateIpAllocationMethod $expectedNic.IpConfigurations[0].PrivateIpAllocationMethod

        
        # Check publicIp address reference
        $publicip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # list
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

        $list = Get-AzNetworkInterface -ResourceGroupName "*" -Name "*"
        Assert-True { $list.Count -ge 0 }

        $list = Get-AzNetworkInterface -Name "*"
        Assert-True { $list.Count -ge 0 }

        $list = Get-AzNetworkInterface -ResourceGroupName "*"
        Assert-True { $list.Count -ge 0 }

        # Delete NetworkInterface
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
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
Tests creating new simple public networkinterface with disableTcpStateTracking Property.
#>
function Test-NetworkInterfaceWithDisableTcpStateTracking
{
   # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

        # Create NetworkInterface with DisableTcpStateTracking Property set to true
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip -DisableTcpStateTracking true
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        Assert-NotNull $expectedNic.ResourceGuid
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $true $expectedNic.DisableTcpStateTracking

        # Delete ResourceGroup
        $delete = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
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
Test creating new NetworkInterfaceTapConfiguration using minimal set of parameters
#>
function Test-NetworkInterfaceTapConfigurationCRUD
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
    $rname = Get-ResourceName
    $vtapName = Get-ResourceName
    $vtapName2 = Get-ResourceName
    $sourceIpConfigName = Get-ResourceName
    $sourceNicName = Get-ResourceName

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $job = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip -AsJob
        $job | Wait-Job
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname

        # Create required dependencies (Vtap)
        $DestinationEndpoint = $expectedNic.IpConfigurations[0]
        $actualVtap = New-AzVirtualNetworkTap -ResourceGroupName $rgname -Name $vtapName -Location $location -DestinationNetworkInterfaceIPConfiguration $DestinationEndpoint  -Force
        $vVirtualNetworkTap = Get-AzVirtualNetworkTap -ResourceGroupName $rgname -Name $vtapName;

        # Create source Nic which is getting tapped
        $sourceIpConfig = New-AzNetworkInterfaceIpConfig -Name $sourceIpConfigName -Subnet $vnet.Subnets[0]
        $sourceNic = New-AzNetworkInterface -Name $sourceNicName -ResourceGroupName $rgname -Location $location -IpConfiguration $sourceIpConfig -Tag @{ testtag = "testval" } -EnableAcceleratedNetworking

        # Add tap configuration
        Add-AzNetworkInterfaceTapConfig -NetworkInterface $sourceNic -VirtualNetworkTap $vVirtualNetworkTap -Name $rname

        #get tap configuration
        $tapConfig = Get-AzNetworkInterfaceTapConfig -ResourceGroupName $rgname -NetworkInterfaceName $sourceNicName -Name $rname
        Assert-NotNull $tapConfig
        Assert-AreEqual $tapConfig.ResourceGroupName $rgname
        Assert-AreEqual $tapConfig.NetworkInterfaceName $sourceNicName
        Assert-AreEqual $tapConfig.Name $rname

        $tapConfigs = Get-AzNetworkInterfaceTapConfig -ResourceGroupName $rgname -NetworkInterfaceName $sourceNicName
        Assert-NotNull $tapConfigs

        $tapConfigs = Get-AzNetworkInterfaceTapConfig -ResourceGroupName $rgname -NetworkInterfaceName $sourceNicName -Name "*"
        Assert-NotNull $tapConfigs

        $tapConfig = Get-AzNetworkInterfaceTapConfig -ResourceId $tapConfig.Id
        Assert-NotNull $tapConfig
        Assert-AreEqual $tapConfig.ResourceGroupName $rgname
        Assert-AreEqual $tapConfig.NetworkInterfaceName $sourceNicName
        Assert-AreEqual $tapConfig.Name $rname

        # get nic and check back reference
        $sourceNic = Get-AzNetworkInterface -Name $sourceNicName -ResourceGroupName $rgname
        Assert-NotNull $sourceNic.TapConfigurations
        Assert-NotNull $sourceNic.TapConfigurations[0]
        Assert-AreEqual $sourceNic.TapConfigurations[0].Id $tapConfig.Id

        # get vtap and check back reference
        $vVirtualNetworkTap = Get-AzVirtualNetworkTap -ResourceGroupName $rgname -Name $vtapName;
        Assert-NotNull $vVirtualNetworkTap.NetworkInterfaceTapConfigurations
        Assert-NotNull $vVirtualNetworkTap.NetworkInterfaceTapConfigurations[0]
        Assert-AreEqual $vVirtualNetworkTap.NetworkInterfaceTapConfigurations[0].Id $tapConfig.Id

        # set tap configuration
        $job = Set-AzNetworkInterfaceTapConfig -NetworkInterfaceTapConfig $tapConfig -AsJob -Force
        $job | Wait-Job
        $tapConfig = $job | Receive-Job
        Assert-NotNull $tapConfig
        Assert-AreEqual $tapConfig.ResourceGroupName $rgname
        Assert-AreEqual $tapConfig.NetworkInterfaceName $sourceNicName
        Assert-AreEqual $tapConfig.Name $rname

        # Remove NetworkInterfaceTapConfiguration
        $removeNetworkInterfaceTapConfiguration = Remove-AzNetworkInterfaceTapConfig -ResourceGroupName $rgname -NetworkInterfaceName $sourceNicName -Name $rname -PassThru -Force;
        Assert-AreEqual $true $removeNetworkInterfaceTapConfiguration;

        $sourceNic = Get-AzNetworkInterface -Name $sourceNicName -ResourceGroupName $rgname
        Assert-NotNull $sourceNic.TapConfigurations
        Assert-Null $sourceNic.TapConfigurations[0]

        # get vtap and check back reference
        $vVirtualNetworkTap = Get-AzVirtualNetworkTap -ResourceGroupName $rgname -Name $vtapName;
        Assert-NotNull $vVirtualNetworkTap.NetworkInterfaceTapConfigurations
        Assert-Null $vVirtualNetworkTap.NetworkInterfaceTapConfigurations[0]

        # Get NetworkInterfaceTapConfiguration should fail
        Assert-ThrowsContains { Get-AzNetworkInterfaceTapConfig  -ResourceGroupName $rgname -NetworkInterfaceName $sourceNicName -Name $rname } "not found";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

function Get-NameById($Id, $ResourceType)
{
    $name = $Id.Substring($Id.IndexOf($ResourceType + '/') + $ResourceType.Length + 1);
    if ($name.IndexOf('/') -ne -1)
    {
        $name = $name.Substring(0, $name.IndexOf('/'));
    }
    return $name;
}

function Test-NetworkInterfaceVmss
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Compute/virtualMachineScaleSets"
    $location = Get-ProviderLocation $resourceTypeParent
    $lbName = Get-ResourceName

    try
    {
       # Create the resource group
       $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
       #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
       $secpasswd = ConvertTo-SecureString "Pa$$word2018" -AsPlainText -Force
       $mycreds = New-Object System.Management.Automation.PSCredential ("username", $secpasswd)

       $vmssName = "vmssip"
       $templateFile = (Resolve-Path ".\ScenarioTests\Data\VmssDeploymentTemplate.json").Path
       New-AzureRmResourceGroupDeployment -Name $rgname -ResourceGroupName $rgname -TemplateFile $templateFile;

       $listAllResults = Get-AzureRmNetworkInterface -ResourceGroupName $rgname -VirtualMachineScaleSetName $vmssName;
       Assert-NotNull $listAllResults;

       $listFirstResultId = $listAllResults[0].Id;
       $vmIndex = Get-NameById $listFirstResultId "virtualMachines";
       $nicName = Get-NameById $listFirstResultId "networkInterfaces";

       $listResults = Get-AzureRmNetworkInterface -ResourceGroupName $rgname -VirtualMachineScaleSetName $vmssName -VirtualmachineIndex $vmIndex;
       Assert-NotNull $listResults;
       Assert-AreEqualObjectProperties $listAllResults[0] $listResults[0] "List and list all results should contain equal items";

       $vmssNic = Get-AzureRmNetworkInterface -VirtualMachineScaleSetName $vmssName -ResourceGroupName $rgname -VirtualMachineIndex $vmIndex -Name $nicName;
       Assert-NotNull $vmssNic;
       Assert-AreEqualObjectProperties $vmssNic $listResults[0] "List and get results should contain equal items";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}

<#
.SYNOPSIS
Test that network interface can be put in an edge zone. Subscriptions need to be explicitly whitelisted for access to edge zones.
#>
function Test-NetworkInterfaceInEdgeZone
{
    $resourceGroup = Get-ResourceGroupName
    $locationName = "westus"
    $edgeZone = "microsoftlosangeles1"

    try
    {
        New-AzResourceGroup -Name $resourceGroup -Location $locationName -Force

        $networkName = "MyNet"
        $nicName = "MyNIC"
        $subnetName = "MySubnet"
        $subnetAddressPrefix = "10.0.0.0/24"
        $vnetAddressPrefix = "10.0.0.0/16"

        $singleSubnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix $subnetAddressPrefix
        $vnet = New-AzVirtualNetwork -Name $networkName -ResourceGroupName $resourceGroup -Location $locationName -EdgeZone $edgeZone -AddressPrefix $vnetAddressPrefix -Subnet $singleSubnet
        New-AzNetworkInterface -Name $nicName -ResourceGroupName $resourceGroup -Location $locationName -EdgeZone $edgeZone -SubnetId $vnet.Subnets[0].Id

		$nic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $resourceGroup
        Assert-AreEqual $nic.ExtendedLocation.Name $edgeZone
        Assert-AreEqual $nic.ExtendedLocation.Type "EdgeZone"
    }
    catch [Microsoft.Azure.Commands.Network.Common.NetworkCloudException]
    {
        Assert-NotNull { $_.Exception.Message -match 'Resource type .* does not support edge zone .* in location .* The supported edge zones are .*' }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $resourceGroup
    }
}

<#
.SYNOPSIS
Test that network interface can be put with AuxiliarySku. Subscriptions need to be explicitly whitelisted for access to AuxiliaryMode and AuxiliarySku properties.
#>
function Test-NetworkInterfaceWithAuxiliarySku
{
 # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "Central US EUAP"
    $resourceTypeParent = "Microsoft.Network/networkInterfaces"
    $location = Get-ProviderLocation $resourceTypeParent "Central US EUAP"
    $vmName = Get-ResourceName

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        
        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -DomainNameLabel $domainNameLabel

        # Create NetworkInterface
        $actualNic = New-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname -Location $location -Subnet $vnet.Subnets[0] -PublicIpAddress $publicip -EnableAcceleratedNetworking -AuxiliaryMode MaxConnections -AuxiliarySku A2 -Tag @{ fastpathenabled = "true"}
                
        $expectedNic = Get-AzNetworkInterface -Name $nicName -ResourceGroupName $rgname 

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $expectedNic.Name $actualNic.Name	
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-NotNull $expectedNic.ResourceGuid
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "MaxConnections" $actualNic.AuxiliaryMode
        Assert-AreEqual "A2" $actualNic.AuxiliarySku


        $expectedNic = Get-AzNetworkInterface -ResourceId $actualNic.Id

        Assert-AreEqual $expectedNic.ResourceGroupName $actualNic.ResourceGroupName
        Assert-AreEqual $expectedNic.Name $actualNic.Name
        Assert-AreEqual $expectedNic.Location $actualNic.Location
        Assert-NotNull $expectedNic.ResourceGuid
        Assert-AreEqual "Succeeded" $expectedNic.ProvisioningState
        Assert-AreEqual $expectedNic.IpConfigurations[0].Name $actualNic.IpConfigurations[0].Name
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $actualNic.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $actualNic.IpConfigurations[0].Subnet.Id
        Assert-NotNull $expectedNic.IpConfigurations[0].PrivateIpAddress
        Assert-AreEqual "MaxConnections" $actualNic.AuxiliaryMode
        Assert-AreEqual "A2" $actualNic.AuxiliarySku


        # Check publicIp address reference
        $publicip = Get-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName
        Assert-AreEqual $expectedNic.IpConfigurations[0].PublicIpAddress.Id $publicip.Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $publicip.IpConfiguration.Id

        # Check Subnet address reference
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual $expectedNic.IpConfigurations[0].Subnet.Id $vnet.Subnets[0].Id
        Assert-AreEqual $expectedNic.IpConfigurations[0].Id $vnet.Subnets[0].IpConfigurations[0].Id

        # list
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actualNic.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actualNic.Name	
        Assert-AreEqual $list[0].Location $actualNic.Location
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
        Assert-AreEqual $actualNic.Etag $list[0].Etag

        # Delete NetworkInterface
        $job = Remove-AzNetworkInterface -ResourceGroupName $rgname -name $nicName -PassThru -Force -AsJob
		$job | Wait-Job
		$delete = $job | Receive-Job
        Assert-AreEqual true $delete
        
        $list = Get-AzNetworkInterface -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
