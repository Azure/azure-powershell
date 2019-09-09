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
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$createdRecord = New-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Ttl 100 -RecordType A -Metadata @{ tag1 ="val1"}

	Assert-NotNull $createdRecord
	Assert-NotNull $createdRecord.Etag
	Assert-AreEqual 100 $createdRecord.Ttl
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $recordName $createdRecord.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdRecord.ResourceGroupName 
	Assert-AreEqual 1 $createdRecord.Metadata.Count
	Assert-AreEqual 0 $createdRecord.Records.Count

	$retrievedRecord = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName
	Assert-AreEqual $retrievedRecord.Etag $createdRecord.Etag
	Assert-AreEqual 1 $retrievedRecord.Metadata.Count
	Assert-AreEqual 0 $retrievedRecord.Records.Count

	$createdRecord.Metadata = @{ tag1 = "val1"; tag2 = "val2"}
	$createdRecord.Ttl = 1300
	$updatedRecord = $createdRecord | Add-AzPrivateDnsRecordConfig -Ipv4Address 13.13.0.13 | Set-AzPrivateDnsRecordSet

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

	$retrievedRecord = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName
	Assert-AreEqual $retrievedRecord.Etag $updatedRecord.Etag
	Assert-AreEqual 2 $retrievedRecord.Metadata.Count
	Assert-AreEqual 1 $retrievedRecord.Records.Count
	Assert-AreEqual "13.13.0.13" $retrievedRecord.Records[0].Ipv4Address

	$removed = Remove-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A } "*does not exist*"

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
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
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$createdRecord = New-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -Ttl 100 -RecordType A -Metadata @{tag1 = "val1"}

	Assert-NotNull $createdRecord
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $recordName $createdRecord.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdRecord.ResourceGroupName 

	$retrievedRecord = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName

	$retrievedRecord = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName

	$removed = Remove-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A } "*does not exist*"

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle with piping
#>
function Test-RecordSetCrudWithPiping
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup 
    $zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName
	$updatedRecord = New-AzPrivateDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName  -Name $recordName -Ttl 100 -RecordType A -Metadata @{tag1 = "val1"} | Add-AzPrivateDnsRecordConfig -Ipv4Address 13.13.0.13 | Set-AzPrivateDnsRecordSet

	$resourceGroupName = $updatedRecord.ResourceGroupName
	Assert-NotNull $updatedRecord
	Assert-NotNull $updatedRecord.Etag
	Assert-AreEqual $recordName $updatedRecord.Name 
	Assert-AreEqual $zoneName $updatedRecord.ZoneName 
	Assert-NotNull $updatedRecord.ResourceGroupName
	Assert-AreEqual 1 $updatedRecord.Metadata.Count
	Assert-AreEqual 1 $updatedRecord.Records.Count
	Assert-AreEqual "13.13.0.13" $updatedRecord.Records[0].Ipv4Address

	$removed = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -RecordType A | Remove-AzPrivateDnsRecordSet -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -RecordType A } "*does not exist*"

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle with zone name ending with dot
#>
function Test-RecordSetCrudWithPipingTrimsDotFromZoneName
{
	$zoneName = Get-RandomZoneName
	$zoneNameWithDot = $zoneName + "."

	$recordName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup
    $zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName
	
	$zoneObjectWithDot = New-Object Microsoft.Azure.Commands.PrivateDns.Models.PSPrivateDnsZone
	$zoneObjectWithDot.Name = $zoneNameWithDot
	$zoneObjectWithDot.ResourceGroupName = $zone.ResourceGroupName
	
	$createdRecord = New-AzPrivateDnsRecordSet -ZoneName $zoneObjectWithDot.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType A -Metadata @{ tag1 ="val1"}

	Assert-NotNull $createdRecord
	Assert-AreEqual $recordName $createdRecord.Name 
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $zone.ResourceGroupName $createdRecord.ResourceGroupName

	$recordObjectWithDot = New-Object Microsoft.Azure.Commands.PrivateDns.Models.PSPrivateDnsRecordSet
	$recordObjectWithDot.Name = $recordName
	$recordObjectWithDot.ZoneName = $zoneNameWithDot
	$recordObjectWithDot.ResourceGroupName = $zone.ResourceGroupName
	$recordObjectWithDot.Ttl = 60

	$recordAfterAdd = $recordObjectWithDot | Add-AzPrivateDnsRecordConfig -Ipv4Address 13.13.0.13

	# this is an offline operation, we don't check the dot and don't change the object in place
	Assert-AreEqual $zoneNameWithDot $recordAfterAdd.ZoneName 

	$updatedRecord = $recordAfterAdd | Set-AzPrivateDnsRecordSet -Overwrite

	Assert-NotNull $updatedRecord
	Assert-AreEqual $recordName $updatedRecord.Name 
	Assert-AreEqual $zoneName $updatedRecord.ZoneName 
	Assert-AreEqual $zone.ResourceGroupName $updatedRecord.ResourceGroupName

	$retrievedRecord = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneNameWithDot -ResourceGroupName $zone.ResourceGroupName -RecordType A 
	
	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $zone.ResourceGroupName $updatedRecord.ResourceGroupName
	
	$removed = $recordObjectWithDot | Remove-AzPrivateDnsRecordSet -Overwrite -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $updatedRecord.ResourceGroupName -RecordType A } "*does not exist*"

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $zone.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $zone.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full Record Set CRUD cycle with resource id of zone
#>
function Test-RecordSetCrudWithZoneResourceId
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$createdRecord = New-AzPrivateDnsRecordSet -Name $recordName -ParentResourceId $zone.ResourceId -Ttl 100 -RecordType A -Metadata @{ tag1 ="val1"}

	Assert-NotNull $createdRecord
	Assert-NotNull $createdRecord.Etag
	Assert-AreEqual 100 $createdRecord.Ttl
	Assert-AreEqual $zoneName $createdRecord.ZoneName 
	Assert-AreEqual $recordName $createdRecord.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdRecord.ResourceGroupName 
	Assert-AreEqual 1 $createdRecord.Metadata.Count
	Assert-AreEqual 0 $createdRecord.Records.Count

	$retrievedRecord = Get-AzPrivateDnsRecordSet -Name $recordName -ParentResourceId $zone.ResourceId -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName
	Assert-AreEqual $retrievedRecord.Etag $createdRecord.Etag
	Assert-AreEqual 1 $retrievedRecord.Metadata.Count
	Assert-AreEqual 0 $retrievedRecord.Records.Count

	$createdRecord.Metadata = @{ tag1 = "val1"; tag2 = "val2"}
	$createdRecord.Ttl = 1300
	$updatedRecord = $createdRecord | Add-AzPrivateDnsRecordConfig -Ipv4Address 13.13.0.13 | Set-AzPrivateDnsRecordSet

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

	$retrievedRecord = Get-AzPrivateDnsRecordSet -Name $recordName -ParentResourceId $zone.ResourceId -RecordType A

	Assert-NotNull $retrievedRecord
	Assert-AreEqual $recordName $retrievedRecord.Name 
	Assert-AreEqual $zoneName $retrievedRecord.ZoneName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedRecord.ResourceGroupName
	Assert-AreEqual $retrievedRecord.Etag $updatedRecord.Etag
	Assert-AreEqual 2 $retrievedRecord.Metadata.Count
	Assert-AreEqual 1 $retrievedRecord.Records.Count
	Assert-AreEqual "13.13.0.13" $retrievedRecord.Records[0].Ipv4Address

	$removed = Remove-AzPrivateDnsRecordSet -Name $recordName -Zone $zone -RecordType A -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A } "*does not exist*"

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force

	Remove-AzResourceGroup -Name $zone.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full A Record Set CRUD cycle
