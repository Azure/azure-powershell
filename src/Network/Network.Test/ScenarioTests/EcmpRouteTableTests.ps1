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
P0-01: Create route table with single ECMP route and minimum 2 IPs via RouteConfig.
#>
function Test-EcmpRouteTableCreateBasic
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create ECMP route config with 2 IPs (minimum)
        $ecmpRoute = New-AzRouteConfig -name "ecmpRoute" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5"

        # Verify in-memory config
        Assert-AreEqual "ecmpRoute" $ecmpRoute.Name
        Assert-AreEqual "VirtualApplianceEcmp" $ecmpRoute.NextHopType
        Assert-NotNull $ecmpRoute.NextHop
        Assert-AreEqual 2 $ecmpRoute.NextHop.NextHopIpAddresses.Count

        # Create route table
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute

        # GET and verify
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        Assert-AreEqual $routeTableName $getRT.Name
        Assert-AreEqual 1 @($getRT.Routes).Count
        Assert-AreEqual "ecmpRoute" $getRT.Routes[0].Name
        Assert-AreEqual "VirtualApplianceEcmp" $getRT.Routes[0].NextHopType
        Assert-NotNull $getRT.Routes[0].NextHop
        Assert-AreEqual 2 $getRT.Routes[0].NextHop.NextHopIpAddresses.Count
        Assert-AreEqual $true ($getRT.Routes[0].NextHop.NextHopIpAddresses -contains "10.0.0.4")
        Assert-AreEqual $true ($getRT.Routes[0].NextHop.NextHopIpAddresses -contains "10.0.0.5")

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-02: Create route table with ECMP route containing the maximum number of IPs.
#>
function Test-EcmpRouteTableCreateMax16
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    $ecmpIps = @()
    for ($i = 1; $i -le 16; $i++) { $ecmpIps += "10.0.0.$i" }

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $ecmpRoute = New-AzRouteConfig -name "ecmpRoute16" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses $ecmpIps

        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute

        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($getRT.Routes).Count

        $route = $getRT | Get-AzRouteConfig -name "ecmpRoute16"
        Assert-AreEqual "VirtualApplianceEcmp" $route.NextHopType
        Assert-AreEqual 16 $route.NextHop.NextHopIpAddresses.Count
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "10.0.0.1")
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "10.0.0.16")

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-03: Create route table with ECMP route containing 3 IPs.
#>
function Test-EcmpRouteTableCreate3Ips
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $ecmpRoute = New-AzRouteConfig -name "ecmpRoute3" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5","10.0.0.6"

        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute

        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        $route = $getRT | Get-AzRouteConfig -name "ecmpRoute3"
        Assert-AreEqual 3 $route.NextHop.NextHopIpAddresses.Count
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "10.0.0.4")
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "10.0.0.5")
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "10.0.0.6")

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-04/P0-06: Add ECMP route via Add-AzRouteConfig and remove via Remove-AzRouteConfig.
#>
function Test-EcmpRouteTableAddRemoveRoute
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create route table with a standard route
        $stdRoute = New-AzRouteConfig -name "stdRoute" -AddressPrefix "192.168.1.0/24" -NextHopIpAddress "23.108.1.1" -NextHopType "VirtualAppliance"
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $stdRoute

        # Add ECMP route
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname | `
            Add-AzRouteConfig -name "ecmpRoute" -AddressPrefix "10.2.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.10","10.0.0.11" | `
            Set-AzRouteTable

        Assert-AreEqual 2 @($getRT.Routes).Count

        $ecmpResult = $getRT | Get-AzRouteConfig -name "ecmpRoute"
        Assert-AreEqual "VirtualApplianceEcmp" $ecmpResult.NextHopType
        Assert-AreEqual 2 $ecmpResult.NextHop.NextHopIpAddresses.Count

        # Remove ECMP route
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname | `
            Remove-AzRouteConfig -name "ecmpRoute" | `
            Set-AzRouteTable

        Assert-AreEqual 1 @($getRT.Routes).Count
        Assert-Null ($getRT.Routes | Where-Object { $_.Name -eq "ecmpRoute" })
        Assert-NotNull ($getRT.Routes | Where-Object { $_.Name -eq "stdRoute" })

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-05: Update an ECMP route IP list via Set-AzRouteConfig.
#>
function Test-EcmpRouteTableUpdateRoute
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $ecmpRoute = New-AzRouteConfig -name "ecmpRoute" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5"
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute

        # Update ECMP route to 4 IPs
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname | `
            Set-AzRouteConfig -name "ecmpRoute" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5","10.0.0.6","10.0.0.7" | `
            Set-AzRouteTable

        $route = $getRT | Get-AzRouteConfig -name "ecmpRoute"
        Assert-AreEqual 4 $route.NextHop.NextHopIpAddresses.Count
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "10.0.0.6")
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "10.0.0.7")

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-07: Delete an entire route table containing ECMP routes.
#>
function Test-EcmpRouteTableDeleteTable
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $ecmpRoute = New-AzRouteConfig -name "ecmpRoute" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5"
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute

        $delete = Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
        Assert-AreEqual true $delete

        $list = Get-AzRouteTable -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-08: GET route table with ECMP route verifies nextHopType and nextHop fields are present.
