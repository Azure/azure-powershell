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

function Test-RestoreFromNewAccountCmdlets
{
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup13"
  $location = "West US"
  $restoreTimestampInUtc = "2021-01-08T04:59:30+00:00"
  $cosmosDBAccountName = "restored-cosmosdb-1213"
  $sourceCosmosDBAccountName = "cosmosdb-1213"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $apiKind = "Sql"
  $locations = @() 
  $locations += New-AzCosmosDBLocationObject -LocationName "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  

  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName  
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId

  Assert-NotNull $sourceRestorableAccount.Id
  Assert-NotNull $sourceRestorableAccount.Location
  Assert-NotNull $sourceRestorableAccount.DatabaseAccountInstanceId
  Assert-NotNull $sourceRestorableAccount.RestorableLocations
  Assert-AreEqual $sourceRestorableAccount.RestorableLocations.Count 1
  Assert-AreEqual $sourceRestorableAccount.DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $sourceRestorableAccount.DatabaseAccountName
  Assert-NotNull $sourceRestorableAccount.CreationTime

  $restorableSqlDatabases = Get-AzCosmosDBSqlRestorableDatabase -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $restorableSqlDatabases
  Assert-AreEqual $restorableSqlDatabases.Count 1

  $databaseRid=$restorableSqlDatabases[0].OwnerResourceId
  $restorableSqlContainers = Get-AzCosmosDBSqlRestorableContainer -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId -DatabaseRid $databaseRid
  Assert-NotNull $restorableSqlContainers
  Assert-True { $restorableSqlContainers.Count -eq 1 }

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName
  $restoredCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $sourceRestorableAccount.Location -FromPointInTimeBackup -SourceRestorableDatabaseAccountId $sourceRestorableAccount.Id -RestoreTimestampInUtc $restoreTimestampInUtc -DatabasesToRestore $datatabaseToRestore
 
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  $inputRestoreTS = Get-Date $restoreTimestampInUtc
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName
}

function Test-RestoreAccountCmdlets
{
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup10"
  $restoreTimestampInUtc = "2021-05-08T22:57:48+00:00"
  $cosmosDBAccountName = "restored2-cosmosdb-1210-1"
  $sourceCosmosDBAccountName = "cosmosdb-1210"
  $databaseName = "TestDB1";
  $collectionName1 = "TestCollectionInDB1";
  $collectionName2 = "TestCollectionInDB2";
  $location = "East US"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $locations = @() 
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName1  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName2  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  
  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName1,$collectionName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -DatabasesToRestore $datatabaseToRestore

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  $inputRestoreTS = Get-Date $restoreTimestampInUtc
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName1
}

function Test-MongoRestoreAccountCmdlets
{
  $rgName = "CosmosDBResourceGroup74"
  $location = "West US"
  $CollectionName = "collectionName"
  $ThroughputValue = 1200
  $CollectionThroughputValue = 800
  $sourceCosmosDBAccountName = "mongo-continuous-1274"
  $databaseName = "TestDB1";
  $ShardKey = "shardKeyPath"
  $collectionName1 = "TestCollection1";
  $location = "East US"
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName  
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId

  Assert-NotNull $sourceRestorableAccount.Id
  Assert-NotNull $sourceRestorableAccount.Location
  Assert-NotNull $sourceRestorableAccount.DatabaseAccountInstanceId
  Assert-NotNull $sourceRestorableAccount.RestorableLocations
  Assert-AreEqual $sourceRestorableAccount.RestorableLocations.Count 1
  Assert-AreEqual $sourceRestorableAccount.DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $sourceRestorableAccount.DatabaseAccountName
  Assert-NotNull $sourceRestorableAccount.CreationTime

  $NewDatabase =  New-AzCosmosDBMongoDBDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName -Throughput  $ThroughputValue
  $NewCollection =  New-AzCosmosDBMongoDBCollection -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Throughput  $CollectionThroughputValue -Name $CollectionName -Shard $ShardKey
  
  $restorableMongoDatabases = Get-AzCosmosDBMongoDBRestorableDatabase -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $restorableMongoDatabases
  Assert-AreEqual $restorableMongoDatabases.Count 1

  $databaseRid=$restorableMongoDatabases[0].OwnerResourceId
  $restorableMongoContainers = Get-AzCosmosDBMongoDBRestorableCollection -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId -DatabaseRid $databaseRid
  Assert-NotNull $restorableMongoContainers
  Assert-AreEqual $restorableMongoContainers.Count 1

}