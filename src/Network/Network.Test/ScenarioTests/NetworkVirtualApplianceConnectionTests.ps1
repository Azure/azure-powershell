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
Test creating new NetworkVirtualApplianceConnection
#>
function Test-NetworkVirtualApplianceConnectionGet
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "eastus2euap"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    $vendor = "ciscosdwan"
    $scaleunit = 2
    $version = 'latest'
    $asn = 65222
    $prefix = "10.0.0.0/16"
    try{
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location
        $sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
        Assert-NotNull $sku

        $wan = New-AzVirtualWan -ResourceGroupName $rgname -Name $wanname -Location $location
        $hub = New-AzVirtualHub -ResourceGroupName $rgname -Name $hubname -Location $location -VirtualWan $wan -AddressPrefix $prefix

        # Wait for Virtual Hub Routing State to become Provisioned or Failed
        while ($hub.RoutingState -eq "Provisioning")
        {
            Start-TestSleep -Seconds 30
            $hub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $hubname
        }
        Assert-AreEqual $hub.RoutingState "Provisioned"


        $nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo hi" 
        Assert-NotNull $nva
        
        $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
        Assert-NotNull $getnva
        

        $getNvaConnection = Get-AzNetworkVirtualApplianceConnection -VirtualAppliance $getnva
        Assert-NotNull $getNvaConnection
   	}   
    finally{
        # Clean up.
        Clean-ResourceGroup $rgname
	}
}

function Test-NetworkVirtualApplianceConnectionUpdate
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "centraluseuap"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    $vendor = "ciscosdwan"
    $scaleunit = 2
    $version = 'latest'
    $asn = 65222
    $prefix = "10.1.0.0/16"
    $routeMapName = "testRouteMap"
    try{
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location
        $sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
        Assert-NotNull $sku

        $wan = New-AzVirtualWan -ResourceGroupName $rgname -Name $wanname -Location $location
        $hub = New-AzVirtualHub -ResourceGroupName $rgname -Name $hubname -Location $location -VirtualWan $wan -AddressPrefix $prefix

        # Wait for Virtual Hub Routing State to become Provisioned or Failed
        while ($hub.RoutingState -eq "Provisioning")
        {
            Start-TestSleep -Seconds 30
            $hub = Get-AzVirtualHub -ResourceGroupName $rgName -Name $hubname
        }
        Assert-AreEqual $hub.RoutingState "Provisioned"


        $nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo hi" 
        Assert-NotNull $nva
        
        $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
        Assert-NotNull $getnva
        $oldRoutingConfig = $getnva.RoutingConfiguration
        
        $getNvaConnection = Get-AzNetworkVirtualApplianceConnection -VirtualAppliance $getnva
        Assert-NotNull $getNvaConnection 
        
        $rt = Get-AzVHubRouteTable -ResourceGroupName $rgname -VirtualHubName $hubname -Name "noneRouteTable"
        
        #RouteMAp
        $routeMapMatchCriterion = New-AzRouteMapRuleCriterion -MatchCondition "Equals" -AsPath @("12345")
		$routeMapAction = New-AzRouteMapRuleAction -Type "Drop"
		$routeMapRule = New-AzRouteMapRule -Name "rule" -MatchCriteria @($routeMapMatchCriterion) -RouteMapRuleAction @($routeMapAction) -NextStepIfMatched "Terminate"

		New-AzRouteMap -ResourceGroupName $rgName -VirtualHubName $hubname -Name $routeMapName -RouteMapRule @($routeMapRule)
		$routeMap = Get-AzRouteMap -ResourceGroupName $rgName -VirtualHubName $hubname -Name $routeMapName
		Assert-AreEqual $routeMap.Rules.Count 1

        $routingconfig = New-AzRoutingConfiguration -AssociatedRouteTable $rt.Id -Label @("none") -Id @($rt.Id) -InboundRouteMap $routeMap.Id

        Update-AzNetworkVirtualApplianceConnection -ResourceGroupName $rgname -VirtualApplianceName $nvaname -Name defaultConnection -RoutingConfiguration $routingconfig
        
        $updatedNvaConnection = Get-AzNetworkVirtualApplianceConnection -VirtualAppliance $getnva
        
        Assert-AreNotEqual $updatedNvaConnection.RoutingConfiguration $oldRoutingConfig 
        Assert-AreEqual $updatedNvaConnection.RoutingConfiguration.AssociatedRouteTable.Id $rt.Id
        Assert-AreEqual $updatedNvaConnection.RoutingConfiguration.PropagatedRouteTables.Ids[0].Id $rt.Id
        Assert-AreEqual $updatedNvaConnection.RoutingConfiguration.PropagatedRouteTables.Labels[0] "none"
        Assert-AreEqual $updatedNvaConnection.RoutingConfiguration.InboundRouteMap.Id $routeMap.Id

   	}   
    finally{
        # Clean up.
        Clean-ResourceGroup $rgname
	}
}
