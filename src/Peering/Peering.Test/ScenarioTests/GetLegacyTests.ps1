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
function Test-GetLegacyKindExchangeAshburn
{
<<<<<<< HEAD
    $legacy = Get-AzLegacyPeering -Kind Exchange -PeeringLocation Ashburn 
	Assert-NotNull $legacy
	Assert-True {$legacy.Count -ge 1}
=======
try{
#must be hard coded asn because they have legacy items.
	$peerAsn = makePeerAsn 15224;
    $legacy = Get-AzLegacyPeering -Kind Exchange -PeeringLocation Ashburn 
	Assert-NotNull $legacy
	Assert-True {$legacy.Count -ge 1}
	}finally {
			$isRemoved = Remove-AzPeerAsn -Name $peerAsn.Name -Force -PassThru
		Assert-True {$isRemoved}
	}
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}

<#
.SYNOPSIS
GetLocationKindDirect
#>
function Test-GetLegacyKindDirectAmsterdam
{
<<<<<<< HEAD
	$peerAsn = makePeerAsn 3257
    $legacy = Get-AzLegacyPeering -Kind Direct -PeeringLocation Amsterdam 
	Assert-NotNull $legacy
	Assert-True {$legacy.Count -ge 1}
}

function makePeerAsn($asn)
{
#asn has to be hard coded because its unique and finite amoungst locations
	$asnId = $asn
	$asnPeerName = getAssetName "Global"
	$asnPeer = getAssetName 
	[string[]]$emails = "noc@$asnPeer.com","noc@$asnPeerName.com"
	$phone = getAssetName
	New-AzPeerAsn -Name $asnPeerName -PeerName $asnPeer -PeerAsn $asnId -Email $emails -Phone $phone
	$created = Get-AzPeerAsn -Name $asnPeerName
	Assert-NotNull $created
	return $created
}
=======
try{
#must be hard coded asn because they have legacy items.
	$peerAsn = makePeerAsn 20940
    $legacy = Get-AzLegacyPeering -Kind Direct -PeeringLocation Amsterdam 
	Assert-NotNull $legacy
	Assert-True {$legacy.Count -ge 1}
	}
	finally {
		$isRemoved = Remove-AzPeerAsn -Name $peerAsn.Name -Force -PassThru
		Assert-True {$isRemoved}
	}
}

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
