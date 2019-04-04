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
Helper Function NewExchangeConnectionV4V6 
#>
function NewExchangeConnectionV4V6($prefixv4, $prefixv6, $maxv4, $maxv6)
{
    $resourceName = "testTataEPV4V6"
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "26"

	$maxPrefixesAdvertisedIPv4 = $maxv4
	$maxPrefixesAdvertisedIPv6 = $maxv6
	$sessionv4 = "80.249.209." + $prefixv4
	$sessionv6 = "2001:7f8:1::a500:8075:" + $prefixv6

    $createdConnection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxPrefixesAdvertisedIPv4 -MaxPrefixesAdvertisedIPv6 $maxPrefixesAdvertisedIPv6 -PeerSessionIPv4Address $sessionv4 -PeerSessionIPv6Address $sessionv6 -MD5AuthenticationKey $md5
	return $createdConnection
}

<#
.SYNOPSIS
Helper Function NewExchangeConnectionV4V6 
#>
function NewExchangePeeringPipeTwoConnections
{
	$resourceName = "NewExchangePeeringPipeTwoConnections"
    $resourceGroup = "testCarrier"
    $peeringLocation = "Amsterdam"
    $profileSku = "Basic_Exchange_Free"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
	$asn = "/subscriptions/4445bf11-61c4-436f-a940-60194f8aca57/providers/Microsoft.Peering/peerAsns/Contoso"

	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "64"
	$maxPrefixesAdvertisedIPv4 = 23
	$maxPrefixesAdvertisedIPv6 = 45
	$sessionv4 = "80.249.209.22"
	$sessionv6 = "2001:7f8:1::a500:8075:22"

	$connection1 =NewExchangeConnectionV4V6 "22" "22" 23 45
	$connection2 = NewExchangeConnectionV4V6 "34" "34" 55 100

    $createdPeering = ,@( $connection1, $connection2  ) | New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -Tag $tags
	return $createdPeering
}

<#
.SYNOPSIS
Tests new Exchange Peering 
#>
function Test-NewExchangePeering()
{
	$resourceName = "NewExchangePeering"
    $resourceGroup = "testCarrier"
    $peeringLocation = "Amsterdam"
    $profileSku = "Basic_Exchange_Free"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
	$asn = "/subscriptions/4445bf11-61c4-436f-a940-60194f8aca57/providers/Microsoft.Peering/peerAsns/Contoso"

	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "26"
	$maxPrefixesAdvertisedIPv4 = 23
	$maxPrefixesAdvertisedIPv6 = 45
	$sessionv4 = "80.249.209.22"
	$sessionv6 = "2001:7f8:1::a500:8075:22"

	$connection1 =NewExchangeConnectionV4V6 "22" "22" 23 45
    $createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -ExchangeConnection $connection1 -Tag $tags

    Assert-AreEqual $md5 $createdPeering.Connections[0].BgpSession.Md5AuthenticationKey
    Assert-AreEqual $bandwidth $createdPeering.Connections[0].BandwidthInMbps 
	Assert-AreEqual $facilityId $createdPeering.Connections[0].PeeringDBFacilityId 
	Assert-AreEqual "Exchange" $createdPeering.Kind
    Assert-AreEqual $maxPrefixesAdvertisedIPv4 $createdPeering.Connections[0].BgpSession.MaxPrefixesAdvertisedV4
    Assert-AreEqual $maxPrefixesAdvertisedIPv6 $createdPeering.Connections[0].BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $sessionv4 $createdPeering.Connections[0].BgpSession.PeerSessionIPv4Address
    Assert-AreEqual $sessionv6 $createdPeering.Connections[0].BgpSession.PeerSessionIPv6Address
	Assert-AreEqual $resourceName $createdPeering.Name
	Assert-AreEqual $peeringLocation $createdPeering.PeeringLocation
	Assert-AreEqual $profileSku $createdPeering.Sku.Name
}

