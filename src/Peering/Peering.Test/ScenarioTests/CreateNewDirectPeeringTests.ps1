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
function NewDirectConnectionV4V6($facilityId,$bandwidth)
{
	Write-Debug "Creating Connection at $facilityId"
	$md5 = getHash
	$md5 = $md5.ToString()
	Write-Debug "Created Hash $md5"
	$rand1 = Get-Random -Maximum 20 -Minimum 3
	$rand2 = Get-Random -Maximum 200 -Minimum 1
	$sessionv4 = newIpV4Address $true $true 0 $rand2
	$sessionv6 = newIpV6Address $true $true 0 $rand2
	Write-Debug "Created IPs $sessionv4 $SessionPrefixV6"
	$maxv4 = maxAdvertisedIpv4
	$maxv6 = maxAdvertisedIpv6
	Write-Debug "Created maxAdvertised $maxv4 $maxv6"

    $createdConnection = New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV4 $sessionv4 -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv4 $maxv4 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5
	Write-Debug "Created Connection $createdConnection"
#	Assert-NotNull $createdConnection
#	Assert-AreEqual $md5 $createdConnection.BgpSession.Md5AuthenticationKey
#	Assert-AreEqual $facilityId $createdConnection.PeeringDBFacilityId 
#    Assert-AreEqual $bandwidth $createdConnection.BandwidthInMbps
#	Assert-AreEqual $sessionv4 $createdConnection.BgpSession.SessionPrefixV4
#    Assert-AreEqual $sessionv6 $createdConnection.BgpSession.SessionPrefixV6
	return $createdConnection
}
<#
.SYNOPSIS
Tests new Direct Peering 
#>
function Test-NewDirectPeering
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Amsterdam"
	$resourceGroup = "testCarrier";
	Write-Debug $resourceGroup
	#Create Resource
	$resourceName = getAssetName "DirectOneConnection";
	Write-Debug "Setting $resourceName"
    $peeringLocation = getPeeringLocation $kind $loc;
	Write-Debug "Getting the Asn Information"
	$randNum = getRandomNumber
	Write-Debug "Random Number $randNum";
	$peerAsn = makePeerAsn $randNum
	$asn = $peerAsn
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#create Connection
	$bandwidth = getBandwidth
	$directConnection = NewDirectConnectionV4V6 $facilityId $bandwidth
	$tags = @{"tfs_$randNum" = "value1"; "tag2" = "value2"}
	$md5 =  $directConnection.BgpSession.Md5AuthenticationKey
	$sessionv4 = getPeeringVariable "sessionv4" $directConnection.BgpSession.SessionPrefixV4
	$sessionv6 = getPeeringVariable "sessionv6" $directConnection.BgpSession.SessionPrefixV6
	Write-Debug "Creating New Peering: $resourceName."
    $createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation[0].PeeringLocation -Sku "Basic_Direct_Free" -PeerAsnResourceId $asn.Id -DirectConnection $directConnection -Tag $tags
	Write-Debug "Created New Peering: $createdPeering$Name"
	Assert-NotNull $createdPeering
	Assert-AreEqual $kind $createdPeering.Kind
	Assert-AreEqual $resourceName $createdPeering.Name
	Assert-AreEqual $peeringLocation[0].PeeringLocation $createdPeering.PeeringLocation
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
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Seattle"
	$resourceGroup = "testCarrier";
	Write-Debug $resourceGroup
	#Create Asn
	Write-Debug "Getting the Asn Information"
	$randNum = getRandomNumber
	Write-Debug "Random Number $randNum";
	$peerAsn = makePeerAsn $randNum
	$asn = $peerAsn
	#Create Resource
	$resourceName = getAssetName "DirectPipeConnection";
	Write-Debug "Setting $resourceName"
    $peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#create Connection
	$bandwidth = getBandwidth
	$directConnection = NewDirectConnectionV4V6 $facilityId $bandwidth
	$tags = @{"tfs_$randNum" = "value1"; "tag2" = "value2"}
	$md5 =  $directConnection.BgpSession.Md5AuthenticationKey
	$sessionv4 = getPeeringVariable "sessionv4" $directConnection.BgpSession.SessionPrefixV4
	$sessionv6 = getPeeringVariable "sessionv6" $directConnection.BgpSession.SessionPrefixV6
	Write-Debug "Creating New Peering: $resourceName."
    $createdPeering =  New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation[0].PeeringLocation -Sku "Basic_Direct_Free" -PeerAsnResourceId $asn.Id -Tag $tags -DirectConnection ($directConnection) 
	Assert-NotNull $createdPeering
	Assert-AreEqual "Direct" $createdPeering.Kind
	Assert-AreEqual $resourceName $createdPeering.Name
	Assert-AreEqual $peeringLocation[0].PeeringLocation $createdPeering.PeeringLocation
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
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Ashburn"
	$resourceGroup = "testCarrier";
	Write-Debug $resourceGroup
		#Create Asn
	Write-Debug "Getting the Asn Information"
	$randNum = getRandomNumber
	Write-Debug "Random Number $randNum";
	$peerAsn = makePeerAsn $randNum
	$asn = $peerAsn
	#Create Resource
	$resourceName = getAssetName "DirectOneConnection";
	Write-Debug "Setting $resourceName"
    $peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#create Connection
	$bandwidth = getBandwidth
	$bandwidth2 = getBandwidth
	$tags = @{"tfs_$randNum" = "value1"; "tag2" = "value2"}
	Write-Debug "Creating New Peering: $resourceName."
	$connection1 = NewDirectConnectionV4V6 $facilityId $bandwidth
	# variables to save for playback
	$sessionv4 = getPeeringVariable "sessionv4" $connection1.BgpSession.SessionPrefixV4
	$sessionv6 = getPeeringVariable "sessionv6" $connection1.BgpSession.SessionPrefixV6
	$md5 =  $connection1.BgpSession.Md5AuthenticationKey
	#connection2
	$connection2 = NewDirectConnectionV4V6 $facilityId $bandwidth2
	#create peering
    $createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation[0].PeeringLocation -Sku "Basic_Direct_Free" -PeerAsnResourceId $asn.Id -Tag $tags -DirectConnection $connection1, $connection2
	Assert-NotNull $createdPeering
	Assert-AreEqual $kind $createdPeering.Kind
	Assert-AreEqual $resourceName $createdPeering.Name
	Assert-AreEqual $peeringLocation[0].PeeringLocation $createdPeering.PeeringLocation
	Assert-AreEqual $md5 $createdPeering.Connections[0].BgpSession.Md5AuthenticationKey
	Assert-AreEqual $facilityId $createdPeering.Connections[0].PeeringDBFacilityId 
    Assert-AreEqual $bandwidth $createdPeering.Connections[0].BandwidthInMbps
	Assert-AreEqual $sessionv4 $createdPeering.Connections[0].BgpSession.SessionPrefixV4
    Assert-AreEqual $sessionv6 $createdPeering.Connections[0].BgpSession.SessionPrefixV6
	Assert-NotNull $createdPeering.Connections[1].BgpSession
}

