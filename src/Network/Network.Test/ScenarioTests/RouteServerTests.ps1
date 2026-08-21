function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName
    Assert-NotNull $cmdletData
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") }
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") }
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.",""
    return $cmdletReturnTypes -contains $realReturnType
}

function Remove-RouteServerWithRetry
{
    param(
        [string]$ResourceGroupName,
        [string]$RouteServerName
    )

    $maxAttempts = 3
    $retryDelaySeconds = 30

    for ($attempt = 1; $attempt -le $maxAttempts; $attempt++)
    {
        try
        {
            return Remove-AzRouteServer -ResourceGroupName $ResourceGroupName -RouteServerName $RouteServerName -PassThru -Force -ErrorAction Stop
        }
        catch
        {
            $errorMessage = $_.Exception.Message
            $isOperationNotFound = $errorMessage -match "Operation .+ not found"

            if (-not $isOperationNotFound)
            {
                throw
            }

            try
            {
                $null = Get-AzRouteServer -ResourceGroupName $ResourceGroupName -RouteServerName $RouteServerName -ErrorAction Stop
            }
            catch
            {
                $getErrorMessage = $_.Exception.Message
                $routeServerMissing = ($getErrorMessage -match "ResourceNotFound") -or ($getErrorMessage -match "was not found")
                if ($routeServerMissing)
                {
                    return $true
                }

                throw
            }

            if ($attempt -eq $maxAttempts)
            {
                throw
            }

            Start-TestSleep -Seconds $retryDelaySeconds
        }
    }
}

