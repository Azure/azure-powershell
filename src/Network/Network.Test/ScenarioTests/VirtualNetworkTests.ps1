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
.DESCRIPTION
SmokeTest
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $job = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8 -Subnet $subnet -AsJob
        $job | Wait-Job
        $actual = $job | Receive-Job
        $expected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        Assert-AreEqual $expected.ResourceGroupName $rgname    
        Assert-AreEqual $expected.Name $actual.Name    
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual "Succeeded" $expected.ProvisioningState
        Assert-NotNull $expected.ResourceGuid
        Assert-AreEqual "10.0.0.0/16" $expected.AddressSpace.AddressPrefixes[0]
        Assert-AreEqual 1 @($expected.DhcpOptions.DnsServers).Count
        Assert-AreEqual "8.8.8.8" $expected.DhcpOptions.DnsServers[0]
        Assert-AreEqual 1 @($expected.Subnets).Count
        Assert-AreEqual $subnetName $expected.Subnets[0].Name
        Assert-AreEqual "10.0.1.0/24" $expected.Subnets[0].AddressPrefix
        
        # List virtual Network
        $list = Get-AzVirtualNetwork -ResourceGroupName $rgname
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

        # Commented out due to known failures with listing items. 
        <# $listAll = Get-AzVirtualNetwork
        Assert-NotNull $listAll

        $listAll = Get-AzVirtualNetwork -ResourceGroupName "*"
        Assert-NotNull $listAll

        $listAll = Get-AzVirtualNetwork -Name "*"
        Assert-NotNull $listAll

        $listAll = Get-AzVirtualNetwork -ResourceGroupName "*" -Name "*"
        Assert-NotNull $listAll #>

        # Test virtual network private ip address - available - TestByResource
        $testResponse1 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Test-AzPrivateIPAddressAvailability -IPAddress "10.0.1.10"
        Assert-AreEqual true $testResponse1.Available

        # Test virtual network private ip address - not available - TestByResource
        $testResponse2 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Test-AzPrivateIPAddressAvailability -IPAddress "10.0.1.3"
        Assert-AreEqual false $testResponse2.Available
        Assert-AreEqual 5 @($testResponse2.AvailableIpAddresses).Count

        # Test virtual network private ip address - available - TestByResourceId
        $testResponse1 = Test-AzPrivateIPAddressAvailability -ResourceGroupName $rgname -VirtualNetworkName $vnetName -IPAddress "10.0.1.10"
        Assert-AreEqual true $testResponse1.Available

        # Test virtual network private ip address - not available - TestByResourceId
        $testResponse2 = Test-AzPrivateIPAddressAvailability -ResourceGroupName $rgname -VirtualNetworkName $vnetName -IPAddress "10.0.1.3"
        Assert-AreEqual false $testResponse2.Available
        Assert-AreEqual 5 @($testResponse2.AvailableIpAddresses).Count
        
        # Delete VirtualNetwork
        $job = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete
                
        $list = Get-AzVirtualNetwork -ResourceGroupName $rgname
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
.DESCRIPTION
SmokeTest
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        # Add a subnet
        $vnet | Add-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.2.0/24
        
        # Set VirtualNetwork
        $vnet | Set-AzVirtualNetwork
        
        # Get VirtualNetwork
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual "10.0.2.0/24" $vnetExpected.Subnets[1].AddressPrefix
        
        # Edit a subnet
        $job = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Set-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.3.0/24 | Set-AzVirtualNetwork -AsJob
        $job | Wait-Job

        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual "10.0.3.0/24" $vnetExpected.Subnets[1].AddressPrefix

        # Get subnet
        $subnet2 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnet2Name
        $subnetAll = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig
        $subnet2ById = Get-AzVirtualNetworkSubnetConfig -ResourceId $subnet2.Id

        Assert-AreEqual 2 @($subnetAll).Count
        Assert-AreEqual $subnetName $subnetAll[0].Name
        Assert-AreEqual $subnet2Name $subnetAll[1].Name
        Assert-AreEqual $subnet2Name $subnet2.Name
        Assert-AreEqual $subnet2Name $subnet2ById.Name

        # Get non-existing subnet
        try
        {
            $subnetNotExists = $vnetExpected | Get-AzVirtualNetworkSubnetConfig -Name "Subnet-DoesNotExist"
        }
        catch
        {
            if ($_.Exception.GetType() -ne [System.ArgumentException])
            {
                throw;
            }
        }

        # Remove a subnet
        Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Remove-AzVirtualNetworkSubnetConfig -Name $subnet2Name | Set-AzVirtualNetwork
        
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name        
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-VirtualNetworkCRUDWithIpamPool
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = "centraluseuap"
    $networkManagerName = Get-ResourceName
    $ipamPoolName = Get-ResourceName
    $rglocation = "centraluseuap"
    $subscriptionId = "/subscriptions/c9295b92-3574-4021-95a1-26c8f74f8359"
    $addressPrefixes  = @("10.0.0.0/8")
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create Scope
        $subscriptions  = @($subscriptionId)
        $scope = New-AzNetworkManagerScope -Subscription $subscriptions

        # Define access
        $access  = @("SecurityAdmin")

        # Create network manager
        New-AzNetworkManager -ResourceGroupName $rgName -Name $networkManagerName -NetworkManagerScope $scope -NetworkManagerScopeAccess $access -Location $rglocation

        # Create ipam pool
        New-AzNetworkManagerIpamPool -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $ipamPoolName -Location $rglocation -AddressPrefix $addressPrefixes
        $ipamPool = Get-AzNetworkManagerIpamPool -ResourceGroupName $rgName -NetworkManagerName $networkManagerName -Name $ipamPoolName
        Assert-NotNull $ipamPool;

        # Create the Virtual Network
        $ipamPoolPrefixAllocation = [PSCustomObject]@{
            Id = $ipamPool.Id
            NumberOfIpAddresses = "256"
        }

        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -IpamPoolPrefixAllocation $ipamPoolPrefixAllocation
        $job = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -IpamPoolPrefixAllocation $ipamPoolPrefixAllocation -Subnet $subnet -AsJob
        $job | Wait-Job
        $actual = $job | Receive-Job
        $expected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        Assert-AreEqual $expected.ResourceGroupName $rgname    
        Assert-AreEqual $expected.Name $actual.Name    
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual "Succeeded" $expected.ProvisioningState
        Assert-NotNull $expected.ResourceGuid
        Assert-AreEqual "10.0.0.0/24" $expected.AddressSpace.AddressPrefixes[0]
        Assert-AreEqual $expected.AddressSpace.IpamPoolPrefixAllocations.Count 1;
        Assert-AreEqual $expected.AddressSpace.IpamPoolPrefixAllocations[0].Id $ipamPool.Id;
        Assert-AreEqual $expected.AddressSpace.IpamPoolPrefixAllocations[0].NumberOfIpAddresses "256";

        Assert-AreEqual 1 @($expected.Subnets).Count
        Assert-AreEqual $subnetName $expected.Subnets[0].Name
        Assert-AreEqual "10.0.0.0/24" $expected.Subnets[0].AddressPrefix
        Assert-AreEqual $expected.Subnets[0].IpamPoolPrefixAllocations.Count 1;
        Assert-AreEqual $expected.Subnets[0].IpamPoolPrefixAllocations[0].Id $ipamPool.Id;
        Assert-AreEqual $expected.Subnets[0].IpamPoolPrefixAllocations[0].NumberOfIpAddresses "256";
        
        # Delete VirtualNetwork
        $job = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete
                
        $list = Get-AzVirtualNetwork -ResourceGroupName $rgname
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
.DESCRIPTION
SmokeTest
#>
function Test-subnetWithDefaultOutboundAccessCRUD
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24 -DefaultOutboundAccess $true
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        # Add a subnet
        $vnet | Add-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.2.0/24 -DefaultOutboundAccess $true
        
        # Set VirtualNetwork
        $vnet | Set-AzVirtualNetwork
        
        # Get VirtualNetwork
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual "10.0.2.0/24" $vnetExpected.Subnets[1].AddressPrefix
        Assert-AreEqual $true $vnetExpected.Subnets[0].DefaultOutboundAccess
        Assert-AreEqual $true $vnetExpected.Subnets[1].DefaultOutboundAccess

        Set-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnetExpected -DefaultOutboundAccess $false -AddressPrefix 10.0.1.0/24
        $vnetExpected | Set-AzVirtualNetwork

        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual "10.0.2.0/24" $vnetExpected.Subnets[1].AddressPrefix
        Assert-AreEqual $false $vnetExpected.Subnets[0].DefaultOutboundAccess
        Assert-AreEqual $true $vnetExpected.Subnets[1].DefaultOutboundAccess
        
        # Remove a subnet
        Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Remove-AzVirtualNetworkSubnetConfig -Name $subnet2Name | Set-AzVirtualNetwork
        
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name        
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating, updating & deleting a virtualNetwork with BGP Communities.
.DESCRIPTION
SmokeTest
#>
function Test-bgpCommunitiesCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnet1Name = Get-ResourceName
    $vnet2Name = Get-ResourceName
    $peering1Name = Get-ResourceName
    $peering2Name = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create two virtual networks with BGP communities
        New-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.1.0.0/16 -BgpCommunity 12076:20001
        New-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.2.0.0/16 -BgpCommunity 12076:20002

        # Perform GET operations to retrieve both virtual networks and verify that the VirtualNetworkCommunity is set to the expected value
        $vnet1 = Get-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname
        $vnet2 = Get-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname
        Assert-AreEqual "12076:20001" $vnet1.BgpCommunities.VirtualNetworkCommunity
        Assert-AreEqual "12076:20002" $vnet2.BgpCommunities.VirtualNetworkCommunity

        # Update the VirtualNetworkCommunity on both virtual networks
        $vnet1.BgpCommunities.VirtualNetworkCommunity = "12076:20111"
        $vnet2.BgpCommunities.VirtualNetworkCommunity = "12076:20222"
        $vnet1 | Set-AzVirtualNetwork
        $vnet2 | Set-AzVirtualNetwork

        # Perform GET operations to retrieve both virtual networks and verify that the VirtualNetworkCommunity is set to the expected value
        $vnet1 = Get-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname
        $vnet2 = Get-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname
        Assert-AreEqual "12076:20111" $vnet1.BgpCommunities.VirtualNetworkCommunity
        Assert-AreEqual "12076:20222" $vnet2.BgpCommunities.VirtualNetworkCommunity

        # Peer both virtual networks
        Add-AzVirtualNetworkPeering -Name $peering1Name -VirtualNetwork $vnet1 -RemoteVirtualNetworkId $vnet2.Id
        Add-AzVirtualNetworkPeering -Name $peering2Name -VirtualNetwork $vnet2 -RemoteVirtualNetworkId $vnet1.Id

        # Perform GET operations to retrieve both virtual networks and validate the RemoteBgpCommunity property on the child peering resource
        $vnet1 = Get-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname
        $vnet2 = Get-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname   
        Assert-AreEqual "12076:20222" $vnet1.VirtualNetworkPeerings[0].RemoteBgpCommunities.VirtualNetworkCommunity
        Assert-AreEqual "12076:20111" $vnet2.VirtualNetworkPeerings[0].RemoteBgpCommunities.VirtualNetworkCommunity
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new virtualNetwork w/ delegated subnets.
.DESCRIPTION
SmokeTest
#>
function Test-subnetDelegationCRUD
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create a delegation
        $delegation = New-AzDelegation -Name "sqlDelegation" -ServiceName "Microsoft.Sql/managedInstances"

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24 -delegation $delegation
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        # Add a subnet
        $vnet | Add-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.2.0/24
        
        # Set VirtualNetwork
        $vnet | Set-AzVirtualNetwork
        
        # Get VirtualNetwork
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual 1 @($vnetExpected.Subnets[0].Delegations).Count
        Assert-AreEqual 0 @($vnetExpected.Subnets[1].Delegations).Count
        
        # Edit a subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Set-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.2.0/24
		
		# Add a delegation to the subnet
		Get-AzVirtualNetworkSubnetConfig -Name $subnet2Name -VirtualNetwork $vnet | Add-AzDelegation -Name "bareMetalDelegation" -ServiceName "Microsoft.Netapp/volumes"
		Set-AzVirtualNetwork -VirtualNetwork $vnet

        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual 1 @($vnetExpected.Subnets[0].Delegations).Count
		Assert-AreEqual "Microsoft.Sql/managedInstances" $vnetExpected.Subnets[0].Delegations[0].ServiceName
        Assert-AreEqual 1 @($vnetExpected.Subnets[1].Delegations).Count
		Assert-AreEqual "Microsoft.Netapp/volumes" $vnetExpected.Subnets[1].Delegations[0].ServiceName

        # Get subnet
        $subnet2 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnet2Name
		Assert-AreEqual 1 @($subnet2.Delegations).Count
        $subnetAll = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig

        Assert-AreEqual 2 @($subnetAll).Count

		# Get delegations from the subnets
		Foreach ($sub in $subnetAll)
		{
			$del = Get-AzDelegation -Subnet $sub
			Assert-NotNull $del
		}

        # Remove a delegation
        $vnetToEdit = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
		$subnetWithoutDelegation = Get-AzVirtualNetworkSubnetConfig -Name $subnet2Name -VirtualNetwork $vnet | Remove-AzDelegation -Name "bareMetalDelegation"
		$vnetToEdit.Subnets[1] = $subnetWithoutDelegation
		$vnet = Set-AzVirtualNetwork -VirtualNetwork $vnetToEdit
        
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual 1 @($vnetExpected.Subnets[0].Delegations).Count
		Assert-AreEqual 0 @($vnetExpected.Subnets[1].Delegations).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new virtualNetwork w/ network security group associated and disassociated from subnets.