#>
function Test-RecordSetA
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType A -PrivateDnsRecords @()

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzPrivateDnsRecordConfig -Ipv4Address 1.1.1.1
	$record = $record | Add-AzPrivateDnsRecordConfig -Ipv4Address 2.2.2.2
	$record = $record | Remove-AzPrivateDnsRecordConfig -Ipv4Address 1.1.1.1
	$record = $record | Remove-AzPrivateDnsRecordConfig -Ipv4Address 3.3.3.3

	$record | Set-AzPrivateDnsRecordSet
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "2.2.2.2" $getResult.Records[0].Ipv4Address

	$listResult = Get-AzPrivateDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual "2.2.2.2" $listResult[0].Records[0].Ipv4Address

	$removed = $listResult[0] | Remove-AzPrivateDnsRecordSet -PassThru -Confirm:$false

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full non empty A Record Set CRUD cycle
#>
function Test-RecordSetANonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$aRecords=@()
	$aRecords += New-AzPrivateDnsRecordConfig -IPv4Address "192.168.0.1"
	$aRecords += New-AzPrivateDnsRecordConfig -IPv4Address "192.168.0.2"
	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType A -PrivateDnsRecords $aRecords
	
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "192.168.0.1" $getResult.Records[0].Ipv4Address
	Assert-AreEqual "192.168.0.2" $getResult.Records[1].Ipv4Address

	$listResult = Get-AzPrivateDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A

	Assert-AreEqual 2 $listResult[0].Records.Count
	Assert-AreEqual "192.168.0.1" $listResult[0].Records[0].Ipv4Address
	Assert-AreEqual "192.168.0.2" $listResult[0].Records[1].Ipv4Address

	$removed = $listResult[0] | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full AAAA Record Set CRUD cycle