<#
.SYNOPSIS
Test route server CRUD
#>
function Test-RouteServerCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "centraluseuap"
    $routeServerName = Get-ResourceName
    $subnetName = "RouteServerSubnet"
    $publicIpAddressName = Get-ResourceName
    $skuType = "Standard"
    $tier = "Regional"
    $hubRoutingPreference = "VpnGateway"
    $minCapacity = 6
    $defaultCapacity = 2

    try
    {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
     
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $hostedSubnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
        
      # Create the public ip address for route server
      $publicIp = New-AzPublicIpAddress -Name $publicIpAddressName -ResourceGroupName $rgName -AllocationMethod Static -Location $rglocation -Sku Standard -Tier Regional
      $publicIp = Get-AzPublicIpAddress -Name $publicIpAddressName -ResourceGroupName $rgName

      # Create the autoscale configuration
      $autoscaleConfiguration = New-AzVirtualRouterAutoScaleConfiguration -MinCapacity $minCapacity 

      # Create route server
      $actualvr = New-AzRouteServer -ResourceGroupName $rgname -location $rglocation -RouteServerName $routeServerName -HostedSubnet $hostedsubnet.Id -PublicIpAddress $publicIp -HubRoutingPreference $hubRoutingPreference -AllowBranchToBranchTraffic
      $expectedvr = Get-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName
      Assert-AreEqual $expectedvr.ResourceGroupName $actualvr.ResourceGroupName	
      Assert-AreEqual $expectedvr.Name $actualvr.Name
      Assert-AreEqual $expectedvr.Location $actualvr.Location
      Assert-AreEqual $expectedvr.HubRoutingPreference $actualvr.HubRoutingPreference
      Assert-AreEqual $expectedvr.AllowBranchToBranchTraffic $actualvr.AllowBranchToBranchTraffic
      Assert-AreEqual $defaultCapacity $actualvr.VirtualRouterAutoScaleConfiguration.MinCapacity

      # Update route server
      $actualvr = Update-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName -HubRoutingPreference "ASPath" -VirtualRouterAutoScaleConfiguration $autoscaleConfiguration

      # List route servers
      $list = Get-AzRouteServer -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actualvr.ResourceGroupName	
      Assert-AreEqual $list[0].Name $actualvr.Name	
      Assert-AreEqual $list[0].Location $actualvr.Location
      Assert-AreEqual $list[0].HubRoutingPreference $actualvr.HubRoutingPreference
      Assert-AreEqual $list[0].AllowBranchToBranchTraffic $actualvr.AllowBranchToBranchTraffic
      Assert-AreEqual $list[0].VirtualRouterAutoScaleConfiguration.MinCapacity $actualvr.VirtualRouterAutoScaleConfiguration.MinCapacity
      Assert-AreEqual $list[0].VirtualRouterAutoScaleConfiguration.MinCapacity $minCapacity
        
      # Delete VR
      $deletevr = Remove-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName -PassThru -Force
      Assert-AreEqual true $deletevr
        
      $list = Get-AzRouteServer -ResourceGroupName $rgname
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
Test route server peer CRUD
#>
function Test-RouteServerPeerCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "centraluseuap"
    $routeServerName = Get-ResourceName
    $subnetName = "RouteServerSubnet"
    $peerName = Get-ResourceName
    $publicIpAddressName = Get-ResourceName
    $skuType = "Standard"
    $tier = "Regional"

    try
    {
      # Create resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
     
      # Create virtual network and subnet
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $hostedSubnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
      
      # Create the public ip address for route server
      $publicIp = New-AzPublicIpAddress -Name $publicIpAddressName -ResourceGroupName $rgName -AllocationMethod Static -Location $rglocation -Sku Standard -Tier Regional
      $publicIp = Get-AzPublicIpAddress -Name $publicIpAddressName -ResourceGroupName $rgName

      # Create route server
      $actualvr = New-AzRouteServer -ResourceGroupName $rgname -location $rglocation -RouteServerName $routeServerName -HostedSubnet $hostedsubnet.Id -PublicIpAddress $publicIp
      $routeServer = Get-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName

      # Create hub bgp connection
      $actualBgpConnection = Add-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName -PeerIp "192.168.1.5" -PeerAsn "20000"
      $expectedBgpConnection = Get-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName
      Assert-AreEqual $expectedBgpConnection.Peerings.PeerName $actualBgpConnection.PeerName
      Assert-AreEqual $expectedBgpConnection.PeerIp "192.168.1.5"
      Assert-AreEqual $expectedBgpConnection.PeerAsn "20000"

      #delete hub bgp connection
      $deleteBgpConnection = Remove-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName -Force
      Assert-AreEqual 0 @($deleteBgpConnection.Peerings).Count

      # Delete route server
      $deleteRouteServer = Remove-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName -PassThru -Force
      Assert-AreEqual true $deleteRouteServer

      $list = Get-AzRouteServer -ResourceGroupName $rgname
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
Test route server peer learned and advertiesd routes (bgp routes)
#>
function Test-RouteServerPeerRoutes
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "centraluseuap"
    $routeServerName = Get-ResourceName
    $subnetName = "RouteServerSubnet"
    $peerName = Get-ResourceName
    $publicIpAddressName = Get-ResourceName
    $skuType = "Standard"
    $tier = "Regional"

    try
    {
      # Create resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
     
      # Create virtual network and subnet
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $hostedSubnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
      
      # Create the public ip address for route server
      $publicIp = New-AzPublicIpAddress -Name $publicIpAddressName -ResourceGroupName $rgName -AllocationMethod Static -Location $rglocation -Sku Standard -Tier Regional
      $publicIp = Get-AzPublicIpAddress -Name $publicIpAddressName -ResourceGroupName $rgName

      # Create route server
      $actualvr = New-AzRouteServer -ResourceGroupName $rgname -location $rglocation -RouteServerName $routeServerName -HostedSubnet $hostedsubnet.Id -PublicIpAddress $publicIp
      $routeServer = Get-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName

      # Create route server peering
      $peering = Add-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName -PeerIp "192.168.1.5" -PeerAsn "20000"
      $peering = Get-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName

      $learnedRoutes = Get-AzRouteServerPeerLearnedRoute -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName
      $advertisedRoutes = Get-AzRouteServerPeerAdvertisedRoute -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName

      #delete route server peering
      $deletePeering = Remove-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName -Force
      Assert-AreEqual 0 @($deletePeering.Peerings).Count

      # Delete route server
      $deleteRouteServer = Remove-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName -PassThru -Force
      Assert-AreEqual true $deleteRouteServer

      $list = Get-AzRouteServer -ResourceGroupName $rgname
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
Test route server peer with routing configuration and hub virtual network connection
#>
function Test-RouteServerPeerWithRoutingConfiguration
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "centraluseuap"
    $routeServerName = Get-ResourceName
    $subnetName = "RouteServerSubnet"
    $peerName = Get-ResourceName
    $publicIpAddressName = Get-ResourceName
    $routeMapName = Get-ResourceName

    try
    {
        # Create resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create virtual network with RouteServerSubnet
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16

        # Add RouteServerSubnet as a private subnet
        $vnet = Add-AzVirtualNetworkSubnetConfig -Name "RouteServerSubnet" -AddressPrefix 10.0.1.0/24 -DefaultOutboundAccess $false -VirtualNetwork $vnet
        
        # Commit the VNet changes
        $vnet = Set-AzVirtualNetwork -VirtualNetwork $vnet
        $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
        $hostedSubnet = Get-AzVirtualNetworkSubnetConfig -Name "RouteServerSubnet" -VirtualNetwork $vnet

        # Create the public ip address for route server
        $publicIp = New-AzPublicIpAddress -Name $publicIpAddressName -ResourceGroupName $rgname -AllocationMethod Static -Location $rglocation -Sku Standard -Tier Regional
        $publicIp = Get-AzPublicIpAddress -Name $publicIpAddressName -ResourceGroupName $rgname

        # Create route server
        $routeServer = New-AzRouteServer -ResourceGroupName $rgname -Location $rglocation -RouteServerName $routeServerName -HostedSubnet $hostedSubnet.Id -PublicIpAddress $publicIp
        $routeServer = Get-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName
        Assert-AreEqual $routeServerName $routeServer.Name

        # Get the route server hub and wait for provisioning
        $virtualHubName = $routeServerName
        $virtualHub = Get-AzVirtualHub -ResourceGroupName $rgname -Name $virtualHubName
        $routingStatePollIntervalSeconds = 180
        $maxRoutingStatePollAttempts = 10
        $routingStatePollAttempt = 0
        while ($virtualHub.RoutingState -eq "Provisioning" -and $routingStatePollAttempt -lt $maxRoutingStatePollAttempts)
        {
            Start-TestSleep -Seconds $routingStatePollIntervalSeconds
            $virtualHub = Get-AzVirtualHub -ResourceGroupName $rgname -Name $virtualHubName
            $routingStatePollAttempt++
        }
        Assert-AreEqual "Provisioned" $virtualHub.RoutingState

        # Create a route map on the route server hub
        $routeMapMatchCriterion1 = New-AzRouteMapRuleCriterion -MatchCondition "Contains" -RoutePrefix @("10.0.0.0/16")
        $routeMapActionParameter1 = New-AzRouteMapRuleActionParameter -AsPath @("12345")
        $routeMapAction1 = New-AzRouteMapRuleAction -Type "Add" -Parameter @($routeMapActionParameter1)
        $routeMapRule1 = New-AzRouteMapRule -Name "rule1" -MatchCriteria @($routeMapMatchCriterion1) -RouteMapRuleAction @($routeMapAction1) -NextStepIfMatched "Continue"

        New-AzRouteMap -ResourceGroupName $rgname -VirtualHubName $virtualHubName -Name $routeMapName -RouteMapRule @($routeMapRule1)
        $routeMap = Get-AzRouteMap -ResourceGroupName $rgname -VirtualHubName $virtualHubName -Name $routeMapName
        Assert-AreEqual $routeMapName $routeMap.Name
        Assert-AreEqual 1 $routeMap.Rules.Count

        # Create routing configuration with inbound and outbound route maps
        $routingConfig = New-AzRoutingConfiguration -InboundRouteMap $routeMap.Id -OutboundRouteMap $routeMap.Id

        # Create route server peer with routing configuration
        $result = Add-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName -PeerIp "10.0.0.5" -PeerAsn "65010" -RoutingConfiguration $routingConfig
        $peer = Get-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName
        Assert-AreEqual $peerName $peer.Name
        Assert-AreEqual "10.0.0.5" $peer.PeerIp
        Assert-AreEqual "65010" $peer.PeerAsn
        Assert-NotNull $peer.RoutingConfiguration
        Assert-AreEqual $peer.RoutingConfiguration.InboundRouteMap.Id $routeMap.Id
        Assert-AreEqual $peer.RoutingConfiguration.OutboundRouteMap.Id $routeMap.Id

        # Delete route server peer
        $deleteResult = Remove-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName -Force
        Assert-AreEqual 0 @($deleteResult.Peerings).Count

        # Delete route map
        Remove-AzRouteMap -ResourceGroupName $rgname -VirtualHubName $virtualHubName -Name $routeMapName -Force

        # Delete route server
        Remove-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName -PassThru -Force
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}


function Test-RouteServerPeerWithHubVnetConnection
{
    # Setup
    $rgname = Get-ResourceGroupName
    $hubVnetName = Get-ResourceName
    $spokeVnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "centraluseuap"
    $routeServerName = Get-ResourceName
    $routeServerSubnetName = "RouteServerSubnet"
    $peerName = Get-ResourceName
    $publicIpAddressName = Get-ResourceName
    $routeMapName = Get-ResourceName
    $hubVnetPeeringName = Get-ResourceName
    $spokeVnetPeeringName = Get-ResourceName
    $hubVnetConnectionName = Get-ResourceName

    try
    {
        # Create resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create hub virtual network with RouteServerSubnet
        $hubVnet = New-AzVirtualNetwork -Name $hubVnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16
        
        # Add RouteServerSubnet as a private subnet
        $hubVnet = Add-AzVirtualNetworkSubnetConfig -Name $routeServerSubnetName -AddressPrefix 10.0.0.0/24 -DefaultOutboundAccess $false -VirtualNetwork $hubVnet
        
        # Commit the VNet changes
        $hubVnet = Set-AzVirtualNetwork -VirtualNetwork $hubVnet
        $hubVnet = Get-AzVirtualNetwork -Name $hubVnetName -ResourceGroupName $rgname
        $hostedSubnet = Get-AzVirtualNetworkSubnetConfig -Name $routeServerSubnetName -VirtualNetwork $hubVnet

        # Create spoke virtual network with SpokeSubnet
        $spokeSubnet = New-AzVirtualNetworkSubnetConfig -Name "SpokeSubnet" -AddressPrefix 10.1.0.0/24 -DefaultOutboundAccess $false
        $spokeVnet = New-AzVirtualNetwork -Name $spokeVnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.1.0.0/16 -Subnet $spokeSubnet
        $spokeVnet = Get-AzVirtualNetwork -Name $spokeVnetName -ResourceGroupName $rgname

        # Create the public ip address for route server
        $publicIp = New-AzPublicIpAddress -Name $publicIpAddressName -ResourceGroupName $rgname -AllocationMethod Static -Location $rglocation -Sku Standard -Tier Regional
        $publicIp = Get-AzPublicIpAddress -Name $publicIpAddressName -ResourceGroupName $rgname

        # Create route server
        $routeServer = New-AzRouteServer -ResourceGroupName $rgname -Location $rglocation -RouteServerName $routeServerName -HostedSubnet $hostedSubnet.Id -PublicIpAddress $publicIp
        $routeServer = Get-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName
        Assert-AreEqual $routeServerName $routeServer.Name

        # Get the route server hub and wait for provisioning
        $virtualHubName = $routeServerName
        $virtualHub = Get-AzVirtualHub -ResourceGroupName $rgname -Name $virtualHubName
        $routingStatePollIntervalSeconds = 180
        $maxRoutingStatePollAttempts = 10
        $routingStatePollAttempt = 0
        while ($virtualHub.RoutingState -eq "Provisioning" -and $routingStatePollAttempt -lt $maxRoutingStatePollAttempts)
        {
            Start-TestSleep -Seconds $routingStatePollIntervalSeconds
            $virtualHub = Get-AzVirtualHub -ResourceGroupName $rgname -Name $virtualHubName
            $routingStatePollAttempt++
        }
        Assert-AreEqual "Provisioned" $virtualHub.RoutingState

        # Create hub-to-spoke VNet peering with allowGatewayTransit = true
        $hubToSpokePeering = Add-AzVirtualNetworkPeering -Name $hubVnetPeeringName -VirtualNetwork $hubVnet -RemoteVirtualNetworkId $spokeVnet.Id -AllowGatewayTransit
        # Refresh peering object to ensure all properties are populated
        $hubToSpokePeering = Get-AzVirtualNetworkPeering -Name $hubVnetPeeringName -VirtualNetworkName $hubVnet.Name -ResourceGroupName $rgname
        Assert-AreEqual $hubVnetPeeringName $hubToSpokePeering.Name
        Assert-AreEqual $true $hubToSpokePeering.AllowGatewayTransit

        # Create spoke-to-hub VNet peering with useRemoteGateway = true
        $spokeToHubPeering = Add-AzVirtualNetworkPeering -Name $spokeVnetPeeringName -VirtualNetwork $spokeVnet -RemoteVirtualNetworkId $hubVnet.Id -UseRemoteGateway
        # Refresh peering object to ensure all properties are populated
        $spokeToHubPeering = Get-AzVirtualNetworkPeering -Name $spokeVnetPeeringName -VirtualNetworkName $spokeVnet.Name -ResourceGroupName $rgname
        Assert-AreEqual $spokeVnetPeeringName $spokeToHubPeering.Name


        # Create a route map on the route server hub
        $routeMapMatchCriterion1 = New-AzRouteMapRuleCriterion -MatchCondition "Contains" -RoutePrefix @("10.0.0.0/16", "10.1.0.0/16")
        $routeMapActionParameter1 = New-AzRouteMapRuleActionParameter -AsPath @("12345")
        $routeMapAction1 = New-AzRouteMapRuleAction -Type "Add" -Parameter @($routeMapActionParameter1)
        $routeMapRule1 = New-AzRouteMapRule -Name "rule1" -MatchCriteria @($routeMapMatchCriterion1) -RouteMapRuleAction @($routeMapAction1) -NextStepIfMatched "Continue"

        New-AzRouteMap -ResourceGroupName $rgname -VirtualHubName $virtualHubName -Name $routeMapName -RouteMapRule @($routeMapRule1)
        $routeMap = Get-AzRouteMap -ResourceGroupName $rgname -VirtualHubName $virtualHubName -Name $routeMapName
        Assert-AreEqual $routeMapName $routeMap.Name
        Assert-AreEqual 1 $routeMap.Rules.Count

        # Create hub VNet connection for spoke VNet
        $hubVnetConnection = New-AzVirtualHubVnetConnection -ResourceGroupName $rgname -VirtualHubName $virtualHubName -Name $hubVnetConnectionName -RemoteVirtualNetworkId $spokeVnet.Id
        # Refresh hub VNet connection to ensure all properties are populated
        $hubVnetConnection = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgname -VirtualHubName $virtualHubName -Name $hubVnetConnectionName
        Assert-AreEqual $hubVnetConnectionName $hubVnetConnection.Name
        # Model shape differs across API/profile versions; accept either property.
        $remoteVnetId = $hubVnetConnection.RemoteVirtualNetworkId
        if ($null -eq $remoteVnetId -or $remoteVnetId -eq "")
        {
            $remoteVnetId = $hubVnetConnection.RemoteVirtualNetwork.Id
        }
        Assert-AreEqual $spokeVnet.Id $remoteVnetId

        # Create route server peer with routing configuration referencing hub VNet connection
        # Use first IP from spokeVnet address space (10.1.0.5 from 10.1.0.0/16)
        $result = Add-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName -PeerIp "10.1.0.5" -PeerAsn "65011" -VirtualHubVnetConnection $hubVnetConnection
        # Refresh peer object to ensure all properties are populated
        $peer = Get-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName

        Assert-AreEqual $peerName $peer.Name
        Assert-AreEqual "10.1.0.5" $peer.PeerIp
        Assert-NotNull $peer.HubVirtualNetworkConnection

        # Delete route server peer
        $deleteResult = Remove-AzRouteServerPeer -ResourceGroupName $rgname -RouteServerName $routeServerName -PeerName $peerName -Force
        Assert-AreEqual 0 @($deleteResult.Peerings).Count

        # Delete hub VNet connection
        Remove-AzVirtualHubVnetConnection -ResourceGroupName $rgname -VirtualHubName $virtualHubName -Name $hubVnetConnectionName -Force

        # Delete VNet peerings
        Remove-AzVirtualNetworkPeering -ResourceGroupName $rgname -VirtualNetworkName $hubVnetName -Name $hubVnetPeeringName -Force
        Remove-AzVirtualNetworkPeering -ResourceGroupName $rgname -VirtualNetworkName $spokeVnetName -Name $spokeVnetPeeringName -Force

        # Delete route map
        Remove-AzRouteMap -ResourceGroupName $rgname -VirtualHubName $virtualHubName -Name $routeMapName -Force

        # Delete route server
        Remove-RouteServerWithRetry -ResourceGroupName $rgname -RouteServerName $routeServerName
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}