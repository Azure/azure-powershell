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
GetLocationKindDirect 
#>
function Test-GetLegacyKindExchangeAmsterdam
{
    $legacy = Get-AzLegacyPeering -Kind Exchange -PeeringLocation Amsterdam 

	Assert-NotNull $legacy
	Assert-AreEqual 1 $legacy.Count
}

function Test-GetLegacyKindDirectAmsterdam
{
    $legacy = Get-AzLegacyPeering -Kind Exchange -PeeringLocation Amsterdam 

	Assert-NotNull $legacy
	Assert-AreEqual 1 $legacy.Count
}

<#
.SYNOPSIS
GetLocationKindDirect
#>
function Test-ConvertLegacyDirectNewPeering
{
	$resourceName = "AkamaiPeering"
    $legacy = Get-AzLegacyPeering -Kind Direct -PeeringLocation Amsterdam  

	Assert-NotNull $legacy
	Assert-AreEqual 1 $legacy.Count

	$peerAsn = Get-AzPeerAsn

	Assert-NotNull $peerAsn

	$legacy | New-AzPeering -Name $resourceName -ResourceGroupName testCarrier -PeeringLocation $legacy.PeeringLocation -PeerAsnResourceId $peerAsn.Id 

	$newPeering = Get-AzPeering -ResourceGroupName testCarrier -Name $resourceName
	
	Assert-NotNull $newPeering
	Assert-AreEqual $resourceName $newPeering.Name
}

<#
.SYNOPSIS
GetLocationKindExchange
#>
function Test-ConvertLegacyExchangeNewPeering
{
	$resourceName = "AkamaiPeering"
    $legacy = Get-AzLegacyPeering -Kind Exchange -PeeringLocation Amsterdam  

	Assert-NotNull $legacy
	Assert-AreEqual 1 $legacy.Count

	$peerAsn = Get-AzPeerAsn

	Assert-NotNull $peerAsn

	$legacy | New-AzPeering -Name $resourceName -ResourceGroupName testCarrier -PeeringLocation $legacy.PeeringLocation -PeerAsnResourceId $peerAsn.Id 

	$newPeering = Get-AzPeering -ResourceGroupName testCarrier -Name $resourceName
	
	Assert-NotNull $newPeering
	Assert-AreEqual $resourceName $newPeering.Name
}


