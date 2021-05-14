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
SetNewIP 
#>
function Test-SetNewIP {
    try {
        $peerAsn = makePeerAsn (getRandomNumber)
        $resourceGroups = TestSetup-CreateResourceGroup
        $resourceGroup = $resourceGroups.ResourceGroupName
        $peering = CreateExchangePeering $resourceGroup $peerAsn.Name
        $peer = Get-AzPeering -ResourceId $peering.Id
        $peerIpAddress = $peer.Connections[0].BgpSession.PeerSessionIPv4Address
        $offset = getPeeringVariable "offSet" (Get-Random -Maximum 10 -Minimum 1 | % { $_ * 2 } )
        $newIpAddress = getPeeringVariable "newIpAddress" (changeIp "$peerIpAddress/32" $false $offset $false )
        $peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $newIpAddress
        Assert-ThrowsContains { $peer | Update-AzPeering } "OperationNotSupported"
    }
    finally {
        Clean-Peering $peering.Id
        Clean-ASN $peerAsn.Name
        Clean-ResourceGroup $resourceGroup
    }
}
<#
    .SYNOPSIS
    SetNewIPv6 
    #>
function Test-SetNewIPv6 {
    try {
        $peerAsn = makePeerAsn (getRandomNumber)
        $resourceGroups = TestSetup-CreateResourceGroup
        $resourceGroup = $resourceGroups.ResourceGroupName
        $peering = CreateExchangePeering $resourceGroup $peerAsn.Name
        $peer = Get-AzPeering -ResourceId $peering.Id
        $peerIpAddress = getPeeringVariable "IpAddress" (newIpV6Address $false $false 0 0)
        $peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringExchangeConnectionObject -PeerSessionIPv6Address $peerIpAddress
        Assert-ThrowsContains { $peer | Update-AzPeering } "BadArgument"
    }
    finally {
        Clean-Peering $peering.Id
        Clean-ASN $peerAsn.Name
        Clean-ResourceGroup $resourceGroup
    }
}
<#
    .SYNOPSIS
    SetNewBandwidth 
    #>
function Test-SetNewBandwidth {
    try {
    $peering = (Get-AzPeering -Kind Direct)[0];
    $resourceGroup = (Get-AzResource -ResourceId $peering.Id).ResourceGroupName
    $peer = Get-AzPeering -ResourceId $peering.Id
    $bandwidth = $peer.Connections[0].BandwidthInMbps
    $bandwidth = getPeeringVariable "newBandwidth" (Get-Random -Maximum 2 -Minimum 1 | % { $_ * 10000 } | % { $_ + $bandwidth })
    $peer.Connections[0] = $peer.Connections[0] | Set-AzPeeringDirectConnectionObject -BandwidthInMbps $bandwidth 
    $setPeer = $peer | Update-AzPeering 

    Assert-NotNull $setPeer
        }
    catch {
    }
}
    
<#
    .SYNOPSIS
    SetNewMd5Hash 
    #>
function Test-SetNewMd5Hash {
    try {
        $peerAsn = makePeerAsn (getRandomNumber)
        $resourceGroups = TestSetup-CreateResourceGroup
        $resourceGroup = $resourceGroups.ResourceGroupName
        $peering = CreateExchangePeering $resourceGroup $peerAsn.Name
        $hash = getHash
        $connection = $peering.Connections[0] | Set-AzPeeringExchangeConnectionObject -MD5AuthenticationKey $hash
        Assert-ThrowsContains { $setPeer = Update-AzPeering -ResourceId $peering.Id -ExchangeConnection $connection } "ErrorCode"
    }
    finally {
        Clean-Peering $peering.Id
        Clean-ASN $peerAsn.Name
        Clean-ResourceGroup $resourceGroup
    }
}