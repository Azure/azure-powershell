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
GetPeeringServiceProviders 
#>
function Test-CreateRegisteredPrefix {
    $randNum = getRandomNumber
    $assetName = getAssetName "peering"
    $resourceGroup = getAssetName "rg"
    $peering = (Get-AzPeering -Kind Direct)[0];
    $name = getAssetName "name"
    $prefix = newIpV4Address $true $false 0 $randNum
    $peeringPrefix = $peering | New-AzPeeringRegisteredPrefix -Name $name -Prefix $prefix
    Assert-NotNull $peeringPrefix 
    Assert-ThrowsContains { New-AzPeeringRegisteredPrefix -ResourceGroupName $resourceGroup -PeeringName $peering.Name -Name $name -Prefix $prefix } "NotFound"
    Assert-NotNull (New-AzPeeringRegisteredPrefix -ResourceId $peering.Id -Name $name -Prefix $prefix)
    Assert-ThrowsContains { $peering | New-AzPeeringRegisteredPrefix -Name $name -Prefix "prefix" } "Unrecognized routePrefix prefix"
}

function Test-GetRegisteredPrefix {
    $peering = (Get-AzPeering -Kind Direct)[0];
    $name = getAssetName
    $assetName = getAssetName "peering"
    $resourceGroup = getAssetName "rg"
    Assert-ThrowsContains { $peering | Get-AzPeeringRegisteredPrefix -Name $name } "NotFound"
    Assert-ThrowsContains { Get-AzPeeringRegisteredPrefix -ResourceId $peering.Id } "peeringName"
    Assert-Null (Get-AzPeeringRegisteredPrefix -ResourceGroupName $resourceGroup -PeeringName $assetName)
    Assert-ThrowsContains { Get-AzPeeringRegisteredPrefix -ResourceGroupName $resourceGroup -PeeringName $assetName -Name $name } "NotFound"
    Assert-ThrowsContains { Get-AzPeeringRegisteredPrefix -ResourceGroupName $resourceGroup -PeeringName $assetName -Name $name -ResourceId "asdfa" } "Parameter set cannot be resolved using the specified named parameters"
}