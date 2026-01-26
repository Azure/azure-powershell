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
Test MongoDB CRUD cmdlets using Name parameter set
#>
function Test-MongoOperationsCmdlets
{
  $AccountName = "mongo-db00044v2"
  $rgName = "CosmosDBResourceGroup44"
  $DatabaseName = "dbName"
  $CollectionName = "collection1"
  $shardKey = "partitionkey1"
  $partitionKeys = @("partitionkey1", "partitionkey2")
  $partitionKeys2 = @("partitionkey1", "partitionkey2", "partitionkey3")
  $ttlKeys = @("_ts")
  $ttlInSeconds = 604800
  $ttlInSeconds = 1204800
  $DatabaseName2 = "dbName2"
  $CollectionName2 = "collection2"
  $ThroughputValue = 500
  $UpdatedCollectionThroughputValue = 600
  $location = "East US"
  $apiKind = "MongoDB"
  $serverVersion = "3.6" #3.2 or 3.6
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0
Try {

      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

            
      # create a new database
      $NewDatabase =  New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $ThroughputValue
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      #create index
      $index0 = New-AzCosmosDBMongoDBIndex -Key "_id"
      $index1 = New-AzCosmosDBMongoDBIndex -Key $partitionKeys -Unique 1
      $index2 = New-AzCosmosDBMongoDBIndex -Key $ttlKeys -TtlInSeconds $ttlInSeconds

      #create a new Collection
      $NewCollection = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -Index $index0,$index1,$index2 -Shard $shardKey
      Assert-AreEqual $NewCollection.Name $CollectionName
      Validate-EqualIndexes $NewCollection.Resource.Index ($index0, $index1, $index2)
      Assert-AreEqual $NewCollection.Resource.Shard $ShardKey["Hash"]

      #create an existing Collection
      Try {
          $NewDuplicateCollection = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -Shard $shardKey
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $CollectionName + " already exists.")
      }

      #get an existing database
      $Database = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name
      Assert-AreEqual $NewDatabase.Resource.Id $Database.Resource.Id
      Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
      Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
      Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag

      #get an existing Collection
      $Collection = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      Assert-AreEqual $NewCollection.Id $Collection.Id
      Assert-AreEqual $NewCollection.Name $Collection.Name
      Assert-AreEqual $NewCollection.Resource.Id $Collection.Resource.Id
      Assert-AreEqual $NewCollection.Resource._rid $Collection.Resource._rid
      Assert-AreEqual $NewCollection.Resource._ts $Collection.Resource._ts
      Assert-AreEqual $NewCollection.Resource._etag $Collection.Resource._etag
      Validate-EqualIndexes $NewCollection.Resource.Index $Collection.Resource.Index

      #update a non existing database and Collection
      Try {
          $UpdatedDatabase = Update-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName2 + " does not exist.")
      }

      Try {
          $UpdatedCollection = Update-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $CollectionName2 + " does not exist.")
      }

      #update an existing database
      #$UpdatedDatabase = Update-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $UpdatedCollectionThroughputValue
      #$Throughput = Get-AzCosmosDBMongoDBDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      #Assert-AreEqual $UpdatedDatabase.Name $DatabaseName
      #Assert-AreEqual $Throughput.Throughput $UpdatedCollectionThroughputValue

      #create an new index
      #$index3 = New-AzCosmosDBMongoDBIndex -Key $ttlKeys -TtlInSeconds $ttlInSeconds2 
      #$index4 = New-AzCosmosDBMongoDBIndex -Key $partitionKeys2 -Unique 1
      #update an existing Collection
      #$UpdatedCollection = Update-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -Index $index0,$index3,$index4
      #Assert-AreEqual $UpdatedCollection.Name $CollectionName
      #Validate-EqualIndexes $UpdatedCollection.Resource.Index ($index0, $index3, $index4)

      #list all Collections under a database
      $ListCollections = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListCollections)

      #list all databases under the account
      $Lists = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($Lists)
  
      #delete a Collection
      $IsCollectionRemoved =  Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -PassThru
      Assert-AreEqual $IsCollectionRemoved true
       
      #delete a database
      $IsRemoved = Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsRemoved true
    }

    Finally {
        Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
        Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
	}
}

function Test-MongoInAccountRestoreOperationsSharedRUResourcesCmdlets
{
  $AccountName = "mongo-db000045"
  $rgName = "CosmosDBResourceGroup46"
  $DatabaseName = "dbName"
  $CollectionName = "collection"
  $shardKey = "partitionkey1"
  $partitionKeys = @("partitionkey1", "partitionkey2")
  $ttlKeys = @("_ts")
  $ttlInSeconds = 604800
  $ttlInSeconds = 1204800
  $ThroughputValue = 500
  $location = "West US"
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0
Try {

      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous


      # create a new database
      $NewDatabase =  New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $ThroughputValue
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      #create index
      $index0 = New-AzCosmosDBMongoDBIndex -Key "_id"
      $index1 = New-AzCosmosDBMongoDBIndex -Key $partitionKeys -Unique 1
      $index2 = New-AzCosmosDBMongoDBIndex -Key $ttlKeys -TtlInSeconds $ttlInSeconds

      #create a new Collection
      $NewCollection = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -Index $index0,$index1,$index2 -Shard $shardKey
      Assert-AreEqual $NewCollection.Name $CollectionName
      Validate-EqualIndexes $NewCollection.Resource.Index ($index0, $index1, $index2)
      Assert-AreEqual $NewCollection.Resource.Shard $ShardKey["Hash"]

      #create an existing Collection
      Try {
          $NewDuplicateCollection = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -Shard $shardKey
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $CollectionName + " already exists.")
      }

      #get an existing database
      $Database = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name
      Assert-AreEqual $NewDatabase.Resource.Id $Database.Resource.Id
      Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
      Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
      Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag

      #get an existing Collection
      $Collection = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      Assert-AreEqual $NewCollection.Id $Collection.Id
      Assert-AreEqual $NewCollection.Name $Collection.Name
      Assert-AreEqual $NewCollection.Resource.Id $Collection.Resource.Id
      Assert-AreEqual $NewCollection.Resource._rid $Collection.Resource._rid
      Assert-AreEqual $NewCollection.Resource._ts $Collection.Resource._ts
      Assert-AreEqual $NewCollection.Resource._etag $Collection.Resource._etag
      Validate-EqualIndexes $NewCollection.Resource.Index $Collection.Resource.Index

      $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

      #list all Collections under a database
      $ListCollections = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListCollections)

      #list all databases under the account
      $Lists = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($Lists)

      Start-TestSleep -s 50

      #delete a Collection
      $IsCollectionRemoved =  Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -PassThru
      Assert-AreEqual $IsCollectionRemoved true

      Start-TestSleep -s 100

      Try {
          $RestoredCollection = Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -RestoreTimestampInUtc $restoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("InAccount restore of individual shared database collections is not supported. Please restore shared database to restore its collections that shared the throughput") true
      }

      #delete a database
      $IsRemoved = Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsRemoved true

      Start-TestSleep -s 100

      # restore deleted database
      Restore-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 100

      #list all Collections under a database
      $ListCollections = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListCollections)

      #list all databases under the account
      $Lists = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($Lists)

      #delete a Collection
      $IsCollectionRemoved =  Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -PassThru
      Assert-AreEqual $IsCollectionRemoved true

      #delete a database
      $IsRemoved = Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsRemoved true
    }

    Finally {
        Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
        Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
	}
}

