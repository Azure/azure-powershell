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
Test SQL CRUD operations using Name parameter set
#>
function Test-SqlOperationsCmdlets
{
  $AccountName = "cosmosdb9921232812"
  $rgName = "rgtest9921232812"
  $DatabaseName = "dbName"
  $ContainerName = "container1"
  $StoredProcedureName = "storedProcedure"
  $UDFName = "udf"
  $TriggerName = "trigger"

  $DatabaseName2 = "dbName2"
  $ContainerName2 = "container2"
  $StoredProcedureName2 = "storedProcedure2"
  $UDFName2 = "udf2"
  $TriggerName2 = "trigger2"

  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"

  $Body = "function () { var context = getContext(); " +
                        "var response = context.getResponse();" +
                        "response.setBody('Hello, World');" +
                        "}"
  $Body2 = "function () { var x = 10;" +
                        "}"

  $TriggerOperation = "All"
  $TriggerType = "Pre"

  Try{
      # create a new database
      $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing keyspace
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      # Indexing Policy Creation
      $ipath1 = New-AzCosmosDBSqlIncludedPathIndex -DataType String -Precision -1 -Kind Hash
      $ipath2 = New-AzCosmosDBSqlIncludedPathIndex -DataType String -Precision -1 -Kind Hash
      $IncludedPath = New-AzCosmosDBSqlIncludedPath -Path "/*" -Index $ipath1, $ipath2
      $SpatialSpec = New-AzCosmosDBSqlSpatialSpec -Path  "/mySpatialPath/*" -Type  "Point", "LineString", "Polygon", "MultiPolygon"
      $cp1 = New-AzCosmosDBSqlCompositePath -Path "/abc" -Order Ascending
      $cp2 = New-AzCosmosDBSqlCompositePath -Path "/aberc" -Order Descending
      $CompositePaths = (($cp1, $cp2), ($cp2, $cp1))

      $IndexingPolicy = New-AzCosmosDBSqlIndexingPolicy -IncludedPath $IncludedPath -SpatialSpec $SpatialSpec -CompositePath $CompositePaths -ExcludedPath "/myPathToNotIndex/*" -Automatic 1 -IndexingMode Consistent
     
      # UniqueKey Creation
      $p1 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey3"
      $p2 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey4"
      $p3 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey2"
      $p4 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey1"

      $uk1 = New-AzCosmosDBSqlUniqueKeyPolicy -UniqueKey $p1,$p2,$p3,$p4
      # create a new container
      $NewContainer = New-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600 -IndexingPolicy $IndexingPolicy -UniqueKeyPolicy $uk1
      Assert-AreEqual $NewContainer.Name $ContainerName
      Assert-AreEqual $NewContainer.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
      Assert-AreEqual $NewContainer.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
      Assert-AreEqual $NewContainer.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
      Assert-AreEqual $NewContainer.Resource.IndexingPolicy.CompositeIndexes.Count 2
      Assert-AreEqual $NewContainer.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path
      Assert-AreEqual $NewContainer.Resource.UniqueKeyPolicy.UniqueKeys.Count 4

      # create an existing container
      Try {
            $NewDuplicateContainer = New-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600 -IndexingPolicy $IndexingPolicy 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $ContainerName + " already exists.")
      }

      # create a new stored procedure
      $NewStoredProcedure = New-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName -Body $Body
      Assert-AreEqual $NewStoredProcedure.Name $StoredProcedureName
      Assert-AreEqual $NewStoredProcedure.Resource.Body $Body

      # create an existing stored procedure
      Try {
            $NewDuplicateStoredProcedure = New-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName -Body $Body
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $StoredProcedureName + " already exists.")
      }

      # create a new UDF
      $NewUDF = New-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $UDFName -Body $Body
      Assert-AreEqual $NewUDF.Name $UDFName
      Assert-AreEqual $NewUDF.Resource.Body $Body

      # create an existing UDF
      Try {
            $NewDuplicateUDF = New-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $UDFName -Body $Body
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $UDFName + " already exists.")
      }

      # create a new Trigger
      $NewTrigger = New-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName -Body $Body -TriggerOperation $TriggerOperation -TriggerType $TriggerType
      Assert-AreEqual $NewTrigger.Name $TriggerName
      Assert-AreEqual $NewTrigger.Resource.Body $Body
      Assert-AreEqual $NewTrigger.Resource.TriggerOperation $TriggerOperation
      Assert-AreEqual $NewTrigger.Resource.TriggerType $TriggerType

      # create an existing Trigger
      Try {
          $NewDuplicateTrigger = New-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName -Body $Body -TriggerOperation $TriggerOperation -TriggerType $TriggerType
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $TriggerName + " already exists.")
      }

      # update non existing database, container, UDF, stored procedure, trigger
      Try {
          $UpdatedDatabse = Update-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName2 + " does not exist.")
      }

      Try {
          $UpdatedContainer = Update-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $ContainerName2 + " does not exist.")
      }

      Try {
          $UpdatedStoredProcedure  = Update-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName2 -Body $Body 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $StoredProcedureName2 + " does not exist.")
      }

      Try {
          $UpdatedTrigger  = Update-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName2 -Body $Body 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $TriggerName2 + " does not exist.")
      }

      Try {
          $UpdatedUDF  = Update-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $UDFName2 -Body $Body 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $UDFName2 + " does not exist.")
      }

      # get a database
      $Database = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # get a container
      $Container = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Assert-AreEqual $NewContainer.Id $Container.Id
      Assert-AreEqual $NewContainer.Name $Container.Name

      # get a stored procedure
      $StoredProcedure = Get-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName
      Assert-AreEqual $NewStoredProcedure.Id $StoredProcedure.Id
      Assert-AreEqual $NewStoredProcedure.Name $StoredProcedure.Name
      Assert-AreEqual $NewStoredProcedure.Resource.Body $StoredProcedure.Resource.Body
  
      # get a UDF
      $UDF = Get-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $UDFName
      Assert-AreEqual $NewUDF.Id $UDF.Id
      Assert-AreEqual $NewUDF.Name $UDF.Name
      Assert-AreEqual $NewUDF.Resource.Body $UDF.Resource.Body

      # get a trigger
      $Trigger = Get-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName
      Assert-AreEqual $NewTrigger.Id $Trigger.Id
      Assert-AreEqual $NewTrigger.Name $Trigger.Name
      Assert-AreEqual $NewTrigger.Resource.Body $Trigger.Resource.Body
      Assert-AreEqual $NewTrigger.Resource.TriggerType $Trigger.Resource.TriggerType
      Assert-AreEqual $NewTrigger.Resource.TriggerOperation $Trigger.Resource.TriggerOperation

      # updating database, container, udf, trigger
      $UpdatedDatabase =  Update-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $UpdatedDatabase.Name $DatabaseName

      # update container
      $UpdatedContainer = Update-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Assert-AreEqual $UpdatedContainer.Name $ContainerName
      Assert-AreEqual $UpdatedContainer.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
      Assert-AreEqual $UpdatedContainer.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
      Assert-AreEqual $UpdatedContainer.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
      Assert-AreEqual $UpdatedContainer.Resource.IndexingPolicy.CompositeIndexes.Count 2
      Assert-AreEqual $UpdatedContainer.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path
      Assert-AreEqual $UpdatedContainer.Resource.UniqueKeyPolicy.UniqueKeys.Count 4

      # update storedprocedure
      $UpdatedStoredProcedure = Update-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName -Body $Body2
      Assert-AreEqual $UpdatedStoredProcedure.Name $StoredProcedureName
      Assert-AreEqual $UpdatedStoredProcedure.Resource.Body $Body2

      # update trigger
      $UpdatedTrigger = Update-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName -Body $Body2 
      Assert-AreEqual $UpdatedTrigger.Name $TriggerName
      Assert-AreEqual $UpdatedTrigger.Resource.Body $Body2
      Assert-AreEqual $UpdatedTrigger.Resource.TriggerOperation $TriggerOperation
      Assert-AreEqual $UpdatedTrigger.Resource.TriggerType $TriggerType

      # update udf
      $UpdatedUDF = Update-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $UDFName -Body $Body2
      Assert-AreEqual $UpdatedUDF.Name $UDFName
      Assert-AreEqual $UpdatedUDF.Resource.Body $Body2

      # list containers
      $ListContainers = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListContainers)

      # list databases
      $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      # list stored procedures
      $ListStoredProcedures = Get-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName
      Assert-NotNull($ListStoredProcedures)

      # list udfs
      $ListUDFs = Get-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName
      Assert-NotNull($ListUDFs)

      # list triggers
      $ListTriggers = Get-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName
      Assert-NotNull($ListTriggers)

      Remove-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName 

      Remove-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName 

      Remove-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName  -Name $UDFName 

      Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName 

      Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
  }
  Finally {
    Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName 
    Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
  }
}