#>
function Test-RecordSetAAAA
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType AAAA

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzPrivateDnsRecordConfig -Ipv6Address 1::11
	$record = $record | Add-AzPrivateDnsRecordConfig -Ipv6Address 2::22
	$record = $record | Add-AzPrivateDnsRecordConfig -Ipv6Address 4::44
	$record = $record | Remove-AzPrivateDnsRecordConfig -Ipv6Address 2::22
	$record = $record | Remove-AzPrivateDnsRecordConfig -Ipv6Address 3::33

	$record | Set-AzPrivateDnsRecordSet
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType AAAA 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "1::11" $getResult.Records[0].Ipv6Address
	Assert-AreEqual "4::44" $getResult.Records[1].Ipv6Address

	$listResult = Get-AzPrivateDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType AAAA

	Assert-AreEqual 2 $listResult[0].Records.Count
	Assert-AreEqual "1::11" $listResult[0].Records[0].Ipv6Address
	Assert-AreEqual "4::44" $listResult[0].Records[1].Ipv6Address

	$removed = $listResult[0] | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetAAAANonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$aaaaRecords=@()
	$aaaaRecords += New-AzPrivateDnsRecordConfig  -IPv6Address "2002::1"
	$aaaaRecords += New-AzPrivateDnsRecordConfig  -IPv6Address "2002::2"
	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType AAAA -PrivateDnsRecords $aaaaRecords

	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType AAAA
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "2002::1" $getResult.Records[0].Ipv6Address
	Assert-AreEqual "2002::2" $getResult.Records[1].Ipv6Address

	$removed = $getResult | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


<#
.SYNOPSIS
Full CNAME Record Set CRUD cycle
#>
function Test-RecordSetCNAME
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType CNAME

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzPrivateDnsRecordConfig -Cname www.example.com
	$record = $record | Remove-AzPrivateDnsRecordConfig -Cname www.example.com
	$record = $record | Add-AzPrivateDnsRecordConfig -Cname www.contoso.com
	$record = $record | Remove-AzPrivateDnsRecordConfig -Cname gibberish

	$record | Set-AzPrivateDnsRecordSet
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CNAME 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "www.contoso.com" $getResult.Records[0].Cname

	$listResult = Get-AzPrivateDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CNAME

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual "www.contoso.com" $listResult[0].Records[0].Cname

	$removed = $listResult[0] | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetCNAMENonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

	$records = New-AzPrivateDnsRecordConfig  -Cname "www.contoso.com"
	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType CNAME -PrivateDnsRecords $records

	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType CNAME 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "www.contoso.com" $getResult.Records[0].Cname

	$removed = $getResult | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full MX Record Set CRUD cycle
