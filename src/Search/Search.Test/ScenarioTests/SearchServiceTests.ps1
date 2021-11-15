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
function Test-NewAzSearchService
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
function Test-NewAzSearchServiceBasic
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
function Test-NewAzSearchServiceL1
{
	# Arrange
	$rgname = getAssetName
	$rgname = $rgname
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "Central US EUAP"
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
Test New-AzSearchServiceIdentity
#>
function Test-NewAzSearchServiceIdentity
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
	$identityType = "SystemAssigned"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# Act
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode -IdentityType $identityType
		
		# Assert
		Assert-NotNull $newSearchService
		Assert-AreEqual $svcName $newSearchService.Name 
		Assert-AreEqual $sku $newSearchService.Sku
		Assert-AreEqual $loc $newSearchService.Location
		Assert-AreEqual $partitionCount $newSearchService.PartitionCount
		Assert-AreEqual $replicaCount $newSearchService.ReplicaCount
		Assert-AreEqual $hostingMode $newSearchService.HostingMode
		Assert-NotNull $newSearchService.Identity
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzSearchServicePublicNetworkAccessDisabled
#>
function Test-NewAzSearchServicePublicNetworkAccessDisabled
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
	$publicNetworkAccess = "Disabled"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# Act
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode -PublicNetworkAccess $publicNetworkAccess
		
		# Assert
		Assert-NotNull $newSearchService
		Assert-AreEqual $svcName $newSearchService.Name 
		Assert-AreEqual $sku $newSearchService.Sku
		Assert-AreEqual $loc $newSearchService.Location
		Assert-AreEqual $partitionCount $newSearchService.PartitionCount
		Assert-AreEqual $replicaCount $newSearchService.ReplicaCount
		Assert-AreEqual $hostingMode $newSearchService.HostingMode
		Assert-AreEqual $publicNetworkAccess $newSearchService.PublicNetworkAccess
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzSearchServiceIpRules
#>
function Test-NewAzSearchServiceIpRules
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
	$ipRules = 
		@([pscustomobject]@{Value="55.5.64.73"},
		[pscustomobject]@{Value="52.228.216.197"},
		[pscustomobject]@{Value="101.37.222.205"})

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# Act
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode -IpRuleList $ipRules
		
		# Assert
		Assert-NotNull $newSearchService
		Assert-AreEqual $svcName $newSearchService.Name 
		Assert-AreEqual $sku $newSearchService.Sku
		Assert-AreEqual $loc $newSearchService.Location
		Assert-AreEqual $partitionCount $newSearchService.PartitionCount
		Assert-AreEqual $replicaCount $newSearchService.ReplicaCount
		Assert-AreEqual $hostingMode $newSearchService.HostingMode
		Assert-AreEqual 3 $newSearchService.NetworkRuleSet.Count
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
function Test-GetAzSearchService
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

		# Create another one in the same ResourceGroup.
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
function Test-RemoveAzSearchService
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
function Test-SetAzSearchService
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
Test ManageAzSearchServiceAdminKey
#>
function Test-ManageAzSearchServiceAdminKey
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
Test ManageAzSearchServiceQueryKey
#>
function Test-ManageAzSearchServiceQueryKey
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

<#
.SYNOPSIS
Test Get-AzSearchPrivateLinkResource
#>
function Test-GetAzSearchPrivateLinkResource
{
	# Arrange
	$rgname = getAssetName
	$rgname = $rgname
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "Central US EUAP"
	$svcName = $rgname + "-service"
	$sku = "Basic"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# Create service
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode
		$privateLinkResources = Get-AzSearchPrivateLinkResource -ResourceGroupName $rgname -Name $svcName

		Assert-AreEqual 1 $privateLinkResources.Count

		Assert-NotNull $privateLinkResources[0].Id
		Assert-NotNull $privateLinkResources[0].GroupId
		Assert-True { $privateLinkResources[0].RequiredMembers.Count -gt 0 }
		Assert-True { $privateLinkResources[0].RequiredZoneNames.Count -gt 0 }
		Assert-True { $privateLinkResources[0].ShareablePrivateLinkResourceTypes.Count -gt 0 }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Get-AzSearchPrivateLinkResourcePipeline
#>
function Test-GetAzSearchPrivateLinkResourcePipeline
{
	# Arrange
	$rgname = getAssetName
	$rgname = $rgname
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "Central US EUAP"
	$svcName = $rgname + "-service"
	$sku = "Basic"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc
		
		# Create service
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode
		$privateLinkResources = $newSearchService | Get-AzSearchPrivateLinkResource

		Assert-AreEqual 1 $privateLinkResources.Count

		Assert-NotNull $privateLinkResources[0].Id
		Assert-NotNull $privateLinkResources[0].GroupId
		Assert-True { $privateLinkResources[0].RequiredMembers.Count -gt 0 }
		Assert-True { $privateLinkResources[0].RequiredZoneNames.Count -gt 0 }
		Assert-True { $privateLinkResources[0].ShareablePrivateLinkResourceTypes.Count -gt 0 }
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzSearchSharedPrivateLinkResource
Test Get-AzSearchSharedPrivateLinkResource
Test Set-AzSearchSharedPrivateLinkResource
Test Remove-AzSearchSharedPrivateLinkResource
#>
function Test-ManageAzSearchSharedPrivateLinkResources
{
	# Arrange
	$rgname = getAssetName
	$rgname = $rgname
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "Central US EUAP"
	$svcName = $rgname + "-service"
	$sku = "Basic"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc

		$resource1 = "blob-pe"
		$storageAccount1 = "pssweanzmd"
		$resourceObj1 = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $storageAccount1 -SkuName Standard_LRS -Kind StorageV2 -Location (Get-StorageLocation)
		$resourceId1 = $resourceObj1.Id

		$resource2 = "blob-pe2"
		$storageAccount2 = "pslnuvtdhp"
		$resourceObj2 = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $storageAccount2 -SkuName Standard_LRS -Kind StorageV2 -Location (Get-StorageLocation)
		$resourceId2 = $resourceObj2.Id

		$groupId = "blob"
		
		# Create service
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode
		
		# Create a shared private link resource to a pre-created storage account 
		$sharedPrivateLinkResource1 = New-AzSearchSharedPrivateLinkResource `
			-ResourceGroupName $rgname `
			-ServiceName $svcName `
			-Name $resource1 `
			-PrivateLinkResourceId $resourceId1 `
			-GroupId $groupId `
			-RequestMessage "Please approve" 

		Assert-NotNull $sharedPrivateLinkResource1

		# Create a shared private link resource to another pre-created storage account 
		$sharedPrivateLinkResource2 = New-AzSearchSharedPrivateLinkResource `
			-ResourceGroupName $rgname `
			-ServiceName $svcName `
			-Name $resource2 `
			-PrivateLinkResourceId $resourceId2 `
			-GroupId $groupId `
			-RequestMessage "Please approve" 

		Assert-NotNull $sharedPrivateLinkResource2

		# Create a shared private link resource to the same pre-created storage account but with different group id
		$sharedPrivateLinkResource3 = New-AzSearchSharedPrivateLinkResource `
			-ResourceGroupName $rgname `
			-ServiceName $svcName `
			-Name "table-pe" `
			-PrivateLinkResourceId $resourceId2 `
			-GroupId "table" `
			-RequestMessage "Please approve" 

		Assert-NotNull $sharedPrivateLinkResource3

		# List all shared private link resources
		$sharedPrivateLinkResources = Get-AzSearchSharedPrivateLinkResource -ResourceGroupName $rgname -ServiceName $svcName
		Assert-AreEqual 3 $sharedPrivateLinkResources.Count

		# Get a specific shared private link resource
		$sharedPrivateLinkResource = Get-AzSearchSharedPrivateLinkResource -ResourceGroupName $rgname -ServiceName $svcName -Name $resource1
		Assert-AreEqual $resource1 $sharedPrivateLinkResource.Name

		# Get a specific shared private link resource by resource id
		$sharedPrivateLinkResource = Get-AzSearchSharedPrivateLinkResource -ResourceId $sharedPrivateLinkResource2.Id
		Assert-AreEqual $resource2 $sharedPrivateLinkResource.Name

		# Update the request message of a specific shared private link resource
		$sharedPrivateLinkResourceUpdated = Set-AzSearchSharedPrivateLinkResource `
			-ResourceGroupName $rgname `
			-ServiceName $svcName `
			-Name $resource2 `
			-RequestMessage "Please kindly approve"

		Assert-AreEqual $resource2 $sharedPrivateLinkResourceUpdated.Name
		Assert-AreEqual "Please kindly approve" $sharedPrivateLinkResourceUpdated.RequestMessage

		# Update the request message of a different shared private link resource by resource id
		$sharedPrivateLinkResourceUpdated = Set-AzSearchSharedPrivateLinkResource `
			-ResourceId $sharedPrivateLinkResource1.Id `
			-RequestMessage "Please kindly approve resource 1"

		Assert-AreEqual $resource1 $sharedPrivateLinkResourceUpdated.Name
		Assert-AreEqual "Please kindly approve resource 1" $sharedPrivateLinkResourceUpdated.RequestMessage

		# Delete a specific shared private link resource
		Remove-AzSearchSharedPrivateLinkResource -ResourceGroupName $rgname -ServiceName $svcName -Name $resource1 -Force

		# Delete a specific shared private link resource by resource id
		Remove-AzSearchSharedPrivateLinkResource -ResourceId $sharedPrivateLinkResource2.Id -Force

		# List all the shared private link resources of the service
		$sharedPrivateLinkResources = Get-AzSearchSharedPrivateLinkResource -ResourceGroupName $rgname -ServiceName $svcName
		Assert-AreEqual 1 $sharedPrivateLinkResources.Count
		Assert-AreEqual "table-pe" $sharedPrivateLinkResources[0].Name
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ManageAzSearchSharedPrivateLinkResourcePipeline
#>
function Test-ManageAzSearchSharedPrivateLinkResourcePipeline
{
# Arrange
	$rgname = getAssetName
	$rgname = $rgname
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "Central US EUAP"
	$svcName = $rgname + "-service"
	$sku = "Basic"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc

		$resource1 = "blob-pe"
		$storageAccount1 = "pstalexsmn"
		$resourceObj1 = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $storageAccount1 -SkuName Standard_LRS -Kind StorageV2 -Location (Get-StorageLocation)
		$resourceId1 = $resourceObj1.Id

		$resource2 = "blob-pe2"
		$storageAccount2 = "psotjpehnm"
		$resourceObj2 = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $storageAccount2 -SkuName Standard_LRS -Kind StorageV2 -Location (Get-StorageLocation)
		$resourceId2 = $resourceObj2.Id

		$groupId = "blob"
		
		# Create service
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode
		
		# Create a shared private link resource to a pre-created storage account 
		$sharedPrivateLinkResource1 = New-AzSearchSharedPrivateLinkResource `
			-ResourceGroupName $rgname `
			-ServiceName $svcName `
			-Name $resource1 `
			-PrivateLinkResourceId $resourceId1 `
			-GroupId $groupId `
			-RequestMessage "Please approve" 

		Assert-NotNull $sharedPrivateLinkResource1

		# Create a shared private link resource to another pre-created storage account 
		$sharedPrivateLinkResource2 = New-AzSearchSharedPrivateLinkResource `
			-ResourceGroupName $rgname `
			-ServiceName $svcName `
			-Name $resource2 `
			-PrivateLinkResourceId $resourceId2 `
			-GroupId $groupId `
			-RequestMessage "Please approve" 

		Assert-NotNull $sharedPrivateLinkResource2

		# List all shared private link resources via pipeline object (parent)
		$sharedPrivateLinkResources = Get-AzSearchService -ResourceGroupName $rgname -Name $svcName | Get-AzSearchSharedPrivateLinkResource
		Assert-AreEqual 2 $sharedPrivateLinkResources.Count

		# Get a specific shared private link resource via pipeline object (parent)
		$sharedPrivateLinkResource = Get-AzSearchService -ResourceGroupName $rgname -Name $svcName `
		| Get-AzSearchSharedPrivateLinkResource -Name $resource1
		Assert-AreEqual $resource1 $sharedPrivateLinkResource.Name

		# Update the request message of a specific shared private link resource via pipeline object (input)
		$sharedPrivateLinkResourceUpdated = Get-AzSearchService -ResourceGroupName $rgname -Name $svcName `
		| Get-AzSearchSharedPrivateLinkResource -Name $resource2 `
		| Set-AzSearchSharedPrivateLinkResource -RequestMessage "Please kindly approve"

		Assert-AreEqual $resource2 $sharedPrivateLinkResourceUpdated.Name
		Assert-AreEqual "Please kindly approve" $sharedPrivateLinkResourceUpdated.RequestMessage

		# Update the request message of a different shared private link resource via pipeline object (parent)
		$sharedPrivateLinkResourceUpdated = Get-AzSearchService -ResourceGroupName $rgname -Name $svcName `
		| Set-AzSearchSharedPrivateLinkResource -Name $resource1 -RequestMessage "Please kindly approve resource 1"

		Assert-AreEqual $resource1 $sharedPrivateLinkResourceUpdated.Name
		Assert-AreEqual "Please kindly approve resource 1" $sharedPrivateLinkResourceUpdated.RequestMessage

		# Delete a specific shared private link resource via pipeline object (input)
		Get-AzSearchService -ResourceGroupName $rgname -Name $svcName `
		| Get-AzSearchSharedPrivateLinkResource -Name $resource1 `
		| Remove-AzSearchSharedPrivateLinkResource -Force

		# Delete a specific shared private link resource via pipeline object (parent)
		Get-AzSearchService -ResourceGroupName $rgname -Name $svcName `
		| Remove-AzSearchSharedPrivateLinkResource -Name $resource2 -Force

		# List all the shared private link resources of the service
		$sharedPrivateLinkResources = Get-AzSearchSharedPrivateLinkResource -ResourceGroupName $rgname -ServiceName $svcName
		Assert-AreEqual 0 $sharedPrivateLinkResources.Count
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test ManageAzSearchSharedPrivateLinkResourceJob
#>
function Test-ManageAzSearchSharedPrivateLinkResourceJob
{
# Arrange
	$rgname = getAssetName
	$rgname = $rgname
	$loc = Get-Location -providerNamespace "Microsoft.Search" -resourceType "searchServices" -preferredLocation "Central US EUAP"
	$svcName = $rgname + "-service"
	$sku = "Basic"
	$partitionCount = 1
	$replicaCount = 1
	$hostingMode = "Default"

	try
    {
		New-AzResourceGroup -Name $rgname -Location $loc

		$resource1 = "blob-pe"

		# A random name
		$storageAccount1 = "psjiuxstbg"
		$resourceObj1 = New-AzStorageAccount -ResourceGroupName $rgname -StorageAccountName $storageAccount1 -SkuName Standard_LRS -Kind StorageV2 -Location (Get-StorageLocation)
		$resourceId1 = $resourceObj1.Id

		$groupId = "blob"
		
		# Create service
		$newSearchService = New-AzSearchService -ResourceGroupName $rgname -Name $svcName -Sku $sku -Location $loc -PartitionCount $partitionCount -ReplicaCount $replicaCount -HostingMode $hostingMode
		
		# Create a shared private link resource to a pre-created storage account 
		$createJob = New-AzSearchSharedPrivateLinkResource `
			-ResourceGroupName $rgname `
			-ServiceName $svcName `
			-Name $resource1 `
			-PrivateLinkResourceId $resourceId1 `
			-GroupId $groupId `
			-RequestMessage "Please approve" `
			-AsJob

		$stopwatch =  [system.diagnostics.stopwatch]::StartNew()
		Write-Verbose "Querying for create job completion"
		while ($true)
		{
			if ($stopwatch.Elapsed.TotalMinutes -gt 10)
			{
				throw [System.InvalidOperationException] "Took too long to create shared private link resource."
			}

			$createState = ($createJob | Get-Job).State
			if ($createState -ne "Completed")
			{
				Write-Verbose "Job still running waiting for 30 seconds before trying again"
				Start-Sleep -Seconds 30
			}
			else
			{
				Write-Verbose "Job completed"
				break
			}
		} 
		$stopwatch.Stop()

		# List all the shared private link resources of the service
		$sharedPrivateLinkResources = Get-AzSearchSharedPrivateLinkResource -ResourceGroupName $rgname -ServiceName $svcName
		Assert-AreEqual 1 $sharedPrivateLinkResources.Count

		$deleteJob = Remove-AzSearchSharedPrivateLinkResource `
			-ResourceGroupName $rgname `
			-ServiceName $svcName `
			-Name $resource1 `
			-Force `
			-AsJob

		$stopwatch =  [system.diagnostics.stopwatch]::StartNew()
		Write-Verbose "Querying for delete job completion"
		while ($true)
		{
			if ($stopwatch.Elapsed.TotalMinutes -gt 10)
			{
				throw [System.InvalidOperationException] "Took too long to delete shared private link resource."
			}

			$deleteState = ($deleteJob | Get-Job).State
			if ($deleteState -ne "Completed")
			{
				Write-Verbose "Job still running waiting for 30 seconds before trying again"
				Start-Sleep -Seconds 30
			}
			else
			{
				Write-Verbose "Job completed"
				break
			}
		}
		$stopwatch.Stop()

		# List all the shared private link resources of the service
		$sharedPrivateLinkResources = Get-AzSearchSharedPrivateLinkResource -ResourceGroupName $rgname -ServiceName $svcName
		Assert-AreEqual 0 $sharedPrivateLinkResources.Count
	}
	finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}