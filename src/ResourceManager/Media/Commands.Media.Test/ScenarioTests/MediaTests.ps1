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
Test Media related Cmdlets
#>
function Test-Media 
{
  $rgname = GetResourceGroupName
  $preferedlocation = "East US"
  $location = Get-AvailableLocation $preferedlocation
  Write-Output $location

  $resourceGroup = CreateResourceGroup $rgname $location

  $storageAccountName1 = "sto" + $rgname
  $storageAccount1 = CreateStorageAccount $rgname $storageAccountName1 $location

  $storageAccountName2 = "sto" + $rgname + "2"
  $storageAccount2 = CreateStorageAccount $rgname $storageAccountName2 $location

  <# Check name availability #>
  $accountName = "med" + $rgname
  $availability = Get-AzureRmMediaServiceNameAvailability -AccountName $accountName
  Assert-AreEqual $true $availability.nameAvailable

  <# Create a media service with specifiying the primary storage account only #>
  $accountName = "med" + $rgname
  $tags = @{"tag1" = "value1"; "tag2" = "value2"}
  $storageAccount1 = GetStorageAccount -ResourceGroupName $rgname -Name $storageAccountName1
  $mediaService = New-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName -Location $location -StorageAccountId $storageAccount1.Id -Tags $tags
  Assert-NotNull $mediaService
  Assert-AreEqual $accountName $mediaService.AccountName
  Assert-AreEqual $rgname $mediaService.ResourceGroupName
  Assert-AreEqual $location $mediaService.Location
  Assert-Tags $tags $mediaService.Tags
  Assert-AreEqual $storageAccountName1 $mediaService.StorageAccounts[0].AccountName
  Assert-AreEqual $true $mediaService.StorageAccounts[0].IsPrimary
  Assert-AreEqual $rgname $mediaService.StorageAccounts[0].ResourceGroupName

  $availability = Get-AzureRmMediaServiceNameAvailability -AccountName $accountName
  Assert-AreEqual $false $availability.nameAvailable

  <# Get a media service with specifying resource group only #>
  $mediaServices = Get-AzureRmMediaService -ResourceGroupName $rgname 
  Assert-NotNull $mediaServices
  Assert-AreEqual 1 $mediaServices.Count
  Assert-AreEqual $accountName $mediaServices[0].AccountName
  Assert-AreEqual $rgname $mediaServices[0].ResourceGroupName
  Assert-AreEqual $location $mediaServices[0].Location
  Assert-AreEqual $storageAccountName1 $mediaServices[0].StorageAccounts[0].AccountName
  Assert-AreEqual $true $mediaService.StorageAccounts[0].IsPrimary
  Assert-AreEqual $rgname $mediaServices[0].StorageAccounts[0].ResourceGroupName

  <# Get a media service with specifying resource group and account name #>
  $mediaService = Get-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName
  Assert-NotNull $mediaService
  Assert-AreEqual $accountName $mediaService.AccountName
  Assert-AreEqual $rgname $mediaService.ResourceGroupName
  Assert-AreEqual $location $mediaService.Location
  Assert-AreEqual $storageAccountName1 $mediaService.StorageAccounts[0].AccountName
  Assert-AreEqual $true $mediaService.StorageAccounts[0].IsPrimary
  Assert-AreEqual $rgname $mediaService.StorageAccounts[0].ResourceGroupName

  <# Set a media service #>
  $tagsUpdated = @{"tag3" = "value3"; "tag4" = "value4"}
  $storageAccount2 = GetStorageAccount -ResourceGroupName $rgname -Name $storageAccountName2
  $primaryStorageAccount = New-AzureRmMediaServiceStorageConfig -storageAccountId $storageAccount1.Id -IsPrimary
  $secondaryStorageAccount = New-AzureRmMediaServiceStorageConfig -storageAccountId $storageAccount2.Id
  $storageAccounts = @($primaryStorageAccount, $secondaryStorageAccount)
  $mediaServiceUpdated = Set-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName -Tags $tagsUpdated -StorageAccounts $storageAccounts
  Assert-NotNull $mediaServiceUpdated
  Assert-Tags $tagsUpdated $mediaServiceUpdated.Tags
  Assert-AreEqual $storageAccountName1 $mediaServiceUpdated.StorageAccounts[0].AccountName
  Assert-AreEqual $true $mediaService.StorageAccounts[0].IsPrimary
  Assert-AreEqual $storageAccountName2 $mediaServiceUpdated.StorageAccounts[1].AccountName
  Assert-AreEqual $false $mediaServiceUpdated.StorageAccounts[1].IsPrimary

  <# Get service keys #>
  $serviceKeys = Get-AzureRmMediaServiceKeys -ResourceGroupName $rgname -AccountName $accountName
  Assert-NotNull $serviceKeys
  Assert-NotNull $serviceKeys.PrimaryAuthEndpoint
  Assert-NotNull $serviceKeys.PrimaryKey
  Assert-NotNull $serviceKeys.SecondaryAuthEndpoint
  Assert-NotNull $serviceKeys.SecondaryKey
  Assert-NotNull $serviceKeys.Scope

  <# Set service key #>
  $serviceKeysUpdated1 = Set-AzureRmMediaServiceKey -ResourceGroupName $rgname -AccountName $accountName -KeyType Primary
  Assert-NotNull $serviceKeysUpdated1
  Assert-NotNull $serviceKeysUpdated1.Key
  Assert-AreNotEqual $serviceKeys.PrimaryKey $serviceKeysUpdated1.Key

  $serviceKeysUpdated2 = Set-AzureRmMediaServiceKey -ResourceGroupName $rgname -AccountName $accountName -KeyType Secondary
  Assert-NotNull $serviceKeysUpdated2
  Assert-NotNull $serviceKeysUpdated2.Key
  Assert-AreNotEqual $serviceKeys.SecondaryKey $serviceKeysUpdated2.Key

  <# Remove media service #>
  Remove-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName -Force
  $mediaServices = Get-AzureRmMediaService -ResourceGroupName $rgname
  Assert-Null $mediaServices

  <# Create a media service with multiple storage accounts #>
  $tags = @{"tag1" = "value1"; "tag2" = "value2"}
  $mediaService = New-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName -Location $location -StorageAccounts $storageAccounts -Tags $tags
  Assert-NotNull $mediaService
  Assert-AreEqual $accountName $mediaService.AccountName
  Assert-AreEqual $rgname $mediaService.ResourceGroupName
  Assert-AreEqual $location $mediaService.Location
  Assert-Tags $tags $mediaService.Tags
  Assert-AreEqual $storageAccountName1 $mediaService.StorageAccounts[0].AccountName
  Assert-AreEqual $true $mediaService.StorageAccounts[0].IsPrimary
  Assert-AreEqual $rgname $mediaService.StorageAccounts[0].ResourceGroupName
  Assert-AreEqual $storageAccountName2 $mediaService.StorageAccounts[1].AccountName
  Assert-AreEqual $false $mediaService.StorageAccounts[1].IsPrimary
  Assert-AreEqual $rgname $mediaService.StorageAccounts[1].ResourceGroupName

  Remove-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName -Force
  RemoveStorageAccount $rgname $storageAccountName1
  RemoveStorageAccount $rgname $storageAccountName2
  RemoveResourceGroup $rgname
}

