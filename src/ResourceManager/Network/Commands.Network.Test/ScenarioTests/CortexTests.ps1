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
	$expressRouteGatewayName = Get-ResourceName
    $circuitName = Get-ResourceName
    $expressRouteConnectionName = Get-ResourceName
	$remoteVirtualNetworkName = Get-ResourceName
	$vpnConnectionName = Get-ResourceName
	$hubVnetConnectionName = Get-ResourceName

	$storeName = 'blob' + $rgName
    
	try
	{
		# Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgName -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
		$createdVirtualWan = Update-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -AllowVnetToVnetTraffic $false -AllowBranchToBranchTraffic $false
		$virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name
		Assert-AreEqual $false $virtualWan.AllowVnetToVnetTraffic
		Assert-AreEqual $false $virtualWan.AllowBranchToBranchTraffic

		# Create the Virtual Hub
		$createdVirtualHub = New-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual "192.168.1.0/24" $virtualHub.AddressPrefix

		# Update the Virtual Hub
		$route1 = New-AzureRmVirtualHubRoute -AddressPrefix @("10.0.0.0/16", "11.0.0.0/16") -NextHopIpAddress "12.0.0.5"
		$route2 = New-AzureRmVirtualHubRoute -AddressPrefix @("13.0.0.0/16") -NextHopIpAddress "14.0.0.5"
		$routeTable = New-AzureRmVirtualHubRouteTable -Route @($route1, $route2)
		Update-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -RouteTable $routeTable
		$virtualHub = Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		$routes = $virtualHub.RouteTable.Routes
		Assert-AreEqual 2 @($routes).Count
		
		# Create the VpnSite
		$vpnSiteAddressSpaces = New-Object string[] 1
		$vpnSiteAddressSpaces[0] = "192.168.2.0/24"
		$createdVpnSite = New-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Location $rglocation -VirtualWan $virtualWan -IpAddress "1.2.3.4" -AddressSpace $vpnSiteAddressSpaces -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -LinkSpeedInMbps 10
		$createdVpnSite = Update-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -IpAddress "2.3.4.5"
		$vpnSite = Get-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName
		Assert-AreEqual $rgName $vpnSite.ResourceGroupName
		Assert-AreEqual $vpnSiteName $vpnSite.Name
		Assert-AreEqual "2.3.4.5" $vpnSite.IpAddress

		# Create the VpnGateway
		$createdVpnGateway = New-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 3
		$createdVpnGateway = Update-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VpnGatewayScaleUnit 4
		$vpnGateway = Get-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual $rgName $vpnGateway.ResourceGroupName
		Assert-AreEqual $vpnGatewayName $vpnGateway.Name
		Assert-AreEqual 4 $vpnGateway.VpnGatewayScaleUnit

		# Create the VpnConnection
		$createdVpnConnection = New-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20
		$createdVpnConnection = Update-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -ConnectionBandwidth 30
		$vpnConnection = Get-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Assert-AreEqual $vpnConnectionName $vpnConnection.Name
		Assert-AreEqual 30 $vpnConnection.ConnectionBandwidth

        # Create a HubVirtualNetworkConnection
		$remoteVirtualNetwork = New-AzureRmVirtualNetwork -ResourceGroupName $rgName -Name $remoteVirtualNetworkName -Location $rglocation -AddressPrefix "10.0.1.0/24"
		$createdHubVnetConnection = New-AzureRmVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName -RemoteVirtualNetwork $remoteVirtualNetwork
		$hubVnetConnection = Get-AzureRmVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName
		Assert-AreEqual $hubVnetConnectionName $hubVnetConnection.Name
	}
	finally
	{
		$delete = Remove-AzureRmVirtualHubVnetConnection -ResourceGroupName $rgName -ParentResourceName $virtualHubName -Name $hubVnetConnectionName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force -PassThru
		Assert-AreEqual $True $delete

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
        $resourceGroup = New-AzureRmResourceGroup -Name $rgName -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
		$virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name
		
		# Create the Virtual Hub
		$createdVirtualHub = New-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual "192.168.1.0/24" $virtualHub.AddressPrefix

		# Create the VpnSite
		$vpnSiteAddressSpaces = New-Object string[] 1
		$vpnSiteAddressSpaces[0] = "192.168.2.0/24"
		$createdVpnSite = New-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Location $rglocation -VirtualWan $virtualWan -IpAddress "1.2.3.4" -AddressSpace $vpnSiteAddressSpaces -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -LinkSpeedInMbps 10
		$vpnSite = Get-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName
		Assert-AreEqual $rgName $vpnSite.ResourceGroupName
		Assert-AreEqual $vpnSiteName $vpnSite.Name
		
		# Create the VpnGateway
		$createdVpnGateway = New-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 3
		$vpnGateway = Get-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual $rgName $vpnGateway.ResourceGroupName
		Assert-AreEqual $vpnGatewayName $vpnGateway.Name
		
		# Create the VpnConnection
		$createdVpnConnection = New-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20
		$vpnConnection = Get-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Assert-AreEqual $vpnConnectionName $vpnConnection.Name
		
		# Download config
		$storetype = 'Standard_GRS'
		$containerName = 'cont' + $rgName
		New-AzureRmStorageAccount -ResourceGroupName $rgName -Name $storeName -Location $rglocation -Type $storetype
		$key = Get-AzureRmStorageAccountKey -ResourceGroupName $rgName -Name $storeName
		$context = New-AzureStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
		New-AzureStorageContainer -Name $containerName -Context $context
		$container = Get-AzureStorageContainer -Name $containerName -Context $context
		New-Item -Name EmptyFile.txt -ItemType File -Force
		Set-AzureStorageBlobContent -File "EmptyFile.txt" -Container $containerName -Blob "emptyfile.txt" -Context $context
		$now=get-date
		$blobSasUrl = New-AzureStorageBlobSASToken -Container $containerName -Blob emptyfile.txt -Context $context -Permission "rwd" -StartTime $now.AddHours(-1) -ExpiryTime $now.AddDays(1) -FullUri

		$vpnSitesForConfig = New-Object Microsoft.Azure.Commands.Network.Models.PSVpnSite[] 1
		$vpnSitesForConfig[0] = $vpnSite
		Get-AzureRmVirtualWanVpnConfiguration -VirtualWan $virtualWan -StorageSasUrl $blobSasUrl -VpnSite $vpnSitesForConfig
	}
	finally
	{
		$delete = Remove-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force -PassThru
		Assert-AreEqual $True $delete

		Clean-ResourceGroup $rgname
	}
}

