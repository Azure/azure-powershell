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

		# Create the Virtual Hub
		$createdVirtualHub = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual "192.168.1.0/24" $virtualHub.AddressPrefix

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

		# Create the VpnGateway
		$createdVpnGateway = New-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 3
		$createdVpnGateway = Update-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VpnGatewayScaleUnit 4
		$vpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual $rgName $vpnGateway.ResourceGroupName
		Assert-AreEqual $vpnGatewayName $vpnGateway.Name
		Assert-AreEqual 4 $vpnGateway.VpnGatewayScaleUnit

		# Create the VpnConnection
		$createdVpnConnection = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20
		$createdVpnConnection = Update-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -ConnectionBandwidth 30
		$vpnConnection = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Assert-AreEqual $vpnConnectionName $vpnConnection.Name
		Assert-AreEqual 30 $vpnConnection.ConnectionBandwidth

		# Create a HubVirtualNetworkConnection
		$remoteVirtualNetwork = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $remoteVirtualNetworkName -Location $rglocation -AddressPrefix "10.0.1.0/24"
		$createdHubVnetConnection = New-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName -RemoteVirtualNetwork $remoteVirtualNetwork
		$hubVnetConnection = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName
		Assert-AreEqual $hubVnetConnectionName $hubVnetConnection.Name
	}
	finally
	{
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
	}
	finally
	{
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

		Clean-ResourceGroup $rgname
	}
}


