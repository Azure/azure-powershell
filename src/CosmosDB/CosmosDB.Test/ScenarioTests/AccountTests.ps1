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
Gets and removes custom domain with running endpoint.
#>

function Test-AccountRelatedCmdlets
{
  $rgName = "rgtest9921232812"
  $location = "East US"
  $locationlist = "East US", "West US"
  $locationlist2 = "East US", "UK South", "UK West", "South India"
  $locationlist3 = "West US", "East US"

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location

  $cosmosDBAccountName1 = "cosmosdb9921232812"
  $cosmosDBAccountName2 = "cosmosdb99121232812"
  $cosmosDBAccountName3 = "cosmosdb99221232812" 

  $cosmosDBExistingAccountName = "cosmosdb99"
  $existingResourceGroupName = "rgtest99"

  $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName1 -Location  $locationlist
  do 
    {
       $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName1
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")
  Assert-AreEqual $cosmosDBAccountName1 $cosmosDBAccount.Name

  $cosmosDBAccount2 = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName2 -DefaultConsistencyLevel "Eventual" -Location  $locationlist  -ApiKind "MongoDB"
  do 
    {
       $cosmosDBAccount2 = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName2
    } while ($cosmosDBAccount2.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBAccountName2 $cosmosDBAccount2.Name
  Assert-AreEqual "Eventual" $cosmosDBAccount2.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual "MongoDB" $cosmosDBAccount2.Kind
  
  $ipRangeFilter = "192.168.0.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}

  $cosmosDBAccount3 = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName3 -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -Location $locationlist -IpRangeFilter $ipRangeFilter -Tag $tags -EnableVirtualNetwork  -EnableMultipleWriteLocations  -EnableAutomaticFailover
    do 
    {
       $cosmosDBAccount3 = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName3
    } while ($cosmosDBAccount3.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBAccountName3 $cosmosDBAccount3.Name
  Assert-AreEqual "BoundedStaleness" $cosmosDBAccount3.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $cosmosDBAccount3.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $cosmosDBAccount3.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual "192.168.0.1" $cosmosDBAccount3.IpRangeFilter
  Assert-AreEqual $cosmosDBAccount3.EnableAutomaticFailover 1 
  Assert-AreEqual $cosmosDBAccount3.EnableMultipleWriteLocations 1
  Assert-AreEqual $cosmosDBAccount3.IsVirtualNetworkFilterEnabled 1

  $updatedCosmosDBAccount2 = Update-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -IpRangeFilter $ipRangeFilter -Tag $tags -EnableVirtualNetwork 1 -EnableAutomaticFailover 1 
    do 
    {
       $updatedCosmosDBAccount2 = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
    } while ($updatedCosmosDBAccount2.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBExistingAccountName $updatedCosmosDBAccount2.Name
  Assert-AreEqual "BoundedStaleness" $updatedCosmosDBAccount2.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $updatedCosmosDBAccount2.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $updatedCosmosDBAccount2.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual "192.168.0.1" $updatedCosmosDBAccount2.IpRangeFilter
  Assert-AreEqual $updatedCosmosDBAccount2.EnableAutomaticFailover 1 
  Assert-AreEqual $updatedCosmosDBAccount2.IsVirtualNetworkFilterEnabled 1

  $updatedCosmosDBAccount2Location = Update-AzCosmosDBAccountRegion -ResourceGroupName $rgName -Name $cosmosDBAccountName2 -Location $locationlist2 -PassThru
  $updatedFailoverPriority = Update-AzCosmosDBAccountFailoverPriority -ResourceGroupName $rgName -Name $cosmosDBAccountName2 -FailoverPolicy $locationlist -PassThru
  Assert-AreEqual $updatedFailoverPriority true

  $IsAccountDeleted = Remove-AzCosmosDBAccount -Name $cosmosDBAccountName1 -ResourceGroupName $rgName -PassThru
  Assert-AreEqual $IsAccountDeleted true

  do 
    {
		$DeletedAccount = Get-AzCosmosDBAccount -Name $cosmosDBAccountName1 -ResourceGroupName $rgName
    } while ($DeletedAccount.ProvisioningState -ne "Deleting")
  
  $IsAccountDeleted = Remove-AzCosmosDBAccount -Name $cosmosDBAccountName2 -ResourceGroupName $rgName -PassThru
  Assert-AreEqual $IsAccountDeleted true

  do 
    {
		$DeletedAccount = Get-AzCosmosDBAccount -Name $cosmosDBAccountName2 -ResourceGroupName $rgName
    } while ($DeletedAccount.ProvisioningState -ne "Deleting")

  $IsAccountDeleted = Remove-AzCosmosDBAccount -Name $cosmosDBAccountName3 -ResourceGroupName $rgName -PassThru
  Assert-AreEqual $IsAccountDeleted true

  do 
    {
		$DeletedAccount = Get-AzCosmosDBAccount -Name $cosmosDBAccountName3 -ResourceGroupName $rgName
    } while ($DeletedAccount.ProvisioningState -ne "Deleting")
}

function Test-ResourceIdParameterSet
{
  $rgName = "rgtest9921251"
  $location = "East US"
  $locationlist = "East US", "West US"
  $locationlist2 = "East US", "UK South", "UK West", "South India"

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location $location

  $cosmosDBAccountName1 = "cosmosdb9921251"

  $cosmosDBExistingAccountName = "cosmosdb99"
  $existingResourceGroupName = "rgtest99"

  $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName1 -Location $locationlist
  do 
    {
       $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceId $cosmosDBAccount.Id
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")
  Assert-AreEqual $cosmosDBAccountName1 $cosmosDBAccount.Name
 
  $ipRangeFilter = "192.168.0.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}
  $existingCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceId $existingCosmosDBAccount.Id -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -IpRangeFilter $ipRangeFilter -Tag $tags -EnableVirtualNetwork 1 -EnableAutomaticFailover 1 
    do 
    {
       $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceId $updatedCosmosDBAccount.Id
    } while ($updatedCosmosDBAccount.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBExistingAccountName $updatedCosmosDBAccount.Name
  Assert-AreEqual "BoundedStaleness" $updatedCosmosDBAccount.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $updatedCosmosDBAccount.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $updatedCosmosDBAccount.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual "192.168.0.1" $updatedCosmosDBAccount.IpRangeFilter
  Assert-AreEqual $updatedCosmosDBAccount.EnableAutomaticFailover 1 
  Assert-AreEqual $updatedCosmosDBAccount.IsVirtualNetworkFilterEnabled 1

  $updatedCosmosDBAccountLocation = Update-AzCosmosDBAccountRegion -ResourceId $cosmosDBAccount.Id -Location $locationlist2 -PassThru
  $updatedFailoverPriority = Update-AzCosmosDBAccountFailoverPriority -ResourceId $cosmosDBAccount.Id -FailoverPolicy $locationlist -PassThru
  Assert-AreEqual $updatedFailoverPriority true

  $IsAccountDeleted = Remove-AzCosmosDBAccount -ResourceId $cosmosDBAccount.Id -PassThru
  Assert-AreEqual $IsAccountDeleted true
}

function Test-ObjectParameterSet
{
  $rgName = "rgtest99212328411212"
  $location = "East US"
  $locationlist = "East US", "West US"
  $locationlist2 = "East US", "UK South", "UK West", "South India"
  $locationlist3 = "West US", "East US"

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location

  $cosmosDBAccountName1 = "cosmosdb99212328411212"

  $cosmosDBExistingAccountName = "cosmosdb99"
  $existingResourceGroupName = "rgtest99"

  $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName1 -Location  $locationlist
  do 
    {
       $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName1
    } while ($cosmosDBAccount.ProvisioningState -ne "Succeeded")
  Assert-AreEqual $cosmosDBAccountName1 $cosmosDBAccount.Name

  $ipRangeFilter = "192.168.0.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}

  $updatedCosmosDBAccount2 = Update-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -IpRangeFilter $ipRangeFilter -Tag $tags -EnableVirtualNetwork 1 -EnableAutomaticFailover 1 
    do 
    {
       $updatedCosmosDBAccount2 = Get-AzCosmosDBAccount -ResourceGroupName $existingResourceGroupName -Name $cosmosDBExistingAccountName
    } while ($updatedCosmosDBAccount2.ProvisioningState -ne "Succeeded")

  Assert-AreEqual $cosmosDBExistingAccountName $updatedCosmosDBAccount2.Name
  Assert-AreEqual "BoundedStaleness" $updatedCosmosDBAccount2.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $updatedCosmosDBAccount2.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $updatedCosmosDBAccount2.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual "192.168.0.1" $updatedCosmosDBAccount2.IpRangeFilter
  Assert-AreEqual $updatedCosmosDBAccount2.EnableAutomaticFailover 1 
  Assert-AreEqual $updatedCosmosDBAccount2.IsVirtualNetworkFilterEnabled 1

  $updatedCosmosDBAccount2Location = Update-AzCosmosDBAccountRegion -InputObject $cosmosDBAccount -Location $locationlist2 -PassThru
  $updatedFailoverPriority = Update-AzCosmosDBAccountFailoverPriority -InputObject $cosmosDBAccount -FailoverPolicy $locationlist -PassThru
  Assert-AreEqual $updatedFailoverPriority true

  $IsAccountDeleted = Remove-AzCosmosDBAccount -InputObject $cosmosDBAccount -PassThru
  Assert-AreEqual $IsAccountDeleted true
}