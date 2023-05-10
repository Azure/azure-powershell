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
VirtualHubBgpConnectionCRUD
#>
function Test-VirtualHubBgpConnectionCRUD
{
	# Setup
    $rgName = Get-ResourceGroupName
    $rglocation = Get-ProviderLocation "ResourceManagement" "westcentralus"
    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName
    $virtualNetworkName = Get-ResourceName
    $hubVnetConnectionName = Get-ResourceName
    $hubBgpConnectionName = Get-ResourceName

    try
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgName -Location $rglocation

        # Create the Virtual Wan
        $createdVirtualWan = New-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
        $virtualWan = Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
        Write-Debug "Created Virtual WAN $($virtualWan.Name) successfully"

        # Create the Virtual Hub
        $createdVirtualHub = New-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "10.8.0.0/24" -VirtualWan $virtualWan
        $virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
        Write-Debug "Created Virtual Hub $($virtualHub.Name) successfully"

        # Wait for Virtual Hub Routing State to become Provisioned or Failed
        while ($virtualHub.RoutingState -eq "Provisioning")
        {
            Start-TestSleep -Seconds 30
            $virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
        }
        Assert-AreEqual $virtualHub.RoutingState "Provisioned"

        # Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name "default" -AddressPrefix "192.168.1.0/24"
        $createdVirtualNetwork = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $virtualNetworkName -Location $rglocation -AddressPrefix "192.168.0.0/16" -Subnet $subnet
        $virtualNetwork = Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $virtualNetworkName
        Write-Debug "Created Virtual Network $($virtualNetwork.Name) successfully"

        # Create HubVnetConnection
        $createdHubVnetConnection = New-AzVirtualHubVnetConnection -ResourceGroupName $rgName -ParentResourceName $virtualHubName -Name $hubVnetConnectionName -RemoteVirtualNetwork $virtualNetwork
        $hubVnetConnection = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -ParentResourceName $virtualHubName -Name $hubVnetConnectionName
        Write-Debug "Created Virtual Hub Vnet Connection $($hubVnetConnection.Name) successfully"

        # Create HubBgpConnection
        $createdBgpConnection = New-AzVirtualHubBgpConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubBgpConnectionName -PeerIp "192.168.1.5" -PeerAsn "20000" -VirtualHubVnetConnection $hubVnetConnection
        $bgpConnection = Get-AzVirtualHubBgpConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubBgpConnectionName
        Assert-AreEqual $bgpConnection.Name $hubBgpConnectionName
        Assert-AreEqual $bgpConnection.PeerIp "192.168.1.5"
        Assert-AreEqual $bgpConnection.PeerAsn "20000"
        Assert-AreEqual $bgpConnection.HubVirtualNetworkConnection.Id $hubVnetConnection.Id

        # Delete HubBgpConnection
        Remove-AzVirtualHubBgpConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubBgpConnectionName -Force
        Assert-ThrowsLike { Get-AzVirtualHubBgpConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubBgpConnectionName } "*Not*Found*"

        # Delete HubVnetConnection
        Remove-AzVirtualHubVnetConnection -ResourceGroupName $rgName -ParentResourceName $virtualHubName -Name $hubVnetConnectionName -Force
        Assert-ThrowsLike { Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -ParentResourceName $virtualHubName -Name $hubVnetConnectionName } "*Not*Found*"

        # Delete Virtual Network
        Remove-AzVirtualNetwork -ResourceGroupName $rgName -Name $virtualNetworkName -Force
        Assert-ThrowsLike { Get-AzVirtualNetwork -ResourceGroupName $rgName -Name $virtualNetworkName } "*Not*Found*"

        # Delete Virtual Hub
        Remove-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Force
        $virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
        Assert-AreEqual $virtualHub.Count 0

        # Delete Virtual Wan
        Remove-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Force
        Assert-ThrowsLike { Get-AzVirtualWan -ResourceGroupName $rgName -Name $virtualWanName } "*Not*Found*"
    }
    finally
    {
        Clean-ResourceGroup $rgName
    }
}