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
Full Zone CRUD cycle
#>
function Test-ZoneCrud
{
	$zoneName = Get-RandomZoneName
    $resourceGroup = TestSetup-CreateResourceGroup
	$createdZone = New-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Tags @{tag1="value1"}

	Assert-NotNull $createdZone
	Assert-NotNull $createdZone.Etag
	Assert-AreEqual $zoneName $createdZone.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdZone.ResourceGroupName 
	Assert-AreEqual 1 $createdZone.Tags.Count
	Assert-AreEqual 2 $createdZone.NumberOfRecordSets
	Assert-AreNotEqual $createdZone.NumberOfRecordSets $createdZone.MaxNumberOfRecordSets


	$retrievedZone = Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedZone
	Assert-NotNull $retrievedZone.Etag
	Assert-AreEqual $zoneName $retrievedZone.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedZone.ResourceGroupName
	Assert-AreEqual $retrievedZone.Etag $createdZone.Etag
	Assert-AreEqual 1 $retrievedZone.Tags.Count
	Assert-AreEqual $createdZone.NumberOfRecordSets $retrievedZone.NumberOfRecordSets
	# broken by bug RDBug #6993514
	#Assert-AreEqual $createdZone.MaxNumberOfRecordSets $retrievedZone.MaxNumberOfRecordSets

	$updatedZone = Set-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Tags @{tag1="value1";tag2="value2"}

	Assert-NotNull $updatedZone
	Assert-NotNull $updatedZone.Etag
	Assert-AreEqual $zoneName $updatedZone.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $updatedZone.ResourceGroupName
	Assert-AreNotEqual $updatedZone.Etag $createdZone.Etag
	Assert-AreEqual 2 $updatedZone.Tags.Count

	$retrievedZone = Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedZone
	Assert-NotNull $retrievedZone.Etag
	Assert-AreEqual $zoneName $retrievedZone.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedZone.ResourceGroupName
	Assert-AreEqual $retrievedZone.Etag $updatedZone.Etag
	Assert-AreEqual 2 $retrievedZone.Tags.Count

	$removed = Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName } "*was not found*"
}

<#
.SYNOPSIS
Tests that the zone cmdlets trim the terminating dot from the zone name
#>
function Test-ZoneCrudTrimsDot
{
	$zoneName = Get-RandomZoneName
	$zoneNameWithDot = $zoneName + "."
    $resourceGroup = TestSetup-CreateResourceGroup
	$createdZone = New-AzureRmDnsZone -Name $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $createdZone
	Assert-AreEqual $zoneName $createdZone.Name 

	$retrievedZone = Get-AzureRmDnsZone -Name $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedZone
	Assert-AreEqual $zoneName $retrievedZone.Name 

	$updatedZone = Set-AzureRmDnsZone -Name $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -Tags @{tag1="value1";tag2="value2"}

	Assert-NotNull $updatedZone
	Assert-AreEqual $zoneName $updatedZone.Name 

	$removed = Remove-AzureRmDnsZone -Name $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName } "*was not found*"
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneCrudWithPiping
{
	$zoneName = Get-RandomZoneName
    $createdZone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName -Tags @{tag1="value1"}

	$resourceGroupName = $createdZone.ResourceGroupName

	Assert-NotNull $createdZone
	Assert-NotNull $createdZone.Etag
	Assert-AreEqual $zoneName $createdZone.Name 
	Assert-NotNull $createdZone.ResourceGroupName
	Assert-AreEqual 1 $createdZone.Tags.Count 

	$updatedZone = Get-AzureRmResourceGroup -Name $resourceGroupName | Get-AzureRmDnsZone -Name $zoneName | Set-AzureRmDnsZone -Tags $null

	Assert-NotNull $updatedZone
	Assert-NotNull $updatedZone.Etag
	Assert-AreEqual $zoneName $updatedZone.Name 
	Assert-AreEqual $resourceGroupName $updatedZone.ResourceGroupName
	Assert-AreNotEqual $updatedZone.Etag $createdZone.Etag
	Assert-AreEqual 0 $updatedZone.Tags.Count 

	$removed = Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroupName | Remove-AzureRmDnsZone -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroupName } "*was not found*"
}

