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
	$zoneName = getAssetname
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	$zone = New-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$createdRecord = New-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Ttl 100 -RecordType A -Tags @{Name="tag1";Value="val1"}

	Assert-NotNull $createdRecord
	Assert-NotNull $createdRecord.Etag
	Assert-AreEqual 100 $createdRecord.Ttl
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $recordName $createdRecord.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdRecord.ResourceGroupName 
	Assert-AreEqual 1 $createdRecord.Tags.Count
	Assert-AreEqual 0 $createdRecord.Records.Count

	$retrievedRecord = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName
	Assert-AreEqual $retrievedRecord.Etag $createdRecord.Etag
	Assert-AreEqual 1 $retrievedRecord.Tags.Count
	Assert-AreEqual 0 $retrievedRecord.Records.Count
	# broken by service bug
	# Assert-AreEqual 100 $createdRecord.Ttl

	# TODO: change and pipe in retrievedRecord, not createdRecord but this is currently broken by a service bug
	$createdRecord.Tags = @{Name="tag1";Value="val1"},@{Name="tag2";Value="val2"}
	$createdRecord.Ttl = 1300
	$updatedRecord = $createdRecord | Add-AzureRmDnsRecordConfig -Ipv4Address 13.13.0.13 | Set-AzureRmDnsRecordSet

	Assert-NotNull $updatedRecord
	Assert-NotNull $updatedRecord.Etag
	Assert-AreEqual $recordName $updatedRecord.Name 
	Assert-AreEqual $zoneName $updatedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $updatedRecord.ResourceGroupName
	Assert-AreEqual 1300 $updatedRecord.Ttl
	Assert-AreNotEqual $updatedRecord.Etag $createdRecord.Etag
	Assert-AreEqual 2 $updatedRecord.Tags.Count
	Assert-AreEqual 1 $updatedRecord.Records.Count
	Assert-AreEqual "13.13.0.13" $updatedRecord.Records[0].Ipv4Address

	$retrievedRecord = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName
	Assert-AreEqual $retrievedRecord.Etag $updatedRecord.Etag
	Assert-AreEqual 2 $retrievedRecord.Tags.Count
	Assert-AreEqual 1 $retrievedRecord.Records.Count
	Assert-AreEqual "13.13.0.13" $retrievedRecord.Records[0].Ipv4Address
	# broken by service bug
	# Assert-AreEqual 1300 $createdRecord.Ttl

	$removed = Remove-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A -PassThru -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A } "ResourceNotFound: Resource not found."

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle trims terminating dot from zone name
#>
function Test-RecordSetCrudTrimsDotFromZoneName
{
	$zoneName = getAssetname
	$zoneNameWithDot = $zoneName + "."

	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	$zone = New-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$createdRecord = New-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -Ttl 100 -RecordType A -Tags @{Name="tag1";Value="val1"}

	Assert-NotNull $createdRecord
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $recordName $createdRecord.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdRecord.ResourceGroupName 

	$retrievedRecord = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName

	$retrievedRecord = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName

	$removed = Remove-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A -PassThru -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A } "ResourceNotFound: Resource not found."

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetCrudWithPiping
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $updatedRecord = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType A -Tags @{Name="tag1";Value="val1"} | Add-AzureRmDnsRecordConfig -Ipv4Address 13.13.0.13 | Set-AzureRmDnsRecordSet

	Assert-NotNull $updatedRecord
	Assert-NotNull $updatedRecord.Etag
	Assert-AreEqual $recordName $updatedRecord.Name 
	Assert-AreEqual $zoneName $updatedRecord.ZoneName 
	Assert-NotNull $updatedRecord.ResourceGroupName
	Assert-AreEqual 1 $updatedRecord.Tags.Count
	Assert-AreEqual 1 $updatedRecord.Records.Count
	Assert-AreEqual "13.13.0.13" $updatedRecord.Records[0].Ipv4Address

	$removed = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -RecordType A | Remove-AzureRmDnsRecordSet -PassThru -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -RecordType A } "ResourceNotFound: Resource not found."

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetCrudWithPipingTrimsDotFromZoneName
{
	$zoneName = getAssetname
	$zoneNameWithDot = $zoneName + "."

	$recordName = getAssetname
    $zone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName
	
	$zoneObjectWithDot = New-Object Microsoft.Azure.Commands.Dns.DnsZone
	$zoneObjectWithDot.Name = $zoneNameWithDot
	$zoneObjectWithDot.ResourceGroupName = $zone.ResourceGroupName
	
	$createdRecord = $zoneObjectWithDot | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType A -Tags @{Name="tag1";Value="val1"}

	Assert-NotNull $createdRecord
	Assert-AreEqual $recordName $createdRecord.Name 
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $zone.ResourceGroupName $createdRecord.ResourceGroupName

	$recordObjectWithDot = New-Object Microsoft.Azure.Commands.Dns.DnsRecordSet
	$recordObjectWithDot.Name = $recordName
	$recordObjectWithDot.ZoneName = $zoneNameWithDot
	$recordObjectWithDot.ResourceGroupName = $zone.ResourceGroupName
	$recordObjectWithDot.Ttl = 60

	$recordAfterAdd = $recordObjectWithDot | Add-AzureRmDnsRecordConfig -Ipv4Address 13.13.0.13

	# this is an offline operation, we don't check the dot and don't change the object in place
	Assert-AreEqual $zoneNameWithDot $recordAfterAdd.ZoneName 

	$updatedRecord = $recordAfterAdd | Set-AzureRmDnsRecordSet -Overwrite

	Assert-NotNull $updatedRecord
	Assert-AreEqual $recordName $updatedRecord.Name 
	Assert-AreEqual $zoneName $updatedRecord.ZoneName 
	Assert-AreEqual $zone.ResourceGroupName $updatedRecord.ResourceGroupName

	$retrievedRecord = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $zone.ResourceGroupName -RecordType A 
	
	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $zone.ResourceGroupName $updatedRecord.ResourceGroupName
	
	$removed = $recordObjectWithDot | Remove-AzureRmDnsRecordSet -Overwrite -PassThru -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -RecordType A } "ResourceNotFound: Resource not found."

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $zone.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetA
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzureRmDnsZone -Name $zoneName 

	$record = $zone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType A 

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzureRmDnsRecordConfig -Ipv4Address 1.1.1.1
	$record = $record | Add-AzureRmDnsRecordConfig -Ipv4Address 2.2.2.2
	$record = $record | Remove-AzureRmDnsRecordConfig -Ipv4Address 1.1.1.1
	$record = $record | Remove-AzureRmDnsRecordConfig -Ipv4Address 3.3.3.3

	$record | Set-AzureRmDnsRecordSet
	$getResult = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "2.2.2.2" $getResult.Records[0].Ipv4Address

	$listResult = Get-AzureRmDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual "2.2.2.2" $listResult[0].Records[0].Ipv4Address

	$removed = $listResult[0] | Remove-AzureRmDnsRecordSet -Force -PassThru

	Assert-True { $removed }

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetAAAA
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzureRmDnsZone -Name $zoneName 

	$record = $zone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType AAAA

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzureRmDnsRecordConfig -Ipv6Address 1::11
	$record = $record | Add-AzureRmDnsRecordConfig -Ipv6Address 2::22
	$record = $record | Add-AzureRmDnsRecordConfig -Ipv6Address 4::44
	$record = $record | Remove-AzureRmDnsRecordConfig -Ipv6Address 2::22
	$record = $record | Remove-AzureRmDnsRecordConfig -Ipv6Address 3::33

	$record | Set-AzureRmDnsRecordSet
	$getResult = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType AAAA 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "1::11" $getResult.Records[0].Ipv6Address
	Assert-AreEqual "4::44" $getResult.Records[1].Ipv6Address

	$listResult = Get-AzureRmDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType AAAA

	Assert-AreEqual 2 $listResult[0].Records.Count
	Assert-AreEqual "1::11" $listResult[0].Records[0].Ipv6Address
	Assert-AreEqual "4::44" $listResult[0].Records[1].Ipv6Address

	$removed = $listResult[0] | Remove-AzureRmDnsRecordSet -Force -PassThru

	Assert-True { $removed }

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetCNAME
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzureRmDnsZone -Name $zoneName 

	$record = $zone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType CNAME

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzureRmDnsRecordConfig -Cname www.example.com
	$record = $record | Remove-AzureRmDnsRecordConfig -Cname www.example.com
	$record = $record | Add-AzureRmDnsRecordConfig -Cname www.contoso.com
	$record = $record | Remove-AzureRmDnsRecordConfig -Cname gibberish

	$record | Set-AzureRmDnsRecordSet
	$getResult = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CNAME 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "www.contoso.com" $getResult.Records[0].Cname

	$listResult = Get-AzureRmDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CNAME

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual "www.contoso.com" $listResult[0].Records[0].Cname

	$removed = $listResult[0] | Remove-AzureRmDnsRecordSet -Force -PassThru

	Assert-True { $removed }

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetMX
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzureRmDnsZone -Name $zoneName 

	$record = $zone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType MX

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzureRmDnsRecordConfig -Exchange mail1.theg.com -Preference 10
	$record = $record | Add-AzureRmDnsRecordConfig -Exchange mail2.theg.com -Preference 10
	$record = $record | Remove-AzureRmDnsRecordConfig -Exchange mail1.theg.com -Preference 10
	$record = $record | Remove-AzureRmDnsRecordConfig -Exchange mail2.theg.com -Preference 15

	$record | Set-AzureRmDnsRecordSet
	$getResult = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "mail2.theg.com" $getResult.Records[0].Exchange
	Assert-AreEqual 10 $getResult.Records[0].Preference

	$listResult = Get-AzureRmDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual "mail2.theg.com" $listResult[0].Records[0].Exchange
	Assert-AreEqual 10 $listResult[0].Records[0].Preference

	$removed = $listResult[0] | Remove-AzureRmDnsRecordSet -Force -PassThru

	Assert-True { $removed }

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetNS
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzureRmDnsZone -Name $zoneName 

	$record = $zone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType NS

	# add three records, remove one, remove another no-op
	$record = $record | Add-AzureRmDnsRecordConfig -Nsdname ns1.example.com
	$record = $record | Add-AzureRmDnsRecordConfig -Nsdname ns2.example.com
	$record = $record | Add-AzureRmDnsRecordConfig -Nsdname ns3.example.com
	$record = $record | Remove-AzureRmDnsRecordConfig -Nsdname ns3.example.com
	$record = $record | Remove-AzureRmDnsRecordConfig -Nsdname ns4.example.com

	$record | Set-AzureRmDnsRecordSet
	$getResult = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType NS 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "ns1.example.com" $getResult.Records[0].Nsdname
	Assert-AreEqual "ns2.example.com" $getResult.Records[1].Nsdname

	$listResult = Get-AzureRmDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType NS

	# the authoritative NS record set will be the first result
	Assert-AreEqual 2 $listResult.Count
	Assert-AreEqual 2 $listResult[1].Records.Count
	Assert-AreEqual "ns1.example.com" $listResult[1].Records[0].Nsdname
	Assert-AreEqual "ns2.example.com" $listResult[1].Records[1].Nsdname

	$removed = $listResult[1] | Remove-AzureRmDnsRecordSet -Force -PassThru

	Assert-True { $removed }

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetTXT
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzureRmDnsZone -Name $zoneName 

	$record = $zone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType TXT

	# add three records, remove one, remove another no-op
	$record = $record | Add-AzureRmDnsRecordConfig -Value text1
	$record = $record | Add-AzureRmDnsRecordConfig -Value text2
	$record = $record | Add-AzureRmDnsRecordConfig -Value text3
	$record = $record | Remove-AzureRmDnsRecordConfig -Value text1
	$record = $record | Remove-AzureRmDnsRecordConfig -Value text4

	$record | Set-AzureRmDnsRecordSet
	$getResult = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual text2 $getResult.Records[0].Value
	Assert-AreEqual text3 $getResult.Records[1].Value

	$listResult = Get-AzureRmDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT

	Assert-AreEqual 2 $listResult[0].Records.Count
	Assert-AreEqual text2 $listResult[0].Records[0].Value
	Assert-AreEqual text3 $listResult[0].Records[1].Value

	$removed = $listResult[0] | Remove-AzureRmDnsRecordSet -Force -PassThru

	Assert-True { $removed }

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetSRV
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzureRmDnsZone -Name $zoneName 

	$record = $zone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType SRV

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzureRmDnsRecordConfig -Port 53 -Priority 1 -Target ns1.example.com -Weight 5
	$record = $record | Add-AzureRmDnsRecordConfig -Port 53 -Priority 2 -Target ns2.example.com -Weight 10
	$record = $record | Remove-AzureRmDnsRecordConfig -Port 53 -Priority 2 -Target ns2.example.com -Weight 10
	$record = $record | Remove-AzureRmDnsRecordConfig -Port 42 -Priority 999 -Target ns5.example.com -Weight 1600

	$record | Set-AzureRmDnsRecordSet
	$getResult = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SRV 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual 53 $getResult.Records[0].Port
	Assert-AreEqual 1 $getResult.Records[0].Priority
	Assert-AreEqual ns1.example.com $getResult.Records[0].Target
	Assert-AreEqual 5 $getResult.Records[0].Weight

	$listResult = Get-AzureRmDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SRV

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual 53 $listResult[0].Records[0].Port
	Assert-AreEqual 1 $listResult[0].Records[0].Priority
	Assert-AreEqual ns1.example.com $listResult[0].Records[0].Target
	Assert-AreEqual 5 $listResult[0].Records[0].Weight

	$removed = $listResult[0] | Remove-AzureRmDnsRecordSet -Force -PassThru

	Assert-True { $removed }

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetSOA
{
	$zoneName = getAssetname
	$recordName = "@"
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzureRmDnsZone -Name $zoneName 

	$record = $zone | Get-AzureRmDnsRecordSet -Name $recordName -RecordType SOA

	# can only update SOA values, can't add or remove
	Assert-AreEqual 1 $record.Count
	$record.Records[0].RefreshTime = 13
	$record.Records[0].RetryTime = 666
	$record.Records[0].ExpireTime = 42
	$record.Records[0].MinimumTtl = 321
	$record.Ttl = 110901

	$record | Set-AzureRmDnsRecordSet
	$getResult = Get-AzureRmDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SOA 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual 13 $getResult.Records[0].RefreshTime
	Assert-AreEqual 666 $getResult.Records[0].RetryTime
	Assert-AreEqual 42 $getResult.Records[0].ExpireTime
	Assert-AreEqual 321 $getResult.Records[0].MinimumTtl
	Assert-AreEqual 110901 $getResult.Ttl

	$listResult = Get-AzureRmDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SOA

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual 13 $listResult[0].Records[0].RefreshTime
	Assert-AreEqual 666 $listResult[0].Records[0].RetryTime
	Assert-AreEqual 42 $listResult[0].Records[0].ExpireTime
	Assert-AreEqual 321 $listResult[0].Records[0].MinimumTtl
	Assert-AreEqual 110901 $listResult[0].Ttl

	Assert-Throws { $listResult[0] | Remove-AzureRmDnsRecordSet -Force -PassThru } "BadRequest: Records of type 'SOA' cannot be deleted."

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
New-AzureRmDnsRecordSet when the record set already exists
#>
function Test-RecordSetNewAlreadyExists
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = $resourceGroup | New-AzureRmDnsZone -Name $zoneName 

	$record = $zone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType A | Add-AzureRmDnsRecordConfig -Ipv4Address 1.2.9.8

	# error the second time
	Assert-Throws {  $zone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 212 -RecordType A } "PreconditionFailed: The condition '*' in the If-None-Match header was not satisfied. The current was 'n/a'."

	$zone | New-AzureRmDnsRecordSet -Name $recordName -Ttl 999 -RecordType A -Overwrite -Force

	$retrievedRecordSet - $zone | Get-AzureRmDnsRecordSet -Name $recordName -RecordType A

	Assert-AreEqual 999 $retrievedRecordSet.Ttl
	Assert-AreEqual 2 $retrievedRecordSet.Records.Count

	$retrievedRecordSet | Remove-AzureRmDnsRecordSet -Force
	$zone | Remove-AzureRmDnsZone -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetAddRecordTypeMismatch
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $recordSet = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType MX
	
	Assert-Throws { $recordSet | Add-AzureRmDnsRecordConfig -Ipv6Address 3::90 } "Cannot add a record of type AAAA to a record set of type MX. The types must match."

	$recordSet | Remove-AzureRmDnsRecordSet -Force
	Remove-AzureRmDnsZone -Name $recordSet.ZoneName -ResourceGroupName $recordSet.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetAddTwoCnames
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $recordSet = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType CNAME
	
	$recordSet | Add-AzureRmDnsRecordConfig -Cname www.goril.la
	Assert-Throws { $recordSet | Add-AzureRmDnsRecordConfig -Cname rubadub.dub } "There already exists a CNAME record in this set. A CNAME record set can only contain one record."
	Assert-AreEqual 1 $recordSet.Records.Count

	$recordSet | Remove-AzureRmDnsRecordConfig -Cname www.goril.la
	$recordSet | Add-AzureRmDnsRecordConfig -Cname rubadub.dub

	Assert-AreEqual 1 $recordSet.Records.Count
	Assert-AreEqual rubadub.dub $recordSet.Records[0].Cname

	$recordSet | Remove-AzureRmDnsRecordSet -Force
	Remove-AzureRmDnsZone -Name $recordSet.ZoneName -ResourceGroupName $recordSet.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle
#>
function Test-RecordSetRemoveRecordTypeMismatch
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $recordSet = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType TXT
	
	Assert-Throws { $recordSet | Remove-AzureRmDnsRecordConfig -Nsdname nsa.fed.gov } "Cannot remove a record of type NS from a record set of type TXT. The types must match."

	$recordSet | Remove-AzureRmDnsRecordSet -Force
	Remove-AzureRmDnsZone -Name $recordSet.ZoneName -ResourceGroupName $recordSet.ResourceGroupName -Force
}

