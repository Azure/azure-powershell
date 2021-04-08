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
function Test-ConvertLegacyKindExchangeDallas {
    try {
        #must be hard coded asn because they have legacy items.
        $peerAsn = makePeerAsn 42;
        $name = getPeeringVariable "Name" "AS42_Dallas_Exchange"
        $rg = getPeeringVariable "ResourceGroupName" "Building40"
        $legacy = Get-AzLegacyPeering -Kind Exchange -PeeringLocation Dallas 
		Assert-NotNull $peerAsn.Id
        Assert-NotNull $legacy
        Assert-True { $legacy.Count -ge 1 }
        $peering = $legacy | New-AzPeering -ResourceGroupName $rg -Name "AS42_Dallas_Exchange" -PeerAsnResourceId $peerAsn.Id -Tag @{ "tfs_813288" = "Approved" }
        $peering = Get-AzPeering -ResourceGroupName $rg -Name "AS42_Dallas_Exchange"
        Assert-NotNull $peering
    }
    finally {
        $isRemoved = Remove-AzPeerAsn -Name $peerAsn.Name -Force -PassThru
        Assert-True { $isRemoved }
    }
}

<#
.SYNOPSIS
Convert Legacy Kind Exchange Chicago With New Connection
#>
function Test-ConvertLegacyKindExchangeChicagoWithNewConnection {
    try {
        #must be hard coded asn because they have legacy items.
        $peerAsn = makePeerAsn 42
        $name = getPeeringVariable "Name" "AS42_Chicago_Exchange"
        $rg = getPeeringVariable "ResourceGroupName" "Building40"
        $legacy = Get-AzLegacyPeering -Kind Exchange -PeeringLocation Chicago 
        Assert-NotNull $legacy
        Assert-True { $legacy.Count -ge 1 }
        #has to be hard coded becuase this ip address isnt used.
        #testing trim
        $ipaddress = getPeeringVariable "ipaddress" " 206.41.110.42 "
        $facilityId = 26
        $maxv4 = maxAdvertisedIpv4
        $connection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxv4 -PeerSessionIPv4Address $ipaddress
        $peering = $legacy | New-AzPeering -ResourceGroupName $rg -Name $name -PeerAsnResourceId $peerAsn.Id
    }
    finally {
        $isRemoved = Remove-AzPeerAsn -Name $peerAsn.Name -Force -PassThru
        Assert-True { $isRemoved }
    }
}

