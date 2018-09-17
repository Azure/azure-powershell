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
    $rglocation = "eastus2euap"

	$virtualWanName = Get-ResourceName
	$virtualHubName = Get-ResourceName
	$vpnSiteName = Get-ResourceName
	$vpnGatewayName = Get-ResourceName
	$remoteVirtualNetworkName = Get-ResourceName
	$vpnConnectionName = Get-ResourceName
	$hubVnetConnectionName = Get-ResourceName
    
	try
	{
		# Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgName -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic $true -AllowBranchToBranchTraffic $true
		$createdVirtualWan = Set-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -AllowVnetToVnetTraffic $false -AllowBranchToBranchTraffic $false
		$virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name

		# Create the Virtual Hub
		$createdVirtualHub = New-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name

		# Create the VpnSite
		$vpnSiteAddressSpaces = New-Object string[] 1
		$vpnSiteAddressSpaces[0] = "192.168.2.0/24"
		$createdVpnSite = New-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Location $rglocation -VirtualWan $virtualWan -IpAddress "1.2.3.4" -AddressSpace $vpnSiteAddressSpaces -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -LinkSpeedInMbps 10
		$createdVpnSite = Set-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -DeviceModel "SomeDevice1" -DeviceVendor "SomeDeviceVendor1" -LinkSpeedInMbps 20
		$vpnSite = Get-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName
		Assert-AreEqual $rgName $vpnSite.ResourceGroupName
		Assert-AreEqual $vpnSiteName $vpnSite.Name

		# Create the VpnGateway
		$createdVpnGateway = New-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 3
		$createdVpnGateway = Set-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VpnGatewayScaleUnit 4
		$vpnGateway = Get-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual $rgName $vpnGateway.ResourceGroupName
		Assert-AreEqual $vpnGatewayName $vpnGateway.Name

		# Create the VpnConnection
		$createdVpnConnection = New-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20
		$createdVpnConnection = Set-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -ConnectionBandwidth 30
		$vpnConnection = Get-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Assert-AreEqual $rgName $vpnConnection.ResourceGroupName
		Assert-AreEqual $vpnConnectionName $vpnConnection.Name

		# Create a HubVirtualNetworkConnection
		$remoteVirtualNetwork = New-AzureRmVirtualNetwork -ResourceGroupName $rgName -Name $remoteVirtualNetworkName -Location $rglocation -AddressPrefix "10.0.1.0/24"
		$createdHubVnetConnection = New-AzureRmVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName -RemoteVirtualNetwork $remoteVirtualNetwork
		$hubVnetConnection = Get-AzureRmVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName
		Assert-AreEqual $rgName $hubVnetConnection.ResourceGroupName
		Assert-AreEqual $hubVnetConnectionName $hubVnetConnection.Name
	}
	finally
	{
		Remove-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -Force
		Remove-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Force
		Remove-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Force
		Remove-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force
		Remove-AzureRmVirtualNetwork -ResourceGroupName $rgName -Name $remoteVirtualNetworkName -Force
		Remove-AzureRmResourceGroup -Name $rgName
	}
}