function Test-CortexExpressRouteCRUD
{
 # Setup
    $rgName = Get-ResourceName
    # ExpressRoute gateways have been enabled only in westcentralus region
    $rglocation = "westcentralus"

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
		$createdVirtualWan = Update-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -AllowVnetToVnetTraffic $false -AllowBranchToBranchTraffic $false
		$virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Write-Debug "Created Virtual WAN  $virtualWan.Name successfully"

        $createdVirtualHub = New-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "10.8.0.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
        Write-Debug "Created Virtual Hub virtualHub.Name successfully"

        # Create the ExpressRouteGateway
		$createdExpressRouteGateway = New-AzureRmExpressRouteGateway -ResourceGroupName $rgName -Name $expressRouteGatewayName -VirtualHub $virtualHub -MinScaleUnits 2
        Write-Debug "Created ExpressRoute Gateway $expressRouteGatewayName successfully"
		$expressRouteGateway = Get-AzureRmExpressRouteGateway -ResourceGroupName $rgName -Name $expressRouteGatewayName
        Write-Debug "Retrieved ExpressRoute Gateway $expressRouteGatewayName successfully"

        # Create the ExpressRouteCircuit with peering to which the connection needs to be established to
        $peering = New-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -PeeringType AzurePrivatePeering -PeerASN 100 -PrimaryPeerAddressPrefix "10.2.3.4/30" -SecondaryPeerAddressPrefix "11.2.3.4/30" -VlanId 22
        #$circuit = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $rglocation -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "equinix" -PeeringLocation "Silicon Valley" -BandwidthInMbps 1000 -Peering $peering
        $circuit = New-AzureRmExpressRouteCircuit -Name $circuitName -Location $rglocation -ResourceGroupName $rgname -SkuTier Standard -SkuFamily MeteredData  -ServiceProviderName "Zayo" -PeeringLocation "Denver" -BandwidthInMbps 200 -Peering $peering
        Write-Debug "Created ExpressRoute Circuit with Private Peering $circuitName successfully"

        #Get Express Route Circuit Resource
		$circuitResult = Get-AzureRmExpressRouteCircuit -Name $circuitName -ResourceGroupName $rgname
		$peeringResult = Get-AzureRmExpressRouteCircuitPeeringConfig -Name AzurePrivatePeering -ExpressRouteCircuit $circuitResult
        Write-Debug "Created ExpressRoute Circuit with Private Peering $circuitName successfully"

        # Create the ExpressRoute Connection
		$createdExpressRouteConnection = New-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ParentResourceName $expressRouteGatewayName -Name $expressRouteConnectionName -ExpressRouteCircuitPeeringId $peeringResult.Id -RoutingWeight 10
        Write-Debug "Created ExpressRoute Connection with Private Peering $expressRouteConnectionName successfully"
		$createdExpressRouteConnection = Set-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ParentResourceName $expressRouteGatewayName -Name $expressRouteConnectionName -RoutingWeight 30
        Write-Debug "Updated ExpressRoute Connection with Private Peering $expressRouteConnectionName successfully"
		$expressRouteConnection = Get-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ParentResourceName $expressRouteGatewayName -Name $expressRouteConnectionName
        Write-Debug "Retrieved ExpressRoute Connection with Private Peering $expressRouteConnectionName successfully"
		Assert-AreEqual $expressRouteConnectionName $expressRouteConnection.Name
		Assert-AreEqual 30 $expressRouteConnection.RoutingWeight
	}
    catch
    {
        Write-Debug "Encountered an exception: $_.Exception.Message"
        throw
    }
	finally
	{
        Remove-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ParentResourceName $expressRouteGatewayName -Name $expressRouteConnectionName
		Assert-ThrowsContains { Get-AzureRmExpressRouteConnection -ResourceGroupName $rgName -ParentResourceName $expressRouteGatewayName -Name $expressRouteConnectionName } "NotFound";

        Remove-AzureRmExpressRouteGateway -ResourceGroupName $rgName -Name $expressRouteGatewayName -Force
		Assert-ThrowsContains { Get-AzureRmExpressRouteGateway -ResourceGroupName $rgName -Name $expressRouteGatewayName } "NotFound";

		Remove-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Force
		Assert-ThrowsContains { Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName } "NotFound";

		Remove-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force
		Assert-ThrowsContains { Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName } "NotFound";

		Clean-ResourceGroup $rgname
	}
}