.DESCRIPTION
SmokeTest
#>
function Test-subnetNetworkSecurityGroupCRUD {
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnet1Name = Get-ResourceName
    $subnet2Name = Get-ResourceName
    $subnet3Name = Get-ResourceName
    $networkSecurityGroupName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create a network security group
        $networkSecurityGroup = New-AzNetworkSecurityGroup -Name $networkSecurityGroupName -ResourceGroupName $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnet1Name -AddressPrefix 10.0.1.0/24 -NetworkSecurityGroup $networkSecurityGroup
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        # Add subnets
        $vnet | Add-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.2.0/24
        $vnet | Add-AzVirtualNetworkSubnetConfig -Name $subnet3Name -AddressPrefix 10.0.3.0/24
        
        # Set VirtualNetwork
        $vnet | Set-AzVirtualNetwork
        
        # Get VirtualNetwork
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-AreEqual 3 $vnetExpected.Subnets.Count
        Assert-AreEqual $subnet1Name $vnetExpected.Subnets[0].Name
        Assert-AreEqual 1 $vnetExpected.Subnets[0].NetworkSecurityGroup.Count
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual 0 $vnetExpected.Subnets[1].NetworkSecurityGroup.Count
        Assert-AreEqual $subnet3Name $vnetExpected.Subnets[2].Name
        Assert-AreEqual 0 $vnetExpected.Subnets[2].NetworkSecurityGroup.Count

        # Associate a network security group to a subnet using the NetworkSecurityGroup parameter
        Set-AzVirtualNetworkSubnetConfig -Name $subnet2Name -VirtualNetwork $vnet -AddressPrefix 10.0.2.0/24 -NetworkSecurityGroup $networkSecurityGroup
        Set-AzVirtualNetwork -VirtualNetwork $vnet

        # Associate a network security group to a subnet using the NetworkSecurityGroupId parameter
        Set-AzVirtualNetworkSubnetConfig -Name $subnet3Name -VirtualNetwork $vnet -AddressPrefix 10.0.3.0/24 -NetworkSecurityGroupId $networkSecurityGroup.Id
        Set-AzVirtualNetwork -VirtualNetwork $vnet

        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 3 $vnetExpected.Subnets.Count
        Assert-AreEqual 1 $vnetExpected.Subnets[0].NetworkSecurityGroup.Count
        Assert-AreEqual $networkSecurityGroup.Id $vnetExpected.Subnets[0].NetworkSecurityGroup.Id
        Assert-AreEqual 1 $vnetExpected.Subnets[1].NetworkSecurityGroup.Count
        Assert-AreEqual $networkSecurityGroup.Id $vnetExpected.Subnets[1].NetworkSecurityGroup.Id
        Assert-AreEqual 1 ($vnetExpected.Subnets[2].NetworkSecurityGroup).Count
        Assert-AreEqual $networkSecurityGroup.Id $vnetExpected.Subnets[2].NetworkSecurityGroup.Id

        # Get subnets
        $subnet1 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnet1Name
        Assert-AreEqual 1 $subnet1.NetworkSecurityGroup.Count
        $subnet2 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnet2Name
        Assert-AreEqual 1 $subnet2.NetworkSecurityGroup.Count
        $subnet3 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnet3Name
        Assert-AreEqual 1 $subnet3.NetworkSecurityGroup.Count
        $subnetAll = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig

        Assert-AreEqual 3 $subnetAll.Count

        # Disassociate a network security group with the NetworkSecurityGroup parameter as $null
        Set-AzVirtualNetworkSubnetConfig -Name $subnet1Name -VirtualNetwork $vnet -AddressPrefix 10.0.1.0/24 -NetworkSecurityGroup $null
        Set-AzVirtualNetwork -VirtualNetwork $vnet

        # Disassociate a network security group with the NetworkSecurityGroupId parameter as $null
        Set-AzVirtualNetworkSubnetConfig -Name $subnet2Name -VirtualNetwork $vnet -AddressPrefix 10.0.2.0/24 -NetworkSecurityGroupId $null
        Set-AzVirtualNetwork -VirtualNetwork $vnet

        # Disassociate a network security group with the NetworkSecurityGroupId parameter as an empty string
        Set-AzVirtualNetworkSubnetConfig -Name $subnet3Name -VirtualNetwork $vnet -AddressPrefix 10.0.3.0/24 -NetworkSecurityGroupId ""
        Set-AzVirtualNetwork -VirtualNetwork $vnet
        
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 3 $vnetExpected.Subnets.Count
        Assert-AreEqual 0 $vnetExpected.Subnets[0].NetworkSecurityGroup.Count
        Assert-AreEqual 0 $vnetExpected.Subnets[1].NetworkSecurityGroup.Count
        Assert-AreEqual 0 $vnetExpected.Subnets[2].NetworkSecurityGroup.Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new virtualNetwork w/ route table associated and disassoicated from subnets.
.DESCRIPTION
SmokeTest
#>
function Test-subnetRouteTableCRUD {
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnet1Name = Get-ResourceName
    $subnet2Name = Get-ResourceName
    $subnet3Name = Get-ResourceName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create a route table
        $routeTable = New-AzRouteTable -Name $routeTableName -ResourceGroupName $rgname -Location $location

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnet1Name -AddressPrefix 10.0.1.0/24 -RouteTable $routeTable
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        # Add subnets
        $vnet | Add-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.2.0/24
        $vnet | Add-AzVirtualNetworkSubnetConfig -Name $subnet3Name -AddressPrefix 10.0.3.0/24
        
        # Set VirtualNetwork
        $vnet | Set-AzVirtualNetwork
        
        # Get VirtualNetwork
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-AreEqual 3 $vnetExpected.Subnets.Count
        Assert-AreEqual $subnet1Name $vnetExpected.Subnets[0].Name
        Assert-AreEqual 1 $vnetExpected.Subnets[0].RouteTable.Count
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual 0 $vnetExpected.Subnets[1].RouteTable.Count
        Assert-AreEqual $subnet3Name $vnetExpected.Subnets[2].Name
        Assert-AreEqual 0 $vnetExpected.Subnets[2].RouteTable.Count

        # Associate a route table to a subnet using the RouteTable parameter
        Set-AzVirtualNetworkSubnetConfig -Name $subnet2Name -VirtualNetwork $vnet -AddressPrefix 10.0.2.0/24 -RouteTable $routeTable
        Set-AzVirtualNetwork -VirtualNetwork $vnet

        # Associate a route table to a subnet using the RouteTableId parameter
        Set-AzVirtualNetworkSubnetConfig -Name $subnet3Name -VirtualNetwork $vnet -AddressPrefix 10.0.3.0/24 -RouteTableId $routeTable.Id
        Set-AzVirtualNetwork -VirtualNetwork $vnet

        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 3 $vnetExpected.Subnets.Count
        Assert-AreEqual 1 $vnetExpected.Subnets[0].RouteTable.Count
        Assert-AreEqual $routeTable.Id $vnetExpected.Subnets[0].RouteTable.Id
        Assert-AreEqual 1 $vnetExpected.Subnets[1].RouteTable.Count
        Assert-AreEqual $routeTable.Id $vnetExpected.Subnets[1].RouteTable.Id
        Assert-AreEqual 1 $vnetExpected.Subnets[2].RouteTable.Count
        Assert-AreEqual $routeTable.Id $vnetExpected.Subnets[2].RouteTable.Id

        # Get subnets
        $subnet1 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnet1Name
        Assert-AreEqual 1 $subnet1.RouteTable.Count
        $subnet2 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnet2Name
        Assert-AreEqual 1 $subnet2.RouteTable.Count
        $subnet3 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnet3Name
        Assert-AreEqual 1 $subnet3.RouteTable.Count
        $subnetAll = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig

        Assert-AreEqual 3 $subnetAll.Count

        # Disassociate a route table with the RouteTable parameter as $null
        Set-AzVirtualNetworkSubnetConfig -Name $subnet1Name -VirtualNetwork $vnet -AddressPrefix 10.0.1.0/24 -RouteTable $null
        $vnet = Set-AzVirtualNetwork -VirtualNetwork $vnet

        # Disassociate a route table with the RouteTableId parameter as $null
        Set-AzVirtualNetworkSubnetConfig -Name $subnet2Name -VirtualNetwork $vnet -AddressPrefix 10.0.2.0/24 -RouteTableId $null
        Set-AzVirtualNetwork -VirtualNetwork $vnet

        # Disassociate a route table with the RouteTableId parameter as an empty string
        Set-AzVirtualNetworkSubnetConfig -Name $subnet3Name -VirtualNetwork $vnet -AddressPrefix 10.0.3.0/24 -RouteTableId ""
        Set-AzVirtualNetwork -VirtualNetwork $vnet
        
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 3 $vnetExpected.Subnets.Count
        Assert-AreEqual 0 $vnetExpected.Subnets[0].RouteTable.Count
        Assert-AreEqual 0 $vnetExpected.Subnets[1].RouteTable.Count
        Assert-AreEqual 0 $vnetExpected.Subnets[2].RouteTable.Count
    }
    finally {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple virtualNetwork and subnets.
.DESCRIPTION
SmokeTest
#>
function Test-multiPrefixSubnetCRUD
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/28,10.0.2.0/28
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        # Add a subnet
        $vnet | Add-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.3.0/28,10.0.4.0/28
        
        # Set VirtualNetwork
        $vnet | Set-AzVirtualNetwork
        
        # Get VirtualNetwork
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual "10.0.1.0/28 10.0.2.0/28" $vnetExpected.Subnets[0].AddressPrefix
        Assert-AreEqual "10.0.3.0/28 10.0.4.0/28" $vnetExpected.Subnets[1].AddressPrefix
        
        # Edit a subnet
        $job = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Set-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.5.0/28,10.0.6.0/28 | Set-AzVirtualNetwork -AsJob
        $job | Wait-Job

        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual "10.0.5.0/28 10.0.6.0/28" $vnetExpected.Subnets[1].AddressPrefix

        # Get subnet
        $subnet2 = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnet2Name
        $subnetAll = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig

        Assert-AreEqual 2 @($subnetAll).Count
        Assert-AreEqual $subnetName $subnetAll[0].Name
        Assert-AreEqual $subnet2Name $subnetAll[1].Name
        Assert-AreEqual $subnet2Name $subnet2.Name

        # Get non-existing subnet
        try
        {
            $subnetNotExists = $vnetExpected | Get-AzVirtualNetworkSubnetConfig -Name "Subnet-DoesNotExist"
        }
        catch
        {
            if ($_.Exception.GetType() -ne [System.ArgumentException])
            {
                throw;
            }
        }

        # Remove a subnet
        Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Remove-AzVirtualNetworkSubnetConfig -Name $subnet2Name | Set-AzVirtualNetwork
        
        $vnetExpected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name        
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests the creation of a new virtual network with DDoS protection parameters.
#>
function Test-VirtualNetworkCRUDWithDDoSProtection
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $ddosProtectionPlanName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent

    try 
    {
        # Create the resource group

        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create a DDoS Protection plan

        $ddosProtectionPlan = New-AzDdosProtectionPlan -Name $ddosProtectionPlanName -ResourceGroupName $rgname -Location $location

        # Create the Virtual Network

        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $actual = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8 -Subnet $subnet -EnableDdoSProtection -DdosProtectionPlanId $ddosProtectionPlan.Id
        $expected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-AreEqual $expected.ResourceGroupName $rgname
        Assert-AreEqual $expected.Name $actual.Name
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual "Succeeded" $expected.ProvisioningState
        Assert-NotNull $expected.ResourceGuid
        Assert-AreEqual "10.0.0.0/16" $expected.AddressSpace.AddressPrefixes[0]
        Assert-AreEqual 1 @($expected.DhcpOptions.DnsServers).Count
        Assert-AreEqual "8.8.8.8" $expected.DhcpOptions.DnsServers[0]
        Assert-AreEqual 1 @($expected.Subnets).Count
        Assert-AreEqual $subnetName $expected.Subnets[0].Name
        Assert-AreEqual "10.0.1.0/24" $expected.Subnets[0].AddressPrefix
        Assert-AreEqual true $expected.EnableDDoSProtection
        Assert-AreEqual $ddosProtectionPlan.Id $expected.DdosProtectionPlan.Id
        
        $expected.EnableDDoSProtection = $false
        $expected.DdosProtectionPlan = $null
        Set-AzVirtualNetwork -VirtualNetwork $expected
        $expected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual false $expected.EnableDDoSProtection
        Assert-AreEqual $null $expected.DdosProtectionPlan
       
        $expected.DdosProtectionPlan = New-Object Microsoft.Azure.Commands.Network.Models.PSResourceId
        $expected.DdosProtectionPlan.Id = $ddosProtectionPlan.Id
        Set-AzVirtualNetwork -VirtualNetwork $expected
        $expected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual false $expected.EnableDDoSProtection
        Assert-AreEqual $ddosProtectionPlan.Id $expected.DdosProtectionPlan.Id

        # Delete the virtual network

        $deleteVnet = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $deleteVnet

        # Delete the DDoS protection plan

        $deleteDdosProtectionPlan = Remove-AzDdosProtectionPlan -ResourceGroupName $rgname -name $ddosProtectionPlanName -PassThru
        Assert-AreEqual true $deleteDdosProtectionPlan
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests on CRUD for virtualNetworkpeering.
#>
function Test-VirtualNetworkPeeringCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $peerName = Get-ResourceName
    $vnet1Name = Get-ResourceName
    $vnet2Name = Get-ResourceName
    $subnet1Name = Get-ResourceName
    $subnet2Name = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network1
        $subnet1 = New-AzVirtualNetworkSubnetConfig -Name $subnet1Name -AddressPrefix 10.0.0.0/24
        $vnet1 = New-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet1


        Assert-AreEqual $vnet1.ResourceGroupName $rgname    
        Assert-AreEqual $vnet1.Name $vnet1Name    
        Assert-AreEqual $vnet1.Location $rglocation
        Assert-AreEqual "Succeeded" $vnet1.ProvisioningState        
        Assert-AreEqual $vnet1.Subnets[0].Name $subnet1.Name

        # Create the Virtual Network2
        $subnet2 = New-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.1.1.0/24
        $vnet2 = New-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.1.0.0/16 -Subnet $subnet2

        Assert-AreEqual $vnet2.ResourceGroupName $rgname    
        Assert-AreEqual $vnet2.Name $vnet2Name    
        Assert-AreEqual $vnet2.Location $rglocation
        Assert-AreEqual "Succeeded" $vnet2.ProvisioningState 

        # Add Peering to vnet1
        $job = $vnet1 | Add-AzVirtualNetworkPeering -name $peerName -RemoteVirtualNetworkId $vnet2.Id -AllowForwardedTraffic -AsJob
        $job | Wait-Job
        $peer = $job | Receive-Job
        
        Assert-AreEqual $peer.ResourceGroupName $rgname    
        Assert-AreEqual $peer.Name $peerName    
        Assert-AreEqual $peer.VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $peer.ProvisioningState 
        Assert-AreEqual $peer.RemoteVirtualNetwork.Id $vnet2.Id
        Assert-AreEqual $peer.AllowVirtualNetworkAccess True
        Assert-AreEqual $peer.AllowForwardedTraffic True
        Assert-Null $peer.RemoteGateways
        Assert-Null $peer.$peer.RemoteVirtualNetworkAddressSpace
        
        # Get peer
        $getPeer = Get-AzVirtualNetworkPeering -name $peerName -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname
        
        Assert-AreEqual $getPeer.ResourceGroupName $rgname    
        Assert-AreEqual $getPeer.Name $peerName    
        Assert-AreEqual $getPeer.VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $getPeer.ProvisioningState 
        Assert-AreEqual $getPeer.RemoteVirtualNetwork.Id $vnet2.Id
        Assert-AreEqual $getPeer.AllowVirtualNetworkAccess True
        Assert-AreEqual $getPeer.AllowForwardedTraffic True
        Assert-AreEqual $peer.AllowGatewayTransit $false
        Assert-AreEqual $peer.UseRemoteGateways $false
        Assert-Null $getPeer.RemoteGateways
        Assert-Null $getPeer.$peer.RemoteVirtualNetworkAddressSpace
        
        # List Peer
        $listPeer = Get-AzVirtualNetworkPeering -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname
        
        Assert-AreEqual 1 @($listPeer).Count
        Assert-AreEqual $listPeer[0].ResourceGroupName $rgname    
        Assert-AreEqual $listPeer[0].Name $peerName    
        Assert-AreEqual $listPeer[0].VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $listPeer[0].ProvisioningState 
        Assert-AreEqual $listPeer[0].RemoteVirtualNetwork.Id $vnet2.Id
        Assert-AreEqual $listPeer[0].AllowVirtualNetworkAccess True
        Assert-AreEqual $listPeer[0].AllowForwardedTraffic True
        Assert-AreEqual $listPeer[0].AllowGatewayTransit $false
        Assert-AreEqual $listPeer[0].UseRemoteGateways $false
        Assert-Null $listPeer[0].RemoteGateways
        Assert-Null $listPeer[0].$peer.RemoteVirtualNetworkAddressSpace

        # List Peer
        $listPeer = Get-AzVirtualNetworkPeering -Name "*" -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname
        
        Assert-AreEqual 1 @($listPeer).Count
        Assert-AreEqual $listPeer[0].ResourceGroupName $rgname    
        Assert-AreEqual $listPeer[0].Name $peerName    
        Assert-AreEqual $listPeer[0].VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $listPeer[0].ProvisioningState 
        Assert-AreEqual $listPeer[0].RemoteVirtualNetwork.Id $vnet2.Id
        Assert-AreEqual $listPeer[0].AllowVirtualNetworkAccess True
        Assert-AreEqual $listPeer[0].AllowForwardedTraffic True
        Assert-AreEqual $listPeer[0].AllowGatewayTransit $false
        Assert-AreEqual $listPeer[0].UseRemoteGateways $false
        Assert-Null $listPeer[0].RemoteGateways
        Assert-Null $listPeer[0].$peer.RemoteVirtualNetworkAddressSpace
        
        # Set Peer
        $getPeer.AllowForwardedTraffic = $false
        
        $job = $getPeer | Set-AzVirtualNetworkPeering -AsJob
        $job | Wait-Job
        $setPeer = $job | Receive-Job
        
        Assert-AreEqual $setPeer.ResourceGroupName $rgname    
        Assert-AreEqual $setPeer.Name $peerName    
        Assert-AreEqual $setPeer.VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $setPeer.ProvisioningState 
        Assert-AreEqual $setPeer.RemoteVirtualNetwork.Id $vnet2.Id
        Assert-AreEqual $setPeer.AllowVirtualNetworkAccess True
        Assert-AreEqual $setPeer.AllowForwardedTraffic $false
        Assert-AreEqual $setPeer.AllowGatewayTransit $false
        Assert-AreEqual $setPeer.UseRemoteGateways $false
        Assert-Null $setPeer.RemoteGateways
        Assert-Null $setPeer.$peer.RemoteVirtualNetworkAddressSpace
        
        # Delete Peer
        $job = Remove-AzVirtualNetworkPeering -name $peerName -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname -Force -PassThru -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete

        # Delete VirtualNetwork
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnet1Name -PassThru -Force
        Assert-AreEqual true $delete

        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnet2Name -PassThru -Force
        Assert-AreEqual true $delete
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests on CRUD for virtualNetworkpeering.
#>
function Test-MultiTenantVNetPCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $peerName = Get-ResourceName
    $vnet1Name = Get-ResourceName
    $vnet2Id = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/paryTestRG/providers/Microsoft.Network/virtualNetworks/myVirtualNetwork1"
    $subnet1Name = Get-ResourceName
    $subnet2Name = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "East US"
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent "East US"

	# The remote VNet in this case lives under a different tenant and hence can is assumed to be created by the time the test is run
	# Create the remote Virtual Network : This needs to e done ins a separate subscription that lives under a different tenant
	# As of now the steps are manual

    # $subnet2 = New-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.1.1.0/24
    # $vnet2 = New-AzVirtualNetwork -Name myVirtualNetwork1 -ResourceGroupName $rgname -Location eastus -AddressPrefix 10.1.0.0/16 -Subnet $subnet2

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network1
        $subnet1 = New-AzVirtualNetworkSubnetConfig -Name $subnet1Name -AddressPrefix 10.0.0.0/24
        $vnet1 = New-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet2
                
        Assert-AreEqual $vnet1.ResourceGroupName $rgname    
        Assert-AreEqual $vnet1.Name $vnet1Name    
        Assert-AreEqual $vnet1.Location $rglocation
        Assert-AreEqual "Succeeded" $vnet1.ProvisioningState        
       

        # Add Peering to vnet1
        $job = $vnet1 | Add-AzVirtualNetworkPeering -name $peerName -RemoteVirtualNetworkId $vnet2Id -AllowForwardedTraffic -AsJob
        $job | Wait-Job
        $peer = $job | Receive-Job
        
        Assert-AreEqual $peer.ResourceGroupName $rgname    
        Assert-AreEqual $peer.Name $peerName    
        Assert-AreEqual $peer.VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $peer.ProvisioningState 
        Assert-AreEqual $peer.RemoteVirtualNetwork.Id $vnet2.Id
        Assert-AreEqual $peer.AllowVirtualNetworkAccess True
        Assert-AreEqual $peer.AllowForwardedTraffic True
        Assert-Null $peer.RemoteGateways
        Assert-Null $peer.$peer.RemoteVirtualNetworkAddressSpace
        
        # Get peer
        $getPeer = Get-AzVirtualNetworkPeering -name $peerName -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname
        
        Assert-AreEqual $getPeer.ResourceGroupName $rgname    
        Assert-AreEqual $getPeer.Name $peerName    
        Assert-AreEqual $getPeer.VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $getPeer.ProvisioningState 
        Assert-AreEqual $getPeer.RemoteVirtualNetwork.Id $vnet2.Id
        Assert-AreEqual $getPeer.AllowVirtualNetworkAccess True
        Assert-AreEqual $getPeer.AllowForwardedTraffic True
        Assert-AreEqual $peer.AllowGatewayTransit $false
        Assert-AreEqual $peer.UseRemoteGateways $false
        Assert-Null $getPeer.RemoteGateways
        Assert-Null $getPeer.$peer.RemoteVirtualNetworkAddressSpace
        
        # List Peer
        $listPeer = Get-AzVirtualNetworkPeering -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname
        
        Assert-AreEqual 1 @($listPeer).Count
        Assert-AreEqual $listPeer[0].ResourceGroupName $rgname    
        Assert-AreEqual $listPeer[0].Name $peerName    
        Assert-AreEqual $listPeer[0].VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $listPeer[0].ProvisioningState 
        Assert-AreEqual $listPeer[0].RemoteVirtualNetwork.Id $vnet2.Id
        Assert-AreEqual $listPeer[0].AllowVirtualNetworkAccess True
        Assert-AreEqual $listPeer[0].AllowForwardedTraffic True
        Assert-AreEqual $listPeer[0].AllowGatewayTransit $false
        Assert-AreEqual $listPeer[0].UseRemoteGateways $false
        Assert-Null $listPeer[0].RemoteGateways
        Assert-Null $listPeer[0].$peer.RemoteVirtualNetworkAddressSpace
        
        # Set Peer
        $getPeer.AllowForwardedTraffic = $false
        
        $job = $getPeer | Set-AzVirtualNetworkPeering -AsJob
        $job | Wait-Job
        $setPeer = $job | Receive-Job
        
        Assert-AreEqual $setPeer.ResourceGroupName $rgname    
        Assert-AreEqual $setPeer.Name $peerName    
        Assert-AreEqual $setPeer.VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $setPeer.ProvisioningState 
        Assert-AreEqual $setPeer.RemoteVirtualNetwork.Id $vnet2.Id
        Assert-AreEqual $setPeer.AllowVirtualNetworkAccess True
        Assert-AreEqual $setPeer.AllowForwardedTraffic $false
        Assert-AreEqual $setPeer.AllowGatewayTransit $false
        Assert-AreEqual $setPeer.UseRemoteGateways $false
        Assert-Null $setPeer.RemoteGateways
        Assert-Null $setPeer.$peer.RemoteVirtualNetworkAddressSpace
        
        # Delete Peer
        $job = Remove-AzVirtualNetworkPeering -name $peerName -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname -Force -PassThru -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete

        # Delete VirtualNetwork
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnet1Name -PassThru -Force
        Assert-AreEqual true $delete

		# Delete VNet2 in the remote tenant
        # $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnet2Name -PassThru -Force
        # Assert-AreEqual true $delete
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests on CRUD for resource navigation links on subnets.
#>
function Test-ResourceNavigationLinksCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $cacheName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "West US"
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
                
        Assert-AreEqual $vnet.ResourceGroupName $rgname    
        Assert-AreEqual $vnet.Name $vnetName    
        Assert-AreEqual $vnet.Location $rglocation
        Assert-AreEqual "Succeeded" $vnet.ProvisioningState

        $subnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnetName
        Assert-AreEqual 0 @($subnet.ResourceNavigationLinks).Count

        # Create redis-cache
        $cacheCreated = New-AzRedisCache -ResourceGroupName $rgname -Name $cacheName -Location $location -Size P1 -Sku Premium -SubnetId $subnet.Id

        # In loop to check if cache exists
        for ($i = 0; $i -le 60; $i++)
        {
            Start-TestSleep -Seconds 30
            $cacheGet = Get-AzRedisCache -ResourceGroupName $rgname -Name $cacheName
            if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
            {
                break
            }
            Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
        }

        # Get redis-cache
        $cache = Get-AzRedisCache -ResourceGroupName $rgname -Name $cacheName

        # Get subnet and check resource navigation links
        $subnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzVirtualNetworkSubnetConfig -Name $subnetName
        Assert-AreEqual 1 @($subnet.ResourceNavigationLinks).Count
        Assert-AreEqual $cache.Id $subnet.ResourceNavigationLinks[0].Link
        Assert-AreEqual "Microsoft.Cache/redis" $subnet.ResourceNavigationLinks[0].LinkedResourceType
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests checking Virtual Network Usage feature.
.DESCRIPTION
SmokeTest
#>
function Test-VirtualNetworkUsage
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $subnet2Name = Get-ResourceName
    $nicName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-NotNull $vnet;
        Assert-NotNull $vnet.Subnets;

        $subnetId = $vnet.Subnets[0].Id;

        $usage = Get-AzVirtualNetworkUsageList -ResourceGroupName $rgname -Name $vnetName;

        Assert-NotNull $usage;
        $currentUsage = $usage.CurrentValue;

        # Add Network Interface to change usage current value
        New-AzNetworkInterface -Location $location -Name $nicName -ResourceGroupName $rgname -SubnetId $subnetId;
        $usage = Get-AzVirtualNetworkUsageList -ResourceGroupName $rgname -Name $vnetName;
        $currentUsageNew = $usage.CurrentValue;

        Assert-AreEqual $currentUsage $($currentUsageNew - 1);
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests checking Virtual Network Subnet Service Endpoint feature.
#>
function Test-VirtualNetworkSubnetServiceEndpoint
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    $serviceEndpoint = "Microsoft.Storage"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" };

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $serviceEndpoint;
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname;

        Assert-NotNull $vnet;
        Assert-NotNull $vnet.Subnets;

        $subnet = $vnet.Subnets[0];
        Assert-AreEqual $serviceEndpoint $subnet.serviceEndpoints[0].Service;

        Set-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $null;
        $vnet = Set-AzVirtualNetwork -VirtualNetwork $vnet;
        $subnet = $vnet.Subnets[0];

        Assert-Null $subnet.serviceEndpoints;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests checking Virtual Network Subnet Service Endpoint feature With NetworkIdentifier.
#>
function Test-VirtualNetworkSubnetServiceEndpointWithNetworkIdentifier
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    $publicIPAddressName = "PublicIPAddressName";
    $publicIPAddressAllocationMethod = "Static";
    $serviceEndpoint = "Microsoft.Storage"
    
    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" };

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIPAddressName -location $location -AllocationMethod $publicIPAddressAllocationMethod    

        # Create the $networkIdentifier
        $networkIdentifier = @{ Id = $publicip.Id };
        
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $serviceEndpoint -NetworkIdentifier $networkIdentifier ;
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname;

        Assert-NotNull $vnet;
        Assert-NotNull $vnet.Subnets;

        $subnet = $vnet.Subnets[0];
        Assert-AreEqual $serviceEndpoint $subnet.serviceEndpoints[0].Service;
        Assert-AreEqual $networkIdentifier.Id $subnet.serviceEndpoints[0].networkIdentifier.Id;

        
        Set-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $null;
        $vnet = Set-AzVirtualNetwork -VirtualNetwork $vnet;
        $subnet = $vnet.Subnets[0];

        Assert-Null $subnet.serviceEndpoints;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests checking Virtual Network Subnet Service Endpoint feature With NetworkIdentifier using ServiceEndpointConfig .
#>
function Test-VirtualNetworkSubnetServiceEndpointConfig
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    $publicIPAddressName = "PublicIPAddressName";
    $publicIPAddressAllocationMethod = "Static";
    $serviceEndpoint = "Microsoft.Storage"
    
    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" };

        # Create the publicip
        $publicip = New-AzPublicIpAddress -ResourceGroupName $rgname -name $publicIPAddressName -location $location -AllocationMethod $publicIPAddressAllocationMethod    

        # Create the $networkIdentifier
        $networkIdentifier = @{ Id = $publicip.Id };
        $serviceEndpointConfig = @( @{ Service = $ServiceEndpointServiceName; NetworkIdentifier = $NetworkIdentifier }) 
    
        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24 -ServiceEndpointConfig $serviceEndpointConfig -NetworkIdentifier $networkIdentifier ;
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname;

        Assert-NotNull $vnet;
        Assert-NotNull $vnet.Subnets;

        $subnet = $vnet.Subnets[0];
        Assert-AreEqual $serviceEndpoint $subnet.serviceEndpoints[0].Service;
        Assert-AreEqual $networkIdentifier.Id $subnet.serviceEndpoints[0].networkIdentifier.Id;

        
        Set-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $null;
        $vnet = Set-AzVirtualNetwork -VirtualNetwork $vnet;
        $subnet = $vnet.Subnets[0];

        Assert-Null $subnet.serviceEndpoints;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests checking Virtual Network Subnet Service Endpoint Policies.
#>
function Test-VirtualNetworkSubnetServiceEndpointPolicies
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    $serviceEndpoint = "Microsoft.Storage"
    $serviceEndpointPolicyDefinitionName = "ServiceEndpointPolicyDefinition1"
	$serviceEndpointPolicyDefinitionDescription = "New Policy"
    $serviceEndpointPolicyDefinitionDescription2 = "One more policy"
    $updatedDescription = "Updated"
    $serviceEndpointPolicyName = "ServiceEndpointPolicy1"
    $serviceEndpointPolicyDefinitionName2 = Get-ResourceName
    $serviceEndpointPolicyDefinitionResourceName = "/subscriptions/subid1/resourceGroups/storageRg/providers/Microsoft.Storage/storageAccounts/stAccount"
	$provisioningStateSucceeded = "Succeeded"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" };

        # Create the Virtual Network
        $serviceEndpointDefinition = New-AzServiceEndpointPolicyDefinition -Name $serviceEndpointPolicyDefinitionName -Service $serviceEndpoint -ServiceResource $serviceEndpointPolicyDefinitionResourceName -Description $serviceEndpointPolicyDefinitionDescription;
        $serviceEndpointPolicy = New-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ServiceEndpointPolicyDefinition $serviceEndpointDefinition -ResourceGroupName $rgname -Location $rglocation;

        # Overwrite with the same values
        $serviceEndpointPolicy = New-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ServiceEndpointPolicyDefinition $serviceEndpointDefinition -ResourceGroupName $rgname -Location $rglocation -Force;

        $getserviceEndpointPolicy = Get-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ResourceGroupName $rgname;

        Assert-AreEqual $getserviceEndpointPolicy[0].Name $serviceEndpointPolicyName;
        Assert-AreEqual $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Service $serviceEndpoint;
        Assert-AreEqual $serviceEndpointPolicyDefinitionName $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Name;
        Assert-AreEqual $serviceEndpointPolicyDefinitionDescription $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Description;
        Assert-AreEqual $serviceEndpointPolicyDefinitionResourceName $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].ServiceResources[0];
        Assert-AreEqual $getserviceEndpointPolicy[0].ProvisioningState $provisioningStateSucceeded;

        $getserviceEndpointPolicyDefinition = Get-AzServiceEndpointPolicyDefinition -Name $serviceEndpointPolicyDefinitionName -ServiceEndpointPolicy $getserviceEndpointPolicy

        Assert-AreEqual $getserviceEndpointPolicyDefinition[0].Name $serviceEndpointPolicyDefinitionName;
        Assert-AreEqual $getserviceEndpointPolicyDefinition[0].ProvisioningState $provisioningStateSucceeded;
        Assert-AreEqual $getserviceEndpointPolicyDefinition[0].ServiceResources[0] $serviceEndpointPolicyDefinitionResourceName;
        Assert-AreEqual $getserviceEndpointPolicyDefinition[0].Service $serviceEndpoint;

        $getserviceEndpointPolicyDefinitionList = Get-AzServiceEndpointPolicyDefinition -ServiceEndpointPolicy $getserviceEndpointPolicy;
        Assert-NotNull $getserviceEndpointPolicyDefinitionList;

        $getserviceEndpointPolicyList = Get-AzServiceEndpointPolicy -ResourceGroupName $rgname;
        Assert-NotNull $getserviceEndpointPolicyList;

        $getserviceEndpointPolicyListAll = Get-AzServiceEndpointPolicy;
        Assert-NotNull $getserviceEndpointPolicyListAll;

        $getserviceEndpointPolicyListAll = Get-AzServiceEndpointPolicy -ResourceGroupName "*"
        Assert-NotNull $getserviceEndpointPolicyListAll;

        $getserviceEndpointPolicyListAll = Get-AzServiceEndpointPolicy -Name "*"
        Assert-NotNull $getserviceEndpointPolicyListAll;

        $getserviceEndpointPolicyListAll = Get-AzServiceEndpointPolicy -ResourceGroupName "*" -Name "*"
        Assert-NotNull $getserviceEndpointPolicyListAll;

        $getserviceEndpointPolicy = Get-AzServiceEndpointPolicy -ResourceId $serviceEndpointPolicy.Id;
        Assert-AreEqual $getserviceEndpointPolicy[0].Name $serviceEndpointPolicyName;
        Assert-AreEqual $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Service $serviceEndpoint;
        Assert-AreEqual $serviceEndpointPolicyDefinitionName $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Name;
        Assert-AreEqual $serviceEndpointPolicyDefinitionDescription $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Description;
        Assert-AreEqual $serviceEndpointPolicyDefinitionResourceName $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].ServiceResources[0];
        Assert-AreEqual $getserviceEndpointPolicy[0].ProvisioningState $provisioningStateSucceeded;

        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $serviceEndpoint -ServiceEndpointPolicy $serviceEndpointPolicy;
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet;
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname;

        Assert-NotNull $vnet;
        Assert-NotNull $vnet.Subnets;

        $subnet = $vnet.Subnets[0];
        Assert-AreEqual $serviceEndpoint $subnet.serviceEndpoints[0].Service;
        Assert-AreEqual $getserviceEndpointPolicy[0].Id $subnet.serviceEndpointPolicies[0].Id;

        Set-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $null -ServiceEndpointPolicy $null;
        $vnet = Set-AzVirtualNetwork -VirtualNetwork $vnet;
        $subnet = $vnet.Subnets[0];

        Assert-Null $subnet.serviceEndpoints;
        Assert-Null $subnet.ServiceEndpointPolicies;

        Remove-AzServiceEndpointPolicyDefinition -ServiceEndpointPolicy $serviceEndpointPolicy -Name $serviceEndpointPolicyDefinitionName;
        $serviceEndpointPolicy = Set-AzServiceEndpointPolicy -ServiceEndpointPolicy $serviceEndpointPolicy
        $getserviceEndpointPolicy = Get-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ResourceGroupName $rgname;

        Assert-AreEqual 0 $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions.Count;

        Add-AzServiceEndpointPolicyDefinition -ServiceEndpointPolicy $serviceEndpointPolicy -Name $serviceEndpointPolicyDefinitionName -Service $serviceEndpoint -ServiceResource $serviceEndpointPolicyDefinitionResourceName -Description $serviceEndpointPolicyDefinitionDescription2;
        Assert-ThrowsLike { Add-AzServiceEndpointPolicyDefinition -ServiceEndpointPolicy $serviceEndpointPolicy -Name $serviceEndpointPolicyDefinitionName -Service $serviceEndpoint -ServiceResource $serviceEndpointPolicyDefinitionResourceName -Description $serviceEndpointPolicyDefinitionDescription2; } "*already exists*"
        $serviceEndpointPolicy = Set-AzServiceEndpointPolicy -ServiceEndpointPolicy $serviceEndpointPolicy
        $getserviceEndpointPolicy = Get-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ResourceGroupName $rgname;

        Assert-AreEqual $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Service $serviceEndpoint;
        Assert-AreEqual $serviceEndpointPolicyDefinitionName $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Name;
        Assert-AreEqual $serviceEndpointPolicyDefinitionDescription2 $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Description;
        Assert-AreEqual $serviceEndpointPolicyDefinitionResourceName $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].ServiceResources[0];

        Set-AzServiceEndpointPolicyDefinition -ServiceEndpointPolicy $serviceEndpointPolicy -Name $serviceEndpointPolicyDefinitionName -Service $serviceEndpoint -ServiceResource $serviceEndpointPolicyDefinitionResourceName -Description $updatedDescription;
        Assert-ThrowsLike { Set-AzServiceEndpointPolicyDefinition -ServiceEndpointPolicy $serviceEndpointPolicy -Name "fake name" -Service $serviceEndpoint -ServiceResource $serviceEndpointPolicyDefinitionResourceName -Description $serviceEndpointPolicyDefinitionDescription2; } "*does not exist*"
        $serviceEndpointPolicy = Set-AzServiceEndpointPolicy -ServiceEndpointPolicy $serviceEndpointPolicy
        $getserviceEndpointPolicy = Get-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ResourceGroupName $rgname;
        Assert-AreEqual $updatedDescription $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Description;

        Remove-AzServiceEndpointPolicyDefinition -ServiceEndpointPolicy $serviceEndpointPolicy -ResourceId $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Id
        $serviceEndpointPolicy = Set-AzServiceEndpointPolicy -ServiceEndpointPolicy $serviceEndpointPolicy
        $getserviceEndpointPolicy = Get-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ResourceGroupName $rgname;
        Assert-AreEqual 0 $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions.Count;

        Remove-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ResourceGroupName $rgname -Force

        Assert-ThrowsLike { Set-AzServiceEndpointPolicy -ServiceEndpointPolicy $serviceEndpointPolicy } "*not*found*"

        $serviceEndpointPolicy = New-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ServiceEndpointPolicyDefinition $serviceEndpointDefinition -ResourceGroupName $rgname -Location $rglocation;

        Remove-AzServiceEndpointPolicyDefinition -ServiceEndpointPolicy $serviceEndpointPolicy -InputObject $serviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0]
        $serviceEndpointPolicy = Set-AzServiceEndpointPolicy -ServiceEndpointPolicy $serviceEndpointPolicy
        $getserviceEndpointPolicy = Get-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ResourceGroupName $rgname;
        Assert-AreEqual 0 $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions.Count;

        $deleted = Remove-AzServiceEndpointPolicy -ResourceId $serviceEndpointPolicy.Id -Force -PassThru
        Assert-AreEqual true $deleted

        $serviceEndpointPolicy = New-AzServiceEndpointPolicy -Name $serviceEndpointPolicyName -ServiceEndpointPolicyDefinition $serviceEndpointDefinition -ResourceGroupName $rgname -Location $rglocation;
        $deleted = Remove-AzServiceEndpointPolicy -InputObject $serviceEndpointPolicy -Force -PassThru
        Assert-AreEqual true $deleted
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
<<<<<<< HEAD
Tests creating new virtual network with flow timeout.
#>
function Test-VirtualNetworkCRUD-FlowTimeout
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create virtual network
        $actual = New-AzVirtualNetwork -ResourceGroupName $rgname -name $rname -location $location -FlowTimeout 15 -AddressPrefix 10.0.0.0/16
        $expected = Get-AzVirtualNetwork -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName 
        Assert-AreEqual $expected.Name $actual.Name 
        Assert-AreEqual $expected.Location $actual.Location
        Assert-NotNull $expected.ResourceGuid
        Assert-AreEqual "Succeeded" $expected.ProvisioningState
        Assert-AreEqual 15 $expected.FlowTimeoutInMinutes

        # Set virtual network
        $actual.FlowTimeoutInMinutes = 30
        $actual = Set-AzVirtualNetwork -VirtualNetwork $actual
        $expected = Get-AzVirtualNetwork -ResourceGroupName $rgname -name $rname
        Assert-AreEqual 30 $expected.FlowTimeoutInMinutes

        # delete
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $actual.ResourceGroupName -Name $rname -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzVirtualNetwork -ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 0 @($list).Count

        # test error handling
        Assert-ThrowsContains { Set-AzVirtualNetwork -VirtualNetwork $actual } "not found";
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests on CRUD for Sync on VirtualNetworkpeering.
#>
function Test-SyncVirtualNetworkPeeringCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName 
    $peerName = Get-ResourceName
    $peerName2 = Get-ResourceName
    $vnet1Name = Get-ResourceName
    $vnet2Name = Get-ResourceName
    $subnet1Name = Get-ResourceName
    $subnet2Name = Get-ResourceName
    $rglocation = "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = "eastus2euap"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network1
        $subnet1 = New-AzVirtualNetworkSubnetConfig -Name $subnet1Name -AddressPrefix 10.1.1.0/24
        $vnet1 = New-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.1.0.0/16 -Subnet $subnet1


        Assert-AreEqual $vnet1.ResourceGroupName $rgname    
        Assert-AreEqual $vnet1.Name $vnet1Name    
        Assert-AreEqual $vnet1.Location $rglocation
        Assert-AreEqual "Succeeded" $vnet1.ProvisioningState        
        Assert-AreEqual $vnet1.Subnets[0].Name $subnet1.Name

        # Create the Virtual Network2
        $subnet2 = New-AzVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.2.1.0/24
        $vnet2 = New-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.2.0.0/16 -Subnet $subnet2

        Assert-AreEqual $vnet2.ResourceGroupName $rgname    
        Assert-AreEqual $vnet2.Name $vnet2Name    
        Assert-AreEqual $vnet2.Location $rglocation
        Assert-AreEqual "Succeeded" $vnet2.ProvisioningState 

        # Add Peering to vnet1
        $job = $vnet1 | Add-AzVirtualNetworkPeering -name $peerName -RemoteVirtualNetworkId $vnet2.Id -AllowForwardedTraffic -AsJob
        $job | Wait-Job
        $peer1 = $job | Receive-Job
        
        # Add Peering to VNet2
        $job = $vnet2 | Add-AzVirtualNetworkPeering -name $peerName2 -RemoteVirtualNetworkId $vnet1.Id -AllowForwardedTraffic -AsJob
        $job | Wait-Job
        $peer2 = $job | Receive-Job

        Assert-AreEqual $peer1.ResourceGroupName $rgname    
        Assert-AreEqual $peer1.Name $peerName    
        Assert-AreEqual $peer1.VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $peer1.ProvisioningState 
        Assert-AreEqual $peer1.RemoteVirtualNetwork.Id $vnet2.Id
        Assert-AreEqual $peer1.AllowVirtualNetworkAccess True
        Assert-AreEqual $peer1.AllowForwardedTraffic True

        Assert-AreEqual $peer2.ResourceGroupName $rgname    
        Assert-AreEqual $peer2.Name $peerName2    
        Assert-AreEqual $peer2.VirtualNetworkName $vnet2Name
        Assert-AreEqual "Succeeded" $peer2.ProvisioningState 
        Assert-AreEqual $peer2.RemoteVirtualNetwork.Id $vnet1.Id
        Assert-AreEqual $peer2.AllowVirtualNetworkAccess True
        Assert-AreEqual $peer2.AllowForwardedTraffic True
        
        # Check if Address Spaces are same
        Assert-AreEqual $peer1.RemoteVirtualNetworkAddressSpace.AddressPrefixesText $vnet2.AddressSpace.AddressPrefixesText

        # Update Address Space of vnet1
        $vnet1.AddressSpace.AddressPrefixes.Add("10.99.0.0/16")
        $vnet1 | Set-AzVirtualNetwork

        # Get and Check Peering Sync Levels of Vnet1 and Vnet2
        $peer1 = Get-AzVirtualNetworkPeering -VirtualNetworkName $vnet1Name -Name $peerName -ResourceGroupName $rgname
        $peer2 = Get-AzVirtualNetworkPeering -VirtualNetworkName $vnet2Name -Name $peerName2 -ResourceGroupName $rgname

        Assert-AreEqual $peer1.PeeringSyncLevel "RemoteNotInSync"
        Assert-AreEqual $peer2.PeeringSyncLevel "LocalNotInSync"

        # Call Sync on VNet2
        $syncVnet2 = Sync-AzVirtualNetworkPeering -Name $peerName2 -VirtualNetworkName $vnet2Name -ResourceGroupName $rgname
        
        # Get and Check Peering Sync Levels of Vnet1 and Vnet2 after updating address space of Vnet1 and syncing them
        $peer1 = Get-AzVirtualNetworkPeering -VirtualNetworkName $vnet1Name -Name $peerName -ResourceGroupName $rgname
        $peer2 = Get-AzVirtualNetworkPeering -VirtualNetworkName $vnet2Name -Name $peerName2 -ResourceGroupName $rgname

        Assert-AreEqual $peer1.PeeringSyncLevel "FullyInSync"
        Assert-AreEqual $peer2.PeeringSyncLevel "FullyInSync"

        $vnet1 = Get-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname

        Assert-AreEqual $peer2.RemoteVirtualNetworkAddressSpace.AddressPrefixesText $vnet1.AddressSpace.AddressPrefixesText
        
        # Delete Peer1 and Peer2
        $job = Remove-AzVirtualNetworkPeering -name $peerName -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname -Force -PassThru -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete

        $job = Remove-AzVirtualNetworkPeering -name $peerName2 -VirtualNetworkName $vnet2Name -ResourceGroupName $rgname -Force -PassThru -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete

        # Delete VirtualNetwork
        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnet1Name -PassThru -Force
        Assert-AreEqual true $delete

        $delete = Remove-AzVirtualNetwork -ResourceGroupName $rgname -name $vnet2Name -PassThru -Force
        Assert-AreEqual true $delete
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests whether virtual network put to an edge zone is successful.
#>
function Test-VirtualNetworkInEdgeZone
{
    # Setup
	$ResourceGroup = Get-ResourceGroupName;
    $LocationName = "westus";
    $EdgeZone = "microsoftlosangeles1";

	$NetworkName = "MyNet";
    $SubnetName = "MySubnet";
    $SubnetAddressPrefix = "10.0.0.0/24";
    $VnetAddressPrefix = "10.0.0.0/16";
    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $ResourceGroup -Location $LocationName -Force;

		$SingleSubnet = New-AzVirtualNetworkSubnetConfig -Name $SubnetName -AddressPrefix $SubnetAddressPrefix;
        New-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $ResourceGroup -Location $LocationName -EdgeZone $EdgeZone -AddressPrefix $VnetAddressPrefix -Subnet $SingleSubnet;

		$Vnet = Get-AzVirtualNetwork -Name $NetworkName -ResourceGroupName $ResourceGroup
		Assert-AreEqual $Vnet.ExtendedLocation.Name $EdgeZone
    }
    catch [Microsoft.Azure.Commands.Network.Common.NetworkCloudException]
    {
        Assert-NotNull { $_.Exception.Message -match 'Resource type .* does not support edge zone .* in location .* The supported edge zones are .*' }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $ResourceGroupfunction Test-VirtualNetworkEdgeZone
    }
}

