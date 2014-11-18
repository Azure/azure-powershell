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
Tests creating new resource group and a simple resource.
#>
function Test-CreatesNewSimpleResource
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceName
	$rglocation = Get-ProviderLocation ResourceManagement
	$location = Get-ProviderLocation "Microsoft.Sql/servers"
	$apiversion = "2014-04-01"
	$resourceType = "Microsoft.Sql/servers"

	# Test
	New-AzureResourceGroup -Name $rgname -Location $rglocation
	$actual = New-AzureResource -Name $rname -Location $location -Tags @{Name = "testtag"; Value = "testval"} -ResourceGroupName $rgname -ResourceType $resourceType -PropertyObject @{"administratorLogin" = "adminuser"; "administratorLoginPassword" = "P@ssword1"} -ApiVersion $apiversion
	$expected = Get-AzureResource -Name $rname -ResourceGroupName $rgname -ResourceType $resourceType -ApiVersion $apiversion
	
	$list = Get-AzureResource -ResourceGroupName $rgname

	# Assert
	Assert-AreEqual $expected.Name $actual.Name
	Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
	Assert-AreEqual $expected.ResourceType $actual.ResourceType
	Assert-AreEqual 1 @($list).Count
	Assert-AreEqual $expected.Name $list[0].Name	
}

<#
.SYNOPSIS
Tests creating new resource group and parent and child resources.
#>
function Test-CreatesNewComplexResource
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rnameParent = Get-ResourceName
	$rnameChild = Get-ResourceName
	$resourceTypeParent = "Microsoft.Sql/servers"
	$resourceTypeChild = "Microsoft.Sql/servers/databases"
	$rglocation = Get-ProviderLocation ResourceManagement
	$location = Get-ProviderLocation $resourceTypeParent
	$apiversion = "2014-04-01"

	# Test
	New-AzureResourceGroup -Name $rgname -Location $rglocation
	$actualParent = New-AzureResource -Name $rnameParent -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeParent -PropertyObject @{"administratorLogin" = "adminuser"; "administratorLoginPassword" = "P@ssword1"} -ApiVersion $apiversion
	$expectedParent = Get-AzureResource -Name $rnameParent -ResourceGroupName $rgname -ResourceType $resourceTypeParent -ApiVersion $apiversion

	$actualChild = New-AzureResource -Name $rnameChild -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeChild -ParentResource servers/$rnameParent -PropertyObject @{"edition" = "Web"; "collation" = "SQL_Latin1_General_CP1_CI_AS"; "maxSizeBytes" = "1073741824"} -ApiVersion $apiversion
	$expectedChild = Get-AzureResource -Name $rnameChild -ResourceGroupName $rgname -ResourceType $resourceTypeChild -ParentResource servers/$rnameParent -ApiVersion $apiversion

	$list = Get-AzureResource -ResourceGroupName $rgname

	$parentFromList = $list | where {$_.ResourceType -eq $resourceTypeParent} | Select-Object -First 1
	$childFromList = $list | where {$_.ResourceType -eq $resourceTypeChild} | Select-Object -First 1

	$listOfServers = Get-AzureResource -ResourceType $resourceTypeParent -ResourceGroupName $rgname
	$listOfDatabases = Get-AzureResource -ResourceType $resourceTypeChild -ResourceGroupName $rgname

	# Assert
	Assert-AreEqual $expectedParent.Name $actualParent.Name
	Assert-AreEqual $expectedChild.Name $actualChild.Name
	Assert-AreEqual $expectedParent.ResourceType $actualParent.ResourceType
	Assert-AreEqual $expectedChild.ResourceType $actualChild.ResourceType

	Assert-AreEqual 2 @($list).Count
	Assert-AreEqual $expectedParent.Name $parentFromList.Name
	Assert-AreEqual $expectedChild.Name $childFromList.Name
	Assert-AreEqual $expectedParent.ResourceType $parentFromList.ResourceType
	Assert-AreEqual $expectedChild.ResourceType $childFromList.ResourceType

	Assert-AreEqual 1 @($listOfServers).Count
	Assert-AreEqual 1 @($listOfDatabases).Count
}

