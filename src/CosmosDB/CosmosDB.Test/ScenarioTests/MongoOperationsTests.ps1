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
  $AccountName = "mongo-db00044"
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
  $AccountName = "mongo-db00045"
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
  $AccountName = "mongo-db00048"
  $rgName = "CosmosDBResourceGroup48"
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
    $AccountName = "mongodb-iar25"
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
  $AccountName = "mongo-db00049"
  $rgName = "CosmosDBResourceGroup49"
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