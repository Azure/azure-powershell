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
	$vpnSite2Name = Get-ResourceName
	$vpnSiteLink1Name = Get-ResourceName
	$vpnSiteLink2Name = Get-ResourceName
	$vpnConnection2Name = Get-ResourceName
	$vpnLink1ConnectionName = Get-ResourceName
	$vpnLink2ConnectionName = Get-ResourceName

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
		Assert-AreEqual $true $virtualWan.AllowVnetToVnetTraffic
		Assert-AreEqual $false $virtualWan.AllowBranchToBranchTraffic

        $virtualWans = Get-AzureRmVirtualWan -ResourceGroupName $rgName
        Assert-NotNull $virtualWans

        $virtualWansAll = Get-AzureRmVirtualWan
        Assert-NotNull $virtualWansAll
        Assert-NotNull $virtualWansAll[0].ResourceGroupName

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
         Assert-NotNull $virtualHubsAll[0].ResourceGroupName

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

		# Create the VpnSite with Links
		$vpnSite2AddressSpaces = New-Object string[] 2
		$vpnSite2AddressSpaces[0] = "192.169.2.0/24"
		$vpnSite2AddressSpaces[1] = "192.169.3.0/24"
		$vpnSiteLink1 = New-AzVpnSiteLink -Name $vpnSiteLink1Name -IpAddress "5.5.5.5" -LinkProviderName "SomeTelecomProvider1" -LinkSpeedInMbps "10"
		$vpnSiteLink2 = New-AzVpnSiteLink -Name $vpnSiteLink2Name -IpAddress "5.5.5.6" -LinkProviderName "SomeTelecomProvider2" -LinkSpeedInMbps "10"

		$createdVpnSite2 = New-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name -Location $rglocation -VirtualWan $virtualWan -AddressSpace $vpnSite2AddressSpaces -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -VpnSiteLink @($vpnSiteLink1, $vpnSiteLink2)
		$vpnSite2 = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name
		Assert-AreEqual $rgName $vpnSite2.ResourceGroupName
		Assert-AreEqual $vpnSite2Name $vpnSite2.Name
		Assert-AreEqual 2 $vpnSite2.VpnSiteLinks.Count
		$vpnSiteLink1.IpAddress = "7.3.4.5"
		$vpnSite2AddressSpaces = New-Object string[] 2
		$vpnSite2AddressSpaces[0] = "192.170.2.0/24"
		$vpnSite2AddressSpaces[1] = "192.170.3.0/24"
		Update-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name -VpnSiteLink @($vpnSiteLink1) -AddressSpace $vpnSite2AddressSpaces
		$updatedVpnSite2 = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name
		Assert-AreEqual 1 $updatedVpnSite2.VpnSiteLinks.Count
		Assert-AreEqual "7.3.4.5" $updatedVpnSite2.VpnSiteLinks[0].IpAddress
		Update-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name -VpnSiteLink @($vpnSiteLink1, $vpnSiteLink2)

        $vpnSites = Get-AzureRmVpnSite -ResourceGroupName $rgName
        Assert-NotNull $vpnSites

        $vpnSitesAll = Get-AzVpnSite
        Assert-NotNull $vpnSitesAll
        Assert-NotNull $vpnSitesAll[0].ResourceGroupName

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

        $vpnGateways = Get-AzVpnGateway
        Assert-NotNull $vpnGateways
        Assert-NotNull $vpnGateways[0].ResourceGroupName

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
		$createdVpnConnection = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20 -UseLocalAzureIpAddress 
		Assert-AreEqual $true $createdVpnConnection.UseLocalAzureIpAddress
		
		$createdVpnConnection = Update-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -ConnectionBandwidth 30 -UseLocalAzureIpAddress $false
		$vpnConnection = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Assert-AreEqual $vpnConnectionName $vpnConnection.Name
		Assert-AreEqual 30 $vpnConnection.ConnectionBandwidth
		Assert-AreEqual $false $vpnConnection.UseLocalAzureIpAddress 

		# Create the VpnConnection with site with links
		$vpnSiteLinkConnection1 = New-AzVpnSiteLinkConnection -Name $vpnLink1ConnectionName -VpnSiteLink $vpnSite2.VpnSiteLinks[0] -ConnectionBandwidth 100
	    $vpnSiteLinkConnection2 = New-AzVpnSiteLinkConnection -Name $vpnLink2ConnectionName -VpnSiteLink $vpnSite2.VpnSiteLinks[1] -ConnectionBandwidth 10

		$createdVpnConnection2 = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name -VpnSite $vpnSite2 -VpnSiteLinkConnection @($vpnSiteLinkConnection1, $vpnSiteLinkConnection2)
		$vpnConnection2 = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name
		Assert-AreEqual $vpnConnection2Name $vpnConnection2.Name
		Assert-AreEqual 2 $vpnConnection2.VpnLinkConnections.Count

		$vpnSiteLinkConnection1.RoutingWeight = 10
		Update-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name -VpnSiteLinkConnection @($vpnSiteLinkConnection1)
		$vpnConnection2 = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name

		Assert-AreEqual $vpnConnection2Name $vpnConnection2.Name
		Assert-AreEqual 1 $vpnConnection2.VpnLinkConnections.Count
		Assert-AreEqual 10 $vpnConnection2.VpnLinkConnections[0].RoutingWeight

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

		$delete = Remove-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name -Force -PassThru
        Assert-AreEqual $True $delete

        $delete = Remove-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -Force -PassThru
        Assert-AreEqual $True $delete

        $delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Force -PassThru
        Assert-AreEqual $True $delete

		$delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name -Force -PassThru
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
	$vpnSite2Name = Get-ResourceName
	$vpnSiteLink1Name = Get-ResourceName
	$vpnSiteLink2Name = Get-ResourceName
	$vpnGatewayName = Get-ResourceName
	$remoteVirtualNetworkName = Get-ResourceName
	$vpnConnectionName = Get-ResourceName
	$vpnConnection2Name = Get-ResourceName
	$vpnLink1ConnectionName = Get-ResourceName
	$vpnLink2ConnectionName = Get-ResourceName
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
		
		# Create the VpnSite with Links
		$vpnSite2AddressSpaces = New-Object string[] 2
		$vpnSite2AddressSpaces[0] = "192.169.2.0/24"
		$vpnSite2AddressSpaces[1] = "192.169.3.0/24"
		$vpnSiteLink1 = New-AzVpnSiteLink -Name $vpnSiteLink1Name -IpAddress "5.5.5.5" -LinkProviderName "SomeTelecomProvider1" -LinkSpeedInMbps "10"
		$vpnSiteLink2 = New-AzVpnSiteLink -Name $vpnSiteLink2Name -IpAddress "5.5.5.6" -LinkProviderName "SomeTelecomProvider2" -LinkSpeedInMbps "100"
		$createdVpnSite2 = New-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name -Location $rglocation -VirtualWan $virtualWan -AddressSpace $vpnSite2AddressSpaces -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -VpnSiteLink @($vpnSiteLink1, $vpnSiteLink2)
		$vpnSite2 = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name
		Assert-AreEqual $rgName $vpnSite2.ResourceGroupName
		Assert-AreEqual $vpnSite2Name $vpnSite2.Name
		Assert-AreEqual 2 $vpnSite2.VpnSiteLinks.Count 

		# Create the VpnGateway
		$createdVpnGateway = New-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 3
		$vpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual $rgName $vpnGateway.ResourceGroupName
		Assert-AreEqual $vpnGatewayName $vpnGateway.Name
		
		# Create the VpnConnection
		$createdVpnConnection = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20
		$vpnConnection = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Assert-AreEqual $vpnConnectionName $vpnConnection.Name
		
		# Create the VpnConnection with site with links
		$vpnSiteLinkConnection1 = New-AzVpnSiteLinkConnection -Name $vpnLink1ConnectionName -VpnSiteLink $vpnSite2.VpnSiteLinks[0] -ConnectionBandwidth 100
	    $vpnSiteLinkConnection2 = New-AzVpnSiteLinkConnection -Name $vpnLink2ConnectionName -VpnSiteLink $vpnSite2.VpnSiteLinks[1] -ConnectionBandwidth 10

		$createdVpnConnection2 = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name -VpnSite $vpnSite2 -VpnSiteLinkConnection @($vpnSiteLinkConnection1, $vpnSiteLinkConnection2)
		$vpnConnection2 = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name
		Assert-AreEqual $vpnConnection2Name $vpnConnection2.Name
		Assert-AreEqual 2 $vpnConnection2.VpnLinkConnections.Count

		# Download config
		$storetype = 'Standard_GRS'
		$containerName = "cont$($rgName)"
		New-AzStorageAccount -ResourceGroupName $rgName -Name $storeName -Location $rglocation -Type $storetype
		$key = Get-AzStorageAccountKey -ResourceGroupName $rgName -Name $storeName
		$context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
		New-AzStorageContainer -Name $containerName -Context $context
		$container = Get-AzStorageContainer -Name $containerName -Context $context
		New-Item -Name EmptyFile.txt -ItemType File -Force
		Set-AzStorageBlobContent -File "EmptyFile.txt" -Container $containerName -Blob "emptyfile.txt" -Context $context
		$now=get-date
		$blobSasUrl = New-AzStorageBlobSASToken -Container $containerName -Blob emptyfile.txt -Context $context -Permission "rwd" -StartTime $now.AddHours(-1) -ExpiryTime $now.AddDays(1) -FullUri

		$vpnSitesForConfig = New-Object Microsoft.Azure.Commands.Network.Models.PSVpnSite[] 2
		$vpnSitesForConfig[0] = $vpnSite
		$vpnSitesForConfig[1] = $vpnSite2
		Get-AzVirtualWanVpnConfiguration -VirtualWan $virtualWan -StorageSasUrl $blobSasUrl -VpnSite $vpnSitesForConfig

		$delete = Remove-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -Force -PassThru
		Assert-AreEqual $True $delete
		
		$delete = Remove-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name -Force -PassThru
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
    $rgName = Get-ResourceGroupName
    $hubRgName = Get-ResourceGroupName
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
        $resourceGroup = New-AzureRmResourceGroup -Name $hubRgName -Location $rglocation

        # Create the Virtual Wan
        $createdVirtualWan = New-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
        $virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
        Write-Debug "Created Virtual WAN $virtualWan.Name successfully"

        $createdVirtualHub = New-AzureRmVirtualHub -ResourceGroupName $hubRgName -Name $virtualHubName -Location $rglocation -AddressPrefix "10.8.0.0/24" -VirtualWan $virtualWan
        $virtualHub = Get-AzureRmVirtualHub -ResourceGroupName $hubRgName -Name $virtualHubName
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

        Remove-AzureRmVirtualHub -ResourceGroupName $hubRgName -Name $virtualHubName -Force

        Remove-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force
        Assert-ThrowsLike { Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName } "*Not*Found*"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<# .SYNOPSIS
 Point to site Cortex feature tests
 #>
 function Test-P2SCortexCRUD
 {
 param 
    ( 
        $basedir = ".\" 
    )

    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation "Microsoft.Network/VirtualWans"
 
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName
    $VpnServerConfiguration1Name = Get-ResourceName
    $VpnServerConfiguration2Name = Get-ResourceName
    $P2SVpnGatewayName = Get-ResourceName
    $vpnclientAuthMethod = "EAPTLS"

    $storeName = 'blob' + $rgName

    try
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic
		$virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name

		# Create the Virtual Hub
		$createdVirtualHub = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual $virtualWan.Id $virtualhub.VirtualWan.Id

		# Create the VpnServerConfiguration1 with VpnClient settings using New-AzVpnServerConfiguration
		$VpnServerConfigCertFilePath = Join-Path -Path $basedir -ChildPath "\ScenarioTests\Data\ApplicationGatewayAuthCert.cer"
		$listOfCerts = New-Object "System.Collections.Generic.List[String]"
		$listOfCerts.Add($VpnServerConfigCertFilePath)
		$vpnclientipsecpolicy1 = New-AzVpnClientIpsecPolicy -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTime 86471 -SADataSize 429496 -IkeEncryption AES256 -IkeIntegrity SHA384 -DhGroup DHGroup14 -PfsGroup PFS14
        New-AzVpnServerConfiguration -Name $VpnServerConfiguration1Name -ResourceGroupName $rgName -VpnProtocol IkeV2 -VpnAuthenticationType Certificate -VpnClientRootCertificateFilesList $listOfCerts -VpnClientRevokedCertificateFilesList $listOfCerts -VpnClientIpsecPolicy $vpnclientipsecpolicy1 -Location $rglocation

        # Get created VpnServerConfiguration using Get-AzVpnServerConfiguration
        $vpnServerConfig1 = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration1Name
        Assert-NotNull $vpnServerConfig1
		Assert-AreEqual $rgName $vpnServerConfig1.ResourceGroupName
		Assert-AreEqual $VpnServerConfiguration1Name $vpnServerConfig1.Name
		$protocols = $vpnServerConfig1.VpnProtocols
		Assert-AreEqual 1 @($protocols).Count
		Assert-AreEqual "IkeV2" $protocols[0]
		$authenticationTypes = $vpnServerConfig1.VpnAuthenticationTypes
		Assert-AreEqual 1 @($authenticationTypes).Count
		Assert-AreEqual "Certificate" $authenticationTypes[0]

		# Create the P2SVpnGateway using New-AzP2sVpnGateway
		$vpnClientAddressSpaces = New-Object string[] 2
		$vpnClientAddressSpaces[0] = "192.168.2.0/24"
		$vpnClientAddressSpaces[1] = "192.168.3.0/24"
		$customDnsServers = New-Object string[] 2
		$customDnsServers[0] = "7.7.7.7"
		$customDnsServers[1] = "8.8.8.8"
		$createdP2SVpnGateway = New-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 1 -VpnClientAddressPool $vpnClientAddressSpaces -VpnServerConfiguration $vpnServerConfig1 -CustomDnsServer $customDnsServers
		Assert-AreEqual "Succeeded" $createdP2SVpnGateway.ProvisioningState

		# Get the created P2SVpnGateway using Get-AzP2sVpnGateway
		$P2SVpnGateway = Get-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
		Assert-AreEqual $rgName $P2SVpnGateway.ResourceGroupName
		Assert-AreEqual $P2SvpnGatewayName $P2SVpnGateway.Name
		Assert-AreEqual $vpnServerConfig1.Id $P2SVpnGateway.VpnServerConfiguration.Id
		Assert-AreEqual "Succeeded" $P2SVpnGateway.ProvisioningState
		Assert-AreEqual 2 @($P2SVpnGateway.CustomDnsServers).Count
        Assert-AreEqual "7.7.7.7" $P2SVpnGateway.CustomDnsServers[0]
		Assert-AreEqual "8.8.8.8" $P2SVpnGateway.CustomDnsServers[1]

		# Get all associated VpnServerConfigurations at Wan level using Get-AzVirtualWanVpnServerConfiguration
        $associatedVpnServerConfigs = Get-AzVirtualWanVpnServerConfiguration -Name $virtualWanName -ResourceGroupName $rgName
        Assert-NotNull $associatedVpnServerConfigs
        Assert-AreEqual 1 @($associatedVpnServerConfigs.VpnServerConfigurationResourceIds).Count
        Assert-AreEqual $vpnServerConfig1.Id $associatedVpnServerConfigs.VpnServerConfigurationResourceIds[0]

        # Get VpnServerConfiguration1 and see that it shows as attached to P2SVpnGateway created.
        $vpnServerConfig1 = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration1Name
        Assert-NotNull $vpnServerConfig1
        Assert-AreEqual $vpnServerConfig1.P2sVpnGateways[0].Id $P2SVpnGateway.Id

        # List all VpnServerConfigurations under Resource group
        $vpnServerConfigs = Get-AzVpnServerConfiguration -ResourceGroupName $rgName
        Assert-NotNull $vpnServerConfigs
        Assert-AreEqual 1 @($vpnServerConfigs).Count
        
        # Generate vpn profile at Hub/P2SVpnGateway level using Get-AzP2sVpnGatewayVpnProfile
		$vpnProfileResponse = Get-AzP2sVpnGatewayVpnProfile -Name $P2SVpnGatewayName -ResourceGroupName $rgName -AuthenticationMethod $vpnclientAuthMethod
		Assert-NotNull $vpnProfileResponse.ProfileUrl
		Assert-AreEqual True ($vpnProfileResponse.ProfileUrl -Match "zip")

		# Generate vpn profile at Wan-VpnServerConfiguration combination level using Get-AzP2sVpnGatewayVpnProfile
		$vpnProfileWanResponse = Get-AzVirtualWanVpnServerConfigurationVpnProfile -Name $virtualWanName -ResourceGroupName $rgName -AuthenticationMethod $vpnclientAuthMethod -VpnServerConfiguration $vpnServerConfig1
		Assert-NotNull $vpnProfileWanResponse.ProfileUrl
		Assert-AreEqual True ($vpnProfileWanResponse.ProfileUrl -Match "zip")

		# Create the VpnServerConfiguration2 with RadiusClient settings using New-AzVpnServerConfiguration
		#[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine", Justification="Test passwords only valid for the duration of the test")]
		$Secure_String_Pwd = ConvertTo-SecureString "TestRadiusServerPassword" -AsPlainText -Force
		New-AzVpnServerConfiguration -Name $VpnServerConfiguration2Name -ResourceGroupName $rgName -VpnProtocol IkeV2 -VpnAuthenticationType Radius -RadiusServerAddress "TestRadiusServer" -RadiusServerSecret $Secure_String_Pwd -RadiusServerRootCertificateFilesList $listOfCerts -RadiusClientRootCertificateFilesList $listOfCerts -Location $rglocation
        
        $vpnServerConfig2 = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration2Name
		Assert-AreEqual "Succeeded" $vpnServerConfig2.ProvisioningState
		Assert-AreEqual "TestRadiusServer" $vpnServerConfig2.RadiusServerAddress
	
        # List all VpnServerConfigurations under Resource group
        $vpnServerConfigs = Get-AzVpnServerConfiguration -ResourceGroupName $rgName
        Assert-NotNull $vpnServerConfigs
        Assert-AreEqual 2 @($vpnServerConfigs).Count

		# Update existing VpnServerConfiguration2 using Update-AzVpnServerConfiguration
		Update-AzVpnServerConfiguration -Name $VpnServerConfiguration2Name -ResourceGroupName $rgName -RadiusServerAddress "TestRadiusServer1"
		$VpnServerConfig2 = Get-AzVpnServerConfiguration -Name $VpnServerConfiguration2Name -ResourceGroupName $rgName
		Assert-AreEqual $VpnServerConfiguration2Name $VpnServerConfig2.Name
		Assert-AreEqual "TestRadiusServer1" $VpnServerConfig2.RadiusServerAddress
		
		Update-AzVpnServerConfiguration -ResourceId  $VpnServerConfig2.Id -RadiusServerAddress "TestRadiusServer2"			
		$VpnServerConfig2Get = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration2Name
		Assert-AreEqual "TestRadiusServer2" $VpnServerConfig2Get.RadiusServerAddress
						
		Update-AzVpnServerConfiguration -InputObject $VpnServerConfig2Get -RadiusServerAddress "TestRadiusServer3"
		$VpnServerConfig2Get = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration2Name
        Assert-AreEqual "TestRadiusServer3" $VpnServerConfig2Get.RadiusServerAddress

        # Update existing P2SVpnGateway  with new VpnClientAddressPool and CustomDnsServers using Update-AzP2sVpnGateway
        $vpnClientAddressSpaces[1] = "192.168.4.0/24"
        $updatedP2SVpnGateway = Update-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName -VpnClientAddressPool $vpnClientAddressSpaces -CustomDnsServer 9.9.9.9

        $P2SVpnGateway = Get-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
		Assert-AreEqual $P2SvpnGatewayName $P2SVpnGateway.Name
		Assert-AreEqual "Succeeded" $P2SVpnGateway.ProvisioningState
		Assert-AreEqual $vpnServerConfig1.Id $P2SVpnGateway.VpnServerConfiguration.Id
		$setVpnClientAddressSpacesString = [system.String]::Join(" ", $vpnClientAddressSpaces)
        Assert-AreEqual $setVpnClientAddressSpacesString $P2SVpnGateway.P2SConnectionConfigurations[0].VpnClientAddressPool.AddressPrefixes
		Assert-AreEqual 1 @($P2SVpnGateway.CustomDnsServers).Count
        Assert-AreEqual "9.9.9.9" $P2SVpnGateway.CustomDnsServers[0]

		# Update existing P2SVpnGateway to remove the CustomDnsServers
		$P2SVpnGateway = Get-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
		Update-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName -CustomDnsServer @()
        $P2SVpnGateway = Get-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
        Assert-AreEqual 0 @($P2SVpnGateway.CustomDnsServers).Count

        $associatedVpnServerConfigs = Get-AzVirtualWanVpnServerConfiguration -ResourceId $virtualWan.Id
        Assert-NotNull $associatedVpnServerConfigs
        Assert-AreEqual 1 @($associatedVpnServerConfigs.VpnServerConfigurationResourceIds).Count
        Assert-AreEqual $vpnServerConfig1.Id $associatedVpnServerConfigs.VpnServerConfigurationResourceIds[0]

        # Delete VpnServerConfiguration2 using Remove-AzVirtualWanVpnServerConfiguration
		$delete = Remove-AzVpnServerConfiguration -InputObject $VpnServerConfig2Get -Force -PassThru
		Assert-AreEqual $True $delete

		$vpnServerConfigs = Get-AzVpnServerConfiguration -ResourceGroupName $rgName
        Assert-NotNull $vpnServerConfigs
        Assert-AreEqual 1 @($vpnServerConfigs).Count

        # Get aggreagated point to site connections health from P2SVpnGateway
        #$aggregatedConnectionHealth = Get-AzP2sVpnGatewayConnectionHealth -Name $P2SvpnGatewayName -ResourceGroupName $rgName
        #Assert-NotNull $aggregatedConnectionHealth
        #Assert-NotNull $aggregatedConnectionHealth.VpnClientConnectionHealth
        #Assert-AreEqual 0 $aggregatedConnectionHealth.VpnClientConnectionHealth.VpnClientConnectionsCount
        
        # Get a SAS url for getting detained point to site connections health details.
        $storetype = 'Standard_GRS'
		$containerName = "cont$($rgName)"
		New-AzStorageAccount -ResourceGroupName $rgName -Name $storeName -Location $rglocation -Type $storetype
		$key = Get-AzStorageAccountKey -ResourceGroupName $rgName -Name $storeName
		$context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
		New-AzStorageContainer -Name $containerName -Context $context
		$container = Get-AzStorageContainer -Name $containerName -Context $context
		New-Item -Name EmptyFile.txt -ItemType File -Force
		Set-AzStorageBlobContent -File "EmptyFile.txt" -Container $containerName -Blob "emptyfile.txt" -Context $context
		$now=get-date
		$blobSasUrl = New-AzStorageBlobSASToken -Container $containerName -Blob emptyfile.txt -Context $context -Permission "rwd" -StartTime $now.AddHours(-1) -ExpiryTime $now.AddDays(1) -FullUri

        # Get detailed point to site connections health from P2SVpnGateway
        $detailedConnectionHealth = Get-AzP2sVpnGatewayDetailedConnectionHealth -Name $P2SvpnGatewayName -ResourceGroupName $rgName -OutputBlobSasUrl $blobSasUrl
        Assert-NotNull $detailedConnectionHealth
        Assert-NotNull $detailedConnectionHealth.SasUrl
        Assert-AreEqual $blobSasUrl $detailedConnectionHealth.SasUrl
     }
     finally
     {
		# Delete P2SVpnGateway using Remove-AzP2sVpnGateway
		$delete = Remove-AzP2sVpnGateway -Name $P2SVpnGatewayName -ResourceGroupName $rgName -Force -PassThru
		Assert-AreEqual $True $delete

        # Verify that there are no associated VpnServerConfigurations to Virtual wan anymore
        $associatedVpnServerConfigs = Get-AzVirtualWanVpnServerConfiguration -Name $virtualWanName -ResourceGroupName $rgName
        Assert-NotNull $associatedVpnServerConfigs
        Assert-AreEqual 0 @($associatedVpnServerConfigs.VpnServerConfigurationResourceIds).Count

		# Delete VpnServerConfiguration1 using Remove-AzVpnServerConfiguration      
		$delete = Remove-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration1Name -Force -PassThru
		Assert-AreEqual $True $delete

		# Delete Virtual hub
		$delete = Remove-AzVirtualHub -ResourceGroupName $rgname -Name $virtualHubName -Force -PassThru
		Assert-AreEqual $True $delete

		# Delete Virtual wan
		$delete = Remove-AzVirtualWan -InputObject $virtualWan -Force -PassThru
		Assert-AreEqual $True $delete

		Clean-ResourceGroup $rgname
     }
}

