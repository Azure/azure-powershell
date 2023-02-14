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
Full Record Set CRUD cycle
#>
function Test-RecordSetCrud
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	$zone = New-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$createdRecord = New-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Ttl 100 -RecordType A -Metadata @{ tag1 ="val1"}

	Assert-NotNull $createdRecord
	Assert-NotNull $createdRecord.Etag
	Assert-AreEqual 100 $createdRecord.Ttl
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $recordName $createdRecord.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdRecord.ResourceGroupName 
	Assert-AreEqual 1 $createdRecord.Metadata.Count
	Assert-AreEqual 0 $createdRecord.Records.Count

	$retrievedRecord = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName
	Assert-AreEqual $retrievedRecord.Etag $createdRecord.Etag
	Assert-AreEqual 1 $retrievedRecord.Metadata.Count
	Assert-AreEqual 0 $retrievedRecord.Records.Count
	# broken by service bug
	# Assert-AreEqual 100 $createdRecord.Ttl

	# TODO: change and pipe in retrievedRecord, not createdRecord but this is currently broken by a service bug
	$createdRecord.Metadata = @{ tag1 = "val1"; tag2 = "val2"}
	$createdRecord.Ttl = 1300
	$updatedRecord = $createdRecord | Add-AzDnsRecordConfig -Ipv4Address 13.13.0.13 | Set-AzDnsRecordSet

	Assert-NotNull $updatedRecord
	Assert-NotNull $updatedRecord.Etag
	Assert-AreEqual $recordName $updatedRecord.Name 
	Assert-AreEqual $zoneName $updatedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $updatedRecord.ResourceGroupName
	Assert-AreEqual 1300 $updatedRecord.Ttl
	Assert-AreNotEqual $updatedRecord.Etag $createdRecord.Etag
	Assert-AreEqual 2 $updatedRecord.Metadata.Count
	Assert-AreEqual 1 $updatedRecord.Records.Count
	Assert-AreEqual "13.13.0.13" $updatedRecord.Records[0].Ipv4Address

	$retrievedRecord = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName
	Assert-AreEqual $retrievedRecord.Etag $updatedRecord.Etag
	Assert-AreEqual 2 $retrievedRecord.Metadata.Count
	Assert-AreEqual 1 $retrievedRecord.Records.Count
	Assert-AreEqual "13.13.0.13" $retrievedRecord.Records[0].Ipv4Address
	# broken by service bug
	# Assert-AreEqual 1300 $createdRecord.Ttl

	$removed = Remove-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A } "*does not exist*"

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test Alias Record Set
#>
function Test-AliasRecordSet
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
	$subscription = getSubscription
	$resourceGroup = TestSetup-CreateResourceGroup
	$recordType = "A"
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	# non alias record
	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType $recordType -DnsRecords @()
	$record = $record | Add-AzDnsRecordConfig -Ipv4Address 1.1.1.1
	$record = $record | Set-AzDnsRecordSet
	
	# alias record pointing to non-alias record
	$aliasRecordName = "alias" + $(getAssetname)
	$createdRecord = New-AzDnsRecordSet -Name $aliasRecordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType $recordType -TargetResourceId $record.Id

	Assert-NotNull $createdRecord
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $aliasRecordName $createdRecord.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdRecord.ResourceGroupName

	$aliasRecord = $zone | Get-AzDnsRecordSet -Name $aliasRecordName -RecordType $recordType
	$nonaliasRecord = $zone | Get-AzDnsRecordSet -Name $recordName -RecordType $recordType
	Assert-AreEqual $record.Id $aliasRecord.TargetResourceId

	$nonaliasRecord | Remove-AzDnsRecordSet

	Assert-ThrowsLike { Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType $recordType } "*does not exist*"

	$aliasRecord = $zone | Get-AzDnsRecordSet -Name $aliasRecordName -RecordType $recordType
	Assert-Null $nonaliasRecord.TargetResourceId
	$aliasRecord | Remove-AzDnsRecordSet

	Assert-ThrowsLike { Get-AzDnsRecordSet -Name $aliasRecordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType $recordType } "*does not exist*"

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle trims terminating dot from zone name
#>
function Test-RecordSetCrudTrimsDotFromZoneName
{
	$zoneName = Get-RandomZoneName
	$zoneNameWithDot = $zoneName + "."

	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	$zone = New-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$createdRecord = New-AzDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -Ttl 100 -RecordType A -Metadata @{tag1 = "val1"}

	Assert-NotNull $createdRecord
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $recordName $createdRecord.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdRecord.ResourceGroupName 

	$retrievedRecord = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName

	$retrievedRecord = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName

	$removed = Remove-AzDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A } "*does not exist*"

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetCrudWithPiping
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $updatedRecord = TestSetup-CreateResourceGroup | New-AzDnsZone -Name $zoneName | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType A -Metadata @{tag1 = "val1"} | Add-AzDnsRecordConfig -Ipv4Address 13.13.0.13 | Set-AzDnsRecordSet

	$resourceGroupName = $updatedRecord.ResourceGroupName
	Assert-NotNull $updatedRecord
	Assert-NotNull $updatedRecord.Etag
	Assert-AreEqual $recordName $updatedRecord.Name 
	Assert-AreEqual $zoneName $updatedRecord.ZoneName 
	Assert-NotNull $updatedRecord.ResourceGroupName
	Assert-AreEqual 1 $updatedRecord.Metadata.Count
	Assert-AreEqual 1 $updatedRecord.Records.Count
	Assert-AreEqual "13.13.0.13" $updatedRecord.Records[0].Ipv4Address

	$removed = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -RecordType A | Remove-AzDnsRecordSet -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -RecordType A } "*does not exist*"

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetCrudWithPipingTrimsDotFromZoneName
{
	$zoneName = Get-RandomZoneName
	$zoneNameWithDot = $zoneName + "."

	$recordName = getAssetname
    $zone = TestSetup-CreateResourceGroup | New-AzDnsZone -Name $zoneName
	
	$zoneObjectWithDot = New-Object Microsoft.Azure.Commands.Dns.DnsZone
	$zoneObjectWithDot.Name = $zoneNameWithDot
	$zoneObjectWithDot.ResourceGroupName = $zone.ResourceGroupName
	
	$createdRecord = $zoneObjectWithDot | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType A -Metadata @{ tag1 ="val1"}

	Assert-NotNull $createdRecord
	Assert-AreEqual $recordName $createdRecord.Name 
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $zone.ResourceGroupName $createdRecord.ResourceGroupName

	$recordObjectWithDot = New-Object Microsoft.Azure.Commands.Dns.DnsRecordSet
	$recordObjectWithDot.Name = $recordName
	$recordObjectWithDot.ZoneName = $zoneNameWithDot
	$recordObjectWithDot.ResourceGroupName = $zone.ResourceGroupName
	$recordObjectWithDot.Ttl = 60

	$recordAfterAdd = $recordObjectWithDot | Add-AzDnsRecordConfig -Ipv4Address 13.13.0.13

	# this is an offline operation, we don't check the dot and don't change the object in place
	Assert-AreEqual $zoneNameWithDot $recordAfterAdd.ZoneName 

	$updatedRecord = $recordAfterAdd | Set-AzDnsRecordSet -Overwrite

	Assert-NotNull $updatedRecord
	Assert-AreEqual $recordName $updatedRecord.Name 
	Assert-AreEqual $zoneName $updatedRecord.ZoneName 
	Assert-AreEqual $zone.ResourceGroupName $updatedRecord.ResourceGroupName

	$retrievedRecord = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $zone.ResourceGroupName -RecordType A 
	
	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $zone.ResourceGroupName $updatedRecord.ResourceGroupName
	
	$removed = $recordObjectWithDot | Remove-AzDnsRecordSet -Overwrite -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -RecordType A } "*does not exist*"

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $zone.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $zone.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetA
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType A -DnsRecords @()

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzDnsRecordConfig -Ipv4Address 1.1.1.1
	$record = $record | Add-AzDnsRecordConfig -Ipv4Address 2.2.2.2
	$record = $record | Remove-AzDnsRecordConfig -Ipv4Address 1.1.1.1
	$record = $record | Remove-AzDnsRecordConfig -Ipv4Address 3.3.3.3

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "2.2.2.2" $getResult.Records[0].Ipv4Address

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual "2.2.2.2" $listResult[0].Records[0].Ipv4Address

	$removed = $listResult[0] | Remove-AzDnsRecordSet -PassThru -Confirm:$false

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetANonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$aRecords=@()
	$aRecords += New-AzDnsRecordConfig -IPv4Address "192.168.0.1"
	$aRecords += New-AzDnsRecordConfig -IPv4Address "192.168.0.2"
	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType A -DnsRecords $aRecords
	
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "192.168.0.1" $getResult.Records[0].Ipv4Address
	Assert-AreEqual "192.168.0.2" $getResult.Records[1].Ipv4Address

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-AreEqual 2 $listResult[0].Records.Count
	Assert-AreEqual "192.168.0.1" $listResult[0].Records[0].Ipv4Address
	Assert-AreEqual "192.168.0.2" $listResult[0].Records[1].Ipv4Address

	$removed = $listResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetAAAA
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType AAAA

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzDnsRecordConfig -Ipv6Address 1::11
	$record = $record | Add-AzDnsRecordConfig -Ipv6Address 2::22
	$record = $record | Add-AzDnsRecordConfig -Ipv6Address 4::44
	$record = $record | Remove-AzDnsRecordConfig -Ipv6Address 2::22
	$record = $record | Remove-AzDnsRecordConfig -Ipv6Address 3::33

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType AAAA 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "1::11" $getResult.Records[0].Ipv6Address
	Assert-AreEqual "4::44" $getResult.Records[1].Ipv6Address

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType AAAA

	Assert-AreEqual 2 $listResult[0].Records.Count
	Assert-AreEqual "1::11" $listResult[0].Records[0].Ipv6Address
	Assert-AreEqual "4::44" $listResult[0].Records[1].Ipv6Address

	$removed = $listResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetAAAANonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$aaaaRecords=@()
	$aaaaRecords += New-AzDnsRecordConfig  -IPv6Address "2002::1"
	$aaaaRecords += New-AzDnsRecordConfig  -IPv6Address "2002::2"
	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType AAAA -DnsRecords $aaaaRecords

	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType AAAA
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "2002::1" $getResult.Records[0].Ipv6Address
	Assert-AreEqual "2002::2" $getResult.Records[1].Ipv6Address

	$removed = $getResult | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetCNAME
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType CNAME

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzDnsRecordConfig -Cname www.example.com
	$record = $record | Remove-AzDnsRecordConfig -Cname www.example.com
	$record = $record | Add-AzDnsRecordConfig -Cname www.contoso.com
	$record = $record | Remove-AzDnsRecordConfig -Cname gibberish

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CNAME 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "www.contoso.com" $getResult.Records[0].Cname

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CNAME

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual "www.contoso.com" $listResult[0].Records[0].Cname

	$removed = $listResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetCNAMENonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$records = New-AzDnsRecordConfig  -Cname "www.contoso.com"
	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType CNAME -DnsRecords $records

	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CNAME 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "www.contoso.com" $getResult.Records[0].Cname

	$removed = $getResult | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetMX
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType MX

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzDnsRecordConfig -Exchange mail1.theg.com -Preference 10
	$record = $record | Add-AzDnsRecordConfig -Exchange mail2.theg.com -Preference 10
	$record = $record | Remove-AzDnsRecordConfig -Exchange mail1.theg.com -Preference 10
	$record = $record | Remove-AzDnsRecordConfig -Exchange mail2.theg.com -Preference 15

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "mail2.theg.com" $getResult.Records[0].Exchange
	Assert-AreEqual 10 $getResult.Records[0].Preference

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual "mail2.theg.com" $listResult[0].Records[0].Exchange
	Assert-AreEqual 10 $listResult[0].Records[0].Preference

	$removed = $listResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetMXNonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$records = @();
	$records += New-AzDnsRecordConfig  -Exchange mail2.theg.com -Preference 0
	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType MX -DnsRecords $records

	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "mail2.theg.com" $getResult.Records[0].Exchange
	Assert-AreEqual 0 $getResult.Records[0].Preference

	$removed = $getResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetNS
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType NS

	# add three records, remove one, remove another no-op
	$record = $record | Add-AzDnsRecordConfig -Nsdname ns1.example.com
	$record = $record | Add-AzDnsRecordConfig -Nsdname ns2.example.com
	$record = $record | Add-AzDnsRecordConfig -Nsdname ns3.example.com
	$record = $record | Remove-AzDnsRecordConfig -Nsdname ns3.example.com
	$record = $record | Remove-AzDnsRecordConfig -Nsdname ns4.example.com

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType NS 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "ns1.example.com" $getResult.Records[0].Nsdname
	Assert-AreEqual "ns2.example.com" $getResult.Records[1].Nsdname

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType NS

	# the authoritative NS record set will be the first result
	Assert-AreEqual 2 $listResult.Count
	Assert-AreEqual 2 $listResult[1].Records.Count
	Assert-AreEqual "ns1.example.com" $listResult[1].Records[0].Nsdname
	Assert-AreEqual "ns2.example.com" $listResult[1].Records[1].Nsdname

	$removed = $listResult[1] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetNSNonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$records = @()
	$records += New-AzDnsRecordConfig  -Nsdname ns1.example.com
    $records += New-AzDnsRecordConfig  -Nsdname ns2.example.com
	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType NS -DnsRecords $records

	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType NS 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "ns1.example.com" $getResult.Records[0].Nsdname
	Assert-AreEqual "ns2.example.com" $getResult.Records[1].Nsdname

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType NS

	# the authoritative NS record set will be the first result
	Assert-AreEqual 2 $listResult.Count
	Assert-AreEqual 2 $listResult[1].Records.Count
	Assert-AreEqual "ns1.example.com" $listResult[1].Records[0].Nsdname
	Assert-AreEqual "ns2.example.com" $listResult[1].Records[1].Nsdname

	$removed = $listResult[1] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetTXT
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType TXT

	# add three records, remove one, remove another no-op
	$record = $record | Add-AzDnsRecordConfig -Value text1
	$record = $record | Add-AzDnsRecordConfig -Value text2
	$record = $record | Add-AzDnsRecordConfig -Value text3
	$record = $record | Remove-AzDnsRecordConfig -Value text1
	$record = $record | Remove-AzDnsRecordConfig -Value text4

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual text2 $getResult.Records[0].Value
	Assert-AreEqual text3 $getResult.Records[1].Value

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT

	Assert-AreEqual 2 $listResult[0].Records.Count
	Assert-AreEqual text2 $listResult[0].Records[0].Value
	Assert-AreEqual text3 $listResult[0].Records[1].Value

	$removed = $listResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetTXTNonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

    $records = @()
	$records += New-AzDnsRecordConfig  -Value text2
    $records += New-AzDnsRecordConfig  -Value text3

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType TXT -DnsRecords $records

	# add three records, remove one, remove another no-op

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual text2 $getResult.Records[0].Value
	Assert-AreEqual text3 $getResult.Records[1].Value

	$removed = $getResult | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetTXTLegacyLengthValidation
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 
	$longRecordTxt = Get-TxtOfSpecifiedLength 1025;
	$maxRecordTxt = Get-TxtOfSpecifiedLength 1024;

	$recordSet = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType TXT ;
		
	Assert-Throws {$recordSet | Add-AzDnsRecordConfig -Value $longRecordTxt }
	
	$recordSet = $recordSet | Add-AzDnsRecordConfig -Value $maxRecordTxt
	$setResult = $recordSet | Set-AzDnsRecordSet ;
		
	Assert-AreEqual $maxRecordTxt $setResult.Records[0].Value;

	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT ;
	Assert-AreEqual $maxRecordTxt $getResult.Records[0].Value;

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


