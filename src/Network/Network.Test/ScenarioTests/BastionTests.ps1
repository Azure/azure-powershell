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
BastionCRUD
#>
function Test-BastionCRUD
{

   # Register-AzResourceProvider -ProviderNamespace "Microsoft.Network"
   # Setup
    $rgname = Get-ResourceGroupName
    $bastionName = Get-ResourceName
	$resourceTypeParent = "Microsoft.Network/bastionHosts"
    $location = Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "AzureBastionSubnet"
    $publicIpName = Get-ResourceName
    
	try
	{
		# Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location

		# Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

		# Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard
		
		# Create Bastion
        $bastion = New-AzBastion -ResourceGroupName $rgname –Name $bastionName -PublicIpAddressRgName $rgname -PublicIpAddressName $publicIpName -VirtualNetworkRgName $rgname -VirtualNetworkName $vnetName -Sku "Standard"

		# Get Bastion by Name
		$bastionObj = Get-AzBastion -ResourceGroupName $rgname -Name $bastionName
        Assert-NotNull $bastionObj

		#verification
        Assert-AreEqual $rgName $bastionObj.ResourceGroupName
        Assert-AreEqual $bastionName $bastionObj.Name
        Assert-NotNull $bastionObj.Etag
        Assert-AreEqual 1 @($bastionObj.IpConfigurations).Count
        Assert-NotNull $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet.Id $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $bastionObj.Sku.Name "Standard"
        Assert-AreEqual $bastionObj.ScaleUnit 2

		# Get Bastion by Id
		$bastionObj = Get-AzBastion -ResourceId $bastion.id
        Assert-NotNull $bastionObj

		#verification
        Assert-AreEqual $rgName $bastionObj.ResourceGroupName
        Assert-AreEqual $bastionName $bastionObj.Name
        Assert-NotNull $bastionObj.Etag
        Assert-AreEqual 1 @($bastionObj.IpConfigurations).Count
        Assert-NotNull $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet.Id $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $bastionObj.IpConfigurations[0].PublicIpAddress.Id

        # Update Bastion Scale Units
		$bastionObj = Set-AzBastion -InputObject $bastionObj -ScaleUnit 3 -Force

        # Verification
        Assert-NotNull $bastionObj
        Assert-AreEqual $bastionObj.Sku.Name "Standard"
        Assert-AreEqual $bastionObj.ScaleUnit 3

		# Get all Bastions in ResourceGroup
        $bastions = Get-AzBastion -ResourceGroupName $rgName
        Assert-NotNull $bastions

		# list all Azure Bastion under subscription
        $bastionsAll = Get-AzBastion
        Assert-NotNull $bastionsAll
       
	    # Delete Bastion
        $delete = Remove-AzBastion -ResourceGroupName $rgname -Name $bastionName -PassThru -Force
		Assert-AreEqual true $delete

		# Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

		$list = Get-AzBastion -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
	}
	finally
	{
		# Clean up
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
BastionVnetsIpObjectsParams
#>
function Test-BastionVnetsIpObjectsParams
{

   # Setup
    $rgname = Get-ResourceGroupName
    $bastionName = Get-ResourceName
	$resourceTypeParent = "Microsoft.Network/bastionHosts"
    $location = Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "AzureBastionSubnet"
    $publicIpName = Get-ResourceName
    
	try
	{
		# Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location

		# Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

		# Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard
		
		 # Create Bastion 
        $bastion = New-AzBastion -ResourceGroupName $rgname –Name $bastionName -PublicIpAddress $publicip -VirtualNetwork $vnet

		# Get Bastion by Name
		$bastionObj = Get-AzBastion -ResourceGroupName $rgname -Name $bastionName
        Assert-NotNull $bastionObj
		
		#verification
        Assert-AreEqual $rgName $bastionObj.ResourceGroupName
        Assert-AreEqual $bastionName $bastionObj.Name
        Assert-NotNull $bastionObj.Etag
        Assert-AreEqual 1 @($bastionObj.IpConfigurations).Count
        Assert-NotNull $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet.Id $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $bastionObj.IpConfigurations[0].PublicIpAddress.Id

		# Delete Bastion
        $delete = Remove-AzBastion -ResourceGroupName $rgname -Name $bastionName -PassThru -Force
		Assert-AreEqual true $delete

		# Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

		$list = Get-AzBastion -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
	}
	finally
	{
		# Clean up
		Clean-ResourceGroup $rgname
	}
}
<#
.SYNOPSIS
BastionVnetObjectParam
#>
function Test-BastionVnetObjectParam
{

   # Setup
    $rgname = Get-ResourceGroupName
    $bastionName = Get-ResourceName
	$resourceTypeParent = "Microsoft.Network/bastionHosts"
    $location = Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "AzureBastionSubnet"
    $publicIpName = Get-ResourceName
    
	try
	{
		# Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location

		# Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

		# Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard
		
		 # Create Bastion 
        $bastion = New-AzBastion -ResourceGroupName $rgname –Name $bastionName -PublicIpAddressRgName $rgname -PublicIpAddressName $publicIpName -VirtualNetwork $vnet

		# Get Bastion by Name
		$bastionObj = Get-AzBastion -ResourceGroupName $rgname -Name $bastionName
        Assert-NotNull $bastionObj
		
		#verification
        Assert-AreEqual $rgName $bastionObj.ResourceGroupName
        Assert-AreEqual $bastionName $bastionObj.Name
        Assert-NotNull $bastionObj.Etag
        Assert-AreEqual 1 @($bastionObj.IpConfigurations).Count
        Assert-NotNull $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet.Id $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $bastionObj.IpConfigurations[0].PublicIpAddress.Id

		# Delete Bastion by ResourceId
        $delete = Remove-AzBastion -InputObject $bastionObj -PassThru -Force
		Assert-AreEqual true $delete

		# Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

		$list = Get-AzBastion -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
	}
	finally
	{
		# Clean up
		Clean-ResourceGroup $rgname
	}
}
<#
.SYNOPSIS
BastionIpObjectParam
#>
function Test-BastionIpObjectParam
{

   # Setup
    $rgname = Get-ResourceGroupName
    $bastionName = Get-ResourceName
	$resourceTypeParent = "Microsoft.Network/bastionHosts"
    $location = Get-ProviderLocation $resourceTypeParent

    $vnetName = Get-ResourceName
    $subnetName = "AzureBastionSubnet"
    $publicIpName = Get-ResourceName
    
	try
	{
		# Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $location

		# Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        # Get full subnet details
        $subnet = Get-AzVirtualNetworkSubnetConfig -VirtualNetwork $vnet -Name $subnetName

		# Create public ip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIpName -location $location -AllocationMethod Static -Sku Standard
		
		 # Create Bastion 
        $bastion = New-AzBastion -ResourceGroupName $rgname –Name $bastionName -PublicIpAddress $publicip -VirtualNetworkRgName $rgname -VirtualNetworkName $vnetName

		# Get Bastion by Name
		$bastionObj = Get-AzBastion -ResourceGroupName $rgname -Name $bastionName
        Assert-NotNull $bastionObj
		
		#verification
        Assert-AreEqual $rgName $bastionObj.ResourceGroupName
        Assert-AreEqual $bastionName $bastionObj.Name
        Assert-NotNull $bastionObj.Etag
        Assert-AreEqual 1 @($bastionObj.IpConfigurations).Count
        Assert-NotNull $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-NotNull $bastionObj.IpConfigurations[0].PublicIpAddress.Id
        Assert-AreEqual $subnet.Id $bastionObj.IpConfigurations[0].Subnet.Id
        Assert-AreEqual $publicip.Id $bastionObj.IpConfigurations[0].PublicIpAddress.Id

		# Delete Bastion by ResourceId
        $delete = Remove-AzBastion -InputObject $bastionObj -PassThru -Force
		Assert-AreEqual true $delete

		# Delete VirtualNetwork 
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $delete

		$list = Get-AzBastion -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
	}
	finally
	{
		# Clean up
		Clean-ResourceGroup $rgname
	}
}
