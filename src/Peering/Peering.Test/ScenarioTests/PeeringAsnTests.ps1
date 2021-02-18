﻿# ----------------------------------------------------------------------------------
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
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
<#
.SYNOPSIS
Tests new Exchange Peering 
#>
function Test-NewPeerAsn()
{
	#asn has to be hard coded because its unique and finite amoungst locations
<<<<<<< HEAD
	$asnId = 65000
	$asnPeerName = getAssetName "Global"
	$asnPeer = getAssetName 
	[string[]]$emails = "noc@$asnPeer.com","noc@$asnPeerName.com"
	$phone = getAssetName
	try{
	New-AzPeerAsn -Name $asnPeerName -PeerName $asnPeer -PeerAsn $asnId -Email $emails -Phone $phone
	$asn = Get-AzPeerAsn -Name $asnPeerName
	Assert-NotNull $asn
	Assert-AreEqual "None" $asn.ValidationState
	Assert-AreEqual $asnPeerName $asn.Name
	Assert-AreEqual $asnId $asn.PeerAsnProperty
	Assert-AreEqual $asnPeer $asn.PeerName
	Assert-True {$emails | % {$_ -like "noc@*.com"}}
=======
	$asnId = (getRandomNumber)
	$asnPeerName = getAssetName "Global"
	$asnPeer = getAssetName 
	$contact0 = NewContactDetail "Noc" $asnPeer
	$contact1 = NewContactDetail "Policy" $asnPeer
	$contacts = @($contact0, $contact1)
	try{
	$created = NewAzPeerAsn $asnPeerName $asnPeer $asnId $contacts
	$asn = Get-AzPeerAsn -Name $asnPeerName
	Assert-NotNull $asn
	Assert-NotNull $created
	Assert-AreEqual $created.ValidationState $asn.ValidationState
	Assert-AreEqual $created.Name $asn.Name
	Assert-AreEqual $created.PeerAsnProperty $asn.PeerAsnProperty
	Assert-AreEqual $created.PeerName $asn.PeerName
	Assert-True {$asn.PeerContactDetail | % {$_.Email -like "*@*.com"}}
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
	}
	finally{
		Remove-AzPeerAsn -Name $asnPeerName -Force
	}
}
<#
.SYNOPSIS
Tests new Exchange Peering Pipe
#>
function Test-GetPeerAsn
{
	#asn has to be hard coded because its unique and finite amoungst locations
<<<<<<< HEAD
	$asnId = 65000
	$asnPeerName = getAssetName "Global"
	$asnPeer = getAssetName 
	[string[]]$emails = "noc@$asnPeer.com","noc@$asnPeerName.com"
	$phone = getAssetName
	try{
	$created = New-AzPeerAsn -Name $asnPeerName -PeerName $asnPeer -PeerAsn $asnId -Email $emails -Phone $phone
=======
	$asnId = (getRandomNumber)
	$asnPeerName = getAssetName "Global"
	$asnPeer = getAssetName 
	$contact0 = NewContactDetail "Noc" $asnPeer
	$contact1 = NewContactDetail "Policy" $asnPeer
	$contacts = @($contact0, $contact1)
	try{
	$created = NewAzPeerAsn $asnPeerName $asnPeer $asnId $contacts
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
	$asn = Get-AzPeerAsn -Name $asnPeerName
	Assert-NotNull $asn
	Assert-NotNull $created
	Assert-AreEqual $created.ValidationState $asn.ValidationState
	Assert-AreEqual $created.Name $asn.Name
	Assert-AreEqual $created.PeerAsnProperty $asn.PeerAsnProperty
	Assert-AreEqual $created.PeerName $asn.PeerName
<<<<<<< HEAD
	Assert-True {$emails | % {$_ -like "noc@*.com"}}
	}
	finally{
		Remove-AzPeerAsn -Name $asnPeerName -Force
=======
	Assert-True {$asn.PeerContactDetail | % {$_.Email -like "*@*.com"}}
	}
	finally{
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
	}
}
<#
.SYNOPSIS
Tests new Exchange Peering Pipe
#>
function Test-ListPeerAsn
{
	#asn has to be hard coded because its unique and finite amoungst locations
<<<<<<< HEAD
	makePeerAsn 65000
	makePeerAsn 65001
	makePeerAsn 65002
=======
	makePeerAsn (getRandomNumber)
	makePeerAsn (getRandomNumber)
	makePeerAsn (getRandomNumber)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
	try{
	$asn = Get-AzPeerAsn
	Assert-NotNull $asn
	Assert-True {$asn.Count -ge 3}
	}
	finally{
		Get-AzPeerAsn | Where-Object {$_.Name -match "Global"} | Remove-AzPeerAsn -Force
	}
	$cleaner = Get-AzPeerAsn | Where-Object {$_.Name -match "Global"}
	Assert-Null $cleaner
}

<<<<<<< HEAD
function makePeerAsn($asn)
{
	$asnId = $asn
	$asnPeerName = getAssetName "Global"
	$asnPeer = getAssetName 
	[string[]]$emails = "noc@$asnPeer.com","noc@$asnPeerName.com"
	$phone = getAssetName
	$created = New-AzPeerAsn -Name $asnPeerName -PeerName $asnPeer -PeerAsn $asnId -Email $emails -Phone $phone
	return $created
}

=======
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
<#
.SYNOPSIS
Tests set email 
#>
function Test-SetPeerAsn
{
<<<<<<< HEAD
	$createdPeerAsn = makePeerAsn 65000
	Assert-NotNull $createdPeerAsn
	$name = $createdPeerAsn.Name
	$getPeerAsn = Get-AzPeerAsn -Name $name
	#new email contact 
	$email = getAssetName
	$email = "$email@$name.com"
	$getPeerAsn | Set-AzPeerAsn -Email $email
	$peerasn = Get-AzPeerAsn
	Assert-True { $peerasn.PeerContactInfo.Emails | Where-Object { $_ -match "$email" } | % {$_ -like $email} }
	Remove-AzPeerAsn -Name $name -Force
=======
	try{
		$createdPeerAsn = makePeerAsn (getRandomNumber)
		Assert-NotNull $createdPeerAsn
		$name = $createdPeerAsn.Name
		$getPeerAsn = Get-AzPeerAsn -Name $name
		#new email contact 
		$email = getAssetName
		$email = "$email@$name.com"
		$getPeerAsn.PeerContactDetail[0].Email = $email
		$getPeerAsn | Set-AzPeerAsn
		$peerasn = Get-AzPeerAsn
		Assert-True { $peerasn.PeerContactDetail.Email | Where-Object { $_ -match "$email" } | % {$_ -like $email} }
	}catch {
		Remove-AzPeerAsn -Name $name -Force
	}
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
}
<#
.SYNOPSIS
Tests new Exchange Peering Pipe Two Connections
#>
function Test-RemovePeerAsn
{
<<<<<<< HEAD
	$createdPeerAsn = makePeerAsn 65000
=======
	$createdPeerAsn = makePeerAsn (getRandomNumber)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
	Assert-NotNull $createdPeerAsn
	$name = $createdPeerAsn.Name
	$getPeerAsn = Get-AzPeerAsn -Name $name
	Assert-NotNull $getPeerAsn
<<<<<<< HEAD
	$remove = Remove-AzPeerAsn $name -PassThru -Force
=======
	$remove = Remove-AzPeerAsn -Name $name -PassThru -Force
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
	Assert-NotNull $remove
	Assert-AreEqual $remove "$true"
	Assert-ThrowsContains {Get-AzPeerAsn -Name $name} "Error"
}