<# .SYNOPSIS
 Point to site Cortex feature tests
 #>
 function Test-P2SCortexCRUD
 {
    # Setup
    $rgname = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation ResourceManagement
 
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
 
                # Create the P2SVpnServerConfiguration1 with VpnClient settings and associate it with Virtual wan using Set-AzureRmVirtualWan
                $p2sVpnServerConfigCertFilePath = $basedir + "\ScenarioTests\Data\ApplicationGatewayAuthCert.cer"
                $listOfCerts = New-Object "System.Collections.Generic.List[String]"
                $listOfCerts.Add($p2sVpnServerConfigCertFilePath)
                $vpnclientipsecpolicy1 = New-AzureRmVpnClientIpsecPolicy -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTime 86471 -SADataSize 429496 -IkeEncryption AES256 -IkeIntegrity SHA384 -DhGroup DHGroup14 -PfsGroup PFS14
				$p2sVpnServerConfigObject1 = New-AzureRmP2SVpnServerConfigurationObject -Name $p2sVpnServerConfiguration1Name -VpnProtocol IkeV2 -VpnClientRootCertificateFilesList $listOfCerts -VpnClientRevokedCertificateFilesList $listOfCerts -VpnClientIpsecPolicy $vpnclientipsecpolicy1
 
                Set-AzureRmVirtualWan -Name $virtualWanName -ResourceGroupName $rgName -P2SVpnServerConfiguration $p2sVpnServerConfigObject1
                # Set-AzureRmVirtualWan -VirtualWan
                # Set-AzureRmVirtualWan -VirtualWanId
 
                $virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
                Assert-AreEqual $rgName $virtualWan.ResourceGroupName
                Assert-AreEqual $virtualWanName $virtualWan.Name
                Assert-AreEqual 1 $virtualWan.P2SVpnServerConfigurations.Count
                Assert-AreEqual $p2sVpnServerConfiguration1Name $virtualWan.P2SVpnServerConfigurations[0].Name
 
                # Get created P2SVpnServerConfiguration using Get-AzureRmVirtualWanP2SVpnServerConfiguration
                $p2sVpnServerConfig1 = Get-AzureRmP2SVpnServerConfiguration -VirtualWanName $virtualWanName -ResourceGroupName $rgName -Name $p2sVpnServerConfiguration1Name
				Assert-AreEqual $p2sVpnServerConfiguration1Name $p2sVpnServerConfig1.Name
                $protocols = $p2sVpnServerConfig1.VpnProtocols
                Assert-AreEqual 1 @($protocols).Count
                Assert-AreEqual "IkeV2" $protocols[0]
 
                # Create the P2SVpnGateway
                $vpnClientAddressSpaces = New-Object string[] 2
                $vpnClientAddressSpaces[0] = "192.168.2.0/24"
                $vpnClientAddressSpaces[1] = "192.168.3.0/24"
                $createdP2SVpnGateway = New-AzureRmP2SVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 1 -VpnClientAddressPool $vpnClientAddressSpaces -P2SVpnServerConfiguration $p2sVpnServerConfig1 -Location $rglocation                
 
                # Get the created P2SVpnGateway using Get-AzureRmP2SVpnGateway
                $P2SvpnGateway = Get-AzureRmP2SVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
                Assert.AreEqual $rgName $P2SvpnGateway.ResourceGroupName
                Assert.AreEqual $P2SvpnGatewayName $P2SvpnGateway.Name
                Assert.AreEqual $p2sVpnServerConfig1.Id $P2SvpnGateway.P2SVpnServerConfiguration.Id
 
                # Generate vpn profile using Get-AzureRmP2SVpnGatewayVpnProfile
                $vpnProfileResponse = Get-AzureRmP2SVpnGatewayVpnProfile -Name $p2sVpnGatewayName -ResourceGroupName $rgName -AuthenticationMethod $vpnclientAuthMethod
				Assert-NotNull $vpnProfileResponse.ProfileUrl
 
                # Create the P2SVpnServerConfiguration2 with RadiusClient settings and associate it with the Virtual wan using New-AzureRmVirtualWanP2SVpnServerConfiguration
                $Secure_String_Pwd = ConvertTo-SecureString "TestRadiusServerPassword" -AsPlainText -Force
                $p2sVpnServerConfigObject2 = New-AzureRmP2SVpnServerConfigurationObject -Name $p2sVpnServerConfiguration2Name -VpnProtocol IkeV2 -RadiusServerAddress "TestRadiusServer" -RadiusServerSecret $Secure_String_Pwd -RadiusServerRootCertificateFilesList $listOfCerts -RadiusClientRootCertificateFilesList $listOfCerts
                $createdP2SVpnServerConfig2 = New-AzureRmVirtualWanP2SVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -VirtualWanName $virtualWanName -P2SVpnServerConfiguration $p2sVpnServerConfigObject2
 
                $virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
                Assert-AreEqual 2 $createdVirtualWan.Name $virtualWan.P2SVpnServerConfigurations.Count
				$p2sVpnServerConfig2 = Get-AzureRmVirtualWanP2SVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -ResourceId $virtualWan.Id
                Assert-AreEqual $p2sVpnServerConfiguration2Name $p2sVpnServerConfig2.Name
                Assert-AreEqual "TestRadiusServer" $p2sVpnServerConfig2.RadiusServerAddress

				$p2sVpnServerConfig2 = Get-AzureRmVirtualWanP2SVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -InputObject $virtualWan
                Assert-AreEqual $p2sVpnServerConfiguration2Name $p2sVpnServerConfig2.Name
                Assert-AreEqual "TestRadiusServer" $p2sVpnServerConfig2.RadiusServerAddress
				
                # Update existing P2SVpnServerConfiguration using Set-AzureRmVirtualWanP2SVpnServerConfiguration
                $p2sVpnServerConfig2.RadiusServerAddress = "TestRadiusServer1"
                $updatedP2SVpnServerConfig2 = Set-AzureRmVirtualWanP2SVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -ParentResourceName $virtualWanName -P2SVpnServerConfigurationToSet $p2sVpnServerConfig2 -Force
                $p2sVpnServerConfig2 = Get-AzureRmVirtualWanP2SVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -VirtualWanId $virtualWan.Id
                Assert-AreEqual $p2sVpnServerConfiguration2Name $p2sVpnServerConfig2.Name
                Assert-AreEqual "TestRadiusServer1" $p2sVpnServerConfig2.RadiusServerAddress
				
				$p2sVpnServerConfig2.RadiusServerAddress = "TestRadiusServer2"
                $updatedP2SVpnServerConfig2 = Set-AzureRmVirtualWanP2SVpnServerConfiguration -ResourceId  $p2sVpnServerConfig2.Id -P2SVpnServerConfigurationToSet $p2sVpnServerConfig2 -Force			
				$p2sVpnServerConfig2Get = Get-AzureRmVirtualWanP2SVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -ResourceId $virtualWan.Id
				Assert-AreEqual "TestRadiusServer2" $p2sVpnServerConfig2Get.RadiusServerAddress
								
				$p2sVpnServerConfig2.RadiusServerAddress = "TestRadiusServer3"
                $updatedP2SVpnServerConfig2 = Set-AzureRmVirtualWanP2SVpnServerConfiguration -InputObject p2sVpnServerConfig2Get -P2SVpnServerConfigurationToSet $p2sVpnServerConfig2 -Force
				Assert-AreEqual "TestRadiusServer3" $p2sVpnServerConfig2.RadiusServerAddress
 
                # Update existing P2SVpnGateway to attach P2SVpnServerConfiguration2 using Set-AzureRmP2SVpnGateway
                $updatedP2SVpnGateway = Set-AzureRmP2SVpnGateway -Name $P2SvpnGatewayName -ResourceGroupName $rgName -P2SVpnServerConfiguration $p2sVpnServerConfig2 -Force
                Assert.AreEqual $p2sVpnServerConfig2.Id $updatedP2SVpnGateway.P2SVpnServerConfiguration.Id
 
                # Generate vpn profile again using Get-AzureRmP2SVpnGatewayVpnProfile
                $vpnProfileResponse = Get-AzureRmP2SVpnGatewayVpnProfile -Name $p2sVpnGatewayName -ResourceGroupName $rgName -AuthenticationMethod $vpnclientAuthMethod
				Assert-NotNull $vpnProfileResponse.ProfileUrl
        }
        finally
        {
                # Delete P2SVpnGateway using Remove-AzureRmP2SVpnGateway
                $delete = Remove-AzureRmP2SVpnGateway -Name $p2sVpnGatewayName -ResourceGroupName $rgName -Force
                Assert-AreEqual $True $delete
                $list = Get-AzureRmP2SVpnGateway -ResourceGroupName $rgName
                Assert-AreEqual 0 @($list).Count
 
                # Delete P2SVpnServerConfiguration2 using Remove-AzureRmVirtualWanP2SVpnServerConfiguration
                $delete = Remove-AzureRmVirtualWanP2SVpnServerConfiguration -Name $p2sVpnServerConfiguration2Name -ResourceGroupName $rgName -ParentResourceName $virtualWanName -Force
                Assert-AreEqual $True $delete
 
                # Verify P2SVpnServerConfiguration1 is still associated with the Virtual wan
                $virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
                $p2sVpnServerConfig1 = Get-AzureRmVirtualWanP2SVpnServerConfiguration -Name $p2sVpnServerConfiguration1Name -VirtualWan $virtualWan
                Assert-AreEqual $p2sVpnServerConfiguration1Name $p2sVpnServerConfig1.Name
				#Debug:-
                #$list = Get-AzureRmVirtualWanP2SVpnServerConfiguration -VirtualWan $virtualWan -ResourceGroupName $rgName
                #Assert-AreEqual 1 @($list).Count
 
                # Delete Virtual hub
                $delete = Remove-AzureRmVirtualHub -ResourceGroupName $rgname -Name $virtualHubName -Force 
                Assert-AreEqual $True $delete
 
                # Delete Virtual wan and check associated P2SVpnServerConfiguration1 also gets deleted.
                $delete = Remove-AzureRmVirtualWan -InputObject $virtualWan -Force
                Assert-AreEqual $True $delete
        }
}