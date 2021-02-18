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
GetLocationKindDirect 
#>
<<<<<<< HEAD
function Test-GetLocationKindDirect
{
    $location = Get-AzPeeringLocation -Kind Direct 
	Assert-NotNull $location
	Assert-True { $location.Count -gt 30}
=======
function Test-GetLocationKindDirect {
    try {
        $asn = (getRandomNumber)
        $asnPeerName = makePeerAsn $asn
        $location = Get-AzPeeringLocation -Kind Direct 
        Assert-NotNull $location
        Assert-True { $location.Count -gt 30 }
    }
    finally {
        Remove-AzPeerAsn -Name $asnPeerName -Force
    }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}
<#
.SYNOPSIS
GetLocationKindDirect
#>
<<<<<<< HEAD
function Test-GetLocationKindExchange
{
    $location = Get-AzPeeringLocation -Kind Exchange 
	Assert-NotNull $location
	Assert-True {$location.Count -gt 60}
=======
function Test-GetLocationKindExchange {
    try {
        $asn = (getRandomNumber)
        $asnPeerName = makePeerAsn $asn
        $location = Get-AzPeeringLocation -Kind Exchange 
        Assert-NotNull $location
        Assert-True { $location.Count -gt 60 }
    }
    finally {
        Remove-AzPeerAsn -Name $asnPeerName -Force
    }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}
<#
.SYNOPSIS
GetLocationKindExchangeSeattle
#>
<<<<<<< HEAD
function Test-GetLocationKindExchangeSeattle
{
    $location = Get-AzPeeringLocation -Kind Exchange -PeeringLocation seattle
	Assert-NotNull $location
	Assert-AreEqual 4 $location.Count
	Assert-AreEqual 11 $location[0].PeeringDBFacilityId
	Assert-AreEqual 13 $location[1].PeeringDBFacilityId
	Assert-AreEqual 1174 $location[2].PeeringDBFacilityId
	Assert-AreEqual 82 $location[3].PeeringDBFacilityId
=======
function Test-GetLocationKindExchangeSeattle {
    try {
        $asn = (getRandomNumber)
        $asnPeerName = makePeerAsn $asn
        $location = Get-AzPeeringLocation -Kind Exchange -PeeringLocation seattle
        Assert-NotNull $location
        Assert-AreEqual 5 $location.Count
    }
    finally {
        Remove-AzPeerAsn -Name $asnPeerName -Force
    }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}
<#
.SYNOPSIS
GetLocationKindDirectSeattle
#>
<<<<<<< HEAD
function Test-GetLocationKindDirectSeattle
{
    $location = Get-AzPeeringLocation -Kind Direct -PeeringLocation seattle
	Assert-NotNull $location
	Assert-AreEqual 1 $location.Count
	Assert-AreEqual 71 $location[0].PeeringDBFacilityId
}
=======
function Test-GetLocationKindDirectSeattle {
    try {
        $asn = (getRandomNumber)
        $asnPeerName = makePeerAsn $asn
        $location = Get-AzPeeringLocation -Kind Direct -DirectPeeringType Edge -PeeringLocation sea
        Assert-NotNull $location
		Assert-True { $location.Count -ge 2 }
    }
    finally {
        Remove-AzPeerAsn -Name $asnPeerName -Force
    }
}

<#
.SYNOPSIS
GetLocationKindDirectSeattle
#>
function Test-GetLocationKindDirectSeattle99999WithLocation {
    try {
        $asn = (getRandomNumber)
        $asnPeerName = makePeerAsn $asn
        $location = Get-AzPeeringLocation -Kind Direct -DirectPeeringType Edge -PeeringLocation sea -PeeringDbFacilityId  99999
        Assert-NotNull $location
		Assert-True { $location.Count -eq 1 }
    }
    finally {
        Remove-AzPeerAsn -Name $asnPeerName -Force
    }
}

<#
.SYNOPSIS
GetLocationKindDirectSeattle
#>
function Test-GetLocationKindDirectSeattle99999 {
    try {
        $asn = (getRandomNumber)
        $asnPeerName = makePeerAsn $asn
        $location = Get-AzPeeringLocation -Kind Direct -DirectPeeringType Edge -PeeringDbFacilityId  99999
        Assert-NotNull $location
		Assert-True { $location.Count -eq 1 }
    }
    finally {
        Remove-AzPeerAsn -Name $asnPeerName -Force
    }
}

<#
.SYNOPSIS
GetLocationKindDirectSeattle
#>
function Test-GetLocationKindDirectAmsterdam {
    try {
        $asn = (getRandomNumber)
        $asnPeerName = makePeerAsn $asn
        $location = Get-AzPeeringLocation -Kind Direct -DirectPeeringType Cdn -PeeringLocation Amsterdam
        Assert-NotNull $location
		Assert-True { $location.Count -ge 1 }
    }
    finally {
        Remove-AzPeerAsn -Name $asnPeerName -Force
    }
}
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