<#
.SYNOPSIS
Record Set Etag Mismatch
#>
function Test-RecordSetEtagMismatch
{
	$zoneName = getAssetname
	$recordName = getAssetname
    $recordSet = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName | New-AzureRmDnsRecordSet -Name $recordName -Ttl 100 -RecordType AAAA
	$originalEtag = $recordSet.Etag
	$recordSet.Etag = "gibberish"

	Assert-Throws { $recordSet | Set-AzureRmDnsRecordSet } "PreconditionFailed: The condition 'gibberish' in the If-Match header was not satisfied. The current was '$originalEtag'."

	$updatedRecordSet = $recordSet | Set-AzureRmDnsRecordSet -Overwrite

	Assert-AreNotEqual "gibberish" $updatedRecordSet.Etag
	Assert-AreNotEqual $recordSet.Etag $updatedRecordSet.Etag

	Assert-Throws { $recordSet | Remove-AzureRmDnsRecordSet -Force } "PreconditionFailed: The condition 'gibberish' in the If-Match header was not satisfied. The current was '$($updatedRecordSet.Etag)'."

	Assert-True { $recordSet | Remove-AzureRmDnsRecordSet -Overwrite -Force -PassThru }

	Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $recordSet.ResourceGroupName -Force
}

<#
.SYNOPSIS
Record Set Get
#>
function Test-RecordSetGet
{
	$zoneName = getAssetname
	$recordName1 = getAssetname
	$recordName2 = getAssetname
	$recordName3 = getAssetname

	$zone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName

	# test for root records
	$nsRecords = Get-AzureRmDnsRecordSet -Zone $zone -RecordType NS
	$soaRecords = Get-AzureRmDnsRecordSet -Zone $zone -RecordType SOA

	Assert-AreEqual 1 $nsRecords.Count
	Assert-AreEqual 1 $soaRecords.Count

	# test for non-root records

    New-AzureRmDnsRecordSet -Zone $zone -Name $recordName1 -Ttl 100 -RecordType AAAA
	New-AzureRmDnsRecordSet -Zone $zone -Name $recordName2 -Ttl 1200 -RecordType AAAA
	New-AzureRmDnsRecordSet -Zone $zone -Name $recordName3 -Ttl 1500 -RecordType MX

	$aaaaRecords = $zone | Get-AzureRmDnsRecordSet -RecordType AAAA
	$mxRecords = $zone | Get-AzureRmDnsRecordSet -RecordType MX

	Assert-AreEqual 2 $aaaaRecords.Count
	Assert-AreEqual 1 $mxRecords.Count

	# all records
	$allRecords = Get-AzureRmDnsRecordSet -Zone $zone

	Assert-AreEqual 5 $allRecords.Count
	
	$zone | Remove-AzureRmDnsRecordSet -Name $recordName1 -RecordType AAAA -Force
	$zone | Remove-AzureRmDnsRecordSet -Name $recordName2 -RecordType AAAA -Force
	$zone | Remove-AzureRmDnsRecordSet -Name $recordName3 -RecordType MX -Force

	$zone | Remove-AzureRmDnsZone -Force -Overwrite
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

	$zoneName = getAssetname

	$recordName1 = (getAssetname) + $recordSuffix
	$recordName2 = (getAssetname) + $anotherSuffix
	$recordName3 = (getAssetname) + $recordSuffix

	$zone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName

	# test for root records
	$rootRecords = $zone | Get-AzureRmDnsRecordSet -EndsWith $rootRecordName

	Assert-AreEqual 2 $rootRecords.Count -Message ("Expected 2 root records. Actual: " + $rootRecords.Count)
	
    New-AzureRmDnsRecordSet -Zone $zone -Name $recordName1 -Ttl 100 -RecordType AAAA
	New-AzureRmDnsRecordSet -Zone $zone -Name $recordName2 -Ttl 1200 -RecordType AAAA
	New-AzureRmDnsRecordSet -Zone $zone -Name $recordName3 -Ttl 1500 -RecordType MX

	# test for records within type
	$aaaaRecords = $zone | Get-AzureRmDnsRecordSet -RecordType AAAA -EndsWith $recordSuffix
	$mxRecords = $zone | Get-AzureRmDnsRecordSet -RecordType MX -EndsWith $recordSuffix

	Assert-AreEqual 1 $aaaaRecords.Count -Message ("Expected 1 AAAA record. Actual: " + $aaaaRecords.Count)
	Assert-AreEqual 1 $mxRecords.Count -Message ("Expected 1 MX record. Actual: " + $mxRecords.Count)

	# all records
	$allRecords = $zone | Get-AzureRmDnsRecordSet -EndsWith $recordSuffix

	Assert-AreEqual 2 $allRecords.Count -Message ("Expected 2 records across types. Actual: " + $allRecords.Count)

	$zone | Remove-AzureRmDnsRecordSet -Name $recordName1 -RecordType AAAA -Force
	$zone | Remove-AzureRmDnsRecordSet -Name $recordName2 -RecordType AAAA -Force
	$zone | Remove-AzureRmDnsRecordSet -Name $recordName3 -RecordType MX -Force

	$zone | Remove-AzureRmDnsZone -Force -Overwrite
}