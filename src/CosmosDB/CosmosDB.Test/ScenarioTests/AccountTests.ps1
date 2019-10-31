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
  $rgname = "testrg78945120912101"
  $preferedlocation = "East US"
  $locationlist = "East US", "West US"
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgname  -Location $preferedlocation

   $cosmosDBAccountName1 = "testcosmosdb78945120912101" 

   $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgname -Name $cosmosDBAccountName1 -Location  $locationlist
   Assert-AreEqual $cosmosDBAccountName1 $cosmosDBAccount.Name

   $cosmosDBAccountName2 = "testcosmosdb789451120912101" 
   $cosmosDBAccount2 = New-AzCosmosDBAccount -ResourceGroupName $rgname -Name $cosmosDBAccountName2 -DefaultConsistencyLevel "Eventual" -Location  $locationlist  -ApiKind "MongoDB"
   Assert-AreEqual $cosmosDBAccountName2 $cosmosDBAccount2.Name
   Assert-AreEqual "Eventual" $cosmosDBAccount2.ConsistencyPolicy.DefaultConsistencyLevel
   Assert-AreEqual "MongoDB" $cosmosDBAccount2.Kind
  
  Remove-AzCosmosDBAccount -ResourceGroupName $rgname -Name $cosmosDBAccountName2

  $getCosmosDBAccountResult1 = Get-AzCosmosDBAccount -ResourceGroupName $rgname -Name $cosmosDBAccountName1
  Assert-NotNull $getCosmosDBAccountResult1

  $getCosmosDBAccountResult2 = Get-AzCosmosDBAccount -ResourceGroupName $rgname -Name $cosmosDBAccountName2
  Assert-Null $getCosmosDBAccountResult2.Name

  $ipRangeFilter = "192.168.0.1"
  $tags = @{ name = "test"; Shape = "Square"; Color = "Blue"}

  $cosmosDBAccountName3 = "testcosmosdb789452120912101" 
  $cosmosDBAccount3 = New-AzCosmosDBAccount -ResourceGroupName $rgname -Name $cosmosDBAccountName3 -DefaultConsistencyLevel "BoundedStaleness" -MaxStalenessIntervalInSeconds 10  -MaxStalenessPrefix 20 -Location $locationlist -IpRangeFilter $ipRangeFilter -Tag $tags
  Assert-AreEqual $cosmosDBAccountName3 $cosmosDBAccount3.Name
  Assert-AreEqual "BoundedStaleness" $cosmosDBAccount3.ConsistencyPolicy.DefaultConsistencyLevel
  Assert-AreEqual 10 $cosmosDBAccount3.ConsistencyPolicy.MaxIntervalInSeconds
  Assert-AreEqual 20 $cosmosDBAccount3.ConsistencyPolicy.MaxStalenessPrefix
  Assert-AreEqual "192.168.0.1" $cosmosDBAccount3.IpRangeFilter

}