<# 
.SYNOPSIS
 Disconnect Point to site vpn gateway vpn connection
 #>
 function Test-DisconnectAzP2sVpnGatewayVpnConnection
 {
 param 
    ( 
        $basedir = ".\" 
    )

    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = "East US"
 
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName
    $VpnServerConfiguration1Name = Get-ResourceName
    $P2SVpnGatewayName = Get-ResourceName
    
    try
	{
		# Create the resource group
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Create the Virtual Wan
		New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation
		$virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $virtualWanName $virtualWan.Name

		# Create the Virtual Hub
		New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual $virtualWan.Id $virtualhub.VirtualWan.Id

		# Create the VpnServerConfiguration1 with VpnClient settings using New-AzVpnServerConfiguration
		$VpnServerConfigCertFilePath = Join-Path -Path $basedir -ChildPath "\ScenarioTests\Data\ApplicationGatewayAuthCert.cer"
		$listOfCerts = New-Object "System.Collections.Generic.List[String]"
		$listOfCerts.Add($VpnServerConfigCertFilePath)
		$vpnclientipsecpolicy1 = New-AzVpnClientIpsecPolicy -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTime 86471 -SADataSize 429496 -IkeEncryption AES256 -IkeIntegrity SHA384 -DhGroup DHGroup14 -PfsGroup PFS14
        New-AzVpnServerConfiguration -Name $VpnServerConfiguration1Name -ResourceGroupName $rgName -VpnProtocol IkeV2 -VpnAuthenticationType Certificate -VpnClientRootCertificateFilesList $listOfCerts -VpnClientRevokedCertificateFilesList $listOfCerts -VpnClientIpsecPolicy $vpnclientipsecpolicy1 -Location $rglocation

        # Get created VpnServerConfiguration using Get-AzVpnServerConfiguration
        $vpnServerConfig1 = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration1Name
        Assert-NotNull $vpnServerConfig1
		
		# Create the P2SVpnGateway using New-AzP2sVpnGateway
		$vpnClientAddressSpaces = New-Object string[] 2
		$vpnClientAddressSpaces[0] = "192.168.2.0/24"
		$vpnClientAddressSpaces[1] = "192.168.3.0/24"
		New-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 1 -VpnClientAddressPool $vpnClientAddressSpaces -VpnServerConfiguration $vpnServerConfig1
		
		# Get the created P2SVpnGateway using Get-AzP2sVpnGateway
		$P2SVpnGateway = Get-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
		Assert-AreEqual $P2SvpnGatewayName $P2SVpnGateway.Name
		Assert-AreEqual "Succeeded" $P2SVpnGateway.ProvisioningState

		$expected = Disconnect-AzP2SVpnGatewayVpnConnection -ResourceGroupName $rgname -ResourceName $P2SvpnGatewayName -VpnConnectionId @("IKEv2_1e1cfe59-5c7c-4315-a876-b11fbfdfeed4")
        Assert-AreEqual $expected.Name $P2SVpnGateway.Name
     }
     finally
     {
		# Delete P2SVpnGateway using Remove-AzP2sVpnGateway
		$delete = Remove-AzP2sVpnGateway -Name $P2SVpnGatewayName -ResourceGroupName $rgName -Force -PassThru
		Assert-AreEqual $True $delete

		# Delete VpnServerConfiguration1 using Remove-AzVpnServerConfiguration      
		$delete = Remove-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration1Name -Force -PassThru
		Assert-AreEqual $True $delete

		# Delete Virtual hub
		$delete = Remove-AzVirtualHub -ResourceGroupName $rgname -Name $virtualHubName -Force -PassThru
		Assert-AreEqual $True $delete

		# Delete Virtual wan
		$delete = Remove-AzVirtualWan -InputObject $virtualWan -Force -PassThru
		Assert-AreEqual $True $delete

		Clean-ResourceGroup $rgname
     }
}

