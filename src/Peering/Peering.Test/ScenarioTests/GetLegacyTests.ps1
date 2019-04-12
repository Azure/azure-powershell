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
GetLocationKindExchange 
#>
function Test-GetLegacyKindExchangeAmsterdam
{
	try{
	$peer = makePeerAsn 15169
    $legacy = Get-AzLegacyPeering -Kind Exchange -PeeringLocation Amsterdam 
	Assert-NotNull $legacy
	Assert-True {$legacy.Count -ge 1}
	}
	finally
	{
	Remove-AzPeerAsn $peer.Name -Force
	}
}

<#
.SYNOPSIS
GetLocationKindDirect
#>
function Test-GetLegacyKindDirectAshburn
{
try{
	$peer = makePeerAsn 15169
    $legacy = Get-AzLegacyPeering -Kind Direct -PeeringLocation Ashburn 
	Assert-NotNull $legacy
	Assert-True {$legacy.Count -ge 1}
	}
	finally{
		Remove-AzPeerAsn $peer.Name -Force
	}
}

function makePeerAsn($asn)
{
#asn has to be hard coded because its unique and finite amoungst locations
	$asnId = $asn
	$asnPeerName = getAssetName "Global"
	$asnPeer = getAssetName 
	[string[]]$emails = "noc@$asnPeer.com","noc@$asnPeerName.com"
	$phone = getAssetName
	$created = New-AzPeerAsn -Name $asnPeerName -PeerName $asnPeer -PeerAsn $asnId -Email $emails -Phone $phone
	return $created
}
