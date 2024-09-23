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
  $AccountName = "dbaccount60-1"
  $rgName = "CosmosDBResourceGroup60"
  $DatabaseName = "dbName"
  $ContainerName = "container1"
  $StoredProcedureName = "storedProcedure"
  $UDFName = "udf"
  $TriggerName = "trigger"
  $location = "East US"
  $DatabaseName2 = "dbName2"
  $ContainerName2 = "container2"
  $StoredProcedureName2 = "storedProcedure2"
  $UDFName2 = "udf2"
  $TriggerName2 = "trigger2"
  $apiKind = "Sql"
  $consistencyLevel = "BoundedStaleness"
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
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

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

function Test-SqlInAccountRestoreOperationsCmdlets
{
  $AccountName = "dbaccount60-5"
  $rgName = "CosmosDBResourceGroup65"
  $DatabaseName = "sqldbName5"
  $ContainerName = "container1"
  $location = "West US"
  $DatabaseName2 = "dbName2"
  $ContainerName2 = "container2"
  $apiKind = "Sql"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"

  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0
  $locations += New-AzCosmosDBLocationObject -LocationName "Central US" -FailoverPriority 1 -IsZoneRedundant 0

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -BackupPolicyType Continuous

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

      # get a database
      $Database = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # get a container
      $Container = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Assert-AreEqual $NewContainer.Id $Container.Id
      Assert-AreEqual $NewContainer.Name $Container.Name

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

      $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')
      # list containers
      $ListContainers = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListContainers)

      # list databases
      $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      Start-TestSleep -s 50

      # remove container
      Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

      Start-TestSleep -s 50

      # restore deleted container
      Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -RestoreTimestampInUtc $restoreTimestampInUtc

      #remove region
      $locationObject2 = @()
      $locationObject2 += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0
      Update-AzCosmosDBAccountRegion -ResourceGroupName $rgName -Name $AccountName -LocationObject $locationObject2

      # remove database
      Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

      Start-TestSleep -s 100

      #Restore collection when database is deleted
      Try {
          $RestoredCollection = Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -RestoreTimestampInUtc $restoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("Could not find the database") true
      }

      $invalidRestoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')
      #Restore database with invalid timestamp
      Try {
          $RestoredDatabase = Restore-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $invalidRestoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("No databases or collections found in the source account at the restore timestamp provided") true
      }

      #add region
      $locationObject3 = @()
      $locationObject3 += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0
      $locationObject3 += New-AzCosmosDBLocationObject -LocationName "Central US" -FailoverPriority 1 -IsZoneRedundant 0
      Update-AzCosmosDBAccountRegion -ResourceGroupName $rgName -Name $AccountName -LocationObject $locationObject3

      # restore deleted database
      Restore-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 50

      # restore deleted container
      Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -RestoreTimestampInUtc $restoreTimestampInUtc

      # list containers
      $ListContainers = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListContainers)

      # list databases
      $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)
  }
  Finally {
    Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
    Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
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
function Test-SqlInAccountCoreFunctionalityNoTimestampBasedRestoreCmdletsV2
{
    $AccountName = "dbaccount49-sql-ntbr"
    $rgName = "CosmosDBResourceGroup63"
    $DatabaseName = "sqldbName6"
    $ContainerName = "container1"
    $location = "West US"
    $DatabaseName2 = "dbName2"
    $ContainerName2 = "container2"
    $apiKind = "Sql"
    $PartitionKeyPathValue = "/foo/bar"
    $PartitionKeyKindValue = "Hash"

    $locations = @()
    $locations += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0
    $locations += New-AzCosmosDBLocationObject -LocationName "Central US" -FailoverPriority 1 -IsZoneRedundant 0

    Try {
        $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
        $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -BackupPolicyType Continuous

        # 1. Create a new database
        $NewDatabase = New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-AreEqual $NewDatabase.Name $DatabaseName

        # 2. Create a new container
        $NewContainer = New-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600
        Assert-AreEqual $NewContainer.Name $ContainerName

        # 3. Get a database
        $Database = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-AreEqual $NewDatabase.Id $Database.Id
        Assert-AreEqual $NewDatabase.Name $Database.Name
        Assert-NotNull($Database)

        # 4. Get a container
        $Container = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Assert-AreEqual $NewContainer.Id $Container.Id
        Assert-AreEqual $NewContainer.Name $Container.Name
        Assert-NotNull($Container)

        Start-TestSleep -s 50

        # 5. Remove container
        Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

        Start-TestSleep -s 50

        # 6. Restore non-existent container - expect failure
        $InvalidContainerName = "Invalid-Container459"
        $RestoreInvalidContainerResult = Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $InvalidContainerName
        Assert-Null $RestoreInvalidContainerResult

        # 7. Restore deleted container in #5
        Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

        Start-TestSleep -s 50

        # list containers
        $ListContainers = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
        Assert-NotNull($ListContainers)

        # 8. Delete database
        Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 100

        # list databases
        $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-Null($ListDatabases)

        # 9. Restore container - expect failure (database is offline)
        $RestoreContainerWhenDatabaseOfflineResult = Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Assert-Null $RestoreContainerWhenDatabaseOfflineResult

        # 10. Restore deleted database
        Restore-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 50

        # list databases
        $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-NotNull($ListDatabases)

        Start-TestSleep -s 50

        # 11. Restore collection
        $RestoredCollection = Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

        Start-TestSleep -s 50

        # list containers
        $ListContainers = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
        Assert-NotNull($ListContainers)

        # 12. Restore container again - expect failure (collection already online)
        $SecondInAccountContainerRestore = Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Assert-Null $SecondInAccountContainerRestore

        # 13. Delete database
        Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 100
        # list databases
        $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-Null($ListDatabases)

        # 14. Restore non-existent database - expect failure
        $InvalidDatabaseName = "InvalidDatabaseName"
        $RestoreInvalidDatabase = Restore-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $InvalidDatabaseName
        Assert-Null $RestoreInvalidDatabase


        # 15. Restore database
        Restore-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 50

        # list databases
        $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
        Assert-NotNull($ListDatabases)

        # 16. Restore database again - expect failure (database already exists)
        $SecondInAccountDatabaseRestore = Restore-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-Null $SecondInAccountDatabaseRestore

        # 17. Restore collection
        $RestoredCollection = Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Start-TestSleep -s 50
        Assert-NotNull $RestoredCollection

        # list containers
        $ListContainers = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
        Assert-NotNull $ListContainers
  }
  Catch {
        Write-Output "Error: $_"
        throw $_
  }
  Finally {
        Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
        Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

function Test-SqlInAccountRestoreOperationsNoTimestampCmdlets
{
  $AccountName = "dbaccount60-14"
  $rgName = "CosmosDBResourceGroup63"
  $DatabaseName = "sqldbName6"
  $ContainerName = "container1"
  $location = "West US"
  $DatabaseName2 = "dbName2"
  $ContainerName2 = "container2"
  $apiKind = "Sql"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"

  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0
  $locations += New-AzCosmosDBLocationObject -LocationName "Central US" -FailoverPriority 1 -IsZoneRedundant 0

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -BackupPolicyType Continuous

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

      # get a database
      $Database = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # get a container
      $Container = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Assert-AreEqual $NewContainer.Id $Container.Id
      Assert-AreEqual $NewContainer.Name $Container.Name

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

      $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')
      # list containers
      $ListContainers = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListContainers)

      # list databases
      $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      Start-TestSleep -s 50

      # remove container
      Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

      Start-TestSleep -s 50

      # restore deleted container
      Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

      Start-TestSleep -s 100

      # remove database
      Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

      Start-TestSleep -s 100

      
      # restore deleted database
      Restore-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

      Start-TestSleep -s 50

      #Restore collection with no timestamp after database restore
      Try {
          $RestoredCollection = Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("No container with name") true
      }

      # list databases
      $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)
  }
  Finally {
    Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
    Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

function Test-SqlInAccountRestoreOperationsSharedResourcesCmdlets
{
  $AccountName = "dbaccount60-4"
  $rgName = "CosmosDBResourceGroup62"
  $DatabaseName = "sqldbName"
  $ContainerName = "container1"
  $location = "West US"
  $apiKind = "Sql"
  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $ThroughputValue = 500
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0
  #$locations += New-AzCosmosDBLocationObject -LocationName "East US 2 EUAP" -FailoverPriority 1 -IsZoneRedundant 0

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -BackupPolicyType Continuous

      # create a new database
      $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput $ThroughputValue
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create an existing keyspace
      Try {
          $NewDuplicateDatabase = New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $DatabaseName + " already exists.")
      }

      # create a new container
      $NewContainer = New-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      Assert-AreEqual $NewContainer.Name $ContainerName

      # create an existing container
      Try {
            $NewDuplicateContainer = New-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput $ThroughputValue
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $ContainerName + " already exists.")
      }

      # get a database
      $Database = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Id $Database.Id
      Assert-AreEqual $NewDatabase.Name $Database.Name

      # get a container
      $Container = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Assert-AreEqual $NewContainer.Id $Container.Id
      Assert-AreEqual $NewContainer.Name $Container.Name

      # update database
      $UpdatedDatabase =  Update-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $UpdatedDatabase.Name $DatabaseName

      # update container
      $UpdatedContainer = Update-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Assert-AreEqual $UpdatedContainer.Name $ContainerName

      $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')
      # list containers
      $ListContainers = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListContainers)

      # list databases
      $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)

      Start-TestSleep -s 50

      # remove container
      Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName

      Start-TestSleep -s 50

      # restore deleted container
      Try {
      Restore-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -RestoreTimestampInUtc $restoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("InAccount restore of individual shared database collections is not supported. Please restore shared database to restore its collections that shared the throughput.") true
      }
      # remove database
      Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

      Start-TestSleep -s 100

      $invalidRestoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')
      #Restore database with invalid timestamp
      Try {
          $RestoredDatabase = Restore-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $invalidRestoreTimestampInUtc
      }
      Catch {
          Assert-AreEqual $_.Exception.Message.Contains("No databases or collections found in the source account at the restore timestamp provided") true
      }

      # restore deleted database
      Restore-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 50

      # list containers
      $ListContainers = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListContainers)

      # list databases
      $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListDatabases)
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
  $AccountName = "dbaccount61-1"
  $rgName = "CosmosDBResourceGroup61"
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
  $location = "East US"
  $apiKind = "Sql"
  $consistencyLevel = "BoundedStaleness"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

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
  $AccountName = "dbaccount62-1"
  $rgName = "CosmosDBResourceGroup62"
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
  $location = "East US"
  $apiKind = "Sql"
  $consistencyLevel = "BoundedStaleness"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

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
  $AccountName = "dbaccount62-1"
  $rgName = "CosmosDBResourceGroup62"
  $DatabaseName = "dbName4"
  $ContainerName = "containerName"
  $location = "East US"
  $apiKind = "Sql"
  $consistencyLevel = "BoundedStaleness"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"

  $ThroughputValue = 1200

  $ContainerThroughputValue = 800

  $Autoscale = "Autoscale"
  $Manual = "Manual"

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

      $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName -Throughput  $ThroughputValue
      $Throughput = Get-AzCosmosDBSqlDatabaseThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue
      Assert-AreEqual $Throughput.AutoscaleSettings.MaxThroughput 0

      $AutoscaleThroughput = Invoke-AzCosmosDBSqlDatabaseThroughputMigration -InputObject $NewDatabase -ThroughputType $Autoscale
      Assert-AreNotEqual $AutoscaleThroughput.AutoscaleSettings.MaxThroughput 0

      $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName #get parent object
      $ManualThroughput = Invoke-AzCosmosDBSqlDatabaseThroughputMigration -ParentObject $CosmosDBAccount -Name $DatabaseName -ThroughputType $Manual
      Assert-AreEqual $ManualThroughput.AutoscaleSettings.MaxThroughput 0

      $NewContainer =  New-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Throughput  $ContainerThroughputValue -Name $ContainerName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
      $ContainerThroughput = Get-AzCosmosDBSqlContainerThroughput -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
      Assert-AreEqual $ContainerThroughput.Throughput $ContainerThroughputValue

      $AutoscaledContainerThroughput = Invoke-AzCosmosDBSqlContainerThroughputMigration -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -ThroughputType $Autoscale
      Assert-AreNotEqual $AutoscaledContainerThroughput.AutoscaleSettings.MaxThroughput 0

      $ManualContainerThroughput = Invoke-AzCosmosDBSqlContainerThroughputMigration  -InputObject $NewContainer -ThroughputType $Manual
      Assert-AreEqual $ManualContainerThroughput.AutoscaleSettings.MaxThroughput 0

      Remove-AzCosmosDBSqlContainer -InputObject $NewContainer
      Remove-AzCosmosDBSqlDatabase -InputObject $NewDatabase
  }
  Finally{
      Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName  -Name $ContainerName
      Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test SQL Roles cmdlets using all parameter sets
#>
function Test-SqlRoleCmdlets
{
  $AccountName = "rbactestps73"
  $rgName = "rgtest9921232873"
  $location = "East US"
  $subscriptionId = $(getVariable "SubscriptionId")

  $apiKind = "Sql"
  $consistencyLevel = "BoundedStaleness"
  $maxStalenessInterval = 300
  $maxStalenessPrefix = 100000
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East US" -FailoverPriority 0 -IsZoneRedundant 0
  
  $DatabaseName = "dbName"

  $RoleName = "roleDefinitionName"
  $RoleName2 = "roleDefinitionName2"
  $RoleName3 = "roleDefinitionName3"
  $RoleName4 = "roleDefinitionName4"
  $RoleName5 = "roleDefinitionName5"
  $RoleName6 = "roleDefinitionName6"

  $DataActionRead = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/read"
  $DataActionCreate = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/create"
  $DataActionReplace = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/replace"
  $DataActionInvalid = "Microsoft.DocumentDB/databaseAccounts/sqlDatabases/containers/items/invalid-action"

  $PrincipalId = "d006e945-a621-4973-8113-b0a705061e33"
  $PrincipalId2 = "5af9fd41-fffc-4c7a-9fd8-bed87ae38ac3"

  $Scope = "/"
  $FullyQualifiedScope = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName"
  $Scope2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/dbs/dbName"

  $RoleAssignmentId = "a2ccaf94-3c39-4728-b892-95edeef0e754"
  $FullyQualifiedRoleAssignmentId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/sqlRoleAssignments/a2ccaf94-3c39-4728-b892-95edeef0e754"
  $RoleAssignmentId2 = "8f3f78c4-a8df-4088-9cbb-a3947e27076b"
  $FullyQualifiedRoleAssignmentId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/sqlRoleAssignments/8f3f78c4-a8df-4088-9cbb-a3947e27076b"
  $RoleAssignmentId3 = "e7a0b8a5-b381-495d-a020-5467c534e619"
  $FullyQualifiedRoleAssignmentId3 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/sqlRoleAssignments/e7a0b8a5-b381-495d-a020-5467c534e619"

  $RoleDefinitionId = "cf31c3a1-20f5-4ff1-bdd0-5e0782617e22"
  $FullyQualifiedRoleDefinitionId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/sqlRoleDefinitions/cf31c3a1-20f5-4ff1-bdd0-5e0782617e22"
  $RoleDefinitionId2 = "a36e56a5-9afc-4819-aa78-3a8083a3ee74"
  $FullyQualifiedRoleDefinitionId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/sqlRoleDefinitions/a36e56a5-9afc-4819-aa78-3a8083a3ee74"
  $RoleDefinitionId3 = "9ee200b5-73fd-4779-b36a-e2a31f9244f3"
  $FullyQualifiedRoleDefinitionId3 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/sqlRoleDefinitions/9ee200b5-73fd-4779-b36a-e2a31f9244f3"
  $location = "East US"
  $apiKind = "Sql"
  $consistencyLevel = "BoundedStaleness"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel
      $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

      $DatabaseAccount = Get-AzCosmosDBAccount -Name $AccountName -ResourceGroupName $rgName

      # create a new role definition - using parent object and permission
      $Permissions = New-AzCosmosDBPermission -DataAction $DataActionRead
      $NewRoleDefinitionFromParentObject = New-AzCosmosDBSqlRoleDefinition -Type "CustomRole" -RoleName $RoleName -Permission $Permissions -AssignableScope $Scope -Id $RoleDefinitionId -ParentObject $DatabaseAccount
      Assert-AreEqual $NewRoleDefinitionFromParentObject.RoleName $RoleName
      Assert-AreEqual $NewRoleDefinitionFromParentObject.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromParentObject.Id $FullyQualifiedRoleDefinitionId
      Assert-NotNull $NewRoleDefinitionFromParentObject.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromParentObject.Permissions

      # create a new role definition - using fields and data actions
      $NewRoleDefinitionFromFields = New-AzCosmosDBSqlRoleDefinition -Type "CustomRole" -RoleName $RoleName2 -DataAction $DataActionCreate -AssignableScope $Scope2 -Id $FullyQualifiedRoleDefinitionId2 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleDefinitionFromFields.RoleName $RoleName2
      Assert-AreEqual $NewRoleDefinitionFromFields.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromFields.Id $FullyQualifiedRoleDefinitionId2
      Assert-NotNull $NewRoleDefinitionFromFields.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromFields.Permissions

      # create a new role assignment from name
      $NewRoleAssignmentFromName = New-AzCosmosDBSqlRoleAssignment -RoleDefinitionName $RoleName -Scope $Scope2 -PrincipalId $PrincipalId -Id $RoleAssignmentId -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleAssignmentFromName.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $NewRoleAssignmentFromName.Scope $Scope2
      Assert-AreEqual $NewRoleAssignmentFromName.PrincipalId $PrincipalId
      Assert-AreEqual $NewRoleAssignmentFromName.Id $FullyQualifiedRoleAssignmentId

      # create a new role assignment from parent object
      $NewRoleAssignmentFromParentObject = New-AzCosmosDBSqlRoleAssignment -ParentObject $NewRoleDefinitionFromFields -Scope $Scope2 -PrincipalId $PrincipalId2 -Id $FullyQualifiedRoleAssignmentId2
      Assert-AreEqual $NewRoleAssignmentFromParentObject.RoleDefinitionId $FullyQualifiedRoleDefinitionId2
      Assert-AreEqual $NewRoleAssignmentFromParentObject.Scope $Scope2
      Assert-AreEqual $NewRoleAssignmentFromParentObject.PrincipalId $PrincipalId2
      Assert-AreEqual $NewRoleAssignmentFromParentObject.Id $FullyQualifiedRoleAssignmentId2

      # create a new role assignment from Id
      $NewRoleAssignmentFromId = New-AzCosmosDBSqlRoleAssignment -RoleDefinitionId $RoleDefinitionId -Scope $Scope -PrincipalId $PrincipalId -AccountName $AccountName -ResourceGroupName $rgName -Id $FullyQualifiedRoleAssignmentId3
      Assert-AreEqual $NewRoleAssignmentFromId.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $NewRoleAssignmentFromId.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromId.PrincipalId $PrincipalId
      Assert-NotNull $NewRoleAssignmentFromId.Id

      # update non-existing role definition, role assignment
      Try {
          $UpdatedRoleDefinition = Update-AzCosmosDBSqlRoleDefinition -Type "CustomRole" -RoleName "RoleName3" -DataAction $DataActionCreate -AssignableScope $Scope2 -Id "00000000-0000-0000-0000-000000000000" -AccountName $AccountName -ResourceGroupName $rgName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Role Definition with Id [00000000-0000-0000-0000-000000000000] does not exist.")
      }
      Try {
          $UpdatedRoleAssignment = Update-AzCosmosDBSqlRoleAssignment -RoleDefinitionName "RoleName4" -Id "11111111-1111-1111-1111-111111111111" -AccountName $AccountName -ResourceGroupName $rgName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Role Assignment with Name [RoleName4] does not exist.")
      }

      # get a role definition
      $RoleDefinition = Get-AzCosmosDBSqlRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId
      Assert-AreEqual $RoleDefinition.RoleName $RoleName
      Assert-AreEqual $RoleDefinition.Type "CustomRole"
      Assert-NotNull $RoleDefinition.AssignableScopes
      Assert-NotNull $RoleDefinition.Permissions

      # get a role assignment
      $RoleAssignment = Get-AzCosmosDBSqlRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $FullyQualifiedRoleAssignmentId
      Assert-AreEqual $RoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $RoleAssignment.Scope $Scope2
      Assert-AreEqual $RoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $RoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role definition by parent object and data actions
      $UpdatedRoleDefinition = Update-AzCosmosDBSqlRoleDefinition -Type "CustomRole" -RoleName $RoleName3 -DataAction $DataActionReplace -AssignableScope $Scope2 -Id $RoleDefinitionId -ParentObject $DatabaseAccount
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName3
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions

      #update role definition by input object
      $UpdatedRoleDefinition.RoleName = $RoleName4
      $UpdatedRoleDefinition = Update-AzCosmosDBSqlRoleDefinition -InputObject $UpdatedRoleDefinition
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName4
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions

      # update role definition by fields and permissions
      $UpdatedRoleDefinition = Update-AzCosmosDBSqlRoleDefinition -Type "CustomRole" -RoleName $RoleName5 -Permission $Permissions -AssignableScope $Scope -AccountName $AccountName -ResourceGroupName $rgName -Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName5
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions

      # update role assignment by role definition name
      $UpdatedRoleAssignment = Update-AzCosmosDBSqlRoleAssignment -RoleDefinitionName $RoleName2 -Id $RoleAssignmentId -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId2
      Assert-AreEqual $UpdatedRoleAssignment.Scope $Scope2
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by parent object
      $UpdatedRoleAssignment = Update-AzCosmosDBSqlRoleAssignment -Id $RoleAssignmentId -ParentObject $UpdatedRoleDefinition
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleAssignment.Scope $Scope2
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by role definition id
      $UpdatedRoleAssignment = Update-AzCosmosDBSqlRoleAssignment -RoleDefinitionId $RoleDefinitionId -Id $FullyQualifiedRoleAssignmentId2 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleAssignment.Scope $Scope2
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId2
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId2

      # update role assignmnent by input object
      $UpdatedRoleAssignment.RoleDefinitionId = $FullyQualifiedRoleDefinitionId2

      $UpdatedRoleAssignment = Update-AzCosmosDBSqlRoleAssignment -InputObject $UpdatedRoleAssignment
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId2
      Assert-AreEqual $UpdatedRoleAssignment.Scope $Scope2
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId2
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId2

      # list Role Definitions
      $ListRoleDefinitions = Get-AzCosmosDBSqlRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull $ListRoleDefinitions

      # list Role Assignments
      $ListRoleAssignments = Get-AzCosmosDBSqlRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull $ListRoleAssignments

      # check for correct error propagation
      $PermissionsInvalid = New-AzCosmosDBPermission -DataAction $DataActionInvalid
      $ScriptBlockRoleDef = { New-AzCosmosDBSqlRoleDefinition -Type "CustomRole" -RoleName $RoleName6 -Permission $PermissionsInvalid -AssignableScope $Scope -Id $RoleDefinitionId3 -ParentObject $DatabaseAccount }
      Assert-ThrowsContains $ScriptBlockRoleDef $DataActionInvalid
  }
  Finally
  {
      Remove-AzCosmosDBSqlRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Remove-AzCosmosDBSqlRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $FullyQualifiedRoleAssignmentId2
      $DatabaseAccount = Get-AzCosmosDBAccount -Name $AccountName -ResourceGroupName $rgName
      Remove-AzCosmosDBSqlRoleAssignment -ParentObject $DatabaseAccount -Id $FullyQualifiedRoleAssignmentId3

      Remove-AzCosmosDBSqlRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $FullyQualifiedRoleDefinitionId
      Remove-AzCosmosDBSqlRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId2
      Remove-AzCosmosDBSqlRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId3
  }
}

