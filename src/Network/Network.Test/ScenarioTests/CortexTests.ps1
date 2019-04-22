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
CortexCRUD
#>
function Test-CortexCRUD
{
 # Setup
    $rgName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "East US"

	$virtualWanName = Get-ResourceName
	$virtualHubName = Get-ResourceName
	$vpnSiteName = Get-ResourceName
	$vpnGatewayName = Get-ResourceName
	$remoteVirtualNetworkName = Get-ResourceName
	$vpnConnectionName = Get-ResourceName
	$hubVnetConnectionName = Get-ResourceName

	$storeName = 'blob' + $rgName
    
	try
	{
		# Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
		$createdVirtualWan = Update-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -AllowVnetToVnetTraffic $false -AllowBranchToBranchTraffic $false
		$virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name
		Assert-AreEqual $false $virtualWan.AllowVnetToVnetTraffic
		Assert-AreEqual $false $virtualWan.AllowBranchToBranchTraffic

        $virtualWans = Get-AzureRmVirtualWan -ResourceGroupName $rgName
        Assert-NotNull $virtualWans

        $virtualWansAll = Get-AzureRmVirtualWan
        Assert-NotNull $virtualWansAll

		$virtualWansAll = Get-AzVirtualWan -ResourceGroupName "*"
        Assert-NotNull $virtualWansAll

		$virtualWansAll = Get-AzVirtualWan -Name "*"
        Assert-NotNull $virtualWansAll

		$virtualWansAll = Get-AzVirtualWan -ResourceGroupName "*" -Name "*"
        Assert-NotNull $virtualWansAll

		# Create the Virtual Hub
		$createdVirtualHub = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual "192.168.1.0/24" $virtualHub.AddressPrefix

        $virtualHubs = Get-AzureRmVirtualHub -ResourceGroupName $rgName
        Assert-NotNull $virtualHubs

        $virtualHubsAll = Get-AzureRmVirtualHub
        Assert-NotNull $virtualHubsAll

		$virtualHubsAll = Get-AzureRmVirtualHub -ResourceGroupName "*"
        Assert-NotNull $virtualHubsAll

		$virtualHubsAll = Get-AzureRmVirtualHub -Name "*"
        Assert-NotNull $virtualHubsAll

		$virtualHubsAll = Get-AzureRmVirtualHub -ResourceGroupName "*" -Name "*"
        Assert-NotNull $virtualHubsAll

		# Update the Virtual Hub
		$route1 = New-AzVirtualHubRoute -AddressPrefix @("10.0.0.0/16", "11.0.0.0/16") -NextHopIpAddress "12.0.0.5"
		$route2 = New-AzVirtualHubRoute -AddressPrefix @("13.0.0.0/16") -NextHopIpAddress "14.0.0.5"
		$routeTable = New-AzVirtualHubRouteTable -Route @($route1, $route2)
		Update-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -RouteTable $routeTable
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		$routes = $virtualHub.RouteTable.Routes
		Assert-AreEqual 2 @($routes).Count
		
		# Create the VpnSite
		$vpnSiteAddressSpaces = New-Object string[] 1
		$vpnSiteAddressSpaces[0] = "192.168.2.0/24"
		$createdVpnSite = New-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Location $rglocation -VirtualWan $virtualWan -IpAddress "1.2.3.4" -AddressSpace $vpnSiteAddressSpaces -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -LinkSpeedInMbps 10
		$createdVpnSite = Update-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -IpAddress "2.3.4.5"
		$vpnSite = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName
		Assert-AreEqual $rgName $vpnSite.ResourceGroupName
		Assert-AreEqual $vpnSiteName $vpnSite.Name
		Assert-AreEqual "2.3.4.5" $vpnSite.IpAddress

        $vpnSites = Get-AzureRmVpnSite -ResourceGroupName $rgName
        Assert-NotNull $vpnSites

        $vpnSitesAll = Get-AzureRmVpnSite
        Assert-NotNull $vpnSitesAll

		$vpnSitesAll = Get-AzVpnSite -ResourceGroupName "*"
        Assert-NotNull $vpnSitesAll

		$vpnSitesAll = Get-AzVpnSite -Name "*"
        Assert-NotNull $vpnSitesAll

		$vpnSitesAll = Get-AzVpnSite -ResourceGroupName "*" -Name "*"
        Assert-NotNull $vpnSitesAll

		# Create the VpnGateway
		$createdVpnGateway = New-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 3
		$createdVpnGateway = Update-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VpnGatewayScaleUnit 4
		$vpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual $rgName $vpnGateway.ResourceGroupName
		Assert-AreEqual $vpnGatewayName $vpnGateway.Name
		Assert-AreEqual 4 $vpnGateway.VpnGatewayScaleUnit

        $vpnGateways = Get-AzureRmVpnGateway -ResourceGroupName $rgName
        Assert-NotNull $vpnGateways

        $vpnGatewaysAll = Get-AzureRmVpnGateway -ResourceGroupName "*"
        Assert-NotNull $vpnGatewaysAll

		$vpnGatewaysAll = Get-AzureRmVpnGateway -Name "*"
        Assert-NotNull $vpnGatewaysAll

		$vpnGatewaysAll = Get-AzureRmVpnGateway -ResourceGroupName "*" -Name "*"
        Assert-NotNull $vpnGatewaysAll

		$vpnGatewaysAll = Get-AzureRmVpnGateway
        Assert-NotNull $vpnGatewaysAll

		# Create the VpnConnection
		$createdVpnConnection = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20
		$createdVpnConnection = Update-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -ConnectionBandwidth 30
		$vpnConnection = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Assert-AreEqual $vpnConnectionName $vpnConnection.Name
		Assert-AreEqual 30 $vpnConnection.ConnectionBandwidth

        $vpnConnections = Get-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName
        Assert-NotNull $vpnConnections

		$vpnConnections = Get-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "*"
        Assert-NotNull $vpnConnections

		# Create a HubVirtualNetworkConnection
		$remoteVirtualNetwork = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $remoteVirtualNetworkName -Location $rglocation -AddressPrefix "10.0.1.0/24"
		$createdHubVnetConnection = New-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName -RemoteVirtualNetwork $remoteVirtualNetwork
		$hubVnetConnection = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName
		Assert-AreEqual $hubVnetConnectionName $hubVnetConnection.Name
        $hubVnetConnections = Get-AzureRmVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName
        Assert-NotNull $hubVnetConnections
        $hubVnetConnections = Get-AzureRmVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name "*"
        Assert-NotNull $hubVnetConnections

        # Clean up
        $delete = Remove-AzVirtualHubVnetConnection -ResourceGroupName $rgName -ParentResourceName $virtualHubName -Name $hubVnetConnectionName -Force -PassThru
        Assert-AreEqual $True $delete

        $delete = Remove-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -Force -PassThru
        Assert-AreEqual $True $delete

        $delete = Remove-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -Force -PassThru
        Assert-AreEqual $True $delete

        $delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Force -PassThru
        Assert-AreEqual $True $delete

        $delete = Remove-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Force -PassThru
        Assert-AreEqual $True $delete

        $delete = Remove-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force -PassThru
        Assert-AreEqual $True $delete
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
CortexDownloadConfig
#>
function Test-CortexDownloadConfig
{
 # Setup
    $rgName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "East US"

	$virtualWanName = Get-ResourceName
	$virtualHubName = Get-ResourceName
	$vpnSiteName = Get-ResourceName
	$vpnGatewayName = Get-ResourceName
	$remoteVirtualNetworkName = Get-ResourceName
	$vpnConnectionName = Get-ResourceName
	$hubVnetConnectionName = Get-ResourceName

	$storeName = 'blob' + $rgName
    
	try
	{
		# Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
		$virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name
		
		# Create the Virtual Hub
		$createdVirtualHub = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual "192.168.1.0/24" $virtualHub.AddressPrefix

		# Create the VpnSite
		$vpnSiteAddressSpaces = New-Object string[] 1
		$vpnSiteAddressSpaces[0] = "192.168.2.0/24"
		$createdVpnSite = New-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Location $rglocation -VirtualWan $virtualWan -IpAddress "1.2.3.4" -AddressSpace $vpnSiteAddressSpaces -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -LinkSpeedInMbps 10
		$vpnSite = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName
		Assert-AreEqual $rgName $vpnSite.ResourceGroupName
		Assert-AreEqual $vpnSiteName $vpnSite.Name
		
		# Create the VpnGateway
		$createdVpnGateway = New-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 3
		$vpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual $rgName $vpnGateway.ResourceGroupName
		Assert-AreEqual $vpnGatewayName $vpnGateway.Name
		
		# Create the VpnConnection
		$createdVpnConnection = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20
		$vpnConnection = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Assert-AreEqual $vpnConnectionName $vpnConnection.Name
		
		# Download config
		$storetype = 'Standard_GRS'
		$containerName = 'cont' + $rgName
		New-AzStorageAccount -ResourceGroupName $rgName -Name $storeName -Location $rglocation -Type $storetype
		$key = Get-AzStorageAccountKey -ResourceGroupName $rgName -Name $storeName
		$context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
		New-AzStorageContainer -Name $containerName -Context $context
		$container = Get-AzStorageContainer -Name $containerName -Context $context
		New-Item -Name EmptyFile.txt -ItemType File -Force
		Set-AzStorageBlobContent -File "EmptyFile.txt" -Container $containerName -Blob "emptyfile.txt" -Context $context
		$now=get-date
		$blobSasUrl = New-AzStorageBlobSASToken -Container $containerName -Blob emptyfile.txt -Context $context -Permission "rwd" -StartTime $now.AddHours(-1) -ExpiryTime $now.AddDays(1) -FullUri

		$vpnSitesForConfig = New-Object Microsoft.Azure.Commands.Network.Models.PSVpnSite[] 1
		$vpnSitesForConfig[0] = $vpnSite
		Get-AzVirtualWanVpnConfiguration -VirtualWan $virtualWan -StorageSasUrl $blobSasUrl -VpnSite $vpnSitesForConfig

		$delete = Remove-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force -PassThru
		Assert-AreEqual $True $delete
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}
}

function Test-CortexExpressRouteCRUD
{
    # Setup
    $rgName = Get-ResourceName
    # ExpressRoute gateways have been enabled only in westcentralus region
    $rglocation = Get-ProviderLocation "ResourceManagement" "westcentralus"

    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName
    $expressRouteGatewayName = Get-ResourceName
    $circuitName = Get-ResourceName
    $expressRouteConnectionName = Get-ResourceName

    try
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgName -Location $rglocation

        # Create the Virtual Wan
        $createdVirtualWan = New-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
        $virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
        Write-Debug "Created Virtual WAN $virtualWan.Name successfully"

        $createdVirtualHub = New-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "10.8.0.0/24" -VirtualWan $virtualWan
        $virtualHub = Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
        Write-Debug "Created Virtual Hub virtualHub.Name successfully"

        # Create the ExpressRouteGateway
        $createdExpressRouteGateway = New-AzureRmExpressRouteGateway -ResourceGroupName $rgName -Name $expressRouteGatewayName -VirtualHub $virtualHub -MinScaleUnits 2
        Write-Debug "Created ExpressRoute Gateway $expressRouteGatewayName successfully"
        $expressRouteGateway = Get-AzureRmExpressRouteGateway -ResourceGroupName $rgName -Name $expressRouteGatewayName
        Assert-NotNull $expressRouteGateway
        Write-Debug "Retrieved ExpressRoute Gateway $expressRouteGatewayName successfully"

        # List the ExpressRouteGateway
        $expressRouteGateways = Get-AzureRmExpressRouteGateway
        Assert-NotNull $expressRouteGateways
        Assert-True { $expressRouteGateways.Count -gt 0 }

		$expressRouteGateways = Get-AzureRmExpressRouteGateway -ResourceGroupName "*"
        Assert-NotNull $expressRouteGateways
        Assert-True { $expressRouteGateways.Count -gt 0 }

		$expressRouteGateways = Get-AzureRmExpressRouteGateway -Name "*"
        Assert-NotNull $expressRouteGateways
        Assert-True { $expressRouteGateways.Count -gt 0 }

		$expressRouteGateways = Get-AzureRmExpressRouteGateway -ResourceGroupName "*" -Name "*"
        Assert-NotNull $expressRouteGateways
        Assert-True { $expressRouteGateways.Count -gt 0 }

		$expressRouteGateways = Get-AzureRmExpressRouteGateway -ResourceGroupName $rgName
        Assert-NotNull $expressRouteGateways
        Assert-True { $expressRouteGateways.Count -gt 0 }

        # Create the ExpressRouteCircuit with peering to which the connection needs to be established to
        $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -PeeringType AzurePrivatePeering -PeerASN 100 -PrimaryPeerAddressPrefix "10.2.3.4/30" -SecondaryPeerAddressPrefix "11.2.3.4/30" -VlanId 22
        $circuit = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $rglocation -ResourceGroupName $rgname -SkuTier Premium -SkuFamily MeteredData  -ServiceProviderName "Zayo" -PeeringLocation "Denver" -BandwidthInMbps 200 -Peering $peering
        Write-Debug "Created ExpressRoute Circuit with Private Peering $circuitName successfully"

        # Get Express Route Circuit Resource
        $circuitResult = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname
        $peeringResult = Get-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -ExpressRouteCircuit $circuitResult
        Write-Debug "Created ExpressRoute Circuit with Private Peering $circuitName successfully"

        # Create the ExpressRoute Connection
        $createdExpressRouteConnection = New-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ExpressRouteGatewayName $expressRouteGatewayName -Name $expressRouteConnectionName -ExpressRouteCircuitPeeringId $peeringResult.Id -RoutingWeight 10
        Write-Debug "Created ExpressRoute Connection with Private Peering $expressRouteConnectionName successfully"
        $createdExpressRouteConnection = Set-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ExpressRouteGatewayName $expressRouteGatewayName -Name $expressRouteConnectionName -RoutingWeight 30
        Write-Debug "Updated ExpressRoute Connection with Private Peering $expressRouteConnectionName successfully"
        $expressRouteConnection = Get-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ExpressRouteGatewayName $expressRouteGatewayName -Name $expressRouteConnectionName
        Assert-NotNull $expressRouteConnection
        Write-Debug "Retrieved ExpressRoute Connection with Private Peering $expressRouteConnectionName successfully"
        Assert-AreEqual $expressRouteConnectionName $expressRouteConnection.Name
        Assert-AreEqual 30 $expressRouteConnection.RoutingWeight

		$expressRouteConnection = Get-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ExpressRouteGatewayName $expressRouteGatewayName
        Assert-NotNull $expressRouteConnection
		Assert-True { $expressRouteConnection.Count -ge 0}

		$expressRouteConnection = Get-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ExpressRouteGatewayName $expressRouteGatewayName -Name "*"
        Assert-NotNull $expressRouteConnection
		Assert-True { $expressRouteConnection.Count -ge 0}

        # Clean up
        Remove-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ExpressRouteGatewayName $expressRouteGatewayName -Name $expressRouteConnectionName -Force
        Assert-ThrowsLike { Get-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ExpressRouteGatewayName $expressRouteGatewayName -Name $expressRouteConnectionName } "*Not*Found*"

        Remove-AzureRmExpressRouteGateway -ResourceGroupName $rgName -Name $expressRouteGatewayName -Force
        Assert-ThrowsLike { Get-AzureRmExpressRouteGateway -ResourceGroupName $rgName -Name $expressRouteGatewayName } "*Not*Found*"

        Remove-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Force

        Remove-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force
        Assert-ThrowsLike { Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName } "*Not*Found*"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}
