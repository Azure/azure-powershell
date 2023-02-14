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
    $communities = Get-AzBgpServiceCommunity

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
    $rgname = Get-ResourceGroupName
    $ruleName = Get-ResourceName
    $filterName = Get-ResourceName
    $location = Get-ProviderLocation "Microsoft.Network/routeFilters" "westcentralus"

    try
    {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location

      # Create the route filter
      $job = New-AzRouteFilter -Name $filterName -ResourceGroupName $rgname -Location $location -Force -AsJob
      $job | Wait-Job
      $filter = $job | Receive-Job

      #verification
      Assert-AreEqual $rgName $filter.ResourceGroupName
      Assert-AreEqual $filterName $filter.Name
      Assert-NotNull $filter.Location
      Assert-AreEqual 0 @($filter.Rules).Count

      $rule = New-AzRouteFilterRuleConfig -Name $ruleName -Access Allow -RouteFilterRuleType Community -CommunityList "12076:5010" -Force
      $filter = Get-AzRouteFilter -Name $filterName -ResourceGroupName $rgname
      $filter.Rules.Add($rule)
      $job = Set-AzRouteFilter -RouteFilter $filter -Force -AsJob
      $job | Wait-Job
      $filter = $job | Receive-Job

      #verification
      Assert-AreEqual $rgName $filter.ResourceGroupName
      Assert-AreEqual $filterName $filter.Name
      Assert-NotNull $filter.Location
      Assert-AreEqual 1 @($filter.Rules).Count

      $filter = Get-AzRouteFilter -Name $filterName -ResourceGroupName $rgname
      $filter.Rules.Clear()
      $filter = Set-AzRouteFilter -RouteFilter $filter -Force

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
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation
      
      # Create the ExpressRouteCircuit
      $job = New-AzExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 500 -AllowClassicOperations $true -AsJob
      $job | Wait-Job
      $circuit = $job | Receive-Job
      
      $circuit = Get-AzExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname
      # set
      $circuit.AllowClassicOperations = $false
      $circuit = Set-AzExpressRouteCircuit -ExpressRouteCircuit $circuit

      $actual = Get-AzExpressRouteCircuitStats -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name 
      Assert-AreEqual $actual.PrimaryBytesIn 0

      #move
      $job = Move-AzExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname -Location $location -ServiceKey $circuit.ServiceKey -Force -AsJob
      $job | Wait-Job

      # Delete Circuit
      $job = Remove-AzExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force -AsJob
      $job | Wait-Job
      $delete = $job | Receive-Job
      Assert-AreEqual true $delete

      # Check that the circuit was deleted
      $list = Get-AzExpressRouteCircuit -ResourceGroupName $rgname
      Assert-Null ($list | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $circuitName });

      $list = Get-AzExpressRouteCircuit -ResourceGroupName "*"
      Assert-Null ($list | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $circuitName });

      $list = Get-AzExpressRouteCircuit -Name "*"
      Assert-Null ($list | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $circuitName });

      $list = Get-AzExpressRouteCircuit -ResourceGroupName "*" -Name "*"
      Assert-Null ($list | Where-Object { $_.ResourceGroupName -eq $rgname -and $_.Name -eq $circuitName });
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
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation
      
      # Create the ExpressRouteCircuit
        $circuit = New-AzExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 500;
      
      # get Circuit
      $getCircuit = Get-AzExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname

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
      $list = Get-AzExpressRouteCircuit -ResourceGroupName $rgname
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

      $job = Set-AzExpressRouteCircuit -ExpressRouteCircuit $getCircuit -AsJob
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
      $delete = Remove-AzExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force
      Assert-AreEqual true $delete
              
      $list = Get-AzExpressRouteCircuit -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation
    
        # Create the ExpressRouteCircuit with peering
        $peering = New-AzExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -PeeringType AzurePrivatePeering -PeerASN 100 -PrimaryPeerAddressPrefix "192.168.1.0/30" -SecondaryPeerAddressPrefix "192.168.2.0/30" -VlanId 22
        $circuit = New-AzExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 1000 -Peering $peering
    
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

        $stats = Get-AzExpressRouteCircuitStats -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name -PeeringType AzurePrivatePeering
        Assert-AreEqual $stats.PrimaryBytesIn 0

        Get-AzExpressRouteCircuitARPTable -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name -PeeringType AzurePrivatePeering -DevicePath Primary
        Get-AzExpressRouteCircuitRouteTableSummary -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name -PeeringType AzurePrivatePeering -DevicePath Primary
        Get-AzExpressRouteCircuitRouteTable -ResourceGroupName $rgname -ExpressRouteCircuitName $circuit.Name -PeeringType AzurePrivatePeering -DevicePath Primary
        
        # get peering
        $p = $circuit | Get-AzExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering
        Assert-AreEqual "AzurePrivatePeering" $p.Name
        Assert-AreEqual "AzurePrivatePeering" $p.PeeringType
        Assert-AreEqual "100" $p.PeerASN
        Assert-AreEqual "192.168.1.0/30" $p.PrimaryPeerAddressPrefix
        Assert-AreEqual "192.168.2.0/30" $p.SecondaryPeerAddressPrefix
        Assert-AreEqual "22" $p.VlanId
        Assert-Null $p.MicrosoftPeeringConfig

        # List peering
        $listPeering = $circuit | Get-AzExpressRouteCircuitPeeringConfig
        Assert-AreEqual 1 @($listPeering).Count

        # Delete Circuit
        $delete = Remove-AzExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force
        Assert-AreEqual true $delete
            
        $list = Get-AzExpressRouteCircuit -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation    
        # Create the ExpressRouteCircuit with peering
        $peering = New-AzExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 33 -PrimaryPeerAddressPrefix "192.171.1.0/30" -SecondaryPeerAddressPrefix "192.171.2.0/30" -VlanId 224 -MicrosoftConfigAdvertisedPublicPrefixes @("11.2.3.4/30", "12.2.3.4/30") -MicrosoftConfigCustomerAsn 1000 -MicrosoftConfigRoutingRegistryName AFRINIC -LegacyMode $true 
        $circuit = New-AzExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Premium -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 1000 -Peering $peering	

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
        $rule = New-AzRouteFilterRuleConfig -Name $ruleName -Access Allow -RouteFilterRuleType Community -CommunityList "12076:5010" -Force	
        $filter = New-AzRouteFilter -Name $filterName -ResourceGroupName $rgname -Location $location -Rule $rule -Force
        
        # update circuit with filter 
        $circuit = Get-AzExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname
        $circuit.Peerings[0].RouteFilter = $filter
        Set-AzExpressRouteCircuit -ExpressRouteCircuit $circuit

        # get peering
        $p = $circuit | Get-AzExpressRouteCircuitPeeringConfig -Name MicrosoftPeering
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
        $listPeering = $circuit | Get-AzExpressRouteCircuitPeeringConfig
        Assert-AreEqual 1 @($listPeering).Count

        # Set a new IPv4 peering
        $circuit = Get-AzExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Set-AzExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 44 -PrimaryPeerAddressPrefix "192.171.1.0/30" -SecondaryPeerAddressPrefix "192.171.2.0/30" -VlanId 555 -MicrosoftConfigAdvertisedPublicPrefixes @("11.2.3.4/30", "12.2.3.4/30") -MicrosoftConfigCustomerAsn 1000 -MicrosoftConfigRoutingRegistryName AFRINIC | Set-AzExpressRouteCircuit 
        $p = $circuit | Get-AzExpressRouteCircuitPeeringConfig -Name MicrosoftPeering
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
        $circuit = Get-AzExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Set-AzExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 44 -PrimaryPeerAddressPrefix $primaryPeerAddressPrefixV6 -SecondaryPeerAddressPrefix $secondaryPeerAddressPrefixV6 -VlanId 555 -MicrosoftConfigAdvertisedPublicPrefixes @($advertisedPublicPrefixesV6) -MicrosoftConfigCustomerAsn $customerAsnV6 -MicrosoftConfigRoutingRegistryName $routingRegistryNameV6 -PeerAddressType IPv6 | Set-AzExpressRouteCircuit 
        $p = $circuit | Get-AzExpressRouteCircuitPeeringConfig -Name MicrosoftPeering
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
        $listPeering = $circuit | Get-AzExpressRouteCircuitPeeringConfig
        Assert-AreEqual 1 @($listPeering).Count

        $deletePeering = Remove-AzExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -ExpressRouteCircuit $circuit -PeerAddressType All | Set-AzExpressRouteCircuit 

        # List peering
        $circuit = Get-AzExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname 
        $listPeering = $circuit | Get-AzExpressRouteCircuitPeeringConfig
        Assert-AreEqual 0 @($listPeering).Count

        # Set a new IPv6 peering
        $primaryPeerAddressPrefixV6 = "fc00::/126";
        $secondaryPeerAddressPrefixV6 = "fc00::/126";
        $customerAsnV6 = 2000;
        $routingRegistryNameV6 = "RADB";
        $advertisedPublicPrefixesV6 = "fc02::1/128";
        $circuit = Get-AzExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Add-AzExpressRouteCircuitPeeringConfig -Name MicrosoftPeering -PeeringType MicrosoftPeering -PeerASN 44 -PrimaryPeerAddressPrefix $primaryPeerAddressPrefixV6 -SecondaryPeerAddressPrefix $secondaryPeerAddressPrefixV6 -VlanId 555 -MicrosoftConfigAdvertisedPublicPrefixes @($advertisedPublicPrefixesV6) -MicrosoftConfigCustomerAsn $customerAsnV6 -MicrosoftConfigRoutingRegistryName $routingRegistryNameV6 -PeerAddressType IPv6 | Set-AzExpressRouteCircuit 
        $p = $circuit | Get-AzExpressRouteCircuitPeeringConfig -Name MicrosoftPeering
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
        $delete = Remove-AzExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force
        Assert-AreEqual true $delete
            
        $list = Get-AzExpressRouteCircuit -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation
    
        # Create the ExpressRouteCircuit with authorization
        $authorization = New-AzExpressRouteCircuitAuthorization -Name $authorizationName
        $circuit = New-AzExpressRouteCircuit -Name $circuitName -Location $location -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 500 -Authorization $authorization
    
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
        $a = $circuit | Get-AzExpressRouteCircuitAuthorization -Name $authorizationName
        Assert-AreEqual $authorizationName $a.Name

        # add a new authorization
        $circuit = Get-AzExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname | Add-AzExpressRouteCircuitAuthorization -Name "testkey2" | Set-AzExpressRouteCircuit

        $a = $circuit | Get-AzExpressRouteCircuitAuthorization -Name "testkey2"
        Assert-AreEqual "testkey2" $a.Name
        

        $listAuthorization = $circuit | Get-AzExpressRouteCircuitAuthorization
        Assert-AreEqual 2 @($listAuthorization).Count

        # Delete Circuit
        $delete = Remove-AzExpressRouteCircuit -ResourceGroupName $rgname -name $circuitName -PassThru -Force
        Assert-AreEqual true $delete
            
        $list = Get-AzExpressRouteCircuit -ResourceGroupName $rgname
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation
    
        # Create the initiating ExpressRouteCircuit with peering
        $initpeering = New-AzExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -PeeringType AzurePrivatePeering -PeerASN 100 -PrimaryPeerAddressPrefix "192.168.1.0/30" -SecondaryPeerAddressPrefix "192.168.2.0/30" -VlanId 22
        $initckt = New-AzExpressRouteCircuit -Name $initCircuitName -Location $rglocation -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 1000 -Peering $initpeering
        

        #Get Express Route Circuit Resource
        $initckt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
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
        $peerpeering = New-AzExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -PeeringType AzurePrivatePeering -PeerASN 200 -PrimaryPeerAddressPrefix "192.168.3.0/30" -SecondaryPeerAddressPrefix "192.168.4.0/30" -VlanId 44
        $peerckt = New-AzExpressRouteCircuit -Name $peerCircuitName -Location $rglocation -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Chicago" -BandwidthInMbps 1000 -Peering $peerpeering
        

        #Get Express Route Circuit Resource
        $peerckt = Get-AzExpressRouteCircuit -Name $peerCircuitName -ResourceGroupName $rgname
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
        Add-AzExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initckt -PeerExpressRouteCircuitPeering $peerckt.Peerings[0].Id -AddressPrefix $addressPrefix -AuthorizationKey test

        #Set on Express Route Circuit
        Set-AzExpressRouteCircuit -ExpressRouteCircuit $initckt

        #Get Express Route Circuit Resource
        $initckt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
        $initckt

        #Verify Circuit Connection fields
        Assert-AreEqual $connectionName $initckt.Peerings[0].Connections[0].Name
        Assert-AreEqual "Succeeded" $initckt.Peerings[0].Connections[0].ProvisioningState
        Assert-AreEqual "Connected" $initckt.Peerings[0].Connections[0].CircuitConnectionStatus
        Assert-AreEqual 1 $initckt.Peerings[0].Connections.Count

        #Get Express Route Circuit Resource
        $initckt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname

        #Verify Global reach enabled readonly flag
        Assert-AreEqual $true $initckt.GlobalReachEnabled

        $connection = Get-AzureRmExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initckt
        Assert-AreEqual $connectionName $connection.Name
        Assert-AreEqual "Succeeded" $connection.ProvisioningState
        Assert-AreEqual "Connected" $connection.CircuitConnectionStatus

        $connections = Get-AzureRmExpressRouteCircuitConnectionConfig -ExpressRouteCircuit $initckt
        Assert-NotNull $connections
        Assert-AreEqual 1 $connections.Count

        $initckt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
        $peerckt = Get-AzExpressRouteCircuit -Name $peerCircuitName -ResourceGroupName $rgname

        #Verify Global reach enabled readonly flag in peer circuit
        Assert-AreEqual $true $peerckt.GlobalReachEnabled

        #Verify Peer Circuit Connection fields
        Assert-AreEqual 1 $peerckt.Peerings[0].PeeredConnections.Count
        Assert-AreEqual $initckt.ServiceKey $peerckt.Peerings[0].PeeredConnections[0].Name
        Assert-AreEqual $connectionName $peerckt.Peerings[0].PeeredConnections[0].ConnectionName
        Assert-AreEqual "Succeeded" $peerckt.Peerings[0].PeeredConnections[0].ProvisioningState
        Assert-AreEqual "Connected" $peerckt.Peerings[0].PeeredConnections[0].CircuitConnectionStatus

        #Delete the circuit connection Resource
        Remove-AzExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initckt

        #Set on Express Route Circuit
        Set-AzExpressRouteCircuit -ExpressRouteCircuit $initckt

        #Get Express Route Circuit Resource
        $initckt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
        $initckt

        #Verify Global reach enabled readonly flag
        Assert-AreEqual $false $initckt.GlobalReachEnabled

        #Verify Circuit Connection does not exist
        Assert-AreEqual 0 $initckt.Peerings[0].Connections.Count

        #Get peer Express Route Circuit Resource
        $peerckt = Get-AzExpressRouteCircuit -Name $peerCircuitName -ResourceGroupName $rgname

        #Verify Global reach enabled readonly flag in peer circuit
        Assert-AreEqual $false $peerckt.GlobalReachEnabled

        #Verify peer Circuit Connection does not exist
        Assert-AreEqual 0 $peerckt.Peerings[0].PeeredConnections.Count

        Remove-AzureRmExpressRouteCircuitPeeringConfig -ExpressRouteCircuit $initckt -Name AzurePrivatePeering
        $initckt = Set-AzureRmExpressRouteCircuit -ExpressRouteCircuit $initckt

        Assert-ThrowsLike { Get-AzureRmExpressRouteCircuitConnectionConfig -ExpressRouteCircuit $initckt } "*does not exist*"
        Assert-ThrowsLike { Add-AzureRmExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initckt -PeerExpressRouteCircuitPeering $peerckt.Peerings[0].Id -AddressPrefix $addressPrefix } "*needs to be configured*"
        Assert-ThrowsLike { Remove-AzureRmExpressRouteCircuitConnectionConfig -ExpressRouteCircuit $initckt -Name $connectionName } "*does not exist*"

        # Delete Circuits
        $deleteinit = Remove-AzExpressRouteCircuit -ResourceGroupName $rgname -name $initCircuitName -PassThru -Force
        Assert-AreEqual true $deleteinit

        $deletepeer = Remove-AzExpressRouteCircuit -ResourceGroupName $rgname -name $peerCircuitName -PassThru -Force
        Assert-AreEqual true $deletepeer
            
        $list = Get-AzExpressRouteCircuit -ResourceGroupName $rgname
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
function Test-ExpressRouteCircuitConnectionIPv6CRUD
{
    
    #Generate random names for testing
    $initCircuitName = Get-ResourceName

    $rgname = Get-ResourceGroupName
    $resourceTypeParent = "Microsoft.Network/expressRouteCircuits"

    $rglocation = Get-ProviderLocation $resourceTypeParent "eastus2euap"

    $primaryPeerAddressPrefix = "192.168.16.252/30"
    $secondaryPeerAddressPrefix` = "192.168.18.252/30"

    $primaryPeerAddressPrefixV6 = "aa:bb:cc::/126"
    $secondaryPeerAddressPrefixV6 = "bb:cc:dd::/126"

    #$peeringLocation = ""
    $peeringLocation = "Boydton cbn"
    $serviceProviderName = "bvtcustomerixp01"

    try
    {

        # 
        # Create the resource group
        #
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation
    
        # Create the initiating ExpressRouteCircuit with peering
        $initpeering = New-AzExpressRouteCircuitPeeringConfig `
        -Name AzurePrivatePeering `
        -PeeringType AzurePrivatePeering `
        -PeerASN 100 `
        -PrimaryPeerAddressPrefix $primaryPeerAddressPrefix `
        -SecondaryPeerAddressPrefix $secondaryPeerAddressPrefix `
        -VlanId 22

        $initCkt = New-AzExpressRouteCircuit `
        -Name $initCircuitName `
        -Location $rglocation `
        -ResourceGroupName $rgname `
        -SkuTier Standard `
        -SkuFamily MeteredData `
        -ServiceProviderName $serviceProviderName `
        -PeeringLocation $peeringLocation `
        -BandwidthInMbps 1000 `
        -Peering $initpeering
        

        #Get Express Route Circuit Resource
        $initCkt

        #verification
        Assert-AreEqual $rgName $initCkt.ResourceGroupName
        Assert-AreEqual $initCircuitName $initCkt.Name
        Assert-NotNull $initCkt.Location
        Assert-NotNull $initCkt.Etag
        Assert-AreEqual 1 @($initCkt.Peerings).Count
        Assert-AreEqual "Standard_MeteredData" $initCkt.Sku.Name
        Assert-AreEqual "Standard" $initCkt.Sku.Tier
        Assert-AreEqual "MeteredData" $initCkt.Sku.Family
        Assert-AreEqual $serviceProviderName $initCkt.ServiceProviderProperties.ServiceProviderName
        Assert-AreEqual $peeringLocation $initCkt.ServiceProviderProperties.PeeringLocation
        Assert-AreEqual "1000" $initCkt.ServiceProviderProperties.BandwidthInMbps


        #Create Peer Circuit

        $peerPrimaryPeerAddressPrefix = "192.168.26.252/30"
        $peerSecondaryPeerAddressPrefix` = "192.168.28.252/30"

        $peerPrimaryPeerAddressPrefixV6 = "bb:cc::/126"
        $peerSecondaryPeerAddressPrefixV6 = "bb:cd::/126"

        $peerPeeringLocation = "Boydton cbn"
        $peerServiceProviderName = "bvtazureixp01"

        $peerCircuitName = Get-ResourceName
          # Create the initiating ExpressRouteCircuit with peering
        $peerCircuitPeering = New-AzExpressRouteCircuitPeeringConfig `
        -Name AzurePrivatePeering `
        -PeeringType AzurePrivatePeering `
        -PeerASN 100 `
        -PrimaryPeerAddressPrefix $peerPrimaryPeerAddressPrefix `
        -SecondaryPeerAddressPrefix $peerSecondaryPeerAddressPrefix `
        -VlanId 22

        $peerCkt = New-AzExpressRouteCircuit `
        -Name $peerCircuitName `
        -Location $rglocation `
        -ResourceGroupName $rgname `
        -SkuTier Standard `
        -SkuFamily MeteredData `
        -ServiceProviderName $peerServiceProviderName `
        -PeeringLocation $peerPeeringLocation `
        -BandwidthInMbps 1000 `
        -Peering $peerCircuitPeering
        
        #Get Peer Express Route Circuit Resource

        $peerCkt = Get-AzExpressRouteCircuit -Name $peerCircuitName -ResourceGroupName $rgname
        $peerckt

        #verification
        Assert-AreEqual $rgName $peerCkt.ResourceGroupName
        Assert-AreEqual $peerCircuitName $peerCkt.Name
        Assert-NotNull $peerCkt.Location
        Assert-NotNull $peerCkt.Etag
        Assert-AreEqual 1 @($peerCkt.Peerings).Count
        Assert-AreEqual "Standard_MeteredData" $peerCkt.Sku.Name
        Assert-AreEqual "Standard" $peerCkt.Sku.Tier
        Assert-AreEqual "MeteredData" $peerCkt.Sku.Family
        Assert-AreEqual $peerServiceProviderName $peerCkt.ServiceProviderProperties.ServiceProviderName
        Assert-AreEqual $peerPeeringLocation $peerCkt.ServiceProviderProperties.PeeringLocation
        Assert-AreEqual "1000" $peerCkt.ServiceProviderProperties.BandwidthInMbps
   
        $connectionName = Get-ResourceName

        $addressPrefix = "10.1.1.0/29"
        $addressPrefixv6 = "cc:dd::1/125"

        Add-AzExpressRouteCircuitConnectionConfig `
        -Name $connectionName `
        -ExpressRouteCircuit $initCkt `
        -PeerExpressRouteCircuitPeering $peerCkt.Peerings[0].Id `
        -AddressPrefix $addressPrefix `
        -AuthorizationKey test

        #Create IPv6 Peering
        Set-AzExpressRouteCircuitConnectionConfig `
        -Name $connectionName `
        -ExpressRouteCircuit $initCkt `
        -PeerExpressRouteCircuitPeering $peerCkt.Peerings[0].Id `
        -AddressPrefix $addressPrefixv6 `
        -AddressPrefixType IPv6

        Set-AzExpressRouteCircuit -ExpressRouteCircuit $initCkt


        $initCkt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
        $initCkt
        #Verify Circuit Connection fields
        Assert-AreEqual $connectionName $initCkt.Peerings[0].Connections[0].Name
        Assert-AreEqual "Succeeded" $initCkt.Peerings[0].Connections[0].ProvisioningState
        Assert-AreEqual "Connected" $initCkt.Peerings[0].Connections[0].CircuitConnectionStatus
        Assert-AreEqual 1 $initCkt.Peerings[0].Connections.Count

        Assert-AreEqual "Connected" $initCkt.Peerings[0].Connections[0].IPv6CircuitConnectionConfig.CircuitConnectionStatus
        Assert-AreEqual $addressPrefixv6 $initCkt.Peerings[0].Connections[0].IPv6CircuitConnectionConfig.AddressPrefix

        #Get Express Route Circuit Resource
        $initCkt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname

        #Verify Global reach enabled readonly flag
        Assert-AreEqual $true $initCkt.GlobalReachEnabled

        $connection = Get-AzExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initCkt
        Assert-AreEqual $connectionName $connection.Name
        Assert-AreEqual "Succeeded" $connection.ProvisioningState
        Assert-AreEqual "Connected" $connection.CircuitConnectionStatus

        Assert-AreEqual $addressPrefixv6 $connection.IPv6CircuitConnectionConfig.AddressPrefix
        Assert-AreEqual "Connected" $connection.IPv6CircuitConnectionConfig.CircuitConnectionStatus

        $connections = Get-AzExpressRouteCircuitConnectionConfig -ExpressRouteCircuit $initCkt
        Assert-NotNull $connections
        Assert-AreEqual 1 $connections.Count

        $peerCkt = Get-AzExpressRouteCircuit -Name $peerCircuitName -ResourceGroupName $rgname

        #Verify Global reach enabled readonly flag in peer circuit
        Assert-AreEqual $true $peerCkt.GlobalReachEnabled
        
        #Verify Peer Circuit Connection fields
        Assert-AreEqual 1 $peerCkt.Peerings[0].PeeredConnections.Count
        Assert-AreEqual $initCkt.ServiceKey $peerCkt.Peerings[0].PeeredConnections[0].Name
        Assert-AreEqual $connectionName $peerCkt.Peerings[0].PeeredConnections[0].ConnectionName
        Assert-AreEqual "Succeeded" $peerCkt.Peerings[0].PeeredConnections[0].ProvisioningState
        Assert-AreEqual "Connected" $peerCkt.Peerings[0].PeeredConnections[0].CircuitConnectionStatus

        #Delete the circuit connection Resource
        Remove-AzExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initCkt -AddressPrefixType IPv6

        #Set on Express Route Circuit
        Set-AzExpressRouteCircuit -ExpressRouteCircuit $initCkt

        #Get Express Route Circuit Resource
        $initCkt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
        $initCkt

        #Verify Global reach enabled readonly flag
        Assert-AreEqual $true $initckt.GlobalReachEnabled

        #Verify Circuit Connection does not exist
        Assert-AreEqual 1 $initckt.Peerings[0].Connections.Count

        Remove-AzExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initCkt

        #Set on Express Route Circuit
        Set-AzExpressRouteCircuit -ExpressRouteCircuit $initCkt

        #Get Express Route Circuit Resource
        $initCkt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
        $initCkt

        #Verify Global reach enabled readonly flag
        Assert-AreEqual $false $initckt.GlobalReachEnabled

        #Verify Circuit Connection does not exist
        Assert-AreEqual 0 $initckt.Peerings[0].Connections.Count

        #Get peer Express Route Circuit Resource
        $peerckt = Get-AzExpressRouteCircuit -Name $peerCircuitName -ResourceGroupName $rgname

        #Verify Global reach enabled readonly flag in peer circuit
        Assert-AreEqual $false $peerckt.GlobalReachEnabled

        #Verify peer Circuit Connection does not exist
        Assert-AreEqual 0 $peerckt.Peerings[0].PeeredConnections.Count

        #Test Deletion
        Remove-AzExpressRouteCircuitPeeringConfig -ExpressRouteCircuit $initckt -Name AzurePrivatePeering
        $initckt = Set-AzExpressRouteCircuit -ExpressRouteCircuit $initckt

        Assert-ThrowsLike { Get-AzExpressRouteCircuitConnectionConfig -ExpressRouteCircuit $initckt } "*does not exist*"
        Assert-ThrowsLike { Add-AzExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initckt -PeerExpressRouteCircuitPeering $peerckt.Peerings[0].Id -AddressPrefix $addressPrefix } "*needs to be configured*"
        Assert-ThrowsLike { Remove-AzExpressRouteCircuitConnectionConfig -ExpressRouteCircuit $initckt -Name $connectionName } "*does not exist*"

        # Delete Circuits
        $deleteinit = Remove-AzExpressRouteCircuit -ResourceGroupName $rgname -name $initCircuitName -PassThru -Force
        Assert-AreEqual true $deleteinit

        $deletepeer = Remove-AzExpressRouteCircuit -ResourceGroupName $rgname -name $peerCircuitName -PassThru -Force
        Assert-AreEqual true $deletepeer

        $list = Get-AzExpressRouteCircuit -ResourceGroupName $rgname
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
Tests ExpressRoute Global Reach creation over IPv6 peering.
With Precreated circuits
#>
function Test-ExpressRouteCircuitConnectionIPv6PrecreatedCRUD
{
    $connectionName = Get-ResourceName
    #initCircuitName
    <#
    For global reach the connections need to be in Provisioned State.
    #>

    $initCircuitName = "ParentCircuit";
    $rgName = "DO_NOT_DEL_UT_GR_RG";
    $rglocation = "North Europe"


    $serviceProviderName = "Equinix";
    $peeringLocation = "London";
    try{

        #Get Init Circuit
        <#
        Dump circuit information output :
        ================================================================================================
        SUBSCRIPTION ID: b25d654b-d9d2-4ad8-9982-32e84af77698
        SERVICE KEY: 1838cbc7-83fa-42ad-8176-ad26ae55238d
        CIRCUIT NAME: ParentCircuit
        CIRCUIT LOCATION: London
        GATEWAY MANAGER REGION: North Europe
        GATEWAY MANAGER REGION MONIKER: DB
        CIRCUIT SKU: Standard
        BANDWIDTH: 1000
        BILLING TYPE: MeteredData
        PRIMARY DEVICE: lon31-09xgmr-cis-1
        SECONDARY DEVICE: lon31-09xgmr-cis-2
        SERVICE PROVIDER: Equinix
        CIRCUIT STATE: Enabled
        NRP RESOURCE URI: https://northeurope.network.azure.com/subscriptions/b25d654b-d9d2-4ad8-9982-32e84af77698/resourceGroups/DO_NOT_DEL_UT_GR_RG/providers/Microsoft.Network/expressRouteCircuits/ParentCircuit
        #>

        $initCkt =  Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
        Assert-AreEqual $rgName $initCkt.ResourceGroupName
        Assert-AreEqual $initCircuitName $initCkt.Name
        Assert-NotNull $initCkt.Location
        Assert-NotNull $initCkt.Etag
        Assert-AreEqual 1 @($initCkt.Peerings).Count
        Assert-AreEqual "Standard_MeteredData" $initCkt.Sku.Name
        Assert-AreEqual "Standard" $initCkt.Sku.Tier
        Assert-AreEqual "MeteredData" $initCkt.Sku.Family
        Assert-AreEqual $serviceProviderName $initCkt.ServiceProviderProperties.ServiceProviderName
        Assert-AreEqual $peeringLocation $initCkt.ServiceProviderProperties.PeeringLocation
        Assert-AreEqual "1000" $initCkt.ServiceProviderProperties.BandwidthInMbps

        #Get PeerCircuit
        <#
        Dump circuit information output :
        ================================================================================================
        SUBSCRIPTION ID: b25d654b-d9d2-4ad8-9982-32e84af77698
        SERVICE KEY: 5c3ce1c3-8bbf-47b7-9b0c-97348adf3ec2
        CIRCUIT NAME: PeerCircuit
        CIRCUIT LOCATION: London2
        GATEWAY MANAGER REGION: UK South
        GATEWAY MANAGER REGION MONIKER: LN
        CIRCUIT SKU: Standard
        BANDWIDTH: 1000
        BILLING TYPE: MeteredData
        ALLOW GLOBAL REACH: False
        PRIMARY DEVICE: lon32-06gmr-cis-1
        SECONDARY DEVICE: lon32-06gmr-cis-2
        SERVICE PROVIDER: Equinix
        CIRCUIT STATE: Enabled
        NRP RESOURCE URI: https://northeurope.network.azure.com/subscriptions/b25d654b-d9d2-4ad8-9982-32e84af77698/resourceGroups/DO_NOT_DEL_UT_GR_RG/providers/Microsoft.Network/expressRouteCircuits/PeerCircuit
        #>

        $peerServiceProviderName = "Equinix"
        $peerPeeringLocation = "London2"
        $peerCircuitName = "PeerCircuit";

        $peerCkt = Get-AzExpressRouteCircuit -Name $peerCircuitName -ResourceGroupName $rgname

          #verification
        Assert-AreEqual $rgName $peerCkt.ResourceGroupName
        Assert-AreEqual $peerCircuitName $peerCkt.Name
        Assert-NotNull $peerCkt.Location
        Assert-NotNull $peerCkt.Etag
        Assert-AreEqual 1 @($peerCkt.Peerings).Count
        Assert-AreEqual "Standard_MeteredData" $peerCkt.Sku.Name
        Assert-AreEqual "Standard" $peerCkt.Sku.Tier
        Assert-AreEqual "MeteredData" $peerCkt.Sku.Family
        Assert-AreEqual $peerServiceProviderName $peerCkt.ServiceProviderProperties.ServiceProviderName
        Assert-AreEqual $peerPeeringLocation $peerCkt.ServiceProviderProperties.PeeringLocation
        Assert-AreEqual "1000" $peerCkt.ServiceProviderProperties.BandwidthInMbps

        #Create Global Reach
        $connectionName = Get-ResourceName

        $addressPrefix = "10.1.1.0/29"
        $addressPrefixv6 = "cc:dd::1/125"

        Add-AzExpressRouteCircuitConnectionConfig `
        -Name $connectionName `
        -ExpressRouteCircuit $initCkt `
        -PeerExpressRouteCircuitPeering $peerCkt.Peerings[0].Id `
        -AddressPrefix $addressPrefix `
        -AuthorizationKey test

        #Create IPv6 Peering
        Set-AzExpressRouteCircuitConnectionConfig `
        -Name $connectionName `
        -ExpressRouteCircuit $initCkt `
        -PeerExpressRouteCircuitPeering $peerCkt.Peerings[0].Id `
        -AddressPrefix $addressPrefixv6 `
        -AddressPrefixType IPv6

        Set-AzExpressRouteCircuit -ExpressRouteCircuit $initCkt


        $initCkt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
        $initCkt
        #Verify Circuit Connection fields
        Assert-AreEqual $connectionName $initCkt.Peerings[0].Connections[0].Name
        Assert-AreEqual "Succeeded" $initCkt.Peerings[0].Connections[0].ProvisioningState
        Assert-AreEqual "Connected" $initCkt.Peerings[0].Connections[0].CircuitConnectionStatus
        Assert-AreEqual 1 $initCkt.Peerings[0].Connections.Count

        Assert-AreEqual "Connected" $initCkt.Peerings[0].Connections[0].IPv6CircuitConnectionConfig.CircuitConnectionStatus
        Assert-AreEqual $addressPrefixv6 $initCkt.Peerings[0].Connections[0].IPv6CircuitConnectionConfig.AddressPrefix

        #Get Express Route Circuit Resource
        $initCkt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname

        #Verify Global reach enabled readonly flag
        Assert-AreEqual $true $initCkt.GlobalReachEnabled

        $connection = Get-AzExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initCkt
        Assert-AreEqual $connectionName $connection.Name
        Assert-AreEqual "Succeeded" $connection.ProvisioningState
        Assert-AreEqual "Connected" $connection.CircuitConnectionStatus

        Assert-AreEqual $addressPrefixv6 $connection.IPv6CircuitConnectionConfig.AddressPrefix
        Assert-AreEqual "Connected" $connection.IPv6CircuitConnectionConfig.CircuitConnectionStatus

        $connections = Get-AzExpressRouteCircuitConnectionConfig -ExpressRouteCircuit $initCkt
        Assert-NotNull $connections
        Assert-AreEqual 1 $connections.Count

        $peerCkt = Get-AzExpressRouteCircuit -Name $peerCircuitName -ResourceGroupName $rgname

        #Verify Global reach enabled readonly flag in peer circuit
        Assert-AreEqual $true $peerCkt.GlobalReachEnabled

        <#
        #Verify Peer Circuit Connection fields
        Assert-AreEqual 1 $peerCkt.Peerings[0].PeeredConnections.Count
        Assert-AreEqual $initCkt.ServiceKey $peerCkt.Peerings[0].PeeredConnections[0].Name
        Assert-AreEqual $connectionName $peerCkt.Peerings[0].PeeredConnections[0].ConnectionName
        Assert-AreEqual "Succeeded" $peerCkt.Peerings[0].PeeredConnections[0].ProvisioningState
        Assert-AreEqual "Connected" $peerCkt.Peerings[0].PeeredConnections[0].CircuitConnectionStatus
        #>

        #Delete the circuit connection Resource
        Remove-AzExpressRouteCircuitConnectionConfig -Name $connectionName -ExpressRouteCircuit $initCkt

        #Set on Express Route Circuit
        Set-AzExpressRouteCircuit -ExpressRouteCircuit $initCkt

        #Get Express Route Circuit Resource
        $initCkt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
        $initCkt

        #Verify Global reach enabled readonly flag
        Assert-AreEqual $false $initckt.GlobalReachEnabled

        #Verify Circuit Connection does not exist
        Assert-AreEqual 0 $initckt.Peerings[0].Connections.Count

        #Get peer Express Route Circuit Resource
        $peerckt = Get-AzExpressRouteCircuit -Name $peerCircuitName -ResourceGroupName $rgname

        #Verify Global reach enabled readonly flag in peer circuit
        Assert-AreEqual $false $peerckt.GlobalReachEnabled

        #Verify peer Circuit Connection does not exist
        Assert-AreEqual 0 $peerckt.Peerings[0].PeeredConnections.Count

    }
    finally
    {
    
        #Cleanup
        $initckt = Get-AzExpressRouteCircuit -Name $initCircuitName -ResourceGroupName $rgname
        $initckt

        $connections = Get-AzExpressRouteCircuitConnectionConfig -ExpressRouteCircuit $initCkt

        if($connections.Count -ge 1)
        {
            foreach($connection in $connections)
            {
                Remove-AzExpressRouteCircuitConnectionConfig -Name $connection.Name -ExpressRouteCircuit $initCkt
            }

            Set-AzExpressRouteCircuit -ExpressRouteCircuit $initCkt  
        }
       
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
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

        $rule = New-AzRouteFilterRuleConfig -Name $ruleName -Access "Allow" -RouteFilterRuleType "Community" -CommunityList "12076:5010" -Force
        Assert-AreEqual $ruleName $rule.Name

        $filter = New-AzRouteFilter -ResourceGroupName $rgname -Name $filterName -Location $location -Rule $rule -Force
        Assert-AreEqual $filterName $filter.Name
        Assert-AreEqual 1 @($filter.Rules).Count
        Assert-AreEqual $ruleName $filter.Rules[0].Name
        Assert-AreEqual $true $filter.Rules[0].Id.EndsWith($ruleName)

        $peering = New-AzExpressRouteCircuitPeeringConfig -Name $peeringName -RouteFilter $filter -PeeringType $peeringName -PeerASN 33 -PrimaryPeerAddressPrefix "192.171.1.0/30" -SecondaryPeerAddressPrefix "192.171.2.0/30" -VlanId 224 -MicrosoftConfigAdvertisedPublicPrefixes @("11.2.3.4/30", "12.2.3.4/30") -MicrosoftConfigCustomerAsn 1000 -MicrosoftConfigRoutingRegistryName "AFRINIC" -LegacyMode $true
        Assert-AreEqual $peeringName $peering.Name
        Assert-NotNull $peering.RouteFilter
        Assert-AreEqual $true $peering.RouteFilter.Id.EndsWith($filterName) 

        $circuit = New-AzExpressRouteCircuit -ResourceGroupName $rgname -Name $circuitName -Location $location -Peering $peering -SkuTier "Premium" -SkuFamily "MeteredData" -ServiceProviderName "equinix" -PeeringLocation "Atlanta" -BandwidthInMbps 1000
        Assert-AreEqual $circuitName $circuit.Name
        Assert-AreEqual 1 @($circuit.Peerings).Count
        Assert-AreEqual $peeringName $circuit.Peerings[0].Name
        Assert-AreEqual $true $circuit.Peerings[0].Id.EndsWith($peeringName)

        $deletion = Remove-AzExpressRouteCircuit -ResourceGroupName $rgname -Name $circuitName -PassThru -Force
        Assert-AreEqual $true $deletion
        Assert-ThrowsLike { Get-AzExpressRouteCircuit -ResourceGroupName $rgname -Name $circuitName } "*${circuitName}*not found*"

        $deletion = Remove-AzRouteFilter -ResourceGroupName $rgname -Name $filterName -PassThru -Force
        Assert-AreEqual $true $deletion
        Assert-ThrowsLike { Get-AzRouteFilter -ResourceGroupName $rgname -Name $filterName } "*${filterName}*not found*"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