<#
.SYNOPSIS
Get service principal id
#>
function Get-PrincipalObjectId{
	return [Microsoft.Azure.Commands.CosmosDB.Test.ScenarioTests.ScenarioTest.CosmosDBTestHelper]::GetServicePrincipalObjectId()
}
<#
.SYNOPSIS
Add key to vault.
#>
function Create-KeyIdentity{
	param(
		[string] $resourceGroupName="CosmosDBResourceGroup60",
		[string] $vaultName="cosmosdb-ae-keyvault",
		[string] $keyName="key-cosmosdb-ae-ps-test"
		)
	$vault = [Microsoft.Azure.Commands.CosmosDB.Test.ScenarioTests.ScenarioTest.CosmosDBTestHelper]::GetAzureKeyVault($resourceGroupName,$vaultName)
	$keyIdentity = [Microsoft.Azure.Commands.CosmosDB.Test.ScenarioTests.ScenarioTest.CosmosDBTestHelper]::CreateKeyVaultKey($vault,$keyName)
	return $keyIdentity
}

<#
.SYNOPSIS
Test Client Encryption Key operations using Name parameter set
#>
function Test-ClientEncryptionKeyCmdlets
{
  $AccountName = "clientencryptiondbaccount14"
  $rgName = "CosmosDBRgClientEncryption60-14"
  $DatabaseName = "dbNameCdbAE"
  $ClientEncryptionKeyName = "cek1"
  $EncryptionAlgorithm = "AEAD_AES_256_CBC_HMAC_SHA256"
  $EncryptionType_1 = "Deterministic" 
  $EncryptionType_2 = "Randomized"
  $keywrapmetadataName = "cmk1v1"
  $keywrapmetadataName2 = "cmk1v2"
  $keywrapmetadataType = "AZURE_KEY_VAULT"
  $keywrapmetadataAlgo = "RSA-OAEP"
  $vaultName="CosmosDBAeAkv60"
  $location = "East US"
  $apiKind = "Sql"
  $consistencyLevel = "BoundedStaleness"
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
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{ 
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location  $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

      # new user-assigned identity
      $objectId = Get-PrincipalObjectId

      # create a keyvault, delete/purge first
      try
      {
       Remove-AzKeyVault -VaultName $vaultName -InRemovedState -Force -Location $location
      }
      catch{}

      $encryptionKeyVault=New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $location

      # add access police for key-vault
      $encryptionKeyVault= Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ObjectId $objectId -PermissionsToKeys create,Get,UnwrapKey,WrapKey,sign -BypassObjectIdValidation
      
      # new key identity
      $encryptionKey= Create-KeyIdentity -resourceGroupName $rgName -vaultName $vaultName -keyName $keywrapmetadataName
      $encryptionVaultUri=$encryptionKey.Vault
      $encryptionKeyVersion=$encryptionKey.Version
      $encryptionKeyName=$encryptionKey.Name

      # create a new database
      $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create KeyWrapMetadata object.
      $NewKeyWrapMetaDataObject = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata]::new([Microsoft.Azure.Management.CosmosDB.Models.KeyWrapMetadata]::new($keywrapmetadataName,$keywrapmetadataType,$encryptionKey,$keywrapmetadataAlgo))
      
      # Test1 - create a new client encryption key
      $NewClientEncryptionKey = New-AzCosmosDbClientEncryptionKey -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ClientEncryptionKeyName $ClientEncryptionKeyName -EncryptionAlgorithmName "AEAD_AES_256_CBC_HMAC_SHA256" -KeyWrapMetadata $NewKeyWrapMetaDataObject      

      Assert-AreEqual $NewClientEncryptionKey.Resource.id $ClientEncryptionKeyName
      Assert-AreEqual $NewClientEncryptionKey.Resource.encryptionAlgorithm $EncryptionAlgorithm
      Assert-AreEqual $NewClientEncryptionKey.Resource.keyWrapMetadata.name $encryptionKeyName
      Assert-AreEqual $NewClientEncryptionKey.Resource.keyWrapMetadata.type $keywrapmetadataType
      Assert-AreEqual $NewClientEncryptionKey.Resource.keyWrapMetadata.value $encryptionKey
      Assert-AreEqual $NewClientEncryptionKey.Resource.keyWrapMetadata.algorithm $keywrapmetadataAlgo

      # Test2 - fetch/list client encryption keys.
      $ListClientEncryptionKeys = Get-AzCosmosDbClientEncryptionKey -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
      Assert-NotNull($ListClientEncryptionKeys)

      # Test3 - fetch a specific client encryption key.
      $FetchedClientEncryptionKey = Get-AzCosmosDbClientEncryptionKey -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ClientEncryptionKeyName $ClientEncryptionKeyName
      Assert-AreEqual $FetchedClientEncryptionKey.Resource.id $ClientEncryptionKeyName

      # new key identity
      $encryptionKey2 = Create-KeyIdentity -resourceGroupName $rgName -vaultName $vaultName -keyName $keywrapmetadataName2
      $encryptionVaultUri2=$encryptionKey.Vault
      $encryptionKeyVersion2=$encryptionKey.Version
      $encryptionKeyName2=$encryptionKey.Name

      # create updated KeyWrapMetadata object.
      $UpdatedKeyWrapMetaDataObject = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata]::new([Microsoft.Azure.Management.CosmosDB.Models.KeyWrapMetadata]::new($keywrapmetadataName2,$keywrapmetadataType,$encryptionKey2,$keywrapmetadataAlgo))

      # Test4 - update client encryption key
      $UpdatedClientEncryptionKey = Update-AzCosmosDbClientEncryptionKey -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ClientEncryptionKeyName $ClientEncryptionKeyName -KeyWrapMetadata $UpdatedKeyWrapMetaDataObject      
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.id $ClientEncryptionKeyName
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.encryptionAlgorithm $EncryptionAlgorithm
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.keyWrapMetadata.name $keywrapmetadataName2
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.keyWrapMetadata.type $keywrapmetadataType
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.keyWrapMetadata.value $encryptionKey2
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.keyWrapMetadata.algorithm $keywrapmetadataAlgo

      #Test - validate client encryption policy creation.
      $includedPath_1 = [Microsoft.Azure.Management.CosmosDB.Models.ClientEncryptionIncludedPath]::new("/path1",$ClientEncryptionKeyName,$EncryptionType_1,$EncryptionAlgorithm);
      $includedPath_2 = [Microsoft.Azure.Management.CosmosDB.Models.ClientEncryptionIncludedPath]::new("/path2",$ClientEncryptionKeyName,$EncryptionType_2,$EncryptionAlgorithm);
      $listofIncludedPaths = New-Object Collections.Generic.List[Microsoft.Azure.Management.CosmosDB.Models.ClientEncryptionIncludedPath]
      $listofIncludedPaths.Add($includedPath_1)
      $listofIncludedPaths.Add($includedPath_2)
      $newClientEncryptionPolicy = New-Object Microsoft.Azure.Management.CosmosDB.Models.ClientEncryptionPolicy
      $newClientEncryptionPolicy.IncludedPaths = $listofIncludedPaths
      #verify the default policy version 1 is picked up
      $newClientEncryptionPolicy.PolicyFormatVersion = 187
      $newPSSqlClientEncryptionPolicy = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlClientEncryptionPolicy]::new($newClientEncryptionPolicy)

      $ContainerWithEncryptionPolicy = "containerWithEncryptionPolicy"
      #create a container with the above policy
      New-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName  -Name $ContainerWithEncryptionPolicy -PartitionKeyPath "/pk" -PartitionKeyKind Hash -ClientEncryptionPolicy $newPSSqlClientEncryptionPolicy

      $ContainerWithEncryptionPolicy = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName  -Name $ContainerWithEncryptionPolicy

      Assert-AreEqual $ContainerWithEncryptionPolicy.Resource.ClientEncryptionPolicy.IncludedPaths[0].Path "/path1"
      Assert-AreEqual $ContainerWithEncryptionPolicy.Resource.ClientEncryptionPolicy.IncludedPaths[0].ClientEncryptionKeyId $ClientEncryptionKeyName
      Assert-AreEqual $ContainerWithEncryptionPolicy.Resource.ClientEncryptionPolicy.IncludedPaths[0].EncryptionAlgorithm $EncryptionAlgorithm
      Assert-AreEqual $ContainerWithEncryptionPolicy.Resource.ClientEncryptionPolicy.IncludedPaths[0].EncryptionType $EncryptionType_1
      Assert-AreEqual $ContainerWithEncryptionPolicy.Resource.ClientEncryptionPolicy.PolicyFormatVersion 1

      Assert-AreEqual $ContainerWithEncryptionPolicy.Resource.ClientEncryptionPolicy.IncludedPaths[1].Path "/path2"
      Assert-AreEqual $ContainerWithEncryptionPolicy.Resource.ClientEncryptionPolicy.IncludedPaths[1].ClientEncryptionKeyId $ClientEncryptionKeyName
      Assert-AreEqual $ContainerWithEncryptionPolicy.Resource.ClientEncryptionPolicy.IncludedPaths[1].EncryptionAlgorithm $EncryptionAlgorithm
      Assert-AreEqual $ContainerWithEncryptionPolicy.Resource.ClientEncryptionPolicy.IncludedPaths[1].EncryptionType $EncryptionType_2
      Assert-AreEqual $ContainerWithEncryptionPolicy.Resource.ClientEncryptionPolicy.PolicyFormatVersion 1

      #validate update container works on container with encryption policy.
      updateContainerTtl = Update-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -TtlInSeconds 7200
      Assert-AreEqual updateContainerTtl.Resource.DefaultTtl 7200
  }
  Finally {
    Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
    Remove-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $location -Force
    Remove-AzKeyVault -VaultName $vaultName -InRemovedState -Force -Location $location
  }
 }

  <#
