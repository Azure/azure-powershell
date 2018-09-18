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


<# .SYNOPSIS
 Point to site Cortex feature tests
 #>
 function Test-P2SCortexCRUD
 {
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation "Microsoft.Network/VirtualWans"
 
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName
    $p2sVpnServerConfiguration1Name = Get-ResourceName
    $p2sVpnServerConfiguration2Name = Get-ResourceName
    $p2sVpnGatewayName = Get-ResourceName
    $vpnclientAuthMethod = "EAPTLS"
 
    try
	{
		# Create the resource group
		$resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation
		$virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name

		# Create the Virtual Hub
		$createdVirtualHub = New-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name

		# Create the P2sVpnServerConfiguration1 with VpnClient settings and associate it with Virtual wan using Update-AzureRmVirtualWan
		$p2sVpnServerConfigCertFilePath = $basedir + "\ScenarioTests\Data\ApplicationGatewayAuthCert.cer"
		$listOfCerts = New-Object "System.Collections.Generic.List[String]"
		$listOfCerts.Add($p2sVpnServerConfigCertFilePath)
		$vpnclientipsecpolicy1 = New-AzureRmVpnClientIpsecPolicy -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTime 86471 -SADataSize 429496 -IkeEncryption AES256 -IkeIntegrity SHA384 -DhGroup DHGroup14 -PfsGroup PFS14
		$p2sVpnServerConfigObject1 = New-AzureRmP2sVpnServerConfigurationObject -Name $p2sVpnServerConfiguration1Name -VpnProtocol IkeV2 -VpnClientRootCertificateFilesList $listOfCerts -VpnClientRevokedCertificateFilesList $listOfCerts -VpnClientIpsecPolicy $vpnclientipsecpolicy1

		Update-AzureRmVirtualWan -Name $virtualWanName -ResourceGroupName $rgName -P2sVpnServerConfiguration $p2sVpnServerConfigObject1
		$virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name
		Assert-AreEqual 1 $virtualWan.P2SVpnServerConfigurations.Count
		Assert-AreEqual $p2sVpnServerConfiguration1Name $virtualWan.P2SVpnServerConfigurations[0].Name

		# Get created P2sVpnServerConfiguration using Get-AzureRmVirtualWanP2sVpnServerConfiguration
		$p2sVpnServerConfig1 = Get-AzureRmP2sVpnServerConfiguration -VirtualWanName $virtualWanName -ResourceGroupName $rgName -Name $p2sVpnServerConfiguration1Name
		Assert-AreEqual $p2sVpnServerConfiguration1Name $p2sVpnServerConfig1.Name
		$protocols = $p2sVpnServerConfig1.VpnProtocols
		Assert-AreEqual 1 @($protocols).Count
		Assert-AreEqual "IkeV2" $protocols[0]

		# Create the P2sVpnGateway
		$vpnClientAddressSpaces = New-Object string[] 2
		$vpnClientAddressSpaces[0] = "192.168.2.0/24"
		$vpnClientAddressSpaces[1] = "192.168.3.0/24"
		$createdP2SVpnGateway = New-AzureRmP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 1 -VpnClientAddressPool $vpnClientAddressSpaces -P2SVpnServerConfiguration $p2sVpnServerConfig1 -Location $rglocation                

		# Get the created P2sVpnGateway using Get-AzureRmP2sVpnGateway
		$p2sVpnGateway = Get-AzureRmP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
		Assert.AreEqual $rgName $p2sVpnGateway.ResourceGroupName
		Assert.AreEqual $P2SvpnGatewayName $p2sVpnGateway.Name
		Assert.AreEqual $p2sVpnServerConfig1.Id $p2sVpnGateway.P2SVpnServerConfiguration.Id

		# Generate vpn profile using Get-AzureRmP2sVpnGatewayVpnProfile
		$vpnProfileResponse = Get-AzureRmP2sVpnGatewayVpnProfile -Name $p2sVpnGatewayName -ResourceGroupName $rgName -AuthenticationMethod $vpnclientAuthMethod
		Assert-NotNull $vpnProfileResponse.ProfileUrl

		# Create the P2sVpnServerConfiguration2 with RadiusClient settings and associate it with the Virtual wan using New-AzureRmVirtualWanP2sVpnServerConfiguration
		$Secure_String_Pwd = ConvertTo-SecureString "TestRadiusServerPassword" -AsPlainText -Force
		$p2sVpnServerConfigObject2 = New-AzureRmP2sVpnServerConfigurationObject -Name $p2sVpnServerConfiguration2Name -VpnProtocol IkeV2 -RadiusServerAddress "TestRadiusServer" -RadiusServerSecret $Secure_String_Pwd -RadiusServerRootCertificateFilesList $listOfCerts -RadiusClientRootCertificateFilesList $listOfCerts
		$createdP2SVpnServerConfig2 = New-AzureRmVirtualWanP2sVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -VirtualWanName $virtualWanName -P2SVpnServerConfiguration $p2sVpnServerConfigObject2

		$virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual 2 $createdVirtualWan.Name $virtualWan.P2SVpnServerConfigurations.Count
		$p2sVpnServerConfig2 = Get-AzureRmVirtualWanP2sVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -ResourceId $virtualWan.Id
		Assert-AreEqual $p2sVpnServerConfiguration2Name $p2sVpnServerConfig2.Name
		Assert-AreEqual "TestRadiusServer" $p2sVpnServerConfig2.RadiusServerAddress

		$p2sVpnServerConfig2 = Get-AzureRmVirtualWanP2sVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -InputObject $virtualWan
		Assert-AreEqual $p2sVpnServerConfiguration2Name $p2sVpnServerConfig2.Name
		Assert-AreEqual "TestRadiusServer" $p2sVpnServerConfig2.RadiusServerAddress
		
		# Update existing P2sVpnServerConfiguration using Update-AzureRmVirtualWanP2sVpnServerConfiguration
		$p2sVpnServerConfig2.RadiusServerAddress = "TestRadiusServer1"
		$updatedP2SVpnServerConfig2 = Update-AzureRmVirtualWanP2sVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -ParentResourceName $virtualWanName -P2SVpnServerConfigurationToSet $p2sVpnServerConfig2 -Force
		$p2sVpnServerConfig2 = Get-AzureRmVirtualWanP2sVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -VirtualWanId $virtualWan.Id
		Assert-AreEqual $p2sVpnServerConfiguration2Name $p2sVpnServerConfig2.Name
		Assert-AreEqual "TestRadiusServer1" $p2sVpnServerConfig2.RadiusServerAddress
		
		$p2sVpnServerConfig2.RadiusServerAddress = "TestRadiusServer2"
		$updatedP2SVpnServerConfig2 = Update-AzureRmVirtualWanP2sVpnServerConfiguration -ResourceId  $p2sVpnServerConfig2.Id -RadiusServerAddress "TestRadiusServer2" -Force			
		$p2sVpnServerConfig2Get = Get-AzureRmVirtualWanP2sVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -ResourceId $virtualWan.Id
		Assert-AreEqual "TestRadiusServer2" $p2sVpnServerConfig2Get.RadiusServerAddress
						
		$p2sVpnServerConfig2.RadiusServerAddress = "TestRadiusServer3"
		$updatedP2SVpnServerConfig2 = Update-AzureRmVirtualWanP2sVpnServerConfiguration -InputObject p2sVpnServerConfig2Get -RadiusServerAddress "TestRadiusServer3" -Force
		Assert-AreEqual "TestRadiusServer3" $p2sVpnServerConfig2.RadiusServerAddress

		# Update existing P2sVpnGateway to attach P2sVpnServerConfiguration2 using Update-AzureRmP2sVpnGateway
		$updatedP2sVpnGateway = Update-AzureRmP2sVpnGateway -Name $P2SvpnGatewayName -ResourceGroupName $rgName -P2sVpnServerConfiguration $p2sVpnServerConfig2 -Force
		Assert.AreEqual $p2sVpnServerConfig2.Id $updatedP2sVpnGateway.P2SVpnServerConfiguration.Id

		# Generate vpn profile again using Get-AzureRmP2sVpnGatewayVpnProfile
		$vpnProfileResponse = Get-AzureRmP2sVpnGatewayVpnProfile -Name $p2sVpnGatewayName -ResourceGroupName $rgName -AuthenticationMethod $vpnclientAuthMethod
		Assert-NotNull $vpnProfileResponse.ProfileUrl
     }
     finally
     {
		# Delete P2sVpnGateway using Remove-AzureRmP2sVpnGateway
		$delete = Remove-AzureRmP2sVpnGateway -Name $p2sVpnGatewayName -ResourceGroupName $rgName -Force
		Assert-AreEqual $True $delete
		Assert-ThrowsContains { Get-AzureRmP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName } "NotFound";

		# Delete P2sVpnServerConfiguration2 using Remove-AzureRmVirtualWanP2sVpnServerConfiguration
		$delete = Remove-AzureRmVirtualWanP2sVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -ParentResourceName $virtualWanName -Force
		Assert-AreEqual $True $delete
		Assert-ThrowsContains { Get-AzureRmVirtualWanP2sVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -ResourceId $virtualWan.Id } "NotFound";

		# Verify P2sVpnServerConfiguration1 is still associated with the Virtual wan
		$virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		$p2sVpnServerConfig1 = Get-AzureRmVirtualWanP2sVpnServerConfiguration -Name $p2sVpnServerConfiguration1Name -VirtualWan $virtualWan
		Assert-AreEqual $p2sVpnServerConfiguration1Name $p2sVpnServerConfig1.Name

		# Delete Virtual hub
		$delete = Remove-AzureRmVirtualHub -ResourceGroupName $rgname -Name $virtualHubName -Force 
		Assert-AreEqual $True $delete
        Assert-ThrowsContains { Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName } "NotFound";

		# Delete Virtual wan and check associated P2SVpnServerConfiguration1 also gets deleted.
		$delete = Remove-AzureRmVirtualWan -InputObject $virtualWan -Force
		Assert-AreEqual $True $delete
		Assert-ThrowsContains { Get-AzureRmVirtualWanP2sVpnServerConfiguration -Name $p2sVpnServerConfiguration1Name -ResourceGroupName $rgName -ResourceId $virtualWan.Id } "NotFound";
		Assert-ThrowsContains { Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName } "NotFound";
     }
}