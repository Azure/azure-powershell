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
    $resourceName = "testAkamaiEPV4V6"
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$maxPrefixesAdvertisedIPv4 = 23
	$maxPrefixesAdvertisedIPv6 = 45
	$PeerSessionIPv4Address = "192.168.1.22/32"
	$PeerSessionIPv6Address = "fe01::22/128"
    $resourceGroup = "testCarrier" #TestSetup-CreateResourceGroup
    $resourceLocation = "CentralUS"
    $profileSku = "Premium_Direct_Metered"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdConnection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxPrefixesAdvertisedIPv4 -MaxPrefixesAdvertisedIPv6 $maxPrefixesAdvertisedIPv6 -PeerSessionIPv4Address $PeerSessionIPv4Address -PeerSessionIPv6Address $PeerSessionIPv6Address -MD5AuthenticationKey $md5
	Get-AzPeerAsn
    Assert-AreEqual $md5 $createdConnection.BgpSession.Md5AuthenticationKey
    Assert-AreEqual $bandwidth $createdConnection.BandwidthInMbps 
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-AreEqual $maxPrefixesAdvertisedIPv4 $createdConnection.BgpSession.MaxPrefixesAdvertisedV4
    Assert-AreEqual $maxPrefixesAdvertisedIPv6 $createdConnection.BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $PeerSessionIPv4Address $createdConnection.BgpSession.PeerSessionIPv4Address
    Assert-AreEqual $PeerSessionIPv6Address $createdConnection.BgpSession.PeerSessionIPv6Address
}
<#
.SYNOPSIS
NewExchangeConnectionV4
#>
function Test-NewExchangeConnectionV4
{
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$maxPrefixesAdvertisedIPv4 = 23
	$PeerSessionIPv4Address = "192.168.1.22/32"
    $createdConnection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxPrefixesAdvertisedIPv4 -PeerSessionIPv4Address $PeerSessionIPv4Address -MD5AuthenticationKey $md5
	Get-AzPeerAsn
    Assert-AreEqual $md5 $createdConnection.BgpSession.Md5AuthenticationKey
    Assert-AreEqual $bandwidth $createdConnection.BandwidthInMbps 
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-AreEqual $maxPrefixesAdvertisedIPv4 $createdConnection.BgpSession.MaxPrefixesAdvertisedV4
    Assert-Null $createdConnection.BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $PeerSessionIPv4Address $createdConnection.BgpSession.PeerSessionIPv4Address
    Assert-Null $createdConnection.BgpSession.PeerSessionIPv6Address
}
<#
.SYNOPSIS
NewExchangeConnectionV6 
#>
function Test-NewExchangeConnectionV6
{
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$maxPrefixesAdvertisedIPv6 = 45
	$PeerSessionIPv6Address = "fe01::22/128"
    $createdConnection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv6 $maxPrefixesAdvertisedIPv6 -PeerSessionIPv6Address $PeerSessionIPv6Address -MD5AuthenticationKey $md5
	Get-AzPeerAsn
    Assert-AreEqual $md5 $createdConnection.BgpSession.Md5AuthenticationKey
    Assert-AreEqual $bandwidth $createdConnection.BandwidthInMbps 
	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
    Assert-Null $createdConnection.BgpSession.MaxPrefixesAdvertisedV4
    Assert-AreEqual $maxPrefixesAdvertisedIPv6 $createdConnection.BgpSession.MaxPrefixesAdvertisedv6
	Assert-Null $PeerSessionIPv4Address $createdConnection.BgpSession.PeerSessionIPv4Address
    Assert-AreEqual $PeerSessionIPv6Address $createdConnection.BgpSession.PeerSessionIPv6Address
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
	Get-AzPeerAsn
	Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixIPv4 $sessionv4 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5} "Parameter name: Invalid Prefix: 192.168.1.1/32, must be either /30 or /31"
}