#>
function Test-RecordSetMX
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $zone.ResourceGroupName -Name $recordName -Ttl 100 -RecordType MX

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzPrivateDnsRecordConfig -Exchange mail1.theg.com -Preference 10
	$record = $record | Add-AzPrivateDnsRecordConfig -Exchange mail2.theg.com -Preference 10
	$record = $record | Remove-AzPrivateDnsRecordConfig -Exchange mail1.theg.com -Preference 10
	$record = $record | Remove-AzPrivateDnsRecordConfig -Exchange mail2.theg.com -Preference 15

	$record | Set-AzPrivateDnsRecordSet
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "mail2.theg.com" $getResult.Records[0].Exchange
	Assert-AreEqual 10 $getResult.Records[0].Preference

	$listResult = Get-AzPrivateDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual "mail2.theg.com" $listResult[0].Records[0].Exchange
	Assert-AreEqual 10 $listResult[0].Records[0].Preference

	$removed = $listResult[0] | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full non empty MX Record Set CRUD cycle
#>
function Test-RecordSetMXNonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

	$records = @();
	$records += New-AzPrivateDnsRecordConfig  -Exchange mail2.theg.com -Preference 0
	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType MX -PrivateDnsRecords $records

	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual "mail2.theg.com" $getResult.Records[0].Exchange
	Assert-AreEqual 0 $getResult.Records[0].Preference

	$removed = $getResult[0] | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full TXT Record Set CRUD cycle
#>
function Test-RecordSetTXT
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType TXT

	# add three records, remove one, remove another no-op
	$record = $record | Add-AzPrivateDnsRecordConfig -Value text1
	$record = $record | Add-AzPrivateDnsRecordConfig -Value text2
	$record = $record | Add-AzPrivateDnsRecordConfig -Value text3
	$record = $record | Remove-AzPrivateDnsRecordConfig -Value text1
	$record = $record | Remove-AzPrivateDnsRecordConfig -Value text4

	$record | Set-AzPrivateDnsRecordSet
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual text2 $getResult.Records[0].Value
	Assert-AreEqual text3 $getResult.Records[1].Value

	$listResult = Get-AzPrivateDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT

	Assert-AreEqual 2 $listResult[0].Records.Count
	Assert-AreEqual text2 $listResult[0].Records[0].Value
	Assert-AreEqual text3 $listResult[0].Records[1].Value

	$removed = $listResult[0] | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetTXTNonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

    $records = @()
	$records += New-AzPrivateDnsRecordConfig  -Value text2
    $records += New-AzPrivateDnsRecordConfig  -Value text3

	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType TXT -PrivateDnsRecords $records

	# add three records, remove one, remove another no-op

	$record | Set-AzPrivateDnsRecordSet
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual text2 $getResult.Records[0].Value
	Assert-AreEqual text3 $getResult.Records[1].Value

	$removed = $getResult | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetTXTLegacyLengthValidation
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 
	$longRecordTxt = Get-TxtOfSpecifiedLength 1025;
	$maxRecordTxt = Get-TxtOfSpecifiedLength 1024;

	$recordSet = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType TXT ;
		
	Assert-Throws {$recordSet | Add-AzPrivateDnsRecordConfig -Value $longRecordTxt }
	
	$recordSet = $recordSet | Add-AzPrivateDnsRecordConfig -Value $maxRecordTxt
	$setResult = $recordSet | Set-AzPrivateDnsRecordSet ;
		
	Assert-AreEqual $maxRecordTxt $setResult.Records[0].Value;

	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT ;
	Assert-AreEqual $maxRecordTxt $getResult.Records[0].Value;

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


function Test-RecordSetTXTLengthValidation
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

	$longRecordTxt = Get-TxtOfSpecifiedLength 1025;
	Assert-Throws {New-AzPrivateDnsRecordConfig -Value $longRecordTxt }

	$maxRecordTxt = Get-TxtOfSpecifiedLength 1024;
	$maxRecord = New-AzPrivateDnsRecordConfig -Value $maxRecordTxt
	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType TXT -PrivateDnsRecords $maxRecord ;
	Assert-AreEqual $maxRecordTxt $record.Records[0].Value;

	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType TXT ;
	Assert-AreEqual $maxRecordTxt $getResult.Records[0].Value;

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


