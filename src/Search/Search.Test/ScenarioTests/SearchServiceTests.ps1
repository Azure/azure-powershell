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
Test New-AzSearchService
#>
function Test-NewAzureRmSearchService
{
	# Arrange
	$rgname = getAssetName
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "West US"
	$svcName = $rgname + "-service"
	$sku = "Standard"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# Act
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode
		
		# Assert
		Assert-NotNull $newSearchService
		Assert-AreEqual $svcName $newSearchService.Name 
		Assert-AreEqual $sku $newSearchService.Sku
		Assert-AreEqual $loc $newSearchService.Location
		Assert-AreEqual $partitionCount $newSearchService.PartitionCount
		Assert-AreEqual $replicaCount $newSearchService.ReplicaCount
		Assert-AreEqual $hostingMode $newSearchService.HostingMode
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzSearchServiceBasic
#>
function Test-NewAzureRmSearchServiceBasic
{
	# Arrange
	$rgname = getAssetName
	$rgname = $rgname
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "West US"
	$svcName = $rgname + "-service"
	$sku = "Basic"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# Act
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode
		
		# Assert
		Assert-NotNull $newSearchService
		Assert-AreEqual $svcName $newSearchService.Name 
		Assert-AreEqual $sku $newSearchService.Sku
		Assert-AreEqual $loc $newSearchService.Location
		Assert-AreEqual $partitionCount $newSearchService.PartitionCount
		Assert-AreEqual $replicaCount $newSearchService.ReplicaCount
		Assert-AreEqual $hostingMode $newSearchService.HostingMode
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzSearchServiceL1
#>
function Test-NewAzureRmSearchServiceL1
{
	# Arrange
	$rgname = getAssetName
	$rgname = $rgname
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "West US"
	$svcName = $rgname + "-service"
	$sku = "Storage_Optimized_L1"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# Act
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode
		
		# Assert
		Assert-NotNull $newSearchService
		Assert-AreEqual $svcName $newSearchService.Name 
		Assert-AreEqual $sku $newSearchService.Sku
		Assert-AreEqual $loc $newSearchService.Location
		Assert-AreEqual $partitionCount $newSearchService.PartitionCount
		Assert-AreEqual $replicaCount $newSearchService.ReplicaCount
		Assert-AreEqual $hostingMode $newSearchService.HostingMode
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzSearchService
#>
function Test-GetAzureRmSearchService
{
    # Arrange
	$rgname = getAssetName
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "West US"
	$svcName = $rgname + "-service"
	$sku = "Standard"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# Act
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc

		# By ResourceGroup + Name
		$retrievedSearchService1 = Get-AzSearchService -ResourceGroupName $rgname -Name $svcName

		# By ResourceId
		$retrievedSearchService2 = Get-AzSearchService -ResourceId $newSearchService.Id
		
		# Assert
		Assert-NotNull $retrievedSearchService1
		Assert-NotNull $retrievedSearchService2

		Assert-AreEqual $newSearchService.Name $retrievedSearchService1.Name
		Assert-AreEqual $newSearchService.Name $retrievedSearchService2.Name

		Assert-AreEqual $newSearchService.Location $retrievedSearchService1.Location
		Assert-AreEqual $newSearchService.Location $retrievedSearchService2.Location

		Assert-AreEqual $sku $newSearchService.Sku
		Assert-AreEqual $newSearchService.Sku $retrievedSearchService1.Sku
		Assert-AreEqual $newSearchService.Sku $retrievedSearchService2.Sku

		# Create anther one in the same ResourceGroup.
		$svcName2 = $rgname + "-service2"
		$newSearchService2 = New-AzSearchService -ResourceGroupName $rgname -Name $svcName2 -Sku $sku -Location $loc

		# By ResourceGroup only = list
		$allSearchServices = Get-AzSearchService -ResourceGroupName $rgname

		Assert-AreEqual 2 $allSearchServices.Count
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Remove-AzSearchService
#>
function Test-RemoveAzureRmSearchService
{
    # Arrange
	$rgname = getAssetName
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "West US"
	$sku = "Standard"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# 1
		# Act - Create
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $($rgname + "-service1") -Sku $sku -Location $loc

		# Can Get
		$retrievedSvc = Get-AzSearchService -ResourceId $newSearchService.Id
		Assert-NotNull $retrievedSvc

		# Remove by InputObject
		$retrievedSvc | Remove-AzSearchService -Force

		# Assert Get nothing
		$retrievedSvc = Get-AzSearchService -ResourceId $newSearchService.Id
		Assert-Null $retrievedSvc
		
		# 2
		# Act - Create
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $($rgname + "-service2") -Sku $sku -Location $loc
		
		# Can Get
		$retrievedSvc = Get-AzSearchService -ResourceId $newSearchService.Id
		Assert-NotNull $retrievedSvc
		
		# Remove by ResourceId
		Remove-AzSearchService -ResourceId $retrievedSvc.Id -Force

		# Assert Get nothing
		$retrievedSvc = Get-AzSearchService -ResourceId $newSearchService.Id
		Assert-Null $retrievedSvc

		# 3
		# Act - Create
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $($rgname + "-service3") -Sku $sku -Location $loc
		
		# Can Get
		$retrievedSvc = Get-AzSearchService -ResourceId $newSearchService.Id
		Assert-NotNull $retrievedSvc
		
		# Remove by ResourceGroup + Name
		Remove-AzSearchService -ResourceGroupName $rgname -Name $retrievedSvc.Name -Force

		# Assert Get nothing
		$retrievedSvc = Get-AzSearchService -ResourceId $newSearchService.Id
		Assert-Null $retrievedSvc
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Set-AzSearchService
#>
function Test-SetAzureRmSearchService
{
    # Arrange
	$rgname = getAssetName
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "West US"
	$sku = "Standard"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# 1. Act - Create
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $($rgname + "-service1") -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode

		# Set by InputObject
		$newSearchService | Set-AzSearchService -PartitionCount 2 -ReplicaCount 2

		# Assert Get
		$retrievedSvc = Get-AzSearchService -ResourceId $newSearchService.Id
		Assert-AreEqual 2 $retrievedSvc.PartitionCount
		Assert-AreEqual 2 $retrievedSvc.ReplicaCount

		# 2. Act - Create
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $($rgname + "-service2") -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode
		
		# Set by ResourceId
		Set-AzSearchService -ResourceId $newSearchService.Id -PartitionCount 3 -ReplicaCount 3

		# Assert Get
		$retrievedSvc = Get-AzSearchService -ResourceId $newSearchService.Id
		Assert-AreEqual 3 $retrievedSvc.PartitionCount
		Assert-AreEqual 3 $retrievedSvc.ReplicaCount

		# 3. Act - Create
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $($rgname + "-service3") -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode

		# Set by ResourceGroup + Name
		Set-AzSearchService -ResourceGroupName $rgname -Name $newSearchService.Name -PartitionCount 2 -ReplicaCount 2

		# Assert Get
		$retrievedSvc = Get-AzSearchService -ResourceId $newSearchService.Id
		Assert-AreEqual 2 $retrievedSvc.PartitionCount
		Assert-AreEqual 2 $retrievedSvc.ReplicaCount
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ManageAzureRmSearchServiceAdminKey
#>
function Test-ManageAzureRmSearchServiceAdminKey
{
    # Arrange
	$rgname = getAssetName
	$svcName = $rgname + "-service"
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "West US"
	$sku = "Standard"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# 1. Act - Create
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode

		# Get
		$adminKeyPair1 = $newSearchService | Get-AzSearchAdminKeyPair
		$adminKeyPair2 = Get-AzSearchAdminKeyPair -ParentResourceId $newSearchService.Id
		$adminKeyPair3 = Get-AzSearchAdminKeyPair -ResourceGroupName $rgname -ServiceName $svcName

		# Assert
		Assert-NotNull $adminKeyPair1
		Assert-NotNull $adminKeyPair2
		Assert-NotNull $adminKeyPair3

		Assert-AreEqual $adminKeyPair1.Primary $adminKeyPair2.Primary
		Assert-AreEqual $adminKeyPair2.Primary $adminKeyPair3.Primary

		Assert-AreEqual $adminKeyPair1.Secondary $adminKeyPair2.Secondary
		Assert-AreEqual $adminKeyPair2.Secondary $adminKeyPair3.Secondary

		# New
		$newKeyPair1 = $newSearchService | New-AzSearchAdminKey -KeyKind Primary -Force
		$newKeyPair2 = New-AzSearchAdminKey -ParentResourceId $newSearchService.Id -KeyKind Secondary -Force
		$newKeyPair3 = New-AzSearchAdminKey -ResourceGroupName $rgname -ServiceName $svcName -KeyKind Primary -Force

		# 1
		Assert-NotNull $newKeyPair1
		Assert-AreNotEqual $newKeyPair1.Primary $adminKeyPair1.Primary
		Assert-AreEqual $newKeyPair1.Secondary $adminKeyPair1.Secondary

		# 2
		Assert-NotNull $newKeyPair2
		Assert-AreEqual $newKeyPair2.Primary $newKeyPair1.Primary
		
		Assert-AreNotEqual $newKeyPair2.Secondary $adminKeyPair1.Secondary
		Assert-AreNotEqual $newKeyPair2.Primary $adminKeyPair1.Primary

		# 3
		Assert-NotNull $newKeyPair3
		Assert-AreEqual $newKeyPair3.Secondary $newKeyPair2.Secondary

		Assert-AreNotEqual $newKeyPair3.Secondary $adminKeyPair3.Secondary
		Assert-AreNotEqual $newKeyPair3.Primary $adminKeyPair3.Primary
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ManageAzureRmSearchServiceQueryKey
#>
function Test-ManageAzureRmSearchServiceQueryKey
{
    # Arrange
	$rgname = getAssetName
	$svcName = $rgname + "-service"
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "West US"
	$sku = "Standard"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# 1. Act - Create
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode

		# Get
		$queryKey1 = $newSearchService | Get-AzSearchQueryKey
		$queryKey2 = Get-AzSearchQueryKey -ParentResourceId $newSearchService.Id
		$queryKey3 = Get-AzSearchQueryKey -ResourceGroupName $rgname -ServiceName $svcName

		# Assert
		Assert-NotNull $queryKey1
		Assert-NotNull $queryKey2
		Assert-NotNull $queryKey3

		# By default there will be one query key.
		Assert-AreEqual 1 $queryKey1.Count
		Assert-AreEqual $queryKey1.Count $queryKey2.Count
		Assert-AreEqual $queryKey2.Count $queryKey3.Count

		Assert-AreEqual $queryKey1[0].Name $queryKey2[0].Name
		Assert-AreEqual $queryKey2[0].Name $queryKey3[0].Name

		Assert-AreEqual $queryKey1[0].Key $queryKey2[0].Key
		Assert-AreEqual $queryKey2[0].Key $queryKey3[0].Key

		# New
		$newQueryKey1 = $newSearchService | New-AzSearchQueryKey -Name "newquerykey1"
		$newQueryKey2 = New-AzSearchQueryKey -ParentResourceId $newSearchService.Id -Name "newquerykey2"
		$newQueryKey3 = New-AzSearchQueryKey -ResourceGroupName $rgname -ServiceName $svcName -Name "newquerykey3"

		$allKeys = Get-AzSearchQueryKey -ParentResourceId $newSearchService.Id
		
		Assert-AreEqual 4 $allKeys.Count

		# Remove
		$newSearchService | Remove-AzSearchQueryKey -KeyValue $newQueryKey1.Key -Force
		Remove-AzSearchQueryKey -ParentResourceId $newSearchService.Id -KeyValue $newQueryKey2.Key -Force
		Remove-AzSearchQueryKey -ResourceGroupName $rgname -ServiceName $svcName -KeyValue $newQueryKey3.Key -Force

		$allKeys = Get-AzSearchQueryKey -ParentResourceId $newSearchService.Id

		Assert-AreEqual 1 $allKeys.Count
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}