<#
.SYNOPSIS
create a vpn gateway and start packet capture
#>
function Test-VpnGatewayPacketCapture
{
	# Setup
	$rgName = Get-ResourceName
	$rglocation = Get-ProviderLocation ResourceManagement "West Central US"
	$virtualWanName = Get-ResourceName
	$virtualHubName = Get-ResourceName
	$vpnGatewayName = Get-ResourceName

	try
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
		$virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name
		Assert-AreEqual $true $virtualWan.AllowVnetToVnetTraffic
		Assert-AreEqual $true $virtualWan.AllowBranchToBranchTraffic

		# Create the Virtual Hub
		$createdVirtualHub = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "10.0.0.0/16" -VirtualWan $virtualWan
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual "10.0.0.0/16" $virtualHub.AddressPrefix

		# Create the VpnGateway
		$createdVpnGateway = New-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 3
		Assert-AreEqual $rgName $createdVpnGateway.ResourceGroupName
		Assert-AreEqual $vpnGatewayName $createdVpnGateway.Name
		Assert-AreEqual 3 $createdVpnGateway.VpnGatewayScaleUnit

		#create SAS URL
		if ((Get-NetworkTestMode) -ne 'Playback')
		{
			$storetype = 'Standard_GRS'
			$containerName = "testcontainer"
			$storeName = 'sto' + $rgname;
			New-AzStorageAccount -ResourceGroupName $rgname -Name $storeName -Location $rglocation -Type $storetype
			$key = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $storeName
			$context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
			New-AzStorageContainer -Name $containerName -Context $context
			$container = Get-AzStorageContainer -Name $containerName -Context $context
			$now=get-date
			$sasurl = New-AzStorageContainerSASToken -Name $containerName -Context $context -Permission "rwd" -StartTime $now.AddHours(-1) -ExpiryTime $now.AddDays(1) -FullUri
		}
		else
		{
			$sasurl = "https://storage/test123?sp=racwdl&stvigopKcy"
		}

		#StartPacketCapture on gateway with Name parameter
		$output = Start-AzVpnGatewayPacketCapture -ResourceGroupName  $rgname -Name $vpnGatewayName
		Assert-AreEqual $createdVpnGateway.ResourceGroupName $output.ResourceGroupName	
		Assert-AreEqual $createdVpnGateway.Name $output.Name
		Assert-AreEqual $createdVpnGateway.ResourceGroupName $output.ResourceGroupName	
		Assert-AreEqual $createdVpnGateway.Location $output.Location
		Assert-AreEqual $output.Code "Succeeded"

		#StopPacketCapture on gateway with Name parameter
		$output = Stop-AzVpnGatewayPacketCapture -ResourceGroupName  $rgname -Name $vpnGatewayName -SasUrl $sasurl
		Assert-AreEqual $createdVpnGateway.ResourceGroupName $output.ResourceGroupName	
		Assert-AreEqual $createdVpnGateway.Name $output.Name
		Assert-AreEqual $createdVpnGateway.ResourceGroupName $output.ResourceGroupName	
		Assert-AreEqual $createdVpnGateway.Location $output.Location
		Assert-AreEqual $output.Code "Succeeded"

		#StartPacketCapture on gateway object
		$a="{`"TracingFlags`":11,`"MaxPacketBufferSize`":120,`"MaxFileSize`":500,`"Filters`":[{`"SourceSubnets`":[`"10.19.0.4/32`",`"10.20.0.4/32`"],`"DestinationSubnets`":[`"10.20.0.4/32`",`"10.19.0.4/32`"],`"IpSubnetValueAsAny`":true,`"TcpFlags`":-1,`"PortValueAsAny`":true,`"CaptureSingleDirectionTrafficOnly`":true}]}"
		$output = Start-AzVpnGatewayPacketCapture -InputObject $createdVpnGateway -FilterData $a
		Assert-AreEqual $createdVpnGateway.ResourceGroupName $output.ResourceGroupName	
		Assert-AreEqual $createdVpnGateway.Name $output.Name
		Assert-AreEqual $createdVpnGateway.ResourceGroupName $output.ResourceGroupName	
		Assert-AreEqual $createdVpnGateway.Location $output.Location
		Assert-AreEqual $output.Code "Succeeded"

		#StopPacketCapture on gateway object
		$output = Stop-AzVpnGatewayPacketCapture -InputObject $createdVpnGateway -SasUrl $sasurl
		Assert-AreEqual $createdVpnGateway.ResourceGroupName $output.ResourceGroupName	
		Assert-AreEqual $createdVpnGateway.Name $output.Name
		Assert-AreEqual $createdVpnGateway.ResourceGroupName $output.ResourceGroupName	
		Assert-AreEqual $createdVpnGateway.Location $output.Location
		Assert-AreEqual $output.Code "Succeeded"

		# Delete the resources
		$delete = Remove-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -Force -PassThru
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
CortexCRUD
#>
function Test-VpnConnectionPacketCapture
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
	$vpnSiteLink1Name = Get-ResourceName
	$vpnSiteLink2Name = Get-ResourceName
	$vpnLink1ConnectionName = Get-ResourceName
	$vpnLink2ConnectionName = Get-ResourceName
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

		# Create the VpnSite with Links
		$vpnSiteAddressSpaces = New-Object string[] 2
		$vpnSiteAddressSpaces[0] = "192.169.2.0/24"
		$vpnSiteAddressSpaces[1] = "192.169.3.0/24"
		$vpnSiteLink1 = New-AzVpnSiteLink -Name $vpnSiteLink1Name -IpAddress "5.5.5.5" -LinkProviderName "SomeTelecomProvider1" -LinkSpeedInMbps "10"
		$vpnSiteLink2 = New-AzVpnSiteLink -Name $vpnSiteLink2Name -IpAddress "5.5.5.6" -LinkProviderName "SomeTelecomProvider2" -LinkSpeedInMbps "10"

		$createdVpnSite = New-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Location $rglocation -VirtualWan $virtualWan -AddressSpace $vpnSiteAddressSpaces -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -VpnSiteLink @($vpnSiteLink1, $vpnSiteLink2)
		Assert-AreEqual $rgName $createdVpnSite.ResourceGroupName
		Assert-AreEqual $vpnSiteName $createdVpnSite.Name
		Assert-AreEqual 2 $createdVpnSite.VpnSiteLinks.Count

		# Create the VpnGateway
		$createdVpnGateway = New-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 3
		Assert-AreEqual $rgName $createdVpnGateway.ResourceGroupName
		Assert-AreEqual $vpnGatewayName $createdVpnGateway.Name
		Assert-AreEqual 3 $createdVpnGateway.VpnGatewayScaleUnit


		# Create the VpnConnection with site with links
		$vpnSiteLinkConnection1 = New-AzVpnSiteLinkConnection -Name $vpnLink1ConnectionName -VpnSiteLink $createdVpnSite.VpnSiteLinks[0] -ConnectionBandwidth 100
	    $vpnSiteLinkConnection2 = New-AzVpnSiteLinkConnection -Name $vpnLink2ConnectionName -VpnSiteLink $createdVpnSite.VpnSiteLinks[1] -ConnectionBandwidth 10

		$createdVpnConnection = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $createdVpnSite -VpnSiteLinkConnection @($vpnSiteLinkConnection1, $vpnSiteLinkConnection2)

		#create SAS URL
		if ((Get-NetworkTestMode) -ne 'Playback')
		{
			$storetype = 'Standard_GRS'
			$containerName = "testcontainer"
			$storeName = 'sto2' + $rgname;
			New-AzStorageAccount -ResourceGroupName $rgname -Name $storeName -Location $rglocation -Type $storetype
			$key = Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $storeName
			$context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
			New-AzStorageContainer -Name $containerName -Context $context
			$container = Get-AzStorageContainer -Name $containerName -Context $context
			$now=get-date
			$sasurl = New-AzStorageContainerSASToken -Name $containerName -Context $context -Permission "rwd" -StartTime $now.AddHours(-1) -ExpiryTime $now.AddDays(1) -FullUri
		}
		else
		{
			$sasurl = "https://storage/test123?sp=racwdl&stvigopKcy"
		}
		
		$SiteLinkConnections = $vpnSiteLinkConnection1.Name + "," + $vpnSiteLinkConnection2.Name
		# StartPacketCapture on VpnConnection with Name parameter
		$output = Start-AzVpnConnectionPacketCapture -ResourceGroupName  $rgname -Name $vpnConnectionName  -ParentResourceName $vpnGatewayName -LinkConnectionName $SiteLinkConnections
		Assert-AreEqual $createdVpnConnection.Name $output.Name
		Assert-AreEqual $output.Code "Succeeded"

		#StopPacketCapture on VpnConnection with Name parameter
		$output = Stop-AzVpnConnectionPacketCapture -ResourceGroupName  $rgname -Name $vpnConnectionName  -ParentResourceName $vpnGatewayName -SasUrl $sasurl -LinkConnectionName $SiteLinkConnections
		Assert-AreEqual $createdVpnConnection.Name $output.Name
		Assert-AreEqual $output.Code "Succeeded"

		#StartPacketCapture on gateway object with filterData 
		$a="{`"TracingFlags`":11,`"MaxPacketBufferSize`":120,`"MaxFileSize`":500,`"Filters`":[{`"SourceSubnets`":[`"10.19.0.4/32`",`"10.20.0.4/32`"],`"DestinationSubnets`":[`"10.20.0.4/32`",`"10.19.0.4/32`"],`"IpSubnetValueAsAny`":true,`"TcpFlags`":-1,`"PortValueAsAny`":true,`"CaptureSingleDirectionTrafficOnly`":true}]}"
		$output = Start-AzVpnConnectionPacketCapture -InputObject $createdVpnConnection -FilterData $a -LinkConnectionName $SiteLinkConnections
		Assert-AreEqual $createdVpnConnection.Name $output.Name
		Assert-AreEqual $output.Code "Succeeded"

		#StopPacketCapture on gateway object
		$output = Stop-AzVpnConnectionPacketCapture -InputObject $createdVpnConnection -SasUrl $sasurl -LinkConnectionName $SiteLinkConnections
		Assert-AreEqual $createdVpnConnection.Name $output.Name
		Assert-AreEqual $output.Code "Succeeded"

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
 Disconnect site to site vpn gateway BgpSettings
 #>
 function Test-BgpUpdateVpnGateway
 {
 param 
    ( 
        $basedir = ".\" 
    )

    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = "West Central US"
 
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName
    $VpnGatewayName = Get-ResourceName
    
    try
	{
		# Create the resource group
		New-AzResourceGroup -Name $rgname -Location $rglocation

		# Create the Virtual Wan
		New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation
		$virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $virtualWanName $virtualWan.Name

		# Create the Virtual Hub
		New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual $virtualWan.Id $virtualhub.VirtualWan.Id
		
		# Create the VpnGateway
		$createdVpnGateway = New-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 2
		
		# Get the created VpnGateway using Get-AzVpnGateway
		$vpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName

		$addr1 = New-AzIpConfigurationBgpPeeringAddressObject -IpConfigurationId $vpnGateway.BgpSettings.BgpPeeringAddresses[0].IpConfigurationId -CustomAddress @("169.254.22.5")
		$addr2 = New-AzIpConfigurationBgpPeeringAddressObject -IpConfigurationId $vpnGateway.BgpSettings.BgpPeeringAddresses[1].IpConfigurationId -CustomAddress @("169.254.22.10")
		$createdVpnGateway = Update-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -BgpPeeringAddress @($addr1,$addr2)
		$updatedvpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual 1 @($updatedvpnGateway.BgpSettings.BGPPeeringAddresses[0]).Count
		Assert-AreEqual 1 @($updatedvpnGateway.BgpSettings.BGPPeeringAddresses[1]).Count
     }
     finally
     {
		# Delete VpnGateway using Remove-AzVpnGateway
		$delete = Remove-AzVpnGateway -Name $VpnGatewayName -ResourceGroupName $rgName -Force -PassThru
		Assert-AreEqual $True $delete

		# Delete Virtual hub
		$delete = Remove-AzVirtualHub -ResourceGroupName $rgname -Name $virtualHubName -Force -PassThru
		Assert-AreEqual $True $delete

		# Delete Virtual wan
		$delete = Remove-AzVirtualWan -InputObject $virtualWan -Force -PassThru
		Assert-AreEqual $True $delete

		Clean-ResourceGroup $rgname
     }
}

