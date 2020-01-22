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

function Test-GremlinOperationsCmdlets
{
  $AccountName = "db1002"
  $rgName = "CosmosDBResourceGroup2510"
  $DatabaseName = "dbName"
  $GraphName = "graph1"

  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"

  $NewDatabase =  Set-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Name $DatabaseName

  $NewGraph = Set-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
  Assert-AreEqual $NewGraph.Name $GraphName

  $Database = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Id $Database.Id
  Assert-AreEqual $NewDatabase.Name $Database.Name
  Assert-AreEqual $NewDatabase.GremlinDatabaseGetResultsId $Database.GremlinDatabaseGetResultsId
  Assert-AreEqual $NewDatabase._rid $Database._rid
  Assert-AreEqual $NewDatabase._ts $Database._ts
  Assert-AreEqual $NewDatabase._etag $Database._etag

  $Graph = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName
  Assert-AreEqual $NewGraph.Id $Graph.Id
  Assert-AreEqual $NewGraph.Name $Graph.Name
  Assert-AreEqual $NewGraph.GremlinGraphGetResultsId $Graph.GremlinGraphGetResultsId
  Assert-AreEqual $NewGraph._rid $Graph._rid
  Assert-AreEqual $NewGraph._ts $Graph._ts
  Assert-AreEqual $NewGraph._etag $Graph._etag

  $ListGraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
  Assert-NotNull($ListGraphs)

  $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
  Assert-NotNull($ListDatabases)

  $IsGraphRemoved =  Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName -PassThru
  Assert-AreEqual $IsGraphRemoved true
  
  $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
  Assert-AreEqual $IsDatabaseRemoved true
}

function Test-GremlinOperationsCmdletsUsingInputObject
{
  $AccountName = "db1002"
  $rgName = "CosmosDBResourceGroup2510"
  $DatabaseName = "dbName2"
  $GraphName = "graph1"

  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"

  $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName

  $NewDatabase =  Set-AzCosmosDBGremlinDatabase -InputObject $cosmosDBAccount -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Name $DatabaseName

  $NewGraph = Set-AzCosmosDBGremlinGraph -InputObject $NewDatabase -Name $GraphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
  Assert-AreEqual $NewGraph.Name $GraphName

  $Database = Get-AzCosmosDBGremlinDatabase -InputObject $cosmosDBAccount -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Id $Database.Id
  Assert-AreEqual $NewDatabase.Name $Database.Name
  Assert-AreEqual $NewDatabase.Resource.Id $Database.Resource.Id
  Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
  Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
  Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag

  $Graph = Get-AzCosmosDBGremlinGraph -InputObject $NewDatabase -Name $GraphName
  Assert-AreEqual $NewGraph.Id $Graph.Id
  Assert-AreEqual $NewGraph.Name $Graph.Name
  Assert-AreEqual $NewGraph.Resource.Id $Graph.Resource.Id
  Assert-AreEqual $NewGraph.Resource._rid $Graph.Resource._rid
  Assert-AreEqual $NewGraph.Resource._ts $Graph.Resource._ts
  Assert-AreEqual $NewGraph.Resource._etag $Graph.Resource._etag

  $ListGraphs = Get-AzCosmosDBGremlinGraph -InputObject $NewDatabase
  Assert-NotNull($ListGraphs)

  $ListDatabases = Get-AzCosmosDBGremlinDatabase -InputObject $cosmosDBAccount
  Assert-NotNull($ListDatabases)

  $IsGraphRemoved =  Remove-AzCosmosDBGremlinGraph -InputObject $NewGraph -PassThru
  Assert-AreEqual $IsGraphRemoved true
  
  $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -InputObject $NewDatabase -PassThru
  Assert-AreEqual $IsDatabaseRemoved true
}