function Test-RecordSetTXTLengthValidation
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$longRecordTxt = Get-TxtOfSpecifiedLength 1025;
	Assert-Throws {New-AzDnsRecordConfig -Value $longRecordTxt }

	$maxRecordTxt = Get-TxtOfSpecifiedLength 1024;
	$maxRecord = New-AzDnsRecordConfig -Value $maxRecordTxt
	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType TXT -DnsRecords $maxRecord ;
	Assert-AreEqual $maxRecordTxt $record.Records[0].Value;

	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT ;
	Assert-AreEqual $maxRecordTxt $getResult.Records[0].Value;

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


function Test-RecordSetPTR
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType PTR

	# add three records, remove one, remove another no-op
	$record = $record | Add-AzDnsRecordConfig -Ptrdname  "contoso1.com"
	$record = $record | Add-AzDnsRecordConfig -Ptrdname  "contoso2.com"
	$record = $record | Add-AzDnsRecordConfig -Ptrdname  "contoso3.com"
    $record = $record | Remove-AzDnsRecordConfig -Ptrdname  "contoso1.com"
    $record = $record | Remove-AzDnsRecordConfig -Ptrdname  "contoso4.com"

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType PTR 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "contoso2.com" $getResult.Records[0].Ptrdname
	Assert-AreEqual "contoso3.com" $getResult.Records[1].Ptrdname

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType PTR

	Assert-AreEqual 2 $listResult[0].Records.Count

	$removed = $listResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetPTRNonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

    $records = @()
	$records += New-AzDnsRecordConfig   -PtrdName "contoso.com"

    $record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType PTR -DnsRecords $records
	Assert-AreEqual 1 $record.Records.Count

	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType PTR
	Assert-AreEqual 1 $getResult.Records.Count
    Assert-AreEqual "contoso.com" $getResult.Records[0].Ptrdname

	$removed = $getResult | Remove-AzDnsRecordSet -Confirm:$false -PassThru
	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetSRV
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType SRV

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzDnsRecordConfig -Port 53 -Priority 1 -Target ns1.example.com -Weight 5
	$record = $record | Add-AzDnsRecordConfig -Port 53 -Priority 2 -Target ns2.example.com -Weight 10
	$record = $record | Remove-AzDnsRecordConfig -Port 53 -Priority 2 -Target ns2.example.com -Weight 10
	$record = $record | Remove-AzDnsRecordConfig -Port 42 -Priority 999 -Target ns5.example.com -Weight 1600

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SRV 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual 53 $getResult.Records[0].Port
	Assert-AreEqual 1 $getResult.Records[0].Priority
	Assert-AreEqual ns1.example.com $getResult.Records[0].Target
	Assert-AreEqual 5 $getResult.Records[0].Weight

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SRV

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual 53 $listResult[0].Records[0].Port
	Assert-AreEqual 1 $listResult[0].Records[0].Priority
	Assert-AreEqual ns1.example.com $listResult[0].Records[0].Target
	Assert-AreEqual 5 $listResult[0].Records[0].Weight

	$removed = $listResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetSRVNonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

    $records = @()
	$records += New-AzDnsRecordConfig  -Port 53 -Priority 1 -Target ns1.example.com -Weight 5
	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType SRV -DnsRecords $records

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SRV 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual 53 $getResult.Records[0].Port
	Assert-AreEqual 1 $getResult.Records[0].Priority
	Assert-AreEqual ns1.example.com $getResult.Records[0].Target
	Assert-AreEqual 5 $getResult.Records[0].Weight

	$removed = $getResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetSOA
{
	$zoneName = Get-RandomZoneName
	$recordName = "@"
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | Get-AzDnsRecordSet -Name $recordName -RecordType SOA

	#Ensure that SOA RecordSet cannot be created
	Assert-Throws { New-AzDnsRecordSet -Name $recordName -RecordType SOA -ResourceGroupName $resourceGroup -ZoneName $zoneName  -Ttl 100 } "There can be only one record set of type SOA, and it can be modified but not deleted."

	# can only update SOA values, can't add or remove
	Assert-AreEqual 1 $record.Count
	$record.Records[0].RefreshTime = 13
	$record.Records[0].RetryTime = 666
	$record.Records[0].ExpireTime = 42
	$record.Records[0].MinimumTtl = 321
	$record.Ttl = 110901

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SOA 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual 13 $getResult.Records[0].RefreshTime
	Assert-AreEqual 666 $getResult.Records[0].RetryTime
	Assert-AreEqual 42 $getResult.Records[0].ExpireTime
	Assert-AreEqual 321 $getResult.Records[0].MinimumTtl
	Assert-AreEqual 110901 $getResult.Ttl

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SOA

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual 13 $listResult[0].Records[0].RefreshTime
	Assert-AreEqual 666 $listResult[0].Records[0].RetryTime
	Assert-AreEqual 42 $listResult[0].Records[0].ExpireTime
	Assert-AreEqual 321 $listResult[0].Records[0].MinimumTtl
	Assert-AreEqual 110901 $listResult[0].Ttl

	Assert-Throws { $listResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru } "RecordSets of type 'SOA' with name '@' cannot be deleted."

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Validate-CAARecord(
 $record,
 [int] $flags,
 $tag,
 $value)
{
	Assert-AreEqual $flags $record.Flags
	Assert-AreEqual $tag $record.Tag
	Assert-AreEqual $value $record.Value
}

<#
.SYNOPSIS
Full Record Set CRUD cycle for CAA record
#>
function Test-RecordSetCAA
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType CAA

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzDnsRecordConfig -CaaFlags 0 -CaaTag issue -CaaValue "contoso.org"
	#$record = $record | Add-AzDnsRecordConfig -CaaFlags 1 -CaaTag issuewild -CaaValue "contoso.org"
	#$record = $record | Remove-AzDnsRecordConfig -CaaFlags 1 -CaaTag issuewild -CaaValue "contoso.org"
	#$record = $record | Remove-AzDnsRecordConfig -CaaFlags 1 -CaaTag issuewild -CaaValue "contoso.org"

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CAA
	
	Assert-AreEqual 1 $getResult.Records.Count
	Validate-CAARecord $getResult.Records[0] 0 "issue" "contoso.org"

	$listResult = Get-AzDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CAA

	Assert-AreEqual 1 $listResult[0].Records.Count
	Validate-CAARecord $listResult.Records[0] 0 "issue" "contoso.org"

	$removed = $listResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetCAANonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

    $records = @()
	$records += New-AzDnsRecordConfig  -CaaFlags 1 -CaaTag issuewild -CaaValue "contoso.org"
	$records += New-AzDnsRecordConfig  -CaaFlags 0 -CaaTag issue -CaaValue "fabrikam.com"
	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType CAA -DnsRecords $records

	$record | Set-AzDnsRecordSet
	$getResult = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CAA
	
	Assert-AreEqual 2 $getResult.Records.Count
	Validate-CAARecord $getResult.Records[0] 1 "issuewild" "contoso.org"
	Validate-CAARecord $getResult.Records[1] 0 "issue" "fabrikam.com"

	$removed = $getResult[0] | Remove-AzDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
New-AzDnsRecordSet when the record set already exists
#>
function Test-RecordSetNewAlreadyExists
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 

	$record = $zone | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType A | Add-AzDnsRecordConfig -Ipv4Address 1.2.9.8

	# error the second time
	$message = [System.String]::Format("The Record set {0} exists already and hence cannot be created again.", $recordName);
	Assert-Throws {  $zone | New-AzDnsRecordSet -Name $recordName -Ttl 212 -RecordType A } $message

	$zone | New-AzDnsRecordSet -Name $recordName -Ttl 999 -RecordType A -Overwrite -Confirm:$false

	$retrievedRecordSet = $zone | Get-AzDnsRecordSet -Name $recordName -RecordType A

	Assert-AreEqual 999 $retrievedRecordSet.Ttl
	Assert-AreEqual 0 $retrievedRecordSet.Records.Count

	$retrievedRecordSet | Remove-AzDnsRecordSet -Confirm:$false
	$zone | Remove-AzDnsZone -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetAddRecordTypeMismatch
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $recordSet = TestSetup-CreateResourceGroup | New-AzDnsZone -Name $zoneName | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType MX
	
	Assert-Throws { $recordSet | Add-AzDnsRecordConfig -Ipv6Address 3::90 } "Cannot add a record of type AAAA to a record set of type MX. The types must match."

	$recordSet | Remove-AzDnsRecordSet -Confirm:$false
	Remove-AzDnsZone -Name $recordSet.ZoneName -ResourceGroupName $recordSet.ResourceGroupName -Confirm:$false
}

