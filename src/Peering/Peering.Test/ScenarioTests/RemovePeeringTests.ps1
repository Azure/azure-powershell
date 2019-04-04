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
RemoveByName 
#>
function Test-RemoveByName
{
	$peerName = "Contoso"
    $peer = Get-AzPeerAsn -PeerName $peerName

	$removePeer = Remove-AzPeerAsn -PeerName $peer.PeerName -Force

	Assert-NotNull $removePeer

	$peer = Get-AzPeerAsn -PeerName $peer.PeerName
	Assert-Null $peer


}

<#
.SYNOPSIS
RemoveInputObject 
#>
function Test-RemoveInputObject
{
	$peerName = "Contoso"
    $peer = Get-AzPeerAsn -PeerName $peerName

	$removePeer = Get-AzPeerAsn | Remove-AzPeerAsn -Force

	Assert-NotNull $removePeer

	$peer = Get-AzPeerAsn -PeerName $peerName
	Assert-Null $peer
}