function Test-RecordSetPTR
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType PTR

	# add three records, remove one, remove another no-op
	$record = $record | Add-AzPrivateDnsRecordConfig -Ptrdname  "contoso1.com"
	$record = $record | Add-AzPrivateDnsRecordConfig -Ptrdname  "contoso2.com"
	$record = $record | Add-AzPrivateDnsRecordConfig -Ptrdname  "contoso3.com"
    $record = $record | Remove-AzPrivateDnsRecordConfig -Ptrdname  "contoso1.com"
    $record = $record | Remove-AzPrivateDnsRecordConfig -Ptrdname  "contoso4.com"

	$record | Set-AzPrivateDnsRecordSet
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType PTR 
	
	Assert-AreEqual 2 $getResult.Records.Count
	Assert-AreEqual "contoso2.com" $getResult.Records[0].Ptrdname
	Assert-AreEqual "contoso3.com" $getResult.Records[1].Ptrdname

	$listResult = Get-AzPrivateDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType PTR

	Assert-AreEqual 2 $listResult[0].Records.Count

	$removed = $listResult[0] | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetPTRNonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

    $records = @()
	$records += New-AzPrivateDnsRecordConfig   -PtrdName "contoso.com"

    $record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType PTR -PrivateDnsRecords $records
	Assert-AreEqual 1 $record.Records.Count

	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType PTR
	Assert-AreEqual 1 $getResult.Records.Count
    Assert-AreEqual "contoso.com" $getResult.Records[0].Ptrdname

	$removed = $getResult | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru
	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Full SRV Record Set CRUD cycle
#>
function Test-RecordSetSRV
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType SRV

	# add two records, remove one, remove another no-op
	$record = $record | Add-AzPrivateDnsRecordConfig -Port 53 -Priority 1 -Target ns1.example.com -Weight 5
	$record = $record | Add-AzPrivateDnsRecordConfig -Port 53 -Priority 2 -Target ns2.example.com -Weight 10
	$record = $record | Remove-AzPrivateDnsRecordConfig -Port 53 -Priority 2 -Target ns2.example.com -Weight 10
	$record = $record | Remove-AzPrivateDnsRecordConfig -Port 42 -Priority 999 -Target ns5.example.com -Weight 1600

	$record | Set-AzPrivateDnsRecordSet
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SRV 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual 53 $getResult.Records[0].Port
	Assert-AreEqual 1 $getResult.Records[0].Priority
	Assert-AreEqual ns1.example.com $getResult.Records[0].Target
	Assert-AreEqual 5 $getResult.Records[0].Weight

	$listResult = Get-AzPrivateDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SRV

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual 53 $listResult[0].Records[0].Port
	Assert-AreEqual 1 $listResult[0].Records[0].Priority
	Assert-AreEqual ns1.example.com $listResult[0].Records[0].Target
	Assert-AreEqual 5 $listResult[0].Records[0].Weight

	$removed = $listResult[0] | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetSRVNonEmpty
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

    $records = @()
	$records += New-AzPrivateDnsRecordConfig  -Port 53 -Priority 1 -Target ns1.example.com -Weight 5
	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType SRV -PrivateDnsRecords $records
	$record | Set-AzPrivateDnsRecordSet
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SRV 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual 53 $getResult.Records[0].Port
	Assert-AreEqual 1 $getResult.Records[0].Priority
	Assert-AreEqual ns1.example.com $getResult.Records[0].Target
	Assert-AreEqual 5 $getResult.Records[0].Weight

	$removed = $getResult[0] | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru

	Assert-True { $removed }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}


