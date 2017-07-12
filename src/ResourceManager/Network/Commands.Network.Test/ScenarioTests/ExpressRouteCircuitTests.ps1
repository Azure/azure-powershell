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
Tests ExpressRouteCircuitCRUD.
#>
function Test-ExpressRouteBGPServiceCommunities
{
	$communities = Get-AzureRmBgpServiceCommunity

	Assert-NotNull $communities
	Assert-NotNull $communities[0].BgpCommunities
	Assert-AreEqual true $communities[0].BgpCommunities[0].IsAuthorizedToUse
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
    $rglocation = "brazilSouth"
    $resourceTypeParent = "Microsoft.Network/expressRouteCircuits"
    $location = "brazilSouth"
    try 
    {
      # Create the resource group
      $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation
      
      # Create the ExpressRouteCircuit
	  $circuit = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 500 -AllowClassicOperations $true;
      
      $circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname
      # set
      $circuit.AllowClassicOperations = $false
      $circuit = Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $circuit
	  
	  		$actual = Get-AzureRmExpressRouteCircuitStats -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name 
			Assert-AreEqual $actual.PrimaryBytesIn 0
			

	  #move
	  Move-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname -Location $location -ServiceKey $circuit.ServiceKey -Force
            
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
Tests ExpressRouteCircuitCRUD.
#>
function Test-ExpressRouteCircuitCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $circuitName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/expressRouteCircuits"
    $location = Get-ProviderLocation $resourceTypeParent
    $location = "brazilSouth"
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

      $getCircuit = Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $getCircuit 
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
    $resourceTypeParent = "Microsoft.Network/expressRouteCircuits"
    $location = Get-ProviderLocation $resourceTypeParent
    $location = "brazilSouth"
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
	$rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/expressRouteCircuits"
    $location = Get-ProviderLocation $resourceTypeParent
    $location = "brazilSouth"
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation    
        # Create the ExpressRouteCircuit with peering
        $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 33 -PrimaryPeerAddressPrefix "192.168.1.0/30" -SecondaryPeerAddressPrefix "192.168.2.0/30" -VlanId 223 -MicrosoftConfigAdvertisedPublicPrefixes @("11.2.3.4/30", "12.2.3.4/30") -MicrosoftConfigCustomerAsn 1000 -MicrosoftConfigRoutingRegistryName AFRINIC -LegacyMode $true 
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
		Assert-AreEqual "192.168.1.0/30" $circuit.Peerings[0].PrimaryPeerAddressPrefix
		Assert-AreEqual "192.168.2.0/30" $circuit.Peerings[0].SecondaryPeerAddressPrefix
		Assert-AreEqual "223" $circuit.Peerings[0].VlanId
		Assert-NotNull $circuit.Peerings[0].MicrosoftPeeringConfig
		Assert-AreEqual "1000" $circuit.Peerings[0].MicrosoftPeeringConfig.CustomerASN
		Assert-AreEqual "AFRINIC" $circuit.Peerings[0].MicrosoftPeeringConfig.RoutingRegistryName
		Assert-AreEqual 2 @($circuit.Peerings[0].MicrosoftPeeringConfig.AdvertisedPublicPrefixes).Count
		Assert-NotNull $circuit.Peerings[0].MicrosoftPeeringConfig.AdvertisedPublicPrefixesState

		# get peering
		$p = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering
		Assert-AreEqual "MicrosoftPeering" $p.Name
		Assert-AreEqual "MicrosoftPeering" $p.PeeringType
		Assert-AreEqual "192.168.1.0/30" $p.PrimaryPeerAddressPrefix
		Assert-AreEqual "192.168.2.0/30" $p.SecondaryPeerAddressPrefix
		Assert-AreEqual "223" $p.VlanId
		Assert-NotNull $p.MicrosoftPeeringConfig
		Assert-AreEqual "1000" $p.MicrosoftPeeringConfig.CustomerASN
		Assert-AreEqual "AFRINIC" $p.MicrosoftPeeringConfig.RoutingRegistryName
		Assert-AreEqual 2 @($p.MicrosoftPeeringConfig.AdvertisedPublicPrefixes).Count
		Assert-NotNull $p.MicrosoftPeeringConfig.AdvertisedPublicPrefixesState

		# List peering
		$listPeering = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig
		Assert-AreEqual 1 @($listPeering).Count

		# Set a new IPv4 peering
	    $circuit = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Set-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 44 -PrimaryPeerAddressPrefix "192.168.1.0/30" -SecondaryPeerAddressPrefix "192.168.2.0/30" -VlanId 555 -MicrosoftConfigAdvertisedPublicPrefixes @("11.2.3.4/30", "12.2.3.4/30") -MicrosoftConfigCustomerAsn 1000 -MicrosoftConfigRoutingRegistryName AFRINIC | Set-AzureRmExpressRouteCircuit 
		$p = $circuit | Get-AzureRmExpressRouteCircuitPeeringConfig -Name MicrosoftPeering
		Assert-AreEqual "MicrosoftPeering" $p.Name
		Assert-AreEqual "MicrosoftPeering" $p.PeeringType
		Assert-AreEqual "44" $p.PeerASN
		Assert-AreEqual "192.168.1.0/30" $p.PrimaryPeerAddressPrefix
		Assert-AreEqual "192.168.2.0/30" $p.SecondaryPeerAddressPrefix
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
	$rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/expressRouteCircuits"
    $location = Get-ProviderLocation $resourceTypeParent
    $location = "brazilSouth"
	$authorizationName = "testkey"

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

