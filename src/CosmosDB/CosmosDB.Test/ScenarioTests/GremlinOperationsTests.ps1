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
Test Gremlin CRUD cmdlets using Name parameter set
#>
function Test-GremlinOperationsCmdlets
{
  $AccountName = "gremlin-db1050"
  $rgName = "CosmosDBResourceGroup50"
  $DatabaseName = "dbName"
  $graphName = "graph1"
  $location = "East US"

  $DatabaseName2 = "dbName29"
  $graphName2 = "graph2"

  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"

  $apiKind = "Gremlin"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      # create a new database
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel
      
      $NewDatabase =  New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      # Indexing Policy Creation
      $ipath1 = New-AzCosmosDBGremlinIncludedPathIndex -DataType String -Precision -1 -Kind Hash
      $ipath2 = New-AzCosmosDBGremlinIncludedPathIndex -DataType String -Precision -1 -Kind Hash
      $IncludedPath = New-AzCosmosDBGremlinIncludedPath -Path "/*" -Index $ipath1, $ipath2
      $SpatialSpec = New-AzCosmosDBGremlinSpatialSpec -Path  "/mySpatialPath/*" -Type  "Point", "LineString", "Polygon", "MultiPolygon"
      $cp1 = New-AzCosmosDBGremlinCompositePath -Path "/abc" -Order Ascending
      $cp2 = New-AzCosmosDBGremlinCompositePath -Path "/aberc" -Order Descending
      $CompositePaths = (($cp1, $cp2), ($cp2, $cp1))

      $IndexingPolicy = New-AzCosmosDBGremlinIndexingPolicy -IncludedPath $IncludedPath -SpatialSpec $SpatialSpec -CompositePath $CompositePaths -ExcludedPath "/myPathToNotIndex/*" -Automatic 1 -IndexingMode Consistent
  
      # UniqueKey Creation
      $p1 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey3"
      $p2 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey4"
      $p3 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey2"
      $p4 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey1"

      $uk1 = New-AzCosmosDBGremlinUniqueKeyPolicy -UniqueKey $p1,$p2,$p3,$p4

      # create a new graph
      $Newgraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600 -IndexingPolicy $IndexingPolicy  -UniqueKeyPolicy $uk1
      Assert-AreEqual $Newgraph.Name $graphName
      Assert-AreEqual $Newgraph.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
      Assert-AreEqual $Newgraph.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
      Assert-AreEqual $Newgraph.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
      Assert-AreEqual $Newgraph.Resource.IndexingPolicy.CompositeIndexes.Count 2
      Assert-AreEqual $Newgraph.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path
      Assert-AreEqual $Newgraph.Resource.UniqueKeyPolicy.UniqueKeys.Count 4

      # create an existing graph
      Try {
            $NewDuplicategraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600 -IndexingPolicy $IndexingPolicy  -UniqueKeyPolicy $uk1
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $graphName + " already exists.")
      }


      # update non existing database and graph
      Try {
          $UpdatedDatabse = Update-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName2 + " does not exist.")
      }

      Try {
          $Updatedgraph = Update-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $graphName2 + " does not exist.")
      }

      # get a database
      $Database = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # get a graph
      $graph = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName
      Assert-AreEqual $Newgraph.Id $graph.Id
      Assert-AreEqual $Newgraph.Name $graph.Name

      # updating database, graph
      $UpdatedDatabase =  Update-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # update graph
      $Updatedgraph = Update-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName
      Assert-AreEqual $Updatedgraph.Name $graphName
      Assert-AreEqual $Updatedgraph.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
      Assert-AreEqual $Updatedgraph.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
      Assert-AreEqual $Updatedgraph.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
      Assert-AreEqual $Updatedgraph.Resource.IndexingPolicy.CompositeIndexes.Count 2
      Assert-AreEqual $Updatedgraph.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path
      Assert-AreEqual $Updatedgraph.Resource.UniqueKeyPolicy.UniqueKeys.Count 4

      # list graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # list databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName 
      Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
  }
  Finally
  {
    Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName  
    Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test Gremlin InAccount Restore cmdlets using Name paramter set
#>
function Test-GremlinInAccountRestoreOperationsCmdlets
{
  $AccountName = "gremlin-db1051-2"
  $rgName = "CosmosDBResourceGroup51-2"
  $DatabaseName = "dbName"
  $graphName = "graph1"
  $location = "East US"
  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"
  $apiKind = "Gremlin"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      # create a new database
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
      
      $NewDatabase =  New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      # create a new graph
      $Newgraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      Assert-AreEqual $Newgraph.Name $graphName

      # create an existing graph
      Try {
            $NewDuplicategraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $graphName + " already exists.")
      }

      # Get the database
      $Database = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # Get the graph
      $graph = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName
      Assert-AreEqual $Newgraph.Id $graph.Id
      Assert-AreEqual $Newgraph.Name $graph.Name

      $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

      # list graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # list databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      Start-Sleep -s 50

      # Delete the graph
      $IsGraphRemoved = Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PassThru
      Assert-AreEqual $IsGraphRemoved true

      Start-Sleep -s 50

      Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-Sleep -s 100

      # list graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # Delete the database
      $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsDatabaseRemoved true

      Start-Sleep -s 100

      Try {
          Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -RestoreTimestampInUtc $restoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("Could not find the database") true
      }

      $invalidRestoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')
      # Restore database with invalid timestamp
      Try {
          Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $invalidRestoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("No databases or collections found in the source account at the restore timestamp provided") true
      }

      # Restore the deleted database
      Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-Sleep -s 100

      # Restore the deleted graph
      Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-Sleep -s 50

      # List graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # List databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      # Delete the graph
      $IsGraphRemoved = Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PassThru
      Assert-AreEqual $IsGraphRemoved true

      # Delete the database
      $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsDatabaseRemoved true
  }
  Finally
  {
    Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName  
    Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test Gremlin InAccount Restore cmdlets using Name paramter set
#>
function Test-GremlinInAccountRestoreOperationsSharedRUResourcesCmdlets
{
  $AccountName = "gremlin-db1051-3"
  $rgName = "CosmosDBResourceGroup51-3"
  $DatabaseName = "dbName"
  $graphName = "graph1"
  $location = "East US"
  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"
  $apiKind = "Gremlin"
  $consistencyLevel = "Session"
  $ThroughputValue = 500
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      # create a new database
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous
      
      $NewDatabase =  New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      # create a new graph
      $Newgraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      Assert-AreEqual $Newgraph.Name $graphName

      # create an existing graph
      Try {
            $NewDuplicategraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $graphName + " already exists.")
      }

      # Get the database
      $Database = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # Get the graph
      $graph = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName
      Assert-AreEqual $Newgraph.Id $graph.Id
      Assert-AreEqual $Newgraph.Name $graph.Name

      $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

      # list graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # list databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      Start-Sleep -s 50

      # Delete the graph
      $IsGraphRemoved = Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PassThru
      Assert-AreEqual $IsGraphRemoved true

      Start-Sleep -s 50

      Try {
          Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -RestoreTimestampInUtc $restoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("InAccount restore of individual shared database collections is not supported. Please restore shared database to restore its collections that shared the throughput") true
      }

      # Delete the database
      $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsDatabaseRemoved true

      Start-Sleep -s 100

      # Restore the deleted database
      Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-Sleep -s 100

      # List graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # List databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      # Delete the graph
      $IsGraphRemoved = Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PassThru
      Assert-AreEqual $IsGraphRemoved true

      # Delete the database
      $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsDatabaseRemoved true
  }
  Finally
  {
    Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName  
    Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test Gremlin CRUD cmdlets using Parent Object and InputObject paramter set
#>
function Test-GremlinOperationsCmdletsUsingInputObject
{
  $AccountName = "gremlin-db1052"
  $rgName = "CosmosDBResourceGroup52"
  $DatabaseName = "dbName4"
  $GraphName = "graph1"

  $DatabaseName2 = "dbName5"
  $graphName2 = "graph2"

  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"

  $apiKind = "Gremlin"
  $location = "East US"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

      # get the database account object
      $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName

      # create a new database
      $NewDatabase =  New-AzCosmosDBGremlinDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # Indexing Policy Creation
      $ipath1 = New-AzCosmosDBGremlinIncludedPathIndex -DataType String -Precision -1 -Kind Hash
      $ipath2 = New-AzCosmosDBGremlinIncludedPathIndex -DataType String -Precision -1 -Kind Hash
      $IncludedPath = New-AzCosmosDBGremlinIncludedPath -Path "/*" -Index $ipath1, $ipath2
      $SpatialSpec = New-AzCosmosDBGremlinSpatialSpec -Path  "/mySpatialPath/*" -Type  "Point", "LineString", "Polygon", "MultiPolygon"
      $cp1 = New-AzCosmosDBGremlinCompositePath -Path "/abc" -Order Ascending
      $cp2 = New-AzCosmosDBGremlinCompositePath -Path "/aberc" -Order Descending
      $CompositePaths = (($cp1, $cp2), ($cp2, $cp1))

      $IndexingPolicy = New-AzCosmosDBGremlinIndexingPolicy -IncludedPath $IncludedPath -SpatialSpec $SpatialSpec -CompositePath $CompositePaths -ExcludedPath "/myPathToNotIndex/*" -Automatic 1 -IndexingMode Consistent
     
      # create a new uniquekeypolicy
      $p1 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey3"
      $p2 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey4"
      $p3 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey2"
      $p4 = New-AzCosmosDBGremlinUniqueKey -Path "/myUniqueKey1"

      $uk1 = New-AzCosmosDBGremlinUniqueKeyPolicy -UniqueKey $p1,$p2,$p3,$p4

      # create a new Graph
      $NewGraph = New-AzCosmosDBGremlinGraph -ParentObject $NewDatabase -Name $GraphName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600 -IndexingPolicy $IndexingPolicy -UniqueKeyPolicy $uk1
      Assert-AreEqual $NewGraph.Name $GraphName
      Assert-AreEqual $NewGraph.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
      Assert-AreEqual $NewGraph.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
      Assert-AreEqual $NewGraph.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
      Assert-AreEqual $NewGraph.Resource.IndexingPolicy.CompositeIndexes.Count 2
      Assert-AreEqual $NewGraph.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path

      # get a database
      $Database = Get-AzCosmosDBGremlinDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # get a graph
      $Graph = Get-AzCosmosDBGremlinGraph -ParentObject $NewDatabase -Name $GraphName
      Assert-AreEqual $NewGraph.Id $Graph.Id
      Assert-AreEqual $NewGraph.Name $Graph.Name

      # updating database using parent object
      $UpdatedDatabase =  Update-AzCosmosDBGremlinDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName
      Assert-AreEqual $UpdatedDatabase.Name $DatabaseName

      # update graph using parent object
      $UpdatedGraph = Update-AzCosmosDBGremlinGraph -ParentObject $NewDatabase -Name $GraphName
      Assert-AreEqual $UpdatedGraph.Name $GraphName
      Assert-AreEqual $UpdatedGraph.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
      Assert-AreEqual $UpdatedGraph.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
      Assert-AreEqual $UpdatedGraph.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
      Assert-AreEqual $UpdatedGraph.Resource.IndexingPolicy.CompositeIndexes.Count 2
      Assert-AreEqual $UpdatedGraph.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path
      Assert-AreEqual $UpdatedGraph.Resource.UniqueKeyPolicy.UniqueKeys.Count 4

      # updating database using input object
      $UpdatedDatabase2 =  Update-AzCosmosDBGremlinDatabase -InputObject $UpdatedDatabase
      Assert-AreEqual $UpdatedDatabase2.Name $DatabaseName

      # update Graph using input object
      $UpdatedGraph2 = Update-AzCosmosDBGremlinGraph -InputObject $UpdatedGraph
      Assert-AreEqual $UpdatedGraph2.Name $GraphName
      Assert-AreEqual $UpdatedGraph2.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
      Assert-AreEqual $UpdatedGraph2.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
      Assert-AreEqual $UpdatedGraph2.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
      Assert-AreEqual $UpdatedGraph2.Resource.IndexingPolicy.CompositeIndexes.Count 2
      Assert-AreEqual $UpdatedGraph2.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path
      Assert-AreEqual $UpdatedGraph2.Resource.UniqueKeyPolicy.UniqueKeys.Count 4

      # list Graphs
      $ListGraphs = Get-AzCosmosDBGremlinGraph -ParentObject $NewDatabase
      Assert-NotNull($ListGraphs)

      # list databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -ParentObject $cosmosDBAccount
      Assert-NotNull($ListDatabases)

      Remove-AzCosmosDBGremlinGraph -InputObject $NewGraph

      Remove-AzCosmosDBGremlinDatabase -InputObject $NewDatabase
  }
  Finally {
    Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName 
    Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
  }
}

