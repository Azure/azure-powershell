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
    $rglocation = Get-ProviderLocation ResourceManagement
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

		$virtualWans = Get-AzVirtualWan -ResourceGroupName $rgName
		Assert-NotNull $virtualWans

		$virtualWansAll = Get-AzVirtualWan
		Assert-NotNull $virtualWansAll
		Assert-NotNull $virtualWansAll[0].ResourceGroupName

		$virtualWansAll = Get-AzVirtualWan -ResourceGroupName "*"
		Assert-NotNull $virtualWansAll

		$virtualWansAll = Get-AzVirtualWan -Name "*"
		Assert-NotNull $virtualWansAll

		$virtualWansAll = Get-AzVirtualWan -ResourceGroupName "*" -Name "*"
		Assert-NotNull $virtualWansAll

		# Create the Virtual Hub
		$createdVirtualHub = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan -HubRoutingPreference "ASPath"
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $rgName $virtualHub.ResourceGroupName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		Assert-AreEqual "192.168.1.0/24" $virtualHub.AddressPrefix

		$virtualHubs = Get-AzVirtualHub -ResourceGroupName $rgName
		Assert-NotNull $virtualHubs

		#$virtualHubsAll = Get-AzVirtualHub
		#Assert-NotNull $virtualHubsAll
		#Assert-NotNull $virtualHubsAll[0].ResourceGroupName

		#$virtualHubsAll = Get-AzVirtualHub -ResourceGroupName "*"
		#Assert-NotNull $virtualHubsAll

		#$virtualHubsAll = Get-AzVirtualHub -Name "*"
		#Assert-NotNull $virtualHubsAll

		#$virtualHubsAll = Get-AzVirtualHub -ResourceGroupName "*" -Name "*"
		#Assert-NotNull $virtualHubsAll

		# Update the Virtual Hub
		$route1 = New-AzVirtualHubRoute -AddressPrefix @("10.0.0.0/16", "11.0.0.0/16") -NextHopIpAddress "12.0.0.5"
		$route2 = New-AzVirtualHubRoute -AddressPrefix @("13.0.0.0/16") -NextHopIpAddress "14.0.0.5"
		$routeTable = New-AzVirtualHubRouteTable -Route @($route1, $route2)
		Update-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -RouteTable $routeTable -HubRoutingPreference "ExpressRoute"
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

		$vpnSites = Get-AzVpnSite -ResourceGroupName $rgName
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

		# Create a NATRule object
		$natRule = New-Object -TypeName Microsoft.Azure.Commands.Network.Models.PSVpnGatewayNatRule
		$natRule.Name = "NatRule1"
		$natRule.Mode = "EgressSnat"
		$natRule.VpnGatewayNatRulePropertiesType = "Static"
		$natRuleInternalMapping = New-Object -TypeName Microsoft.Azure.Commands.Network.Models.PSVpnNatRuleMapping
		$natRuleInternalMapping.AddressSpace = "192.168.0.0/24"
		$natRule.InternalMappings = New-Object Microsoft.Azure.Commands.Network.Models.PSVpnNatRuleMapping[] 1
		$natRule.InternalMappings[0] = $natRuleInternalMapping
		$natRuleExternalMapping = New-Object -TypeName Microsoft.Azure.Commands.Network.Models.PSVpnNatRuleMapping
		$natRuleExternalMapping.AddressSpace = "10.0.0.0/24"
		$natRule.ExternalMappings = New-Object Microsoft.Azure.Commands.Network.Models.PSVpnNatRuleMapping[] 1
		$natRule.ExternalMappings[0] = $natRuleExternalMapping
		$vpnGatewayNatRules = New-Object Microsoft.Azure.Commands.Network.Models.PSVpnGatewayNatRule[] 1
		$vpnGatewayNatRules[0] = $natRule

		# Create the VpnGateway
		$createdVpnGateway = New-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 3 -EnableRoutingPreferenceInternetFlag -EnableBgpRouteTranslationForNat -VpnGatewayNatRule $vpnGatewayNatRules
		
		$vpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		#Assert-AreEqual $True $vpnGateway.EnableBgpRouteTranslationForNat
		Assert-AreEqual 1 $vpnGateway.NatRules.Count
		Assert-AreEqual "NatRule1" $vpnGateway.NatRules[0].Name

		# Update VpnGateway with new NatRule2
		$vpnGatewayNatRules[0].Name = "NatRule2"
		$createdVpnGateway = Update-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VpnGatewayScaleUnit 4 -VpnGatewayNatRule $vpnGatewayNatRules -EnableBgpRouteTranslationForNat $false

		$vpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual $rgName $vpnGateway.ResourceGroupName
		Assert-AreEqual $vpnGatewayName $vpnGateway.Name
		Assert-AreEqual 4 $vpnGateway.VpnGatewayScaleUnit
		Assert-AreEqual 1 $vpnGateway.NatRules.Count
		Assert-AreEqual "NatRule2" $vpnGateway.NatRules[0].Name
		Assert-AreEqual "EgressSnat" $vpnGateway.NatRules[0].Mode
		Assert-AreEqual "Static" $vpnGateway.NatRules[0].VpnGatewayNatRulePropertiesType
		Assert-AreEqual "Succeeded" $vpnGateway.NatRules[0].ProvisioningState	
		#Assert-AreEqual $false $createdVpnGateway.EnableBgpRouteTranslationForNat

		# Create one more NATRule using New-AzVpnGatewayNatRule
		New-AzVpnGatewayNatRule -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "NatRule3" -Type "Static" -Mode "IngressSnat" -InternalMapping "192.168.1.0/26" -ExternalMapping "10.0.1.0/26" -InternalPortRange @("100-100") -ExternalPortRange @("200-200")
		$natRule = Get-AzVpnGatewayNatRule -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "NatRule3"
		Assert-AreEqual "NatRule3" $natRule.Name
		Assert-AreEqual "Static" $natRule.VpnGatewayNatRulePropertiesType
		Assert-AreEqual "IngressSnat" $natRule.Mode
		Assert-AreEqual 1 $natRule.InternalMappings.Count		
		Assert-AreEqual "192.168.1.0/26" $natRule.InternalMappings[0].AddressSpace
		Assert-AreEqual 1 $natRule.ExternalMappings.Count		
		Assert-AreEqual "10.0.1.0/26" $natRule.ExternalMappings[0].AddressSpace
		Assert-AreEqual "100-100" $natRule.InternalMappings[0].PortRange
		Assert-AreEqual "200-200" $natRule.ExternalMappings[0].PortRange
		Assert-AreEqual 0 $natRule.IngressVpnSiteLinkConnections.Count	
		Assert-AreEqual 0 $natRule.EgressVpnSiteLinkConnections.Count
		Assert-AreEqual "Succeeded" $natRule.ProvisioningState		

		Update-AzVpnGatewayNatRule -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "NatRule3" -InternalMapping "192.168.2.0/26" -ExternalMapping "10.0.2.0/26" -InternalPortRange @("300-300") -ExternalPortRange @("400-400")
		$natRule = Get-AzVpnGatewayNatRule -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "NatRule3"
		Assert-AreEqual "NatRule3" $natRule.Name
		Assert-AreEqual "192.168.2.0/26" $natRule.InternalMappings[0].AddressSpace
		Assert-AreEqual "10.0.2.0/26" $natRule.ExternalMappings[0].AddressSpace
		Assert-AreEqual "300-300" $natRule.InternalMappings[0].PortRange
		Assert-AreEqual "400-400" $natRule.ExternalMappings[0].PortRange
		Assert-AreEqual "Succeeded" $natRule.ProvisioningState	
		#Assert-AreEqual $True $vpnGateway.IsRoutingPreferenceInternet

		$vpnGateways = Get-AzVpnGateway
		Assert-NotNull $vpnGateways
		Assert-NotNull $vpnGateways[0].ResourceGroupName

		#$vpnGateways = Get-AzVpnGateway -ResourceGroupName $rgName
		#Assert-NotNull $vpnGateways

		#$vpnGatewaysAll = Get-AzVpnGateway -ResourceGroupName "*"
		#Assert-NotNull $vpnGatewaysAll

		#$vpnGatewaysAll = Get-AzVpnGateway -Name "*"
		#Assert-NotNull $vpnGatewaysAll

		#$vpnGatewaysAll = Get-AzVpnGateway -ResourceGroupName "*" -Name "*"
		#Assert-NotNull $vpnGatewaysAll

		$vpnGatewaysAll = Get-AzVpnGateway
		Assert-NotNull $vpnGatewaysAll
		
		# Reset/Reboot the VpnGateway using Reset-AzVpnGateway
		$job = Reset-AzVpnGateway -VpnGateway $vpnGateway -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job
		
		$vpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual "Succeeded" $vpnGateway.ProvisioningState

		# Create the VpnConnection
		$createdVpnConnection = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20 -UseLocalAzureIpAddress 
		Assert-AreEqual $true $createdVpnConnection.UseLocalAzureIpAddress
		
		$createdVpnConnection = Update-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -ConnectionBandwidth 30 -UseLocalAzureIpAddress $false
		$vpnConnection = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Assert-AreEqual $vpnConnectionName $vpnConnection.Name
		Assert-AreEqual 30 $vpnConnection.ConnectionBandwidth
		Assert-AreEqual $false $vpnConnection.UseLocalAzureIpAddress 

		# Create the VpnConnection with site with links
		$natRule2 = Get-AzVpnGatewayNatRule -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "NatRule2"
		$vpnSiteLinkConnection1 = New-AzVpnSiteLinkConnection -Name $vpnLink1ConnectionName -VpnSiteLink $vpnSite2.VpnSiteLinks[0] -ConnectionBandwidth 100 -EgressNatRule $natRule2
		$vpnSiteLinkConnection2 = New-AzVpnSiteLinkConnection -Name $vpnLink2ConnectionName -VpnSiteLink $vpnSite2.VpnSiteLinks[1] -ConnectionBandwidth 10 -VpnLinkConnectionMode "Default"

		$createdVpnConnection2 = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name -VpnSite $vpnSite2 -VpnSiteLinkConnection @($vpnSiteLinkConnection1, $vpnSiteLinkConnection2)
		$vpnConnection2 = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name
		Assert-AreEqual $vpnConnection2Name $vpnConnection2.Name
		Assert-AreEqual 2 $vpnConnection2.VpnLinkConnections.Count
		Assert-AreEqual 1 $vpnConnection2.VpnLinkConnections[0].EgressNatRules.Count
		Assert-AreEqual 0 $vpnConnection2.VpnLinkConnections[0].IngressNatRules.Count
		Assert-AreEqual "Default" $vpnConnection2.VpnLinkConnections[1].VpnLinkConnectionMode
		
		$natRule2 = Get-AzVpnGatewayNatRule -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "NatRule2"
		Assert-AreEqual 0 $natRule2.IngressVpnSiteLinkConnections.count
		Assert-AreEqual 1 $natRule2.EgressVpnSiteLinkConnections.count
		Assert-AreEqual $vpnConnection2.VpnLinkConnections[0].Id $natRule2.EgressVpnSiteLinkConnections[0].Id

		#$natRule3 = Get-AzVpnGatewayNatRule -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "NatRule3"
		#$vpnSiteLinkConnection1.EgressNatRules.Clear()
		#$vpnSiteLinkConnection1.IngressNatRules.Add($natRule3)
		#$vpnSiteLinkConnection1.RoutingWeight = 10
		#Update-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name -VpnSiteLinkConnection @($vpnSiteLinkConnection1)
		#$vpnConnection2 = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name

		#Assert-AreEqual $vpnConnection2Name $vpnConnection2.Name
		#Assert-AreEqual 1 $vpnConnection2.VpnLinkConnections.Count
		#Assert-AreEqual 10 $vpnConnection2.VpnLinkConnections[0].RoutingWeight
		#Assert-AreEqual 1 $vpnConnection2.VpnLinkConnections[0].IngressNatRules.Count
		#Assert-AreEqual 0 $vpnConnection2.VpnLinkConnections[0].EgressNatRules.Count

		$vpnConnections = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName
		Assert-NotNull $vpnConnections

		$vpnConnections = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "*"
		Assert-NotNull $vpnConnections

		$vpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual "Succeeded" $vpnGateway.ProvisioningState
		Assert-AreEqual 2 $vpnGateway.NatRules.Count

		# Remove NATRule using Remove-AzVpnGatewayNatRule
		#$delete = Remove-AzVpnGatewayNatRule -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "NatRule2" -Force -PassThru
		$delete = Remove-AzVpnGatewayNatRule -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name "NatRule3" -Force -PassThru
		Assert-AreEqual $True $delete
		$vpnGateway = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert-AreEqual "Succeeded" $vpnGateway.ProvisioningState
		Assert-AreEqual 1 $vpnGateway.NatRules.Count

		# Create a HubVirtualNetworkConnection
		#$remoteVirtualNetwork = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $remoteVirtualNetworkName -Location $rglocation -AddressPrefix "10.0.1.0/24"
		#$createdHubVnetConnection = New-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName -RemoteVirtualNetwork $remoteVirtualNetwork
		#$hubVnetConnection = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName
		#Assert-AreEqual $hubVnetConnectionName $hubVnetConnection.Name
		#$hubVnetConnections = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName
		#Assert-NotNull $hubVnetConnections
		#$hubVnetConnections = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name "*"
		#Assert-NotNull $hubVnetConnections

		# Clean up
		#$delete = Remove-AzVirtualHubVnetConnection -ResourceGroupName $rgName -ParentResourceName $virtualHubName -Name $hubVnetConnectionName -Force -PassThru
		#Assert-AreEqual $True $delete

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
VpnSiteIsSecurity
#>
function Test-VpnSiteIsSecurity
{
 # Setup
    $rgName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
	$virtualWanName = Get-ResourceName
	$vpnSiteName1 = Get-ResourceName
	$vpnSiteName2 = Get-ResourceName
	$vpnSiteName3 = Get-ResourceName
    $vpnSiteLinkName1 = Get-ResourceName
	$vpnSiteLinkName2 = Get-ResourceName

	try
	{
		# Create the resource group
		$resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic
		$virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $rgName $virtualWan.ResourceGroupName
		Assert-AreEqual $virtualWanName $virtualWan.Name

		# Create the VpnSite
		$vpnSiteAddressSpaces1 = New-Object string[] 1
		$vpnSiteAddressSpaces1[0] = "192.168.2.0/24"
		$ip1 = "1.2.3.4"
		$createdVpnSite1 = New-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName1 -Location $rglocation -VirtualWan $virtualWan -IpAddress $ip1 -AddressSpace $vpnSiteAddressSpaces1 -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -LinkSpeedInMbps 10
		$vpnSite1 = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName1
		Assert-AreEqual $rgName $vpnSite1.ResourceGroupName
		Assert-AreEqual $vpnSiteName1 $vpnSite1.Name
		Assert-AreEqual $ip1 $vpnSite1.IpAddress
		Assert-AreEqual $False $vpnSite1.IsSecuritySite

		# Create the VpnSite with IsSecuritySite
		$vpnSiteAddressSpaces2 = New-Object string[] 1
		$vpnSiteAddressSpaces2[0] = "192.168.3.0/24"
		$ip2 = "2.3.4.5"
		$createdVpnSite2 = New-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName2 -Location $rglocation -VirtualWan $virtualWan -IpAddress $ip2 -AddressSpace $vpnSiteAddressSpaces2 -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -LinkSpeedInMbps 10 -IsSecuritySite
		$vpnSite2 = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName2
		Assert-AreEqual $rgName $vpnSite2.ResourceGroupName
		Assert-AreEqual $vpnSiteName2 $vpnSite2.Name
		Assert-AreEqual $ip2 $vpnSite2.IpAddress
		Assert-AreEqual $True $vpnSite2.IsSecuritySite

		# Create the VpnSite with Links
		$vpnSiteAddressSpaces3 = New-Object string[] 2
		$vpnSiteAddressSpaces3[0] = "192.168.2.0/24"
		$vpnSiteAddressSpaces3[1] = "192.168.3.0/24"
		$vpnSiteLink1 = New-AzVpnSiteLink -Name $vpnSiteLinkName1 -IpAddress "5.5.5.5" -LinkProviderName "SomeTelecomProvider1" -LinkSpeedInMbps "10"
		$vpnSiteLink2 = New-AzVpnSiteLink -Name $vpnSiteLinkName2 -IpAddress "5.5.5.6" -LinkProviderName "SomeTelecomProvider2" -LinkSpeedInMbps "10"

		$createdVpnSite3 = New-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName3 -Location $rglocation -VirtualWan $virtualWan -AddressSpace $vpnSiteAddressSpaces3 -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -VpnSiteLink @($vpnSiteLink1, $vpnSiteLink2) -IsSecuritySite
		$vpnSite3 = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName3
		Assert-AreEqual $rgName $vpnSite3.ResourceGroupName
		Assert-AreEqual $vpnSiteName3 $vpnSite3.Name
		Assert-AreEqual $True $vpnSite3.IsSecuritySite

		$delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName1 -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName2 -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSiteName3 -Force -PassThru
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

		# Create traffic selector policy
		$trafficSelector = New-AzIpsecTrafficSelectorPolicy -LocalAddressRange ("2.2.2.2/32", "4.4.4.4/32") -RemoteAddressRange ("3.3.3.3/32", "5.5.5.5/32")
		
		# Create the VpnConnection
		$createdVpnConnection = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20 -TrafficSelectorPolicy ($trafficSelector)
		$vpnConnection = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Assert-AreEqual $vpnConnectionName $vpnConnection.Name
		Assert-AreEqual $trafficSelector.LocalAddressRanges[0] $createdVpnConnection.TrafficSelectorPolicies[0].LocalAddressRanges[0]
		Assert-AreEqual $trafficSelector.RemoteAddressRanges[0] $createdVpnConnection.TrafficSelectorPolicies[0].RemoteAddressRanges[0]
		
		# Create the VpnConnection with site with links
		$vpnSiteLinkConnection1 = New-AzVpnSiteLinkConnection -Name $vpnLink1ConnectionName -VpnSiteLink $vpnSite2.VpnSiteLinks[0] -ConnectionBandwidth 100
	    $vpnSiteLinkConnection2 = New-AzVpnSiteLinkConnection -Name $vpnLink2ConnectionName -VpnSiteLink $vpnSite2.VpnSiteLinks[1] -ConnectionBandwidth 10

		$createdVpnConnection2 = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name -VpnSite $vpnSite2 -VpnSiteLinkConnection @($vpnSiteLinkConnection1, $vpnSiteLinkConnection2)
		$vpnConnection2 = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name
		Assert-AreEqual $vpnConnection2Name $vpnConnection2.Name
		Assert-AreEqual 2 $vpnConnection2.VpnLinkConnections.Count

		# Test Reset VpnSiteLinkConnection
		Reset-AzVpnSiteLinkConnection -InputObject $vpnConnection2.VpnLinkConnections[0]

		# Update VpnConnection with -TrafficSelectorPolicy
		$updatedVpnConnection2 = Update-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnection2Name -TrafficSelectorPolicy ($trafficSelector)

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
    $VpnServerConfigurationMultiAuthName = Get-ResourceName
    $P2SVpnGatewayName = Get-ResourceName
    $vpnclientAuthMethod = "EAPTLS"
    
    $aadTenant = "https://login.microsoftonline.com/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4"
    $aadIssuer = "https://sts.windows.net/0ab2c4f4-81e6-44cc-a0b2-b3a47a1443f4/"
    $aadAudience = "a21fce82-76af-45e6-8583-a08cb3b956f9"

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

		# Create a PolicyGroup1 Object
		$policyGroup1 = New-Object -TypeName Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroup
		$policyGroup1.Name = "PolicyGroup1"
		$policyGroup1.IsDefault = $False
		$policyGroup1.Priority = 0
		$policyGroupMember1 = New-Object -TypeName Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroupMember
		$policyGroupMember1.Name = "policyGroupMember1"
		$policyGroupMember1.AttributeType = "AADGroupId"
		$policyGroupMember1.AttributeValue = "41b23e61-6c1e-4545-b367-cd054e0ed4b5"
		$policyGroup1.PolicyMembers = New-Object Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroupMember[] 1
		$policyGroup1.PolicyMembers[0] = $policyGroupMember1

		# Create the VpnServerConfiguration1 with VpnClient settings (and child PolicyGroup1) using New-AzVpnServerConfiguration
		$VpnServerConfigCertFilePath = Join-Path -Path $basedir -ChildPath "\ScenarioTests\Data\ApplicationGatewayAuthCert.cer"
		$listOfCerts = New-Object "System.Collections.Generic.List[String]"
		$listOfCerts.Add($VpnServerConfigCertFilePath)
		$vpnclientipsecpolicy1 = New-AzVpnClientIpsecPolicy -IpsecEncryption AES256 -IpsecIntegrity SHA256 -SALifeTime 86471 -SADataSize 429496 -IkeEncryption AES256 -IkeIntegrity SHA384 -DhGroup DHGroup14 -PfsGroup PFS14
		New-AzVpnServerConfiguration -Name $VpnServerConfiguration1Name -ResourceGroupName $rgName -VpnProtocol IkeV2 -VpnAuthenticationType Certificate -VpnClientRootCertificateFilesList $listOfCerts -VpnClientRevokedCertificateFilesList $listOfCerts -VpnClientIpsecPolicy $vpnclientipsecpolicy1 -ConfigurationPolicyGroup $policyGroup1 -Location $rglocation

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
		Assert-AreEqual 1 @($vpnServerConfig1.ConfigurationPolicyGroups).Count
		Assert-AreEqual "PolicyGroup1" $vpnServerConfig1.ConfigurationPolicyGroups[0].Name

		# Create the P2SVpnGateway using New-AzP2sVpnGateway
		$vpnClientAddressSpaces = New-Object string[] 2
		$vpnClientAddressSpaces[0] = "192.168.2.0/24"
		$vpnClientAddressSpaces[1] = "192.168.3.0/24"
		$customDnsServers = New-Object string[] 1
		$customDnsServers[0] = "7.7.7.7"
		$createdP2SVpnGateway = New-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 1 -VpnClientAddressPool $vpnClientAddressSpaces -VpnServerConfiguration $vpnServerConfig1 -CustomDnsServer $customDnsServers -EnableRoutingPreferenceInternetFlag
		Assert-AreEqual "Succeeded" $createdP2SVpnGateway.ProvisioningState

		# Get the created P2SVpnGateway using Get-AzP2sVpnGateway
		$P2SVpnGateway = Get-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
		Assert-AreEqual $rgName $P2SVpnGateway.ResourceGroupName
		Assert-AreEqual $P2SvpnGatewayName $P2SVpnGateway.Name
		Assert-AreEqual $vpnServerConfig1.Id $P2SVpnGateway.VpnServerConfiguration.Id
		Assert-AreEqual "Succeeded" $P2SVpnGateway.ProvisioningState
		Assert-AreEqual 1 @($P2SVpnGateway.CustomDnsServers).Count
		Assert-AreEqual "7.7.7.7" $P2SVpnGateway.CustomDnsServers[0]
		Assert-AreEqual $True $P2SVpnGateway.P2SConnectionConfigurations[0].EnableInternetSecurity
		Assert-AreEqual $True $P2SVpnGateway.IsRoutingPreferenceInternet

		$getPolicyGroup1 = Get-AzVpnServerConfigurationPolicyGroup -ResourceGroupName $rgName -ServerConfigurationName $VpnServerConfiguration1Name -Name "PolicyGroup1"
		Assert-AreEqual $getPolicyGroup1.Id	$vpnServerConfig1.ConfigurationPolicyGroups[0].Id

		# Reset/Reboot the P2SVpnGateway using Reset-AzP2sVpnGateway
		$job = Reset-AzP2sVpnGateway -P2SVpnGateway $P2SVpnGateway -AsJob
		$job | Wait-Job
		$actual = $job | Receive-Job

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
	
		# Create the VpnServerConfigurationMultiAuth with Radius and Certificate settings using New-AzVpnServerConfiguration
		New-AzVpnServerConfiguration -Name $VpnServerConfigurationMultiAuthName -ResourceGroupName $rgName -VpnProtocol OpenVpn -VpnAuthenticationType Radius,Certificate -RadiusServerAddress "TestRadiusServer" -RadiusServerSecret $Secure_String_Pwd -RadiusServerRootCertificateFilesList $listOfCerts -RadiusClientRootCertificateFilesList $listOfCerts -VpnClientRootCertificateFilesList $listOfCerts -Location $rglocation
        
        $vpnServerConfigMultiAuth = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfigurationMultiAuthName
		Assert-AreEqual "Succeeded" $vpnServerConfigMultiAuth.ProvisioningState
		Assert-AreEqual "TestRadiusServer" $vpnServerConfigMultiAuth.RadiusServerAddress
		$authenticationTypes = $vpnServerConfigMultiAuth.VpnAuthenticationTypes
		Assert-AreEqual 2 @($authenticationTypes).Count

		# List all VpnServerConfigurations under Resource group
		$vpnServerConfigs = Get-AzVpnServerConfiguration -ResourceGroupName $rgName
		Assert-NotNull $vpnServerConfigs
		Assert-AreEqual 3 @($vpnServerConfigs).Count

		# Create a PolicyGroup2 Object
		$policyGroup2= New-Object -TypeName Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroup
		$policyGroup2.Name = "PolicyGroup2"
		$policyGroup2.IsDefault = $true
		$policyGroup2.Priority = 0
		$policyGroupMember2 = New-Object -TypeName Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroupMember
		$policyGroupMember2.Name = "policyGroupMember2"
		$policyGroupMember2.AttributeType = "AADGroupId"
		$policyGroupMember2.AttributeValue = "41b23e61-6c1e-4545-b367-cd054e0ed4b5"
		$policyGroup2.PolicyMembers = New-Object Microsoft.Azure.Commands.Network.Models.PSVpnServerConfigurationPolicyGroupMember[] 1
		$policyGroup2.PolicyMembers[0] = $policyGroupMember2

		# Update existing VpnServerConfiguration2(adding child PolicyGroup2) using Update-AzVpnServerConfiguration
		Update-AzVpnServerConfiguration -Name $VpnServerConfiguration2Name -ResourceGroupName $rgName -RadiusServerAddress "TestRadiusServer1" -ConfigurationPolicyGroup $policyGroup2
		$VpnServerConfig2 = Get-AzVpnServerConfiguration -Name $VpnServerConfiguration2Name -ResourceGroupName $rgName
		Assert-AreEqual $VpnServerConfiguration2Name $VpnServerConfig2.Name
		Assert-AreEqual "TestRadiusServer1" $VpnServerConfig2.RadiusServerAddress
		Assert-AreEqual 1 @($VpnServerConfig2.ConfigurationPolicyGroups).Count
		Assert-AreEqual "PolicyGroup2" $VpnServerConfig2.ConfigurationPolicyGroups[0].Name
		Assert-AreEqual 0 $VpnServerConfig2.ConfigurationPolicyGroups[0].Priority

		# Delete VpnServerConfiguration2 child PolicyGroup2 using Remove-AzVpnServerConfigurationPolicyGroup		
		$delete = Remove-AzVpnServerConfigurationPolicyGroup -ResourceGroupName $rgName -ServerConfigurationName $VpnServerConfiguration2Name -Name "PolicyGroup2" -Force -PassThru
		Assert-AreEqual $True $delete
		$VpnServerConfig2 = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration2Name
		Assert-AreEqual 0 @($VpnServerConfig2.ConfigurationPolicyGroups).Count

		# Create PolicyGroup2 for VpnServerConfiguration2 using New-AzVpnServerConfigurationPolicyGroup
		New-AzVpnServerConfigurationPolicyGroup -ResourceGroupName $rgName -ServerConfigurationName $VpnServerConfiguration2Name -Name "PolicyGroup2" -DefaultPolicyGroup -Priority 1 -PolicyMember $policyGroupMember2
		$getPolicyGroup2 = Get-AzVpnServerConfigurationPolicyGroup -ResourceGroupName $rgName -ServerConfigurationName $VpnServerConfiguration2Name -Name "PolicyGroup2"
		Assert-AreEqual "PolicyGroup2" $getPolicyGroup2.Name
		Assert-AreEqual $true $getPolicyGroup2.IsDefault
		Assert-AreEqual 1 @($getPolicyGroup2.PolicyMembers).Count
		Assert-AreEqual 1 $getPolicyGroup2.Priority

		$VpnServerConfig2 = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration2Name
		Assert-AreEqual 1 @($VpnServerConfig2.ConfigurationPolicyGroups).Count

		# Update PolicyGroup2 for VpnServerConfiguration2 using Update-AzVpnServerConfigurationPolicyGroup
		Update-AzVpnServerConfigurationPolicyGroup -ResourceGroupName $rgName -ServerConfigurationName $VpnServerConfiguration2Name -Name "PolicyGroup2" -Priority 2 -DefaultPolicyGroup $true
		$getPolicyGroup2 = Get-AzVpnServerConfigurationPolicyGroup -ResourceGroupName $rgName -ServerConfigurationName $VpnServerConfiguration2Name -Name "PolicyGroup2"
		Assert-AreEqual $true $getPolicyGroup2.IsDefault
		Assert-AreEqual 2 $getPolicyGroup2.Priority

		Update-AzVpnServerConfiguration -ResourceId  $VpnServerConfig2.Id -RadiusServerAddress "TestRadiusServer2"			
		$VpnServerConfig2Get = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration2Name
		Assert-AreEqual "TestRadiusServer2" $VpnServerConfig2Get.RadiusServerAddress
						
		Update-AzVpnServerConfiguration -InputObject $VpnServerConfig2Get -RadiusServerAddress "TestRadiusServer3"
		$VpnServerConfig2Get = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfiguration2Name
        Assert-AreEqual "TestRadiusServer3" $VpnServerConfig2Get.RadiusServerAddress

		# Update existing VpnServerConfigurationMultiAuth using Update-AzVpnServerConfiguration
		Update-AzVpnServerConfiguration -Name $VpnServerConfigurationMultiAuthName -ResourceGroupName $rgName -VpnAuthenticationType Radius 
		$vpnServerConfigMultiAuth = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfigurationMultiAuthName
		Assert-AreEqual "Succeeded" $vpnServerConfigMultiAuth.ProvisioningState
		Assert-AreEqual "TestRadiusServer" $vpnServerConfigMultiAuth.RadiusServerAddress
		$authenticationTypes = $vpnServerConfigMultiAuth.VpnAuthenticationTypes
		Assert-AreEqual 1 @($authenticationTypes).Count

		Update-AzVpnServerConfiguration -Name $VpnServerConfigurationMultiAuthName -ResourceGroupName $rgName -VpnAuthenticationType Radius,Certificate,AAD -VpnClientRootCertificateFilesList $listOfCerts -AadAudience $aadAudience -AadIssuer $aadIssuer -AadTenant $aadTenant
		$vpnServerConfigMultiAuth = Get-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfigurationMultiAuthName
		Assert-AreEqual "Succeeded" $vpnServerConfigMultiAuth.ProvisioningState
		Assert-AreEqual "TestRadiusServer" $vpnServerConfigMultiAuth.RadiusServerAddress
		Assert-NotNull $vpnServerConfigMultiAuth.AadAuthenticationParameters.AadTenant;
		$authenticationTypes = $vpnServerConfigMultiAuth.VpnAuthenticationTypes
		Assert-AreEqual 3 @($authenticationTypes).Count

		# Update existing P2SVpnGateway  with new VpnClientAddressPool and CustomDnsServers using Update-AzP2sVpnGateway
		$vpnClientAddressSpaces[1] = "192.168.4.0/24"
		$updatedP2SVpnGateway = Update-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName -VpnClientAddressPool $vpnClientAddressSpaces -CustomDnsServer 9.9.9.9 -DisableInternetSecurityFlag

        $P2SVpnGateway = Get-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
		Assert-AreEqual $P2SvpnGatewayName $P2SVpnGateway.Name
		Assert-AreEqual "Succeeded" $P2SVpnGateway.ProvisioningState
		Assert-AreEqual $vpnServerConfig1.Id $P2SVpnGateway.VpnServerConfiguration.Id
		$setVpnClientAddressSpacesString = [system.String]::Join(" ", $vpnClientAddressSpaces)
        Assert-AreEqual $setVpnClientAddressSpacesString $P2SVpnGateway.P2SConnectionConfigurations[0].VpnClientAddressPool.AddressPrefixes
		Assert-AreEqual 1 @($P2SVpnGateway.CustomDnsServers).Count
        Assert-AreEqual "9.9.9.9" $P2SVpnGateway.CustomDnsServers[0]
		Assert-AreEqual $false $P2SVpnGateway.P2SConnectionConfigurations[0].EnableInternetSecurity

		# Update existing P2SVpnGateway to remove the CustomDnsServers & EnableInternetSecurityFlag & adding new P2SConnectionConfiguration
		$P2SVpnGateway = Get-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
		$p2SConnectionConfigs = New-Object Microsoft.Azure.Commands.Network.Models.PSP2SConnectionConfiguration[] 2
		$p2SConnectionConfigs[0] = $P2SVpnGateway.P2SConnectionConfigurations[0]
		$p2SConnectionConfigs[1] =  New-Object -TypeName Microsoft.Azure.Commands.Network.Models.PSP2SConnectionConfiguration
		$p2SConnectionConfigs[1].Name = "P2SConnectionConfigNew"
		$p2SConnectionConfigs[1].VpnClientAddressPool = New-Object -TypeName Microsoft.Azure.Commands.Network.Models.PSAddressSpace
		$p2SConnectionConfigs[1].VpnClientAddressPool.AddressPrefixes = New-Object string[] 1
		$p2SConnectionConfigs[1].VpnClientAddressPool.AddressPrefixes[0] = "192.168.5.0/24"
		Update-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName -CustomDnsServer @() -EnableInternetSecurityFlag -P2SConnectionConfiguration $p2SConnectionConfigs

		$P2SVpnGateway = Get-AzP2sVpnGateway -ResourceGroupName $rgName -Name $P2SvpnGatewayName
		Assert-AreEqual 0 @($P2SVpnGateway.CustomDnsServers).Count
		Assert-AreEqual 2 @($P2SVpnGateway.P2SConnectionConfigurations).Count
		Assert-AreEqual "P2SConnectionConfigDefault" $P2SVpnGateway.P2SConnectionConfigurations[0].Name
		Assert-AreEqual $true $P2SVpnGateway.P2SConnectionConfigurations[0].EnableInternetSecurity
		Assert-AreEqual "P2SConnectionConfigNew" $P2SVpnGateway.P2SConnectionConfigurations[1].Name		
		Assert-AreEqual $true $P2SVpnGateway.P2SConnectionConfigurations[1].EnableInternetSecurity

		$associatedVpnServerConfigs = Get-AzVirtualWanVpnServerConfiguration -ResourceId $virtualWan.Id
		Assert-NotNull $associatedVpnServerConfigs
		Assert-AreEqual 1 @($associatedVpnServerConfigs.VpnServerConfigurationResourceIds).Count
		Assert-AreEqual $vpnServerConfig1.Id $associatedVpnServerConfigs.VpnServerConfigurationResourceIds[0]

        # Delete VpnServerConfiguration2 using Remove-AzVpnServerConfiguration
		$delete = Remove-AzVpnServerConfiguration -InputObject $VpnServerConfig2Get -Force -PassThru
		Assert-AreEqual $True $delete

		# Delete VpnServerConfigurationMultiAuthName using Remove-AzVpnServerConfiguration
		$delete = Remove-AzVpnServerConfiguration -ResourceGroupName $rgName -Name $VpnServerConfigurationMultiAuthName -Force -PassThru
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
		#Assert-AreEqual 0 @($associatedVpnServerConfigs.VpnServerConfigurationResourceIds).Count

		# Verify that Get PolicyGroup1 works even after attached P2SVpnGateway was deleted.
		$getPolicyGroup1 = Get-AzVpnServerConfigurationPolicyGroup -ResourceGroupName $rgName -ServerConfigurationName $VpnServerConfiguration1Name -Name "PolicyGroup1"
		Assert-NotNull $getPolicyGroup1

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

function Test-VpnSiteLinkConnectionGetIkeSa
{
	# Setup
    	$rgName = Get-ResourceName
    	$rglocation = Get-ProviderLocation ResourceManagement
	$virtualWan1Name = Get-ResourceName
	$virtualWan2Name = Get-ResourceName
	$virtualHub1Name = Get-ResourceName
	$virtualHub2Name = Get-ResourceName
	$vpnSiteLink1Name = Get-ResourceName
	$vpnSiteLink2Name = Get-ResourceName
	$vpnSite1Name = Get-ResourceName
	$vpnSite2Name = Get-ResourceName
	$vpnGateway1Name = Get-ResourceName
	$vpnGateway2Name = Get-ResourceName
	$vpnSiteLinkConnection1Name = Get-ResourceName
	$vpnSiteLinkConnection2Name = Get-ResourceName
	$vpnConnection1Name = Get-ResourceName
	$vpnConnection2Name = Get-ResourceName
    
	try
	{
		# Create Resource Group
		$resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation

		# Create and Get Virtual Wan 1
		$createVirtualWan1 = New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWan1Name -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
		$virtualWan1 = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWan1Name
		Assert-AreEqual $rgName $virtualWan1.ResourceGroupName
		Assert-AreEqual $virtualWan1Name $virtualWan1.Name

		# Create and Get Virtual Hub 1
		$createVirtualHub1 = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHub1Name -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan1
		$virtualHub1 = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHub1Name
		Assert-AreEqual $rgName $virtualHub1.ResourceGroupName
		Assert-AreEqual $virtualHub1Name $virtualHub1.Name
		Assert-AreEqual "192.168.1.0/24" $virtualHub1.AddressPrefix

		# Create VPN Gateway 1
		$createVpnGateway1Job = New-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGateway1Name -VirtualHub $virtualHub1 -VpnGatewayScaleUnit 3 -AsJob

		# Create and Get Virtual Wan 2
		$createVirtualWan2 = New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWan2Name -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
		$virtualWan2 = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWan2Name
		Assert-AreEqual $rgName $virtualWan2.ResourceGroupName
		Assert-AreEqual $virtualWan2Name $virtualWan2.Name

		# Create and Get Virtual Hub 2
		$createVirtualHub2 = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHub2Name -Location $rglocation -AddressPrefix "192.169.1.0/24" -VirtualWan $virtualWan2
		$virtualHub2 = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHub2Name
		Assert-AreEqual $rgName $virtualHub2.ResourceGroupName
		Assert-AreEqual $virtualHub2Name $virtualHub2.Name
		Assert-AreEqual "192.169.1.0/24" $virtualHub2.AddressPrefix

		# Create VPN Gateway 2
		$createVpnGateway2Job = New-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGateway2Name -VirtualHub $virtualHub2 -VpnGatewayScaleUnit 3 -AsJob

		# Create and Get VPN Site 1 with Links
		$vpnSite1AddressSpaces = New-Object string[] 1
		$vpnSite1AddressSpaces[0] = "192.168.2.0/24"
		$vpnSiteLink1 = New-AzVpnSiteLink -Name $vpnSiteLink1Name -IpAddress "5.5.5.5" -LinkProviderName "SomeTelecomProvider1" -LinkSpeedInMbps "10"
		
		$createVpnSite1 = New-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite1Name -Location $rglocation -VirtualWan $virtualWan1 -AddressSpace $vpnSite1AddressSpaces -DeviceModel "SomeDevice1" -DeviceVendor "SomeDeviceVendor1" -VpnSiteLink @($vpnSiteLink1)
		$vpnSite1 = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite1Name
		Assert-AreEqual $rgName $vpnSite1.ResourceGroupName
		Assert-AreEqual $vpnSite1Name $vpnSite1.Name
		Assert-AreEqual 1 $vpnSite1.VpnSiteLinks.Count

		# Get VPN Gateway 1
		$createVpnGateway1Job | Wait-Job
		$gw1 = $createVpnGateway1Job | Receive-Job
		$vpnGateway1 = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGateway1Name
		Assert-AreEqual $rgName $vpnGateway1.ResourceGroupName
		Assert-AreEqual $vpnGateway1Name $vpnGateway1.Name
		Assert-AreEqual 3 $vpnGateway1.VpnGatewayScaleUnit

		# Create and Get VPN Connection 1 and VPN Site Link Connection 1
		$sharedKeySecureString = ConvertTo-SecureString -String "abcd" -AsPlainText -Force

		$vpnSiteLinkConnection1 = New-AzVpnSiteLinkConnection -Name $vpnSiteLinkConnection1Name -VpnSiteLink $vpnSite1.VpnSiteLinks[0] -SharedKey $sharedKeySecureString -ConnectionBandwidth 100
		$createVpnConnection1 = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGateway1Name -Name $vpnConnection1Name -VpnSite $vpnSite1 -VpnSiteLinkConnection @($vpnSiteLinkConnection1)
		$vpnConnection1 = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGateway1Name -Name $vpnConnection1Name
		Assert-AreEqual $vpnConnection1Name $vpnConnection1.Name
		Assert-AreEqual 1 $vpnConnection1.VpnLinkConnections.Count

		# Get IP Address of an Instance of VPN Gateway 1
		$instanceIp1 = "0.0.0.0"
		if ((Get-NetworkTestMode) -ne 'Playback')
		{
			$storetype = 'Standard_GRS'
			$containerName = "cont1$($rgName)"
			$storeName = "blob1" + $rgName
			New-AzStorageAccount -ResourceGroupName $rgName -Name $storeName -Location $rglocation -Type $storetype
			$key = Get-AzStorageAccountKey -ResourceGroupName $rgName -Name $storeName
			$context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
			New-AzStorageContainer -Name $containerName -Context $context
			$container = Get-AzStorageContainer -Name $containerName -Context $context
			$now = Get-Date
			$vpnSite1ConfigFileName = "vpnSite1Config.json"
			$blobSasUrl1 = New-AzStorageBlobSASToken -Container $containerName -Blob $vpnSite1ConfigFileName -Context $context -Permission "rwd" -StartTime $now.AddHours(-1) -ExpiryTime $now.AddDays(1) -FullUri
			$sasUrl1 = Get-AzVirtualWanVpnConfiguration -VirtualWan $virtualWan1 -StorageSasUrl $blobSasUrl1 -VpnSite $vpnSite1

			$configFile1 = Get-AzStorageBlobContent -Blob $vpnSite1ConfigFileName -Container $containerName -Context $context
			$configFile1Data = (Get-Content $vpnSite1ConfigFileName -Raw) | ConvertFrom-Json
			$instanceIp1 = $configFile1Data.vpnSiteConnections.gatewayConfiguration.IpAddresses.Instance0
		}
		Assert-NotNull $instanceIp1

		# Create and Get VPN Site 2 with Links
		$vpnSite2AddressSpaces = New-Object string[] 1
		$vpnSite2AddressSpaces[0] = "192.169.2.0/24"
		$vpnSiteLink2 = New-AzVpnSiteLink -Name $vpnSiteLink2Name -IpAddress $instanceIp1 -LinkProviderName "SomeTelecomProvider2" -LinkSpeedInMbps "10"

		$createVpnSite2 = New-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name -Location $rglocation -VirtualWan $virtualWan2 -AddressSpace $vpnSite2AddressSpaces -DeviceModel "SomeDevice2" -DeviceVendor "SomeDeviceVendor2" -VpnSiteLink @($vpnSiteLink2)
		$vpnSite2 = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name
		Assert-AreEqual $rgName $vpnSite2.ResourceGroupName
		Assert-AreEqual $vpnSite2Name $vpnSite2.Name
		Assert-AreEqual 1 $vpnSite2.VpnSiteLinks.Count

		# Get VPN Gateway 1
		$createVpnGateway2Job | Wait-Job
		$gw2 = $createVpnGateway2Job | Receive-Job
		$vpnGateway2 = Get-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGateway2Name
		Assert-AreEqual $rgName $vpnGateway2.ResourceGroupName
		Assert-AreEqual $vpnGateway2Name $vpnGateway2.Name
		Assert-AreEqual 3 $vpnGateway2.VpnGatewayScaleUnit

		# Create and Get VPN Connection 2 to Site with Links
		$vpnSiteLinkConnection2 = New-AzVpnSiteLinkConnection -Name $vpnSiteLinkConnection2Name -VpnSiteLink $vpnSite2.VpnSiteLinks[0] -SharedKey $sharedKeySecureString -ConnectionBandwidth 100
		$createVpnConnection2 = New-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGateway2Name -Name $vpnConnection2Name -VpnSite $vpnSite2 -VpnSiteLinkConnection @($vpnSiteLinkConnection2)
		$vpnConnection2 = Get-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGateway2Name -Name $vpnConnection2Name
		Assert-AreEqual $vpnConnection2Name $vpnConnection2.Name
		Assert-AreEqual 1 $vpnConnection2.VpnLinkConnections.Count

		# Get IP Address of an Instance of VPN Gateway 2
		$instanceIp2 = "0.0.0.1"
		if ((Get-NetworkTestMode) -ne 'Playback')
		{
			$storetype = 'Standard_GRS'
			$containerName = "cont2$($rgName)"
			$storeName = "blob2" + $rgName
			New-AzStorageAccount -ResourceGroupName $rgName -Name $storeName -Location $rglocation -Type $storetype
			$key = Get-AzStorageAccountKey -ResourceGroupName $rgName -Name $storeName
			$context = New-AzStorageContext -StorageAccountName $storeName -StorageAccountKey $key[0].Value
			New-AzStorageContainer -Name $containerName -Context $context
			$container = Get-AzStorageContainer -Name $containerName -Context $context
			$now = Get-Date

			$vpnSite2ConfigFileName = "vpnSite2Config.json"
			$blobSasUrl2 = New-AzStorageBlobSASToken -Container $containerName -Blob $vpnSite2ConfigFileName -Context $context -Permission "rwd" -StartTime $now.AddHours(-1) -ExpiryTime $now.AddDays(1) -FullUri
			$sasUrl2 = Get-AzVirtualWanVpnConfiguration -VirtualWan $virtualWan2 -StorageSasUrl $blobSasUrl2 -VpnSite $vpnSite2

			$configFile2 = Get-AzStorageBlobContent -Blob $vpnSite2ConfigFileName -Container $containerName -Context $context
			$configFile2Data = (Get-Content $vpnSite2ConfigFileName -Raw) | ConvertFrom-Json
			$instanceIp2 = $configFile2Data.vpnSiteConnections.gatewayConfiguration.IpAddresses.Instance0
		}
		Assert-NotNull $instanceIp2

		# Update IP Address of VPN Site Link 1
		$vpnSiteLink1.IpAddress = $instanceIp2
		Update-AzVpnSite -InputObject $vpnSite1 -VpnSiteLink $vpnSiteLink1
		$vpnSite1 = Get-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite1Name

		Start-Sleep -Seconds 350

		# Get IKE Security Associations for VPN Site Link Connections
		$ikesa1 = Get-AzVpnSiteLinkConnectionIkeSa -ResourceGroupName $rgName -VpnGatewayName $vpnGateway1Name -VpnConnectionName $vpnConnection1Name -Name $vpnSiteLinkConnection1Name
		Assert-NotNull $ikesa1

		$ikesa2 = Get-AzVpnSiteLinkConnectionIkeSa -InputObject $vpnConnection2.VpnLinkConnections[0]
		Assert-NotNull $ikesa2

		# Clean Resources
		<#
		$delete = Remove-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGateway1Name -Name $vpnConnection1Name -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGateway2Name -Name $vpnConnection2Name -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGateway1Name -Force -PassThru
		Assert-AreEqual $True $delete

		$delete = Remove-AzVpnGateway -ResourceGroupName $rgName -Name $vpnGateway2Name -Force -PassThru
		Assert-AreEqual $True $delete
		
		$delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite1Name -Force -PassThru
		Assert-AreEqual $True $delete
		
		$delete = Remove-AzVpnSite -ResourceGroupName $rgName -Name $vpnSite2Name -Force -PassThru
		Assert-AreEqual $True $delete
		
		$delete = Remove-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHub1Name -Force -PassThru
		Assert-AreEqual $True $delete
		
		$delete = Remove-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHub2Name -Force -PassThru
		Assert-AreEqual $True $delete
		
		$delete = Remove-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWan1Name -Force -PassThru
		Assert-AreEqual $True $delete
		
		$delete = Remove-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWan2Name -Force -PassThru
		Assert-AreEqual $True $delete
		#>
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}
}