<#
.SYNOPSIS
Tests new Direct Peering Pipe Two Connections
#>
function Test-NewDirectPeeringPremiumDirectFree
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Ashburn"
	$resourceGroup = "testCarrier";
	Write-Debug $resourceGroup
	#Create Asn
	Write-Debug "Getting the Asn Information"
	$randNum = getRandomNumber
	Write-Debug "Random Number $randNum";
	$peerAsn = makePeerAsn $randNum
	$asn = $peerAsn
	#Create Resource
	$resourceName = getAssetName "DirectOneConnection";
	Write-Debug "Setting $resourceName"
    $peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#create Connection
	$bandwidth = getBandwidth
	$bandwidth2 = getBandwidth
	$tags = @{"tfs_$randNum" = "value1"; "tag2" = "value2"}
	$connection1 = NewDirectConnectionV4V6 $facilityId $bandwidth
	# variables to save for playback
	$sessionv4 = getPeeringVariable "sessionv4" $connection1.BgpSession.SessionPrefixV4
	$sessionv6 = getPeeringVariable "sessionv6" $connection1.BgpSession.SessionPrefixV6
	$md5 =  $connection1.BgpSession.Md5AuthenticationKey
	#connection2
	$connection2 = NewDirectConnectionV4V6 $facilityId $bandwidth2
	#create peering
	$connection2.UseForPeeringService = $true
    $createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation[0].PeeringLocation -Sku "Basic_Direct_Free" -PeerAsnResourceId $asn.Id -Tag $tags -DirectConnection $connection1, $connection2
	Assert-NotNull $createdPeering
	Assert-AreEqual $kind $createdPeering.Kind
	Assert-AreEqual $resourceName $createdPeering.Name
	Assert-AreEqual $peeringLocation[0].PeeringLocation $createdPeering.PeeringLocation
	Assert-AreEqual $md5 $createdPeering.Connections[0].BgpSession.Md5AuthenticationKey
	Assert-AreEqual $facilityId $createdPeering.Connections[0].PeeringDBFacilityId 
    Assert-AreEqual $bandwidth $createdPeering.Connections[0].BandwidthInMbps
	Assert-AreEqual $sessionv4 $createdPeering.Connections[0].BgpSession.SessionPrefixV4
    Assert-AreEqual $sessionv6 $createdPeering.Connections[0].BgpSession.SessionPrefixV6
	Assert-AreEqual "Premium_Direct_Free" $createdPeering.Sku.Name
	Assert-NotNull $createdPeering.Connections[1].BgpSession
}

<#
.SYNOPSIS
Tests new Direct Peering Pipe Two Connections
#>
function Test-NewDirectPeeringPremiumDirectUnlimited
{
	#Hard Coded locations becuase of limitations in locations
	$kind = isDirect $true;
	$loc = "Ashburn"
	$resourceGroup = "testCarrier";
	Write-Debug $resourceGroup
	#Create Asn
	Write-Debug "Getting the Asn Information"
	$randNum = getRandomNumber
	Write-Debug "Random Number $randNum";
	$peerAsn = makePeerAsn $randNum
	$asn = $peerAsn
	#Create Resource
	$resourceName = getAssetName "DirectOneConnection";
	Write-Debug "Setting $resourceName"
    $peeringLocation = getPeeringLocation $kind $loc;
	$facilityId = $peeringLocation[0].PeeringDBFacilityId
	#create Connection
	$bandwidth = getBandwidth
	$bandwidth2 = getBandwidth
	$tags = @{"tfs_$randNum" = "value1"; "tag2" = "value2"}
	$connection1 = NewDirectConnectionV4V6 $facilityId $bandwidth
	# variables to save for playback
	$sessionv4 = getPeeringVariable "sessionv4" $connection1.BgpSession.SessionPrefixV4
	$sessionv6 = getPeeringVariable "sessionv6" $connection1.BgpSession.SessionPrefixV6
	$md5 =  $connection1.BgpSession.Md5AuthenticationKey
	#connection2
	$connection2 = NewDirectConnectionV4V6 $facilityId $bandwidth2
	#create peering
	$connection2.UseForPeeringService = $true
    Assert-ThrowsContains { $createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation[0].PeeringLocation -Sku "Premium_Direct_Unlimited" -PeerAsnResourceId $asn.Id -Tag $tags -DirectConnection $connection1, $connection2 } "Peering SKU is invalid for Direct"
}