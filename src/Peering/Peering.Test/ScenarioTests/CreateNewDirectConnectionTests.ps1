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
    $resourceName = "testAkamaiEPV4V6"
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$sessionv4 = "192.168.1.0/31"
	$sessionv6 = "fe01::0/127"
	$maxv4 = 20000
	$maxv6 = 2000
	$bandwidth = 30000
    $resourceGroup = "testCarrier" #TestSetup-CreateResourceGroup
    $resourceLocation = "CentralUS"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdConnection = New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV4 $sessionv4 -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv4 $maxv4 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5
	Get-AzPeerAsn
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
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$sessionv4 = "192.168.1.0/31"
	$bandwidth = 30000
	$maxv4 = 20000
	$maxv6 = 2000
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
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$sessionv6 = "fe01::0/127"
	$bandwidth = 30000
	$maxv4 = 20000
	$maxv6 = 2000
	Get-AzPeerAsn
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
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$bandwidth = 20000
	$maxv4 = 20000
	$maxv6 = 2000
	Get-AzPeerAsn
	Assert-ThrowsContains { New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxv4 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5 } "Cannot process command because of one or more missing mandatory parameters: SessionPrefixV4."
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 should fail with high BandwidthInMbps message
#>
function Test-NewDirectConnectionHighBandwidth
{
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$sessionv6 = "fe01::0/127"
	$bandwidth = 300000
	$maxv4 = 20000
	$maxv6 = 2000
	Get-AzPeerAsn
	Assert-ThrowsContains { New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5 } "The 300000 argument is greater than the maximum allowed range of 100000"
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 should fail with low BandwidthInMbps message
#>
function Test-NewDirectConnectionLowBandwidth
{
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$sessionv6 = "fe01::0/127"
	$bandwidth = 0
	$maxv4 = 20000
	$maxv6 = 2000
	Get-AzPeerAsn
    Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5} "The 0 argument is less than the minimum allowed range of 10000"
}
<#
.SYNOPSIS
NewDirectConnectionWithV6 should fail with wrong IP
#>
function Test-NewDirectConnectionWrongV6
{
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$sessionv6 = "fe01::1/128"
	$bandwidth = 20000
		$maxv4 = 20000
	$maxv6 = 2000
	Get-AzPeerAsn
	Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5} 'Specified argument was out of the range of valid values'
}
<#
.SYNOPSIS
NewDirectConnectionWithV4 with fail on wrong IP
#>
function Test-NewDirectConnectionWrongV4
{
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$sessionv4 = "192.168.1.1/32"
	$bandwidth = 30000
	$maxv4 = 20000
	$maxv6 = 2000
	Get-AzPeerAsn
	Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV4 $sessionv4 -MaxPrefixesAdvertisedIPv4 $maxv4 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5} "Parameter name: Invalid Prefix: 192.168.1.1/32, must be either /30 or /31"
}