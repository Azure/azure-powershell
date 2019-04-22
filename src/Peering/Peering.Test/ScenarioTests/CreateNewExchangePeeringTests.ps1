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
Helper Function NewExchangeConnectionV4V6 
#>
function Test-NewExchangePeeringPipeTwoConnections
{
#Hard Coded locations becuase of limitations in locations
	$resourceName = getAssetName "NewExchangePeeringPipeTwoConnections"
    $resourceGroup = "testCarrier"
    $peeringLocation = "Seattle"
	$kind = IsDirect $false
	Write-Debug "Getting the Facility Information"
	$facility = Get-AzPeeringLocation -PeeringLocation $peeringLocation -Kind $kind
	$microsoftIpAddressV4 = $facility[1].MicrosoftIPv4Address
	$microsoftIpAddressV6 = $facility[1].MicrosoftIPv6Address
	$facilityId = $facility[1].PeeringDBFacilityId
	$peeringLocation = $facility[1].PeeringLocation
	Write-Debug "Getting the Asn Information"
	$peerAsn = Get-AzPeerAsn | Where-Object {$_.Name -match "Global"} | Select-Object -First 1
	$asn = $peerAsn.Id
	Write-Debug "Creating Connections"
	$connection1 = NewExchangeConnectionV4V6 $facilityId $microsoftIpAddressV4 $microsoftIpAddressV6
	$connection2 = NewExchangeConnectionV4V6 $facilityId $microsoftIpAddressV4 $microsoftIpAddressV6
	Write-Debug "Created $connection1 $connection1"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
    $createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -ExchangeConnection $connection1,$connection2 -Tag $tags
	Assert-NotNull $createdPeering
}
<#
.SYNOPSIS
Tests new Exchange Peering 
#>
function Test-NewExchangePeering()
{
#Hard Coded locations becuase of limitations in locations
	$resourceName = getAssetName "NewExchangePeeringCVS"
    $resourceGroup = "testCarrier"
    $peeringLocation = "Berlin"
	$kind = IsDirect $false
	Write-Debug "Getting the Facility Information"
	$facility = Get-AzPeeringLocation -PeeringLocation $peeringLocation -Kind $kind
	$microsoftIpAddressV4 = $facility[0].MicrosoftIPv4Address.Split(',') | Select-Object -First 1
	$microsoftIpAddressV6 = $facility[0].MicrosoftIPv6Address.Split(',') | Select-Object -First 1
	$facilityId = $facility[0].PeeringDBFacilityId
	$peeringLocation = $facility[0].PeeringLocation
	Write-Debug "Getting the Asn Information"
	$peerAsn = Get-AzPeerAsn | Where-Object {$_.Name -match "Global"} | Select-Object -First 1
	$asn = $peerAsn.Id
	Write-Debug "Creating Connections"
	$connection1 = NewExchangeConnectionV4V6 $facilityId $microsoftIpAddressV4 $microsoftIpAddressV6
	$connection2 = NewExchangeConnectionV4V6 $facilityId $microsoftIpAddressV4 $microsoftIpAddressV6
	Write-Debug "Created $connection1 $connection1"
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
	Write-Debug "Creating Resource $resourceName"
    $createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -ExchangeConnection $connection1,$connection2 -Tag $tags
	Assert-NotNull $createdPeering
}
<#
.SYNOPSIS
Tests new Exchange Peering Pipe
#>
function Test-NewExchangePeeringPipe
{
#Hard Coded locations becuase of limitations in locations
	$resourceName = getAssetName "NewExchangePeeringCVS"
    $resourceGroup = "testCarrier"
    $peeringLocation = "Amsterdam"
	$kind = IsDirect $false
	Write-Debug "Getting the Facility Information"
	$facility = Get-AzPeeringLocation -PeeringLocation $peeringLocation -Kind $kind
	$microsoftIpAddressV4 = $facility[0].MicrosoftIPv4Address
	$microsoftIpAddressV6 = $facility[0].MicrosoftIPv6Address
	$facilityId = $facility[0].PeeringDBFacilityId
	$peeringLocation = $facility[0].PeeringLocation
	Write-Debug "Getting the Asn Information"
	$peerAsn = Get-AzPeerAsn | Where-Object {$_.Name -match "Global"} | Select-Object -First 1
	$asn = $peerAsn.Id
	Write-Debug "Creating Connections"
	$connection1 = NewExchangeConnectionV4V6 $facilityId $microsoftIpAddressV4 $microsoftIpAddressV6
    $tags = @{"tag1" = "value1"; "tag2" = "value2"}
	Write-Debug "Creating Resource $resourceName"
	$createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -Tag $tags -ExchangeConnection $connection1
	Assert-NotNull $createdPeering
}
