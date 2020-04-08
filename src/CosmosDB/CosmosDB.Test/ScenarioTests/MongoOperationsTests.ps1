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

function Test-MongoOperationsCmdlets
{
  $AccountName = "db001"
  $rgName = "CosmosDBResourceGroup3668"
  $DatabaseName = "dbName"
  $CollectionName = "collection1"

  $NewDatabase =  Set-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Name $DatabaseName

  $Index = New-AzCosmosDBMongoDBIndex -Key "a"

  $NewCollection = Set-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -Index $Index
  Assert-AreEqual $NewCollection.Name $CollectionName

  $Database = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Id $Database.Id
  Assert-AreEqual $NewDatabase.Name $Database.Name
  Assert-AreEqual $NewDatabase.Resource.Id $Database.Resource.Id
  Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
  Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
  Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag

  $Collection = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
  Assert-AreEqual $NewCollection.Id $Collection.Id
  Assert-AreEqual $NewCollection.Name $Collection.Name
  Assert-AreEqual $NewCollection.Resource.Id $Collection.Resource.Id
  Assert-AreEqual $NewCollection.Resource._rid $Collection.Resource._rid
  Assert-AreEqual $NewCollection.Resource._ts $Collection.Resource._ts
  Assert-AreEqual $NewCollection.Resource._etag $Collection.Resource._etag

  $ListCollections = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
  Assert-NotNull($ListCollections)

  $ListDatabases = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
  Assert-NotNull($ListDatabases)

  $IsCollectionRemoved =  Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -PassThru
  Assert-AreEqual $IsCollectionRemoved true
  
  $IsDatabaseRemoved = Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
  Assert-AreEqual $IsDatabaseRemoved true
}

function Test-MongoOperationsCmdletsUsingInputObject
{
  $AccountName = "db001"
  $rgName = "CosmosDBResourceGroup3668"
  $DatabaseName = "dbName2"
  $CollectionName = "collection2"

  $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName

  $NewDatabase =  Set-AzCosmosDBMongoDBDatabase -InputObject $cosmosDBAccount -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Name $DatabaseName

  $NewCollection = Set-AzCosmosDBMongoDBCollection -InputObject $NewDatabase -Name $CollectionName
  Assert-AreEqual $NewCollection.Name $CollectionName

  $Database = Get-AzCosmosDBMongoDBDatabase -InputObject $cosmosDBAccount -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Id $Database.Id
  Assert-AreEqual $NewDatabase.Name $Database.Name
  Assert-AreEqual $NewDatabase.Resource.Id $Database.Resource.Id
  Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
  Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
  Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag

  $Collection = Get-AzCosmosDBMongoDBCollection -InputObject $NewDatabase -Name $CollectionName
  Assert-AreEqual $NewCollection.Id $Collection.Id
  Assert-AreEqual $NewCollection.Name $Collection.Name
  Assert-AreEqual $NewCollection.Resource.Id $Collection.Resource.Id
  Assert-AreEqual $NewCollection.Resource._rid $Collection.Resource._rid
  Assert-AreEqual $NewCollection.Resource._ts $Collection.Resource._ts
  Assert-AreEqual $NewCollection.Resource._etag $Collection.Resource._etag

  $ListCollections = Get-AzCosmosDBMongoDBCollection -InputObject $NewDatabase
  Assert-NotNull($ListCollections)

  $ListDatabases = Get-AzCosmosDBMongoDBDatabase -InputObject $cosmosDBAccount
  Assert-NotNull($ListDatabases)

  $IsCollectionRemoved =  Remove-AzCosmosDBMongoDBCollection -InputObject $NewCollection -PassThru
  Assert-AreEqual $IsCollectionRemoved true
  
  $IsDatabaseRemoved = Remove-AzCosmosDBMongoDBDatabase -InputObject $NewDatabase -PassThru
  Assert-AreEqual $IsDatabaseRemoved true
}

function Test-MongoThroughputCmdlets
{
  $AccountName = "db001"
  $rgName = "CosmosDBResourceGroup3668"
  $DatabaseName = "dbName3"
  $CollectionName = "collectionName"

  $ThroughputValue = 1200
  $UpdatedThroughputValue = 1100
  $UpdatedThroughputValue2 = 1000
  $UpdatedThroughputValue3 = 900

  $CollectionThroughputValue = 800
  $UpdatedCollectionThroughputValue = 700
  $UpdatedCollectionThroughputValue2 = 600
  $UpdatedCollectionThroughputValue3 = 500

  $ShardKey = "shardKeyPath"

  $NewDatabase =  Set-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
  $Throughput = Get-AzCosmosDBMongoDBDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  Assert-AreEqual $Throughput.Throughput $ThroughputValue

  $UpdatedThroughput = Update-AzCosmosDBMongoDBDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $UpdatedThroughputValue
  Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue

  $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName
  $UpdatedThroughput = Update-AzCosmosDBMongoDBDatabaseThroughput -ParentObject $CosmosDBAccount -Name $DatabaseName -Throughput $UpdatedThroughputValue2
  Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue2

  $UpdatedThroughput = Update-AzCosmosDBMongoDBDatabaseThroughput -InputObject $NewDatabase -Throughput $UpdatedThroughputValue3
  Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue3

  $NewCollection =  Set-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Throughput  $CollectionThroughputValue -Name $CollectionName -Shard $ShardKey
  $CollectionThroughput = Get-AzCosmosDBMongoDBCollectionThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
  Assert-AreEqual $CollectionThroughput.Throughput $CollectionThroughputValue

  $UpdatedCollectionThroughput = Update-AzCosmosDBMongoDBCollectionThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -Throughput $UpdatedCollectionThroughputValue
  Assert-AreEqual $UpdatedCollectionThroughput.Throughput $UpdatedCollectionThroughputValue

  $UpdatedCollectionThroughput = Update-AzCosmosDBMongoDBCollectionThroughput -InputObject $NewCollection -Throughput $UpdatedCollectionThroughputValue2
  Assert-AreEqual $UpdatedCollectionThroughput.Throughput $UpdatedCollectionThroughputValue2

  $UpdatedCollectionThroughput = Update-AzCosmosDBMongoDBCollectionThroughput -ParentObject $NewDatabase -Name $CollectionName -Throughput $UpdatedCollectionThroughputValue3
  Assert-AreEqual $UpdatedCollectionThroughput.Throughput $UpdatedCollectionThroughputValue3

  Remove-AzCosmosDBMongoDBCollection -InputObject $NewCollection 
  Remove-AzCosmosDBMongoDBDatabase -InputObject $NewDatabase 
}