function Test-MongoInAccountRestoreOperationsCmdlets
{
  $AccountName = "mongo-db00048v2"
  $rgName = "CosmosDBResourceGroup48v2"
  $DatabaseName = "dbName"
  $CollectionName = "collection1"
  $location = "West US"
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0
Try {

      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous


      # create a new database
      $NewDatabase =  New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      #create a new Collection
      $NewCollection = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      Assert-AreEqual $NewCollection.Name $CollectionName

      #create an existing Collection
      Try {
          $NewDuplicateCollection = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $CollectionName + " already exists.")
      }

      #get an existing database
      $Database = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name
      Assert-AreEqual $NewDatabase.Resource.Id $Database.Resource.Id
      Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
      Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
      Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag

      #get an existing Collection
      $Collection = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      Assert-AreEqual $NewCollection.Id $Collection.Id
      Assert-AreEqual $NewCollection.Name $Collection.Name
      Assert-AreEqual $NewCollection.Resource.Id $Collection.Resource.Id
      Assert-AreEqual $NewCollection.Resource._rid $Collection.Resource._rid
      Assert-AreEqual $NewCollection.Resource._ts $Collection.Resource._ts
      Assert-AreEqual $NewCollection.Resource._etag $Collection.Resource._etag

      $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

      #list all Collections under a database
      $ListCollections = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListCollections)

      #list all databases under the account
      $Lists = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($Lists)

      Start-TestSleep -s 50

      #delete a Collection
      $IsCollectionRemoved =  Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -PassThru
      Assert-AreEqual $IsCollectionRemoved true

      Start-TestSleep -s 50

      # restore deleted collection
      Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 100

      #list all Collections under a database
      $ListCollections = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListCollections)

      #delete a database
      $IsRemoved = Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsRemoved true

      Start-TestSleep -s 100

      #Restore collection when database is deleted
      Try {
          $RestoredCollection = Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -RestoreTimestampInUtc $restoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("Could not find the database") true
      }

      $invalidRestoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')
      #Restore database with invalid timestamp
      Try {
          $RestoredDatabase = Restore-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $invalidRestoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("No databases or collections found in the source account at the restore timestamp provided") true
      }

      # restore deleted database
      Restore-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 100

      # restore deleted collection
      Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 50

      #list all Collections under a database
      $ListCollections = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListCollections)

      #list all databases under the account
      $Lists = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($Lists)

      #delete a Collection
      $IsCollectionRemoved =  Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -PassThru
      Assert-AreEqual $IsCollectionRemoved true

      #delete a database
      $IsRemoved = Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsRemoved true
    }

    Finally {
        Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
        Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
	}
}