<#
.SYNOPSIS
Full SOA Record Set CRUD cycle
#>
function Test-RecordSetSOA
{
	$zoneName = Get-RandomZoneName
	$recordName = "@"
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

	$record = $zone | Get-AzPrivateDnsRecordSet -Name $recordName -RecordType SOA

	#Ensure that SOA RecordSet cannot be created
	Assert-Throws { New-AzPrivateDnsRecordSet -Name $recordName -RecordType SOA -ResourceGroupName $resourceGroup -ZoneName $zoneName  -Ttl 100 } "There can be only one record set of type SOA, and it can be modified but not deleted."

	# can only update SOA values, can't add or remove
	Assert-AreEqual 1 $record.Count
	$record.Records[0].RefreshTime = 13
	$record.Records[0].RetryTime = 666
	$record.Records[0].ExpireTime = 42
	$record.Records[0].MinimumTtl = 321
	$record.Ttl = 110901

	$record | Set-AzPrivateDnsRecordSet
	$getResult = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SOA 
	
	Assert-AreEqual 1 $getResult.Records.Count
	Assert-AreEqual 13 $getResult.Records[0].RefreshTime
	Assert-AreEqual 666 $getResult.Records[0].RetryTime
	Assert-AreEqual 42 $getResult.Records[0].ExpireTime
	Assert-AreEqual 321 $getResult.Records[0].MinimumTtl
	Assert-AreEqual 110901 $getResult.Ttl

	$listResult = Get-AzPrivateDnsRecordSet -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType SOA

	Assert-AreEqual 1 $listResult[0].Records.Count
	Assert-AreEqual 13 $listResult[0].Records[0].RefreshTime
	Assert-AreEqual 666 $listResult[0].Records[0].RetryTime
	Assert-AreEqual 42 $listResult[0].Records[0].ExpireTime
	Assert-AreEqual 321 $listResult[0].Records[0].MinimumTtl
	Assert-AreEqual 110901 $listResult[0].Ttl

	Assert-Throws { $listResult[0] | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru } "Record sets of type 'SOA' with name '@' cannot be deleted."

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
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
New-AzPrivateDnsRecordSet when the record set already exists
#>
function Test-RecordSetNewAlreadyExists
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 

	$record = New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 100 -RecordType A | Add-AzPrivateDnsRecordConfig -Ipv4Address 1.2.9.8

	# error the second time
	$message = [System.String]::Format("The Record set {0} exists already and hence cannot be created again.", $recordName);
	Assert-Throws {  New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 212 -RecordType A } $message

	New-AzPrivateDnsRecordSet -ZoneName $zone.Name -ResourceGroupName $resourceGroup.ResourceGroupName -Name $recordName -Ttl 999 -RecordType A -Overwrite -Confirm:$false

	$retrievedRecordSet = $zone | Get-AzPrivateDnsRecordSet -Name $recordName -RecordType A

	Assert-AreEqual 999 $retrievedRecordSet.Ttl
	Assert-AreEqual 0 $retrievedRecordSet.Records.Count

	$retrievedRecordSet | Remove-AzPrivateDnsRecordSet -Confirm:$false
	$zone | Remove-AzPrivateDnsZone -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Test to check addition of mismatching records to recordsets
#>
function Test-RecordSetAddRecordTypeMismatch
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName
    $recordSet = $zone | New-AzPrivateDnsRecordSet -Name $recordName -Ttl 100 -RecordType MX
	
	Assert-Throws { $recordSet | Add-AzPrivateDnsRecordConfig -Ipv6Address 3::90 } "Cannot add a record of type AAAA to a record set of type MX. The types must match."

	$recordSet | Remove-AzPrivateDnsRecordSet -Confirm:$false
	Remove-AzPrivateDnsZone -Name $recordSet.ZoneName -ResourceGroupName $recordSet.ResourceGroupName -Confirm:$false
}

function Test-RecordSetAddTwoCnames
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname

	$resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName
    $recordSet = $zone | New-AzPrivateDnsRecordSet -Name $recordName -Ttl 100 -RecordType CNAME 
	$resourceGroupName = $recordSet.ResourceGroupName

	$recordSet | Add-AzPrivateDnsRecordConfig -Cname www.goril.la
	Assert-Throws { $recordSet | Add-AzPrivateDnsRecordConfig -Cname rubadub.dub } "There already exists a CNAME record in this set. A CNAME record set can only contain one record."
	Assert-AreEqual 1 $recordSet.Records.Count

	$recordSet | Remove-AzPrivateDnsRecordConfig -Cname www.goril.la
	$recordSet | Add-AzPrivateDnsRecordConfig -Cname rubadub.dub

	Assert-AreEqual 1 $recordSet.Records.Count
	Assert-AreEqual rubadub.dub $recordSet.Records[0].Cname

	$recordSet | Remove-AzPrivateDnsRecordSet -Confirm:$false
	Remove-AzPrivateDnsZone -Name $recordSet.ZoneName -ResourceGroupName $recordSet.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Test to try removing mismatching record type from recordset
