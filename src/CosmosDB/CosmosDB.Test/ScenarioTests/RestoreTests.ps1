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
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $location = "West Central US"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "restored-cosmosdb"
  $sourceCosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $consistencyLevel = "Session"
  $apiKind = "Sql"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Central US" -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
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
  $restoredCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $sourceRestorableAccount.Location -FromPointInTimeBackup -SourceRestorableDatabaseAccountId $sourceRestorableAccount.Id -RestoreTimestampInUtc $restoreTimestampInUtc -DatabasesToRestore $datatabaseToRestore -DisableLocalAuth $true
 
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  $inputRestoreTS = Get-Date $restoreTimestampInUtc
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-SqlRestoreAccountCmdlets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "restored2-cosmosdb"
  $sourceCosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb"
  $databaseName = "TestDB1";
  $collectionName1 = "TestCollectionInDB1";
  $collectionName2 = "TestCollectionInDB2";
  $location = "West Central US"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Central US" -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
  $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName1  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName2  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600 -TtlInSeconds 1200
  # This wait is a required backup-window lag (continuous backup needs real wall-clock
  # time to capture a restore point covering the just-created container), not a
  # resource-state check, so it cannot be replaced with polling.
  Start-TestSleep -Seconds 100

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName1, $collectionName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoreTimestampInUtc = $sourceRestorableAccount.CreationTime.AddSeconds(200)
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -DatabasesToRestore $datatabaseToRestore -DisableTtl 1 -DisableLocalAuth $true

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName1
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[1] $collectionName2
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DisableTtl 1
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-MongoRestoreAccountCmdlets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $CollectionName = "collectionName"
  $ThroughputValue = 1200
  $CollectionThroughputValue = 800
  $sourceCosmosDBAccountName = Get-CosmosDBUniqueName "mongo-continuous"
  $databaseName = "TestDB1";
  $ShardKey = "shardKeyPath"
  $collectionName1 = "TestCollection1";
  $location = "East US"
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "East US" -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true

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
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-MongoDBRestoreFromNewAccountCmdlets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $ThroughputValue = 1200
  $CollectionThroughputValue = 800
  $sourceCosmosDBAccountName = Get-CosmosDBUniqueName "mongo-continuous"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "mongo-continuous-res"
  $databaseName = "TestDB1";
  $ShardKey = "shardKeyPath"
  $collectionName1 = "TestCollection1";
  $location = "East US"
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "East US" -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true

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
  $restoredCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $sourceRestorableAccount.Location -FromPointInTimeBackup -SourceRestorableDatabaseAccountId $sourceRestorableAccount.Id -RestoreTimestampInUtc $restoreTimestampInUtc -DatabasesToRestore $datatabaseToRestore -DisableLocalAuth $true

  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName1
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
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
  Assert-NotNull $sourceRestorableAccount.OldestRestorableTime

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
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "restored2-cosmosdb"
  $sourceCosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb"
  $databaseName = "TestDB1";
  $graphName1 = "Graph1";
  $graphName2 = "Graph2";
  $location = "West Central US"
  $apiKind = "Gremlin"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/pk"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Central US" -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
  $NewDatabase =  New-AzCosmosDBGremlinDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewGraph1 = New-AzCosmosDBGremlinGraph -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $graphName1  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $NewGraph2 = New-AzCosmosDBGremlinGraph -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $graphName2  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  # Required backup-window lag before a restore point exists; not a resource-state
  # check, so this cannot be replaced with polling.
  Start-TestSleep -s 100

  $datatabaseToRestore = New-AzCosmosDBGremlinDatabaseToRestore -DatabaseName $databaseName -GraphName $graphName1, $graphName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoreTimestampInUtc = $sourceRestorableAccount.CreationTime.AddSeconds(200)
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -GremlinDatabasesToRestore $datatabaseToRestore -DisableLocalAuth $true

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore[0].GraphNames[0] $graphName1
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore[0].GraphNames[1] $graphName2
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-GremlinRestoreFromNewAccountCmdlets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $location = "West Central US"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "restored-cosmosdb"
  $sourceCosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb"
  $databaseName = "TestDB1";
  $graphName = "TestGraph1";
  $PartitionKeyPathValue = "/pk"
  $PartitionKeyKindValue = "Hash"
  $consistencyLevel = "Session"
  $apiKind = "Gremlin"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Central US" -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
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
  $restoredCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $sourceRestorableAccount.Location -FromPointInTimeBackup -SourceRestorableDatabaseAccountId $sourceRestorableAccount.Id -RestoreTimestampInUtc $restoreTimestampInUtc -GremlinDatabasesToRestore $gremlinDatatabaseToRestore -DisableLocalAuth $true

  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  $inputRestoreTS = Get-Date $restoreTimestampInUtc
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.GremlinDatabasesToRestore[0].GraphNames[0] $graphName
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-TableRestoreAccountCmdlets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "restored2-cosmosdb"
  $sourceCosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb"
  $tableName1 = "table1";
  $tableName2 = "table2";
  $location = "West Central US"
  $apiKind = "Table"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Central US" -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
  $NewTable1 = New-AzCosmosDBTable -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $tableName1 -Throughput 600
  $NewTable2 = New-AzCosmosDBTable -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $tableName2 -Throughput 600
  # Required backup-window lag before a restore point exists; not a resource-state
  # check, so this cannot be replaced with polling.
  Start-TestSleep -s 100

  $tablesToRestore = New-AzCosmosDBTableToRestore -TableName $tableName1, $tableName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoreTimestampInUtc = $sourceRestorableAccount.CreationTime.AddSeconds(200)
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -TablesToRestore $tablesToRestore -DisableLocalAuth $true

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.TablesToRestore
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.TablesToRestore.TableNames
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.TablesToRestore.TableNames[0] $tableName1
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.TablesToRestore.TableNames[1] $tableName2
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-TableRestoreFromNewAccountCmdlets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "restored2-cosmosdb"
  $sourceCosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb"
  $tableName1 = "table1";
  $tableName2 = "table2";
  $location = "West Central US"
  $apiKind = "Table"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Central US" -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
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
  $restoredCosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -Location $sourceRestorableAccount.Location -FromPointInTimeBackup -SourceRestorableDatabaseAccountId $sourceRestorableAccount.Id -RestoreTimestampInUtc $restoreTimestampInUtc -TablesToRestore $tablesToRestore -DisableLocalAuth $true

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
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-SqlContainerBackupInformationCmdLets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $location = "East US"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
  $NewDatabase = New-AzCosmosDBSqlDatabase -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 10000

  $backupInfo = Get-AzCosmosDBSqlContainerBackupInformation -ResourceGroupName $rgName -AccountName $cosmosDBAccountName -DatabaseName $databaseName -Name $collectionName -Location $location
  Assert-NotNull $backupInfo
  Assert-NotNull $backupInfo.LatestRestorableTimestamp
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-MongoDBCollectionBackupInformationCmdLets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $location = "East US"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $shardKey = "partitionkey1"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
  $NewDatabase = New-AzCosmosDBMongoDBDatabase -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewCollection = New-AzCosmosDBMongoDBCollection -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName -Shard $shardKey -Throughput 10000

  $backupInfo = Get-AzCosmosDBMongoDBCollectionBackupInformation -ResourceGroupName $rgName -AccountName $cosmosDBAccountName -DatabaseName $databaseName -Name $collectionName -Location $location
  Assert-NotNull $backupInfo
  Assert-NotNull $backupInfo.LatestRestorableTimestamp
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-GremlinGraphBackupInformationCmdLets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $location = "East US"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb"
  $databaseName = "TestDB1";
  $graphName = "TestGraph1";
  $apiKind = "Gremlin"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/pk"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
  $NewDatabase = New-AzCosmosDBGremlinDatabase -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBGremlinGraph -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $graphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 10000

  $backupInfo = Get-AzCosmosDBGremlinGraphBackupInformation -ResourceGroupName $rgName -AccountName $cosmosDBAccountName -DatabaseName $databaseName -Name $graphName -Location $location
  Assert-NotNull $backupInfo
  Assert-NotNull $backupInfo.LatestRestorableTimestamp
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-TableBackupInformationCmdLets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $location = "East US"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb"
  $tableName = "TestGraph1";
  $apiKind = "Table"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
  $NewTable = New-AzCosmosDBTable -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -Name $tableName -Throughput 600

  $backupInfo = Get-AzCosmosDBTableBackupInformation -ResourceGroupName $rgName -AccountName $cosmosDBAccountName -Name $tableName -Location $location
  Assert-NotNull $backupInfo
  Assert-NotNull $backupInfo.LatestRestorableTimestamp
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-UpdateCosmosDBAccountBackupPolicyCmdLet {
  $rgName = "CosmosDBResourceGroup20"
  $location = "West US"
  $cosmosDBAccountName = "ps-cosmosdb-1220"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location

  Try {
    New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $cosmosDBAccountName + " already exists.")
  }

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -BackupPolicyType Continuous
  Start-Sleep -s 50

  $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  #Assert-NotNull $updatedCosmosDBAccount.BackupPolicy.BackupPolicyMigrationState
  #Assert-NotNull $updatedCosmosDBAccount.BackupPolicy.BackupPolicyMigrationState.Status
  #Assert-NotNull $updatedCosmosDBAccount.BackupPolicy.BackupPolicyMigrationState.TargetType
  #Assert-NotNull $updatedCosmosDBAccount.BackupPolicy.BackupPolicyMigrationState.StartTime

  Start-Sleep -s (60 * 5)

  while (
    $updatedCosmosDBAccount.BackupPolicy.BackupPolicyMigrationState.Status -ne "Completed" -and 
    $updatedCosmosDBAccount.BackupPolicy.BackupPolicyMigrationState.Status -ne "Failed" -and
    $updatedCosmosDBAccount.BackupPolicy.BackupType -ne "Continuous")
  {
    Start-Sleep -s 60

    # keep polling the migration Status
    $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  }

  Assert-AreEqual "Continuous" $updatedCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous30Days" $updatedCosmosDBAccount.BackupPolicy.Tier

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -BackupPolicyType Continuous -ContinuousTier Continuous7Days
  Start-Sleep -s (60 * 2)

  $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Assert-AreEqual "Continuous" $updatedCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous7Days" $updatedCosmosDBAccount.BackupPolicy.Tier
}

