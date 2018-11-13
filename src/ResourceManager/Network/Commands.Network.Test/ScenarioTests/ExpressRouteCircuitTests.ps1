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
Tests ExpressRouteCircuitCRUD.
#>
function Test-ExpressRouteBGPServiceCommunities
{
	$communities = Get-AzureRmBgpServiceCommunity

	Assert-NotNull $communities
	$crmOnlineCommunity = $communities | Where-Object {$_.ServiceName -match "CRMOnline"}
	Assert-NotNull $crmOnlineCommunity.BgpCommunities
	Assert-AreEqual true $crmOnlineCommunity.BgpCommunities[0].IsAuthorizedToUse
}

<#
.SYNOPSIS
Tests ExpressRouteCircuitCRUD.
#>
function Test-ExpressRouteRouteFilters
{
    $location = Get-ProviderLocation "Microsoft.Network/expressRouteCircuits" "West US"
    $rgname = "filter"
    $filterName = "filter"
    $ruleName = "rule"

    try
    {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $location

      # Create the route filter
      $job = New-AzureRmRouteFilter -Name $filterName -ResourceGroupName $rgname -Location $location -Force -AsJob
	  $job | Wait-Job
	  $filter = $job | Receive-Job

      #verification
      Assert-AreEqual $rgName $filter.ResourceGroupName
      Assert-AreEqual $filterName $filter.Name
      Assert-NotNull $filter.Location
      Assert-AreEqual 0 @($filter.Rules).Count

	  $rule = New-AzureRmRouteFilterRuleConfig -Name $ruleName -Access Allow -RouteFilterRuleType Community -CommunityList "12076:5010" -Force
	  $filter = Get-AzureRmRouteFilter -Name filter -ResourceGroupName filter
	  $filter.Rules.Add($rule)
	  $job = Set-AzureRmRouteFilter -RouteFilter $filter -Force -AsJob
	  $job | Wait-Job
	  $filter = $job | Receive-Job

	  #verification
      Assert-AreEqual $rgName $filter.ResourceGroupName
      Assert-AreEqual $filterName $filter.Name
      Assert-NotNull $filter.Location
      Assert-AreEqual 1 @($filter.Rules).Count

	  $filter = Get-AzureRmRouteFilter -Name $filterName -ResourceGroupName $rgname
	  $filter.Rules.Clear()
	  $filter = Set-AzureRmRouteFilter -RouteFilter $filter -Force

	  #verification
      Assert-AreEqual $rgName $filter.ResourceGroupName
      Assert-AreEqual $filterName $filter.Name
      Assert-NotNull $filter.Location
      Assert-AreEqual 0 @($filter.Rules).Count

    }
    finally
    {
    # Cleanup
      Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests ExpressRouteCircuitCRUD.
#>
function Test-ExpressRouteCircuitStageCRUD
{
    # Setup
    $rgname = 'movecircuit'
    $circuitName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "Brazil South"
    $location = Get-ProviderLocation "Microsoft.Network/expressRouteCircuits" "Brazil South"

    try 
    {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation
      
      # Create the ExpressRouteCircuit
	  $job = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 500 -AllowClassicOperations $true -AsJob
	  $job | Wait-Job
	  $circuit = $job | Receive-Job
      
      $circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname
      # set
      $circuit.AllowClassicOperations = $false
      $circuit = Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $circuit
	  
	  		$actual = Get-AzureRmExpressRouteCircuitStats -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name 
			Assert-AreEqual $actual.PrimaryBytesIn 0

	  #move
	  $job = Move-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname -Location $location -ServiceKey $circuit.ServiceKey -Force -AsJob
	  $job | Wait-Job

      # Delete Circuit
	  $job = Remove-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force -AsJob
	  $job | Wait-Job
	  $delete = $job | Receive-Job
      Assert-AreEqual true $delete
		      
      $list = Get-AzureRmExpressRouteCircuit -ResourceGroupName $rgname
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
Tests ExpressRouteCircuitCRUD.
#>
function Test-ExpressRouteCircuitCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $circuitName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $location = Get-ProviderLocation "Microsoft.Network/expressRouteCircuits" "Brazil South"

    try 
    {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation
      
      # Create the ExpressRouteCircuit
		$circuit = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 500;
      
      # get Circuit
      $getCircuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname

      #verification
      Assert-AreEqual $rgName $getCircuit.ResourceGroupName
      Assert-AreEqual $circuitName $getCircuit.Name
      Assert-NotNull $getCircuit.Location
      Assert-NotNull $getCircuit.Etag
      Assert-AreEqual 0 @($getCircuit.Peerings).Count
      Assert-AreEqual "Standard_MeteredData" $getCircuit.Sku.Name
      Assert-AreEqual "Standard" $getCircuit.Sku.Tier
      Assert-AreEqual "MeteredData" $getCircuit.Sku.Family
      Assert-AreEqual "equinix" $getCircuit.ServiceProviderProperties.ServiceProviderName
      Assert-AreEqual "Silicon Valley" $getCircuit.ServiceProviderProperties.PeeringLocation
      Assert-AreEqual "500" $getCircuit.ServiceProviderProperties.BandwidthInMbps

      # list
      $list = Get-AzureRmExpressRouteCircuit -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $getCircuit.ResourceGroupName
      Assert-AreEqual $list[0].Name $getCircuit.Name
      Assert-AreEqual $list[0].Location $getCircuit.Location
      Assert-AreEqual $list[0].Etag $getCircuit.Etag
      Assert-AreEqual @($list[0].Peerings).Count @($getCircuit.Peerings).Count

		# set
      $getCircuit.ServiceProviderProperties.BandwidthInMbps = 1000
      $getCircuit.Sku.Tier = "Premium"
      $getCircuit.Sku.Family = "UnlimitedData"

      $job = Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $getCircuit -AsJob
	  $job | Wait-Job
	  $getCircuit = $job | Receive-Job
      Assert-AreEqual $rgName $getCircuit.ResourceGroupName
      Assert-AreEqual $circuitName $getCircuit.Name
      Assert-NotNull $getCircuit.Location
      Assert-NotNull $getCircuit.Etag
      Assert-AreEqual 0 @($getCircuit.Peerings).Count
      Assert-AreEqual "Standard_MeteredData" $getCircuit.Sku.Name
      Assert-AreEqual "Premium" $getCircuit.Sku.Tier
      Assert-AreEqual "UnlimitedData" $getCircuit.Sku.Family
      Assert-AreEqual "equinix" $getCircuit.ServiceProviderProperties.ServiceProviderName
      Assert-AreEqual "Silicon Valley" $getCircuit.ServiceProviderProperties.PeeringLocation
      Assert-AreEqual "1000" $getCircuit.ServiceProviderProperties.BandwidthInMbps
      

      # Delete Circuit
      $delete = Remove-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force
      Assert-AreEqual true $delete
		      
      $list = Get-AzureRmExpressRouteCircuit -ResourceGroupName $rgname
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
Tests ExpressRouteCircuitPeeringCRUD for private peering and public peering
#>
function Test-ExpressRouteCircuitPrivatePublicPeeringCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $circuitName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $location = Get-ProviderLocation "Microsoft.Network/expressRouteCircuits" "Brazil South"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation
    
        # Create the ExpressRouteCircuit with peering
        $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -PeeringType AzurePrivatePeering -PeerASN 100 -PrimaryPeerAddressPrefix "192.168.1.0/30" -SecondaryPeerAddressPrefix "192.168.2.0/30" -VlanId 22
        $circuit = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 1000 -Peering $peering
    
        #verification
        Assert-AreEqual $rgName $circuit.ResourceGroupName
        Assert-AreEqual $circuitName $circuit.Name
        Assert-NotNull $circuit.Location
        Assert-NotNull $circuit.Etag
        Assert-AreEqual 1 @($circuit.Peerings).Count
        Assert-AreEqual "Standard_MeteredData" $circuit.Sku.Name
        Assert-AreEqual "Standard" $circuit.Sku.Tier
        Assert-AreEqual "MeteredData" $circuit.Sku.Family
        Assert-AreEqual "equinix" $circuit.ServiceProviderProperties.ServiceProviderName
        Assert-AreEqual "Silicon Valley" $circuit.ServiceProviderProperties.PeeringLocation
        Assert-AreEqual "1000" $circuit.ServiceProviderProperties.BandwidthInMbps
				
		# Verify the peering
        Assert-AreEqual "AzurePrivatePeering" $circuit.Peerings[0].Name
        Assert-AreEqual "AzurePrivatePeering" $circuit.Peerings[0].PeeringType
		Assert-AreEqual "100" $circuit.Peerings[0].PeerASN
		Assert-AreEqual "192.168.1.0/30" $circuit.Peerings[0].PrimaryPeerAddressPrefix
		Assert-AreEqual "192.168.2.0/30" $circuit.Peerings[0].SecondaryPeerAddressPrefix
		Assert-AreEqual "22" $circuit.Peerings[0].VlanId
		
		Get-AzureRmExpressRouteCircuitARPTable -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name -PeeringType AzurePrivatePeering -DevicePath Primary
		Get-AzureRmExpressRouteCircuitRouteTableSummary -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name -PeeringType AzurePrivatePeering -DevicePath Primary
		Get-AzureRmExpressRouteCircuitRouteTable -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name -PeeringType AzurePrivatePeering -DevicePath Primary
		
		# get peering
		$p = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering
		Assert-AreEqual "AzurePrivatePeering" $p.Name
		Assert-AreEqual "AzurePrivatePeering" $p.PeeringType
		Assert-AreEqual "100" $p.PeerASN
		Assert-AreEqual "192.168.1.0/30" $p.PrimaryPeerAddressPrefix
		Assert-AreEqual "192.168.2.0/30" $p.SecondaryPeerAddressPrefix
		Assert-AreEqual "22" $p.VlanId
		Assert-Null $p.MicrosoftPeeringConfig

		# List peering
		$listPeering = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig
		Assert-AreEqual 1 @($listPeering).Count

		# add public peering 
		$circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Add-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePublicPeering -PeeringType AzurePublicPeering -PeerASN 30 -PrimaryPeerAddressPrefix "192.168.1.0/30" -SecondaryPeerAddressPrefix "192.168.2.0/30" -VlanId 33  | Set-AzureRmExpressRouteCircuit 
		$p = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePublicPeering
		Assert-AreEqual "AzurePublicPeering" $p.Name
		Assert-AreEqual "AzurePublicPeering" $p.PeeringType
		Assert-AreEqual "30" $p.PeerASN
		Assert-AreEqual "192.168.1.0/30" $p.PrimaryPeerAddressPrefix
		Assert-AreEqual "192.168.2.0/30" $p.SecondaryPeerAddressPrefix
		Assert-AreEqual "33" $p.VlanId
		
		#set public peering
	    $circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Set-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePublicPeering -PeeringType AzurePublicPeering -PeerASN 100 -PrimaryPeerAddressPrefix "192.168.1.0/30" -SecondaryPeerAddressPrefix "192.168.2.0/30" -VlanId 55  | Set-AzureRmExpressRouteCircuit 
		$p = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePublicPeering

		Assert-AreEqual "AzurePublicPeering" $p.Name
		Assert-AreEqual "AzurePublicPeering" $p.PeeringType
		Assert-AreEqual "100" $p.PeerASN
		Assert-AreEqual "192.168.1.0/30" $p.PrimaryPeerAddressPrefix
		Assert-AreEqual "192.168.2.0/30" $p.SecondaryPeerAddressPrefix
		Assert-AreEqual "55" $p.VlanId

		$listPeering = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig
		Assert-AreEqual 2 @($listPeering).Count			

		# Delete Circuit
        $delete = Remove-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force
        Assert-AreEqual true $delete
		    
        $list = Get-AzureRmExpressRouteCircuit -ResourceGroupName $rgname
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
Tests express route microsoft peering
#>
function Test-ExpressRouteCircuitMicrosoftPeeringCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $circuitName = Get-ResourceName
  $filterName = "filter"
  $ruleName = "rule"
    $rglocation = Get-ProviderLocation ResourceManagement
    $location = Get-ProviderLocation "Microsoft.Network/expressRouteCircuits" "Brazil South"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation    
        # Create the ExpressRouteCircuit with peering
        $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 33 -PrimaryPeerAddressPrefix "192.171.1.0/30" -SecondaryPeerAddressPrefix "192.171.2.0/30" -VlanId 224 -MicrosoftConfigAdvertisedPublicPrefixes @("11.2.3.4/30", "12.2.3.4/30") -MicrosoftConfigCustomerAsn 1000 -MicrosoftConfigRoutingRegistryName AFRINIC -LegacyMode $true 
        $circuit = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Premium -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 1000 -Peering $peering	

        #verification
        Assert-AreEqual $rgName $circuit.ResourceGroupName
        Assert-AreEqual $circuitName $circuit.Name
        Assert-NotNull $circuit.Location
        Assert-NotNull $circuit.Etag
        Assert-AreEqual 1 @($circuit.Peerings).Count
        Assert-AreEqual "Premium_MeteredData" $circuit.Sku.Name
        Assert-AreEqual "Premium" $circuit.Sku.Tier
        Assert-AreEqual "MeteredData" $circuit.Sku.Family
        Assert-AreEqual "equinix" $circuit.ServiceProviderProperties.ServiceProviderName
        Assert-AreEqual "Silicon Valley" $circuit.ServiceProviderProperties.PeeringLocation
        Assert-AreEqual "1000" $circuit.ServiceProviderProperties.BandwidthInMbps
		
		# Verify the peering
		Assert-AreEqual "MicrosoftPeering" $circuit.Peerings[0].Name
		Assert-AreEqual "MicrosoftPeering" $circuit.Peerings[0].PeeringType
		Assert-AreEqual "192.171.1.0/30" $circuit.Peerings[0].PrimaryPeerAddressPrefix
		Assert-AreEqual "192.171.2.0/30" $circuit.Peerings[0].SecondaryPeerAddressPrefix
		Assert-AreEqual "224" $circuit.Peerings[0].VlanId
		Assert-NotNull $circuit.Peerings[0].MicrosoftPeeringConfig
		Assert-AreEqual "1000" $circuit.Peerings[0].MicrosoftPeeringConfig.CustomerASN
		Assert-AreEqual "AFRINIC" $circuit.Peerings[0].MicrosoftPeeringConfig.RoutingRegistryName
		Assert-AreEqual 2 @($circuit.Peerings[0].MicrosoftPeeringConfig.AdvertisedPublicPrefixes).Count
		Assert-NotNull $circuit.Peerings[0].MicrosoftPeeringConfig.AdvertisedPublicPrefixesState

	    # create route filter 
		$rule = New-AzureRmRouteFilterRuleConfig -Name $ruleName -Access Allow -RouteFilterRuleType Community -CommunityList "12076:5010" -Force	
		$filter = New-AzureRmRouteFilter -Name $filterName -ResourceGroupName $rgname -Location $location -Rule $rule -Force
		
		# update circuit with filter 
		$circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname
		$circuit.Peerings[0].RouteFilter = $filter
		Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $circuit

		# get peering
		$p = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering
		Assert-AreEqual "MicrosoftPeering" $p.Name
		Assert-AreEqual "MicrosoftPeering" $p.PeeringType
		Assert-AreEqual "192.171.1.0/30" $p.PrimaryPeerAddressPrefix
		Assert-AreEqual "192.171.2.0/30" $p.SecondaryPeerAddressPrefix
		Assert-AreEqual "224" $p.VlanId
		Assert-NotNull $p.MicrosoftPeeringConfig
		Assert-AreEqual "1000" $p.MicrosoftPeeringConfig.CustomerASN
		Assert-AreEqual "AFRINIC" $p.MicrosoftPeeringConfig.RoutingRegistryName
		Assert-AreEqual 2 @($p.MicrosoftPeeringConfig.AdvertisedPublicPrefixes).Count
		Assert-NotNull $p.MicrosoftPeeringConfig.AdvertisedPublicPrefixesState

		# List peering
		$listPeering = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig
		Assert-AreEqual 1 @($listPeering).Count

		# Set a new IPv4 peering
	    $circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Set-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 44 -PrimaryPeerAddressPrefix "192.171.1.0/30" -SecondaryPeerAddressPrefix "192.171.2.0/30" -VlanId 555 -MicrosoftConfigAdvertisedPublicPrefixes @("11.2.3.4/30", "12.2.3.4/30") -MicrosoftConfigCustomerAsn 1000 -MicrosoftConfigRoutingRegistryName AFRINIC | Set-AzureRmExpressRouteCircuit 
		$p = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering
		Assert-AreEqual "MicrosoftPeering" $p.Name
		Assert-AreEqual "MicrosoftPeering" $p.PeeringType
		Assert-AreEqual "44" $p.PeerASN
		Assert-AreEqual "192.171.1.0/30" $p.PrimaryPeerAddressPrefix
		Assert-AreEqual "192.171.2.0/30" $p.SecondaryPeerAddressPrefix
		Assert-AreEqual "555" $p.VlanId
		Assert-NotNull $p.MicrosoftPeeringConfig
		Assert-AreEqual "1000" $p.MicrosoftPeeringConfig.CustomerASN
		Assert-AreEqual "AFRINIC" $p.MicrosoftPeeringConfig.RoutingRegistryName
		Assert-AreEqual 2 @($p.MicrosoftPeeringConfig.AdvertisedPublicPrefixes).Count
		Assert-NotNull $p.MicrosoftPeeringConfig.AdvertisedPublicPrefixesState

		# Set a new IPv6 peering
		$primaryPeerAddressPrefixV6 = "fc00::/126";
		$secondaryPeerAddressPrefixV6 = "fc00::/126";
		$customerAsnV6 = 2000;
		$routingRegistryNameV6 = "RADB";
		$advertisedPublicPrefixesV6 = "fc02::1/128";
	    $circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Set-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 44 -PrimaryPeerAddressPrefix $primaryPeerAddressPrefixV6 -SecondaryPeerAddressPrefix $secondaryPeerAddressPrefixV6 -VlanId 555 -MicrosoftConfigAdvertisedPublicPrefixes @($advertisedPublicPrefixesV6) -MicrosoftConfigCustomerAsn $customerAsnV6 -MicrosoftConfigRoutingRegistryName $routingRegistryNameV6 -PeerAddressType IPv6 | Set-AzureRmExpressRouteCircuit 
		$p = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering
		Assert-AreEqual "MicrosoftPeering" $p.Name
		Assert-AreEqual "MicrosoftPeering" $p.PeeringType
		Assert-AreEqual "44" $p.PeerASN
		Assert-AreEqual $primaryPeerAddressPrefixV6 $p.Ipv6PeeringConfig.PrimaryPeerAddressPrefix
		Assert-AreEqual $secondaryPeerAddressPrefixV6 $p.Ipv6PeeringConfig.SecondaryPeerAddressPrefix
		Assert-AreEqual "555" $p.VlanId
		Assert-NotNull $p.Ipv6PeeringConfig.MicrosoftPeeringConfig
		Assert-AreEqual $customerAsnV6 $p.Ipv6PeeringConfig.MicrosoftPeeringConfig.CustomerASN
		Assert-AreEqual $routingRegistryNameV6 $p.Ipv6PeeringConfig.MicrosoftPeeringConfig.RoutingRegistryName
		Assert-AreEqual 1 @($p.Ipv6PeeringConfig.MicrosoftPeeringConfig.AdvertisedPublicPrefixes).Count
		Assert-NotNull $p.Ipv6PeeringConfig.MicrosoftPeeringConfig.AdvertisedPublicPrefixesState
		
		# List peering
		$listPeering = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig
		Assert-AreEqual 1 @($listPeering).Count

		$deletePeering = Remove-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -ExpressRouteCircuit $circuit -PeerAddressType All | Set-AzureRmExpressRouteCircuit 

		# List peering
		$circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname 
		$listPeering = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig
		Assert-AreEqual 0 @($listPeering).Count

		# Set a new IPv6 peering
		$primaryPeerAddressPrefixV6 = "fc00::/126";
		$secondaryPeerAddressPrefixV6 = "fc00::/126";
		$customerAsnV6 = 2000;
		$routingRegistryNameV6 = "RADB";
		$advertisedPublicPrefixesV6 = "fc02::1/128";
		$circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Add-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 44 -PrimaryPeerAddressPrefix $primaryPeerAddressPrefixV6 -SecondaryPeerAddressPrefix $secondaryPeerAddressPrefixV6 -VlanId 555 -MicrosoftConfigAdvertisedPublicPrefixes @($advertisedPublicPrefixesV6) -MicrosoftConfigCustomerAsn $customerAsnV6 -MicrosoftConfigRoutingRegistryName $routingRegistryNameV6 -PeerAddressType IPv6 | Set-AzureRmExpressRouteCircuit 
		$p = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering
		Assert-AreEqual "MicrosoftPeering" $p.Name
		Assert-AreEqual "MicrosoftPeering" $p.PeeringType
		Assert-AreEqual "44" $p.PeerASN
		Assert-AreEqual $primaryPeerAddressPrefixV6 $p.Ipv6PeeringConfig.PrimaryPeerAddressPrefix
		Assert-AreEqual $secondaryPeerAddressPrefixV6 $p.Ipv6PeeringConfig.SecondaryPeerAddressPrefix
		Assert-AreEqual "555" $p.VlanId
		Assert-NotNull $p.Ipv6PeeringConfig.MicrosoftPeeringConfig
		Assert-AreEqual $customerAsnV6 $p.Ipv6PeeringConfig.MicrosoftPeeringConfig.CustomerASN
		Assert-AreEqual $routingRegistryNameV6 $p.Ipv6PeeringConfig.MicrosoftPeeringConfig.RoutingRegistryName
		Assert-AreEqual 1 @($p.Ipv6PeeringConfig.MicrosoftPeeringConfig.AdvertisedPublicPrefixes).Count
		Assert-NotNull $p.Ipv6PeeringConfig.MicrosoftPeeringConfig.AdvertisedPublicPrefixesState

		# Delete Circuit
		$delete = Remove-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force
		Assert-AreEqual true $delete
		    
        $list = Get-AzureRmExpressRouteCircuit -ResourceGroupName $rgname
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
Tests ExpressRouteCircuitAuthorizationCRUD.
#>
function Test-ExpressRouteCircuitAuthorizationCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $circuitName = Get-ResourceName
	$authorizationName = "testkey"
    $rglocation = Get-ProviderLocation ResourceManagement
    $location = Get-ProviderLocation "Microsoft.Network/expressRouteCircuits" "Brazil South"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation
    
        # Create the ExpressRouteCircuit with authorization
		$authorization = New-AzureRmExpressRouteCircuitAuthorization -Name $authorizationName
		$circuit = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 500 -Authorization $authorization
    
        #verification
        Assert-AreEqual $rgName $circuit.ResourceGroupName
        Assert-AreEqual $circuitName $circuit.Name
        Assert-NotNull $circuit.Location
        Assert-NotNull $circuit.Etag
        Assert-AreEqual 1 @($circuit.Authorizations).Count
        Assert-AreEqual "Standard_MeteredData" $circuit.Sku.Name
        Assert-AreEqual "Standard" $circuit.Sku.Tier
        Assert-AreEqual "MeteredData" $circuit.Sku.Family
        Assert-AreEqual "equinix" $circuit.ServiceProviderProperties.ServiceProviderName
        Assert-AreEqual "Silicon Valley" $circuit.ServiceProviderProperties.PeeringLocation
        Assert-AreEqual "500" $circuit.ServiceProviderProperties.BandwidthInMbps
		
		# Verify the authorization
		Assert-AreEqual $authorizationName $circuit.Authorizations[0].Name
		

		# get authorization
		#$a = $circuit | Get-AzureRmExpressRouteCircuitAuthorization -Name $authorizationName
		#Assert-AreEqual $authorizationName $a.Name

		# add a new authorization
		#$circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Add-AzureRmExpressRouteCircuitAuthorization -Name "testkey2" | Set-AzureRmExpressRouteCircuit

		#$a = $circuit | Get-AzureRmExpressRouteCircuitAuthorization -Name "testkey2"
		#Assert-AreEqual "testkey2" $a.Name
		

		#$listAuthorization = $circuit | Get-AzureRmExpressRouteCircuitAuthorization
		#Assert-AreEqual 2 @($listAuthorization).Count

        # Delete Circuit
        $delete = Remove-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force
        Assert-AreEqual true $delete
		    
        $list = Get-AzureRmExpressRouteCircuit -ResourceGroupName $rgname
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
Tests ExpressRouteCircuitConnectionCRUD.
#>
function Test-ExpressRouteCircuitConnectionCRUD
{
	$initCircuitName = Get-ResourceName
    $peerCircuitName = Get-ResourceName
    $rgname = Get-ResourceGroupName
    $resourceTypeParent = "Microsoft.Network/expressRouteCircuits"
    $rglocation = Get-ProviderLocation $resourceTypeParent "Brazil South"
    $connectionName = Get-ResourceName
    $addressPrefix = "30.0.0.0/29"
	

	try
	{
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation
    
        # Create the initiating ExpressRouteCircuit with peering
        $initpeering = New-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -PeeringType AzurePrivatePeering -PeerASN 100 -PrimaryPeerAddressPrefix "192.168.1.0/30" -SecondaryPeerAddressPrefix "192.168.2.0/30" -VlanId 22
        $initckt = New-AzureRmExpressRouteCircuit -Name $initCircuitName -Location $rglocation -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 1000 -Peering $initpeering
		

        #Get Express Route Circuit Resource
		$initckt = Get-AzureRmExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
		$initckt

        #verification
        Assert-AreEqual $rgName $initckt.ResourceGroupName
        Assert-AreEqual $initCircuitName $initckt.Name
        Assert-NotNull $initckt.Location
        Assert-NotNull $initckt.Etag
        Assert-AreEqual 1 @($initckt.Peerings).Count
        Assert-AreEqual "Standard_MeteredData" $initckt.Sku.Name
        Assert-AreEqual "Standard" $initckt.Sku.Tier
        Assert-AreEqual "MeteredData" $initckt.Sku.Family
        Assert-AreEqual "equinix" $initckt.ServiceProviderProperties.ServiceProviderName
        Assert-AreEqual "Silicon Valley" $initckt.ServiceProviderProperties.PeeringLocation
        Assert-AreEqual "1000" $initckt.ServiceProviderProperties.BandwidthInMbps

        # Create the Peer ExpressRouteCircuit with peering
        $peerpeering = New-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -PeeringType AzurePrivatePeering -PeerASN 200 -PrimaryPeerAddressPrefix "192.168.3.0/30" -SecondaryPeerAddressPrefix "192.168.4.0/30" -VlanId 44
        $peerckt = New-AzureRmExpressRouteCircuit -Name $peerCircuitName -Location $rglocation -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Chicago" -BandwidthInMbps 1000 -Peering $peerpeering
		

        #Get Express Route Circuit Resource
		$peerckt = Get-AzureRmExpressRouteCircuit -Name $peerCircuitName -ResourceGroupName $rgname
		$peerckt

        #verification
        Assert-AreEqual $rgName $peerckt.ResourceGroupName
        Assert-AreEqual $peerCircuitName $peerckt.Name
        Assert-NotNull $peerckt.Location
        Assert-NotNull $peerckt.Etag
        Assert-AreEqual 1 @($peerckt.Peerings).Count
        Assert-AreEqual "Standard_MeteredData" $peerckt.Sku.Name
        Assert-AreEqual "Standard" $peerckt.Sku.Tier
        Assert-AreEqual "MeteredData" $peerckt.Sku.Family
        Assert-AreEqual "equinix" $peerckt.ServiceProviderProperties.ServiceProviderName
        Assert-AreEqual "Chicago" $peerckt.ServiceProviderProperties.PeeringLocation
        Assert-AreEqual "1000" $peerckt.ServiceProviderProperties.BandwidthInMbps

		#Create the circuit connection Resource
		Add-AzureRmExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initckt -PeerExpressRouteCircuitPeering $peerckt.Peerings[0].Id -AddressPrefix $addressPrefix

		#Set on Express Route Circuit
		Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $initckt

		#Get Express Route Circuit Resource
		$initckt = Get-AzureRmExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
		$initckt

		#Verify Circuit Connection fields
		Assert-AreEqual $connectionName $initckt.Peerings[0].Connections[0].Name
		Assert-AreEqual "Succeeded" $initckt.Peerings[0].Connections[0].ProvisioningState
		Assert-AreEqual "Connected" $initckt.Peerings[0].Connections[0].CircuitConnectionStatus
        Assert-AreEqual 1 $initckt.Peerings[0].Connections.Count

		#Get Express Route Circuit Resource
		$initckt = Get-AzureRmExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname

		#Delete the circuit connection Resource
		Remove-AzureRmExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initckt

		#Set on Express Route Circuit
		Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $initckt

		#Get Express Route Circuit Resource
		$initckt = Get-AzureRmExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
		$initckt

		#Verify Circuit Connection does not exist
		Assert-AreEqual 0 $initckt.Peerings[0].Connections.Count

        # Delete Circuits
        $deleteinit = Remove-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -name $initCircuitName -PassThru -Force
        Assert-AreEqual true $deleteinit

        $deletepeer = Remove-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -name $peerCircuitName -PassThru -Force
        Assert-AreEqual true $deletepeer
		    
        $list = Get-AzureRmExpressRouteCircuit -ResourceGroupName $rgname
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
Tests ExpressRouteCircuit Peering with RouteFilter
#>
function Test-ExpressRouteCircuitPeeringWithRouteFilter
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
    $location = Get-ProviderLocation "Microsoft.Network/expressRouteCircuits"
    $ruleName = Get-ResourceName
    $filterName = Get-ResourceName
    $circuitName = Get-ResourceName
    $peeringName = "MicrosoftPeering"

    try
    {
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation

        $rule = New-AzureRmRouteFilterRuleConfig -Name $ruleName -Access "Allow" -RouteFilterRuleType "Community" -CommunityList "12076:5010" -Force
        Assert-AreEqual $ruleName $rule.Name

        $filter = New-AzureRmRouteFilter -ResourceGroupName $rgname -Name $filterName -Location $location -Rule $rule -Force
        Assert-AreEqual $filterName $filter.Name
        Assert-AreEqual 1 @($filter.Rules).Count
        Assert-AreEqual $ruleName $filter.Rules[0].Name
        Assert-AreEqual $true $filter.Rules[0].Id.EndsWith($ruleName)

        $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name $peeringName -RouteFilter $filter -PeeringType $peeringName -PeerASN 33 -PrimaryPeerAddressPrefix "192.171.1.0/30" -SecondaryPeerAddressPrefix "192.171.2.0/30" -VlanId 224 -MicrosoftConfigAdvertisedPublicPrefixes @("11.2.3.4/30", "12.2.3.4/30") -MicrosoftConfigCustomerAsn 1000 -MicrosoftConfigRoutingRegistryName "AFRINIC" -LegacyMode $true
        Assert-AreEqual $peeringName $peering.Name
        Assert-NotNull $peering.RouteFilter
        Assert-AreEqual $true $peering.RouteFilter.Id.EndsWith($filterName) 

        $circuit = New-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -Name $circuitName -Location $location -Peering $peering -SkuTier "Premium" -SkuFamily "MeteredData" -ServiceProviderName "equinix" -PeeringLocation "Atlanta" -BandwidthInMbps 1000
        Assert-AreEqual $circuitName $circuit.Name
        Assert-AreEqual 1 @($circuit.Peerings).Count
        Assert-AreEqual $peeringName $circuit.Peerings[0].Name
        Assert-AreEqual $true $circuit.Peerings[0].Id.EndsWith($peeringName)

        $deletion = Remove-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -Name $circuitName -PassThru -Force
        Assert-AreEqual $true $deletion
        Assert-ThrowsLike { Get-AzureRmExpressRouteCircuit -ResourceGroupName $rgname -Name $circuitName } "*${circuitName}*not found*"

        $deletion = Remove-AzureRmRouteFilter -ResourceGroupName $rgname -Name $filterName -PassThru -Force
        Assert-AreEqual $true $deletion
        Assert-ThrowsLike { Get-AzureRmRouteFilter -ResourceGroupName $rgname -Name $filterName } "*${filterName}*not found*"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
