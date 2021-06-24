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

  $databaseRId=$restorableSqlDatabases[0].OwnerResourceId
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

function Test-RestoreAccountCmdlets
{
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup13"
  $cosmosDBAccountName = "restored2-cosmosdb-1210-1"
  $sourceCosmosDBAccountName = "cosmosdb-1215"
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

  # $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  # New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
  # $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  # $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName1  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  # $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName2  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  $restoreTimestampInUtc = "2021-06-23T03:10:16+00:00" #[DateTime]::UtcNow.ToString('u')

  $datatabaseToRestore = New-AzCosmosDBDatabaseToRestore -DatabaseName $databaseName -CollectionName $collectionName1,$collectionName2
  $sourceCosmosDBAccount = Get-AzCosmosDBAccount -Name $sourceCosmosDBAccountName -ResourceGroupName $rgName
  $sourceRestorableAccount = Get-AzCosmosDBRestorableDatabaseAccount -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -RestoreTimestampInUtc $restoreTimestampInUtc -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $sourceCosmosDBAccount.Location -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -DatabasesToRestore $datatabaseToRestore

  Assert-NotNull $sourceRestorableAccount
  Assert-AreEqual $restoredCosmosDBAccount.Name $cosmosDBAccountName
  Assert-AreEqual $restoredCosmosDBAccount.CreateMode "Restore"
  Assert-NotNull $restoredCosmosDBAccount.RestoreParameters
  Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreSource $sourceRestorableAccount.Id

  #Assert-AreEqual $restoredCosmosDBAccount.RestoreParameters.RestoreTimestampInUtc.ToUniversalTime() $inputRestoreTS.ToUniversalTime()
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

  $NewDatabase =  New-AzCosmosDBMongoDBDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName -Throughput  $ThroughputValue
  $NewCollection =  New-AzCosmosDBMongoDBCollection -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Throughput  $CollectionThroughputValue -Name $CollectionName -Shard $ShardKey

  $restorableMongoDatabases = Get-AzCosmosDBMongoDBRestorableDatabase -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId
  Assert-NotNull $restorableMongoDatabases
  Assert-AreEqual $restorableMongoDatabases.Count 1

  $databaseRId=$restorableMongoDatabases[0].OwnerResourceId
  $restorableMongoContainers = Get-AzCosmosDBMongoDBRestorableCollection -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId -DatabaseRId $databaseRId
  Assert-NotNull $restorableMongoContainers
  Assert-AreEqual $restorableMongoContainers.Count 1
}

function Test-RestoreFailuresAccountCmdlets
{
  #use an existing account with the following information
  $rgName = "CosmosDBResourceGroup13"
  $location = "West US"
  $cosmosDBAccountName = "restored-cosmosdb-1215"
  $sourceCosmosDBAccountName = "cosmosdb-1215"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $consistencyLevel = "Session"
  $apiKind = "Sql"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "West Us" -FailoverPriority 0 -IsZoneRedundant 0

  # Create resource group
  # $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location

  # Restore should fail as account doesn't exist yet
  $invalidSourceCosmosDBAccountName="invalidname"
  $restoreTimestampInUtc = "2021-06-23T03:10:16+00:00" #[DateTime]::UtcNow.ToString('u')
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $invalidSourceCosmosDBAccountName -Location $location -RestoreTimestampInUtc $restoreTimestampInUtc
  Assert-Null($restoredCosmosDBAccount)

  # New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $sourceCosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous

  # Restore should fail as restore timestamp is before account creation timestamp
  # $restoreTimestampInUtc=[DateTime]::UtcNow
  $restoreTimestampInUtc = "2018-06-23T03:10:16+00:00" #$restoreTimestampInUtc.AddDays(-30).ToString('u')
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $location -RestoreTimestampInUtc $restoreTimestampInUtc
  Assert-Null($restoredCosmosDBAccount)

  # Restore should fail as restore timestamp is after current timestamp
  # $restoreTimestampInUtc=[DateTime]::UtcNow
  $restoreTimestampInUtc = "2025-06-23T03:10:16+00:00" #$restoreTimestampInUtc.AddDays(30).ToString('u')
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $location -RestoreTimestampInUtc $restoreTimestampInUtc
  Assert-Null($restoredCosmosDBAccount)

  # Restore should fail as provided location is invalid
  # $restoreTimestampInUtc=[DateTime]::UtcNow.ToString('u')
  $invalidLocation = "East US"
  $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $invalidLocation -RestoreTimestampInUtc $restoreTimestampInUtc
  Assert-Null($restoredCosmosDBAccount)

  # Restore should fail as account is empty
  # $restoreTimestampInUtc=[DateTime]::UtcNow.ToString('u')
  # $restoredCosmosDBAccount = Restore-AzCosmosDBAccount -TargetResourceGroupName $rgName -TargetDatabaseAccountName $cosmosDBAccountName -SourceDatabaseAccountName $sourceCosmosDBAccountName -Location $location -RestoreTimestampInUtc $restoreTimestampInUtc
  # Assert-Null($restoredCosmosDBAccount)

  # Create account restores
  # $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  # $NewContainer = New-AzCosmosDBSqlContainer -AccountName $sourceCosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
  # $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

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

  $databaseRId=$restorableSqlDatabases[0].OwnerResourceId
  $restorableSqlContainers = Get-AzCosmosDBSqlRestorableContainer -Location $sourceCosmosDBAccount.Location -DatabaseAccountInstanceId $sourceCosmosDBAccount.InstanceId -DatabaseRId $databaseRId
  Assert-NotNull $restorableSqlContainers
  Assert-True { $restorableSqlContainers.Count -eq 2 }

  # Trigger restore
  $restoreTimestampInUtc = "2021-06-23T03:10:16+00:00"
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

function Test-SqlContainerBackupInformationCmdLets
{
  $rgName = "CosmosDBResourceGroup3668"
  $location = "EAST US 2"
  $cosmosDBAccountName = "cosmosdb-1214"
  $databaseName = "TestDB1";
  $collectionName = "TestCollectionInDB1";
  $location = "East US"
  $apiKind = "Sql"
  $consistencyLevel = "Session"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -Location "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
  New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $cosmosDBAccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous

  $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -Name $databaseName
  $NewContainer = New-AzCosmosDBSqlContainer -AccountName $cosmosDBAccountName -ResourceGroupName $rgName -DatabaseName $databaseName -Name $collectionName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600

  $backupInfo = Get-AzCosmosDBSqlContainerBackupInformation -ResourceGroupName $rgName -AccountName $cosmosDBAccountName -DatabaseName $databaseName -Name $collectionName -Location $location
  Assert-NotNull $backupInfo
  Assert-NotNull $backupInfo.LatestRestorableTimestamp
}