.SYNOPSIS
Test Client Encryption Key operations using Name parameter set
#>
function Test-ClientEncryptionKeyCmdletsUsingInputObject
{
  $AccountName = "clientencryptiondbaccount19"
  $rgName = "CosmosDBRgClientEncryption60-19"
  $DatabaseName = "dbNameCdbAE"
  $ClientEncryptionKeyName = "cek1"
  $EncryptionAlgorithm = "AEAD_AES_256_CBC_HMAC_SHA256"
  $keywrapmetadataName = "cmk1v1"
  $keywrapmetadataName2 = "cmk1v2"
  $keywrapmetadataName3 = "cmk1v3"
  $keywrapmetadataType = "AZURE_KEY_VAULT"
  $keywrapmetadataAlgo = "RSA-OAEP"
  $vaultName="CosmosDBAeAkv60"
  $location = "East US"
  $apiKind = "Sql"
  $consistencyLevel = "BoundedStaleness"
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
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{ 
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location  $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

      # new user-assigned identity
      $objectId = Get-PrincipalObjectId

      # create a keyvault, delete/purge first
      try
      {
       Remove-AzKeyVault -VaultName $vaultName -InRemovedState -Force -Location $location
      }
      catch{}
      $encryptionKeyVault=New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $location

      # add access police for key-vault
      $encryptionKeyVault= Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ObjectId $objectId -PermissionsToKeys create,Get,UnwrapKey,WrapKey,sign -BypassObjectIdValidation      
      
      # new key identity
      $encryptionKey= Create-KeyIdentity -resourceGroupName $rgName -vaultName $vaultName -keyName $keywrapmetadataName
      $encryptionVaultUri=$encryptionKey.Vault
      $encryptionKeyVersion=$encryptionKey.Version
      $encryptionKeyName=$encryptionKey.Name

      # create a new database
      $NewDatabase =  New-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
      Assert-AreEqual $NewDatabase.Name $DatabaseName

      # create KeyWrapMetadata object.
      $NewKeyWrapMetaDataObject = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata]::new([Microsoft.Azure.Management.CosmosDB.Models.KeyWrapMetadata]::new($keywrapmetadataName,$keywrapmetadataType,$encryptionKey,$keywrapmetadataAlgo))
      
      # Test1 - create a new client encryption key pass Parent object/Database object
      $NewClientEncryptionKey = New-AzCosmosDbClientEncryptionKey -SqlDatabaseObject $NewDatabase -ClientEncryptionKeyName $ClientEncryptionKeyName -EncryptionAlgorithmName "AEAD_AES_256_CBC_HMAC_SHA256" -KeyWrapMetadata $NewKeyWrapMetaDataObject      

      Assert-AreEqual $NewClientEncryptionKey.Resource.id $ClientEncryptionKeyName
      Assert-AreEqual $NewClientEncryptionKey.Resource.encryptionAlgorithm $EncryptionAlgorithm
      Assert-AreEqual $NewClientEncryptionKey.Resource.keyWrapMetadata.name $encryptionKeyName
      Assert-AreEqual $NewClientEncryptionKey.Resource.keyWrapMetadata.type $keywrapmetadataType
      Assert-AreEqual $NewClientEncryptionKey.Resource.keyWrapMetadata.value $encryptionKey
      Assert-AreEqual $NewClientEncryptionKey.Resource.keyWrapMetadata.algorithm $keywrapmetadataAlgo

      # Test2 - fetch/list client encryption keys, pass Parent object/Database object
      $ListClientEncryptionKeys = Get-AzCosmosDbClientEncryptionKey -SqlDatabaseObject $NewDatabase
      Assert-NotNull($ListClientEncryptionKeys)

      # Test3 - fetch a specific client encryption key, pass Parent object/Database object
      $FetchedClientEncryptionKey = Get-AzCosmosDbClientEncryptionKey -SqlDatabaseObject $NewDatabase -ClientEncryptionKeyName $ClientEncryptionKeyName
      Assert-AreEqual $FetchedClientEncryptionKey.Resource.id $ClientEncryptionKeyName

      # new key identity
      $encryptionKey2 = Create-KeyIdentity -resourceGroupName $rgName -vaultName $vaultName -keyName $keywrapmetadataName2
      $encryptionVaultUri2=$encryptionKey.Vault
      $encryptionKeyVersion2=$encryptionKey.Version
      $encryptionKeyName2=$encryptionKey.Name

      # create updated KeyWrapMetadata object.
      $UpdatedKeyWrapMetaDataObject = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata]::new([Microsoft.Azure.Management.CosmosDB.Models.KeyWrapMetadata]::new($keywrapmetadataName2,$keywrapmetadataType,$encryptionKey2,$keywrapmetadataAlgo))

      # Test4 - update client encryption key, pass Parent object/Database object
      $UpdatedClientEncryptionKey = Update-AzCosmosDbClientEncryptionKey -SqlDatabaseObject $NewDatabase -ClientEncryptionKeyName $ClientEncryptionKeyName -KeyWrapMetadata $UpdatedKeyWrapMetaDataObject      
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.id $ClientEncryptionKeyName
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.encryptionAlgorithm $EncryptionAlgorithm
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.keyWrapMetadata.name $keywrapmetadataName2
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.keyWrapMetadata.type $keywrapmetadataType
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.keyWrapMetadata.value $encryptionKey2
      Assert-AreEqual $UpdatedClientEncryptionKey.Resource.keyWrapMetadata.algorithm $keywrapmetadataAlgo

      # Test5 - update client encryption key, pass Input object as key with new WrapMetadata
      $UpdatedKeyWrapMetaDataObject = [Microsoft.Azure.Commands.CosmosDB.Models.PSSqlKeyWrapMetadata]::new([Microsoft.Azure.Management.CosmosDB.Models.KeyWrapMetadata]::new($keywrapmetadataName3,$keywrapmetadataType,$encryptionKey2,$keywrapmetadataAlgo))
      $UpdatedClientEncryptionKey2 = Update-AzCosmosDbClientEncryptionKey -InputObject $UpdatedClientEncryptionKey -KeyWrapMetadata $UpdatedKeyWrapMetaDataObject
      Assert-AreEqual $UpdatedClientEncryptionKey2.Resource.id $ClientEncryptionKeyName
      Assert-AreEqual $UpdatedClientEncryptionKey2.Resource.encryptionAlgorithm $EncryptionAlgorithm
      Assert-AreEqual $UpdatedClientEncryptionKey2.Resource.keyWrapMetadata.name $keywrapmetadataName3
      Assert-AreEqual $UpdatedClientEncryptionKey2.Resource.keyWrapMetadata.type $keywrapmetadataType
      Assert-AreEqual $UpdatedClientEncryptionKey2.Resource.keyWrapMetadata.value $encryptionKey2
      Assert-AreEqual $UpdatedClientEncryptionKey2.Resource.keyWrapMetadata.algorithm $keywrapmetadataAlgo
  }
  Finally {
    Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
    Remove-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $location -Force
    Remove-AzKeyVault -VaultName $vaultName -InRemovedState -Force -Location $location
  }
}