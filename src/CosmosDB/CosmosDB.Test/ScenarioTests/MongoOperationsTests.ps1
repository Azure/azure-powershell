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
Test MongoDB CRUD cmdlets using Name paramter set
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

<#
.SYNOPSIS
Test MongoDB CRUD cmdlets using Parent Object and InputObject paramter set
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
Test MongoDB Throughput cmdlets using all paramter sets
#>
function Test-MongoThroughputCmdlets
{
  $AccountName = "mongo-db0045"
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
Test mongodb Throughput redistribution cmdlets
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
      $partitions = Get-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -AllPartitions
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

      $somePartitions = Get-AzCosmosDBMongoDBCollectionPerPartitionThroughput -ResourceGroupName $rgName -AccountName $AccountName -DatabaseName $DatabaseName -Name $ContainerName -PhysicalPartitionIds ('0', '1')
      Assert-AreEqual $somePartitions.Count 2
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