function Test-RecordSetAddTwoCnames
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname

    $recordSet = TestSetup-CreateResourceGroup | New-AzDnsZone -Name $zoneName | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType CNAME 
	$resourceGroupName = $recordSet.ResourceGroupName

	$recordSet | Add-AzDnsRecordConfig -Cname www.goril.la
	Assert-Throws { $recordSet | Add-AzDnsRecordConfig -Cname rubadub.dub } "There already exists a CNAME record in this set. A CNAME record set can only contain one record."
	Assert-AreEqual 1 $recordSet.Records.Count

	$recordSet | Remove-AzDnsRecordConfig -Cname www.goril.la
	$recordSet | Add-AzDnsRecordConfig -Cname rubadub.dub

	Assert-AreEqual 1 $recordSet.Records.Count
	Assert-AreEqual rubadub.dub $recordSet.Records[0].Cname

	$recordSet | Remove-AzDnsRecordSet -Confirm:$false
	Remove-AzDnsZone -Name $recordSet.ZoneName -ResourceGroupName $recordSet.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetRemoveRecordTypeMismatch
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $recordSet = TestSetup-CreateResourceGroup | New-AzDnsZone -Name $zoneName | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType TXT
	$resourceGroupName = $recordSet.ResourceGroupName

	Assert-Throws { $recordSet | Remove-AzDnsRecordConfig -Nsdname nsa.fed.gov } "Cannot remove a record of type NS from a record set of type TXT. The types must match."

	$recordSet | Remove-AzDnsRecordSet -Confirm:$false
	Remove-AzDnsZone -Name $recordSet.ZoneName -ResourceGroupName $recordSet.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Record Set Etag Mismatch