function Test-UpdateCosmosDBAccountBackupPolicyToContinuous7DaysCmdLets {
  $rgName = Get-CosmosDBUniqueName "PSCosmosDBResourceGroup"
  $location = "West Central US"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "ps-cosmosdb"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -DisableLocalAuth $true

  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -BackupPolicyType Continuous -ContinuousTier Continuous7Days

  # Poll until the backup-policy migration reaches a terminal state instead of a
  # blind fixed-duration sleep.
  $updatedCosmosDBAccount = Wait-CosmosDBBackupPolicyMigration -ResourceGroupName $rgName -AccountName $cosmosDBAccountName

  Assert-AreEqual "Continuous" $updatedCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous7Days" $updatedCosmosDBAccount.BackupPolicy.Tier

  # If we don't provide the continuoustier, it should not trigger the update to continuous30days
  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Wait-CosmosDBCondition -Message "account '$cosmosDBAccountName' backup policy tier to settle at Continuous7Days" -Condition {
    (Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName).BackupPolicy.Tier -eq "Continuous7Days"
  }

  $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Assert-AreEqual "Continuous7Days" $updatedCosmosDBAccount.BackupPolicy.Tier

  # Provide continuoustier explicitly, it should triggered the update to continuous30days
  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -BackupPolicyType Continuous -ContinuousTier Continuous30Days
  Wait-CosmosDBCondition -Message "account '$cosmosDBAccountName' backup policy tier to reach Continuous30Days" -Condition {
    (Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName).BackupPolicy.Tier -eq "Continuous30Days"
  }

  $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Assert-AreEqual "Continuous" $updatedCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous30Days" $updatedCosmosDBAccount.BackupPolicy.Tier
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-ProvisionCosmosDBAccountBackupPolicyWithContinuous7DaysCmdLets {
  $rgName = Get-CosmosDBUniqueName "PSCosmosDBResourceGroup"
  $location = "West Central US"
  $sourceCosmosDBAccountName = Get-CosmosDBUniqueName "ps-cosmosdb"
  $consistencyLevel = "Session"
  $apiKind = "Sql"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Central US" -FailoverPriority 0 -IsZoneRedundant 0

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -ContinuousTier Continuous7Days -DisableLocalAuth $true

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
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}

function Test-ProvisionCosmosDBAccountBackupPolicyWithContinuous35DaysCmdLets {
  $rgName = "PSCosmosDBResourceGroup55"
  $location = "West US"
  $sourceCosmosDBAccountName = "ps-cosmosdb-1255"
  $consistencyLevel = "Session"
  $apiKind = "Sql"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -ContinuousTier Continuous35Days -DisableLocalAuth $true

  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  Assert-AreEqual "Continuous" $sourceCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous35Days" $sourceCosmosDBAccount.BackupPolicy.Tier

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

function Test-UpdateCosmosDBAccountBackupPolicyToContinuous35DaysCmdLets {
  $rgName = "PSCosmosDBResourceGroup56"
  $location = "West US"
  $cosmosDBAccountName = "ps-cosmosdb-1256"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location

  # Provision account with Continuous30Days
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -ContinuousTier Continuous30Days -DisableLocalAuth $true

  $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Assert-AreEqual "Continuous" $cosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous30Days" $cosmosDBAccount.BackupPolicy.Tier

  # Upgrade from Continuous30Days to Continuous35Days
  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -BackupPolicyType Continuous -ContinuousTier Continuous35Days
  SleepInRecordMode (60 * 2)

  $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Assert-AreEqual "Continuous" $updatedCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous35Days" $updatedCosmosDBAccount.BackupPolicy.Tier

  # Verify that not providing ContinuousTier does not change the tier
  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  SleepInRecordMode (60 * 2)

  $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  Assert-AreEqual "Continuous35Days" $updatedCosmosDBAccount.BackupPolicy.Tier
}

function Test-MigratePeriodicToContinuous35DaysCmdLets {
  $rgName = "PSCosmosDBResourceGroup57"
  $location = "West US"
  $cosmosDBAccountName = "ps-cosmosdb-1257"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location $location -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location

  # Provision account with default (Periodic) backup policy
  Try {
    New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -DisableLocalAuth $true
  }
  Catch {
    Assert-AreEqual $_.Exception.Message ("Resource with Name " + $cosmosDBAccountName + " already exists.")
  }

  # Migrate from Periodic to Continuous35Days
  $updatedCosmosDBAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName -BackupPolicyType Continuous -ContinuousTier Continuous35Days
  SleepInRecordMode 50

  $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName

  SleepInRecordMode (60 * 5)

  while (
    $updatedCosmosDBAccount.BackupPolicy.BackupPolicyMigrationState.Status -ne "Completed" -and 
    $updatedCosmosDBAccount.BackupPolicy.BackupPolicyMigrationState.Status -ne "Failed" -and
    $updatedCosmosDBAccount.BackupPolicy.BackupType -ne "Continuous")
  {
    SleepInRecordMode 60

    # keep polling the migration Status
    $updatedCosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $cosmosDBAccountName
  }

  Assert-AreEqual "Continuous" $updatedCosmosDBAccount.BackupPolicy.BackupType
  Assert-AreEqual "Continuous35Days" $updatedCosmosDBAccount.BackupPolicy.Tier
}


function Test-CrossRegionRestoreAccountCmdlets {
  #use an existing account with the following information
  $rgName = "PSCosmosDBResourceGroup53"
  $cosmosDBAccountName = "ps-xrr-cosmosdb-12105-restored"
  $sourceCosmosDBAccountName = "ps-xrr-cosmosdb-12105"
  $databaseName = "TestDB1";
  $collectionName1 = "TestCollectionInDB1";
  $collectionName2 = "TestCollectionInDB2";
  $location = "West Central US"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Central US" -FailoverPriority 0 -IsZoneRedundant 0
  $locations += New-AzCosmosDBLocationObject -Location "East US 2" -FailoverPriority 1 -IsZoneRedundant 0
  $targetLocation = "East US 2"
  $sourceBackupLocation = "West Central US"

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName1  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName2  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName1, $collectionName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  Assert-NotNull $sourceCosmosDBAccount.Location
  Assert-AreEqual $sourceCosmosDBAccount.Location $location

  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId

  Start-TestSleep -s 3662
  $restoreTimestampInUtc = $sourceRestorableAccount.CreationTime.AddSeconds(3610)

  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -SourceBackupLocation $sourceBackupLocation -Location $targetLocation -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -DatabasesToRestore $datatabaseToRestore

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  #Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName1
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.SourceBackupLocation $sourceBackupLocation
  Assert-AreEqual $restoredCosmosDBAccount.WriteLocations[0].LocationName $targetLocation
}

function Test-CrossRegionRestoreSingleRegionAccountCmdlets {
  #use an existing account with the following information
  $rgName = "PSCosmosDBResourceGroup54"
  $cosmosDBAccountName = "ps-xrr-cosmosdb-12106-restored"
  $sourceCosmosDBAccountName = "ps-xrr-cosmosdb-12106"
  $databaseName = "TestDB1";
  $collectionName1 = "TestCollectionInDB1";
  $collectionName2 = "TestCollectionInDB2";
  $location = "West Central US"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Central US" -FailoverPriority 0 -IsZoneRedundant 0
  $targetLocation = "East US 2"
  $sourceBackupLocation = "West Central US"

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName1  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName2  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName1, $collectionName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  Assert-NotNull $sourceCosmosDBAccount.Location
  Assert-AreEqual $sourceCosmosDBAccount.Location $location

  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId

  Start-TestSleep -s 3662
  $restoreTimestampInUtc = $sourceRestorableAccount.CreationTime.AddSeconds(3610)

  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -SourceBackupLocation $sourceBackupLocation -Location $targetLocation -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -DatabasesToRestore $datatabaseToRestore

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  #Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName1
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.SourceBackupLocation $sourceBackupLocation
  Assert-AreEqual $restoredCosmosDBAccount.WriteLocations[0].LocationName $targetLocation
}

function Test-SqlRestoreAccountPublicNetworkAccessCmdlets {
  $rgName = Get-CosmosDBUniqueName "CosmosDBResourceGroup"
  $cosmosDBAccountName = Get-CosmosDBUniqueName "restored2-cosmosdb"
  $sourceCosmosDBAccountName = Get-CosmosDBUniqueName "cosmosdb-rest"
  $databaseName = "TestDB1";
  $collectionName1 = "TestCollectionInDB1";
  $collectionName2 = "TestCollectionInDB2";
  $location = "West Central US"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Central US" -FailoverPriority 0 -IsZoneRedundant 0
  $publicNetworkAccess = "Disabled"

  Try {
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous -DisableLocalAuth $true
  $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName1  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName2  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  # Required backup-window lag before a restore point exists; not a resource-state
  # check, so this cannot be replaced with polling.
  Start-TestSleep -Seconds 100

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName1, $collectionName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoreTimestampInUtc = $sourceRestorableAccount.CreationTime.AddSeconds(200)
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -DatabasesToRestore $datatabaseToRestore -PublicNetworkAccess $publicNetworkAccess -DisableLocalAuth $true

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].DatabaseName $databaseName
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.DatabasesToRestore[0].CollectionNames[0] $collectionName1

  # Assert public network access is disabled
  Assert-AreEqual $restoredCosmosDBAccount.PublicNetworkAccess $publicNetworkAccess
  }
  Finally {
    Remove-AzResourceGroup -ResourceGroupName $rgName -Force -ErrorAction SilentlyContinue
  }
}