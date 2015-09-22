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
	$zoneName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	$createdZone = New-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Tags @{Name="tag1";Value="value1"}

	Assert-NotNull $createdZone
	Assert-NotNull $createdZone.Etag
	Assert-AreEqual $zoneName $createdZone.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdZone.ResourceGroupName 
	Assert-AreEqual 1 $createdZone.Tags.Count

	$retrievedZone = Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedZone
	Assert-NotNull $retrievedZone.Etag
	Assert-AreEqual $zoneName $retrievedZone.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedZone.ResourceGroupName
	Assert-AreEqual $retrievedZone.Etag $createdZone.Etag
	Assert-AreEqual 1 $retrievedZone.Tags.Count

	$updatedZone = Set-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Tags @{Name="tag1";Value="value1"},@{Name="tag2";Value="value2"}

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

	$removed = Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName } "ResourceNotFound: Resource not found."
}

<#
.SYNOPSIS
Tests that the zone cmdlets trim the terminating dot from the zone name
#>
function Test-ZoneCrudTrimsDot
{
	$zoneName = getAssetname
	$zoneNameWithDot = $zoneName + "."
    $resourceGroup = TestSetup-CreateResourceGroup
	$createdZone = New-AzureRmDnsZone -Name $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $createdZone
	Assert-AreEqual $zoneName $createdZone.Name 

	$retrievedZone = Get-AzureRmDnsZone -Name $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedZone
	Assert-AreEqual $zoneName $retrievedZone.Name 

	$updatedZone = Set-AzureRmDnsZone -Name $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -Tags @{Name="tag1";Value="value1"},@{Name="tag2";Value="value2"}

	Assert-NotNull $updatedZone
	Assert-AreEqual $zoneName $updatedZone.Name 

	$removed = Remove-AzureRmDnsZone -Name $zoneNameWithDot -ResourceGroupName $resourceGroup.ResourceGroupName -PassThru -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName } "ResourceNotFound: Resource not found."
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneCrudWithPiping
{
	$zoneName = getAssetname
    $createdZone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName -Tags @{Name="tag1";Value="value1"}

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

	$removed = Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroupName | Remove-AzureRmDnsZone -PassThru -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroupName } "ResourceNotFound: Resource not found."
}

<#
.SYNOPSIS
Tests that the zone CRUD cmdlets trim the terminating dot from the zone name when piping
#>
function Test-ZoneCrudWithPipingTrimsDot
{
	$zoneName = getAssetname
	$zoneNameWithDot = $zoneName + "."
    $createdZone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName
	
	$resourceGroupName = $createdZone.ResourceGroupName

	$zoneObjectWithDot = New-Object Microsoft.Azure.Commands.Dns.DnsZone
	$zoneObjectWithDot.Name = $zoneNameWithDot
	$zoneObjectWithDot.ResourceGroupName = $resourceGroupName

	$updatedZone = $zoneObjectWithDot | Set-AzureRmDnsZone -Overwrite 

	Assert-NotNull $updatedZone
	Assert-AreEqual $zoneName $updatedZone.Name 

	$removed = $zoneObjectWithDot | Remove-AzureRmDnsZone -Overwrite -PassThru -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroupName } "ResourceNotFound: Resource not found."
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneNewAlreadyExists
{
	$zoneName = getAssetname
    $createdZone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName
	$resourceGroupName = $createdZone.ResourceGroupName
	Assert-NotNull $createdZone
	
	Assert-Throws { New-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroupName } "PreconditionFailed: The condition '*' in the If-None-Match header was not satisfied. The current was 'n/a'."

	$createdZone | Remove-AzureRmDnsZone -PassThru -Force
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneSetEtagMismatch
{
	$zoneName = getAssetname
    $createdZone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName
	$originalEtag = $createdZone.Etag
	$createdZone.Etag = "gibberish"

	Assert-Throws { $createdZone | Set-AzureRmDnsZone } "PreconditionFailed: The condition 'gibberish' in the If-Match header was not satisfied. The current was '$originalEtag'."

	$updatedZone = $createdZone | Set-AzureRmDnsZone -Overwrite

	Assert-AreNotEqual "gibberish" $updatedZone.Etag
	Assert-AreNotEqual $createdZone.Etag $updatedZone.Etag

	$updatedZone | Remove-AzureRmDnsZone -PassThru -Force
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneSetNotFound
{
	$zoneName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	
	Assert-Throws { Set-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName } "PreconditionFailed: The condition '*' in the If-Match header was not satisfied. The current was 'n/a'."
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneRemoveEtagMismatch
{
	$zoneName = getAssetname
    $createdZone = TestSetup-CreateResourceGroup | New-AzureRmDnsZone -Name $zoneName
	$originalEtag = $createdZone.Etag
	$createdZone.Etag = "gibberish"

	Assert-Throws { $createdZone | Remove-AzureRmDnsZone -Force } "PreconditionFailed: The condition 'gibberish' in the If-Match header was not satisfied. The current was '$originalEtag'."

	$removed = $createdZone | Remove-AzureRmDnsZone -Overwrite -Force -PassThru

	Assert-True { $removed }
}

<#
.SYNOPSIS
Zone CRUD with piping
#>
function Test-ZoneRemoveNonExisting
{
	$zoneName = getAssetname
    $resourceGroup = TestSetup-CreateResourceGroup
	
	$removed = Remove-AzureRmDnsZone -Name $zoneName -ResourceGroupName $resourceGroup.ResourceGroupName -Force -PassThru
	Assert-True { $removed }
}

<#
.SYNOPSIS
Zone List
#>
function Test-ZoneList
{
	$zoneName1 = getAssetname
	$zoneName2 = $zoneName1 + "A"
	$resourceGroup = TestSetup-CreateResourceGroup
    $createdZone1 = $resourceGroup | New-AzureRmDnsZone -Name $zoneName1 -Tags @{Name="tag1";Value="value1"}
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

	$result | Remove-AzureRmDnsZone -PassThru -Force
}

<#
.SYNOPSIS
Zone List With EndsWith
#>
function Test-ZoneListWithEndsWith
{
	$suffix = ".com"
	$suffixWithDot = ".com."
	$zoneName1 = getAssetname
	$zoneName2 = $zoneName1 + $suffix
	$resourceGroup = TestSetup-CreateResourceGroup
    $createdZone1 = $resourceGroup | New-AzureRmDnsZone -Name $zoneName1 
	$createdZone2 = $resourceGroup | New-AzureRmDnsZone -Name $zoneName2

	$result = Get-AzureRmDnsZone -ResourceGroupName $resourceGroup.ResourceGroupName -EndsWith $suffixWithDot

	Assert-AreEqual 1 $result.Count

	Assert-AreEqual $createdZone2.Etag $result[0].Etag
	Assert-AreEqual $createdZone2.Name $result[0].Name
	Assert-NotNull $resourceGroup.ResourceGroupName $result[0].ResourceGroupName

	$result | Remove-AzureRmDnsZone -PassThru -Force
}