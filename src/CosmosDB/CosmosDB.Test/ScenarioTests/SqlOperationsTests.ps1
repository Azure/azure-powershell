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
Gets and removes custom domain with running endpoint.
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

  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"

  $Body = "function () { var context = getContext(); " +
                        "var response = context.getResponse();" +
                        "response.setBody('Hello, World');" +
                        "}"
  $TriggerOperation = "All"
  $TriggerType = "Pre"

  $NewDatabase =  Set-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Name $DatabaseName

  #Indexing Policy Creation
  $ipath1 = New-AzCosmosDBSqlIncludedPathIndex -DataType String -Precision -1 -Kind Hash
  $ipath2 = New-AzCosmosDBSqlIncludedPathIndex -DataType String -Precision -1 -Kind Hash
  $IncludedPath = New-AzCosmosDBSqlIncludedPath -Path "/*" -Index $ipath1, $ipath2
  $SpatialSpec = New-AzCosmosDBSqlSpatialSpec -Path  "/mySpatialPath/*" -Type  "Point", "LineString", "Polygon", "MultiPolygon"
  $cp1 = New-AzCosmosDBSqlCompositePath -Path "/abc" -Order Ascending
  $cp2 = New-AzCosmosDBSqlCompositePath -Path "/aberc" -Order Descending
  $CompositePaths = (($cp1, $cp2), ($cp2, $cp1))

  $IndexingPolicy = New-AzCosmosDBSqlIndexingPolicy -IncludedPath $IncludedPath -SpatialSpec $SpatialSpec -CompositePath $CompositePaths -ExcludedPath "/myPathToNotIndex/*" -Automatic 1 -IndexingMode Consistent
  
  #UniqueKey Creation
  $p1 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey3"
  $p2 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey4"
  $p3 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey2"
  $p4 = New-AzCosmosDBSqlUniqueKey -Path "/myUniqueKey1"

  $uk1 = New-AzCosmosDBSqlUniqueKeyPolicy -UniqueKey $p1,$p2,$p3,$p4

  $NewContainer = Set-AzCosmosDBSqlContainer  -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName  -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue -Throughput 600 -IndexingPolicy $IndexingPolicy  -UniqueKeyPolicy $uk1
  Assert-AreEqual $NewContainer.Name $ContainerName
  Assert-AreEqual $NewContainer.Resource.IndexingPolicy.Automatic $IndexingPolicy.Automatic
  Assert-AreEqual $NewContainer.Resource.IndexingPolicy.IndexingMode $IndexingPolicy.IndexingMode
  Assert-AreEqual $NewContainer.Resource.IndexingPolicy.IncludedPath.Path $IndexingPolicy.IncludedPath.Path
  Assert-AreEqual $NewContainer.Resource.IndexingPolicy.CompositeIndexes.Count 2
  Assert-AreEqual $NewContainer.Resource.IndexingPolicy.SpatialIndexes.Path $SpatialSpec.Path
  Assert-AreEqual $NewContainer.Resource.UniqueKeyPolicy.UniqueKeys.Count 4

  $NewStoredProcedure = Set-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName -Body $Body
  Assert-AreEqual $NewStoredProcedure.Name $StoredProcedureName

  $NewUDF = Set-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $UDFName -Body $Body
  Assert-AreEqual $NewUDF.Name $UDFName

  $NewTrigger = Set-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName -Body $Body -TriggerOperation $TriggerOperation -TriggerType $TriggerType
  Assert-AreEqual $NewTrigger.Name $TriggerName

  $Database = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Id $Database.Id
  Assert-AreEqual $NewDatabase.Name $Database.Name
  Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
  Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
  Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag
  Assert-AreEqual $NewDatabase.Resource._colls $Database.Resource._colls
  Assert-AreEqual $NewDatabase.Resource._users $Database.Resource._users

  $Container = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
  Assert-AreEqual $NewContainer.Id $Container.Id
  Assert-AreEqual $NewContainer.Name $Container.Name
  Assert-AreEqual $NewContainer.Resource._rid $Container.Resource._rid
  Assert-AreEqual $NewContainer.Resource._ts $Container.Resource._ts
  Assert-AreEqual $NewContainer.Resource._etag $Container.Resource._etag

  $StoredProcedure = Get-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName
  Assert-AreEqual $NewStoredProcedure.Id $StoredProcedure.Id
  Assert-AreEqual $NewStoredProcedure.Name $StoredProcedure.Name
  Assert-AreEqual $NewStoredProcedure.Resource.Body $StoredProcedure.Resource.Body
  Assert-AreEqual $NewStoredProcedure.Resource._rid $StoredProcedure.Resource._rid
  Assert-AreEqual $NewStoredProcedure.Resource._ts $StoredProcedure.Resource._ts
  Assert-AreEqual $NewStoredProcedure.Resource._etag $StoredProcedure.Resource._etag
  
  $UDF = Get-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $UDFName
  Assert-AreEqual $NewUDF.Id $UDF.Id
  Assert-AreEqual $NewUDF.Name $UDF.Name
  Assert-AreEqual $NewUDF.Resource.Body $UDF.Resource.Body
  Assert-AreEqual $NewUDF.Resource._rid $UDF.Resource._rid
  Assert-AreEqual $NewUDF.Resource._ts $UDF.Resource._ts
  Assert-AreEqual $NewUDF.Resource._etag $UDF.Resource._etag

  $Trigger = Get-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName
  Assert-AreEqual $NewTrigger.Id $Trigger.Id
  Assert-AreEqual $NewTrigger.Name $Trigger.Name
  Assert-AreEqual $NewTrigger.Resource.Body $Trigger.Resource.Body
  Assert-AreEqual $NewTrigger.Resource.TriggerType $Trigger.Resource.TriggerType
  Assert-AreEqual $NewTrigger.Resource.TriggerOperation $Trigger.Resource.TriggerOperation
  Assert-AreEqual $NewTrigger.Resource._rid $Trigger.Resource._rid
  Assert-AreEqual $NewTrigger.Resource._ts $Trigger.Resource._ts
  Assert-AreEqual $NewTrigger.Resource._etag $Trigger.Resource._etag

  $ListContainers = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName
  Assert-NotNull($ListContainers)

  $ListDatabases = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName
  Assert-NotNull($ListDatabases)

  $ListStoredProcedures = Get-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName
  Assert-NotNull($ListStoredProcedures)

  $ListUDFs = Get-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName
  Assert-NotNull($ListUDFs)

  $ListTriggers = Get-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName
  Assert-NotNull($ListTriggers)

  Remove-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName 

  Remove-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName 

  Remove-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName  -Name $UDFName 

  Remove-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName 

  Remove-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName 
}

