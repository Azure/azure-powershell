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
    $peers = Get-AzPeering -Kind Direct
	$peer = $peers | Select -First 1
	$setPeer = $peer | Update-AzPeering -UseForPeeringService $true
	Assert-NotNull $setPeer
	Assert-True {$setPeer.UseForPeeringService -ne $false}
	Assert-True {$setPeer.Sku.Name -ne "Basic_Direct_Free"}
}
<#
.SYNOPSIS
SetNewIP 
#>
function Test-SetNewIP
{
    $peers = Get-AzPeering -Kind Direct
	$peer = $peers | Select -First 1
    $peerIpAddress = $peer.Connections[0].BgpSession.SessionPrefixV4
	$offset = getPeeringVariable "offSet" (Get-Random -Maximum 100 -Minimum 1 | % { $_ * 2 } )
	$newIpAddress = getPeeringVariable "newIpAddress" (changeIp "$peerIpAddress" $false $offset $true )
	$msip = getPeeringVariable "MicrosoftSessionIPv4Address" $peer.Connections[0].BgpSession.MicrosoftSessionIPv4Address
	$peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringDirectConnectionObject -SessionPrefixV4 $newIpAddress
	Assert-ThrowsContains {$peer | Update-AzPeering} "ErrorCode: OperationFailed ErrorMessage: Input prefix $newIpAddress"

}
<#
.SYNOPSIS
SetNewIPv6 
#>
function Test-SetNewIPv6
{
    $peers = Get-AzPeering -Kind Direct
	$peer = $peers | Select -First 1
    $peerIpAddress = $peer.Connections[0].BgpSession.SessionPrefixV6
	$offset = getPeeringVariable "offSet" (Get-Random -Maximum 100 -Minimum 1 | % { $_ * 2 } )
	$newIpAddress = getPeeringVariable "newIpAddress" (changeIp "$peerIpAddress" $true $offset $true )
	$msip = getPeeringVariable "MicrosoftSessionIPv6Address" $peer.Connections[0].BgpSession.MicrosoftSessionIPv6Address
	$peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringDirectConnectionObject -SessionPrefixV6 $newIpAddress
	Assert-ThrowsContains {$peer | Update-AzPeering} "ErrorCode: OperationFailed ErrorMessage: Input prefix $newIpAddress"
}
<#
.SYNOPSIS
SetNewBandwidth 
#>
function Test-SetNewBandwidth
{
    $peers = Get-AzPeering -Kind Direct
	$peer = $peers | Select -First 1
    $bandwidth = $peer.Connections[0].BandwidthInMbps
	$bandwidth = getPeeringVariable "newBandwidth" (Get-Random -Maximum 2 -Minimum 1 | % { $_ * 10000 } | % {$_  + $bandwidth })
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
    $peers = Get-AzPeering -Kind Direct
	$peer = $peers | Select -First 1
    $hash = getHash
	$peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringDirectConnectionObject -MD5AuthenticationKey $hash
	$setPeer = $peer | Update-AzPeering
	Assert-NotNull $setPeer
	Assert-AreEqual $hash $setPeer.Connections[0].BgpSession.Md5AuthenticationKey
}