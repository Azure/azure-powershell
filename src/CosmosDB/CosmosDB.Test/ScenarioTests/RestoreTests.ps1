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

function Test-SqlRestoreFromNewAccountCmdlets {
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup13"
  $location = "West US"
  $cosmosDBAccountName = "restored-cosmosdb-1214"
  $sourceCosmosDBAccountName = "cosmosdb-1214"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $consistencyLevel = "Session"
  $apiKind = "Sql"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewDatabase = New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

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
  Assert-NotNull $sourceRestorableAccount.OldestRestorableTime

  $restorableSqlDatabases = Get-AzCosmosDBSqlRestorableDatabase -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $restorableSqlDatabases
  Assert-AreEqual $restorableSqlDatabases.Count 1

  $databaseRId = $restorableSqlDatabases[0].OwnerResourceId
  $restorableSqlContainers = Get-AzCosmosDBSqlRestorableContainer -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId -DatabaseRId $databaseRId
  Assert-NotNull $restorableSqlContainers
  Assert-True { $restorableSqlContainers.Count -eq 1 }

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName
  $restoredCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $sourceRestorableAccount.Location -FromPointInTimeBackup -SourceRestorableDatabaseAccountId $sourceRestorableAccount.Id -RestoreTimestampInUtc $restoreTimestampInUtc -DatabasesToRestore $datatabaseToRestore
 
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  $inputRestoreTS = Get-Date $restoreTimestampInUtc
  #Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName
}

function Test-SqlRestoreAccountCmdlets {
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup64"
  $cosmosDBAccountName = "restored2-cosmosdb-12103-3"
  $sourceCosmosDBAccountName = "cosmosdb-12103"
  $databaseName = "TestDB1";
  $collectionName1 = "TestCollectionInDB1";
  $collectionName2 = "TestCollectionInDB2";
  $location = "West US"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName1  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName2  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600 -TtlInSeconds 1200
  Start-TestSleep -Seconds 100

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName1, $collectionName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoreTimestampInUtc = $sourceRestorableAccount.CreationTime.AddSeconds(200)
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -DatabasesToRestore $datatabaseToRestore -DisableTtl 1

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  #Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName1
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[1] $collectionName2
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DisableTtl 1
}

function Test-MongoRestoreAccountCmdlets {
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
  $locations += New-AzCosmosDBLocationObject -Location "East Us" -FailoverPriority 0 -IsZoneRedundant 0

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
  Assert-NotNull $sourceRestorableAccount.OldestRestorableTime

  $NewDatabase = New-AzCosmosDBMongoDBDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName -Throughput  $ThroughputValue
  $NewCollection = New-AzCosmosDBMongoDBCollection -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Throughput  $CollectionThroughputValue -Name $CollectionName -Shard $ShardKey

  $restorableMongoDatabases = Get-AzCosmosDBMongoDBRestorableDatabase -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $restorableMongoDatabases
  Assert-AreEqual $restorableMongoDatabases.Count 1

  $databaseRId = $restorableMongoDatabases[0].OwnerResourceId
  $restorableMongoContainers = Get-AzCosmosDBMongoDBRestorableCollection -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId -DatabaseRId $databaseRId
  Assert-NotNull $restorableMongoContainers
  Assert-AreEqual $restorableMongoContainers.Count 1
}

