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
    $peer = Get-AzPeering

	$setPeer = $peer | Set-AzPeeringDirectConnectionObject -UseForPeeringService | Set-AzPeering

	Assert-NotNull $setPeer
	Assert-True {$setPeer.UseForPeeringService -eq $true}
	Assert-True {$setPeer.Sku.Name -eq "Basic_Direct_Free"}
	#Assert-True {$setPeer.Sku.Name -eq "Premium_Direct_Free"}

	$setPeer = $peer | Set-AzPeeringDirectConnectionObject -UseForPeeringService | Set-AzPeering

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
	$ip = "192.168.1.4/31"
	$msip = "192.168.1.4"
	$sesip = "192.168.1.5"
    $peer = Get-AzPeering

	$setPeer = $peer | Set-AzPeeringDirectConnectionObject -ConnectionIndex 0 -SessionPrefixV4 $ip | Set-AzPeering

	Assert-NotNull $setPeer
	Assert-AreEqual $ip $setPeer.Connections[0].BgpSession.SessionPrefixV4
	Assert-AreEqual $msip $setPeer.Connections[0].BgpSession.PeerSessionIPv4Address
	Assert-AreEqual $sesip $setPeer.Connections[0].BgpSession.MicrosoftIPv4Address
}

<#
.SYNOPSIS
SetNewIPv6 
#>
function Test-SetNewIPv6
{
	$ip = "fe01::4/127"
	$msip = "fe01::4"
	$sesip = "fe01::4"
    $peer = Get-AzPeering

	$setPeer = $peer | Set-AzPeeringDirectConnectionObject -ConnectionIndex 0 -SessionPrefixV6 $ip | Set-AzPeering

	Assert-NotNull $setPeer
	Assert-AreEqual $ip $setPeer.Connections[0].BgpSession.SessionPrefixV6
	Assert-AreEqual $msip $setPeer.Connections[0].BgpSession.PeerSessionIPv6Address
	Assert-AreEqual $sesip $setPeer.Connections[0].BgpSession.MicrosoftIPv6Address
}

<#
.SYNOPSIS
SetNewBandwidth 
#>
function Test-SetNewBandwidth
{
	$bandwidth = 30000
    $peer = Get-AzPeering

	$setPeer = $peer | Set-AzPeeringDirectConnectionObject -ConnectionIndex 0 -BandwidthInMbps $bandwidth | Set-AzPeering

	Assert-NotNull $setPeer
	Assert-AreEqual $bandwidth $setPeer.Connections[0].BandwidthInMbps
}

<#
.SYNOPSIS
SetNewMd5Hash 
#>
function Test-SetNewMd5Hash
{
	$hash = "25234523452123411fd234qdwfas3234"
    $peer = Get-AzPeering

	$setPeer = $peer | Set-AzPeeringDirectConnectionObject -ConnectionIndex 0 -MD5AuthenticationKey $hash | Set-AzPeering

	Assert-NotNull $setPeer
	Assert-AreEqual $hash $setPeer.Connections[0].BgpSession.Md5AuthenticationKey
}