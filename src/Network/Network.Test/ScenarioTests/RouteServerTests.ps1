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

      # Create route server
      $actualvr = New-AzRouteServer -ResourceGroupName $rgname -location $rglocation -RouteServerName $routeServerName -HostedSubnet $hostedsubnet.Id -PublicIpAddress $publicIp
      $expectedvr = Get-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName
      Assert-AreEqual $expectedvr.ResourceGroupName $actualvr.ResourceGroupName	
      Assert-AreEqual $expectedvr.Name $actualvr.Name
      Assert-AreEqual $expectedvr.Location $actualvr.Location

      # Update route server
      $actualvr = Update-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName -HubRoutingPreference "ASPath"

      # List route servers
      $list = Get-AzRouteServer -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actualvr.ResourceGroupName	
      Assert-AreEqual $list[0].Name $actualvr.Name	
      Assert-AreEqual $list[0].Location $actualvr.Location
        
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