<#
.SYNOPSIS
Test Gremlin throughput cmdlets using all parameter sets
#>
function Test-GremlinThroughputCmdlets
{
  $AccountName = "gremlin-db1053"
  $rgName = "CosmosDBResourceGroup53"
  $DatabaseName = "dbName3"
  $GraphName = "graphName"

  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"

  $ThroughputValue = 1200
  $UpdatedThroughputValue = 1100
  $UpdatedThroughputValue2 = 1000
  $UpdatedThroughputValue3 = 900

  $GraphThroughputValue = 800
  $UpdatedGraphThroughputValue = 700
  $UpdatedGraphThroughputValue2 = 600
  $UpdatedGraphThroughputValue3 = 500

  $apiKind = "Gremlin"
  $location = "East US"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

      $NewDatabase =  New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
      $Throughput = Get-AzCosmosDBGremlinDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue

      $UpdatedThroughput = Update-AzCosmosDBGremlinDatabaseThroughput  -InputObject $NewDatabase -Throughput $UpdatedThroughputValue
      Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue

      $UpdatedThroughput = Update-AzCosmosDBGremlinDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $UpdatedThroughputValue2
      Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue2

      $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName
      $UpdatedThroughput = Update-AzCosmosDBGremlinDatabaseThroughput  -ParentObject $CosmosDBAccount -Name $DatabaseName -Throughput $UpdatedThroughputValue3
      Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue3

      $NewGraph =  New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Throughput  $GraphThroughputValue -Name $GraphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      $GraphThroughput = Get-AzCosmosDBGremlinGraphThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName
      Assert-AreEqual $GraphThroughput.Throughput $GraphThroughputValue

      $UpdatedGraphThroughput = Update-AzCosmosDBGremlinGraphThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName -Throughput $UpdatedGraphThroughputValue
      Assert-AreEqual $UpdatedGraphThroughput.Throughput $UpdatedGraphThroughputValue

      $UpdatedGraphThroughput = Update-AzCosmosDBGremlinGraphThroughput  -InputObject $NewGraph -Throughput $UpdatedGraphThroughputValue2
      Assert-AreEqual $UpdatedGraphThroughput.Throughput $UpdatedGraphThroughputValue2

      $UpdatedGraphThroughput = Update-AzCosmosDBGremlinGraphThroughput -ParentObject $NewDatabase -Name $GraphName -Throughput $UpdatedGraphThroughputValue3
      Assert-AreEqual $UpdatedGraphThroughput.Throughput $UpdatedGraphThroughputValue3

      Remove-AzCosmosDBGremlinGraph -InputObject $NewGraph 
      Remove-AzCosmosDBGremlinDatabase -InputObject $NewDatabase 
  }
  Finally{
      Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName
      Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
  }
}