function Test-MongoDBRestoreFromNewAccountCmdlets {
  $rgName = "CosmosDBResourceGroup75"
  $location = "West US"
  $ThroughputValue = 1200
  $CollectionThroughputValue = 800
  $sourceCosmosDBAccountName = "mongo-continuous-1474"
  $cosmosDBAccountName = "mongo-continuous-1474-res"
  $databaseName = "TestDB1";
  $ShardKey = "shardKeyPath"
  $collectionName1 = "TestCollection1";
  $location = "East US"
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "East Us" -FailoverPriority 0 -IsZoneRedundant 0

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
  Assert-NotNull $sourceRestorableAccount.OldestRestorableTime

  $NewDatabase = New-AzCosmosDBMongoDBDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName -Throughput  $ThroughputValue
  $NewCollection = New-AzCosmosDBMongoDBCollection -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Throughput  $CollectionThroughputValue -Name $collectionName1 -Shard $ShardKey

  $restorableMongoDatabases = Get-AzCosmosDBMongoDBRestorableDatabase -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $restorableMongoDatabases
  Assert-AreEqual $restorableMongoDatabases.Count 1

  $databaseRId = $restorableMongoDatabases[0].OwnerResourceId
  $restorableMongoCollections = Get-AzCosmosDBMongoDBRestorableCollection -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId -DatabaseRId $databaseRId
  Assert-NotNull $restorableMongoCollections
  Assert-True { $restorableMongoCollections.Count -eq 1 }

  $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')
  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName1
  $restoredCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $sourceRestorableAccount.Location -FromPointInTimeBackup -SourceRestorableDatabaseAccountId $sourceRestorableAccount.Id -RestoreTimestampInUtc $restoreTimestampInUtc -DatabasesToRestore $datatabaseToRestore

  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  #Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName1
}

function Test-RestoreFailuresAccountCmdlets {
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup133"
  $location = "West US"
  $cosmosDBAccountName = "restored-cosmosdb-12115"
  $sourceCosmosDBAccountName = "cosmosdb-12115"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $consistencyLevel = "Session"
  $apiKind = "Sql"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  # Create resource group
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location

  # Restore should fail as account doesn't exist yet
  $invalidSourceCosmosDBAccountName = "invalidname"
  $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $invalidSourceCosmosDBAccountName -Location $location -RestoreTimestampInUtc $restoreTimestampInUtc
  Assert-Null($restoredCosmosDBAccount)

  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous

  # Restore should fail as restore timestamp is before account creation timestamp
  $restoreTimestampInUtc=[DateTime]::UtcNow
  $restoreTimestampInUtc = $restoreTimestampInUtc.AddDays(-30).ToString('u')
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $location -RestoreTimestampInUtc $restoreTimestampInUtc
  Assert-Null($restoredCosmosDBAccount)

  # Restore should fail as restore timestamp is after current timestamp
  $restoreTimestampInUtc=[DateTime]::UtcNow
  $restoreTimestampInUtc = $restoreTimestampInUtc.AddDays(30).ToString('u')
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $location -RestoreTimestampInUtc $restoreTimestampInUtc
  Assert-Null($restoredCosmosDBAccount)

  # Restore should fail as provided location is invalid
  # $restoreTimestampInUtc=[DateTime]::UtcNow.ToString('u')
  # $invalidLocation = "East US"
  # $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $invalidLocation -RestoreTimestampInUtc $restoreTimestampInUtc
  # Assert-Null($restoredCosmosDBAccount)

  # Restore should fail as account is empty
  $restoreTimestampInUtc=[DateTime]::UtcNow.ToString('u')
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $location -RestoreTimestampInUtc $restoreTimestampInUtc
  Assert-Null($restoredCosmosDBAccount)

  # Create account restores
  $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

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

  $databaseRId = $restorableSqlDatabases[0].OwnerResourceId
  $restorableSqlContainers = Get-AzCosmosDBSqlRestorableContainer -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId -DatabaseRId $databaseRId
  Assert-NotNull $restorableSqlContainers
  Assert-True { $restorableSqlContainers.Count -eq 2 }

  # Trigger restore
  $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u') #"2021-06-23T03:10:16+00:00"
  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $location -RestoreTimestampInUtc $restoreTimestampInUtc -DatabasesToRestore $datatabaseToRestore

  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  $inputRestoreTS = Get-Date $restoreTimestampInUtc
  # Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName
}

function Test-GremlinRestoreAccountCmdlets {
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup75"
  $cosmosDBAccountName = "restored2-cosmosdb-1425-5"
  $sourceCosmosDBAccountName = "cosmosdb-1425-5"
  $databaseName = "TestDB1";
  $graphName1 = "Graph1";
  $graphName2 = "Graph2";
  $location = "West US"
  $apiKind = "Gremlin"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/pk"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewDatabase =  New-AzCosmosDBGremlinDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewGraph1 = New-AzCosmosDBGremlinGraph -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $graphName1  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $NewGraph2 = New-AzCosmosDBGremlinGraph -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $graphName2  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  Start-TestSleep -Seconds 100

  $datatabaseToRestore = New-AzCosmosDBGremlinDatabaseToRestore -DatabaseName $databaseName -GraphName $graphName1, $graphName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoreTimestampInUtc = $sourceRestorableAccount.CreationTime.AddSeconds(200)
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -GremlinDatabasesToRestore $datatabaseToRestore

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  #Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore[0].GraphNames[0] $graphName1
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore[0].GraphNames[1] $graphName2
}

