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
	$asn = makePeerAsn 65000
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
	Assert-AreEqual $false $createdConnection.UseForPeeringService
	Assert-AreEqual "Peer" $createdConnection.SessionAddressProvider

		removePeerAsn $asn
	

}
<#
.SYNOPSIS
NewDirectConnectionWithV6 v6 should be null
#>
function Test-NewDirectConnectionWithV4
{
	$asn = makePeerAsn 65000
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
	Assert-AreEqual $false $createdConnection.UseForPeeringService
	Assert-AreEqual "Peer" $createdConnection.SessionAddressProvider

		removePeerAsn $asn
	
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 v4 should be Null
#>
function Test-NewDirectConnectionWithV6
{
	$asn = makePeerAsn 65000
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
	Assert-AreEqual $false $createdConnection.UseForPeeringService
	Assert-AreEqual "Peer" $createdConnection.SessionAddressProvider

		removePeerAsn $asn
	
}
<#
.SYNOPSIS
NewDirectConnectionNoSession should pass with null value
#>
function Test-NewDirectConnectionNoSession
{
	$asn = makePeerAsn 65000
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
    $createdConnection = New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -BandwidthInMbps $bandwidth -UseForPeeringService
    Assert-AreEqual $bandwidth $createdConnection.BandwidthInMbps 
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-Null $createdConnection.BgpSession
	Assert-AreEqual $true $createdConnection.UseForPeeringService
	Assert-AreEqual "Peer" $createdConnection.SessionAddressProvider

		removePeerAsn $asn
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 should fail with high BandwidthInMbps message
#>
function Test-NewDirectConnectionHighBandwidth
{
	$asn = makePeerAsn 65000
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Los Angeles"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	#Set up the wrong BandwidthInMbps
	$bandwidth = getBandwidth
	#Anything over 100000 will fail. 
	$bandwidth = [int]$bandwidth * 10
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

		removePeerAsn $asn
	
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 should fail with low BandwidthInMbps message
#>
function Test-NewDirectConnectionLowBandwidth
{
	$asn = makePeerAsn 65000
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

		removePeerAsn $asn
	
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 should fail with wrong IP
#>
function Test-NewDirectConnectionWrongV6
{
	$asn = makePeerAsn 65000
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

		removePeerAsn $asn
	
}
<#
.SYNOPSIS
NewDirectConnectionWithV4 with fail on wrong IP
#>
function Test-NewDirectConnectionWrongV4
{
	$asn = makePeerAsn 65000
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

		removePeerAsn $asn
	
}

<#
.SYNOPSIS
Microsoft Provided IP address 
#>
function Test-NewDirectConnectionWithMicrosoftIpProvidedAddress
{
	$asn = makePeerAsn 65000
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Los Angeles"
	$peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#Create some data for the object
	$bandwidth = getBandwidth
	Write-Debug "Creating Connection at $facilityId"
	#create Connection
    $createdConnection = New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -MicrosoftProvidedIPAddress -BandwidthInMbps $bandwidth -UseForPeeringService
    Assert-AreEqual $bandwidth $createdConnection.BandwidthInMbps 
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-AreEqual $null $createdConnection.BgpSession
    Assert-AreEqual $true $createdConnection.UseForPeeringService
	Assert-AreEqual "Microsoft" $createdConnection.SessionAddressProvider
	removePeerAsn $asn
	
}

<#
.SYNOPSIS
Microsoft Provided IP address 
#>
function Test-NewDirectConnectionWithNoPeeringFacility
{
$asn = makePeerAsn 65000
	Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDbFacilityId} "Missing an argument for parameter 'PeeringDBFacilityId'"
		removePeerAsn $asn
}

<#
.SYNOPSIS
NoBgpSession
#>
function Test-NewDirectConnectionWithNoBgpSession
{
	$asn = makePeerAsn 65000
	$peeringLocation = Get-AzPeeringLocation -Kind Direct
	$index = Get-Random -Maximum ($peeringLocation.Count -1) -Minimum 1
	$facilityId = $peeringLocation[$index].PeeringDBFacilityId
	$bandwidth = getBandwidth
	$connection = New-AzPeeringDirectConnectionObject -PeeringDBFacilityId $facilityId -BandwidthInMbps $bandwidth
	Assert-AreEqual $facilityId $connection.PeeringDBFacilityId
	Assert-AreEqual $bandwidth $connection.BandwidthInMbps
	Assert-AreEqual "Peer" $connection.SessionAddressProvider

		removePeerAsn $asn
	
}

<#
.SYNOPSIS
NoBgpSession
#>
function Test-NewDirectConnectionWithMicrosoftSession
{
	$asn = makePeerAsn 65000
	$peeringLocation = Get-AzPeeringLocation -Kind Direct
	$index = Get-Random -Maximum ($peeringLocation.Count -1) -Minimum 1
	$facilityId = $peeringLocation[$index].PeeringDBFacilityId
	$bandwidth = getBandwidth
	$connection = New-AzPeeringDirectConnectionObject -PeeringDBFacilityId $facilityId -BandwidthInMbps $bandwidth -MicrosoftProvidedIPAddress
	Assert-AreEqual $facilityId $connection.PeeringDBFacilityId
	Assert-AreEqual $bandwidth $connection.BandwidthInMbps
	Assert-AreEqual "Microsoft" $connection.SessionAddressProvider
	Assert-False {$connection.UseForPeeringService}

		removePeerAsn $asn
	
}
<#
.SYNOPSIS
NoBgpSession
#>
function Test-NewDirectConnectionWithMicrosoftSessionWithPeeringService
{
	$asn = makePeerAsn 65000
	$peeringLocation = Get-AzPeeringLocation -Kind Direct
	$index = Get-Random -Maximum ($peeringLocation.Count -1) -Minimum 1
	$facilityId = $peeringLocation[$index].PeeringDBFacilityId
	$bandwidth = getBandwidth
	$connection = New-AzPeeringDirectConnectionObject -PeeringDBFacilityId $facilityId -BandwidthInMbps $bandwidth -MicrosoftProvidedIPAddress -UseForPeeringService
	Assert-AreEqual $facilityId $connection.PeeringDBFacilityId
	Assert-AreEqual $bandwidth $connection.BandwidthInMbps
	Assert-AreEqual "Microsoft" $connection.SessionAddressProvider
	Assert-True {$connection.UseForPeeringService}

		removePeerAsn $asn
	
}

<#
.SYNOPSIS
NoBgpSession
#>
function Test-NewDirectConnectionWithMicrosoftSessionInvalidV4
{
	$asn = makePeerAsn 65000
	$peeringLocation = Get-AzPeeringLocation -Kind Direct
	$index = Get-Random -Maximum ($peeringLocation.Count -1) -Minimum 1
	$facilityId = $peeringLocation[$index].PeeringDBFacilityId
	$bandwidth = getBandwidth
	Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDBFacilityId $facilityId -BandwidthInMbps $bandwidth -SessionPrefixV4 4.4.4.4 -MicrosoftProvidedIPAddress} "Parameter set cannot be resolved using the specified named parameters"

		removePeerAsn $asn
	
}

<#
.SYNOPSIS
NoBgpSession
#>
function Test-NewDirectConnectionWithMicrosoftSessionInvalidV6
{
	$asn = makePeerAsn 65000
	$peeringLocation = Get-AzPeeringLocation -Kind Direct
	$index = Get-Random -Maximum ($peeringLocation.Count -1) -Minimum 1
	$facilityId = $peeringLocation[$index].PeeringDBFacilityId
	$bandwidth = getBandwidth
	Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDBFacilityId $facilityId -BandwidthInMbps $bandwidth -SessionPrefixV6 "fe01::40ef" -MicrosoftProvidedIPAddress} "Parameter set cannot be resolved using the specified named parameters"

		removePeerAsn $asn
	
}