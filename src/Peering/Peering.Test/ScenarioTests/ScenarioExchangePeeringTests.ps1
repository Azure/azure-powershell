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
Helper New Asn Exchange
#>
function Test-UpdateExchangeIPv4OnInputObject {
    # Hard coded name because the resource has to exist and cant be created ad-hoc.
    $randNum = getRandomNumber
    Write-Debug "Random Number $randNum";
    $peerAsn = makePeerAsn $randNum
    $resourceGroups = TestSetup-CreateResourceGroup
    $resourceGroup = $resourceGroups.ResourceGroupName
    $peering = CreateExchangePeering $resourceGroup $peerAsn.Name
    Assert-NotNull $peering
    $ipv4 = $peering.Connections[0].BgpSession.PeerSessionIPv4Address
    $newipv4 = getPeeringVariable "newIpv4" (changeIp "$ipv4/32" $false 15 $false)
    $ipv42 = $peering.Connections[1].BgpSession.PeerSessionIPv4Address
    $newipv42 = getPeeringVariable "newIpv42" (changeIp "$ipv4/32" $false 17 $false)
    $oldpeering = $peering
    $peering.Connections[0] = $peering.Connections[0] | Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $newipv4
    $peering.Connections[1] = $peering.Connections[1] | Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $newipv42
    Write-Debug "ResourceId: $peering.Id" 
    Assert-ThrowsContains { $update = Update-AzPeering -ResourceId $peering.Id $peering.Connections } "BadArgument"
}
<#
.SYNOPSIS
Helper New Asn Exchange changeIp $ipv4 $false $offset $withPrefix
#>
function Test-UpdateExchangeIPv6OnResourceId {
    # Hard coded name because the resource has to exist and cant be created ad-hoc.
    $randNum = getRandomNumber
    Write-Debug "Random Number $randNum";
    $peerAsn = makePeerAsn $randNum
    $resourceGroups = TestSetup-CreateResourceGroup
    $resourceGroup = $resourceGroups.ResourceGroupName
    $peering = CreateExchangePeering $resourceGroup $peerAsn.Name
    Assert-NotNull $peering
    $newipv6 = getPeeringVariable "newIpv6" (newIpV6Address $true $false 0 (getRandomNumber))
    $oldpeering = $peering
    $peering.Connections[0] = $peering.Connections[0] | Set-AzPeeringExchangeConnectionObject -PeerSessionIPv6Address $newipv6 
    Write-Debug $peering.Name
    Assert-ThrowsContains { $update = Update-AzPeering -ResourceId $peering.Id $peering.Connections } "BadArgument"
}
<#
.SYNOPSIS
Helper Not supported
#>
function Test-UpdateExchangeMd5OnNameAndResourceGroup {
    $hash = getHash
    # Hard coded name because the resource has to exist and cant be created ad-hoc.
    $randNum = getRandomNumber
    Write-Debug "Random Number $randNum";
    $peerAsn = makePeerAsn $randNum
    $resourceGroups = TestSetup-CreateResourceGroup
    $resourceGroup = $resourceGroups.ResourceGroupName
    $peering = CreateExchangePeering $resourceGroup $peerAsn.Name
    Assert-NotNull $peering
    $resourceName = $peering.Name
    $oldpeering = $peering
    $peering = Get-AzPeering -ResourceId $peering.Id
    $peering.Connections[0] = $peering.Connections[0] | Set-AzPeeringExchangeConnectionObject -MD5AuthenticationKey $hash
    $peering.Connections[1] = $peering.Connections[1] | Set-AzPeeringExchangeConnectionObject -MD5AuthenticationKey $hash
    $update = $peering | Update-AzPeering 
    Assert-NotNull $update
}