#>
function Test-RecordSetEtagMismatch
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $recordSet = TestSetup-CreateResourceGroup | New-AzDnsZone -Name $zoneName | New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType AAAA
	$originalEtag = $recordSet.Etag
	$recordSet.Etag = "gibberish"

	$message = [System.String]::Format("The Record set {0} has been modified (etag mismatch).", $recordName);
	Assert-Throws { $recordSet | Set-AzDnsRecordSet } $message

	$updatedRecordSet = $recordSet | Set-AzDnsRecordSet -Overwrite

	Assert-AreNotEqual "gibberish" $updatedRecordSet.Etag
	Assert-AreNotEqual $recordSet.Etag $updatedRecordSet.Etag

	$message = [System.String]::Format("The Record set {0} has been modified (etag mismatch).", $recordName);
	Assert-Throws { $recordSet | Remove-AzDnsRecordSet -Confirm:$false } $message

	Assert-True { $recordSet | Remove-AzDnsRecordSet -Overwrite -Confirm:$false -PassThru }

	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $recordSet.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $recordSet.ResourceGroupName -Force
}

<#
.SYNOPSIS
Record Set Get
#>
function Test-RecordSetGet
{
	$zoneName = Get-RandomZoneName
	$recordName1 = getAssetname
	$recordName2 = getAssetname
	$recordName3 = getAssetname

	$zone = TestSetup-CreateResourceGroup | New-AzDnsZone -Name $zoneName
	$resourceGroupName = $zone.ResourceGroupName

	# test for root records
	$nsRecords = Get-AzDnsRecordSet -Zone $zone -RecordType NS
	$soaRecords = Get-AzDnsRecordSet -Zone $zone -RecordType SOA

	Assert-AreEqual 1 $nsRecords.Count
	Assert-AreEqual 1 $soaRecords.Count

	# test for non-root records

    New-AzDnsRecordSet -Zone $zone -Name $recordName1 -Ttl 100 -RecordType AAAA
	New-AzDnsRecordSet -Zone $zone -Name $recordName2 -Ttl 1200 -RecordType AAAA
	New-AzDnsRecordSet -Zone $zone -Name $recordName3 -Ttl 1500 -RecordType MX

	$aaaaRecords = $zone | Get-AzDnsRecordSet -RecordType AAAA
	$mxRecords = $zone | Get-AzDnsRecordSet -RecordType MX

	Assert-AreEqual 2 $aaaaRecords.Count
	Assert-AreEqual 1 $mxRecords.Count

	# all records
	$allRecords = Get-AzDnsRecordSet -Zone $zone

	Assert-AreEqual 5 $allRecords.Count
	
	$zone | Remove-AzDnsRecordSet -Name $recordName1 -RecordType AAAA -Confirm:$false
	$zone | Remove-AzDnsRecordSet -Name $recordName2 -RecordType AAAA -Confirm:$false
	$zone | Remove-AzDnsRecordSet -Name $recordName3 -RecordType MX -Confirm:$false

	$zone | Remove-AzDnsZone -Confirm:$false -Overwrite
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Record Set Get using EndsWith parameter
#>
function Test-RecordSetGetWithEndsWith
{
	$rootRecordName = "@"
	$recordSuffix = ".com"
	$anotherSuffix = ".con"

	$zoneName = Get-RandomZoneName

	$recordName1 = (getAssetname) + $recordSuffix
	$recordName2 = (getAssetname) + $anotherSuffix
	$recordName3 = (getAssetname) + $recordSuffix

	$zone = TestSetup-CreateResourceGroup | New-AzDnsZone -Name $zoneName
	$resourceGroupName = $zone.ResourceGroupName

	# test for root records
	$rootRecords = $zone | Get-AzDnsRecordSet -EndsWith $rootRecordName

	Assert-AreEqual 2 $rootRecords.Count -Message ("Expected 2 root records. Actual: " + $rootRecords.Count)
	
    New-AzDnsRecordSet -Zone $zone -Name $recordName1 -Ttl 100 -RecordType AAAA
	New-AzDnsRecordSet -Zone $zone -Name $recordName2 -Ttl 1200 -RecordType AAAA
	New-AzDnsRecordSet -Zone $zone -Name $recordName3 -Ttl 1500 -RecordType MX

	# test for records within type
	$aaaaRecords = $zone | Get-AzDnsRecordSet -RecordType AAAA -EndsWith $recordSuffix
	$mxRecords = $zone | Get-AzDnsRecordSet -RecordType MX -EndsWith $recordSuffix

	Assert-AreEqual 1 $aaaaRecords.Count -Message ("Expected 1 AAAA record. Actual: " + $aaaaRecords.Count)
	Assert-AreEqual 1 $mxRecords.Count -Message ("Expected 1 MX record. Actual: " + $mxRecords.Count)

	# all records
	$allRecords = $zone | Get-AzDnsRecordSet -EndsWith $recordSuffix

	Assert-AreEqual 2 $allRecords.Count -Message ("Expected 2 records across types. Actual: " + $allRecords.Count)

	$zone | Remove-AzDnsRecordSet -Name $recordName1 -RecordType AAAA -Confirm:$false
	$zone | Remove-AzDnsRecordSet -Name $recordName2 -RecordType AAAA -Confirm:$false
	$zone | Remove-AzDnsRecordSet -Name $recordName3 -RecordType MX -Confirm:$false

	$zone | Remove-AzDnsZone -Confirm:$false -Overwrite
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Record Set Name incorrectly entered includes Zone Name
#>
function Test-RecordSetEndsWithZoneName
{
	$zoneName = Get-RandomZoneName
	$recordName = (getAssetname) + "." + $zoneName
	$resourceGroup = TestSetup-CreateResourceGroup
	$zone = New-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$message = [System.String]::Format("The relative record set name `"{0}`" includes the zone name `"{1}`". This will result in the set name `"{0}.{1}`". Usage of this cmdlet without DnsRecords parameter will be deprecated soon. If there is a need to create empty record set, please specify DnsRecords parameter with an empty array as value Microsoft.Azure.Commands.Dns.DnsRecordSet", $recordName, $zoneName);
	 $warning = (New-AzDnsRecordSet -Name $recordName -RecordType A -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Ttl 100) 3>&1

	Assert-AreEqual $message $warning

	Remove-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A -PassThru -Confirm:$false
	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetNewRecordNoName
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzDnsZone -Name $zoneName 
	$recordSet = New-AzDnsRecordSet -Name $recordName -Ttl 100 -RecordType MX -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName
	$recordSet = Get-AzDnsRecordSet -ResourceGroupName $resourceGroup.ResourceGroupName -ZoneName $zoneName -RecordType MX
	$record1 = Add-AzDnsRecordConfig -Exchange mail1.theg.com -Preference 1 -RecordSet $recordSet
	$recordSet | Set-AzDnsRecordSet
	$getRecordSetOne = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX 
	Assert-AreEqual 1 $getRecordSetOne.Records.Count

	$record2 = Add-AzDnsRecordConfig -Exchange mail2.theg.com -Preference 10 -RecordSet $getRecordSetOne
	$getRecordSetOne | Set-AzDnsRecordSet
	$getRecordSetTwo = Get-AzDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX
	Assert-AreEqual 2 $getRecordSetTwo.Records.Count

	$record1 = $record1 | Remove-AzDnsRecordConfig -Exchange mail1.theg.com -Preference 1
	$record2 = $record2 | Remove-AzDnsRecordConfig -Exchange mail2.theg.com -Preference 10
	$removed = $getRecordSetTwo | Remove-AzDnsRecordSet -Confirm:$false -PassThru
	Assert-True { $removed }
	Remove-AzDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false

	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}