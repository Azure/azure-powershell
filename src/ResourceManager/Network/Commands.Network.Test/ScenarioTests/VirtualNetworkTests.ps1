﻿# ----------------------------------------------------------------------------------
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
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $job = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8 -Subnet $subnet -AsJob
        $job | Wait-Job
        $actual = $job | Receive-Job
        $expected = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
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
        $list = Get-AzureRmvirtualNetwork -ResourceGroupName $rgname
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

        # Test virtual network private ip address - available - TestByResource
        $testResponse1 = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Test-AzureRmPrivateIPAddressAvailability -IPAddress "10.0.1.10"
        Assert-AreEqual true $testResponse1.Available

        # Test virtual network private ip address - not available - TestByResource
        $testResponse2 = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Test-AzureRmPrivateIPAddressAvailability -IPAddress "10.0.1.3"
        Assert-AreEqual false $testResponse2.Available
        Assert-AreEqual 5 @($testResponse2.AvailableIpAddresses).Count

        # Test virtual network private ip address - available - TestByResourceId
        $testResponse1 = Test-AzureRmPrivateIPAddressAvailability -ResourceGroupName $rgname -VirtualNetworkName $vnetName -IPAddress "10.0.1.10"
        Assert-AreEqual true $testResponse1.Available

        # Test virtual network private ip address - not available - TestByResourceId
        $testResponse2 = Test-AzureRmPrivateIPAddressAvailability -ResourceGroupName $rgname -VirtualNetworkName $vnetName -IPAddress "10.0.1.3"
        Assert-AreEqual false $testResponse2.Available
        Assert-AreEqual 5 @($testResponse2.AvailableIpAddresses).Count
        
        # Delete VirtualNetwork
        $job = Remove-AzureRmvirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete
                
        $list = Get-AzureRmvirtualNetwork -ResourceGroupName $rgname
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
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        
        # Add a subnet
        $vnet | Add-AzureRmVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.2.0/24
        
        # Set VirtualNetwork
        $vnet | Set-AzureRmVirtualNetwork
        
        # Get VirtualNetwork
        $vnetExpected = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual "10.0.2.0/24" $vnetExpected.Subnets[1].AddressPrefix
        
        # Edit a subnet
        $job = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Set-AzureRmVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.0.3.0/24 | Set-AzureRmVirtualNetwork -AsJob
        $job | Wait-Job

        $vnetExpected = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual 2 @($vnetExpected.Subnets).Count
        Assert-AreEqual $subnetName $vnetExpected.Subnets[0].Name
        Assert-AreEqual $subnet2Name $vnetExpected.Subnets[1].Name
        Assert-AreEqual "10.0.3.0/24" $vnetExpected.Subnets[1].AddressPrefix

        # Get subnet
        $subnet2 = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzureRmVirtualNetworkSubnetConfig -Name $subnet2Name
        $subnetAll = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzureRmVirtualNetworkSubnetConfig

        Assert-AreEqual 2 @($subnetAll).Count
        Assert-AreEqual $subnetName $subnetAll[0].Name
        Assert-AreEqual $subnet2Name $subnetAll[1].Name
        Assert-AreEqual $subnet2Name $subnet2.Name

        # Get non-existing subnet
        try
        {
            $subnetNotExists = $vnetExpected | Get-AzureRmVirtualNetworkSubnetConfig -Name "Subnet-DoesNotExist"
        }
        catch
        {
            if ($_.Exception.GetType() -ne [System.ArgumentException])
            {
                throw;
            }
        }

        # Remove a subnet
        Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Remove-AzureRmVirtualNetworkSubnetConfig -Name $subnet2Name | Set-AzureRmVirtualNetwork
        
        $vnetExpected = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
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

        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create a DDoS Protection plan

        $ddosProtectionPlan = New-AzureRmDdosProtectionPlan -Name $ddosProtectionPlanName -ResourceGroupName $rgname -Location $location

        # Create the Virtual Network

        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $actual = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8 -Subnet $subnet -EnableDdoSProtection -DdosProtectionPlanId $ddosProtectionPlan.Id
        $expected = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname

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
        Set-AzureRmVirtualNetwork -VirtualNetwork $expected
        $expected = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual false $expected.EnableDDoSProtection
        Assert-AreEqual $null $expected.DdosProtectionPlan
       
        $expected.DdosProtectionPlan = New-Object Microsoft.Azure.Commands.Network.Models.PSResourceId
        $expected.DdosProtectionPlan.Id = $ddosProtectionPlan.Id
        Set-AzureRmVirtualNetwork -VirtualNetwork $expected
        $expected = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        Assert-AreEqual false $expected.EnableDDoSProtection
        Assert-AreEqual $ddosProtectionPlan.Id $expected.DdosProtectionPlan.Id

        # Delete the virtual network

        $deleteVnet = Remove-AzureRmvirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $deleteVnet

        # Delete the DDoS protection plan

        $deleteDdosProtectionPlan = Remove-AzureRmDdosProtectionPlan -ResourceGroupName $rgname -name $ddosProtectionPlanName -PassThru
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
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network1
        $subnet1 = New-AzureRmVirtualNetworkSubnetConfig -Name $subnet1Name -AddressPrefix 10.0.0.0/24
        $vnet1 = New-AzureRmvirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet1


        Assert-AreEqual $vnet1.ResourceGroupName $rgname    
        Assert-AreEqual $vnet1.Name $vnet1Name    
        Assert-AreEqual $vnet1.Location $rglocation
        Assert-AreEqual "Succeeded" $vnet1.ProvisioningState        
        Assert-AreEqual $vnet1.Subnets[0].Name $subnet1.Name

        # Create the Virtual Network2
        $subnet2 = New-AzureRmVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.1.1.0/24
        $vnet2 = New-AzureRmvirtualNetwork -Name $vnet2Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.1.0.0/16 -Subnet $subnet2

        Assert-AreEqual $vnet2.ResourceGroupName $rgname    
        Assert-AreEqual $vnet2.Name $vnet2Name    
        Assert-AreEqual $vnet2.Location $rglocation
        Assert-AreEqual "Succeeded" $vnet2.ProvisioningState 

        # Add Peering to vnet1
        $job = $vnet1 | Add-AzureRmVirtualNetworkPeering -name $peerName -RemoteVirtualNetworkId $vnet2.Id -AllowForwardedTraffic -AsJob
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
        $getPeer = Get-AzureRmVirtualNetworkPeering -name $peerName -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname
        
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
        $listPeer = Get-AzureRmVirtualNetworkPeering -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname
        
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
        
        $job = $getPeer | Set-AzureRmVirtualNetworkPeering -AsJob
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
        $job = Remove-AzureRmVirtualNetworkPeering -name $peerName -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname -Force -PassThru -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete

        # Delete VirtualNetwork
        $delete = Remove-AzureRmvirtualNetwork -ResourceGroupName $rgname -name $vnet1Name -PassThru -Force
        Assert-AreEqual true $delete

        $delete = Remove-AzureRmvirtualNetwork -ResourceGroupName $rgname -name $vnet2Name -PassThru -Force
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
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"

    $location = "eastus"
    
	# The remote VNet in this case lives under a different tenant and hence can is assumed to be created by the time the test is run
	# Create the remote Virtual Network : This needs to e done ins a seperate subscription that lives under a different tenant
	# As of now the steps are manual

    # $subnet2 = New-AzureRmVirtualNetworkSubnetConfig -Name $subnet2Name -AddressPrefix 10.1.1.0/24
    # $vnet2 = New-AzureRmvirtualNetwork -Name myVirtualNetwork1 -ResourceGroupName $rgname -Location eastus -AddressPrefix 10.1.0.0/16 -Subnet $subnet2

    try 
    {
        # Create the resource group
        $rglocation = "eastus"
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network1
        $subnet1 = New-AzureRmVirtualNetworkSubnetConfig -Name $subnet1Name -AddressPrefix 10.0.0.0/24
        $vnet1 = New-AzureRmvirtualNetwork -Name $vnet1Name -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet2
                
        Assert-AreEqual $vnet1.ResourceGroupName $rgname    
        Assert-AreEqual $vnet1.Name $vnet1Name    
        Assert-AreEqual $vnet1.Location $rglocation
        Assert-AreEqual "Succeeded" $vnet1.ProvisioningState        
       

        # Add Peering to vnet1
        $job = $vnet1 | Add-AzureRmVirtualNetworkPeering -name $peerName -RemoteVirtualNetworkId $vnet2Id -AllowForwardedTraffic -AsJob
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
        $getPeer = Get-AzureRmVirtualNetworkPeering -name $peerName -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname
        
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
        $listPeer = Get-AzureRmVirtualNetworkPeering -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname
        
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
        
        $job = $getPeer | Set-AzureRmVirtualNetworkPeering -AsJob
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
        $job = Remove-AzureRmVirtualNetworkPeering -name $peerName -VirtualNetworkName $vnet1Name -ResourceGroupName $rgname -Force -PassThru -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete

        # Delete VirtualNetwork
        $delete = Remove-AzureRmvirtualNetwork -ResourceGroupName $rgname -name $vnet1Name -PassThru -Force
        Assert-AreEqual true $delete

		# Delete VNet2 in the remote tenant
        # $delete = Remove-AzureRmvirtualNetwork -ResourceGroupName $rgname -name $vnet2Name -PassThru -Force
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
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $rglocation = "westus"
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
        $vnet = New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
                
        Assert-AreEqual $vnet.ResourceGroupName $rgname    
        Assert-AreEqual $vnet.Name $vnetName    
        Assert-AreEqual $vnet.Location $rglocation
        Assert-AreEqual "Succeeded" $vnet.ProvisioningState

        $subnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzureRmVirtualNetworkSubnetConfig -Name $subnetName
        Assert-AreEqual 0 @($subnet.ResourceNavigationLinks).Count

        # Create redis-cache
        $cacheCreated = New-AzureRmRedisCache -ResourceGroupName $rgname -Name $cacheName -Location $location -Size P1 -Sku Premium -SubnetId $subnet.Id

        # In loop to check if cache exists
        for ($i = 0; $i -le 60; $i++)
        {
            Start-TestSleep 30000
            $cacheGet = Get-AzureRmRedisCache -ResourceGroupName $rgname -Name $cacheName
            if ([string]::Compare("succeeded", $cacheGet[0].ProvisioningState, $True) -eq 0)
            {
                break
            }
            Assert-False {$i -eq 60} "Cache is not in succeeded state even after 30 min."
        }

        # Get redis-cache
        $cache = Get-AzureRmRedisCache -ResourceGroupName $rgname -Name $cacheName

        # Get subnet and check resource navigation links
        $subnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname | Get-AzureRmVirtualNetworkSubnetConfig -Name $subnetName
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
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname

        Assert-NotNull $vnet;
        Assert-NotNull $vnet.Subnets;

        $subnetId = $vnet.Subnets[0].Id;

        $usage = Get-AzureRMVirtualNetworkUsageList -ResourceGroupName $rgname -Name $vnetName;

        Assert-NotNull $usage;
        $currentUsage = $usage.CurrentValue;

        # Add Network Interface to change usage current value
        New-AzureRmNetworkInterface -Location $location -Name $nicName -ResourceGroupName $rgname -SubnetId $subnetId;
        $usage = Get-AzureRMVirtualNetworkUsageList -ResourceGroupName $rgname -Name $vnetName;
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
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" };

        # Create the Virtual Network
        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $serviceEndpoint;
        New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet;
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname;

        Assert-NotNull $vnet;
        Assert-NotNull $vnet.Subnets;

        $subnet = $vnet.Subnets[0];
        Assert-AreEqual $serviceEndpoint $subnet.serviceEndpoints[0].Service;

        Set-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $null;
        $vnet = Set-AzureRmVirtualNetwork -VirtualNetwork $vnet;
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
    $serviceEndpointPolicyName = "ServiceEndpointPolicy1"
    $serviceEndpointPolicyDefinitionResourceName = "/subscriptions/subid1/resourceGroups/storageRg/providers/Microsoft.Storage/storageAccounts/stAccount"

    try
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" };

        # Create the Virtual Network
        $serviceEndpointDefinition = New-AzureRmServiceEndpointPolicyDefinition -Name $serviceEndpointPolicyDefinitionName -Service $serviceEndpoint -ServiceResource $serviceEndpointPolicyDefinitionResourceName -Description $serviceEndpointPolicyDefinitionDescription;
        $serviceEndpointPolicy = New-AzureRmServiceEndpointPolicy -Name $serviceEndpointPolicyName -ServiceEndpointPolicyDefinition $serviceEndpointDefinition -ResourceGroupName $rgname -Location $rglocation;

        $getserviceEndpointPolicy = Get-AzureRmServiceEndpointPolicy -Name $serviceEndpointPolicyName -ResourceGroupName $rgname;

        Assert-AreEqual $getserviceEndpointPolicy[0].Name $serviceEndpointPolicyName;
        Assert-AreEqual $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Service $serviceEndpoint;
        Assert-AreEqual $serviceEndpointPolicyDefinitionName $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Name;
        Assert-AreEqual $serviceEndpointPolicyDefinitionDescription $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].Description;
        Assert-AreEqual $serviceEndpointPolicyDefinitionResourceName $getserviceEndpointPolicy[0].ServiceEndpointPolicyDefinitions[0].ServiceResources[0];

        $subnet = New-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $serviceEndpoint -ServiceEndpointPolicy $serviceEndpointPolicy;
        New-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -Subnet $subnet;
        $vnet = Get-AzureRmvirtualNetwork -Name $vnetName -ResourceGroupName $rgname;

        Assert-NotNull $vnet;
        Assert-NotNull $vnet.Subnets;

        $subnet = $vnet.Subnets[0];
        Assert-AreEqual $serviceEndpoint $subnet.serviceEndpoints[0].Service;
        Assert-AreEqual $getserviceEndpointPolicy[0].Id $subnet.serviceEndpointPolicies[0].Id;

        Set-AzureRmVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet -AddressPrefix 10.0.1.0/24 -ServiceEndpoint $null -ServiceEndpointPolicy $null;
        $vnet = Set-AzureRmVirtualNetwork -VirtualNetwork $vnet;
        $subnet = $vnet.Subnets[0];

        Assert-Null $subnet.serviceEndpoints;
        Assert-Null $subnet.ServiceEndpointPolicies;

        Remove-AzureRmServiceEndpointPolicy -Name $serviceEndpointPolicyName -ResourceGroupName $rgname -force
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
