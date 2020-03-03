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

  #Indexing Policy Creation
  $ipath1 = New-AzCosmosDBGremlinIncludedPathIndex -DataType String -Precision -1 -Kind Hash
  $ipath2 = New-AzCosmosDBGremlinIncludedPathIndex -DataType String -Precision -1 -Kind Hash
  $IncludedPath = New-AzCosmosDBGremlinIncludedPath -Path "/*" -Index $ipath1, $ipath2
  $SpatialSpec = New-AzCosmosDBGremlinSpatialSpec -Path  "/mySpatialPath/*" -Type  "Point", "LineString", "Polygon", "MultiPolygon"
  $cp1 = New-AzCosmosDBGremlinCompositePath -Path "/abc" -Order Ascending
  $cp2 = New-AzCosmosDBGremlinCompositePath -Path "/aberc" -Order Descending
  $CompositePaths = (($cp1, $cp2), ($cp2, $cp1))

  $IndexingPolicy = New-AzCosmosDBGremlinIndexingPolicy -IncludedPath $IncludedPath -SpatialSpec $SpatialSpec -CompositePath $CompositePaths -ExcludedPath "/myPathToNotIndex/*" -Automatic 1 -IndexingMode Consistent
  
  #UniqueKey Creation
  $p1 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey3"
  $p2 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey4"
  $p3 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey2"
  $p4 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey1"

  $uk1 = New-AzCosmosDBGremlinUniqueKeyPolicy -UniqueKey $p1,$p2,$p3,$p4

  $NewGraph = Set-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -IndexingPolicy $IndexingPolicy  -UniqueKeyPolicy $uk1
  Assert-AreEqual $NewGraph.Name $GraphName
  Assert-AreEqual $NewGraph.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
  Assert-AreEqual $NewGraph.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
  Assert-AreEqual $NewGraph.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
  Assert-AreEqual $NewGraph.Resource.IndexingPolicy.CompositeIndexes.Count 2
  Assert-AreEqual $NewGraph.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path
  Assert-AreEqual $NewGraph.Resource.UniqueKeyPolicy.UniqueKeys.Count 4

  $Database = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Id $Database.Id
  Assert-AreEqual $NewDatabase.Name $Database.Name
  Assert-AreEqual $NewDatabase.Resource.Id $Database.Resource.Id
  Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
  Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
  Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag

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