<#
.SYNOPSIS
Test for creating a new virtual network in an edge zone. Subscriptions need to be explicitly whitelisted for access to edge zones.
#>
function Test-VirtualNetworkEdgeZone
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $rglocation = "eastus2euap"
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = "eastus2euap"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8 -Subnet $subnet -EdgeZone "MicrosoftRRDCLab1"
        $expected = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-AreEqual $expected.ExtendedLocation.Name "MicrosoftRRDCLab1"
        Assert-AreEqual $expected.ExtendedLocation.Type "EdgeZone"
    }
    catch [Microsoft.Azure.Commands.Network.Common.NetworkCloudException]
    {
        Assert-NotNull { $_.Exception.Message -match 'Resource type .* does not support edge zone .* in location .* The supported edge zones are .*' }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating, updating & deleting a virtualNetwork with encryption.
.DESCRIPTION
#>
function Test-VirtualNetworkEncryption
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnet1Name = Get-ResourceName
    $vnet2Name = Get-ResourceName
    $peering1Name = Get-ResourceName
    $peering2Name = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create two virtual networks with encryption property
        New-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.1.0.0/16 -EnableEncryption true -EncryptionEnforcementPolicy "dropUnencrypted"
        New-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.2.0.0/16 -EnableEncryption true -EncryptionEnforcementPolicy "dropUnencrypted"

        # Perform GET operations to retrieve both virtual networks and verify that the encryption property is set to the expected value
        $vnet1 = Get-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname
        $vnet2 = Get-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname
        Assert-AreEqual "true" $vnet1.Encryption.Enabled
        Assert-AreEqual "true" $vnet2.Encryption.Enabled
        Assert-AreEqual "dropUnencrypted" $vnet1.Encryption.Enforcement
        Assert-AreEqual "dropUnencrypted" $vnet2.Encryption.Enforcement

        # Update the encryption policies on both virtual networks
        $vnet1.Encryption.Enabled = "false"
        $vnet1.Encryption.Enforcement = "allowUnencrypted"
        $vnet2.Encryption.Enforcement = "allowUnencrypted"
        $updateVnet1Job = $vnet1 | Set-AzVirtualNetwork -AsJob
        $updateVnet1Job | Wait-Job
        $updateVnet1 = $updateVnet1Job | Receive-Job
        $updateVnet2Job = $vnet2 | Set-AzVirtualNetwork -AsJob
        $updateVnet2Job | Wait-Job
        $updateVnet2 = $updateVnet2Job | Receive-Job

         # Perform GET operations to retrieve both virtual networks and verify that the encryption property is set to the expected value
        $vnet1 = Get-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname
        $vnet2 = Get-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname
        Assert-AreEqual "false" $vnet1.Encryption.Enabled
        Assert-AreEqual "true" $vnet2.Encryption.Enabled
        Assert-AreEqual "allowUnencrypted" $vnet1.Encryption.Enforcement
        Assert-AreEqual "allowUnencrypted" $vnet2.Encryption.Enforcement

        # Peer both virtual networks
        $job1 = $vnet1 | Add-AzVirtualNetworkPeering -Name $peering1Name -RemoteVirtualNetworkId $vnet2.Id -AsJob
        $job1 | Wait-Job
        $peer1 = $job1 | Receive-Job

        $job2 = $vnet2 | Add-AzVirtualNetworkPeering -Name $peering2Name -RemoteVirtualNetworkId $vnet1.Id -AsJob
        $job2 | Wait-Job
        $peer2 = $job2 | Receive-Job

        Assert-AreEqual $peer1.ResourceGroupName $rgname    
        Assert-AreEqual $peer1.Name $peering1Name    
        Assert-AreEqual $peer1.VirtualNetworkName $vnet1Name
        Assert-AreEqual "Succeeded" $peer1.ProvisioningState 
        Assert-AreEqual $peer1.RemoteVirtualNetwork.Id $vnet2.Id

        Assert-AreEqual $peer2.ResourceGroupName $rgname    
        Assert-AreEqual $peer2.Name $peering2Name    
        Assert-AreEqual $peer2.VirtualNetworkName $vnet2Name
        Assert-AreEqual "Succeeded" $peer2.ProvisioningState 
        Assert-AreEqual $peer2.RemoteVirtualNetwork.Id $vnet1.Id

        # Perform GET operations to retrieve both virtual networks and validate the RemoteVirtualNetworkEncryption property on the child peering resource
        $vnet1 = Get-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname
        $vnet2 = Get-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname   
        Assert-AreEqual "true" $vnet1.VirtualNetworkPeerings[0].RemoteVirtualNetworkEncryption.Enabled
        Assert-AreEqual "false" $vnet2.VirtualNetworkPeerings[0].RemoteVirtualNetworkEncryption.Enabled
        Assert-AreEqual "allowUnencrypted" $vnet2.VirtualNetworkPeerings[0].RemoteVirtualNetworkEncryption.Enforcement
        Assert-AreEqual "allowUnencrypted" $vnet1.VirtualNetworkPeerings[0].RemoteVirtualNetworkEncryption.Enforcement

        # Get Peering to confirm the RemoteVirtualNetworkEncryption property
        $peering1 = Get-AzVirtualNetworkPeering -Name $peering1Name -VirtualNetwork $vnet1Name -ResourceGroupName $rgname
        $peering2 = Get-AzVirtualNetworkPeering -Name $peering2Name -VirtualNetwork $vnet2Name -ResourceGroupName $rgname
        Assert-AreEqual "true" $peering1.RemoteVirtualNetworkEncryption.Enabled
        Assert-AreEqual "false" $peering2.RemoteVirtualNetworkEncryption.Enabled
        Assert-AreEqual "allowUnencrypted" $peering1.RemoteVirtualNetworkEncryption.Enforcement
        Assert-AreEqual "allowUnencrypted" $peering2.RemoteVirtualNetworkEncryption.Enforcement
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating, updating, and deleting virtual networks with the PrivateEndpointVNetPolicies property
.DESCRIPTION
#>
function Test-VirtualNetworkPrivateEndpointVNetPolicies
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnet1Name = Get-ResourceName
    $vnet2Name = Get-ResourceName
    $vnet3Name = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
    
        # Create virtual network without specifying PrivateEndpointVNetPolicies
        New-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.1.0.0/16
        
        # Verify that PrivateEndpointVNetPolicies is "Disabled" by default
        $vnet1 = Get-AzVirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname
        Assert-AreEqual "Disabled" $vnet1.PrivateEndpointVNetPolicies

        # Create virtual network with PrivateEndpointVNetPolicies specified as "Disabled"
        New-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.2.0.0/16 -PrivateEndpointVNetPoliciesValue "Disabled"
        $vnet2 = Get-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname
        Assert-AreEqual "Disabled" $vnet2.PrivateEndpointVNetPolicies

        # Validate that the virtual network can be updated to set PrivateEndpointVNetPolicies to "Basic"
        $vnet2.PrivateEndpointVNetPolicies = "Basic"
        $vnet2 | Set-AzVirtualNetwork
        $vnet2 = Get-AzVirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname
        Assert-AreEqual "Basic" $vnet2.PrivateEndpointVNetPolicies

        # Create virtual network with PrivateEndpointVNetPolicies specified as "Basic"
        New-AzVirtualNetwork -Name $vnet3Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.3.0.0/16 -PrivateEndpointVNetPoliciesValue "Basic"
        $vnet3 = Get-AzVirtualNetwork -Name $vnet3Name -ResourceGroupName $rgname
        Assert-AreEqual "Basic" $vnet3.PrivateEndpointVNetPolicies

        # Validate that the virtual network can be updated to set PrivateEndpointVNetPolicies to "Disabled"
        $vnet3.PrivateEndpointVNetPolicies = "Disabled"
        $vnet3 | Set-AzVirtualNetwork
        $vnet3 = Get-AzVirtualNetwork -Name $vnet3Name -ResourceGroupName $rgname
        Assert-AreEqual "Disabled" $vnet3.PrivateEndpointVNetPolicies
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}