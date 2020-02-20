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
function Test-ConvertLegacyKindExchangeAshburn {
    try {
        #must be hard coded asn because they have legacy items.
        $peerAsn = makePeerAsn 11164;
        $name = getPeeringVariable "Name" "AS11164_Ashburn_Exchange"
        $rg = getPeeringVariable "ResourceGroupName" "Building40"
        $legacy = Get-AzLegacyPeering -Kind Exchange -PeeringLocation Ashburn 
		Assert-NotNull $peerAsn.Id
        Assert-NotNull $legacy
        Assert-True { $legacy.Count -ge 1 }
        $peering = $legacy | New-AzPeering -ResourceGroupName $rg -Name $name -PeerAsnResourceId $peerAsn.Id -Tag @{ "tfs_813288" = "Approved" }
        $peering = Get-AzPeering -ResourceGroupName $rg -Name $name
        Assert-NotNull $peering
    }
    finally {
        $isRemoved = Remove-AzPeerAsn -Name $peerAsn.Name -Force -PassThru
        Assert-True { $isRemoved }
    }
}

<#
.SYNOPSIS
Convert Legacy Kind Exchange Amsterdam With New Connection
#>
function Test-ConvertLegacyKindExchangeAmsterdamWithNewConnection {
    try {
        #must be hard coded asn because they have legacy items.
        $peerAsn = makePeerAsn 15224
        $name = getPeeringVariable "Name" "AS15224_Amsterdam_Exchange"
        $rg = getPeeringVariable "ResourceGroupName" "Building40"
        $legacy = Get-AzLegacyPeering -Kind Exchange -PeeringLocation Amsterdam 
        Assert-NotNull $legacy
        Assert-True { $legacy.Count -ge 1 }
        #has to be hard coded becuase this ip address isnt used.
        #testing trim
        $ipaddress = getPeeringVariable "ipaddress" " 80.249.211.62 "
        $facilityId = 26
        $maxv4 = maxAdvertisedIpv4
        $connection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxv4 -PeerSessionIPv4Address $ipaddress
        $peering = $legacy | New-AzPeering -ResourceGroupName $rg -Name $name -PeerAsnResourceId $peerAsn.Id -ExchangeConnection $connection -Tag @{ "tfs_813288" = "Approved" }
    }
    finally {
        $isRemoved = Remove-AzPeerAsn -Name $peerAsn.Name -Force -PassThru
        Assert-True { $isRemoved }
    }
}

