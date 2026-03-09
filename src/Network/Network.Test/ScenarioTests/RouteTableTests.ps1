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
Tests Empty RouteTable.
#>
function Test-EmptyRouteTable
{
    # Setup
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create RouteTable
        $job = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -AsJob
		$job | Wait-Job
		$rt = $job | Receive-Job

        # Get RouteTable
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName
        
        #verification
        Assert-AreEqual $rgName $getRT.ResourceGroupName
        Assert-AreEqual $routeTableName $getRT.Name
        Assert-NotNull $getRT.Etag
        Assert-AreEqual 0 @($getRT.Routes).Count        

        # list
        $list = Get-AzRouteTable -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getRT.ResourceGroupName
        Assert-AreEqual $list[0].Name $getRT.Name
        Assert-AreEqual $list[0].Etag $getRT.Etag
        Assert-AreEqual @($list[0].Routes).Count @($getRT.Routes).Count     
		
        $list = Get-AzRouteTable -ResourceGroupName "*"
        Assert-True { $list.Count -ge 0 }

        $list = Get-AzRouteTable -Name "*"
        Assert-True { $list.Count -ge 0 }

        $list = Get-AzRouteTable -ResourceGroupName "*" -Name "*"
        Assert-True { $list.Count -ge 0 }

        # Delete NetworkSecurityGroup
        $job = Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force -AsJob
		$job | Wait-Job
		$delete = $job | Receive-Job
        Assert-AreEqual true $delete
        
        $list = Get-AzRouteTable -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests RouteTable CRUD.
#>
function Test-RouteTableCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
		$route1 = New-AzRouteConfig -name "route1" -AddressPrefix "192.168.1.0/24" -NextHopIpAddress "23.108.1.1" -NextHopType "VirtualAppliance"
		        
        # Create RouteTable
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route1

		# Get RouteTable
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName

		#verification
        Assert-AreEqual $rgName $getRT.ResourceGroupName
        Assert-AreEqual $routeTableName $getRT.Name
        Assert-NotNull $getRT.Etag
        Assert-AreEqual 1 @($getRT.Routes).Count       
		Assert-AreEqual $getRT.Routes[0].Name "route1"
		Assert-AreEqual $getRT.Routes[0].AddressPrefix "192.168.1.0/24"
		Assert-AreEqual $getRT.Routes[0].NextHopIpAddress "23.108.1.1"
		Assert-AreEqual $getRT.Routes[0].NextHopType "VirtualAppliance"
		Assert-NotNull $getRT.Routes[0].Etag

		# list
        $list = Get-AzRouteTable -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getRT.ResourceGroupName
        Assert-AreEqual $list[0].Name $getRT.Name
        Assert-AreEqual $list[0].Etag $getRT.Etag
        Assert-AreEqual @($list[0].Routes).Count @($getRT.Routes).Count
		Assert-AreEqual $list[0].Routes[0].Etag $getRT.Routes[0].Etag  

		$route2 = New-AzRouteConfig -name "route2" -AddressPrefix "192.168.2.0/24" -NextHopType "VnetLocal"

		# Add a route table
		$getRT = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route1,$route2 -Force

		#verification
        Assert-AreEqual $rgName $getRT.ResourceGroupName
        Assert-AreEqual $routeTableName $getRT.Name
        Assert-NotNull $getRT.Etag
        Assert-AreEqual 2 @($getRT.Routes).Count       
		Assert-AreEqual $getRT.Routes[0].Name "route1"
		Assert-AreEqual $getRT.Routes[1].Name "route2"
		Assert-AreEqual $getRT.Routes[1].AddressPrefix "192.168.2.0/24"
		Assert-null $getRT.Routes[1].NextHopIpAddress
		Assert-AreEqual $getRT.Routes[1].NextHopType "VnetLocal"
		Assert-NotNull $getRT.Routes[1].Etag

		# Remove a route table
		$getRT = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route2 -Force

		Assert-AreEqual $rgName $getRT.ResourceGroupName
        Assert-AreEqual $routeTableName $getRT.Name
        Assert-NotNull $getRT.Etag
        Assert-AreEqual 1 @($getRT.Routes).Count       
		Assert-AreEqual $getRT.Routes[0].Name "route2"		

		# Delete NetworkSecurityGroup
        $delete = Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzRouteTable -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests RouteTable Subnet CRUD
#>
function Test-RouteTableSubnetRef
{
    # Setup
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
	$vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
		$route1 = New-AzRouteConfig -name "route1" -AddressPrefix "192.168.1.0/24" -NextHopIpAddress "23.108.1.1" -NextHopType "VirtualAppliance"
		        
        # Create RouteTable
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route1

		# Get RouteTable
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName

		#verification
        Assert-AreEqual $rgName $getRT.ResourceGroupName
        Assert-AreEqual $routeTableName $getRT.Name
        Assert-NotNull $getRT.Etag
        Assert-AreEqual 1 @($getRT.Routes).Count       
		Assert-AreEqual $getRT.Routes[0].Name "route1"
	
		# create vnet and subnet associated to a Routetable
		# Create the Virtual Network
        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24 -RouteTable $getRT
        $vnet = New-AzVirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8 -Subnet $subnet
		
		# Verify RouteTable reference in subnet
		Assert-AreEqual $vnet.Subnets[0].RouteTable.Id $getRT.Id

		# Verify subnet reference in Routetable
		$getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName
		Assert-AreEqual 1 @($getRT.Subnets).Count       
		Assert-AreEqual $vnet.Subnets[0].Id $getRT.Subnets[0].Id		
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests RouteTable Route CRUD
#>
function Test-RouteTableRouteCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
	$vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
		$route1 = New-AzRouteConfig -name "route1" -AddressPrefix "192.168.1.0/24" -NextHopIpAddress "23.108.1.1" -NextHopType "VirtualAppliance"
		        
        # Create RouteTable
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route1

		# Get RouteTable
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName

		#verification
        Assert-AreEqual $rgName $getRT.ResourceGroupName
        Assert-AreEqual $routeTableName $getRT.Name
        Assert-NotNull $getRT.Etag
        Assert-AreEqual 1 @($getRT.Routes).Count       
		Assert-AreEqual $getRT.Routes[0].Name "route1"
		
		# get route
		$route = $getRT | Get-AzRouteConfig -name "route1"
		Assert-AreEqual $route.Name "route1"
		Assert-AreEqual $getRT.Routes[0].Name $route.Name
		Assert-AreEqual $getRT.Routes[0].AddressPrefix $route.AddressPrefix
		Assert-AreEqual $getRT.Routes[0].NextHopType $route.NextHopType
		Assert-AreEqual $getRT.Routes[0].NextHopIpAddress $route.NextHopIpAddress

		# Add a Route
		$job = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName | Add-AzRouteConfig -name "route2" -AddressPrefix "192.168.2.0/24" -NextHopType "VnetLocal" | Set-AzRouteTable -AsJob
		$job | Wait-Job
		$getRT = $job | Receive-Job

		# get route
		$route = $getRT | Get-AzRouteConfig -name "route2"

		#verification
        Assert-AreEqual 2 @($getRT.Routes).Count       
		Assert-AreEqual $route.Name "route2"
		Assert-AreEqual $getRT.Routes[1].Name $route.Name
		Assert-AreEqual $getRT.Routes[1].AddressPrefix $route.AddressPrefix
		Assert-AreEqual $route.AddressPrefix "192.168.2.0/24"
		Assert-AreEqual $getRT.Routes[1].NextHopType $route.NextHopType
		Assert-AreEqual $route.NextHopType "VnetLocal"
		Assert-Null $route.NextHopIpAddress
		Assert-Null $getRT.Routes[1].NextHopIpAddress

		# list route
		$list = $getRT | Get-AzRouteConfig
		Assert-AreEqual 2 @($list).Count       
		Assert-AreEqual $list[1].Name "route2"
		Assert-AreEqual $list[1].Name $route.Name
		Assert-AreEqual $list[1].AddressPrefix $route.AddressPrefix
		Assert-AreEqual $list[1].NextHopType $route.NextHopType
		Assert-Null $list[1].NextHopIpAddress

		# set route
		$getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName | Set-AzRouteConfig -name "route2" -AddressPrefix "192.168.3.0/24" -NextHopType "VnetLocal" | Set-AzRouteTable

		# get route
		$route = $getRT | Get-AzRouteConfig -name "route2"

		#verification
        Assert-AreEqual 2 @($getRT.Routes).Count       
		Assert-AreEqual $route.Name "route2"
		Assert-AreEqual $getRT.Routes[1].Name $route.Name
		Assert-AreEqual $route.AddressPrefix "192.168.3.0/24"
		Assert-AreEqual $getRT.Routes[1].AddressPrefix $route.AddressPrefix
		Assert-AreEqual $getRT.Routes[1].NextHopType $route.NextHopType
		Assert-Null $route.NextHopIpAddress
		Assert-Null $getRT.Routes[1].NextHopIpAddress

		# Delete route
		$getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName | Remove-AzRouteConfig -name "route1" | Set-AzRouteTable

		# list route
		$list = $getRT | Get-AzRouteConfig
		Assert-AreEqual 1 @($list).Count       
		Assert-AreEqual $list[0].Name "route2"

		# Delete NetworkSecurityGroup
        $delete = Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzRouteTable -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests RouteTable Hoptype Test
#>
function Test-RouteHopTypeTest
{
    # Setup
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
	$vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
		$route1 = New-AzRouteConfig -name "route1" -AddressPrefix "192.168.1.0/24" -NextHopIpAddress "23.108.1.1" -NextHopType "VirtualAppliance"
		$route2 = New-AzRouteConfig -name "route2" -AddressPrefix "10.0.1.0/24" -NextHopType "VnetLocal"
		$route3 = New-AzRouteConfig -name "route3" -AddressPrefix "0.0.0.0/0" -NextHopType "Internet"
		$route4 = New-AzRouteConfig -name "route4" -AddressPrefix "10.0.2.0/24" -NextHopType "None"
		        
        # Create RouteTable
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route1, $route2, $route3, $route4

		# Get RouteTable
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName

		#verification
        Assert-AreEqual $rgName $getRT.ResourceGroupName
        Assert-AreEqual $routeTableName $getRT.Name
        Assert-NotNull $getRT.Etag
        Assert-AreEqual 4 @($getRT.Routes).Count       
		Assert-AreEqual $getRT.Routes[0].Name "route1"
		Assert-AreEqual $getRT.Routes[0].NextHopType "VirtualAppliance"
		Assert-AreEqual $getRT.Routes[1].Name "route2"
		Assert-AreEqual $getRT.Routes[1].NextHopType "VnetLocal"
		Assert-AreEqual $getRT.Routes[2].Name "route3"
		Assert-AreEqual $getRT.Routes[2].NextHopType "Internet"
		Assert-AreEqual $getRT.Routes[3].Name "route4"
		Assert-AreEqual $getRT.Routes[3].NextHopType "None"
		
		# Delete RouteTable
        $delete = Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzRouteTable -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests Route with ECMP (Equal-Cost Multi-Path) NextHop.
#>
function Test-RouteEcmpNextHop
{
    # Setup
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create route with ECMP next hop type and multiple IP addresses
        $ecmpRoute = New-AzRouteConfig -name "ecmpRoute1" -AddressPrefix "192.168.1.0/24" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.1","10.0.0.2"

        # Verify the in-memory route config
        Assert-AreEqual "ecmpRoute1" $ecmpRoute.Name
        Assert-AreEqual "192.168.1.0/24" $ecmpRoute.AddressPrefix
        Assert-AreEqual "VirtualApplianceEcmp" $ecmpRoute.NextHopType
        Assert-Null $ecmpRoute.NextHopIpAddress
        Assert-NotNull $ecmpRoute.NextHop
        Assert-NotNull $ecmpRoute.NextHop.NextHopIpAddresses
        Assert-AreEqual 2 $ecmpRoute.NextHop.NextHopIpAddresses.Count
        Assert-AreEqual "10.0.0.1" $ecmpRoute.NextHop.NextHopIpAddresses[0]
        Assert-AreEqual "10.0.0.2" $ecmpRoute.NextHop.NextHopIpAddresses[1]

        # Create a regular VirtualAppliance route for comparison
        $regularRoute = New-AzRouteConfig -name "regularRoute" -AddressPrefix "192.168.2.0/24" -NextHopIpAddress "23.108.1.1" -NextHopType "VirtualAppliance"

        # Create RouteTable with both ECMP and regular routes
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute, $regularRoute

        # Get RouteTable
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName

        # Verify the route table
        Assert-AreEqual $rgName $getRT.ResourceGroupName
        Assert-AreEqual $routeTableName $getRT.Name
        Assert-NotNull $getRT.Etag
        Assert-AreEqual 2 @($getRT.Routes).Count

        # Verify ECMP route
        $ecmpRouteResult = $getRT | Get-AzRouteConfig -name "ecmpRoute1"
        Assert-AreEqual "ecmpRoute1" $ecmpRouteResult.Name
        Assert-AreEqual "VirtualApplianceEcmp" $ecmpRouteResult.NextHopType
        Assert-NotNull $ecmpRouteResult.NextHop
        Assert-AreEqual 2 $ecmpRouteResult.NextHop.NextHopIpAddresses.Count
        Assert-AreEqual "10.0.0.1" $ecmpRouteResult.NextHop.NextHopIpAddresses[0]
        Assert-AreEqual "10.0.0.2" $ecmpRouteResult.NextHop.NextHopIpAddresses[1]

        # Verify regular route
        $regularRouteResult = $getRT | Get-AzRouteConfig -name "regularRoute"
        Assert-AreEqual "regularRoute" $regularRouteResult.Name
        Assert-AreEqual "VirtualAppliance" $regularRouteResult.NextHopType
        Assert-AreEqual "23.108.1.1" $regularRouteResult.NextHopIpAddress

        # Add another ECMP route using Add-AzRouteConfig
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName | Add-AzRouteConfig -name "ecmpRoute2" -AddressPrefix "10.0.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.1.1.1","10.1.1.2","10.1.1.3" | Set-AzRouteTable

        # Verify the added ECMP route
        Assert-AreEqual 3 @($getRT.Routes).Count
        $addedRoute = $getRT | Get-AzRouteConfig -name "ecmpRoute2"
        Assert-AreEqual "ecmpRoute2" $addedRoute.Name
        Assert-AreEqual "VirtualApplianceEcmp" $addedRoute.NextHopType
        Assert-AreEqual "10.0.0.0/16" $addedRoute.AddressPrefix
        Assert-NotNull $addedRoute.NextHop
        Assert-AreEqual 3 $addedRoute.NextHop.NextHopIpAddresses.Count
        Assert-AreEqual "10.1.1.1" $addedRoute.NextHop.NextHopIpAddresses[0]
        Assert-AreEqual "10.1.1.2" $addedRoute.NextHop.NextHopIpAddresses[1]
        Assert-AreEqual "10.1.1.3" $addedRoute.NextHop.NextHopIpAddresses[2]

        # Update ECMP route using Set-AzRouteConfig - change IP addresses
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName | Set-AzRouteConfig -name "ecmpRoute1" -AddressPrefix "192.168.1.0/24" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.2.2.1","10.2.2.2","10.2.2.3","10.2.2.4" | Set-AzRouteTable

        # Verify the updated route
        $updatedRoute = $getRT | Get-AzRouteConfig -name "ecmpRoute1"
        Assert-AreEqual "ecmpRoute1" $updatedRoute.Name
        Assert-AreEqual "VirtualApplianceEcmp" $updatedRoute.NextHopType
        Assert-NotNull $updatedRoute.NextHop
        Assert-AreEqual 4 $updatedRoute.NextHop.NextHopIpAddresses.Count
        Assert-AreEqual "10.2.2.1" $updatedRoute.NextHop.NextHopIpAddresses[0]
        Assert-AreEqual "10.2.2.4" $updatedRoute.NextHop.NextHopIpAddresses[3]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests RouteTableWithDisableBgpRoutePropagation.
#>
function Test-RouteTableWithDisableBgpRoutePropagation
{
    # Setup
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
        
        # Create RouteTable
        $rt = New-AzRouteTable -name $routeTableName -DisableBgpRoutePropagation -ResourceGroupName $rgname -Location $location

        # Get RouteTable
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgName
        
        #verification
        Assert-AreEqual $rgName $getRT.ResourceGroupName
        Assert-AreEqual $routeTableName $getRT.Name
		Assert-AreEqual true $getRt.DisableBGProutepropagation
        Assert-NotNull $getRT.Etag
        Assert-AreEqual 0 @($getRT.Routes).Count        

        # list
        $list = Get-AzRouteTable -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $getRT.ResourceGroupName
        Assert-AreEqual $list[0].Name $getRT.Name
        Assert-AreEqual $list[0].DisableBGProutepropagation $getRT.DisableBGProutepropagation
        Assert-AreEqual $list[0].Etag $getRT.Etag
        Assert-AreEqual @($list[0].Routes).Count @($getRT.Routes).Count
		
        # Delete RouteTable
        $delete = Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
        Assert-AreEqual true $delete
        
        $list = Get-AzRouteTable -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}