<#
.SYNOPSIS
 1. Create database.
 2. Create container.
 3. Get database.
 4. Get container.
 5. Delete container.
 6. Restore non-existent container and expect failure.
 7. Restore container (from #5).
 8. Delete database.
 9. Restore container and expect failure (due to the database being offline).
 10. Restore database.
 11. Restore container.
 12. Restore container again and expect failure (as the collection is already online).
 13. Delete database.
 14. Restore non-existent database and expect failure.
 15. Restore database.
 16. Restore database again and expect failure (as the database already exists).
 17. Restore collection.
#>
function Test-MongoDBInAccountCoreFunctionalityNoTimestampBasedRestoreCmdletsV2
{
    $AccountName = "mongodb-iar25v2"
    $rgName = "CosmosDBResourceGroup49"
    $DatabaseName = "mongodbName6"
    $ContainerName = "container1"
    $location = "West US"
    $consistencyLevel = "Session"
    $apiKind = "MongoDB"
    $PartitionKeyPathValue = "/foo/bar"
    $PartitionKeyKindValue = "Hash"

    $locations = @()
    $locations += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0
    Try {
        $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
        New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous

        # 1. Create a new database
        $NewDatabase = New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-AreEqual $NewDatabase.Name $DatabaseName

        # 2. Create a new container
        $NewContainer = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Assert-AreEqual $NewContainer.Name $ContainerName

        # 3. Get a database
        $Database = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-AreEqual $NewDatabase.Id $Database.Id
        Assert-AreEqual $NewDatabase.Name $Database.Name
        Assert-NotNull($Database)

        # 4. Get a container
        $Container = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Assert-AreEqual $NewContainer.Id $Container.Id
        Assert-AreEqual $NewContainer.Name $Container.Name
        Assert-NotNull($Container)

        Start-TestSleep -s 50

        # 5. Remove container
        Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

        Start-TestSleep -s 50

        # 6. Restore non-existent container - expect failure
        $InvalidContainerName = "Invalid-Container459"
        $RestoreInvalidContainerResult = Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $InvalidContainerName
        Assert-Null $RestoreInvalidContainerResult

        # 7. Restore deleted container in #5
        Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

        Start-TestSleep -s 50

        # list containers
        $ListContainers = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
        Assert-NotNull($ListContainers)

        # 8. Delete database
        Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 100

        # list databases
        $ListDatabases = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-Null($ListDatabases)

        # 9. Restore container - expect failure (database is offline)
        $RestoreContainerWhenDatabaseOfflineResult = Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Assert-Null $RestoreContainerWhenDatabaseOfflineResult

        # 10. Restore deleted database
        Restore-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 50

        # list databases
        $ListDatabases = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-NotNull($ListDatabases)

        Start-TestSleep -s 50

        # 11. Restore collection
        $RestoredCollection = Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

        Start-TestSleep -s 50

        # list containers
        $ListContainers = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
        Assert-NotNull($ListContainers)

        # 12. Restore container again - expect failure (collection already online)
        $SecondInAccountContainerRestore = Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Assert-Null $SecondInAccountContainerRestore

        # 13. Delete database
        Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Start-TestSleep -s 100

        # list databases
        $ListDatabases = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-Null($ListDatabases)

        # 14. Restore non-existent database - expect failure
        $InvalidDatabaseName = "InvalidDatabaseName"
        $RestoreInvalidDatabase = Restore-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $InvalidDatabaseName
        Assert-Null $RestoreInvalidDatabase


        # 15. Restore database
        Restore-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 50

        # list databases
        $ListDatabases = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-NotNull($ListDatabases)

        # 16. Restore database again - expect failure (database already exists)
        $SecondInAccountDatabaseRestore = Restore-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-Null $SecondInAccountDatabaseRestore

        # 17. Restore collection
        $RestoredCollection = Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Start-TestSleep -s 50
        Assert-NotNull $RestoredCollection

        Start-TestSleep -s 100

        # list containers
        $ListContainers = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
        Assert-NotNull $ListContainers
  }
  Catch {
        Write-Output "Error: $_"
        throw $_
  }
  Finally {
        Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

function Test-MongoInAccountRestoreOperationsNoTimestampCmdlets
{
  $AccountName = "mongo-db00049v2"
  $rgName = "CosmosDBResourceGroup49v2"
  $DatabaseName = "dbName"
  $CollectionName = "collection1"
  $location = "West US"
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "West Central US" -FailoverPriority 0 -IsZoneRedundant 0
Try {

      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
      Start-TestSleep -Seconds 30

      # create a new database
      $NewDatabase =  New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      #create a new Collection
      $NewCollection = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      Assert-AreEqual $NewCollection.Name $CollectionName

      #create an existing Collection
      Try {
          $NewDuplicateCollection = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $CollectionName + " already exists.")
      }

      #get an existing database
      $Database = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name
      Assert-AreEqual $NewDatabase.Resource.Id $Database.Resource.Id
      Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
      Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
      Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag

      #get an existing Collection
      $Collection = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      Assert-AreEqual $NewCollection.Id $Collection.Id
      Assert-AreEqual $NewCollection.Name $Collection.Name
      Assert-AreEqual $NewCollection.Resource.Id $Collection.Resource.Id
      Assert-AreEqual $NewCollection.Resource._rid $Collection.Resource._rid
      Assert-AreEqual $NewCollection.Resource._ts $Collection.Resource._ts
      Assert-AreEqual $NewCollection.Resource._etag $Collection.Resource._etag

      #list all Collections under a database
      $ListCollections = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListCollections)

      #list all databases under the account
      $Lists = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($Lists)

      Start-TestSleep -s 50

      #delete a Collection
      $IsCollectionRemoved =  Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -PassThru
      Assert-AreEqual $IsCollectionRemoved true

      Start-TestSleep -s 50

      # restore deleted collection
      Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName

      Start-TestSleep -s 100

      #list all Collections under a database
      $ListCollections = Get-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListCollections)

      #delete a database
      $IsRemoved = Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsRemoved true

      Start-TestSleep -s 100

      # restore deleted database
      Restore-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

      Start-TestSleep -s 100

      #list all databases under the account
      $Lists = Get-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($Lists)

      #Restore collection with no timestamp after database restore
      Try {
          $RestoredCollection = Restore-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("No collection with name") true
      }

      Start-TestSleep -s 50

      #delete a database
      $IsRemoved = Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsRemoved true
    }

    Finally {
        Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
        Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
	}
}

<#
.SYNOPSIS
Test MongoDB CRUD cmdlets using Parent Object and InputObject parameter set
#>
function Test-MongoOperationsCmdletsUsingInputObject
{
  $AccountName = "mongo-db0029"
  $rgName = "CosmosDBResourceGroup29"
  $DatabaseName = "dbName"
  $CollectionName = "collection1"
  $shardKey = "partitionkey1"
  $partitionKeys = @("partitionkey1", "partitionkey2")
  $partitionKeys2 = @("partitionkey1", "partitionkey2", "partitionkey3")
  $ttlKeys = @("_ts")
  $ttlInSeconds = 604800
  $ttlInSeconds = 1204800
  $DatabaseName2 = "dbName2"
  $CollectionName2 = "collection2"
  $ThroughputValue = 500
  $UpdatedCollectionThroughputValue = 600
  $location = "East US"
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

Try {
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

      #read the associated CosmosDB account
      $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName
      # create a new database
      $NewDatabase =  New-AzCosmosDBMongoDBDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName -Throughput $ThroughputValue
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBMongoDBDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      #create index
      $index0 = New-AzCosmosDBMongoDBIndex -Key "_id"
      $index1 = New-AzCosmosDBMongoDBIndex -Key $partitionKeys -Unique 1
      $index2 = New-AzCosmosDBMongoDBIndex -Key $ttlKeys -TtlInSeconds $ttlInSeconds

      #create a new Collection
      $NewCollection = New-AzCosmosDBMongoDBCollection  -ParentObject $NewDatabase -Name $CollectionName -Index $index0,$index1,$index2 -Shard $shardKey
      Assert-AreEqual $NewCollection.Name $CollectionName
      Validate-EqualIndexes $NewCollection.Resource.Index ($index0, $index1, $index2)
      Assert-AreEqual $NewCollection.Resource.Shard $ShardKey["Hash"]

      #create an existing Collection
      Try {
          $NewDuplicateCollection = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -Shard $shardKey
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $CollectionName + " already exists.")
      }

      #get an existing database
      $Database = Get-AzCosmosDBMongoDBDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name
      Assert-AreEqual $NewDatabase.Resource.Id $Database.Resource.Id
      Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
      Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
      Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag

      #get an existing Collection
      $Collection = Get-AzCosmosDBMongoDBCollection -ParentObject $NewDatabase -Name $CollectionName
      Assert-AreEqual $NewCollection.Id $Collection.Id
      Assert-AreEqual $NewCollection.Name $Collection.Name
      Assert-AreEqual $NewCollection.Resource.Id $Collection.Resource.Id
      Assert-AreEqual $NewCollection.Resource._rid $Collection.Resource._rid
      Assert-AreEqual $NewCollection.Resource._ts $Collection.Resource._ts
      Assert-AreEqual $NewCollection.Resource._etag $Collection.Resource._etag
      Validate-EqualIndexes $UpdatedCollection.Resource.Index $Collection.Resource.Index

      #update a non existing database and Collection
      Try {
          $UpdatedDatabase = Update-AzCosmosDBMongoDBDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName2 + " does not exist.")
      }

      Try {
          $UpdatedCollection = Update-AzCosmosDBMongoDBCollection -ParentObject $NewDatabase -Name $CollectionName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $CollectionName2 + " does not exist.")
      }

      #update an existing database using ParentObject
      $UpdatedDatabase = Update-AzCosmosDBMongoDBDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName -Throughput $UpdatedCollectionThroughputValue
      $Throughput = Get-AzCosmosDBMongoDBDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $UpdatedDatabase.Name $DatabaseName
      Assert-AreEqual $Throughput.Throughput $UpdatedCollectionThroughputValue

      #update an existing database using InputObject
      $UpdatedDatabase2 = Update-AzCosmosDBMongoDBDatabase -InputObject $NewDatabase -Throughput $ThroughputValue
      $Throughput = Get-AzCosmosDBMongoDBDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $UpdatedDatabase2.Name $DatabaseName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue

      #create an new index
      $index3 = New-AzCosmosDBMongoDBIndex -Key $ttlKeys -TtlInSeconds $ttlInSeconds2 
      $index4 = New-AzCosmosDBMongoDBIndex -Key $partitionKeys2 -Unique 1
      #update an existing Collection using ParentObject
      $UpdatedCollection = Update-AzCosmosDBMongoDBCollection -ParentObject $NewDatabase -Name $CollectionName -Index $index0,$index3,$index4
      Assert-AreEqual $UpdatedCollection.Name $CollectionName
      Validate-EqualIndexes $UpdatedCollection.Resource.Index ($index0, $index3, $index4)

      #update an existing Collection using InputObject
      $UpdatedCollection2 = Update-AzCosmosDBMongoDBCollection -InputObject $UpdatedCollection -Index $index0,$index1,$index2
      Assert-AreEqual $UpdatedCollection2.Name $CollectionName
      Validate-EqualIndexes $UpdatedCollection.Resource.Index ($index0, $index1, $index2)

      #list all Collections under a database
      $ListCollections = Get-AzCosmosDBMongoDBCollection -ParentObject $NewDatabase
      Assert-NotNull($ListCollections)

      #list all databases under the account
      $Lists = Get-AzCosmosDBMongoDBDatabase -ParentObject $cosmosDBAccount
      Assert-NotNull($Lists)
  
      #delete a Collection
      $IsCollectionRemoved =  Remove-AzCosmosDBMongoDBCollection -InputObject $NewCollection -PassThru
      Assert-AreEqual $IsCollectionRemoved true
       
      #delete a database
      $IsRemoved = Remove-AzCosmosDBMongoDBDatabase -InputObject $NewDatabase -PassThru
      Assert-AreEqual $IsRemoved true
    }

    Finally {
        Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
        Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
	}
}