function Test-CortexVirtualHubCRUD
{
	# Setup
    $rgName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement "West Central US"

	$virtualWanName = Get-ResourceName
	$virtualHubName = Get-ResourceName

	try
	{
		# Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
		$virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name
		Assert-AreEqual $true $virtualWan.AllowVnetToVnetTraffic
		Assert-AreEqual $true $virtualWan.AllowBranchToBranchTraffic

		# Create the Virtual Hub
		$createdVirtualHub = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "10.0.0.0/16" -VirtualWan $virtualWan
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual "10.0.0.0/16" $virtualHub.AddressPrefix

		# Reset-AzHubRouter
		Reset-AzHubRouter -ResourceGroupName $rgName -Name $virtualHubName

		# Delete the resources
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

function Test-VHubRouteTableCRUD 
{
	# Setup
	$rgName = Get-ResourceName
	$location = Get-ProviderLocation ResourceManagement "West Central US"

	$virtualWanName = Get-ResourceName
	$virtualHubName = Get-ResourceName
	$defaultRouteTableName = "defaultRouteTable"
	$noneRouteTableName = "noneRouteTable"
	$customRouteTableName = "customRouteTable"
	$firewallName = "azFwInVirtualHub"

	try
	{
		# Create the resource group
		New-AzResourceGroup -Name $rgName -Location $location

		# Create the Virtual Wan
		New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $location -VirtualWANType "Standard" -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
		$virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName

		# Create the Virtual Hub
		New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $location -AddressPrefix "10.0.0.0/16" -VirtualWan $virtualWan
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual "10.0.0.0/16" $virtualHub.AddressPrefix

		# Create a firewall in the Virtual hub
		$fwIp = New-AzFirewallHubPublicIpAddress -Count 1
		$hubIpAddresses = New-AzFirewallHubIpAddress -PublicIP $fwIp
		New-AzFirewall -Name $firewallName -ResourceGroupName $rgName -Location "westcentralus" -Sku AZFW_Hub -VirtualHubId $virtualHub.Id -HubIPAddress $hubIpAddresses
		$firewall = Get-AzFirewall -Name $firewallName -ResourceGroupName $rgName

		# Create new route
		$route1 = New-AzVHubRoute -Name "private-traffic" -Destination @("10.30.0.0/16", "10.40.0.0/16") -DestinationType "CIDR" -NextHop $firewall.Id -NextHopType "ResourceId"

		# Create new customRouteTable
		New-AzVHubRouteTable -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $customRouteTableName -Route @($route1) -Label @("customLabel")
		$customRouteTable = Get-AzVHubRouteTable -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $customRouteTableName
		Assert-AreEqual $customRouteTableName $customRouteTable.Name
		Assert-AreEqual 1 $customRouteTable.Routes.Count
		Assert-AreEqual 1 $customRouteTable.Labels.Count

		# Add one more route
		$route2 = New-AzVHubRoute -Name "internet-traffic" -Destination @("0.0.0.0/0") -DestinationType "CIDR" -NextHop $firewall.Id -NextHopType "ResourceId"
		Update-AzVHubRouteTable -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $customRouteTableName -Route @($route2)
		$updateCustomRouteTable = Get-AzVHubRouteTable -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $customRouteTableName
		Assert-AreEqual $customRouteTableName $updateCustomRouteTable.Name
		Assert-AreEqual 1 $updateCustomRouteTable.Routes.Count
		Assert-AreEqual 1 $customRouteTable.Labels.Count

		# Delete the custom route table
		$delete = Remove-AzVHubRouteTable -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $customRouteTableName -Force -PassThru
		Assert-AreEqual $True $delete
	}
	finally
	{
		# Delete the firewall
		$delete = Remove-AzFirewall -Name $firewallName -ResourceGroupName $rgName -Force -PassThru
		Assert-AreEqual $True $delete
	
		# Delete the resources
		$delete = Remove-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Force -PassThru
		Assert-AreEqual $True $delete
	
		$delete = Remove-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force -PassThru
		Assert-AreEqual $True $delete

		Clean-ResourceGroup $rgname
	}
}