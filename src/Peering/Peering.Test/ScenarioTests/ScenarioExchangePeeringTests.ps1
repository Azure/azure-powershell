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
Helper Get Asn Exchange
#>
function GetAsnExchange($name)
{
return Get-AzPeerAsn $name
}
<#
.SYNOPSIS
Helper New Asn Exchange
#>
function NewAsnExchange
{
$name = "Contoso"
$peerName = "Microscript"
$asn = 15224 
$email = "noc@contoso.com"
$phone = "899-888-9989"
New-AzPeerAsn -Name $name -PeerName $peerName -PeerAsn $asn -Email $email -Phone $phone
}
<#
.SYNOPSIS
Helper New Asn Exchange
#>
function Test-RemoveAsnExchange
{
Get-AzPeerAsn | Remove-AzPeerAsn -Force
}
function Test-Asn {
$name = "Contoso"
$peerName = "Microscript"
$asn = 15224 
$email = "noc@contoso.com"
$phone = "899-888-9989"
NewAsnExchange
$peer = GetAsnExchange $name
Assert-NotNull $peer
Assert-AreEqual $peer.Name $name
Assert-AreEqual $peer.PeerName $peerName
Assert-AreEqual $peer.PeerAsnProperty $asn
Assert-AreEqual $peer.PeerContactInfo.Emails $email
Assert-AreEqual $peer.PeerContactInfo.Phone $phone
$email2 = "noc1@microscript.com"
$peer = $peer | Set-AzPeerAsn -Email $email2
Assert-AreEqual $email2 $peer.PeerContactInfo.Emails[1]
}
<#
.SYNOPSIS
Helper Get Legavy
#>
function Test-GetLegacyPeering($location)
{
$legacy = Get-AzLegacyPeering -PeeringLocation $location -Kind Exchange
return $legacy
}
<#
.SYNOPSIS
Convert Legacy Exchange to New Peering
#>
function Test-ConvertLegacyExchangeNewPeering
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $false;
	$loc = "Seattle"
	$resourceGroup = "testCarrier"
	#asn has to be hard coded because its unique and finite amoungst locations
	$asnId = 11164
	$resourceName = getAssetName "LegacyConvertDirect"
	$asnPeerName = getAssetName "PeerName"
	$asnPeer = "Contoso"
	$email = "noc@$asnPeer.com"
	$phone = getAssetName
	New-AzPeerAsn -Name $asnPeerName -PeerName $asnPeer -PeerAsn $asnId -Email $email -Phone $phone
	#the ASN has to be "Approved" by admins prior to this call. 
	$asn = Get-AzPeerAsn $asnPeerName
	Assert-NotNull $asn
	try{
	Assert-AreEqual "Approved" $asn.ValidationState
    $legacy = Get-AzLegacyPeering -Kind $kind -PeeringLocation $loc  
	Assert-NotNull $legacy
	$legacy | New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $legacy.PeeringLocation -PeerAsnResourceId $asn.Id 
	$newPeering = Get-AzPeering -ResourceGroupName testCarrier -Name $resourceName
	Assert-NotNull $newPeering
	#Assert-AreEqual $legacy.
	#Assert-AreEqual $resourceName $newPeering.Name
	}
	finally{
		Remove-AzPeerAsn -Name $asnPeerName -Force
		}
}
<#
.SYNOPSIS
Helper New Asn Exchange
#>
function Test-ConvertLegacyToExchange
{
	$name = "Contoso"
	$resourceName = "NewContosoAmsterdamExchangePeering"
	$resourceGroup = "testCarrier"
	$peeringLocation = "Amsterdam"
	$profileSku = "Basic_Exchange_Free"
	$asn = GetAsnExchange $name
	$legacy = Test-GetLegacyPeering $peeringLocation
	$peering = Get-AzLegacyPeering -PeeringLocation $peeringLocation -Kind Exchange | New-AzPeering -ResourceGroupName $resourceGroup -Name $resourceName -PeeringLocation $peeringLocation -PeerAsnResourceId $asn.Id
	$legacyAfter = Get-AzLegacyPeering -PeeringLocation $peeringLocation -Kind Exchange
	Assert-AreEqual $legacy.Exchange.Connections[0].BgpSession.Md5AuthenticationKey $peering.Connections[0].BgpSession.Md5AuthenticationKey
	Assert-AreEqual $legacy.Exchange.Connections[0].PeeringDBFacilityId $peering.Connections[0].PeeringDBFacilityId 
	Assert-AreEqual $legacy.Exchange.Connections[0].BgpSession.MaxPrefixesAdvertisedV4 $peering.Connections[0].BgpSession.MaxPrefixesAdvertisedV4
    Assert-AreEqual $legacy.Exchange.Connections[0].BgpSession.MaxPrefixesAdvertisedV6 $peering.Connections[0].BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $legacy.Exchange.Connections[0].BgpSession.PeerSessionIPv4Address $peering.Connections[0].BgpSession.PeerSessionIPv4Address
    Assert-AreEqual $legacy.Exchange.Connections[0].BgpSession.PeerSessionIPv6Address $peering.Connections[0].BgpSession.PeerSessionIPv6Address
	Assert-AreEqual $legacy.Exchange.Connections[1].PeeringDBFacilityId     $peering.Connections[1].PeeringDBFacilityId 
	Assert-NotNull $peering.Connections[1].BgpSession
	Assert-AreEqual $legacy.Exchange.Connections[1].BgpSession.MaxPrefixesAdvertisedV4 $peering.Connections[1].BgpSession.MaxPrefixesAdvertisedV4
	Assert-AreEqual $legacy.Exchange.Connections[1].BgpSession.MaxPrefixesAdvertisedV6 $peering.Connections[1].BgpSession.MaxPrefixesAdvertisedv6
	Assert-AreEqual $legacy.Exchange.Connections[1].BgpSession.PeerSessionIPv4Address  $peering.Connections[1].BgpSession.PeerSessionIPv4Address
	Assert-AreEqual $legacy.Exchange.Connections[1].BgpSession.PeerSessionIPv6Address  $peering.Connections[1].BgpSession.PeerSessionIPv6Address
	Assert-AreEqual $legacy.Exchange.Connections[1].BgpSession.Md5AuthenticationKey    $peering.Connections[1].BgpSession.Md5AuthenticationKey
	Assert-AreEqual "Exchange" $peering.Kind
	Assert-AreEqual $resourceName $peering.Name
	Assert-AreEqual $peeringLocation $peering.PeeringLocation
	Assert-AreEqual $profileSku $peering.Sku.Name
	Assert-Null $legacyAfter
}
<#
.SYNOPSIS
Helper New Asn Exchange
#>
function Test-UpdateExchangeIPv4OnResourceId
{
	$resourceName = "NewContosoAmsterdamExchangePeering"
	$resourceGroup = "testCarrier"
	$ipv4 = "80.249.208.57"
	$maxv4 = 19990
	$ipv42 = "80.249.211.55"
	$maxv42 = 19990
	$peering = Get-AzPeering $resourceGroup $resourceName
	Assert-NotNull $peering
	$oldpeering = $peering
	$peering.Connections[0] = $peering.Connections[0] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $ipv4 -MaxPrefixesAdvertisedIPv4 $maxv4
	$peering.Connections[1] = $peering.Connections[1] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $ipv42 -MaxPrefixesAdvertisedIPv4 $maxv42
	$update = Update-AzPeering -ResourceId $peering.Id $peering.Connections
	Assert-AreEqual $ipv4 $update.Connections[0].BgpSession.PeerSessionIPv4Address 
	Assert-AreEqual $maxv4 $update.Connections[0].BgpSession.MaxPrefixesAdvertisedV4 
	Assert-AreEqual $ipv42 $update.Connections[1].BgpSession.PeerSessionIPv4Address 
	Assert-AreEqual $maxv42 $update.Connections[1].BgpSession.MaxPrefixesAdvertisedV4 
}
<#
.SYNOPSIS
Helper New Asn Exchange
#>
function Test-UpdateExchangeIPv4OnInputObject
{
	$resourceName = "NewContosoAmsterdamExchangePeering"
	$resourceGroup = "testCarrier"
	$ipv4 = "80.249.208.57"
	$maxv4 = 19990
	$ipv42 = "80.249.211.55"
	$maxv42 = 19990
	$peering = Get-AzPeering $resourceGroup $resourceName
	Assert-NotNull $peering
	$oldpeering = $peering
	$peering.Connections[0] = $peering.Connections[0] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $ipv4 -MaxPrefixesAdvertisedIPv4 $maxv4
	$peering.Connections[1] = $peering.Connections[1] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $ipv42 -MaxPrefixesAdvertisedIPv4 $maxv42
	$update = $peering | Update-AzPeering 
	Assert-NotNull $update
	Assert-AreEqual $ipv4 $update.Connections[0].BgpSession.PeerSessionIPv4Address 
	Assert-AreEqual $maxv4 $update.Connections[0].BgpSession.MaxPrefixesAdvertisedV4 
	Assert-AreEqual $ipv42 $update.Connections[1].BgpSession.PeerSessionIPv4Address 
	Assert-AreEqual $maxv42 $update.Connections[1].BgpSession.MaxPrefixesAdvertisedV4 
}
<#
.SYNOPSIS
Helper New Asn Exchange
#>
function Test-UpdateExchangeMd5OnNameAndResourceGroup
{
	$hash = "276cd9589fc3ee8921c40e9d98ceca02"
	$resourceName = "NewContosoAmsterdamExchangePeering"
	$resourceGroup = "testCarrier"
	$peering = Get-AzPeering $resourceGroup $resourceName
	Assert-NotNull $peering
	$oldpeering = $peering
	$peering.Connections[0] = $peering.Connections[0] |  Set-AzPeeringExchangeConnectionObject -MD5AuthenticationKey $hash
	$peering.Connections[1] = $peering.Connections[1] |  Set-AzPeeringExchangeConnectionObject -MD5AuthenticationKey $hash
	$update = Update-AzPeering -ResourceGroupName $resourceGroup -Name $resourceName -ExchangeConnection $peering.Connections
	Assert-NotNull $update
	Assert-AreEqual $hash $update.Connections[0].BgpSession.Md5AuthenticationKey 
	Assert-AreEqual $hash $update.Connections[1].BgpSession.Md5AuthenticationKey 
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
