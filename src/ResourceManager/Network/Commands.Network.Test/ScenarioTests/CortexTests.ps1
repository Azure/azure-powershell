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
Virtual network express route gateway tests
#>
function Test-CortexCRUD
{
 # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = "centraluseuap"

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
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation

		# Create the Virtual Wan
		$createdVirtualWan = New-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation
		$virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
		Assert-AreEqual $createdVirtualWan.ResourceGroupName $virtualWan.ResourceGroupName
		Assert-AreEqual $createdVirtualWan.Name $virtualWan.Name

		# Create the Virtual Hub
		$createdVirtualHub = New-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "192.168.1.0/24" -VirtualWan $virtualWan
		$virtualHub = Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $createdVirtualHub.ResourceGroupName $virtualHub.ResourceGroupName
		Assert-AreEqual $createdVirtualHub.Name $virtualHub.Name

		# Create the VpnSite
		$vpnSiteAddressSpaces = New-Object string[] 2
		$vpnSiteAddressSpaces[0] = "192.168.2.0/24"
		$vpnSiteAddressSpaces[1] = "192.168.3.0/24"
		$createdVpnSite = New-AzureRmVpnSite -ResourceGroupName $rgName -Name $vpnSiteName -Location $rglocation -VirtualWan $virtualWan -IpAddress "1.2.3.4" -AddressSpace $vpnSiteAddressSpaces -DeviceModel "SomeDevice" -DeviceVendor "SomeDeviceVendor" -LinkSpeedInMbps "10"
		$vpnSite = Get-AzureRmVpnSite -ResourceGroupName $rgname -Name $vpnSiteName
		Assert.AreEqual $createdVpnSite.ResourceGroupName $vpnSite.ResourceGroupName
		Assert.AreEqual $createdVpnSite.Name $vpnSite.Name

		# Create the VpnGateway
		$createdVpnGateway = New-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName -VirtualHub $virtualHub -VpnGatewayScaleUnit 1
		$vpnGateway = Get-AzureRmVpnGateway -ResourceGroupName $rgName -Name $vpnGatewayName
		Assert.AreEqual $createdVpnGateway.ResourceGroupName $vpnGateway.ResourceGroupName
		Assert.AreEqual $createdVpnGateway.Name $vpnGateway.Name

		# Create the VpnConnection
		$createdVpnConnection = New-AzureRmVpnConnection -ResourceGroupName $vpnGateway.ResourceGroupName -ParentResourceName $vpnGateway.Name -Name $vpnConnectionName -VpnSite $vpnSite -ConnectionBandwidth 20
		$vpnConnection = Get-AzureRmVpnConnection -ResourceGroupName $vpnGateway.ResourceGroupName -ParentResourceName $vpnGateway.Name -Name $vpnConnectionName
		Assert.AreEqual $createdVpnConnection.ResourceGroupName $vpnConnection.ResourceGroupName
		Assert.AreEqual $createdVpnConnection.Name $vpnConnection.Name

		# Create a HubVirtualNetworkConnection
		$createdHubVnetConnection = New-AzureRmHubVirtualNetworkConnection -ResourceGroupName $rgName -VirtualHubName $virtualHub.Name -Name $hubVnetConnectionName -RemoteVirtualNetwork $remoteVirtualNetwork
		$hubVnetConnection = Get-AzureRmHubVirtualNetworkConnection -ResourceGroupName $rgName -VirtualHubName $virtualHub.Name -Name $hubVnetConnectionName
	}
	finally
	{
		Remove-AzureRmHubVirtualNetworkConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName
		Remove-AzureRmVpnConnection -ResourceGroupName $rgName -ParentResourceName $vpnGatewayName -Name $vpnConnectionName
		Remove-AzureRmVpnGateway -ResourceGroupName $rgname -Name $vpnGatewayName
		Remove-AzureRmVpnSite -ResourceGroupName $rgname -Name $vpnSiteName
		Remove-AzureRmVirtualHub -ResourceGroupName $rgname -Name $virtualHubName
		Remove-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
	}
}