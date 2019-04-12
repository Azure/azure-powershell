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
function Test-GetAndSetUseForPeeringService
{
    $peers = Get-AzPeering 
	$peer = $peers | Select -First 1
	$setPeer = $peer | Update-AzPeering -UseForPeeringService $true
	Assert-NotNull $setPeer
	$setPeer = $peer | Update-AzPeering -UseForPeeringService $false
	Assert-NotNull $setPeer
	Assert-True {$setPeer.UseForPeeringService -eq $false}
	Assert-True {$setPeer.Sku.Name -eq "Basic_Direct_Free"}
}
<#
.SYNOPSIS
SetNewIP 
#>
function Test-SetNewIP
{
    $peers = Get-AzPeering
	$peer = $peers | Select -First 1
    $peerIpAddress = $peer.Connections[0].BgpSession.SessionPrefixV4
	$offset = Get-Random -Maximum 100 -Minimum 1 | % { $_ * 2 } | getPeeringVariable
	$newIpAddress = changeIp "$peerIpAddress" $false $offset $true 
	$peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringDirectConnectionObject -SessionPrefixV4 $ip
	$setPeer = $peer | Update-AzPeering
	Assert-NotNull $setPeer
	Assert-AreEqual $ip $setPeer.Connections[0].BgpSession.SessionPrefixV4
	Assert-AreEqual $msip $setPeer.Connections[0].BgpSession.PeerSessionIPv4Address
	Assert-AreEqual $sesip $setPeer.Connections[0].BgpSession.MicrosoftSessionIPv4Address
}
<#
.SYNOPSIS
SetNewIPv6 
#>
function Test-SetNewIPv6
{
    $peers = Get-AzPeering
	$peer = $peers | Select -First 1
    $peerIpAddress = $peer.Connections[0].BgpSession.SessionPrefixV4
	$offset = Get-Random -Maximum 100 -Minimum 1 | % { $_ * 2 } | getPeeringVariable
	$newIpAddress = changeIp "$peerIpAddress" $true $offset $true 
	$peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringDirectConnectionObject -SessionPrefixV6 $ip
	$setPeer = $peer | Update-AzPeering
	Assert-NotNull $setPeer
	Assert-AreEqual $ip $setPeer.Connections[0].BgpSession.SessionPrefixV6
	Assert-AreEqual $msip $setPeer.Connections[0].BgpSession.PeerSessionIPv6Address
	Assert-AreEqual $sesip $setPeer.Connections[0].BgpSession.MicrosoftSessionIPv6Address
}
<#
.SYNOPSIS
SetNewBandwidth 
#>
function Test-SetNewBandwidth
{
    $peers = Get-AzPeering
	$peer = $peers | Select -First 1
    $bandwidth = $peer.Connections[0].BgpSession.BandwidthInMbps
	$bandwidth = Get-Random -Maximum 2 -Minimum 1 | % { $_ * 10000 } | % {$_  + $bandwidth }
	$peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringDirectConnectionObject -BandwidthInMbps $bandwidth 
	$setPeer = $peer | Update-AzPeering
	Assert-NotNull $setPeer
	Assert-AreEqual $bandwidth $setPeer.Connections[0].BandwidthInMbps
}
<#
.SYNOPSIS
SetNewMd5Hash 
#>
function Test-SetNewMd5Hash
{
    $peers = Get-AzPeering
	$peer = $peers | Select -First 1
    $hash = getHash
	$peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringDirectConnectionObject -MD5AuthenticationKey $hash
	$setPeer = $peer | Update-AzPeering
	Assert-NotNull $setPeer
	Assert-AreEqual $hash $setPeer.Connections[0].BgpSession.Md5AuthenticationKey
}