<#
.SYNOPSIS
Test Gremlin migrate throughput cmdlets 
#>
function Test-GremlinMigrateThroughputCmdlets
{
  $AccountName = "gremlin-db1054"
  $rgName = "CosmosDBResourceGroup54"
  $DatabaseName = "dbName4"
  $GraphName = "graphName"
  $apiKind = "Gremlin"
  $location = "East US"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"

  $ThroughputValue = 1200

  $GraphThroughputValue = 800

  $Autoscale = "Autoscale"
  $Manual = "Manual"

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

      $NewDatabase =  New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
      $Throughput = Get-AzCosmosDBGremlinDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue
      Assert-AreEqual $Throughput.AutoscaleSettings.MaxThroughput 0

      $AutoscaleThroughput = Invoke-AzCosmosDBGremlinDatabaseThroughputMigration -InputObject $NewDatabase -ThroughputType $Autoscale
      Assert-AreNotEqual $AutoscaleThroughput.AutoscaleSettings.MaxThroughput 0

      $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName #get parent object
      $ManualThroughput = Invoke-AzCosmosDBGremlinDatabaseThroughputMigration -ParentObject $CosmosDBAccount -Name $DatabaseName -ThroughputType $Manual
      Assert-AreEqual $ManualThroughput.AutoscaleSettings.MaxThroughput 0

      $NewGraph =  New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Throughput  $GraphThroughputValue -Name $GraphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      $GraphThroughput = Get-AzCosmosDBGremlinGraphThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName
      Assert-AreEqual $GraphThroughput.Throughput $GraphThroughputValue

      $AutoscaledGraphThroughput = Invoke-AzCosmosDBGremlinGraphThroughputMigration -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName -ThroughputType $Autoscale
      Assert-AreNotEqual $AutoscaledGraphThroughput.AutoscaleSettings.MaxThroughput 0

      $ManualGraphThroughput = Invoke-AzCosmosDBGremlinGraphThroughputMigration  -InputObject $NewGraph -ThroughputType $Manual
      Assert-AreEqual $ManualGraphThroughput.AutoscaleSettings.MaxThroughput 0

      Remove-AzCosmosDBGremlinGraph -InputObject $NewGraph 
      Remove-AzCosmosDBGremlinDatabase -InputObject $NewDatabase
  }
  Finally{
      Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName  -Name $GraphName
      Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test Gremlin InAccount Restore cmdlets using Name parameter set
#>
function Test-GremlinInAccountRestoreOperationsCmdlets
{
  $AccountName = "gremlin-db1051-2"
  $rgName = "CosmosDBResourceGroup51-2"
  $DatabaseName = "dbName"
  $graphName = "graph1"
  $location = "East US"
  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"
  $apiKind = "Gremlin"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      # create a new database
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous

      $NewDatabase =  New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      # create a new graph
      $Newgraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      Assert-AreEqual $Newgraph.Name $graphName

      # create an existing graph
      Try {
            $NewDuplicategraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $graphName + " already exists.")
      }

      # Get the database
      $Database = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # Get the graph
      $graph = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName
      Assert-AreEqual $Newgraph.Id $graph.Id
      Assert-AreEqual $Newgraph.Name $graph.Name

      $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

      # list graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # list databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      Start-TestSleep -s 50

      # Delete the graph
      $IsGraphRemoved = Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PassThru
      Assert-AreEqual $IsGraphRemoved true

      Start-TestSleep -s 50

      Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 100

      # list graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # Delete the database
      $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsDatabaseRemoved true

      Start-TestSleep -s 100

      Try {
          Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -RestoreTimestampInUtc $restoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("Could not find the database") true
      }

      $invalidRestoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')
      # Restore database with invalid timestamp
      Try {
          Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $invalidRestoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("No databases or collections found in the source account at the restore timestamp provided") true
      }

      # Restore the deleted database
      Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 100

      # Restore the deleted graph
      Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 50

      # List graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # List databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      # Delete the graph
      $IsGraphRemoved = Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PassThru
      Assert-AreEqual $IsGraphRemoved true

      # Delete the database
      $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsDatabaseRemoved true
  }
  Finally
  {
      Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName  
      Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
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
function Test-GremlinInAccountCoreFunctionalityNoTimestampBasedRestoreCmdletsV2
{
    $AccountName = "iar-gremlingraph-ntbr"
    $rgName = "CosmosDBResourceGroup50"
    $DatabaseName = "dbName"
    $ContainerName = "collection1"
    $location = "West US"
    $PartitionKeyPathValue = "/foo"
    $PartitionKeyKindValue = "Hash"
    $apiKind = "Gremlin"
    $consistencyLevel = "Session"
    $locations = @()
    $locations += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0

    Try {

        $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
        New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous

        # 1. Create a new database
        $NewDatabase = New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-AreEqual $NewDatabase.Name $DatabaseName

        # 2. Create a new container
        $NewContainer = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
        Assert-AreEqual $NewContainer.Name $ContainerName

        # 3. Get a database
        $Database = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-AreEqual $NewDatabase.Id $Database.Id
        Assert-AreEqual $NewDatabase.Name $Database.Name
        Assert-NotNull($Database)

        # 4. Get a container
        $Container = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Assert-AreEqual $NewContainer.Id $Container.Id
        Assert-AreEqual $NewContainer.Name $Container.Name
        Assert-NotNull($Container)

        Start-TestSleep -s 50

        # 5. Remove container
        Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

        Start-TestSleep -s 50

        # 6. Restore non-existent container - expect failure
        $InvalidContainerName = "Invalid-Container459"
        $RestoreInvalidContainerResult = Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $InvalidContainerName
        Assert-Null $RestoreInvalidContainerResult

        # 7. Restore deleted container in #5
        Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

        Start-TestSleep -s 50

        # list containers
        $ListContainers = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
        Assert-NotNull($ListContainers)

        # 8. Delete database
        Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 100

        # list databases
        $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-Null($ListDatabases)

        # 9. Restore container - expect failure (database is offline)
        $RestoreContainerWhenDatabaseOfflineResult = Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Assert-Null $RestoreContainerWhenDatabaseOfflineResult

        # 10. Restore deleted database
        Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 50

        # list databases
        $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-NotNull($ListDatabases)

        Start-TestSleep -s 50

        # 11. Restore collection
        $RestoredCollection = Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

        Start-TestSleep -s 50

        # list containers
        $ListContainers = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
        Assert-NotNull($ListContainers)

        # 12. Restore container again - expect failure (collection already online)
        $SecondInAccountContainerRestore = Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Assert-Null $SecondInAccountContainerRestore

        # 13. Delete database
        Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 100

        # list databases
        $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-Null($ListDatabases)

        # 14. Restore non-existent database - expect failure
        $InvalidDatabaseName = "InvalidDatabaseName"
        $RestoreInvalidDatabase = Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $InvalidDatabaseName
        Assert-Null $RestoreInvalidDatabase


        # 15. Restore database
        Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 50

        # list databases
        $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-NotNull($ListDatabases)

        # 16. Restore database again - expect failure (database already exists)
        $SecondInAccountDatabaseRestore = Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-Null $SecondInAccountDatabaseRestore

        # 17. Restore collection
        $RestoredCollection = Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Start-TestSleep -s 50
        Assert-NotNull $RestoredCollection

        # list containers
        $ListContainers = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
        Assert-NotNull $ListContainers
  }
  Catch {
        Write-Output "Error: $_"
        throw $_
  }
  Finally {
        Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test Gremlin InAccount Restore cmdlets using Name parameter set
#>
function Test-GremlinInAccountRestoreOperationsNoTimestampCmdlets
{
  $AccountName = "gremlin-db1051-5"
  $rgName = "CosmosDBResourceGroup51-5"
  $DatabaseName = "dbName"
  $graphName = "graph1"
  $location = "East US"
  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"
  $apiKind = "Gremlin"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      # create a new database
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous

      $NewDatabase =  New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      # create a new graph
      $Newgraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      Assert-AreEqual $Newgraph.Name $graphName

      # create an existing graph
      Try {
            $NewDuplicategraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $graphName + " already exists.")
      }

      # Get the database
      $Database = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # Get the graph
      $graph = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName
      Assert-AreEqual $Newgraph.Id $graph.Id
      Assert-AreEqual $Newgraph.Name $graph.Name

      # list graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # list databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      Start-TestSleep -s 50

      # Delete the graph
      $IsGraphRemoved = Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PassThru
      Assert-AreEqual $IsGraphRemoved true

      Start-TestSleep -s 100

      $Restoredgraph = Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName

      Start-TestSleep -s 100

      # list graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # Delete the database
      $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsDatabaseRemoved true

      Start-TestSleep -s 100

      # Restore the deleted database
      Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

      Start-TestSleep -s 100

      # Restore the deleted graph with no timestamp after database restore
      Try {
          Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("No graph with name") true
      }
      Start-TestSleep -s 50

      # List graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # List databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      # Delete the database
      $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsDatabaseRemoved true
  }
  Finally
  {
    Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName  
    Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test Gremlin InAccount Restore cmdlets using Name parameter set
#>
function Test-GremlinInAccountRestoreOperationsSharedRUResourcesCmdlets
{
  $AccountName = "gremlin-db1051-3"
  $rgName = "CosmosDBResourceGroup51-3"
  $DatabaseName = "dbName"
  $graphName = "graph1"
  $location = "East US"
  $PartitionKeyPathValue = "/foo"
  $PartitionKeyKindValue = "Hash"
  $apiKind = "Gremlin"
  $consistencyLevel = "Session"
  $ThroughputValue = 500
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      # create a new database
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous

      $NewDatabase =  New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing database
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      # create a new graph
      $Newgraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      Assert-AreEqual $Newgraph.Name $graphName

      # create an existing graph
      Try {
            $NewDuplicategraph = New-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $graphName + " already exists.")
      }

      # Get the database
      $Database = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # Get the graph
      $graph = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName
      Assert-AreEqual $Newgraph.Id $graph.Id
      Assert-AreEqual $Newgraph.Name $graph.Name

      $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

      # list graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # list databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      Start-TestSleep -s 50

      # Delete the graph
      $IsGraphRemoved = Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PassThru
      Assert-AreEqual $IsGraphRemoved true

      Start-TestSleep -s 50

      Try {
          Restore-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -RestoreTimestampInUtc $restoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("InAccount restore of individual shared database collections is not supported. Please restore shared database to restore its collections that shared the throughput") true
      }

      # Delete the database
      $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsDatabaseRemoved true

      Start-TestSleep -s 100

      # Restore the deleted database
      Restore-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 100

      # List graphs
      $Listgraphs = Get-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($Listgraphs)

      # List databases
      $ListDatabases = Get-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      # Delete the graph
      $IsGraphRemoved = Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $graphName -PassThru
      Assert-AreEqual $IsGraphRemoved true

      # Delete the database
      $IsDatabaseRemoved = Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -PassThru
      Assert-AreEqual $IsDatabaseRemoved true
  }
  Finally
  {
    Remove-AzCosmosDBGremlinGraph -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $GraphName  
    Remove-AzCosmosDBGremlinDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test Gremlin Roles cmdlets using all parameter sets
#>
function Test-GremlinRoleCmdlets
{
  $AccountName = "yayi-gremlin-test-1"
  $rgName = "yayi-test"  
  $location = "West US 2"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "UK South" -FailoverPriority 0 -IsZoneRedundant 0

  $GremlinName = "gremlin1"
  $GremlinName2 = "gremlin2"
  $apiKind = "Gremlin"
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

  $DataActionRead =     "Microsoft.DocumentDB/databaseAccounts/gremlin/containers/entities/read"
  $DataActionCreate =   "Microsoft.DocumentDB/databaseAccounts/gremlin/containers/entities/create"
  $DataActionReplace =  "Microsoft.DocumentDB/databaseAccounts/gremlin/containers/entities/replace"
  $DataActionInvalid =  "Microsoft.DocumentDB/databaseAccounts/gremlin/containers/entities/invalid-action"

  $Scope = "/"
  $FullyQualifiedScope = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName"
  $Scope2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/dbs/dbName"

  $RoleDefinitionId = "df31c3a1-20f5-4ff1-bdd0-5e0782617e22"
  $FullyQualifiedRoleDefinitionId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/gremlinRoleDefinitions/df31c3a1-20f5-4ff1-bdd0-5e0782617e22"
  $RoleDefinitionId2 = "a36e56a5-9afc-4819-aa78-3a8083a3ee74"
  $FullyQualifiedRoleDefinitionId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/gremlinRoleDefinitions/a36e56a5-9afc-4819-aa78-3a8083a3ee74"
  $RoleDefinitionId3 = "9ee200b5-73fd-4779-b36a-e2a31f9244f3"
  $FullyQualifiedRoleDefinitionId3 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/gremlinRoleDefinitions/9ee200b5-73fd-4779-b36a-e2a31f9244f3"
  $RoleDefinitionId6 = "7ff311a6-73fd-4779-b36a-e2a31f9244f3"  

  $RoleAssignmentId = "a2ccaf94-3c39-4728-b892-95edeef0e754"
  $FullyQualifiedRoleAssignmentId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/gremlinRoleAssignments/a2ccaf94-3c39-4728-b892-95edeef0e754"
  $RoleAssignmentId2 = "8f3f78c4-a8df-4088-9cbb-a3947e27076b"
  $FullyQualifiedRoleAssignmentId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/gremlinRoleAssignments/8f3f78c4-a8df-4088-9cbb-a3947e27076b"
  $RoleAssignmentId3 = "e7a0b8a5-b381-495d-a020-5467c534e619"
  $FullyQualifiedRoleAssignmentId3 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/gremlinRoleAssignments/e7a0b8a5-b381-495d-a020-5467c534e619"


  Try{

      $DatabaseAccount = Get-AzCosmosDBAccount -Name $AccountName -ResourceGroupName $rgName

      # update non-existing role definition, role assignment
      Try {
          $UpdatedRoleDefinition = Update-AzCosmosDBGremlinRoleDefinition -Type "CustomRole" -RoleName "RoleName3" -DataAction $DataActionCreate -AssignableScope $Scope2 -Id "00000000-0000-0000-0000-000000000000" -AccountName $AccountName -ResourceGroupName $rgName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Role Definition with Id [00000000-0000-0000-0000-000000000000] does not exist.")
      }
      Try {
          $UpdatedRoleAssignment = Update-AzCosmosDBGremlinRoleAssignment -RoleDefinitionName "RoleName4" -Id "11111111-1111-1111-1111-111111111111" -AccountName $AccountName -ResourceGroupName $rgName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Role Assignment with Name [RoleName4] does not exist.")
      }

      #role def tests
      # create a new role definition - using parent object and permission
      $Permissions = New-AzCosmosDBPermission -DataAction $DataActionRead
      $NewRoleDefinitionFromParentObject = New-AzCosmosDBGremlinRoleDefinition -Type "CustomRole" -RoleName $RoleName -Permission $Permissions -AssignableScope $Scope -Id $RoleDefinitionId -ParentObject $DatabaseAccount
      Assert-AreEqual $NewRoleDefinitionFromParentObject.RoleName $RoleName
      Assert-AreEqual $NewRoleDefinitionFromParentObject.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromParentObject.Id $FullyQualifiedRoleDefinitionId
      Assert-NotNull $NewRoleDefinitionFromParentObject.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromParentObject.Permissions

      # create a new role definition - using fields and data actions
      $NewRoleDefinitionFromFields = New-AzCosmosDBGremlinRoleDefinition -Type "CustomRole" -RoleName $RoleName2 -DataAction $DataActionCreate -AssignableScope $Scope2 -Id $RoleDefinitionId2 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleDefinitionFromFields.RoleName $RoleName2
      Assert-AreEqual $NewRoleDefinitionFromFields.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromFields.Id $FullyQualifiedRoleDefinitionId2
      Assert-NotNull $NewRoleDefinitionFromFields.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromFields.Permissions

      $NewRoleDefinitionFromFields2 = New-AzCosmosDBGremlinRoleDefinition -Type "CustomRole" -RoleName $RoleName3 -DataAction $DataActionCreate -AssignableScope $Scope -Id $RoleDefinitionId3 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleDefinitionFromFields2.RoleName $RoleName3
      Assert-AreEqual $NewRoleDefinitionFromFields2.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromFields2.Id $FullyQualifiedRoleDefinitionId3
      Assert-NotNull $NewRoleDefinitionFromFields2.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromFields2.Permissions

      # get a role definition
      $RoleDefinition = Get-AzCosmosDBGremlinRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId
      Assert-AreEqual $RoleDefinition.RoleName $RoleName
      Assert-AreEqual $RoleDefinition.Type "CustomRole"
      Assert-NotNull $RoleDefinition.AssignableScopes
      Assert-NotNull $RoleDefinition.Permissions

      # update role definition by parent object and data actions
      $UpdatedRoleDefinition = Update-AzCosmosDBGremlinRoleDefinition -Type "CustomRole" -RoleName $RoleName4 -DataAction $DataActionReplace -AssignableScope $Scope -Id $RoleDefinitionId -ParentObject $DatabaseAccount
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName4
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions

      # update role definition by fields and permissions
      $UpdatedRoleDefinition = Update-AzCosmosDBGremlinRoleDefinition -Type "CustomRole" -RoleName $RoleName5 -Permission $Permissions -AssignableScope $Scope -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName5
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions

      # list Role Definitions
      $ListRoleDefinitions = Get-AzCosmosDBGremlinRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull $ListRoleDefinitions

      #role assignment tests
      # create a new role assignment from name
      $NewRoleAssignmentFromName = New-AzCosmosDBGremlinRoleAssignment -RoleDefinitionName $RoleName5 -Scope $Scope -PrincipalId $PrincipalId -Id $RoleAssignmentId2 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleAssignmentFromName.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $NewRoleAssignmentFromName.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromName.PrincipalId $PrincipalId
      Assert-AreEqual $NewRoleAssignmentFromName.Id $FullyQualifiedRoleAssignmentId2

      # create a new role assignment from parent object
      $NewRoleAssignmentFromParentObject = New-AzCosmosDBGremlinRoleAssignment -ParentObject $NewRoleDefinitionFromFields2 -Scope $Scope -PrincipalId $PrincipalId2 -Id $RoleAssignmentId3
      Assert-AreEqual $NewRoleAssignmentFromParentObject.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $NewRoleAssignmentFromParentObject.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromParentObject.PrincipalId $PrincipalId2
      Assert-AreEqual $NewRoleAssignmentFromParentObject.Id $FullyQualifiedRoleAssignmentId3

      # create a new role assignment from Id
      $NewRoleAssignmentFromId3 = New-AzCosmosDBGremlinRoleAssignment -RoleDefinitionId $RoleDefinitionId -Scope $Scope -PrincipalId $PrincipalId -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Assert-AreEqual $NewRoleAssignmentFromId3.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $NewRoleAssignmentFromId3.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromId3.PrincipalId $PrincipalId
      Assert-NotNull $NewRoleAssignmentFromId3.Id

      # get a role assignment
      $RoleAssignment = Get-AzCosmosDBGremlinRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Assert-AreEqual $RoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $RoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $RoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $RoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignment by role definition name
      $UpdatedRoleAssignment = Update-AzCosmosDBGremlinRoleAssignment -RoleDefinitionName $RoleName3 -Id $RoleAssignmentId -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by role definition id
      $UpdatedRoleAssignment = Update-AzCosmosDBGremlinRoleAssignment -RoleDefinitionId $RoleDefinitionId -Id $RoleAssignmentId -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by input object
      $UpdatedRoleAssignment.RoleDefinitionId = $FullyQualifiedRoleDefinitionId3
      $UpdatedRoleAssignment = Update-AzCosmosDBGremlinRoleAssignment -InputObject $UpdatedRoleAssignment
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by parent object
      $UpdatedRoleAssignment = Update-AzCosmosDBGremlinRoleAssignment -Id $RoleAssignmentId -ParentObject $UpdatedRoleDefinition
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # list Role Assignments
      $ListRoleAssignments = Get-AzCosmosDBGremlinRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull $ListRoleAssignments

      # check for correct error propagation
      $PermissionsInvalid = New-AzCosmosDBPermission -DataAction $DataActionInvalid
      $ScriptBlockRoleDef = { New-AzCosmosDBGremlinRoleDefinition -Type "CustomRole" -RoleName $RoleName6 -Permission $PermissionsInvalid -AssignableScope $Scope -Id $RoleDefinitionId6 -ParentObject $DatabaseAccount }
      Assert-ThrowsContains $ScriptBlockRoleDef "BadRequest"
  }
  Finally {
      $DatabaseAccount = Get-AzCosmosDBAccount -Name $AccountName -ResourceGroupName $rgName

      Remove-AzCosmosDBGremlinRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Remove-AzCosmosDBGremlinRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId2
      Remove-AzCosmosDBGremlinRoleAssignment -ParentObject $DatabaseAccount -Id $RoleAssignmentId3

      Remove-AzCosmosDBGremlinRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId
      Remove-AzCosmosDBGremlinRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId2
      Remove-AzCosmosDBGremlinRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId3
  }
}