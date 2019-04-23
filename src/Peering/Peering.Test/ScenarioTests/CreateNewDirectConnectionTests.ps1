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
NewDirectConnectionWithV4V6 
#>
function Test-NewDirectConnectionWithV4V6
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Los Angeles"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	$bandwidth = getBandwidth
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$sessionv4 = newIpV4Address $true $true 0 0
	$sessionv6 = newIpV6Address $true $true 0 0
	Write-Debug "Created IPs $sessionv4 $SessionPrefixV6"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
    $createdConnection = New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV4 $sessionv4 -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv4 $maxv4 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5
    Assert-AreEqual $md5 $createdConnection.BgpSession.Md5AuthenticationKey
    Assert-AreEqual $bandwidth $createdConnection.BandwidthInMbps 
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-AreEqual $sessionv4 $createdConnection.BgpSession.SessionPrefixV4
    Assert-AreEqual $sessionv6 $createdConnection.BgpSession.SessionPrefixV6
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 v6 should be null
#>
function Test-NewDirectConnectionWithV4
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Amsterdam"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	$bandwidth = getBandwidth
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$sessionv4 = newIpV4Address $true $true 0 0
	Write-Debug "Created IPs $sessionv4"
	$maxv4 = maxAdvertisedIpv4
	Write-Debug "Created maxAdvertised $maxv4"
	#create Connection
    $createdConnection = New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV4 $sessionv4 -MaxPrefixesAdvertisedIPv4 $maxv4 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5
	Get-AzPeerAsn
    Assert-AreEqual $md5 $createdConnection.BgpSession.Md5AuthenticationKey
    Assert-AreEqual $bandwidth $createdConnection.BandwidthInMbps 
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-AreEqual $sessionv4 $createdConnection.BgpSession.SessionPrefixV4
    Assert-Null $createdConnection.BgpSession.SessionPrefixV6
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 v4 should be Null
#>
function Test-NewDirectConnectionWithV6
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Los Angeles"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	$bandwidth = getBandwidth
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$sessionv6 = newIpV6Address $true $true 0 0
	Write-Debug "Created IPs $SessionPrefixV6"
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv6"
	#create Connection
    $createdConnection = New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5
    Assert-AreEqual $md5 $createdConnection.BgpSession.Md5AuthenticationKey
    Assert-AreEqual $bandwidth $createdConnection.BandwidthInMbps 
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-Null $createdConnection.BgpSession.SessionPrefixV4
    Assert-AreEqual $sessionv6 $createdConnection.BgpSession.SessionPrefixV6
}
<#
.SYNOPSIS
NewDirectConnectionNoSession should fail with null value
#>
function Test-NewDirectConnectionNoSession
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Ashburn"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	$bandwidth = getBandwidth
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$sessionv4 = newIpV4Address $true $true 0 0
	$sessionv6 = newIpV6Address $true $true 0 0
	Write-Debug "Created IPs $sessionv4 $SessionPrefixV6"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
	Assert-ThrowsContains { New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxv4 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5 } "Cannot process command because of one or more missing mandatory parameters: SessionPrefixV4."
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 should fail with high BandwidthInMbps message
#>
function Test-NewDirectConnectionHighBandwidth
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Los Angeles"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	#Set up the wrong BandwidthInMbps
	$bandwidth = getBandwidth
	#Anything over 100000 will fail. 
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$sessionv4 = newIpV4Address $true $true 0 0
	$sessionv6 = newIpV6Address $true $true 0 0
	Write-Debug "Created IPs $sessionv4 $SessionPrefixV6"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
	Assert-ThrowsContains { New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5 } "The $bandwidth argument is greater than the maximum allowed range of 100000"
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 should fail with low BandwidthInMbps message
#>
function Test-NewDirectConnectionLowBandwidth
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Ashburn"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	#Set up the wrong BandwidthInMbps
	$wrongBandwidth = 0
	#Anything less than 0 will fail.
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$sessionv4 = newIpV4Address $true $true 0 0
	$sessionv6 = newIpV6Address $true $true 0 0
	Write-Debug "Created IPs $sessionv4 $SessionPrefixV6"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
    Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $wrongBandwidth -MD5AuthenticationKey $md5} "The $wrongBandwidth argument is less than the minimum allowed range of 10000"
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 should fail with wrong IP
#>
function Test-NewDirectConnectionWrongV6
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Ashburn"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	$bandwidth = getBandwidth
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	#set up wrong IP address 
	$sessionv6 = newIpV6Address $true $true 0 0
	$wrongv6 = changeIp $sessionv6 $true 1 $true
	Write-Debug "Created IPs wrong $wrongv6 correct $sessionv6"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
	Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV6 $wrongv6 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5} "Invalid Prefix: $wrongv6, must be"
}
<#
.SYNOPSIS
NewDirectConnectionWithV4 with fail on wrong IP
#>
function Test-NewDirectConnectionWrongV4
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Ashburn"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	$bandwidth = getBandwidth
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	#set up wrong IP address 
	$sessionv4 = newIpV4Address $true $true 0 0
	$wrongv4 = changeIp $sessionv4 $false 1 $true
	Write-Debug "Created IPs wrong $wrongv4 correct $sessionv4"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
	Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV4 $wrongv4 -MaxPrefixesAdvertisedIPv4 $maxv4 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5.ToString} "Invalid Prefix: $wrongv4, must be "
}