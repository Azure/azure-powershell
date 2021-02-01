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
Test creating new VirtualRouter
#>
function Test-VirtualRouterCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "centraluseuap"
    $virtualRouterName = Get-ResourceName
    $subnetName = Get-ResourceName

    try
    {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
     
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $hostedSubnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
        
      # Create Virtual Router
      $actualvr = New-AzVirtualRouter -ResourceGroupName $rgname -location $rglocation -Name $virtualRouterName -HostedSubnet $hostedsubnet.Id
      $expectedvr = Get-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName
      Assert-AreEqual $expectedvr.ResourceGroupName $actualvr.ResourceGroupName	
      Assert-AreEqual $expectedvr.Name $actualvr.Name
      Assert-AreEqual $expectedvr.Location $actualvr.Location

      # Update virtual route with branch to branch traffic
      $actualvr = Update-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName -AllowBranchToBranchTraffic
      $expectedvr = Get-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName
      Assert-True { $expectedvr.AllowBranchToBranchTraffic }

      # Block branch to branch traffic
      $actualvr = Update-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName
      $expectedvr = Get-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName
      Assert-False { $expectedvr.AllowBranchToBranchTraffic } 
        
      # List Virtual Routers
      $list = Get-AzVirtualRouter -ResourceGroupName $rgname
      Assert-AreEqual 1 @($list).Count
      Assert-AreEqual $list[0].ResourceGroupName $actualvr.ResourceGroupName	
      Assert-AreEqual $list[0].Name $actualvr.Name	
      Assert-AreEqual $list[0].Location $actualvr.Location
        
      # Delete VR
      $deletevr = Remove-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName -PassThru -Force
      Assert-AreEqual true $deletevr
        
      $list = Get-AzVirtualRouter -ResourceGroupName $rgname
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
Test creating new virtualRouterPeer
#>
function Test-VirtualRouterPeerCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "centraluseuap"
    $virtualRouterName = Get-ResourceName
    $virtualWanName = Get-ResourceName
    $subnetName = Get-ResourceName
    $peerName = Get-ResourceName

    try
    {
      # Create resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
     
      # Create virtual network and subnet
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $hostedSubnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
      
      # Create virtual router
      $virtualRouter = New-AzVirtualRouter -ResourceGroupName $rgname -location $rglocation -Name $virtualRouterName -HostedSubnet $hostedsubnet.Id
      $virtualRouter = Get-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName

      # Create hub bgp connection
      $actualBgpConnection = Add-AzVirtualRouterPeer -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName -PeerIp "192.168.1.5" -PeerAsn "20000"
      $expectedBgpConnection = Get-AzVirtualRouterPeer -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName
      Assert-AreEqual $expectedBgpConnection.Peerings.PeerName $actualBgpConnection.PeerName
      Assert-AreEqual $expectedBgpConnection.PeerIp "192.168.1.5"
      Assert-AreEqual $expectedBgpConnection.PeerAsn "20000"

      #delete hub bgp connection
      $deleteBgpConnection = Remove-AzVirtualRouterPeer -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName -Force
      Assert-AreEqual 0 @($deleteBgpConnection.Peerings).Count

      # Delete virtual router
      $deleteVirtualRouter = Remove-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName -PassThru -Force
      Assert-AreEqual true $deleteVirtualRouter

      $list = Get-AzVirtualRouter -ResourceGroupName $rgname
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
Test route server CRUD
#>
function Test-RouteServerCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "centraluseuap"
    $routeServerName = Get-ResourceName
    $subnetName = Get-ResourceName

    try
    {
      # Create the resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
     
      # Create the Virtual Network
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $hostedSubnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
        
      # Create Virtual Router
      $actualvr = New-AzRouteServer -ResourceGroupName $rgname -location $rglocation -RouteServerName $routeServerName -HostedSubnet $hostedsubnet.Id
      $expectedvr = Get-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName
      Assert-AreEqual $expectedvr.ResourceGroupName $actualvr.ResourceGroupName	
      Assert-AreEqual $expectedvr.Name $actualvr.Name
      Assert-AreEqual $expectedvr.Location $actualvr.Location

      # Update virtual route with branch to branch traffic
      $actualvr = Update-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName -AllowBranchToBranchTraffic
      $expectedvr = Get-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName
      Assert-True { $expectedvr.AllowBranchToBranchTraffic }

      # Block branch to branch traffic
      $actualvr = Update-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName
      $expectedvr = Get-AzRouteServer -ResourceGroupName $rgname -RouteServerName $routeServerName
      Assert-False { $expectedvr.AllowBranchToBranchTraffic } 
        
      # List Virtual Routers
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
    $virtualWanName = Get-ResourceName
    $subnetName = Get-ResourceName
    $peerName = Get-ResourceName

    try
    {
      # Create resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
     
      # Create virtual network and subnet
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $hostedSubnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
      
      # Create virtual router
      $routeServer = New-AzRouteServer -ResourceGroupName $rgname -location $rglocation -RouteServerName $routeServerName -HostedSubnet $hostedsubnet.Id
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

      # Delete virtual router
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
Test virtual router peer learned and advertiesd routes (bgp routes)
#>
function Test-VirtualRouterPeerRoutes
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "centraluseuap"
    $virtualRouterName = Get-ResourceName
    $virtualWanName = Get-ResourceName
    $subnetName = Get-ResourceName
    $peerName = Get-ResourceName

    try
    {
      # Create resource group
      $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
     
      # Create virtual network and subnet
      $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.0.0/24
      $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $rglocation -AddressPrefix 10.0.0.0/16 -Subnet $subnet
      $vnet = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname
      $subnet = Get-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet
      
      # Create virtual router
      $virtualRouter = New-AzVirtualRouter -ResourceGroupName $rgname -location $rglocation -Name $virtualRouterName -HostedSubnet $subnet.Id
      $virtualRouter = Get-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName

      # Create virtual router peering
      $peering = Add-AzVirtualRouterPeer -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName -PeerIp "192.168.1.5" -PeerAsn "20000"
      $peering = Get-AzVirtualRouterPeer -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName

      $learnedRoutes = Get-AzVirtualRouterPeerLearnedRoute -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName
      $advertisedRoutes = Get-AzVirtualRouterPeerAdvertisedRoute -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName

      #delete virtual router peering
      $deletePeering = Remove-AzVirtualRouterPeer -ResourceGroupName $rgname -VirtualRouterName $virtualRouterName -PeerName $peerName -Force
      Assert-AreEqual 0 @($deletePeering.Peerings).Count

      # Delete virtual router
      $deleteVirtualRouter = Remove-AzVirtualRouter -ResourceGroupName $rgname -RouterName $virtualRouterName -PassThru -Force
      Assert-AreEqual true $deleteVirtualRouter

      $list = Get-AzVirtualRouter -ResourceGroupName $rgname
      Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}