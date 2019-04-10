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
function NewDirectConnectionV4V6($sessionPrefixv4,$sessionPrefixv6,$bandwidth)
{
    $resourceName = "testAkamaiEPV4V6"
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "64"
	$sessionv4 = "192.168.1." + $sessionPrefixv4
	$sessionv6 = "fe01::" + $sessionPrefixv6
	$maxv4 = 20000
	$maxv6 = 2000
    $resourceGroup = "testCarrier"
    $resourceLocation = "CentralUS"
    $profileSku = "Basic_Direct_Free"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdConnection = New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV4 $sessionv4 -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv4 $maxv4 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5
	return $createdConnection
}
<#
.SYNOPSIS
Tests new Direct Peering 
#>
function Test-NewDirectPeering
{
	$resourceName = "NewDirectPeering"
    $resourceGroup = "testCarrier"
    $peeringLocation = "Amsterdam"
    $profileSku = "Basic_Direct_Free"
	$asn = "/subscriptions/4445bf11-61c4-436f-a940-60194f8aca57/providers/Microsoft.Peering/peerAsns/Contoso"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "64"
	$sessionv4 = "192.168.1.0/31"
	$sessionv6 = "fe01::0/127"
	$bandwidth = 20000
	$directConnection = NewDirectConnectionV4V6 "0/31" "0/127" 20000
    $createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -DirectConnection $directConnection -Tag $tags
	Assert-AreEqual "Direct" $createdPeering.Kind
	Assert-AreEqual $resourceName $createdPeering.Name
	Assert-AreEqual $peeringLocation $createdPeering.PeeringLocation
	Assert-AreEqual $md5 $createdPeering.Connections[0].BgpSession.Md5AuthenticationKey
	Assert-AreEqual $facilityId $createdPeering.Connections[0].PeeringDBFacilityId 
    Assert-AreEqual $bandwidth $createdPeering.Connections[0].BandwidthInMbps
	Assert-AreEqual $sessionv4 $createdPeering.Connections[0].BgpSession.SessionPrefixV4
    Assert-AreEqual $sessionv6 $createdPeering.Connections[0].BgpSession.SessionPrefixV6
}
<#
.SYNOPSIS
Tests new Direct Peering With Pipe
#>
function Test-NewDirectPeeringWithPipe
{
	$resourceName = "NewDirectPeering"
    $resourceGroup = "testCarrier"
    $peeringLocation = "Amsterdam"
    $profileSku = "Basic_Direct_Free"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
	$asn = "/subscriptions/4445bf11-61c4-436f-a940-60194f8aca57/providers/Microsoft.Peering/peerAsns/Contoso"
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "64"
	$sessionv4 = "192.168.1.0/31"
	$sessionv6 = "fe01::0/127"
	$bandwidth = 20000
	$directConnection = NewDirectConnectionV4V6 "0/31" "0/127" 20000
    $createdPeering =  ($directConnection) | New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -Tag $tags
	Assert-AreEqual "Direct" $createdPeering.Kind
	Assert-AreEqual $resourceName $createdPeering.Name
	Assert-AreEqual $peeringLocation $createdPeering.PeeringLocation
	Assert-AreEqual $md5 $createdPeering.Connections[0].BgpSession.Md5AuthenticationKey
	Assert-AreEqual $facilityId $createdPeering.Connections[0].PeeringDBFacilityId 
    Assert-AreEqual $bandwidth $createdPeering.Connections[0].BandwidthInMbps
	Assert-AreEqual $sessionv4 $createdPeering.Connections[0].BgpSession.SessionPrefixV4
    Assert-AreEqual $sessionv6 $createdPeering.Connections[0].BgpSession.SessionPrefixV6
}
<#
.SYNOPSIS
Tests new Direct Peering Pipe Two Connections
#>
function Test-NewDirectPeeringPipeTwoConnections
{
	$resourceName = "NewDirectPeeringPipeTwoConnections"
    $resourceGroup = "testCarrier"
    $peeringLocation = "Amsterdam"
    $profileSku = "Basic_Direct_Free"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
	$asn = "/subscriptions/4445bf11-61c4-436f-a940-60194f8aca57/providers/Microsoft.Peering/peerAsns/Contoso"
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "64"
	$sessionv4 = "192.168.1.0/31"
	$sessionv6 = "fe01::0/127"
	$bandwidth = 20000
	$connection1 = NewDirectConnectionV4V6 "0/31" "0/127" 20000
	$connection2 =NewDirectConnectionV4V6 "2/31" "2/127" 30000
    $createdPeering = ,@( $connection1, $connection2  ) | New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -Tag $tags
	Assert-AreEqual "Direct" $createdPeering.Kind
	Assert-AreEqual $resourceName $createdPeering.Name
	Assert-AreEqual $peeringLocation $createdPeering.PeeringLocation
	Assert-AreEqual $md5 $createdPeering.Connections[0].BgpSession.Md5AuthenticationKey
	Assert-AreEqual $facilityId $createdPeering.Connections[0].PeeringDBFacilityId 
    Assert-AreEqual $bandwidth $createdPeering.Connections[0].BandwidthInMbps
	Assert-AreEqual $sessionv4 $createdPeering.Connections[0].BgpSession.SessionPrefixV4
    Assert-AreEqual $sessionv6 $createdPeering.Connections[0].BgpSession.SessionPrefixV6
	Assert-AreEqual $connection2.BgpSession.Md5AuthenticationKey $createdPeering.Connections[1].BgpSession.Md5AuthenticationKey
	Assert-AreEqual $connection2.PeeringDBFacilityId $createdPeering.Connections[1].PeeringDBFacilityId
	Assert-AreEqual $connection2.BandwidthInMbps $createdPeering.Connections[1].BandwidthInMbps
	Assert-NotNull $createdPeering.Connections[1].BgpSession
	Assert-AreEqual $connection2.BgpSession.SessionPrefixV4 $createdPeering.Connections[1].BgpSession.SessionPrefixV4
	Assert-AreEqual $connection2.BgpSession.SessionPrefixV6 $createdPeering.Connections[1].BgpSession.SessionPrefixV6
}