<#
.SYNOPSIS
Test Media related Cmdlets with piping
#>
function Test-MediaWithPiping
{
  $rgname = GetResourceGroupName
  $preferedlocation = "East US"
  $location = Get-AvailableLocation $preferedlocation

  $resourceGroup = CreateResourceGroup $rgname $location
  Assert-NotNull $resourceGroup
  Assert-AreEqual $rgname $resourceGroup.ResourceGroupName
  Assert-AreEqual $location $resourceGroup.Location

  $storageAccountName1 = "sto" + $rgname
  $storageAccount1 = CreateStorageAccount $rgname $storageAccountName1 $location
  
  <# Create a media service with piping #>
  $accountName = "med" + $rgname
  $tags = @{"tag1" = "value1"; "tag2" = "value2"}
  $mediaService = GetStorageAccount -ResourceGroupName $rgname -Name $storageAccountName1 | New-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName -Location $location -Tags $tags
  Assert-NotNull $mediaService
  Assert-AreEqual $accountName $mediaService.AccountName
  Assert-AreEqual $rgname $mediaService.ResourceGroupName
  Assert-AreEqual $location $mediaService.Location
  Assert-Tags $tags $mediaService.Tags
  Assert-AreEqual $storageAccountName1 $mediaService.StorageAccounts[0].AccountName
  Assert-AreEqual $true $mediaService.StorageAccounts[0].IsPrimary
  Assert-AreEqual $rgname $mediaService.StorageAccounts[0].ResourceGroupName

  <# Update a media service with piping #>
  $tagsUpdated = @{"tag3" = "value3"; "tag4" = "value4"}
  $mediaServiceUpdated = Get-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName | Set-AzureRmMediaService -Tags $tagsUpdated
  Assert-NotNull $mediaServiceUpdated
  Assert-Tags $tagsUpdated $mediaServiceUpdated.Tags

  <# Get service keys with piping #>
  $serviceKeys = Get-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName | Get-AzureRmMediaServiceKeys
  Assert-NotNull $serviceKeys
  Assert-NotNull $serviceKeys.PrimaryAuthEndpoint
  Assert-NotNull $serviceKeys.PrimaryKey
  Assert-NotNull $serviceKeys.SecondaryAuthEndpoint
  Assert-NotNull $serviceKeys.SecondaryKey
  Assert-NotNull $serviceKeys.Scope

  <# Set service keys with piping #>
  $serviceKeysUpdated2 = Get-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName | Set-AzureRmMediaServiceKey -KeyType Secondary
  Assert-NotNull $serviceKeysUpdated2
  Assert-NotNull $serviceKeysUpdated2.Key
  Assert-AreNotEqual $serviceKeys.SecondaryKey $serviceKeysUpdated2.Key

  <# Remove media service with piping #>
  Get-AzureRmMediaService -ResourceGroupName $rgname -AccountName $accountName | Remove-AzureRmMediaService -Force
  
  RemoveStorageAccount $rgname $storageAccountName
  RemoveResourceGroup $rgname
}