#>
function Test-RecordSetRemoveRecordTypeMismatch
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName
    $recordSet = $zone | New-AzPrivateDnsRecordSet -Name $recordName -Ttl 100 -RecordType TXT
	$resourceGroupName = $recordSet.ResourceGroupName

	Assert-Throws { $recordSet | Remove-AzPrivateDnsRecordConfig -Cname nsa.fed.gov } "Cannot remove a record of type CNAME from a record set of type TXT. The types must match."

	$recordSet | Remove-AzPrivateDnsRecordSet -Confirm:$false
	Remove-AzPrivateDnsZone -Name $recordSet.ZoneName -ResourceGroupName $recordSet.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroupName -Force
}

<#
.SYNOPSIS
Test to try removing recordset using resource id.
#>
function Test-RecordSetRemoveUsingResourceId
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName
    $recordSet = $zone | New-AzPrivateDnsRecordSet -Name $recordName -Ttl 100 -RecordType TXT
	$resourceGroupName = $recordSet.ResourceGroupName

	$removed = Remove-AzPrivateDnsRecordSet -ResourceId $recordSet.Id -PassThru -Confirm:$false

	Assert-True { $removed }

	Assert-ThrowsLike { Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A } "*does not exist*"

	$recordSet | Remove-AzPrivateDnsRecordSet -Confirm:$false
	Remove-AzPrivateDnsZone -Name $recordSet.ZoneName -ResourceGroupName $recordSet.ResourceGroupName -Confirm:$false
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
	$resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName
    $recordSet = $zone | New-AzPrivateDnsRecordSet -Name $recordName -Ttl 100 -RecordType AAAA
	$originalEtag = $recordSet.Etag
	$recordSet.Etag = "gibberish"

	$message = [System.String]::Format("The Record set {0} has been modified (etag mismatch).", $recordName);
	Assert-Throws { $recordSet | Set-AzPrivateDnsRecordSet } $message

	$updatedRecordSet = $recordSet | Set-AzPrivateDnsRecordSet -Overwrite

	Assert-AreNotEqual "gibberish" $updatedRecordSet.Etag
	Assert-AreNotEqual $recordSet.Etag $updatedRecordSet.Etag

	$message = [System.String]::Format("The Record set {0} has been modified (etag mismatch).", $recordName);
	Assert-Throws { $recordSet | Remove-AzPrivateDnsRecordSet -Confirm:$false } $message

	Assert-True { $recordSet | Remove-AzPrivateDnsRecordSet -Overwrite -Confirm:$false -PassThru }

	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $recordSet.ResourceGroupName -Confirm:$false
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

	$resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	# test for root records
	$soaRecords = Get-AzPrivateDnsRecordSet -Zone $zone -RecordType SOA
	Assert-AreEqual 1 $soaRecords.Count

	# test for non-root records

    New-AzPrivateDnsRecordSet -Zone $zone -Name $recordName1 -Ttl 100 -RecordType AAAA
	New-AzPrivateDnsRecordSet -Zone $zone -Name $recordName2 -Ttl 1200 -RecordType AAAA
	New-AzPrivateDnsRecordSet -Zone $zone -Name $recordName3 -Ttl 1500 -RecordType MX

	$aaaaRecords = $zone | Get-AzPrivateDnsRecordSet -RecordType AAAA
	$mxRecords = $zone | Get-AzPrivateDnsRecordSet -RecordType MX

	Assert-AreEqual 2 $aaaaRecords.Count
	Assert-AreEqual 1 $mxRecords.Count

	# all records
	$allRecords = Get-AzPrivateDnsRecordSet -Zone $zone

	Assert-AreEqual 4 $allRecords.Count
	
	$zone | Remove-AzPrivateDnsRecordSet -Name $recordName1 -RecordType AAAA -Confirm:$false
	$zone | Remove-AzPrivateDnsRecordSet -Name $recordName2 -RecordType AAAA -Confirm:$false
	$zone | Remove-AzPrivateDnsRecordSet -Name $recordName3 -RecordType MX -Confirm:$false

	$zone | Remove-AzPrivateDnsZone -Confirm:$false -Overwrite
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
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

	$resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	# test for root records
	$rootRecords = $zone | Get-AzPrivateDnsRecordSet -EndsWith $rootRecordName

	Assert-AreEqual 2 $rootRecords.Count -Message ("Expected 2 root records. Actual: " + $rootRecords.Count)
	
    New-AzPrivateDnsRecordSet -Zone $zone -Name $recordName1 -Ttl 100 -RecordType AAAA
	New-AzPrivateDnsRecordSet -Zone $zone -Name $recordName2 -Ttl 1200 -RecordType AAAA
	New-AzPrivateDnsRecordSet -Zone $zone -Name $recordName3 -Ttl 1500 -RecordType MX

	# test for records within type
	$aaaaRecords = $zone | Get-AzPrivateDnsRecordSet -RecordType AAAA -EndsWith $recordSuffix
	$mxRecords = $zone | Get-AzPrivateDnsRecordSet -RecordType MX -EndsWith $recordSuffix

	Assert-AreEqual 1 $aaaaRecords.Count -Message ("Expected 1 AAAA record. Actual: " + $aaaaRecords.Count)
	Assert-AreEqual 1 $mxRecords.Count -Message ("Expected 1 MX record. Actual: " + $mxRecords.Count)

	# all records
	$allRecords = $zone | Get-AzPrivateDnsRecordSet -EndsWith $recordSuffix

	Assert-AreEqual 2 $allRecords.Count -Message ("Expected 2 records across types. Actual: " + $allRecords.Count)

	$zone | Remove-AzPrivateDnsRecordSet -Name $recordName1 -RecordType AAAA -Confirm:$false
	$zone | Remove-AzPrivateDnsRecordSet -Name $recordName2 -RecordType AAAA -Confirm:$false
	$zone | Remove-AzPrivateDnsRecordSet -Name $recordName3 -RecordType MX -Confirm:$false

	$zone | Remove-AzPrivateDnsZone -Confirm:$false -Overwrite
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
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
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	$message = "PSPrivateDnsRecordSet"
	$warning = (New-AzPrivateDnsRecordSet -Name $recordName -RecordType A -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Ttl 100)3>&1 | Out-String

	Write-Verbose $warning
	#Assert-AreEqual ($warning -contains $message) $True

	Remove-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType A -PassThru -Confirm:$false
	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false
	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

