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
VirtualHubRouteTableCRUD
#>
function Test-VirtualHubRouteTableCRUD
{
    # Setup
    $rgName = Get-ResourceGroupName
    # ExpressRoute gateways have been enabled only in westcentralus region
    $rglocation = Get-ProviderLocation "ResourceManagement" "westcentralus"

    $virtualWanName = Get-ResourceName
    $virtualHubName = Get-ResourceName
    $expressRouteGatewayName = Get-ResourceName
	$routeTable1Name = Get-ResourceName

    try
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgName -Location $rglocation

        # Create the Virtual Wan
        $createdVirtualWan = New-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName -Location $rglocation -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
        $virtualWan = Get-AzureRmVirtualWan -ResourceGroupName $rgName -Name $virtualWanName
        Write-Debug "Created Virtual WAN $virtualWan.Name successfully"

		# Create the Virtual Hub
        $createdVirtualHub = New-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -Location $rglocation -AddressPrefix "10.8.0.0/24" -VirtualWan $virtualWan
        $virtualHub = Get-AzureRmVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
        Write-Debug "Created Virtual Hub virtualHub.Name successfully"

        # Create the ExpressRouteGateway
        $createdExpressRouteGateway = New-AzureRmExpressRouteGateway -ResourceGroupName $rgName -Name $expressRouteGatewayName -VirtualHub $virtualHub -MinScaleUnits 2
        Write-Debug "Created ExpressRoute Gateway $expressRouteGatewayName successfully"
        $expressRouteGateway = Get-AzureRmExpressRouteGateway -ResourceGroupName $rgName -Name $expressRouteGatewayName
        Assert-NotNull $expressRouteGateway
        Write-Debug "Retrieved ExpressRoute Gateway $expressRouteGatewayName successfully"

		# Create a RouteTable child Resource
		$route1 = Add-AzVirtualHubRoute -DestinationType "CIDR" -Destination @("10.4.0.0/16", "10.5.0.0/16") -NextHopType "IPAddress" -NextHop @("10.0.0.68")
		$route2 = Add-AzVirtualHubRoute -DestinationType "CIDR" -Destination @("0.0.0.0/0") -NextHopType "IPAddress" -NextHop @("10.0.0.68")
    	$routeTable1 = Add-AzVirtualHubRouteTable -Route @($route1, $route2) -Connection @("All_Vnets") -Name $routeTable1Name
		Set-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -RouteTable @($routeTable1)
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		$routeTables = $virtualHub.RouteTables
		Assert-AreEqual 1 @($routeTables).Count
		$routes1 = $routeTables[0].Routes
		Assert-AreEqual 2 @($routes1).Count

		# Update a RouteTable child resource
		$routeTable1 = Get-AzVirtualHubRouteTable -ResourceGroupName $rgName -HubName $virtualHubName -Name $routeTable1Name
		$routeTable1.Routes.RemoveAt(1)
		$routeTable1.Routes[0].NextHops = @("10.0.0.67")
		$routeTable1.Connections = @("All_Branches")
		Set-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName -RouteTable @($routeTable1)
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		$routeTables = $virtualHub.RouteTables
		Assert-AreEqual 1 @($routeTables).Count
		$routes1 = $routeTables[0].Routes
		Assert-AreEqual 1 @($routes1).Count

		# Delete a RouteTable child resource
		Remove-AzVirtualHubRouteTable -ResourceGroupName $rgName -HubName $virtualHubName -Name $routeTable1Name
		$virtualHub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $virtualHubName
		Assert-AreEqual $virtualHubName $virtualHub.Name
		$routeTables = $virtualHub.RouteTables
		Assert-AreEqual 0 @($routeTables).Count

		# Create a HubVirtualNetworkConnection
		$remoteVirtualNetwork = New-AzVirtualNetwork -ResourceGroupName $rgName -Name $remoteVirtualNetworkName -Location $rglocation -AddressPrefix "10.0.1.0/24"
		$createdHubVnetConnection = New-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName -RemoteVirtualNetwork $remoteVirtualNetwork
		$hubVnetConnection = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName
		Assert-AreEqual $hubVnetConnectionName $hubVnetConnection.Name
        $hubVnetConnections = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName
        Assert-NotNull $hubVnetConnections
        $hubVnetConnections = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name "*"
        Assert-NotNull $hubVnetConnections

		# Update a HubVirtualNetworkConnection
		Update-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName -EnableInternetSecurity $true
		$hubVnetConnection = Get-AzVirtualHubVnetConnection -ResourceGroupName $rgName -VirtualHubName $virtualHubName -Name $hubVnetConnectionName
		Assert-AreEqual $hubVnetConnection.EnableInternetSecurity $true

        # Clean up
		$delete = Remove-AzVirtualHubVnetConnection -ResourceGroupName $rgName -ParentResourceName $virtualHubName -Name $hubVnetConnectionName -Force -PassThru
        Assert-AreEqual $True $delete

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