function Test-GremlinRestoreFromNewAccountCmdlets {
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup33"
  $location = "West US"
  $cosmosDBAccountName = "restored-cosmosdb-1316"
  $sourceCosmosDBAccountName = "cosmosdb-1316"
  $databaseName = "TestDB1";
  $graphName = "TestGraph1";
  $PartitionKeyPathValue = "/pk"
  $PartitionKeyKindValue = "Hash"
  $consistencyLevel = "Session"
  $apiKind = "Gremlin"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewDatabase = New-AzCosmosDBGremlinDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBGremlinGraph -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $graphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

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

  $restorableGremlinDatabases = Get-AzCosmosDBGremlinRestorableDatabase -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $restorableGremlinDatabases
  Assert-AreEqual $restorableGremlinDatabases.Count 1

  $databaseRId = $restorableGremlinDatabases[0].OwnerResourceId
  $restorableGremlinGraphs = Get-AzCosmosDBGremlinRestorableGraph -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId -DatabaseRId $databaseRId
  Assert-NotNull $restorableGremlinGraphs
  Assert-True { $restorableGremlinGraphs.Count -eq 1 }

  $gremlinDatatabaseToRestore = New-AzCosmosDBGremlinDatabaseToRestore -DatabaseName $databaseName -GraphName $graphName
  $restoredCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $sourceRestorableAccount.Location -FromPointInTimeBackup -SourceRestorableDatabaseAccountId $sourceRestorableAccount.Id -RestoreTimestampInUtc $restoreTimestampInUtc -GremlinDatabasesToRestore $gremlinDatatabaseToRestore

  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  $inputRestoreTS = Get-Date $restoreTimestampInUtc
  #Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore[0].GraphNames[0] $graphName
}

function Test-TableRestoreAccountCmdlets {
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup45"
  $cosmosDBAccountName = "restored2-cosmosdb-1817"
  $sourceCosmosDBAccountName = "cosmosdb-1817-4"
  $tableName1 = "table1";
  $tableName2 = "table2";
  $location = "West US"
  $apiKind = "Table"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewTable1 = New-AzCosmosDBTable -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $tableName1 -Throughput 600
  $NewTable2 = New-AzCosmosDBTable -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $tableName2 -Throughput 600
  Start-TestSleep -Seconds 100

  $tablesToRestore = New-AzCosmosDBTableToRestore -TableName $tableName1, $tableName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoreTimestampInUtc = $sourceRestorableAccount.CreationTime.AddSeconds(200)
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -TablesToRestore $tablesToRestore

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  #Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.TablesToRestore
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.TablesToRestore.TableNames
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.TablesToRestore.TableNames[0] $tableName1
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.TablesToRestore.TableNames[1] $tableName2
}

function Test-TableRestoreFromNewAccountCmdlets {
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup13"
  $cosmosDBAccountName = "restored2-cosmosdb-1299"
  $sourceCosmosDBAccountName = "cosmosdb-1299"
  $tableName1 = "table1";
  $tableName2 = "table2";
  $location = "West US"
  $apiKind = "Table"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewTable1 = New-AzCosmosDBTable -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $tableName1 -Throughput 600
  $NewTable2 = New-AzCosmosDBTable -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $tableName2 -Throughput 600
  $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

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

  $restorableTables = Get-AzCosmosDBTableRestorableTable -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $restorableTables
  Assert-True { $restorableTables.Count -eq 2 }

  $tablesToRestore = New-AzCosmosDBTableToRestore -TableName $tableName1, $tableName2
  $restoredCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $sourceRestorableAccount.Location -FromPointInTimeBackup -SourceRestorableDatabaseAccountId $sourceRestorableAccount.Id -RestoreTimestampInUtc $restoreTimestampInUtc -TablesToRestore $tablesToRestore

  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  #Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.TablesToRestore
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.TablesToRestore.TableNames
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.TablesToRestore.TableNames[0] $tableName1
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.TablesToRestore.TableNames[1] $tableName2
}

