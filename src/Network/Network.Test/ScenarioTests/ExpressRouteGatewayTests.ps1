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
ExpressRoute gateway traffic block preferences that may be configured by customers
#>
function Test-ExpressRouteGatewayForDifferentCustomerBlockTrafficPreferences
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vWanName = Get-ResourceName
    $vHubName = Get-ResourceName
    $gatewayName = Get-ResourceName

    # return
    $rname = Get-ResourceName
    $vnetName = Get-ResourceName
    $publicIpName = Get-ResourceName
    $vnetGatewayConfigName = Get-ResourceName
    $rglocation = "centraluseuap"
    $resourceTypeParent = "Microsoft.Network/virtualNetworkGateways"
    $location = "centraluseuap"

    try 
    {
        # Create the resource group
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create the virtual WAN
        $vwan = New-AzVirtualWan -ResourceGroupName $rgname -Name $vWanName -Location $rglocation

        # Create the virtual hub
        $hub = New-AzVirtualHub -ResourceGroupName $rgname -Name $vHubName -VirtualWan $vwan -AddressPrefix '10.0.0.0/16' -Location $rglocation

        # Create the ExpressRoute gateway
        $gateway = New-AzExpressRouteGateway -ResourceGroupName $rgname -Name $gatewayName -MinScaleUnits 1 -VirtualHub $hub

        # Update vnet-to-vWAN via property and pass it as input object
        $gateway.AllowNonVirtualWanTraffic = $true
        Set-AzExpressRouteGateway -InputObject $gateway
        $gateway = Get-AzExpressRouteGateway -ResourceGroupName $rgname -Name $gatewayName
        Assert-AreEqual $true $gateway.AllowNonVirtualWanTraffic

        $gateway.AllowNonVirtualWanTraffic = $false
        Set-AzExpressRouteGateway -InputObject $gateway
        $gateway = Get-AzExpressRouteGateway -ResourceGroupName $rgname -Name $gatewayName
        Assert-AreEqual $false $gateway.AllowNonVirtualWanTraffic

        # Update vnet-to-vWAN via cmdlet switch
        Set-AzExpressRouteGateway -ResourceGroupName $rgname -Name $gatewayName -AllowNonVirtualWanTraffic $true
        $gateway = Get-AzExpressRouteGateway -ResourceGroupName $rgname -Name $gatewayName
        Assert-AreEqual $true $gateway.AllowNonVirtualWanTraffic

        Set-AzExpressRouteGateway -ResourceGroupName $rgname -Name $gatewayName -AllowNonVirtualWanTraffic $false
        $gateway = Get-AzExpressRouteGateway -ResourceGroupName $rgname -Name $gatewayName
        Assert-AreEqual $false $gateway.AllowNonVirtualWanTraffic
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
} 