<#
.SYNOPSIS
Tests that the zone CRUD cmdlets trim the terminating dot from the zone name when piping
#>
function Test-ZoneCrudWithPipingTrimsDot
{
	$zoneName = Get-RandomZoneName
	$zoneNameWithDot = $zoneName + "."
    $createdZone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName
	
	$resourceGroupName = $createdZone.ResourceGroupName

	$zoneObjectWithDot = New-Object Microsoft.Azure.Commands.Dns.DnsZone
	$zoneObjectWithDot.Name = $zoneNameWithDot
	$zoneObjectWithDot.ResourceGroupName = $resourceGroupName

	$updatedZone = $zoneObjectWithDot | Set-AzureRmDnsZone -Overwrite 

	Assert-NotNull $updatedZone
	Assert-AreEqual $zoneName $updatedZone.Name 

	$removed = $zoneObjectWithDot | Remove-AzureRmDnsZone -Overwrite -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroupName } "*was not found*"
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneNewAlreadyExists
{
	$zoneName = Get-RandomZoneName
    $createdZone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName
	$resourceGroupName = $createdZone.ResourceGroupName
	Assert-NotNull $createdZone

	$message = [System.String]::Format("The Zone {0} exists already and hence cannot be created again.", $zoneName);
	Assert-Throws { New-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroupName } $message

	$createdZone | Remove-AzureRmDnsZone -PassThru -Confirm:$false
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneSetEtagMismatch
{
	$zoneName = Get-RandomZoneName
    $createdZone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName
	$originalEtag = $createdZone.Etag
	$createdZone.Etag = "gibberish"

	$message = [System.String]::Format("The Zone {0} has been modified (etag mismatch).", $zoneName);
	Assert-Throws { $createdZone | Set-AzureRmDnsZone } $message

	$updatedZone = $createdZone | Set-AzureRmDnsZone -Overwrite

	Assert-AreNotEqual "gibberish" $updatedZone.Etag
	Assert-AreNotEqual $createdZone.Etag $updatedZone.Etag

	$updatedZone | Remove-AzureRmDnsZone -PassThru -Confirm:$false
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneSetNotFound
{
	$zoneName = Get-RandomZoneName
    $resourceGroup = TestSetup-CreateResourceGroup

	$message = [System.String]::Format("The Zone {0} has been modified (etag mismatch).", $zoneName);
	Assert-Throws { Set-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName } $message;
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneRemoveEtagMismatch
{
	$zoneName = Get-RandomZoneName
    $createdZone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName
	$originalEtag = $createdZone.Etag
	$createdZone.Etag = "gibberish"

	$message = [System.String]::Format("The Zone {0} has been modified (etag mismatch).", $zoneName);
	Assert-Throws { $createdZone | Remove-AzureRmDnsZone -Confirm:$false } $message

	$removed = $createdZone | Remove-AzureRmDnsZone -Overwrite -Confirm:$false -PassThru

	Assert-True { $removed }
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneRemoveNonExisting
{
	$zoneName = Get-RandomZoneName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	$removed = Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false -PassThru
}

<#
.SYNOPSIS
Zone List
#>
function Test-ZoneList
{
	$zoneName1 = Get-RandomZoneName
	$zoneName2 = $zoneName1 + "A"
	$resourceGroup = TestSetup-CreateResourceGroup
    $createdZone1 = $resourceGroup | New-AzureRmDnsZone -Name $zoneName1 -Tags @{tag1="value1"}
	$createdZone2 = $resourceGroup | New-AzureRmDnsZone -Name $zoneName2

	$result = Get-AzureRmDnsZone -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-AreEqual 2 $result.Count

	Assert-AreEqual $createdZone1.Etag $result[0].Etag
	Assert-AreEqual $createdZone1.Name $result[0].Name
	Assert-NotNull $resourceGroup.ResourceGroupName $result[0].ResourceGroupName
	Assert-AreEqual 1 $result[0].Tags.Count 

	Assert-AreEqual $createdZone2.Etag $result[1].Etag
	Assert-AreEqual $createdZone2.Name $result[1].Name
	Assert-NotNull $resourceGroup.ResourceGroupName $result[1].ResourceGroupName
	Assert-AreEqual 0 $result[1].Tags.Count 

	$result | Remove-AzureRmDnsZone -PassThru -Confirm:$false
}

function Test-ZoneListSubscription
{
	$zoneName1 = Get-RandomZoneName
	$zoneName2 = $zoneName1 + "A"
	$resourceGroup = TestSetup-CreateResourceGroup
    $createdZone1 = $resourceGroup | New-AzureRmDnsZone -Name $zoneName1 -Tags @{tag1="value1"}
	$createdZone2 = $resourceGroup | New-AzureRmDnsZone -Name $zoneName2

	$result = Get-AzureRmDnsZone

	Assert-True   { $result.Count -ge 2 }

	$createdZone1 | Remove-AzureRmDnsZone -PassThru -Confirm:$false
	$createdZone2 | Remove-AzureRmDnsZone -PassThru -Confirm:$false
}

<#
.SYNOPSIS
Zone List With EndsWith
#>
function Test-ZoneListWithEndsWith
{
	$suffix = ".com"
	$suffixWithDot = ".com."
	$zoneName1 = Get-RandomZoneName
	$zoneName2 = $zoneName1 + $suffix
	$resourceGroup = TestSetup-CreateResourceGroup
    $createdZone1 = $resourceGroup | New-AzureRmDnsZone -Name $zoneName1 
	$createdZone2 = $resourceGroup | New-AzureRmDnsZone -Name $zoneName2

	$result = Get-AzureRmDnsZone -ResourceGroupName $resourceGroup.ResourceGroupName -EndsWith $suffixWithDot

	Assert-AreEqual 1 $result.Count

	Assert-AreEqual $createdZone2.Etag $result[0].Etag
	Assert-AreEqual $createdZone2.Name $result[0].Name
	Assert-NotNull $resourceGroup.ResourceGroupName $result[0].ResourceGroupName
	$result | Remove-AzureRmDnsZone -PassThru -Confirm:$false
}

<#
.SYNOPSIS
Add and Remove RecordSet from Zone and test NumberOfRecordSets
#>
function Test-AddRemoveRecordSet
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$createdZone = New-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Tags @{Name="tag1";Value="value1"}

	$record = $createdZone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType A -DnsRecords @() | Add-AzureRmDnsRecordConfig -Ipv4Address 1.1.1.1 | Set-AzureRmDnsRecordSet
	$updatedZone = Get-AzureRmDnsZone -ResourceGroupName $resourceGroup.ResourceGroupName -Name $zoneName
	Assert-AreEqual 3 $updatedZone.NumberOfRecordSets

	$removeRecord = $updatedZone | Get-AzureRmDnsRecordSet -Name $recordName -RecordType A | Remove-AzureRmDnsRecordSet -Name $recordName -RecordType A -PassThru -Confirm:$false
	$finalZone = Get-AzureRmDnsZone -ResourceGroupName $resourceGroup.ResourceGroupName -Name $zoneName
	Assert-AreEqual 2 $finalZone.NumberOfRecordSets

	$finalZone | Remove-AzureRmDnsZone -PassThru -Confirm:$false
}