<#
.SYNOPSIS
Test SQL CRUD operations using input object and parent object set
#>
function Test-SqlOperationsCmdletsUsingInputObject
{
  $AccountName = "cosmosdb9921232812"
  $rgName = "rgtest9921232812"
  $DatabaseName = "dbName"
  $ContainerName = "container1"
  $StoredProcedureName = "storedProcedure"
  $UDFName = "udf"
  $TriggerName = "trigger"

  $DatabaseName2 = "dbName2"
  $ContainerName2 = "container2"
  $StoredProcedureName2 = "storedProcedure2"
  $UDFName2 = "udf2"
  $TriggerName2 = "trigger2"

  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"

  $Body = "function () { var context = getContext(); " +
                        "var response = context.getResponse();" +
                        "response.setBody('Hello, World');" +
                        "}"
  $Body2 = "function () { var x = 10;" +
                        "}"

  $TriggerOperation = "All"
  $TriggerType = "Pre"

  Try{
      
      # get the database account object
      $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName

      # create a new database
      $NewDatabase =  New-AzCosmosDBSqlDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # Indexing Policy Creation
      $ipath1 = New-AzCosmosDBSqlIncludedPathIndex -DataType String -Precision -1 -Kind Hash
      $ipath2 = New-AzCosmosDBSqlIncludedPathIndex -DataType String -Precision -1 -Kind Hash
      $IncludedPath = New-AzCosmosDBSqlIncludedPath -Path "/*" -Index $ipath1, $ipath2
      $SpatialSpec = New-AzCosmosDBSqlSpatialSpec -Path  "/mySpatialPath/*" -Type  "Point", "LineString", "Polygon", "MultiPolygon"
      $cp1 = New-AzCosmosDBSqlCompositePath -Path "/abc" -Order Ascending
      $cp2 = New-AzCosmosDBSqlCompositePath -Path "/aberc" -Order Descending
      $CompositePaths = (($cp1, $cp2), ($cp2, $cp1))

      $IndexingPolicy = New-AzCosmosDBSqlIndexingPolicy -IncludedPath $IncludedPath -SpatialSpec $SpatialSpec -CompositePath $CompositePaths -ExcludedPath "/myPathToNotIndex/*" -Automatic 1 -IndexingMode Consistent
     
      # create a new  uniquekeypolicy
      $p1 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey3"
      $p2 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey4"
      $p3 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey2"
      $p4 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey1"

      $uk1 = New-AzCosmosDBSqlUniqueKeyPolicy -UniqueKey $p1,$p2,$p3,$p4
      # create a new container
      $NewContainer = New-AzCosmosDBSqlContainer -ParentObject $NewDatabase -Name $ContainerName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600 -IndexingPolicy $IndexingPolicy -UniqueKeyPolicy $uk1
      Assert-AreEqual $NewContainer.Name $ContainerName
      Assert-AreEqual $NewContainer.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
      Assert-AreEqual $NewContainer.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
      Assert-AreEqual $NewContainer.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
      Assert-AreEqual $NewContainer.Resource.IndexingPolicy.CompositeIndexes.Count 2
      Assert-AreEqual $NewContainer.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path

      # create a new stored procedure
      $NewStoredProcedure = New-AzCosmosDBSqlStoredProcedure -ParentObject $NewContainer -Name $StoredProcedureName -Body $Body
      Assert-AreEqual $NewStoredProcedure.Name $StoredProcedureName
      Assert-AreEqual $NewStoredProcedure.Resource.Body $Body

      # create a new UDF
      $NewUDF = New-AzCosmosDBSqlUserDefinedFunction -ParentObject $NewContainer -Name $UDFName -Body $Body
      Assert-AreEqual $NewUDF.Name $UDFName
      Assert-AreEqual $NewUDF.Resource.Body $Body

      # create a new Trigger
      $NewTrigger = New-AzCosmosDBSqlTrigger -ParentObject $NewContainer -Name $TriggerName -Body $Body -TriggerOperation $TriggerOperation -TriggerType $TriggerType
      Assert-AreEqual $NewTrigger.Name $TriggerName
      Assert-AreEqual $NewTrigger.Resource.Body $Body
      Assert-AreEqual $NewTrigger.Resource.TriggerOperation $TriggerOperation
      Assert-AreEqual $NewTrigger.Resource.TriggerType $TriggerType

      # get a database
      $Database = Get-AzCosmosDBSqlDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # get a container
      $Container = Get-AzCosmosDBSqlContainer -ParentObject $NewDatabase -Name $ContainerName
      Assert-AreEqual $NewContainer.Id $Container.Id
      Assert-AreEqual $NewContainer.Name $Container.Name

      # get a stored procedure
      $StoredProcedure = Get-AzCosmosDBSqlStoredProcedure -ParentObject $NewContainer -Name $StoredProcedureName
      Assert-AreEqual $NewStoredProcedure.Id $StoredProcedure.Id
      Assert-AreEqual $NewStoredProcedure.Name $StoredProcedure.Name
      Assert-AreEqual $NewStoredProcedure.Resource.Body $StoredProcedure.Resource.Body
  
      # get a UDF
      $UDF = Get-AzCosmosDBSqlUserDefinedFunction -ParentObject $NewContainer -Name $UDFName
      Assert-AreEqual $NewUDF.Id $UDF.Id
      Assert-AreEqual $NewUDF.Name $UDF.Name
      Assert-AreEqual $NewUDF.Resource.Body $UDF.Resource.Body

      # get a trigger
      $Trigger = Get-AzCosmosDBSqlTrigger -ParentObject $NewContainer -Name $TriggerName
      Assert-AreEqual $NewTrigger.Id $Trigger.Id
      Assert-AreEqual $NewTrigger.Name $Trigger.Name
      Assert-AreEqual $NewTrigger.Resource.Body $Trigger.Resource.Body
      Assert-AreEqual $NewTrigger.Resource.TriggerType $Trigger.Resource.TriggerType
      Assert-AreEqual $NewTrigger.Resource.TriggerOperation $Trigger.Resource.TriggerOperation

      # updating database using parent object
      $UpdatedDatabase =  Update-AzCosmosDBSqlDatabase -ParentObject $cosmosDBAccount -Name $DatabaseName
      Assert-AreEqual $UpdatedDatabase.Name $DatabaseName

      # update container using parent object
      $UpdatedContainer = Update-AzCosmosDBSqlContainer -ParentObject $NewDatabase -Name $ContainerName
      Assert-AreEqual $UpdatedContainer.Name $ContainerName
      Assert-AreEqual $UpdatedContainer.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
      Assert-AreEqual $UpdatedContainer.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
      Assert-AreEqual $UpdatedContainer.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
      Assert-AreEqual $UpdatedContainer.Resource.IndexingPolicy.CompositeIndexes.Count 2
      Assert-AreEqual $UpdatedContainer.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path
      Assert-AreEqual $UpdatedContainer.Resource.UniqueKeyPolicy.UniqueKeys.Count 4

      # update storedprocedure using parent object
      $UpdatedStoredProcedure = Update-AzCosmosDBSqlStoredProcedure -ParentObject $NewContainer -Name $StoredProcedureName -Body $Body2
      Assert-AreEqual $UpdatedStoredProcedure.Name $StoredProcedureName
      Assert-AreEqual $UpdatedStoredProcedure.Resource.Body $Body2

      # update trigger using parent object
      $UpdatedTrigger = Update-AzCosmosDBSqlTrigger -ParentObject $NewContainer -Name $TriggerName -Body $Body2 
      Assert-AreEqual $UpdatedTrigger.Name $TriggerName
      Assert-AreEqual $UpdatedTrigger.Resource.Body $Body2
      Assert-AreEqual $UpdatedTrigger.Resource.TriggerOperation $TriggerOperation
      Assert-AreEqual $UpdatedTrigger.Resource.TriggerType $TriggerType

      # update udf using parent object
      $UpdatedUDF = Update-AzCosmosDBSqlUserDefinedFunction -ParentObject $NewContainer -Name $UDFName -Body $Body2
      Assert-AreEqual $UpdatedUDF.Name $UDFName
      Assert-AreEqual $UpdatedUDF.Resource.Body $Body2

      # updating database using input object
      $UpdatedDatabase2 =  Update-AzCosmosDBSqlDatabase -InputObject $UpdatedDatabase
      Assert-AreEqual $UpdatedDatabase2.Name $DatabaseName

      # update container using inpu object
      $UpdatedContainer2 = Update-AzCosmosDBSqlContainer -InputObject $UpdatedContainer
      Assert-AreEqual $UpdatedContainer2.Name $ContainerName
      Assert-AreEqual $UpdatedContainer2.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
      Assert-AreEqual $UpdatedContainer2.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
      Assert-AreEqual $UpdatedContainer2.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
      Assert-AreEqual $UpdatedContainer2.Resource.IndexingPolicy.CompositeIndexes.Count 2
      Assert-AreEqual $UpdatedContainer2.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path
      Assert-AreEqual $UpdatedContainer2.Resource.UniqueKeyPolicy.UniqueKeys.Count 4

      # update storedprocedure using parent object
      $UpdatedStoredProcedure2 = Update-AzCosmosDBSqlStoredProcedure -InputObject $UpdatedStoredProcedure -Body $Body
      Assert-AreEqual $UpdatedStoredProcedure2.Name $StoredProcedureName
      Assert-AreEqual $UpdatedStoredProcedure2.Resource.Body $Body

      # update trigger using parent object
      $UpdatedTrigger2 = Update-AzCosmosDBSqlTrigger -InputObject $UpdatedTrigger -Body $Body
      Assert-AreEqual $UpdatedTrigger2.Name $TriggerName
      Assert-AreEqual $UpdatedTrigger2.Resource.Body $Body
      Assert-AreEqual $UpdatedTrigger2.Resource.TriggerOperation $TriggerOperation
      Assert-AreEqual $UpdatedTrigger2.Resource.TriggerType $TriggerType

      # update udf using parent object
      $UpdatedUDF2 = Update-AzCosmosDBSqlUserDefinedFunction -InputObject $UpdatedUDF -Body $Body
      Assert-AreEqual $UpdatedUDF2.Name $UDFName
      Assert-AreEqual $UpdatedUDF2.Resource.Body $Body

      # list containers
      $ListContainers = Get-AzCosmosDBSqlContainer -ParentObject $NewDatabase
      Assert-NotNull($ListContainers)

      # list databases
      $ListDatabases = Get-AzCosmosDBSqlDatabase -ParentObject $cosmosDBAccount
      Assert-NotNull($ListDatabases)

      # list stored procedures
      $ListStoredProcedures = Get-AzCosmosDBSqlStoredProcedure -ParentObject $NewContainer 
      Assert-NotNull($ListStoredProcedures)

      # list udfs
      $ListUDFs = Get-AzCosmosDBSqlUserDefinedFunction  -ParentObject $NewContainer 
      Assert-NotNull($ListUDFs)

      # list triggers
      $ListTriggers = Get-AzCosmosDBSqlTrigger  -ParentObject $NewContainer
      Assert-NotNull($ListTriggers)

      Remove-AzCosmosDBSqlStoredProcedure -InputObject $NewStoredProcedure

      Remove-AzCosmosDBSqlTrigger -InputObject $NewTrigger

      Remove-AzCosmosDBSqlUserDefinedFunction -InputObject $NewUDF

      Remove-AzCosmosDBSqlContainer -InputObject $NewContainer

      Remove-AzCosmosDBSqlDatabase -InputObject $NewDatabase
  }
  Finally {

    Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName 
    Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
  }
}

