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
	# Commented Lines are disabled for testing should be uncommented for Production Testing

	Assert-AreEqual $peerName $createdPeerAsn.PeerName
    Assert-AreEqual $asn $createdPeerAsn.PeerAsnProperty
	#Assert-AreEqual $emails.Count $createdPeerAsn[0].Emails.Count
	#Assert-AreEqual $emails $createdPeerAsn.Emails
	#Assert-AreEqual $phone.Count $createdPeerAsn[0].Phone.Count
	#Assert-AreEqual $phone $createdPeerAsn.Phone
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

    $createdPeerAsn = Get-AzPeerAsn -PeerName $peerName
	
	# Commented Lines are disabled for testing should be uncommented for Production Testing

	Assert-AreEqual 1 $createdPeerAsn.Count
	Assert-AreEqual $peerName $createdPeerAsn.PeerName
    Assert-AreEqual $asn $createdPeerAsn.PeerAsnProperty
	#Assert-AreEqual $emails.Count $createdPeerAsn.Emails.Count
	#Assert-AreEqual $emails $createdPeerAsn.Emails
	#Assert-AreEqual $phone.Count $createdPeerAsn.Phone.Count
	#Assert-AreEqual $phone $createdPeerAsn.Phone
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
	#Assert-AreEqual $emails $createdPeerAsn[0].Emails.Count
	#Assert-AreEqual $emails $createdPeerAsn.Emails
	#Assert-AreEqual $phone.Count $createdPeerAsn[0].Phone.Count
	#Assert-AreEqual $phone $createdPeerAsn.Phone
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

	$getPeerAsn = Get-AzPeerAsn -PeerName $peerName

	$getPeerAsn | Set-AzPeerAsn -Email "noc3@contoso.com"
	$peerasn = Get-AzPeerAsn
	$peerasn.PeerContactInfo.Emails
	
	# Commented Lines are disabled for testing should be uncommented for Production Testing


	#Assert-True {$peerasn.PeerContactInfo.Emails -ge 3}
	#Assert-AreEqual $peerasn.PeerName $createdPeerAsn.PeerName
    #Assert-AreEqual $peerasn.PeerAsnProperty $createdPeerAsn.PeerAsnProperty
	#Assert-AreEqual $emails.Count $createdPeerAsn.Emails.Count
	#Assert-NotEqual $getPeerAsn.Emails.Count $createdPeerAsn.Emails.Count
	#Assert-AreEqual $emails $createdPeerAsn[0].Emails
	#Assert-AreEqual $phone.Count $createdPeerAsn.Phone.Count
	#Assert-AreEqual $phone $createdPeerAsn[0].Phone
	#Assert-NotEqual $getPeerAsn.Phone $createdPeerAsn.Phone
}

<#
.SYNOPSIS
Tests new Exchange Peering Pipe Two Connections
#>
function Test-RemovePeerAsn
{
	$peerName = "Contoso"
	$asn = 65000
	[string[]]$emails = "tata@noc.com","tata2@noc.com"
	$phone = "888-800-8889"

    #$createdPeerAsn = Remove-AzPeerAsn -PeerName $peerName -Force
	
	# Commented Lines are disabled for testing should be uncommented for Production Testing
	#$createdPeerAsn = "Peer Asn $peerName Resource Removed."
	#$getPeerAsn = Get-AzPeerAsn -PeerName $peerName
	# this may fail becuase it will return a not found error and not null.
	#Assert-IsNull $getPeerAsn
}

<#
.SYNOPSIS
NewDirectConnectionWithV4 with fail on wrong IP
#>
function Test-NewDirectConnectionWrongV4
{
	$md5 = "25234523452123411fd234qdwfas3234"
	$facilityId = "99999"
	$sessionv4 = "192.168.1.1/32"
	$bandwidth = 30000

	Assert-ThrowsContains {New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixIPv4 $sessionv4 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5} "Parameter name: Invalid Prefix: 192.168.1.1/32, must be either /30 or /31"
}

