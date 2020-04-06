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

function Test-AccountRelatedCmdlets
{
  $rgName = "CosmosDBResourceGroup2"
  $location = "East US"
  $locationlist = "East US", "West US"
  $locationlist2 = "East US", "UK South", "UK West", "South India"
  $locationlist3 = "West US", "East US"

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location

  $cosmosDBAccountName = "cosmosdb670"

  #use an existing account with the following information for Account Update Operations
  $cosmosDBExistingAccountName = "dbaccount27" 
  $existingResourceGroupName = "CosmosDBResourceGroup27"

  $ipRangeFilter = "192.168.0.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}

  $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -Location $location -IpRangeFilter $ipRangeFilter -Tag $tags -EnableVirtualNetwork  -EnableMultipleWriteLocations  -EnableAutomaticFailover -ApiKind "MongoDB"
    do 
    {
       $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")
  
  Assert-AreEqual $cosmosDBAccountName $cosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $cosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $cosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $cosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $ipRangeFilter $cosmosDBAccount.IpRangeFilter
  Assert-AreEqual $cosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $cosmosDBAccount.EnableMultipleWriteLocations 1
  Assert-AreEqual $cosmosDBAccount.IsVirtualNetworkFilterEnabled 1

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -IpRangeFilter $ipRangeFilter -Tag $tags -EnableVirtualNetwork 1 -EnableAutomaticFailover 1 
      do 
    {
       $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBExistingAccountName $updatedCosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $updatedCosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $updatedCosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $updatedCosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $ipRangeFilter $updatedCosmosDBAccount.IpRangeFilter
  Assert-AreEqual $updatedCosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $updatedCosmosDBAccount.IsVirtualNetworkFilterEnabled 1

  $cosmosDBAccountKey = Get-AzCosmosDBAccountKey -Name $cosmosDBAccountName -ResourceGroupName $rgname
  Assert-NotNull $cosmosDBAccountKey

  $cosmosDBAccountConnectionStrings = Get-AzCosmosDBAccountKey -Name $cosmosDBAccountName -ResourceGroupName $rgname -Type "ConnectionStrings"
  Assert-NotNull $cosmosDBAccountConnectionStrings

  $cosmosDBAccountReadOnlyKeys = Get-AzCosmosDBAccountKey -Name $cosmosDBAccountName -ResourceGroupName $rgname -Type "ReadOnlyKeys"
  Assert-NotNull $cosmosDBAccountReadOnlyKeys

  $RegeneratedKey = New-AzCosmosDBAccountKey -Name $cosmosDBAccountName -ResourceGroupName $rgname -KeyKind "primary"
  Assert-NotNull $RegeneratedKey 

  $IsAccountDeleted = Remove-AzCosmosDBAccount -Name $cosmosDBAccountName -ResourceGroupName $rgName -PassThru
  Assert-AreEqual $IsAccountDeleted true
}

function Test-AccountRelatedCmdletsUsingRid
{
  $FailoverPolicy = "UK West", "East US", "UK South", "South India"
  $locationlist2 = "UK South"

  #use an existing account with the following properties
  $cosmosDBExistingAccountName = "dbaccount27" 
  $existingResourceGroupName = "CosmosDBResourceGroup27"

  $ipRangeFilter = "192.168.0.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}

  $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
  $cosmosDBAccountByRid = Get-AzCosmosDBAccount -ResourceId $cosmosDBAccount.Id

  Assert-AreEqual $cosmosDBAccountByRid.Name $cosmosDBAccount.Name
  Assert-AreEqual $cosmosDBAccountByRid.ConsistencyPolicy.DefaultConsistencyLevel $cosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual $cosmosDBAccountByRid.ConsistencyPolicy.MaxIntervalInSeconds $cosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual $cosmosDBAccountByRid.ConsistencyPolicy.MaxStalenessPrefix $cosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $cosmosDBAccountByRid.IpRangeFilter $cosmosDBAccount.IpRangeFilter
  Assert-AreEqual $cosmosDBAccountByRid.EnableAutomaticFailover $cosmosDBAccount.EnableAutomaticFailover 
  Assert-AreEqual $cosmosDBAccountByRid.EnableMultipleWriteLocations $cosmosDBAccount.EnableMultipleWriteLocations
  Assert-AreEqual $cosmosDBAccountByRid.IsVirtualNetworkFilterEnabled $cosmosDBAccount.IsVirtualNetworkFilterEnabled

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceId $cosmosDBAccount.Id -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -IpRangeFilter $ipRangeFilter -Tag $tags -EnableVirtualNetwork 1 -EnableAutomaticFailover 1 
      do 
    {
       $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBExistingAccountName $updatedCosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $updatedCosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $updatedCosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $updatedCosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $ipRangeFilter $updatedCosmosDBAccount.IpRangeFilter
  Assert-AreEqual $updatedCosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $updatedCosmosDBAccount.IsVirtualNetworkFilterEnabled 1

  $cosmosDBAccountKey = Get-AzCosmosDBAccountKey -ResourceId $cosmosDBAccount.Id
  Assert-NotNull $cosmosDBAccountKey

  $cosmosDBAccountConnectionStrings = Get-AzCosmosDBAccountKey -ResourceId $cosmosDBAccount.Id -Type "ConnectionStrings"
  Assert-NotNull $cosmosDBAccountConnectionStrings

  $cosmosDBAccountReadOnlyKeys = Get-AzCosmosDBAccountKey -ResourceId $cosmosDBAccount.Id -Type "ReadOnlyKeys"
  Assert-NotNull $cosmosDBAccountReadOnlyKeys

  $RegeneratedKey = New-AzCosmosDBAccountKey -ResourceId $cosmosDBAccount.Id -KeyKind "secondaryReadonly"
  Assert-NotNull $RegeneratedKey
}

function Test-AccountRelatedCmdletsUsingObject
{
  #use an existing account with the following properties
  $cosmosDBExistingAccountName = "dbaccount27" 
  $existingResourceGroupName = "CosmosDBResourceGroup27"

  $ipRangeFilter = "192.168.0.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}

  $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
 
  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -InputObject $cosmosDBAccount -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -IpRangeFilter $ipRangeFilter -Tag $tags -EnableVirtualNetwork 1 -EnableAutomaticFailover 1 
      do 
    {
       $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBExistingAccountName $updatedCosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $updatedCosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $updatedCosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $updatedCosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual $ipRangeFilter $updatedCosmosDBAccount.IpRangeFilter
  Assert-AreEqual $updatedCosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $updatedCosmosDBAccount.IsVirtualNetworkFilterEnabled 1

  $cosmosDBAccountKey = Get-AzCosmosDBAccountKey -InputObject $cosmosDBAccount
  Assert-NotNull $cosmosDBAccountKey

  $cosmosDBAccountConnectionStrings = Get-AzCosmosDBAccountKey -InputObject $cosmosDBAccount -Type "ConnectionStrings"
  Assert-NotNull $cosmosDBAccountConnectionStrings

  $cosmosDBAccountReadOnlyKeys = Get-AzCosmosDBAccountKey -InputObject $cosmosDBAccount -Type "ReadOnlyKeys"
  Assert-NotNull $cosmosDBAccountReadOnlyKeys

  $RegeneratedKey = New-AzCosmosDBAccountKey -InputObject $cosmosDBAccount -KeyKind "primaryReadonly" 
  Assert-NotNull $RegeneratedKey

  $IsAccountDeleted = Remove-AzCosmosDBAccount -InputObject $cosmosDBAccount -PassThru
  Assert-AreEqual $IsAccountDeleted true
}