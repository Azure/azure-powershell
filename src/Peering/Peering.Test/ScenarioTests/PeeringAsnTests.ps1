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
Tests new Exchange Peering 
#>
function Test-NewPeerAsn()
{
	$peerName = "Contoso"
	$asn = 65000
	[string[]]$emails = "tata@noc.com","tata2@noc.com"
	$phone = "888-800-8889"
    $createdPeerAsn = New-AzPeerAsn -Name $peerName -PeerName $peerName -PeerAsn $asn -Email $emails -Phone $phone
	Assert-AreEqual $peerName $createdPeerAsn.PeerName
    Assert-AreEqual $asn $createdPeerAsn.PeerAsnProperty
}
<#
.SYNOPSIS
Tests new Exchange Peering Pipe
#>
function Test-GetPeerAsn
{
	$peerName = "Contoso"
	$asn = 65000
	[string[]]$emails = "tata@noc.com","tata2@noc.com"
	$phone = "888-800-8889"
    $createdPeerAsn = Get-AzPeerAsn -Name $peerName
	Assert-AreEqual 1 $createdPeerAsn.Count
	Assert-AreEqual $peerName $createdPeerAsn.PeerName
    Assert-AreEqual $asn $createdPeerAsn.PeerAsnProperty
}
<#
.SYNOPSIS
Tests new Exchange Peering Pipe
#>
function Test-ListPeerAsn
{
	$peerName = 'Contoso'
	$asn = 65000
	$emails = 1
	$phone = "888-800-8889"
    $createdPeerAsn = Get-AzPeerAsn
	Assert-True { $createdPeerAsn.Count -ge 1}
	Assert-NotNull $createdPeerAsn[0].PeerName
    Assert-NotNull $createdPeerAsn[0].PeerAsnProperty
}
<#
.SYNOPSIS
Tests set email 
#>
function Test-SetPeerAsn
{
	$peerName = "Contoso"
	$asn = 65000
	$phone = "888-800-8899"
	$getPeerAsn = Get-AzPeerAsn -Name $peerName
	$getPeerAsn | Set-AzPeerAsn -Email "noc3@contoso.com"
	$peerasn = Get-AzPeerAsn
	$peerasn.PeerContactInfo.Emails
}
<#
.SYNOPSIS
Tests new Exchange Peering Pipe Two Connections
#>
function Test-RemovePeerAsn
{
	$peerName = "Contoso1"
	$asn = 65050
	[string[]]$emails = "tata@noc.com","tata2@noc.com"
	$phone = "888-800-8889"
    $createdPeerAsn = New-AzPeerAsn -Name $peerName -PeerName $peerName -PeerAsn $asn -Email $emails -Phone $phone
	Assert-NotNull $createdPeerAsn
	$getPeerAsn = Get-AzPeerAsn -Name $peerName
	Assert-NotNull $getPeerAsn
	$remove = $getPeerAsn | Remove-AzPeerAsn -Force
	Assert-NotNull $remove
	Assert-AreEqual $remove "Peer Asn Contoso1 Resource Removed."
	Assert-ThrowsContains {Get-AzPeerAsn -Name $peerName} "Error:Not Found reason:NotFound message:PeerAsn does not exist with the given name Resource does not exist."
}
