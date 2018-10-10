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
    $rglocation = Get-ProviderLocation "Microsoft.Network/VirtualWans"

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
		Remove-AzureRmVirtualHubVnetConnection -ResourceGroupName $rgName -ParentResourceName $virtualHubName -Name $hubVnetConnectionName -Force
		Assert-ThrowsContains { Get-AzureRmVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName } "NotFound";

		Remove-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -Force
		Assert-ThrowsContains { Get-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName } "NotFound";

		Remove-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -Force
		Assert-ThrowsContains { Get-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName } "NotFound";

		Remove-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Force
		Assert-ThrowsContains { Get-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName } "NotFound";

		Remove-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Force
		Assert-ThrowsContains { Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName } "NotFound";

		Remove-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force
		Assert-ThrowsContains { Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName } "NotFound";

		Clean-ResourceGroup $rgname
	}
}