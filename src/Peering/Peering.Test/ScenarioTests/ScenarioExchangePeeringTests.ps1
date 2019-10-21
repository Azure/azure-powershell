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
try {
$asn = makePeerAsn 15224
$legacy = Get-AzLegacyPeering -PeeringLocation $location -Kind Exchange
Assert-NotNull $legacy
}
finally{
	$isRemoved = Remove-AzPeerAsn -Name $asn.Name -Force -PassThru
		Assert-True {$isRemoved}
}
}
<#
.SYNOPSIS
Convert Legacy Exchange to New Peering
#>
function Test-ConvertLegacyToExchange
{

	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $false;
	$loc = "ashburn"
	$resourceGroup = "testCarrier"
	#asn has to be hard coded because its unique and finite amoungst locations
	$asnId = 57976
	$resourceName = getAssetName "LegacyConvertExchange"
	$asnPeerName = getAssetName "PeerName"
	$asn = makePeerAsn $asnId
	Assert-NotNull $asn
	Assert-AreEqual "Approved" $asn.ValidationState
    $legacy = Get-AzLegacyPeering -Kind $kind -PeeringLocation $loc  
	$tags = @{"tfs_$asnId" = "Active"; "tag2" = "value2"}
	Assert-NotNull $legacy
	$legacy | New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeerAsnResourceId $asn.Id -Tag $tags
	$newPeering = Get-AzPeering -ResourceGroupName testCarrier -Name $resourceName
	Assert-NotNull $newPeering
}

<#
.SYNOPSIS
Helper New Asn Exchange
#>
function Test-UpdateExchangeIPv4OnInputObject 
{
# Hard coded name because the resource has to exist and cant be created ad-hoc.
	$resourceName = getAssetName "LegacyConvertExchange"
	$resourceGroup = "testCarrier"
	$peering = Get-AzPeering -ResourceGroupName $resourceGroup | Where-Object {$_.Name -match "Convert"}
	Assert-NotNull $peering
	$ipv4 = $peering.Connections[0].BgpSession.PeerSessionIPv4Address
	$newipv4 = getPeeringVariable "newIpv4" (changeIp "$ipv4/32" $false 15 $false)
	$ipv42 = $peering.Connections[1].BgpSession.PeerSessionIPv4Address
	$newipv42 = getPeeringVariable "newIpv42" (changeIp "$ipv4/32" $false 17 $false)
	$oldpeering = $peering
	$tags = New-Object 'system.collections.generic.dictionary[string,string]'
	$tags["tfs_234234"] = "Active";
	$peering.Tags = $tags;
	$peering.Connections[0] = $peering.Connections[0] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $newipv4
	$peering.Connections[1] = $peering.Connections[1] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv4Address $newipv42
	Write-Debug "ResourceId: $peering.Id" 
	$update =  $peering | Update-AzPeering 
	Assert-AreEqual $newipv4 $update.Connections[0].BgpSession.PeerSessionIPv4Address 
	Assert-AreEqual $newipv42 $update.Connections[1].BgpSession.PeerSessionIPv4Address 
}
<#
.SYNOPSIS
Helper New Asn Exchange changeIp $ipv4 $false $offset $withPrefix
#>
function Test-UpdateExchangeIPv6OnResourceId
{
# Hard coded name because the resource has to exist and cant be created ad-hoc.
	$resourceName = getAssetName "LegacyConvertExchange"
	$resourceGroup = "testCarrier"
	$peering = Get-AzPeering -ResourceGroupName $resourceGroup | Where-Object {$_.Name -match "Convert"}
	Assert-NotNull $peering
	$ipv6 = $peering.Connections[0].BgpSession.PeerSessionIPv6Address
	$newipv6 = getPeeringVariable "newIpv6" (changeIp "$ipv6/128" $true 14 $false)
	$ipv62 = $peering.Connections[1].BgpSession.PeerSessionIPv6Address
	$newipv62 = getPeeringVariable "newIpv62" (changeIp "$ipv6/128" $true 16 $false)
	$oldpeering = $peering
	$peering.Connections[0] = $peering.Connections[0] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv6Address $newipv6 
	$peering.Connections[1] = $peering.Connections[1] |  Set-AzPeeringExchangeConnectionObject -PeerSessionIPv6Address $newipv62
	Write-Debug $peering.Name
	$update = Update-AzPeering -ResourceId $peering.Id $peering.Connections 
	Assert-NotNull $update
	Assert-AreEqual $newipv6 $update.Connections[0].BgpSession.PeerSessionIPv6Address 
	Assert-AreEqual $newipv62 $update.Connections[1].BgpSession.PeerSessionIPv6Address 
}
<#
.SYNOPSIS
Helper Not supported
#>
function Test-UpdateExchangeMd5OnNameAndResourceGroup
{
	$hash = getHash
# Hard coded name because the resource has to exist and cant be created ad-hoc.
	$resourceGroup = "testCarrier"
	$peering = Get-AzPeering -ResourceGroupName $resourceGroup | Where-Object {$_.Name -match "Convert"}
	Assert-NotNull $peering
	$resourceName = $peering.Name
	$oldpeering = $peering
	$tags = New-Object 'system.collections.generic.dictionary[string,string]'
	$tags["tfs_234234"] = "Active";
	$peering.Tags = $tags;
	$peering.Connections[0] = $peering.Connections[0] |  Set-AzPeeringExchangeConnectionObject -MD5AuthenticationKey $hash
	$peering.Connections[1] = $peering.Connections[1] |  Set-AzPeeringExchangeConnectionObject -MD5AuthenticationKey $hash
	Assert-ThrowsContains {$peering = $peering | Update-AzPeering} "not yet supported"
}
