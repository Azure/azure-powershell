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
Test restarting an existing NetworkVirtualAppliance
#>
function Test-NetworkVirtualApplianceRestart
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "eastus2"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    $vendor = "ciscosdwan"
    $scaleunit = 20
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

        $restartnva = Restart-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
        Assert-AreEqual $restartnva.Status "Succeeded"
   	}   
    finally{
        # Clean up.
	}
}