function Test-SqlContainerBackupInformationCmdLets {
  $rgName = "CosmosDBResourceGroup18"
  $location = "East US"
  $cosmosDBAccountName = "cosmosdb-1414"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location

  Try {
    New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $cosmosDBAccountName + " already exists.")
  }

  Try {
    $NewDatabase = New-AzCosmosDBSqlDatabase -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $databaseName + " already exists.")
  }

  Try {
    $NewContainer = New-AzCosmosDBSqlContainer -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 10000
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $collectionName + " already exists.")
  }

  $backupInfo = Get-AzCosmosDBSqlContainerBackupInformation -ResourceGroupName $rgName -AccountName $cosmosDBAccountName -DatabaseName $databaseName -Name $collectionName -Location $location
  Assert-NotNull $backupInfo
  Assert-NotNull $backupInfo.LatestRestorableTimestamp
}

function Test-MongoDBCollectionBackupInformationCmdLets {
  $rgName = "CosmosDBResourceGroup15"
  $location = "East US"
  $cosmosDBAccountName = "cosmosdb-1215"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $shardKey = "partitionkey1"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location

  Try {
    New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $cosmosDBAccountName + " already exists.")
  }

  Try {
    $NewDatabase = New-AzCosmosDBMongoDBDatabase -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $databaseName + " already exists.")
  }

  Try {
    $NewCollection = New-AzCosmosDBMongoDBCollection -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName -Shard $shardKey -Throughput 10000
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $collectionName + " already exists.")
  }

  $backupInfo = Get-AzCosmosDBMongoDBCollectionBackupInformation -ResourceGroupName $rgName -AccountName $cosmosDBAccountName -DatabaseName $databaseName -Name $collectionName -Location $location
  Assert-NotNull $backupInfo
  Assert-NotNull $backupInfo.LatestRestorableTimestamp
}

function Test-GremlinGraphBackupInformationCmdLets {
  $rgName = "CosmosDBResourceGroup14"
  $location = "East US"
  $cosmosDBAccountName = "cosmosdb-1216"
  $databaseName = "TestDB1";
  $graphName = "TestGraph1";
  $apiKind = "Gremlin"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/pk"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location

  Try {
    New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $cosmosDBAccountName + " already exists.")
  }

  Try {
    $NewDatabase = New-AzCosmosDBGremlinDatabase -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $databaseName + " already exists.")
  }

  Try {
    $NewContainer = New-AzCosmosDBGremlinGraph -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $graphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 10000
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $graphName + " already exists.")
  }

  $backupInfo = Get-AzCosmosDBGremlinGraphBackupInformation -ResourceGroupName $rgName -AccountName $cosmosDBAccountName -DatabaseName $databaseName -Name $graphName -Location $location
  Assert-NotNull $backupInfo
  Assert-NotNull $backupInfo.LatestRestorableTimestamp
}

function Test-TableBackupInformationCmdLets {
  $rgName = "CosmosDBResourceGroup84"
  $location = "East US"
  $cosmosDBAccountName = "cosmosdb-1917"
  $tableName = "TestGraph1";
  $apiKind = "Table"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location

  Try {
    New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $cosmosDBAccountName + " already exists.")
  }

  Try {
    $NewTable = New-AzCosmosDBTable -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -Name $tableName -Throughput 600
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $tableName + " already exists.")
  }

  $backupInfo = Get-AzCosmosDBTableBackupInformation -ResourceGroupName $rgName -AccountName $cosmosDBAccountName -Name $tableName -Location $location
  Assert-NotNull $backupInfo
  Assert-NotNull $backupInfo.LatestRestorableTimestamp
}

