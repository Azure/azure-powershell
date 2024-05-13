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

function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName
    Assert-NotNull $cmdletData
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") }
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") }
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.",""
    return $cmdletReturnTypes -contains $realReturnType
}

<#
.SYNOPSIS
Test creating new NetworkVirtualAppliance
#>
function Test-NetworkVirtualApplianceCRUD
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "eastus2"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    $vendor = "barracuda sdwan release"
    $scaleunit = 1
    $version = 'latest'
    $newasn = 1271
    $asn=1270
    $prefix = "10.0.0.0/16"
    try{
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location
        $sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
        Assert-NotNull $sku

        $wan = New-AzVirtualWan -ResourceGroupName $rgname -Name $wanname -Location $location
        $hub = New-AzVirtualHub -ResourceGroupName $rgname -Name $hubname -Location $location -VirtualWan $wan -AddressPrefix $prefix

        $ipConfig1 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig" -Primary $true
        $ipConfig2 = New-AzVirtualApplianceIpConfiguration -Name "publicnicipconfig-2" -Primary $false
        $nicConfig1 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PublicNic" -IpConfiguration $ipConfig1, $ipConfig2
        $ipConfig3 = New-AzVirtualApplianceIpConfiguration -Name "privatenicipconfig" -Primary $true
        $ipConfig4 = New-AzVirtualApplianceIpConfiguration -Name "privatenicipconfig-2" -Primary $false
        $nicConfig2 = New-AzVirtualApplianceNetworkInterfaceConfiguration -NicType "PrivateNic" -IpConfiguration $ipConfig3, $ipConfig4
        $networkProfile = New-AzVirtualApplianceNetworkProfile -NetworkInterfaceConfiguration $nicConfig1, $nicConfig2

        $nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo hi" -NetworkProfile $networkProfile

        Assert-NotNull $nva
        
        $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
        Assert-NotNull $getnva
        
        ## There is a bug in the update call in the nfvrp. The NfvRp team will record the powershell tests once fixed.
        # $updatednva = Update-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -VirtualApplianceAsn $newasn -Force
        # Assert-True { $updatednva.VirtualApplianceAsn -eq $newasn}

        $rmresult = Remove-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Force -PassThru
        Assert-True { $true }
   	}   
    finally{
        # Clean up.
        Clean-ResourceGroup $rgname
	}
}

<#
.SYNOPSIS
Test creating new VirtualApplianceSite
#>
function Test-VirtualApplianceSiteCRUD
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "eastus2"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $sitename = Get-ResourceName
    $resourceTypeParent = "Microsoft.Network/networkVirtualAppliance"
    $vendor = "barracuda sdwan release"
    $scaleunit = 1
    $version = 'latest'    
    $asn = 1270
    $prefix = "10.0.0.0/16"
    $siteprefix = "10.0.1.0/24"
    $newsiteprefix = "10.0.2.0/24"
    try{
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location $location
        $sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
        Assert-NotNull $sku

        $wan = New-AzVirtualWan -ResourceGroupName $rgname -Name $wanname -Location $location
        $hub = New-AzVirtualHub -ResourceGroupName $rgname -Name $hubname -Location $location -VirtualWan $wan -AddressPrefix $prefix
        $nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -VirtualHubId /subscriptions/5e1e8156-5dec-452a-bfe5-6b6e0947c27a/resourceGroups/sliceTestRG/providers/Microsoft.Network/virtualHubs/sliceHub -Sku $sku -CloudInitConfiguration "echo hi" 
        $getnva = Get-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname
        
        $o365Policy = New-AzOffice365PolicyProperty -Allow -Optimize
        $site = New-AzVirtualApplianceSite -Name $sitename -ResourceGroupName $rgname -AddressPrefix $siteprefix -O365Policy $o365Policy -NetworkVirtualApplianceId $getnva.Id
        $getsite = Get-AzVirtualApplianceSite -Name $sitename -ResourceGroupName $rgname -NetworkVirtualApplianceId $getnva.Id
        $setsite = Update-AzVirtualApplianceSite -Name $sitename -ResourceGroupName $rgname -NetworkVirtualApplianceId $getnva.Id -AddressPrefix $newsiteprefix -Force
        Remove-AzVirtualApplianceSite -Name $sitename -ResourceGroupName $rgname -NetworkVirtualApplianceId $getnva.Id -Force
        Remove-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Force
   	}   
    finally{
        # Clean up.
        Clean-ResourceGroup $rgname
	}
}