<#
.SYNOPSIS
Test MongoDB Throughput cmdlets using all parameter sets
#>
function Test-MongoThroughputCmdlets
{
  $AccountName = "mongo-db0046"
  $rgName = "CosmosDBResourceGroup45"
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
  $location = "East US"
  $apiKind = "MongoDB"
  $serverVersion = "3.6" #3.2 or 3.6
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{    
    $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
    New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel
   
    $NewDatabase =  New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
    $Throughput = Get-AzCosmosDBMongoDBDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
    Assert-AreEqual $Throughput.Throughput $ThroughputValue

    $UpdatedThroughput = Update-AzCosmosDBMongoDBDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $UpdatedThroughputValue
    Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue

    $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName
    $UpdatedThroughput = Update-AzCosmosDBMongoDBDatabaseThroughput -ParentObject $CosmosDBAccount -Name $DatabaseName -Throughput $UpdatedThroughputValue2
    Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue2

    $UpdatedThroughput = Update-AzCosmosDBMongoDBDatabaseThroughput -InputObject $NewDatabase -Throughput $UpdatedThroughputValue3
    Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue3

    $NewCollection =  New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Throughput  $CollectionThroughputValue -Name $CollectionName -Shard $ShardKey
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
  Finally{
    Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
    Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
  }
}

function Validate-EqualIndexes($index1, $index2)
{
    Assert-AreEqual $index1.Keys.Count $index2.Keys.Count

    $i = 0
    foreach($key in $index1.Keys)
    {
        Validate-EqualLists($index1.Keys[$i], $index2.Keys[$i])
        Assert-AreEqual $index1.Options.ExpireAfterSeconds $index2.Options.ExpireAfterSeconds 
        Assert-AreEqual $index1.Options.Unique $index2.Options.Unique 
        $i = $i + 1
	}
}

function Validate-EqualLists($list1, $list2)
{
    Assert-AreEqual $list1.Count $list2.Count

    foreach($ele in $list1)
    {
      Assert-true($list2 -contains $ele)
    }
    
    foreach($ele in $list2)
    {
      Assert-true($list1 -contains $ele)
    }
}

<#
.SYNOPSIS
Test Mongo migrate throughput cmdlets 
#>
function Test-MongoMigrateThroughputCmdlets
{
  $AccountName = "mongo-db0029"
  $rgName = "CosmosDBResourceGroup29"
  $DatabaseName = "dbName4"
  $CollectionName = "collectionName"
  $location = "East US"
  $apiKind = "MongoDB"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  $ShardKey = "shardKeyPath"
  $ThroughputValue = 1200
  $CollectionThroughputValue = 800

  $Autoscale = "Autoscale"
  $Manual = "Manual"

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

      $NewDatabase =  New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
      $Throughput = Get-AzCosmosDBMongoDBDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue
      Assert-AreEqual $Throughput.AutoscaleSettings.MaxThroughput 0

      $AutoscaleThroughput = Invoke-AzCosmosDBMongoDBDatabaseThroughputMigration -InputObject $NewDatabase -ThroughputType $Autoscale
      Assert-AreNotEqual $AutoscaleThroughput.AutoscaleSettings.MaxThroughput 0

      $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName #get parent object
      $ManualThroughput = Invoke-AzCosmosDBMongoDBDatabaseThroughputMigration -ParentObject $CosmosDBAccount -Name $DatabaseName -ThroughputType $Manual
      Assert-AreEqual $ManualThroughput.AutoscaleSettings.MaxThroughput 0

      $NewCollection =  New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Throughput  $CollectionThroughputValue -Name $CollectionName -Shard $ShardKey
      $CollectionThroughput = Get-AzCosmosDBMongoDBCollectionThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      Assert-AreEqual $CollectionThroughput.Throughput $CollectionThroughputValue

      $AutoscaledCollectionThroughput = Invoke-AzCosmosDBMongoDBCollectionThroughputMigration -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -ThroughputType $Autoscale
      Assert-AreNotEqual $AutoscaledCollectionThroughput.AutoscaleSettings.MaxThroughput 0

      $ManualCollectionThroughput = Invoke-AzCosmosDBMongoDBCollectionThroughputMigration  -InputObject $NewCollection -ThroughputType $Manual
      Assert-AreEqual $ManualCollectionThroughput.AutoscaleSettings.MaxThroughput 0

      Remove-AzCosmosDBMongoDBCollection -InputObject $NewCollection 
      Remove-AzCosmosDBMongoDBDatabase -InputObject $NewDatabase
  }
  Finally{
      Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test MongoDB RBAC cmdlets using Name parameter set
#>
function Test-MongoRBACCmdlets
{
  $AccountName = "mongo-db0004414"
  $rgName = "mongorbactest-4414"
  #$rgName = "CosmosDBResourceGroup44"
  $DatabaseName = "dbName"
  $CollectionName = "collection1"
  $shardKey = "partitionkey1"
  $partitionKeys = @("partitionkey1", "partitionkey2")
  $partitionKeys2 = @("partitionkey1", "partitionkey2", "partitionkey3")
  $capabilities = @("EnableMongo", "EnableMongoRoleBasedAccessControl")
  $ttlKeys = @("_ts")
  $ttlInSeconds = 604800
  $ttlInSeconds = 1204800
  $DatabaseName2 = "dbName2"
  $CollectionName2 = "collection2"
  $ThroughputValue = 500
  $UpdatedCollectionThroughputValue = 600
  $location = "East US"
  $apiKind = "MongoDB"
  $serverVersion = "3.6" #3.2 or 3.6
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East US" -FailoverPriority 0 -IsZoneRedundant 0
  $subscriptionId = $(getVariable "SubscriptionId")
  $RoleName1 = "mongoPSRole1"
  $RoleDefinitionId1 = $DatabaseName + "." + $RoleName1
  $FullyQualifiedRoleDefinitionId1 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongodbRoleDefinitions/$RoleDefinitionId1"
  $actions1 = 'insert', 'find'
  $updateaction = 'find'
  $Resource1 = New-AzCosmosDBMongoDBPrivilegeResource -Database $DatabaseName -Collection $CollectionName
  $Privilege1 = New-AzCosmosDBMongoDBPrivilege -PrivilegeResource $Resource1 -Actions $actions1
  $Roles = New-AzCosmosDBMongoDBRole -Database $DatabaseName -Role $RoleName1
  $RoleName2 = "mongoPSInheritedRole1"
  $RoleDefinitionId2 = $DatabaseName + "." + $RoleName2
  $FullyQualifiedRoleDefinitionId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongodbRoleDefinitions/$RoleDefinitionId2"
  $actions2 = 'insert'
  $Privilege2 = New-AzCosmosDBMongoDBPrivilege -PrivilegeResource $Resource1 -Actions $actions2
  $Username1 = 'testuser1'
  $Pass1 = 'testuserpass1'
  $Mechanisms = 'SCRAM-SHA-256'
  $CustomData = 'Test custom data'
  $UpdatedRoles = New-AzCosmosDBMongoDBRole -Database $DatabaseName -Role $RoleName2
  $UserDefinitionId1 = $DatabaseName + "." + $Username1
  $FullyQualifiedUserDefinitionId1 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongodbUserDefinitions/$UserDefinitionId1"


Try {
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Capabilities $capabilities -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel


      # create a new database
      $NewDatabase =  New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      #create a new Collection
      $NewCollection = New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
      Assert-AreEqual $NewCollection.Name $CollectionName

      #create a new Mongo Role
      $RoleDef = New-AzCosmosDBMongoDBRoleDefinition -ResourceGroupName $rgName -AccountName $AccountName -Id $FullyQualifiedRoleDefinitionId1 -RoleName $RoleName1 -Type "CustomRole" -DatabaseName $DatabaseName -Privileges $Privilege1
      Assert-AreEqual $RoleDef.Id $FullyQualifiedRoleDefinitionId1

      # get existing Mongo Role
      $GetRole = Get-AzCosmosDBMongoDBRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId1
      Assert-AreEqual $GetRole.Id $FullyQualifiedRoleDefinitionId1

      # Update Role
      $Privilege1 = New-AzCosmosDBMongoDBPrivilege -PrivilegeResource $Resource1 -Actions $updateaction
      $RoleDef = Update-AzCosmosDBMongoDBRoleDefinition -ResourceGroupName $rgName -AccountName $AccountName -Id $FullyQualifiedRoleDefinitionId1 -RoleName $RoleName1 -Type "CustomRole" -DatabaseName $DatabaseName -Privileges $Privilege1
      Assert-AreEqual $RoleDef.Id $FullyQualifiedRoleDefinitionId1
      Assert-AreEqual $RoleDef.Privileges.Actions 'find'

      #create a new Mongo Role with inherited role
      $RoleDef2 = New-AzCosmosDBMongoDBRoleDefinition -ResourceGroupName $rgName -AccountName $AccountName -Id $FullyQualifiedRoleDefinitionId2 -RoleName $RoleName2 -Type "CustomRole" -DatabaseName $DatabaseName -Privileges $Privilege2 -Roles $Roles
      Assert-AreEqual $RoleDef2.Id $FullyQualifiedRoleDefinitionId2
      Assert-AreEqual $RoleDef2.Privileges.Actions 'insert'
      Assert-AreEqual $RoleDef2.Roles.RoleProperty $RoleName1

      # get existing Mongo Role
      $GetRole = Get-AzCosmosDBMongoDBRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId2
      Assert-AreEqual $GetRole.Id $FullyQualifiedRoleDefinitionId2

      # Create a new User Definition
      $UserDef1 = New-AzCosmosDBMongoDBUserDefinition -ResourceGroupName $rgName -AccountName $AccountName -Id $FullyQualifiedUserDefinitionId1 -UserName $Username1 -Password $Pass1 -Mechanisms $Mechanisms -CustomData $CustomData -DatabaseName $DatabaseName -Roles $Roles
      Assert-AreEqual $UserDef1.Id $FullyQualifiedUserDefinitionId1
      Assert-AreEqual $UserDef1.UserName $Username1
      Assert-AreEqual $UserDef1.Roles.RoleProperty $RoleName1

      # get existing Mongo User
      $GetUser = Get-AzCosmosDBMongoDBUserDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $UserDefinitionId1
      Assert-AreEqual $GetUser.Id $FullyQualifiedUserDefinitionId1

      # Update a User Definition
      $UserDef1 = Update-AzCosmosDBMongoDBUserDefinition -ResourceGroupName $rgName -AccountName $AccountName -Id $FullyQualifiedUserDefinitionId1 -UserName $Username1 -Password $Pass1 -Mechanisms $Mechanisms -CustomData $CustomData -DatabaseName $DatabaseName -Roles $UpdatedRoles
      Assert-AreEqual $UserDef1.Id $FullyQualifiedUserDefinitionId1
      Assert-AreEqual $UserDef1.UserName $Username1
      Assert-AreEqual $UserDef1.Roles.RoleProperty $RoleName2

      # delete existing User.
      $IsRemoved = Remove-AzCosmosDBMongoDBUserDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $UserDefinitionId1 -PassThru
      Assert-AreEqual $IsRemoved true

      # delete existing Roles.
      $IsRemoved = Remove-AzCosmosDBMongoDBRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId2 -PassThru
      Assert-AreEqual $IsRemoved true
      $IsRemoved = Remove-AzCosmosDBMongoDBRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId1 -PassThru
      Assert-AreEqual $IsRemoved true

      #delete a Collection
      $IsCollectionRemoved =  Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName -PassThru
      Assert-AreEqual $IsCollectionRemoved true

      #delete a database
      $IsRemoved = Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsRemoved true
    }

    Finally {
        Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $CollectionName
        Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
	}
}
<#
.SYNOPSIS
Test mongodb collection Throughput redistribution cmdlets
#>
function Test-MongoDBCollectionAdaptiveRUCmdlets
{
  $AccountName = "mongomergeaccount"
  $rgName = "canary-sdk-test"
  $DatabaseName = "adaptiverudatabase"
  $ContainerName = "adaptiveruContainer"

  $ShardKey = "shardKeyPath"
  $ContainerThroughputValue = 24000
  $UpdatedContainerThroughputValue = 2000

  Try{

      New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Throughput  $ContainerThroughputValue -Name $ContainerName -Shard $ShardKey
      Update-AzCosmosDBMongoDBCollectionThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -Throughput $UpdatedContainerThroughputValue
      $partitions = Get-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -EnableAllPartitionsThroughput
      Assert-AreEqual $partitions.Count 4
      $sources = @()
      $targets = @()
      Foreach($partition in $partitions)
      {
          Assert-AreEqual $partition.Throughput 500
          if($partition.Id -lt 2)
          {
            $throughput = $partition.Throughput - 100
            $sources += New-AzCosmosDBPhysicalPartitionThroughputObject -Id $partition.Id -Throughput $throughput
          }
          else
          {
              $throughput = $partition.Throughput + 100
              $targets += New-AzCosmosDBPhysicalPartitionThroughputObject -Id $partition.Id -Throughput $throughput
          }
      }
      
      $newPartitions = Update-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -SourcePhysicalPartitionThroughputObject $sources -TargetPhysicalPartitionThroughputObject $targets
      Assert-AreEqual $newPartitions.Count 4
      Foreach($partition in $newPartitions)
      {
          if($partition.Id -lt 2)
          {
            Assert-AreEqual $partition.Throughput 400
          }
          else
          {
              Assert-AreEqual $partition.Throughput 600              
          }
      }      

      $resetPartitions = Update-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -EqualDistributionPolicy
      
      Assert-AreEqual $resetPartitions.Count 4

      Foreach($partition in $resetPartitions)
      {
          Assert-AreEqual $partition.Throughput 500          
      }

      $somePartitions = Get-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -PhysicalPartitionIdList ('0', '1')
      Assert-AreEqual $somePartitions.Count 2
  }
  Finally{
      Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test mongodb database Throughput redistribution cmdlets
#>
function Test-MongoDBDatabaseAdaptiveRUCmdlets
{
  $AccountName = "sharedadrutest"
  $rgName = "canary-sdk-test"
  $DatabaseName = "adaptiverudatabase"

  $DatabaseThroughputValue = 34000
  $UpdatedDatabaseThroughputValue = 2000

  Try{
      New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $DatabaseThroughputValue
      Update-AzCosmosDBMongoDBDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $UpdatedDatabaseThroughputValue
      $partitions = Get-AzCosmosDBMongoDBDatabasePerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -EnableAllPartitionsThroughput
      Assert-AreEqual $partitions.Count 4
      $sources = @()
      $targets = @()
      $oldPartitions = @()
      for($i = 0; $i -lt $partitions.Count; $i++)
      {
          Assert-AreEqual $partitions[$i].Throughput 500
          if($i -lt 2)
          {
            $throughput = $partitions[$i].Throughput - 100
            $sources += New-AzCosmosDBPhysicalPartitionThroughputObject -Id $partitions[$i].Id -Throughput $throughput
          }
          else
          {
              $throughput = $partitions[$i].Throughput + 100
              $targets += New-AzCosmosDBPhysicalPartitionThroughputObject -Id $partitions[$i].Id -Throughput $throughput
          }
          $oldPartitions += $partitions[$i]
      }
      
      $newPartitions = Update-AzCosmosDBMongoDBDatabasePerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -SourcePhysicalPartitionThroughputObject $sources -TargetPhysicalPartitionThroughputObject $targets
      Assert-AreEqual $newPartitions.Count 4
      for($i = 0; $i -lt $newPartitions.Count; $i++)
      {
          if($newPartitions[$i].Id -eq $oldPartitions[0].Id -or $newPartitions[$i].Id -eq $oldPartitions[1].Id)
          {
              Assert-AreEqual $newPartitions[$i].Throughput 400
          }
          else
          {
              Assert-AreEqual $newPartitions[$i].Throughput 600              
          }
      }      
      
      $resetPartitions = Update-AzCosmosDBMongoDBDatabasePerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -EqualDistributionPolicy
      
      Assert-AreEqual $resetPartitions.Count 4

      Foreach($partition in $resetPartitions)
      {
          Assert-AreEqual $partition.Throughput 500          
      }

      $somePartitions = Get-AzCosmosDBMongoDBDatabasePerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -PhysicalPartitionIdList ($oldPartitions[0].Id, $oldPartitions[1].Id)
      Assert-AreEqual $somePartitions.Count 2
  }
  Finally{
      Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test mongodb merge cmdlet
#>
function Test-MongoDBCollectionMergeCmdlet
{
  $AccountName = "mongomergeaccount"
  $rgName = "canary-sdk-test"
  $DatabaseName = "mergedatabase"
  $ContainerName = "mergecontainer"

  $ShardKey = "shardKeyPath"

  $ContainerThroughputValue = 24000
  $UpdatedContainerThroughputValue = 2000

  Try{

      New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Throughput  $ContainerThroughputValue -Name $ContainerName -Shard $ShardKey
      Update-AzCosmosDBMongoDBCollectionThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -Throughput $UpdatedContainerThroughputValue
      $physicalPartitionStorageInfos = Invoke-AzCosmosDBMongoDBCollectionMerge -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -Force
      Assert-AreEqual $physicalPartitionStorageInfos.Count 1
      if($physicalPartitionStorageInfos[0].Id.contains("mergeTarget"))
      {
          throw "Name of partition: " + $physicalPartitionStorageInfos[0].Id + " Unexpected Id: mergeTarget"
      }

  }
  Finally{
      Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test mongodb merge cmdlet
#>
function Test-MongoDBDatabaseMergeCmdlet
{
  $AccountName = "mongomergeaccount"
  $rgName = "canary-sdk-test"
  $DatabaseName = "mergedatabase"
  $ContainerName = "mergecontainer"

  $ShardKey = "shardKeyPath"

  $ContainerThroughputValue = 24000
  $UpdatedContainerThroughputValue = 2000

  Try{

      New-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $ContainerThroughputValue
      New-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -Shard $ShardKey
      Update-AzCosmosDBMongoDBDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $UpdatedContainerThroughputValue
      $physicalPartitionStorageInfos = Invoke-AzCosmosDBMongoDBDatabaseMerge -ResourceGroupName $rgName -AccountName $AccountName -Name $DatabaseName -Force
      Assert-AreEqual $physicalPartitionStorageInfos.Count 1
      if($physicalPartitionStorageInfos[0].Id.contains("mergeTarget"))
      {
          throw "Name of partition: " + $physicalPartitionStorageInfos[0].Id + " Unexpected Id: mergeTarget"
      }

  }
  Finally{
      Remove-AzCosmosDBMongoDBCollection -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Remove-AzCosmosDBMongoDBDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test MongoMI Roles cmdlets using all parameter sets
#>
function Test-MongoMIRoleCmdlets
{
  $AccountName = "yayi-mongomi-test-1"
  $rgName = "yayi-test"  
  $location = "West US 2"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "UK South" -FailoverPriority 0 -IsZoneRedundant 0

  $MongoMIName = "mongoMI1"
  $MongoMIName2 = "mongoMI2"
  $apiKind = "MongoDB"
  $ThroughputValue = 500
  $consistencyLevel = "Session"
  $UpdatedThroughputValue = 600

  $subscriptionId = "80be3961-0521-4a0a-8570-5cd5a4e2f98c" #$(getVariable "SubscriptionId")

  $PrincipalId = "5059f4fb-8e7e-4f41-9ca0-37bbaea765ea"
  $PrincipalId2 = "15859188-ae55-4f6d-8f07-ac19a1ae8e7f"

  $RoleName = "roleDefinitionName12"
  $RoleName2 = "roleDefinitionName2"
  $RoleName3 = "roleDefinitionName3"
  $RoleName4 = "roleDefinitionName4"
  $RoleName5 = "roleDefinitionName5"
  $RoleName6 = "roleDefinitionName6"

  $DataActionRead =     "Microsoft.DocumentDB/databaseAccounts/mongoMI/containers/entities/read"
  $DataActionCreate =   "Microsoft.DocumentDB/databaseAccounts/mongoMI/containers/entities/create"
  $DataActionReplace =  "Microsoft.DocumentDB/databaseAccounts/mongoMI/containers/entities/replace"
  $DataActionInvalid =  "Microsoft.DocumentDB/databaseAccounts/mongoMI/containers/entities/invalid-action"

  $Scope = "/"
  $FullyQualifiedScope = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName"
  $Scope2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/dbs/dbName"

  $RoleDefinitionId = "df31c3a1-20f5-4ff1-bdd0-5e0782617e22"
  $FullyQualifiedRoleDefinitionId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongoMIRoleDefinitions/df31c3a1-20f5-4ff1-bdd0-5e0782617e22"
  $RoleDefinitionId2 = "a36e56a5-9afc-4819-aa78-3a8083a3ee74"
  $FullyQualifiedRoleDefinitionId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongoMIRoleDefinitions/a36e56a5-9afc-4819-aa78-3a8083a3ee74"
  $RoleDefinitionId3 = "9ee200b5-73fd-4779-b36a-e2a31f9244f3"
  $FullyQualifiedRoleDefinitionId3 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongoMIRoleDefinitions/9ee200b5-73fd-4779-b36a-e2a31f9244f3"
  $RoleDefinitionId6 = "7ff311a6-73fd-4779-b36a-e2a31f9244f3"  

  $RoleAssignmentId = "a2ccaf94-3c39-4728-b892-95edeef0e754"
  $FullyQualifiedRoleAssignmentId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongoMIRoleAssignments/a2ccaf94-3c39-4728-b892-95edeef0e754"
  $RoleAssignmentId2 = "8f3f78c4-a8df-4088-9cbb-a3947e27076b"
  $FullyQualifiedRoleAssignmentId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongoMIRoleAssignments/8f3f78c4-a8df-4088-9cbb-a3947e27076b"
  $RoleAssignmentId3 = "e7a0b8a5-b381-495d-a020-5467c534e619"
  $FullyQualifiedRoleAssignmentId3 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/mongoMIRoleAssignments/e7a0b8a5-b381-495d-a020-5467c534e619"


  Try{

      $DatabaseAccount = Get-AzCosmosDBAccount -Name $AccountName -ResourceGroupName $rgName

      # update non-existing role definition, role assignment
      Try {
          $UpdatedRoleDefinition = Update-AzCosmosDBMongoMIRoleDefinition -Type "CustomRole" -RoleName "RoleName3" -DataAction $DataActionCreate -AssignableScope $Scope2 -Id "00000000-0000-0000-0000-000000000000" -AccountName $AccountName -ResourceGroupName $rgName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Role Definition with Id [00000000-0000-0000-0000-000000000000] does not exist.")
      }
      Try {
          $UpdatedRoleAssignment = Update-AzCosmosDBMongoMIRoleAssignment -RoleDefinitionName "RoleName4" -Id "11111111-1111-1111-1111-111111111111" -AccountName $AccountName -ResourceGroupName $rgName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Role Assignment with Name [RoleName4] does not exist.")
      }

      #role def tests
      # create a new role definition - using parent object and permission
      $Permissions = New-AzCosmosDBPermission -DataAction $DataActionRead
      $NewRoleDefinitionFromParentObject = New-AzCosmosDBMongoMIRoleDefinition -Type "CustomRole" -RoleName $RoleName -Permission $Permissions -AssignableScope $Scope -Id $RoleDefinitionId -ParentObject $DatabaseAccount
      Assert-AreEqual $NewRoleDefinitionFromParentObject.RoleName $RoleName
      Assert-AreEqual $NewRoleDefinitionFromParentObject.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromParentObject.Id $FullyQualifiedRoleDefinitionId
      Assert-NotNull $NewRoleDefinitionFromParentObject.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromParentObject.Permissions

      # create a new role definition - using fields and data actions
      $NewRoleDefinitionFromFields = New-AzCosmosDBMongoMIRoleDefinition -Type "CustomRole" -RoleName $RoleName2 -DataAction $DataActionCreate -AssignableScope $Scope2 -Id $RoleDefinitionId2 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleDefinitionFromFields.RoleName $RoleName2
      Assert-AreEqual $NewRoleDefinitionFromFields.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromFields.Id $FullyQualifiedRoleDefinitionId2
      Assert-NotNull $NewRoleDefinitionFromFields.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromFields.Permissions

      $NewRoleDefinitionFromFields2 = New-AzCosmosDBMongoMIRoleDefinition -Type "CustomRole" -RoleName $RoleName3 -DataAction $DataActionCreate -AssignableScope $Scope -Id $RoleDefinitionId3 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleDefinitionFromFields2.RoleName $RoleName3
      Assert-AreEqual $NewRoleDefinitionFromFields2.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromFields2.Id $FullyQualifiedRoleDefinitionId3
      Assert-NotNull $NewRoleDefinitionFromFields2.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromFields2.Permissions

      # get a role definition
      $RoleDefinition = Get-AzCosmosDBMongoMIRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId
      Assert-AreEqual $RoleDefinition.RoleName $RoleName
      Assert-AreEqual $RoleDefinition.Type "CustomRole"
      Assert-NotNull $RoleDefinition.AssignableScopes
      Assert-NotNull $RoleDefinition.Permissions

      # update role definition by parent object and data actions
      $UpdatedRoleDefinition = Update-AzCosmosDBMongoMIRoleDefinition -Type "CustomRole" -RoleName $RoleName4 -DataAction $DataActionReplace -AssignableScope $Scope -Id $RoleDefinitionId -ParentObject $DatabaseAccount
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName4
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions

      # update role definition by fields and permissions
      $UpdatedRoleDefinition = Update-AzCosmosDBMongoMIRoleDefinition -Type "CustomRole" -RoleName $RoleName5 -Permission $Permissions -AssignableScope $Scope -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName5
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions

      # list Role Definitions
      $ListRoleDefinitions = Get-AzCosmosDBMongoMIRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull $ListRoleDefinitions

      #role assignment tests
      # create a new role assignment from name
      $NewRoleAssignmentFromName = New-AzCosmosDBMongoMIRoleAssignment -RoleDefinitionName $RoleName5 -Scope $Scope -PrincipalId $PrincipalId -Id $RoleAssignmentId2 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleAssignmentFromName.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $NewRoleAssignmentFromName.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromName.PrincipalId $PrincipalId
      Assert-AreEqual $NewRoleAssignmentFromName.Id $FullyQualifiedRoleAssignmentId2

      # create a new role assignment from parent object
      $NewRoleAssignmentFromParentObject = New-AzCosmosDBMongoMIRoleAssignment -ParentObject $NewRoleDefinitionFromFields2 -Scope $Scope -PrincipalId $PrincipalId2 -Id $RoleAssignmentId3
      Assert-AreEqual $NewRoleAssignmentFromParentObject.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $NewRoleAssignmentFromParentObject.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromParentObject.PrincipalId $PrincipalId2
      Assert-AreEqual $NewRoleAssignmentFromParentObject.Id $FullyQualifiedRoleAssignmentId3

      # create a new role assignment from Id
      $NewRoleAssignmentFromId3 = New-AzCosmosDBMongoMIRoleAssignment -RoleDefinitionId $RoleDefinitionId -Scope $Scope -PrincipalId $PrincipalId -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Assert-AreEqual $NewRoleAssignmentFromId3.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $NewRoleAssignmentFromId3.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromId3.PrincipalId $PrincipalId
      Assert-NotNull $NewRoleAssignmentFromId3.Id

      # get a role assignment
      $RoleAssignment = Get-AzCosmosDBMongoMIRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Assert-AreEqual $RoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $RoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $RoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $RoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignment by role definition name
      $UpdatedRoleAssignment = Update-AzCosmosDBMongoMIRoleAssignment -RoleDefinitionName $RoleName3 -Id $RoleAssignmentId -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by role definition id
      $UpdatedRoleAssignment = Update-AzCosmosDBMongoMIRoleAssignment -RoleDefinitionId $RoleDefinitionId -Id $RoleAssignmentId -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by input object
      $UpdatedRoleAssignment.RoleDefinitionId = $FullyQualifiedRoleDefinitionId3
      $UpdatedRoleAssignment = Update-AzCosmosDBMongoMIRoleAssignment -InputObject $UpdatedRoleAssignment
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by parent object
      $UpdatedRoleAssignment = Update-AzCosmosDBMongoMIRoleAssignment -Id $RoleAssignmentId -ParentObject $UpdatedRoleDefinition
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # list Role Assignments
      $ListRoleAssignments = Get-AzCosmosDBMongoMIRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull $ListRoleAssignments

      # check for correct error propagation
      $PermissionsInvalid = New-AzCosmosDBPermission -DataAction $DataActionInvalid
      $ScriptBlockRoleDef = { New-AzCosmosDBMongoMIRoleDefinition -Type "CustomRole" -RoleName $RoleName6 -Permission $PermissionsInvalid -AssignableScope $Scope -Id $RoleDefinitionId6 -ParentObject $DatabaseAccount }
      Assert-ThrowsContains $ScriptBlockRoleDef "BadRequest"
  }
  Finally {
      $DatabaseAccount = Get-AzCosmosDBAccount -Name $AccountName -ResourceGroupName $rgName

      Remove-AzCosmosDBMongoMIRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Remove-AzCosmosDBMongoMIRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId2
      Remove-AzCosmosDBMongoMIRoleAssignment -ParentObject $DatabaseAccount -Id $RoleAssignmentId3

      Remove-AzCosmosDBMongoMIRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId
      Remove-AzCosmosDBMongoMIRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId2
      Remove-AzCosmosDBMongoMIRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId3
  }
}