function Test-RecordSetNewRecordNoName
{
	$zoneName = Get-RandomZoneName
	$recordName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup 
	$zone = New-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName 
	$recordSet = New-AzPrivateDnsRecordSet -Name $recordName -Ttl 100 -RecordType MX -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName
	$recordSet = Get-AzPrivateDnsRecordSet -ResourceGroupName $resourceGroup.ResourceGroupName -ZoneName $zoneName -RecordType MX
	$record1 = Add-AzPrivateDnsRecordConfig -Exchange mail1.theg.com -Preference 1 -RecordSet $recordSet
	$recordSet | Set-AzPrivateDnsRecordSet
	$getRecordSetOne = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX 
	Assert-AreEqual 1 $getRecordSetOne.Records.Count

	$record2 = Add-AzPrivateDnsRecordConfig -Exchange mail2.theg.com -Preference 10 -RecordSet $getRecordSetOne
	$getRecordSetOne | Set-AzPrivateDnsRecordSet
	$getRecordSetTwo = Get-AzPrivateDnsRecordSet -Name $recordName -ZoneName $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -RecordType MX
	Assert-AreEqual 2 $getRecordSetTwo.Records.Count

	$record1 = $record1 | Remove-AzPrivateDnsRecordConfig -Exchange mail1.theg.com -Preference 1
	$record2 = $record2 | Remove-AzPrivateDnsRecordConfig -Exchange mail2.theg.com -Preference 10
	$removed = $getRecordSetTwo | Remove-AzPrivateDnsRecordSet -Confirm:$false -PassThru
	Assert-True { $removed }
	Remove-AzPrivateDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Confirm:$false

	Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}