function Test-SqlOperationsCmdletsUsingInputObject
{
  $AccountName = "cosmosdb9921232812"
  $rgName = "rgtest9921232812"
  $DatabaseName = "dbName2"
  $ContainerName = "container1"

  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"
  $StoredProcedureName = "storedProcedure"

  $UDFName = "udf"
  $TriggerName = "trigger"

  $PartitionKeyPathValue = "/foo/bar"
  $PartitionKeyKindValue = "Hash"

  $Body = "function () { var context = getContext(); " +
                        "var response = context.getResponse();" +
                        "response.setBody('Hello, World');" +
                        "}"
  $TriggerOperation = "All"
  $TriggerType = "Pre"

  $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName

  $NewDatabase =  Set-AzCosmosDBSqlDatabase -InputObject $cosmosDBAccount -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Name $DatabaseName

  $NewContainer = Set-AzCosmosDBSqlContainer -InputObject $NewDatabase -Name $ContainerName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
  Assert-AreEqual $NewContainer.Name $ContainerName

  $NewStoredProcedure = Set-AzCosmosDBSqlStoredProcedure -InputObject $NewContainer -Name $StoredProcedureName -Body $Body
  Assert-AreEqual $NewStoredProcedure.Name $StoredProcedureName

  $NewUDF = Set-AzCosmosDBSqlUserDefinedFunction -InputObject $NewContainer -Name $UDFName -Body $Body
  Assert-AreEqual $NewUDF.Name $UDFName

  $NewTrigger = Set-AzCosmosDBSqlTrigger -InputObject $NewContainer -Name $TriggerName -Body $Body -TriggerOperation $TriggerOperation -TriggerType $TriggerType
  Assert-AreEqual $NewTrigger.Name $TriggerName

  $Database = Get-AzCosmosDBSqlDatabase -InputObject $cosmosDBAccount -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Id $Database.Id
  Assert-AreEqual $NewDatabase.Name $Database.Name
  Assert-AreEqual $NewDatabase.Resource._rid $Database.Resource._rid
  Assert-AreEqual $NewDatabase.Resource._ts $Database.Resource._ts
  Assert-AreEqual $NewDatabase.Resource._etag $Database.Resource._etag
  Assert-AreEqual $NewDatabase.Resource._colls $Database.Resource._colls
  Assert-AreEqual $NewDatabase.Resource._users $Database.Resource._users

  $Container = Get-AzCosmosDBSqlContainer -InputObject $NewDatabase -Name $ContainerName
  Assert-AreEqual $NewContainer.Id $Container.Id
  Assert-AreEqual $NewContainer.Name $Container.Name
  Assert-AreEqual $NewContainer.Resource._rid $Container.Resource._rid
  Assert-AreEqual $NewContainer.Resource._ts $Container.Resource._ts
  Assert-AreEqual $NewContainer.Resource._etag $Container.Resource._etag

  $StoredProcedure = Get-AzCosmosDBSqlStoredProcedure -InputObject $NewContainer -Name $StoredProcedureName
  Assert-AreEqual $NewStoredProcedure.Id $StoredProcedure.Id
  Assert-AreEqual $NewStoredProcedure.Name $StoredProcedure.Name
  Assert-AreEqual $NewStoredProcedure.Resource.Body $StoredProcedure.Resource.Body
  Assert-AreEqual $NewStoredProcedure.Resource._rid $StoredProcedure.Resource._rid
  Assert-AreEqual $NewStoredProcedure.Resource._ts $StoredProcedure.Resource._ts
  Assert-AreEqual $NewStoredProcedure.Resource._etag $StoredProcedure.Resource._etag
  
  $UDF = Get-AzCosmosDBSqlUserDefinedFunction -InputObject $NewContainer -Name $UDFName
  Assert-AreEqual $NewUDF.Id $UDF.Id
  Assert-AreEqual $NewUDF.Name $UDF.Name
  Assert-AreEqual $NewUDF.Resource.Body $UDF.Resource.Body
  Assert-AreEqual $NewUDF.Resource._rid $UDF.Resource._rid
  Assert-AreEqual $NewUDF.Resource._ts $UDF.Resource._ts
  Assert-AreEqual $NewUDF.Resource._etag $UDF.Resource._etag

  $Trigger = Get-AzCosmosDBSqlTrigger -InputObject $NewContainer -Name $TriggerName
  Assert-AreEqual $NewTrigger.Id $Trigger.Id
  Assert-AreEqual $NewTrigger.Name $Trigger.Name
  Assert-AreEqual $NewTrigger.Resource.Body $Trigger.Resource.Body
  Assert-AreEqual $NewTrigger.Resource.TriggerType $Trigger.Resource.TriggerType
  Assert-AreEqual $NewTrigger.Resource.TriggerOperation $Trigger.Resource.TriggerOperation
  Assert-AreEqual $NewTrigger.Resource._rid $Trigger.Resource._rid
  Assert-AreEqual $NewTrigger.Resource._ts $Trigger.Resource._ts
  Assert-AreEqual $NewTrigger.Resource._etag $Trigger.Resource._etag

  $ListContainers = Get-AzCosmosDBSqlContainer -InputObject $NewDatabase
  Assert-NotNull($ListContainers)

  $ListDatabases = Get-AzCosmosDBSqlDatabase -InputObject $cosmosDBAccount
  Assert-NotNull($ListDatabases) 

  $ListStoredProcedures = Get-AzCosmosDBSqlStoredProcedure -InputObject $NewContainer
  Assert-NotNull($ListStoredProcedures)

  $ListUDFs = Get-AzCosmosDBSqlUserDefinedFunction -InputObject $NewContainer
  Assert-NotNull($ListUDFs)

  $ListTriggers = Get-AzCosmosDBSqlTrigger -InputObject $NewContainer
  Assert-NotNull($ListTriggers)

  Remove-AzCosmosDBSqlStoredProcedure -InputObject $StoredProcedure

  Remove-AzCosmosDBSqlTrigger -InputObject $Trigger

  Remove-AzCosmosDBSqlUserDefinedFunction -InputObject $UDF

  Remove-AzCosmosDBSqlContainer -InputObject $NewContainer 

  Remove-AzCosmosDBSqlDatabase -InputObject $NewDatabase 
}