<#
.SYNOPSIS
Test SQL throughput cmdlets using all parameter sets
#>
function Test-SqlThroughputCmdlets
{
  $AccountName = "cosmosdb9921232812"
  $rgName = "rgtest9921232812"
  $DatabaseName = "dbName3"
  $ContainerName = "containerName"

  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"

  $ThroughputValue = 1200
  $UpdatedThroughputValue = 1100
  $UpdatedThroughputValue2 = 1000
  $UpdatedThroughputValue3 = 900

  $ContainerThroughputValue = 800
  $UpdatedContainerThroughputValue = 700
  $UpdatedContainerThroughputValue2 = 600
  $UpdatedContainerThroughputValue3 = 500

  $DatabaseName2 = "dbName4"
  $ContainerName2 = "containerName3"
  $AutoscaleContainerThroughput = 5000
  $AutoscaleUpdatedContainerThroughput = 10000
  $AutoscaleDatabaseThroughput = 8000
  $AutoscaleUpdatedDatabaseThroughput = 12000

  Try{
      $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
      $Throughput = Get-AzCosmosDBSqlDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue

      $UpdatedThroughput = Update-AzCosmosDBSqlDatabaseThroughput  -InputObject $NewDatabase -Throughput $UpdatedThroughputValue
      Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue

      $UpdatedThroughput = Update-AzCosmosDBSqlDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $UpdatedThroughputValue2
      Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue2

      $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName
      $UpdatedThroughput = Update-AzCosmosDBSqlDatabaseThroughput  -ParentObject $CosmosDBAccount -Name $DatabaseName -Throughput $UpdatedThroughputValue3
      Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue3

      $NewContainer =  New-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Throughput  $ContainerThroughputValue -Name $ContainerName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      $ContainerThroughput = Get-AzCosmosDBSqlContainerThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Assert-AreEqual $ContainerThroughput.Throughput $ContainerThroughputValue

      $UpdatedContainerThroughput = Update-AzCosmosDBSqlContainerThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -Throughput $UpdatedContainerThroughputValue
      Assert-AreEqual $UpdatedContainerThroughput.Throughput $UpdatedContainerThroughputValue

      $UpdatedContainerThroughput = Update-AzCosmosDBSqlContainerThroughput  -InputObject $NewContainer -Throughput $UpdatedContainerThroughputValue2
      Assert-AreEqual $UpdatedContainerThroughput.Throughput $UpdatedContainerThroughputValue2

      $UpdatedContainerThroughput = Update-AzCosmosDBSqlContainerThroughput -ParentObject $NewDatabase -Name $ContainerName -Throughput $UpdatedContainerThroughputValue3
      Assert-AreEqual $UpdatedContainerThroughput.Throughput $UpdatedContainerThroughputValue3

      # autoscale scenarios
      $AutoscaleDatabase =  New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName2 -AutoscaleMaxThroughput $AutoscaleDatabaseThroughput
      $Throughput = Get-AzCosmosDBSqlDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName2
      Assert-AreEqual $Throughput.AutoscaleSettings.MaxThroughput $AutoscaleDatabaseThroughput

      $AutoscaleContainer =  New-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName2 -AutoscaleMaxThroughput $AutoscaleContainerThroughput -Name $ContainerName2 -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      $ContainerThroughput = Get-AzCosmosDBSqlContainerThroughput -InputObject $AutoscaleContainer
      Assert-AreEqual $ContainerThroughput.AutoscaleSettings.MaxThroughput $AutoscaleContainerThroughput

      $UpdatedContainerThroughput = Update-AzCosmosDBSqlContainerThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName2 -Name $ContainerName2 -AutoscaleMaxThroughput $AutoscaleUpdatedContainerThroughput
      Assert-AreEqual $UpdatedContainerThroughput.AutoscaleSettings.MaxThroughput $AutoscaleUpdatedContainerThroughput

      # can only update throughput of database if it has atleast one container with shared throughput
      # $UpdatedThroughput = Update-AzCosmosDBSqlDatabaseThroughput  -InputObject $AutoscaleDatabase -AutoscaleMaxThroughput $AutoscaleUpdatedDatabaseThroughput
      # Assert-AreEqual $UpdatedThroughput.AutoscaleSettings.MaxThroughput $AutoscaleUpdatedDatabaseThroughput

      Remove-AzCosmosDBSqlContainer -InputObject $NewContainer 
      Remove-AzCosmosDBSqlDatabase -InputObject $NewDatabase
      Remove-AzCosmosDBSqlContainer -InputObject $AutoscaleContainer 
      Remove-AzCosmosDBSqlDatabase -InputObject $AutoscaleDatabase 
  }
  Finally{
      Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName  -Name $ContainerName
      Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName2  -Name $ContainerName2
      Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName2
  }
}