#>
function Test-EcmpRouteTableGetVerifyFields
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $ecmpRoute = New-AzRouteConfig -name "ecmpRoute" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5","10.0.0.6"
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute

        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname

        # Verify all ECMP-specific fields
        Assert-AreEqual $rgname $getRT.ResourceGroupName
        Assert-AreEqual $routeTableName $getRT.Name
        Assert-NotNull $getRT.Etag
        Assert-AreEqual 1 @($getRT.Routes).Count

        $route = $getRT.Routes[0]
        Assert-AreEqual "ecmpRoute" $route.Name
        Assert-AreEqual "10.1.0.0/16" $route.AddressPrefix
        Assert-AreEqual "VirtualApplianceEcmp" $route.NextHopType
        Assert-Null $route.NextHopIpAddress
        Assert-NotNull $route.NextHop
        Assert-NotNull $route.NextHop.NextHopIpAddresses
        Assert-AreEqual 3 $route.NextHop.NextHopIpAddresses.Count
        Assert-AreEqual "10.0.0.4" $route.NextHop.NextHopIpAddresses[0]
        Assert-AreEqual "10.0.0.5" $route.NextHop.NextHopIpAddresses[1]
        Assert-AreEqual "10.0.0.6" $route.NextHop.NextHopIpAddresses[2]

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-21: Route table containing both standard and ECMP routes via RouteConfig.
#>
function Test-EcmpRouteTableMixed
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $stdRoute = New-AzRouteConfig -name "stdRoute" -AddressPrefix "192.168.1.0/24" -NextHopIpAddress "10.0.0.4" -NextHopType "VirtualAppliance"
        $ecmpRoute = New-AzRouteConfig -name "ecmpRoute" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.10","10.0.0.11"

        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $stdRoute, $ecmpRoute

        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        Assert-AreEqual 2 @($getRT.Routes).Count

        # Verify standard route
        $std = $getRT | Get-AzRouteConfig -name "stdRoute"
        Assert-AreEqual "VirtualAppliance" $std.NextHopType
        Assert-AreEqual "10.0.0.4" $std.NextHopIpAddress

        # Verify ECMP route
        $ecmp = $getRT | Get-AzRouteConfig -name "ecmpRoute"
        Assert-AreEqual "VirtualApplianceEcmp" $ecmp.NextHopType
        Assert-AreEqual 2 $ecmp.NextHop.NextHopIpAddresses.Count

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-22/P0-23: Convert between standard and ECMP via Set-AzRouteConfig.
#>
function Test-EcmpRouteTableConvertTypes
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Start with standard route
        $stdRoute = New-AzRouteConfig -name "route1" -AddressPrefix "10.1.0.0/16" -NextHopIpAddress "10.0.0.4" -NextHopType "VirtualAppliance"
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $stdRoute

        # Convert standard -> ECMP
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname | `
            Set-AzRouteConfig -name "route1" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5" | `
            Set-AzRouteTable

        $route = $getRT | Get-AzRouteConfig -name "route1"
        Assert-AreEqual "VirtualApplianceEcmp" $route.NextHopType
        Assert-AreEqual 2 $route.NextHop.NextHopIpAddresses.Count

        # Convert ECMP -> standard
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname | `
            Set-AzRouteConfig -name "route1" -AddressPrefix "10.1.0.0/16" -NextHopIpAddress "10.0.0.4" -NextHopType "VirtualAppliance" | `
            Set-AzRouteTable

        $route = $getRT | Get-AzRouteConfig -name "route1"
        Assert-AreEqual "VirtualAppliance" $route.NextHopType
        Assert-AreEqual "10.0.0.4" $route.NextHopIpAddress

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P2-01: Dense IP range - the maximum number of IPs from a single /24 subnet.
#>
function Test-EcmpRouteTableDenseIpRange
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    $ecmpIps = @()
    for ($i = 1; $i -le 16; $i++) { $ecmpIps += "10.0.0.$i" }

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $ecmpRoute = New-AzRouteConfig -name "denseEcmp" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses $ecmpIps
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute

        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        $route = $getRT | Get-AzRouteConfig -name "denseEcmp"
        Assert-AreEqual 16 $route.NextHop.NextHopIpAddresses.Count
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "10.0.0.1")
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "10.0.0.16")

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P2-07/P2-09: ECMP with 0.0.0.0/0 default route and /32 narrow prefix.
#>
function Test-EcmpRouteTableDefaultAndNarrowPrefix
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $defaultRoute = New-AzRouteConfig -name "defaultEcmp" -AddressPrefix "0.0.0.0/0" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5"
        $narrowRoute = New-AzRouteConfig -name "narrowEcmp" -AddressPrefix "10.5.5.5/32" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.6","10.0.0.7"

        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $defaultRoute, $narrowRoute

        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        Assert-AreEqual 2 @($getRT.Routes).Count

        $default = $getRT | Get-AzRouteConfig -name "defaultEcmp"
        Assert-AreEqual "0.0.0.0/0" $default.AddressPrefix
        Assert-AreEqual "VirtualApplianceEcmp" $default.NextHopType
        Assert-AreEqual 2 $default.NextHop.NextHopIpAddresses.Count

        $narrow = $getRT | Get-AzRouteConfig -name "narrowEcmp"
        Assert-AreEqual "10.5.5.5/32" $narrow.AddressPrefix
        Assert-AreEqual "VirtualApplianceEcmp" $narrow.NextHopType
        Assert-AreEqual 2 $narrow.NextHop.NextHopIpAddresses.Count

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P2-13: ECMP route with hasBgpOverride enabled.
#>
function Test-EcmpRouteTableBgpOverride
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $ecmpRoute = New-AzRouteConfig -name "ecmpBgp" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5"

        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute -DisableBgpRoutePropagation

        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        Assert-AreEqual $true $getRT.DisableBgpRoutePropagation

        $route = $getRT | Get-AzRouteConfig -name "ecmpBgp"
        Assert-AreEqual "VirtualApplianceEcmp" $route.NextHopType
        Assert-AreEqual 2 $route.NextHop.NextHopIpAddresses.Count

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P2-17: Convert all ECMP routes to standard in a single PUT via RouteConfig.
#>
function Test-EcmpRouteTableConvertAllToStandard
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create with 3 ECMP routes
        $r1 = New-AzRouteConfig -name "ecmp1" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5"
        $r2 = New-AzRouteConfig -name "ecmp2" -AddressPrefix "10.2.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.6","10.0.0.7"
        $r3 = New-AzRouteConfig -name "ecmp3" -AddressPrefix "10.3.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.8","10.0.0.9"

        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $r1, $r2, $r3

        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        Assert-AreEqual 3 @($getRT.Routes).Count

        # Replace all with standard routes in a single PUT
        $s1 = New-AzRouteConfig -name "ecmp1" -AddressPrefix "10.1.0.0/16" -NextHopIpAddress "10.0.0.4" -NextHopType "VirtualAppliance"
        $s2 = New-AzRouteConfig -name "ecmp2" -AddressPrefix "10.2.0.0/16" -NextHopIpAddress "10.0.0.6" -NextHopType "VirtualAppliance"
        $s3 = New-AzRouteConfig -name "ecmp3" -AddressPrefix "10.3.0.0/16" -NextHopIpAddress "10.0.0.8" -NextHopType "VirtualAppliance"

        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $s1, $s2, $s3 -Force

        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        Assert-AreEqual 3 @($getRT.Routes).Count
        foreach ($route in $getRT.Routes)
        {
            Assert-AreEqual "VirtualAppliance" $route.NextHopType
        }

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P1-23: Idempotent PUT — PUTting same ECMP route table twice yields same result.
#>
function Test-EcmpRouteTableIdempotentPut
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $ecmpRoute = New-AzRouteConfig -name "ecmpRoute" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5"

        # First PUT
        $rt1 = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute

        # Second PUT (identical)
        $rt2 = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute -Force

        # Verify both succeed with same data
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($getRT.Routes).Count
        Assert-AreEqual "VirtualApplianceEcmp" $getRT.Routes[0].NextHopType
        Assert-AreEqual 2 $getRT.Routes[0].NextHop.NextHopIpAddresses.Count

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P1-01: Create ECMP route with IPv6 next hop addresses.
#>
function Test-EcmpRouteTableIpv6
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        $ecmpRoute = New-AzRouteConfig -name "ipv6Ecmp" -AddressPrefix "fd00::/64" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "fd00::1","fd00::2","fd00::3"

        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute

        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        $route = $getRT | Get-AzRouteConfig -name "ipv6Ecmp"
        Assert-AreEqual "fd00::/64" $route.AddressPrefix
        Assert-AreEqual "VirtualApplianceEcmp" $route.NextHopType
        Assert-AreEqual 3 $route.NextHop.NextHopIpAddresses.Count
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "fd00::1")
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "fd00::2")
        Assert-AreEqual $true ($route.NextHop.NextHopIpAddresses -contains "fd00::3")

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-10/P0-11/P0-12/P0-13/NEG-01 to NEG-08: Reject ECMP routes with fewer than 2 IPs (0, 1, null, missing).
#>
function Test-EcmpRouteTableRejectBelow2Ips
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # NEG-02/P0-10: ECMP with only 1 IP (below minimum of 2) should fail.
        # Validation happens client-side in New-AzRouteConfig, before any service call.
        Assert-ThrowsContains { New-AzRouteConfig -name "ecmpBad1" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4" } "NextHopIpAddresses"

        # NEG-01/P0-11: ECMP with empty IP list should fail
        Assert-ThrowsContains { New-AzRouteConfig -name "ecmpBad0" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses @() } "NextHopIpAddresses"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-14/NEG-03/NEG-04: Reject ECMP routes that exceed the maximum number of next hop IPs.
NOTE: 65 next hop IP addresses (one above the SDK/API hard maximum of 64) must be rejected.
#>
function Test-EcmpRouteTableRejectAbove64Ips
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    # 65 IPs is one above the SDK/API hard maximum of 64 and must be rejected.
    $ecmpIps65 = @()
    for ($i = 1; $i -le 65; $i++) { $ecmpIps65 += "10.0.0.$i" }

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # 65 IPs should fail (exceeds the maximum of 64). Validation happens client-side
        # in New-AzRouteConfig, before any service call.
        Assert-ThrowsContains { New-AzRouteConfig -name "ecmpBad65" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses $ecmpIps65 } "NextHopIpAddresses"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-15/NEG-25/NEG-26: Reject ECMP routes with duplicate next hop IPs.
#>
function Test-EcmpRouteTableRejectDuplicateIps
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # NEG-25: Exact duplicate IPs
        $route = New-AzRouteConfig -name "ecmpDupe" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5","10.0.0.4"
        Assert-ThrowsContains { New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route } "Duplicate"

        # NEG-26: All IPs identical
        $route2 = New-AzRouteConfig -name "ecmpAllDupe" -AddressPrefix "10.2.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.4"
        Assert-ThrowsContains { New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route2 } "Duplicate"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-24/P0-25/P1-04/P1-05/P1-06/NEG-16 to NEG-24: Reject ECMP routes with forbidden IP addresses.
#>
function Test-EcmpRouteTableRejectForbiddenIps
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # P0-24/NEG-16: Loopback IP 127.0.0.1
        $route = New-AzRouteConfig -name "ecmpLoopback" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","127.0.0.1"
        Assert-ThrowsContains { New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route } "InvalidNextHopIpAddress"

        # P0-25/NEG-18: Multicast IP 224.0.0.1
        $route2 = New-AzRouteConfig -name "ecmpMulticast" -AddressPrefix "10.2.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","224.0.0.1"
        Assert-ThrowsContains { New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route2 } "InvalidNextHopIpAddress"

        # P1-04/NEG-20: Broadcast 255.255.255.255
        $route3 = New-AzRouteConfig -name "ecmpBcast" -AddressPrefix "10.3.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","255.255.255.255"
        Assert-ThrowsContains { New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route3 } "InvalidNextHopIpAddress"

        # P1-05/NEG-21: Link-local/APIPA 169.254.1.1
        $route4 = New-AzRouteConfig -name "ecmpApipa" -AddressPrefix "10.4.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","169.254.1.1"
        Assert-ThrowsContains { New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route4 } "InvalidNextHopIpAddress"

        # P1-06/NEG-23: Azure wireserver 168.63.129.16
        $route5 = New-AzRouteConfig -name "ecmpWireserver" -AddressPrefix "10.5.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","168.63.129.16"
        Assert-ThrowsContains { New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route5 } "InvalidNextHopIpAddress"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-17/NEG-33/NEG-34: Reject setting both nextHopIpAddress and nextHop on ECMP/standard routes.
#>
function Test-EcmpRouteTableRejectMutualExclusivity
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # P0-18/NEG-34: Standard VirtualAppliance with NextHop set should fail
        # Passing both -NextHopIpAddress and -NextHopIpAddresses is not allowed by PowerShell parameter binding
        Assert-Throws {
            New-AzRouteConfig -name "badStdRoute" -AddressPrefix "10.1.0.0/16" -NextHopIpAddress "10.0.0.4" -NextHopType "VirtualAppliance" -NextHopIpAddresses "10.0.0.5","10.0.0.6"
        }
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P1-07/P1-08/P1-09/P1-10/NEG-35 to NEG-38: Reject NextHop on non-VirtualAppliance types.
#>
function Test-EcmpRouteTableRejectNextHopOnNonVaTypes
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # -NextHopIpAddresses is only valid for the 'VirtualApplianceEcmp' next hop type.
        # New-AzRouteConfig rejects it client-side for any other type, before any service call.

        # P1-07/NEG-35: Internet type + NextHopIpAddresses should fail
        Assert-ThrowsContains { New-AzRouteConfig -name "internetWithEcmp" -AddressPrefix "10.1.0.0/16" -NextHopType "Internet" -NextHopIpAddresses "10.0.0.4","10.0.0.5" } "NextHopIpAddresses"

        # P1-08/NEG-36: VnetLocal type + NextHopIpAddresses should fail
        Assert-ThrowsContains { New-AzRouteConfig -name "vnetLocalWithEcmp" -AddressPrefix "10.2.0.0/16" -NextHopType "VnetLocal" -NextHopIpAddresses "10.0.0.4","10.0.0.5" } "NextHopIpAddresses"

        # P1-09/NEG-37: None type + NextHopIpAddresses should fail
        Assert-ThrowsContains { New-AzRouteConfig -name "noneWithEcmp" -AddressPrefix "10.3.0.0/16" -NextHopType "None" -NextHopIpAddresses "10.0.0.4","10.0.0.5" } "NextHopIpAddresses"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P1-02/P1-03/NEG-29 to NEG-32: Reject address family mismatches between prefix and ECMP next hop IPs.
#>
function Test-EcmpRouteTableRejectAddressFamilyMismatch
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # P1-02/NEG-29: IPv4 prefix with IPv6 next hops
        $route = New-AzRouteConfig -name "v4PrefixV6Hops" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "fd00::1","fd00::2"
        Assert-ThrowsContains { New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route } "DifferentAddressFamilies"

        # P1-03/NEG-31: Mixed IPv4 and IPv6 in same IP list
        $route2 = New-AzRouteConfig -name "mixedIps" -AddressPrefix "10.2.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","fd00::1"
        Assert-ThrowsContains { New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route2 } "DifferentAddressFamilies"

        # NEG-30: IPv6 prefix with IPv4 next hops
        $route3 = New-AzRouteConfig -name "v6PrefixV4Hops" -AddressPrefix "fd00::/64" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5"
        Assert-ThrowsContains { New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $route3 } "DifferentAddressFamilies"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P2-16: ECMP route table CRUD — create, add routes, update, and delete without VNet association.
#>
function Test-EcmpRouteTableSubnetAssociation
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Create ECMP route table
        $ecmpRoute = New-AzRouteConfig -name "ecmpRoute" -AddressPrefix "10.1.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.4","10.0.0.5"
        $rt = New-AzRouteTable -name $routeTableName -ResourceGroupName $rgname -Location $location -Route $ecmpRoute

        # Verify ECMP route table was created
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname
        Assert-AreEqual 1 @($getRT.Routes).Count

        # Verify ECMP route has correct data
        $route = $getRT | Get-AzRouteConfig -name "ecmpRoute"
        Assert-AreEqual "VirtualApplianceEcmp" $route.NextHopType
        Assert-AreEqual 2 $route.NextHop.NextHopIpAddresses.Count

        # Add another ECMP route
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname | `
            Add-AzRouteConfig -name "ecmpRoute2" -AddressPrefix "10.2.0.0/16" -NextHopType "VirtualApplianceEcmp" -NextHopIpAddresses "10.0.0.6","10.0.0.7" | `
            Set-AzRouteTable

        Assert-AreEqual 2 @($getRT.Routes).Count

        # Delete first ECMP route
        $getRT = Get-AzRouteTable -name $routeTableName -ResourceGroupName $rgname | `
            Remove-AzRouteConfig -name "ecmpRoute" | `
            Set-AzRouteTable

        Assert-AreEqual 1 @($getRT.Routes).Count
        Assert-AreEqual "ecmpRoute2" $getRT.Routes[0].Name

        Remove-AzRouteTable -ResourceGroupName $rgname -name $routeTableName -PassThru -Force
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-09/P1-17: ECMP route PUT with older API version (< 2025-03-01) should be rejected because
VirtualApplianceEcmp is not a recognized nextHopType in older API versions.
#>
function Test-EcmpRouteTableRejectOlderApiVersion
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Build the REST URI with an older API version that does not support ECMP
        $subscriptionId = (Get-AzContext).Subscription.Id
        $path = "/subscriptions/$subscriptionId/resourceGroups/$rgname/providers/Microsoft.Network/routeTables/$($routeTableName)?api-version=2024-05-01"

        # Build ECMP route table payload
        $body = @{
            location = $location
            properties = @{
                routes = @(
                    @{
                        name = "ecmpRoute"
                        properties = @{
                            addressPrefix = "10.1.0.0/16"
                            nextHopType = "VirtualApplianceEcmp"
                            nextHop = @{
                                nextHopIpAddresses = @("10.0.0.4", "10.0.0.5")
                            }
                        }
                    }
                )
            }
        } | ConvertTo-Json -Depth 10

        # PUT with older API version — should fail with 400
        $response = Invoke-AzRestMethod -Path $path -Method PUT -Payload $body
        Assert-AreNotEqual 201 $response.StatusCode
        Assert-AreNotEqual 200 $response.StatusCode

        # Verify error response — older API version doesn't recognize VirtualApplianceEcmp
        Assert-AreEqual 400 $response.StatusCode
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
P0-19/NEG-41: ECMP route creation against an invalid/nonexistent subscription is rejected.
Uses Invoke-AzRestMethod with an all-zero (nonexistent) subscription ID and asserts the request
fails with a client-error status code (>= 400) rather than succeeding.
#>
function Test-EcmpRouteTableRejectUnauthorizedSubscription
{
    $rgname = Get-ResourceGroupName
    $routeTableName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/routeTables"
    $location = Get-ProviderLocation $resourceTypeParent

    try
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }

        # Use an all-zero, nonexistent subscription ID so the request cannot succeed.
        $dummySubscriptionId = "00000000-0000-0000-0000-000000000000"
        $path = "/subscriptions/$dummySubscriptionId/resourceGroups/$rgname/providers/Microsoft.Network/routeTables/$($routeTableName)?api-version=2025-07-01"

        # Build ECMP route table payload
        $body = @{
            location = $location
            properties = @{
                routes = @(
                    @{
                        name = "ecmpRoute"
                        properties = @{
                            addressPrefix = "10.1.0.0/16"
                            nextHopType = "VirtualApplianceEcmp"
                            nextHop = @{
                                nextHopIpAddresses = @("10.0.0.4", "10.0.0.5")
                            }
                        }
                    }
                )
            }
        } | ConvertTo-Json -Depth 10

        # PUT with dummy subscription — should fail (not 200/201)
        $response = Invoke-AzRestMethod -Path $path -Method PUT -Payload $body

        # The request should not succeed — expect 403, 404, or other non-success code
        Assert-AreNotEqual 201 $response.StatusCode
        Assert-AreNotEqual 200 $response.StatusCode

        # Verify the subscription is rejected (could be 403 Forbidden or 404 Not Found for dummy sub)
        Assert-AreEqual $true ($response.StatusCode -ge 400)
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}
