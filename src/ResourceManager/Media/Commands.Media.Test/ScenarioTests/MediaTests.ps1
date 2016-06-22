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
  $location = "East US"

  $resourceGroup = CreateResourceGroup $rgname $location
  Assert-NotNull $resourceGroup
  Assert-AreEqual $rgname $resourceGroup.ResourceGroupName
  Assert-AreEqual $location $resourceGroup.Location

  $storageAccountName = "sto" + $rgname
  $storageAccount = CreateStorageAccount $rgname $storageAccountName $location
  Assert-NotNull $storageAccount
  Assert-AreEqual $rgname $storageAccount.ResourceGroupName
  Assert-AreEqual $storageAccountName $storageAccount.Name

  $mediaServiceAccountName = "med" + $rgname
  $tags = @{"tag1" = "value1"; "tag2" = "value2"}
  $mediaService = New-AzureRmMediaService -ResourceGroupName $rgname -MediaServiceAccountName $mediaServiceAccountName -Location $location -Tags $tags -StorageAccountName $storageAccountName
  Assert-NotNull $mediaService
  Assert-AreEqual $mediaServiceAccountName $mediaService.Name
  Assert-AreEqual $rgname $mediaService.ResourceGroupName
  Assert-AreEqual $location $mediaService.Location
  Assert-Tags $tags $mediaService.Tags
  Assert-AreEqual $storageAccountName $mediaService.Properties.StorageAccounts[0].StorageAccountName
  Assert-AreEqual $rgname $mediaService.Properties.StorageAccounts[0].ResourceGroupName

  $mediaServices = Show-AzureRmMediaServices -ResourceGroupName $rgname
  Assert-NotNull $mediaServices
  Assert-AreEqual 1 $mediaServices.Count
  Assert-AreEqual $mediaServiceAccountName $mediaServices[0].Name
  Assert-AreEqual $rgname $mediaServices[0].ResourceGroupName
  Assert-AreEqual $location $mediaServices[0].Location
  Assert-AreEqual $storageAccountName $mediaServices[0].Properties.StorageAccounts[0].StorageAccountName
  Assert-AreEqual $rgname $mediaServices[0].Properties.StorageAccounts[0].ResourceGroupName

  $tagsUpdated = @{"tag3" = "value3"; "tag4" = "value4"}
  $mediaServiceUpdated = Set-AzureRmMediaService -ResourceGroupName $rgname -MediaServiceAccountName $mediaServiceAccountName -Tags $tagsUpdated
  Assert-NotNull $mediaServiceUpdated
  Assert-Tags $tagsUpdated $mediaServiceUpdated.Tags

  $serviceKeys = Show-AzureRmMediaServiceKeys -ResourceGroupName $rgname -MediaServiceAccountName $mediaServiceAccountName
  Assert-NotNull $serviceKeys
  Assert-NotNull $serviceKeys.PrimaryAuthEndpoint
  Assert-NotNull $serviceKeys.PrimaryKey
  Assert-NotNull $serviceKeys.SecondaryAuthEndpoint
  Assert-NotNull $serviceKeys.SecondaryKey
  Assert-NotNull $serviceKeys.Scope

  $serviceKeysUpdated1 = Set-AzureRmMediaServiceKey -ResourceGroupName $rgname -MediaServiceAccountName $mediaServiceAccountName -KeyType "Primary"
  Assert-NotNull $serviceKeysUpdated1
  Assert-NotNull $serviceKeysUpdated1.Key
  Assert-AreNotEqual $serviceKeys.PrimaryKey $serviceKeysUpdated1.Key

  $serviceKeysUpdated2 = Set-AzureRmMediaServiceKey -ResourceGroupName $rgname -MediaServiceAccountName $mediaServiceAccountName -KeyType "Secondary"
  Assert-NotNull $serviceKeysUpdated2
  Assert-NotNull $serviceKeysUpdated2.Key
  Assert-AreNotEqual $serviceKeys.SecondaryKey $serviceKeysUpdated2.Key

  Remove-AzureRmMediaService -ResourceGroupName $rgname -MediaServiceAccountName $mediaServiceAccountName
  $mediaServices = Show-AzureRmMediaServices -ResourceGroupName $rgname
  Assert-Null $mediaServices

  RemoveStorageAccount $rgname $storageAccountName
  RemoveResourceGroup $rgname
}