<#
.SYNOPSIS
Test SQL migrate throughput cmdlets 
#>
function Test-SqlMigrateThroughputCmdlets
{
  $AccountName = "cosmosdb9921232812"
  $rgName = "rgtest9921232812"
  $DatabaseName = "dbName4"
  $ContainerName = "containerName"

  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"

  $ThroughputValue = 1200

  $ContainerThroughputValue = 800

  $Autoscale = "Autoscale"
  $Manual = "Manual"

  Try{
      $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
      $Throughput = Get-AzCosmosDBSqlDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue
      Assert-AreEqual $Throughput.AutoscaleSettings.MaxThroughput 0

      $AutoscaleThroughput = Migrate-AzCosmosDBSqlDatabaseThroughput -InputObject $NewDatabase -ThroughputType $Autoscale
      Assert-AreNotEqual $UpdatedThroughput.AutoscaleSettings.MaxThroughput 0

      $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName #get parent object
      $ManualThroughput = Migrate-AzCosmosDBSqlDatabaseThroughput -ParentObject $CosmosDBAccount -Name $DatabaseName -ThroughputType $Manual
      Assert-AreEqual $ManualThroughput.AutoscaleSettings.MaxThroughput 0

      $NewContainer =  New-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Throughput  $ContainerThroughputValue -Name $ContainerName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      $ContainerThroughput = Get-AzCosmosDBSqlContainerThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Assert-AreEqual $ContainerThroughput.Throughput $ContainerThroughputValue

      $AutoscaledContainerThroughput = Migrate-AzCosmosDBSqlContainerThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -ThroughputType $Autoscale
      Assert-AreNotEqual $UpdatedContainerThroughput.AutoscaleSettings.MaxThroughput 0

      $ManualContainerThroughput = Migrate-AzCosmosDBSqlContainerThroughput  -InputObject $NewContainer -ThroughputType $Manual
      Assert-AreEqual $UpdatedContainerThroughput.AutoscaleSettings.MaxThroughput 0

      Remove-AzCosmosDBSqlContainer -InputObject $NewContainer 
      Remove-AzCosmosDBSqlDatabase -InputObject $NewDatabase
  }
  Finally{
      Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName  -Name $ContainerName
      Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}