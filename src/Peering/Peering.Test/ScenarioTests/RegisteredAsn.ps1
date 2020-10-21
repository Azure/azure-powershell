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
function Test-CreateRegisteredAsn {
    $peering = (Get-AzPeering -Kind Direct)[0];
    $resourceGroup = $peering[0].Id.Split("/")[4]
    Assert-NotNull $peering
    $name = getAssetName "name"
    $Asn = getRandomNumber
    Assert-ThrowsContains { $peering | New-AzPeeringRegisteredAsn -Name $name -Asn $Asn} "OperationNotSupported"
    Assert-ThrowsContains { New-AzPeeringRegisteredAsn -ResourceGroupName $resourceGroup -PeeringName $peering.Name -Name $name -Asn $Asn } "OperationNotSupported"
    Assert-ThrowsContains { New-AzPeeringRegisteredAsn -ResourceId $peering.Id -Name $name -Asn $Asn} "OperationNotSupported"
}

function Test-GetRegisteredAsn {
    $peering = (Get-AzPeering -Kind Direct)[0];
    $name = getAssetName
    $assetName = getAssetName "peering"
    $resourceGroup = $peering[0].Id.Split("/")[4]
    Assert-ThrowsContains { $peering | Get-AzPeeringRegisteredAsn -Name $name } "NotFound"
    Assert-ThrowsContains { Get-AzPeeringRegisteredAsn -ResourceId $peering.Id } "peeringName"
    Assert-ThrowsContains {Get-AzPeeringRegisteredAsn -ResourceGroupName $resourceGroup -PeeringName $assetName} "peering"
    Assert-ThrowsContains { Get-AzPeeringRegisteredAsn -ResourceGroupName $resourceGroup -PeeringName $assetName -Name $name } "NotFound"
    Assert-ThrowsContains { Get-AzPeeringRegisteredAsn -ResourceGroupName $resourceGroup -PeeringName $assetName -Name $name -ResourceId "asdfa" } "Parameter set cannot be resolved using the specified named parameters"
}