<#
.SYNOPSIS
Tests new Exchange Peering Pipe
#>
function Test-NewExchangePeeringPipe
{
	$resourceName = "NewExchangePeeringPipe"
    $resourceGroup = "testCarrier"
    $peeringLocation = "Amsterdam"
    $profileSku = "Basic_Exchange_Free"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
	$asn = "/subscriptions/4445bf11-61c4-436f-a940-60194f8aca57/providers/Microsoft.Peering/peerAsns/Contoso"

	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "26"
	$maxPrefixesAdvertisedIPv4 = 23
	$maxPrefixesAdvertisedIPv6 = 45
	$sessionv4 = "80.249.209.24"
	$sessionv6 = "2001:7f8:1::a500:8075:24"

    $createdPeering = @( NewExchangeConnectionV4V6 "24" "24" 23 45 ) | New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -Tag $tags	

    Assert-AreEqual $md5 $createdPeering.Connections[0].BgpSession.Md5AuthenticationKey
	Assert-AreEqual $facilityId $createdPeering.Connections[0].PeeringDBFacilityId 
	Assert-AreEqual "Exchange" $createdPeering.Kind
    Assert-AreEqual $maxPrefixesAdvertisedIPv4 $createdPeering.Connections[0].BgpSession.MaxPrefixesAdvertisedV4
    Assert-AreEqual $maxPrefixesAdvertisedIPv6 $createdPeering.Connections[0].BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $sessionv4 $createdPeering.Connections[0].BgpSession.PeerSessionIPv4Address
    Assert-AreEqual $sessionv6 $createdPeering.Connections[0].BgpSession.PeerSessionIPv6Address
	Assert-AreEqual $resourceName $createdPeering.Name
	Assert-AreEqual $peeringLocation $createdPeering.PeeringLocation
	Assert-AreEqual $profileSku $createdPeering.Sku.Name
}

<#
.SYNOPSIS
Tests new Exchange Peering Pipe Two Connections
#>
function Test-NewExchangePeeringPipeTwoConnections
{
	$resourceName = "NewExchangePeeringPipeTwoConnections"
    $resourceGroup = "testCarrier"
    $peeringLocation = "Amsterdam"
    $profileSku = "Basic_Exchange_Free"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
	$asn = "/subscriptions/4445bf11-61c4-436f-a940-60194f8aca57/providers/Microsoft.Peering/peerAsns/Contoso"

	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "26"
	$maxPrefixesAdvertisedIPv4 = 23
	$maxPrefixesAdvertisedIPv6 = 45
	$sessionv4 = "80.249.209.25"
	$sessionv6 = "2001:7f8:1::a500:8075:25"

	$connection1 =NewExchangeConnectionV4V6 "25" "25" 23 45
	$connection2 = NewExchangeConnectionV4V6 "34" "34" 55 100

    $createdPeering = ,@( $connection1, $connection2  ) | New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -Tag $tags
	

    Assert-AreEqual $md5 $createdPeering.Connections[0].BgpSession.Md5AuthenticationKey
	Assert-AreEqual $facilityId $createdPeering.Connections[0].PeeringDBFacilityId 
	Assert-AreEqual $maxPrefixesAdvertisedIPv4 $createdPeering.Connections[0].BgpSession.MaxPrefixesAdvertisedV4
    Assert-AreEqual $maxPrefixesAdvertisedIPv6 $createdPeering.Connections[0].BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $sessionv4 $createdPeering.Connections[0].BgpSession.PeerSessionIPv4Address
    Assert-AreEqual $sessionv6 $createdPeering.Connections[0].BgpSession.PeerSessionIPv6Address
	Assert-AreEqual $md5 $createdPeering.Connections[0].BgpSession.Md5AuthenticationKey
	
	Assert-AreEqual $connection2.PeeringDBFacilityId $createdPeering.Connections[1].PeeringDBFacilityId 
	Assert-NotNull $createdPeering.Connections[1].BgpSession
	Assert-AreEqual $connection2.BgpSession.MaxPrefixesAdvertisedV4 $createdPeering.Connections[1].BgpSession.MaxPrefixesAdvertisedV4
	Assert-AreEqual $connection2.BgpSession.MaxPrefixesAdvertisedv6 $createdPeering.Connections[1].BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $connection2.BgpSession.PeerSessionIPv4Address $createdPeering.Connections[1].BgpSession.PeerSessionIPv4Address
	Assert-AreEqual $connection2.BgpSession.PeerSessionIPv6Address $createdPeering.Connections[1].BgpSession.PeerSessionIPv6Address
	Assert-AreEqual "Exchange" $createdPeering.Kind
	Assert-AreEqual $resourceName $createdPeering.Name
	Assert-AreEqual $peeringLocation $createdPeering.PeeringLocation
	Assert-AreEqual $profileSku $createdPeering.Sku.Name
}

<#
.SYNOPSIS
NewDirectConnectionWithV4 with fail on wrong IP
#>
function Test-NewDirectConnectionWrongV4
{
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "64"
	$sessionv4 = "192.168.1.1/32"
	$bandwidth = 30000

	Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixIPv4 $sessionv4 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5} "Parameter name: Invalid Prefix: 192.168.1.1/32, must be either /30 or /31"
}

