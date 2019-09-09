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
GetAndSetUseForPeeringService 
#>
function Test-GetAndSetUseForPeeringService {
    $peers = Get-AzPeering -Kind Direct
    $peer = $peers | Select-Object -First 1
    $setPeer = $peer | Update-AzPeering -UseForPeeringService $true
    Assert-NotNull $setPeer
    Assert-True { $setPeer.UseForPeeringService -ne $false }
    Assert-True { $setPeer.Sku.Name -ne "Basic_Direct_Free" }
}

<#
.SYNOPSIS
SetNewIP 
#>
function Test-SetNewIP {
    $peer = Get-AzPeering -Kind Exchange | Select-Object -First 1
    $peerIpAddress = $peer.Connections[1].BgpSession.PeerSessionIPv4Address
    $offset = getPeeringVariable "offSet" (Get-Random -Maximum 100 -Minimum 1 | % { $_ * 2 } )
    $newIpAddress = getPeeringVariable "newIpAddress" (changeIp "$peerIpAddress/32" $false $offset $false )
    $peer.Connections[1] = $peer.Connections[1] | Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $newIpAddress
    Assert-ThrowsContains { $peering = $peer | Update-AzPeering } "ErrorCode"

}
<#
.SYNOPSIS
SetNewIPv6 
#>
function Test-SetNewIPv6 {
    $peer = Get-AzPeering -Kind Exchange | Select-Object -First 1
    $peerIpAddress = getPeeringVariable "IpAddress" (newIpV6Address $false $false 0 0)
    $peer.Connections[1] = $peer.Connections[1] | Set-AzPeeringExchangeConnectionObject -PeerSessionIPv6Address $peerIpAddress
    Assert-ThrowsContains { $peering = $peer | Update-AzPeering } "ErrorCode"

}
<#
.SYNOPSIS
SetNewBandwidth 
#>
function Test-SetNewBandwidth {
    $peers = Get-AzPeering -Kind Direct
    $peer = $peers | Select-Object -First 1
    $bandwidth = $peer.Connections[0].BandwidthInMbps
    $bandwidth = getPeeringVariable "newBandwidth" (Get-Random -Maximum 2 -Minimum 1 | % { $_ * 10000 } | % { $_ + $bandwidth })
    $peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringDirectConnectionObject -BandwidthInMbps $bandwidth 
     Assert-ThrowsContains { $setPeer = $peer | Update-AzPeering } "ErrorCode"
}
<#
.SYNOPSIS
SetNewMd5Hash 
#>
function Test-SetNewMd5Hash {
    $peer = Get-AzPeering -Kind Exchange | Select-Object -First 1
    $hash = getHash
    $connection = $peer.Connections[0] | Set-AzPeeringExchangeConnectionObject -MD5AuthenticationKey $hash
    Assert-ThrowsContains { $setPeer = Update-AzPeering -ResourceId $peer.Id -ExchangeConnection $connection } "ErrorCode"
}