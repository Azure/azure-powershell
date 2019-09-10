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
NewExchangeConnectionV4V6 
#>
function Test-NewExchangeConnectionV4V6
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $false;
	$loc = "Los Angeles"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$sessionv4 = newIpV4Address $false $false 0 0
	$sessionv6 = newIpV6Address $false $false 0 0
	Write-Debug "Created IPs $sessionv4"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
    $createdConnection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxv4 -MaxPrefixesAdvertisedIPv6 $maxv6 -PeerSessionIPv4Address $sessionv4 -PeerSessionIPv6Address $sessionv6 -MD5AuthenticationKey $md5
	Assert-AreEqual $md5 $createdConnection.BgpSession.Md5AuthenticationKey
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-AreEqual $maxv4 $createdConnection.BgpSession.MaxPrefixesAdvertisedV4
    Assert-AreEqual $maxv6 $createdConnection.BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $sessionv4 $createdConnection.BgpSession.PeerSessionIPv4Address
    Assert-AreEqual $sessionv6 $createdConnection.BgpSession.PeerSessionIPv6Address
}
<#
.SYNOPSIS
NewExchangeConnectionV4
#>
function Test-NewExchangeConnectionV4
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $false;
	$loc = "Los Angeles"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$sessionv4 = newIpV4Address $false $false 0 0
	$sessionv6 = $null
	Write-Debug "Created IPs $sessionv4"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = $null
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
    $createdConnection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxv4 -PeerSessionIPv4Address $sessionv4 -MD5AuthenticationKey $md5
	Assert-AreEqual $md5 $createdConnection.BgpSession.Md5AuthenticationKey
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-AreEqual $maxv4 $createdConnection.BgpSession.MaxPrefixesAdvertisedV4
    Assert-AreEqual $maxv6 $createdConnection.BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $sessionv4 $createdConnection.BgpSession.PeerSessionIPv4Address
    Assert-AreEqual $sessionv6 $createdConnection.BgpSession.PeerSessionIPv6Address
}
<#
.SYNOPSIS
NewExchangeConnectionV6 
#>
function Test-NewExchangeConnectionV6
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $false;
	$loc = "Los Angeles"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$sessionv6 = newIpV6Address $false $false 0 0
	Write-Debug "Created IPs $sessionv4"
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
    $createdConnection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv6 $maxv6 -PeerSessionIPv6Address $sessionv6 -MD5AuthenticationKey $md5
	Assert-AreEqual $md5 $createdConnection.BgpSession.Md5AuthenticationKey
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-AreEqual $null $createdConnection.BgpSession.MaxPrefixesAdvertisedV4
    Assert-AreEqual $maxv6 $createdConnection.BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $null $createdConnection.BgpSession.PeerSessionIPv4Address
    Assert-AreEqual $sessionv6 $createdConnection.BgpSession.PeerSessionIPv6Address
}
<#
.SYNOPSIS
NewDirectConnectionWithV4 with fail on wrong IP
#>
function Test-NewExchangeConnectionWrongV4
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $false;
	$loc = "Los Angeles"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$sessionv4 = newIpV4Address $false $false 0 0
	$sessionv6 = newIpV6Address $false $false 0 0
	Write-Debug "Created IPs $sessionv4"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
	Assert-ThrowsContains {New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxv4 -MaxPrefixesAdvertisedIPv6 $maxv6 -PeerSessionIPv4Address $sessionv4 -PeerSessionIPv6Address $sessionv6 -MD5AuthenticationKey $md5} "Parameter name: Invalid Prefix"
}