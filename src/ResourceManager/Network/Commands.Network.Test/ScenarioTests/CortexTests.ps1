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