function Test-UpdateCosmosDBAccountBackupPolicyToContinuous30DaysCmdLets {
  $rgName = "PSCosmosDBResourceGroup20"
  $location = "East US"
  $cosmosDBAccountName = "ps-cosmosdb-1220"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  New-AzResourceGroup -ResourceGroupName $rgName -Location $location

  Try {
    New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $cosmosDBAccountName + " already exists.")
  }

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -BackupPolicyType Continuous
  Start-TestSleep -Seconds (60)

  # Verify account after migration
  Assert-AreEqual "Continuous" $updatedCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous30Days" $updatedCosmosDBAccount.BackupPolicy.Tier

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -BackupPolicyType Continuous -ContinuousTier Continuous7Days
  Start-TestSleep -Seconds (60 * 2)

  $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Assert-AreEqual "Continuous" $updatedCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous7Days" $updatedCosmosDBAccount.BackupPolicy.Tier
}

function Test-UpdateCosmosDBAccountBackupPolicyToContinuous7DaysCmdLets {
  $rgName = "PSCosmosDBResourceGroup50"
  $location = "East US"
  $cosmosDBAccountName = "ps-cosmosdb-1250"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  New-AzResourceGroup -ResourceGroupName $rgName -Location $location

  Try {
    New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $cosmosDBAccountName + " already exists.")
  }

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -BackupPolicyType Continuous -ContinuousTier Continuous7Days

  # Verify account after migration
  Assert-AreEqual "Continuous" $updatedCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous7Days" $updatedCosmosDBAccount.BackupPolicy.Tier

  # If we don't provide the continuoustier, it should not trigger the update to continuous30days
  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Start-TestSleep -Seconds (60 * 2)

  $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Assert-AreEqual "Continuous7Days" $updatedCosmosDBAccount.BackupPolicy.Tier

  # Provide continuoustier explicitly, it should triggered the update to continuous30days
  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -BackupPolicyType Continuous -ContinuousTier Continuous30Days

  $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Assert-AreEqual "Continuous" $updatedCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous30Days" $updatedCosmosDBAccount.BackupPolicy.Tier
}

function Test-ProvisionCosmosDBAccountBackupPolicyWithContinuous7DaysCmdLets {
  #use an existing account with the following information
  $rgName = "PSCosmosDBResourceGroup51"
  $location = "West US"
  $sourceCosmosDBAccountName = "ps-cosmosdb-1251"
  $consistencyLevel = "Session"
  $apiKind = "Sql"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  New-AzResourceGroup -ResourceGroupName $rgName -Location $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -ContinuousTier Continuous7Days

  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  Assert-AreEqual "Continuous" $sourceCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous7Days" $sourceCosmosDBAccount.BackupPolicy.Tier
  
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $sourceRestorableAccount.Id
  Assert-NotNull $sourceRestorableAccount.Location
  Assert-NotNull $sourceRestorableAccount.DatabaseAccountInstanceId
  Assert-NotNull $sourceRestorableAccount.RestorableLocations
  Assert-AreEqual $sourceRestorableAccount.RestorableLocations.Count 1
  Assert-AreEqual $sourceRestorableAccount.DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $sourceRestorableAccount.DatabaseAccountName
  Assert-NotNull $sourceRestorableAccount.CreationTime
  Assert-NotNull $sourceRestorableAccount.OldestRestorableTime
}

function Test-SqlRestoreAccountPublicNetworkAccessCmdlets {
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup64"
  $cosmosDBAccountName = "restored2-cosmosdb-12103-3"
  $sourceCosmosDBAccountName = "cosmosdb-12103"
  $databaseName = "TestDB1";
  $collectionName1 = "TestCollectionInDB1";
  $collectionName2 = "TestCollectionInDB2";
  $location = "West US"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0
  $publicNetworkAccess = "Disabled"

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName1  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName2  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  Start-TestSleep -Seconds 100

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName1, $collectionName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoreTimestampInUtc = $sourceRestorableAccount.CreationTime.AddSeconds(200)
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -DatabasesToRestore $datatabaseToRestore -PublicNetworkAccess $publicNetworkAccess

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName1

  # Assert public network acccess is disabled
  Assert-AreEqual $restoredCosmosDBAccount.PublicNetworkAccess $publicNetworkAccess
}