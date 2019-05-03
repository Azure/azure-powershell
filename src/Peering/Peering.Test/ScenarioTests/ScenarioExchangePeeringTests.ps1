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
function NewExchangeConnectionV4V6($facilityId, $v4, $v6)
{
	#Create some data for the object
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$offset = Get-Random -Maximum 20 -Minimum 3
	$sessionv4 = changeIp "$v4/32" $false $offset $false
	$sessionv6 = changeIp "$v6/128" $true $offset $false
	Write-Debug "Created IPs $sessionv4"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"
	#create Connection
    $createdConnection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxv4 -PeerSessionIPv4Address $sessionv4 -PeerSessionIPv6Address $sessionv6 -MaxPrefixesAdvertisedIPv6 $maxv6 -MD5AuthenticationKey $md5
	return $createdConnection
}
<#
.SYNOPSIS
Helper Get Legavy
#>
function Test-GetLegacyPeering($location)
{
$legacy = Get-AzLegacyPeering -PeeringLocation $location -Kind Exchange
Assert-NotNull $legacy
}
<#
.SYNOPSIS
Convert Legacy Exchange to New Peering
#>
function Test-ConvertLegacyToExchange
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $false;
	$loc = "Seattle"
	$resourceGroup = "testCarrier"
	#asn has to be hard coded because its unique and finite amoungst locations
	$asnId = 11164
	$resourceName = getAssetName "LegacyConvertExchange"
	$asnPeerName = getAssetName "PeerName"
	$asnPeer = "Contoso"
	$email = "noc@$asnPeer.com"
	$phone = getAssetName
	New-AzPeerAsn -Name $asnPeerName -PeerName $asnPeer -PeerAsn $asnId -Email $email -Phone $phone
	#the ASN has to be "Approved" by admins prior to this call. 
	$asn = Get-AzPeerAsn -Name $asnPeerName
	Assert-NotNull $asn
	Assert-AreEqual "Approved" $asn.ValidationState
    $legacy = Get-AzLegacyPeering -Kind $kind -PeeringLocation $loc  
	Assert-NotNull $legacy
	$legacy | New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeerAsnResourceId $asn.Id 
	$newPeering = Get-AzPeering -ResourceGroupName testCarrier -Name $resourceName
	Assert-NotNull $newPeering
	#Assert-AreEqual $legacy.
	#Assert-AreEqual $resourceName $newPeering.Name
}
<#
.SYNOPSIS
Helper New Asn Exchange
#>
function Test-UpdateExchangeIPv4OnResourceId
{
	$hash = getHash
	$peering = Get-AzPeering -Kind "Exchange" | Select-Object -First 1
	Assert-NotNull $peering
	$ipv4 = $peering.Connections[0].BgpSession.PeerSessionIPv4Address
	$newipv4 = getPeeringVariable "newIpv4" (changeIp "$ipv4/32" $false 15 $false)
	$maxv4 = maxAdvertisedIpv4
	$ipv42 = $peering.Connections[1].BgpSession.PeerSessionIPv4Address
	$newipv42 = getPeeringVariable "newIpv42" (changeIp "$ipv4/32" $false 17 $false)
	$maxv42 = maxAdvertisedIpv4
	$oldpeering = $peering
	$peering.Connections[0] = $peering.Connections[0] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $newipv4 -MaxPrefixesAdvertisedIPv4 $maxv4
	$peering.Connections[1] = $peering.Connections[1] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $newipv42 -MaxPrefixesAdvertisedIPv4 $maxv42
	$update = Update-AzPeering -ResourceId $peering.Id $peering.Connections
	Assert-AreEqual $newipv4 $update.Connections[0].BgpSession.PeerSessionIPv4Address 
	Assert-AreEqual $maxv4 $update.Connections[0].BgpSession.MaxPrefixesAdvertisedV4 
	Assert-AreEqual $newipv42 $update.Connections[1].BgpSession.PeerSessionIPv4Address 
	Assert-AreEqual $maxv42 $update.Connections[1].BgpSession.MaxPrefixesAdvertisedV4 
}
<#
.SYNOPSIS
Helper New Asn Exchange changeIp $ipv4 $false $offset $withPrefix
#>
function Test-UpdateExchangeIPv4OnInputObject
{
	$hash = getHash
	$peering = Get-AzPeering -Kind "Exchange" | Select-Object -First 1
	Assert-NotNull $peering
	$ipv4 = $peering.Connections[0].BgpSession.PeerSessionIPv4Address
	$newipv4 = getPeeringVariable "newIpv4" (changeIp "$ipv4/32" $false 14 $false)
	$maxv4 = maxAdvertisedIpv4
	$ipv42 = $peering.Connections[1].BgpSession.PeerSessionIPv4Address
	$newipv42 = getPeeringVariable "newIpv42" (changeIp "$ipv4/32" $false 16 $false)
	$maxv42 = maxAdvertisedIpv4
	$oldpeering = $peering
	$peering.Connections[0] = $peering.Connections[0] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $newipv4 -MaxPrefixesAdvertisedIPv4 $maxv4
	$peering.Connections[1] = $peering.Connections[1] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $newipv42 -MaxPrefixesAdvertisedIPv4 $maxv42
	$update = $peering | Update-AzPeering 
	Assert-NotNull $update
	Assert-AreEqual $newipv4 $update.Connections[0].BgpSession.PeerSessionIPv4Address 
	Assert-AreEqual $maxv4 $update.Connections[0].BgpSession.MaxPrefixesAdvertisedV4 
	Assert-AreEqual $newipv42 $update.Connections[1].BgpSession.PeerSessionIPv4Address 
	Assert-AreEqual $maxv42 $update.Connections[1].BgpSession.MaxPrefixesAdvertisedV4 
}
<#
.SYNOPSIS
Helper New Asn Exchange
#>
function Test-UpdateExchangeMd5OnNameAndResourceGroup
{
	$hash = getHash
	$peering = Get-AzPeering -Kind "Exchange" | Select-Object -First 1
	Assert-NotNull $peering
	$resourceName = $peering.Name
	$resourceGroup = "testCarrier"
	$oldpeering = $peering
	$peering.Connections[0] = $peering.Connections[0] |  Set-AzPeeringExchangeConnectionObject -MD5AuthenticationKey $hash
	$peering.Connections[1] = $peering.Connections[1] |  Set-AzPeeringExchangeConnectionObject -MD5AuthenticationKey $hash
	$update = Update-AzPeering -ResourceGroupName $resourceGroup -Name $resourceName -ExchangeConnection $peering.Connections
	Assert-NotNull $update
	Assert-AreEqual $hash $update.Connections[0].BgpSession.Md5AuthenticationKey 
	Assert-AreEqual $hash $update.Connections[1].BgpSession.Md5AuthenticationKey 
}