<#
.SYNOPSIS
Tests get resources via piping from resource group
#>
function Test-GetResourcesViaPiping
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rnameParent = Get-ResourceName
	$rnameChild = Get-ResourceName
	$resourceTypeParent = "Microsoft.Sql/servers"
	$resourceTypeChild = "Microsoft.Sql/servers/databases"
	$rglocation = Get-ProviderLocation ResourceManagement
	$location = Get-ProviderLocation $resourceTypeParent
	$apiversion = "2014-04-01"

	# Test
	New-AzureResourceGroup -Name $rgname -Location $rglocation
	New-AzureResource -Name $rnameParent -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeParent -PropertyObject @{"administratorLogin" = "adminuser"; "administratorLoginPassword" = "P@ssword1"} -ApiVersion $apiversion		
	New-AzureResource -Name $rnameChild -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeChild -ParentResource servers/$rnameParent -PropertyObject @{"edition" = "Web"; "collation" = "SQL_Latin1_General_CP1_CI_AS"; "maxSizeBytes" = "1073741824"} -ApiVersion $apiversion
		
	$list = Get-AzureResourceGroup -Name $rgname | Get-AzureResource
	$serverFromList = $list | where {$_.ResourceType -eq $resourceTypeParent} | Select-Object -First 1
	$databaseFromList = $list | where {$_.ResourceType -eq $resourceTypeChild} | Select-Object -First 1

	# Assert
	Assert-AreEqual 2 @($list).Count
	Assert-AreEqual $rnameParent $serverFromList.Name
	Assert-AreEqual $rnameChild $databaseFromList.Name
	Assert-AreEqual $resourceTypeParent $serverFromList.ResourceType
	Assert-AreEqual $resourceTypeChild $databaseFromList.ResourceType
}

<#
.SYNOPSIS
Nagative test. Get resources from an empty group.
#>
function Test-GetResourcesFromEmptyGroup
{
	# Setup
	$rgname = Get-ResourceGroupName
	$location = Get-ProviderLocation ResourceManagement

	# Test
	New-AzureResourceGroup -Name $rgname -Location $location
	$listViaPiping = Get-AzureResourceGroup -Name $rgname | Get-AzureResource
	$listViaDirect = Get-AzureResource -ResourceGroupName $rgname

	# Assert
	Assert-AreEqual 0 @($listViaPiping).Count
	Assert-AreEqual 0 @($listViaDirect).Count
}

<#
.SYNOPSIS
Nagative test. Get resources from an non-existing empty group.
#>
function Test-GetResourcesFromNonExisingGroup
{
	# Setup
	$rgname = Get-ResourceGroupName

	# Test
	Assert-Throws { Get-AzureResource -ResourceGroupName $rgname } "Provided resource group does not exist."
}

<#
.SYNOPSIS
Nagative test. Get resources from non-existing type.
#>
function Test-GetResourcesForNonExisingType
{
	# Test
	$list = Get-AzureResource -ResourceType 'Non-Existing'

	# Assert
	Assert-AreEqual 0 @($list).Count
}

<#
.SYNOPSIS
Nagative test. Get non-existing resource.
#>
function Test-GetResourceForNonExisingResource
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rname = Get-ResourceGroupName
	$location = Get-ProviderLocation ResourceManagement
	$resourceTypeWeb = "Microsoft.Web/sites"
	$resourceTypeSql = "Microsoft.Sql/servers"
	$apiversion = "2014-04-01"

	# Test
	New-AzureResourceGroup -Name $rgname -Location $location
	Assert-Throws { Get-AzureResource -Name $rname -ResourceGroupName $rgname -ResourceType $resourceTypeWeb -ApiVersion $apiversion } "Provided resource does not exist."
	Assert-Throws { Get-AzureResource -Name $rname -ResourceGroupName $rgname -ResourceType $resourceTypeSql -ApiVersion $apiversion } "Provided resource does not exist."
	Assert-Throws { Get-AzureResource -Name $rname -ResourceGroupName $rgname -ResourceType 'Microsoft.Fake/nonexisting' -ApiVersion $apiversion } "Provided resource does not exist."
}

<#
.SYNOPSIS
Tests get resources via piping from resource group
#>
function Test-GetResourcesViaPipingFromAnotherResource
{
	# Setup
	$rgname = Get-ResourceGroupName
	$rnameParent = Get-ResourceName
	$rnameChild = Get-ResourceName
	$resourceTypeParent = "Microsoft.Sql/servers"
	$resourceTypeChild = "Microsoft.Sql/servers/databases"
	$rglocation = Get-ProviderLocation ResourceManagement
	$location = Get-ProviderLocation $resourceTypeParent
	$apiversion = "2014-04-01"

	# Test
	New-AzureResourceGroup -Name $rgname -Location $rglocation
	New-AzureResource -Name $rnameParent -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeParent -PropertyObject @{"administratorLogin" = "adminuser"; "administratorLoginPassword" = "P@ssword1"} -ApiVersion $apiversion		
	New-AzureResource -Name $rnameChild -Location $location -ResourceGroupName $rgname -ResourceType $resourceTypeChild -ParentResource servers/$rnameParent -PropertyObject @{"edition" = "Web"; "collation" = "SQL_Latin1_General_CP1_CI_AS"; "maxSizeBytes" = "1073741824"} -ApiVersion $apiversion
		
	$list = Get-AzureResource -ResourceGroupName $rgname | Get-AzureResource -ApiVersion $apiversion
		
	# Assert
	Assert-AreEqual 2 @($list).Count
}