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

  $NewContainer = Set-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName -PartitionKeyPath $PartitionKeyPathValue -PartitionKeyKind $PartitionKeyKindValue
  Assert-AreEqual $NewContainer.Name $ContainerName

  $NewStoredProcedure = Set-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName -Body $Body
  Assert-AreEqual $NewStoredProcedure.Name $StoredProcedureName

  $NewUDF = Set-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $UDFName -Body $Body
  Assert-AreEqual $NewUDF.Name $UDFName

  $NewTrigger = Set-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName -Body $Body -TriggerOperation $TriggerOperation -TriggerType $TriggerType
  Assert-AreEqual $NewTrigger.Name $TriggerName

  $Database = Get-AzCosmosDBSqlDatabase -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  Assert-AreEqual $NewDatabase.Id $Database.Id
  Assert-AreEqual $NewDatabase.Name $Database.Name
  Assert-AreEqual $NewDatabase.SqlDatabaseGetResultsId $Database.SqlDatabaseGetResultsId
  Assert-AreEqual $NewDatabase._rid $Database._rid
  Assert-AreEqual $NewDatabase._ts $Database._ts
  Assert-AreEqual $NewDatabase._etag $Database._etag
  Assert-AreEqual $NewDatabase._colls $Database._colls
  Assert-AreEqual $NewDatabase._users $Database._users

  $Container = Get-AzCosmosDBSqlContainer -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -Name $ContainerName
  Assert-AreEqual $NewContainer.Id $Container.Id
  Assert-AreEqual $NewContainer.Name $Container.Name
  Assert-AreEqual $NewContainer.SqlContainerGetResultsId $Container.SqlContainerGetResultsId
  Assert-AreEqual $NewContainer._rid $Container._rid
  Assert-AreEqual $NewContainer._ts $Container._ts
  Assert-AreEqual $NewContainer._etag $Container._etag

  $StoredProcedure = Get-AzCosmosDBSqlStoredProcedure -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $StoredProcedureName
  Assert-AreEqual $NewStoredProcedure.Id $StoredProcedure.Id
  Assert-AreEqual $NewStoredProcedure.Name $StoredProcedure.Name
  Assert-AreEqual $NewStoredProcedure.SqlStoredProcedureGetResultsId $StoredProcedure.SqlStoredProcedureGetResultsId
  Assert-AreEqual $NewStoredProcedure.Body $StoredProcedure.Body
  Assert-AreEqual $NewStoredProcedure._rid $StoredProcedure._rid
  Assert-AreEqual $NewStoredProcedure._ts $StoredProcedure._ts
  Assert-AreEqual $NewStoredProcedure._etag $StoredProcedure._etag
  
  $UDF = Get-AzCosmosDBSqlUserDefinedFunction -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $UDFName
  Assert-AreEqual $NewUDF.Id $UDF.Id
  Assert-AreEqual $NewUDF.Name $UDF.Name
  Assert-AreEqual $NewUDF.SqlUserDefinedFunctionGetResultsId $UDF.SqlUserDefinedFunctionGetResultsId
  Assert-AreEqual $NewUDF.Body $UDF.Body
  Assert-AreEqual $NewUDF._rid $UDF._rid
  Assert-AreEqual $NewUDF._ts $UDF._ts
  Assert-AreEqual $NewUDF._etag $UDF._etag

  $Trigger = Get-AzCosmosDBSqlTrigger -AccountName $AccountName -ResourceGroupName $rgName -DatabaseName $DatabaseName -ContainerName $ContainerName -Name $TriggerName
  Assert-AreEqual $NewTrigger.Id $Trigger.Id
  Assert-AreEqual $NewTrigger.Name $Trigger.Name
  Assert-AreEqual $NewTrigger.SqlTriggerGetResultsId $Trigger.SqlTriggerGetResultsId
  Assert-AreEqual $NewTrigger.Body $Trigger.Body
  Assert-AreEqual $NewTrigger.TriggerType $Trigger.TriggerType
  Assert-AreEqual $NewTrigger.TriggerOperation $Trigger.TriggerOperation
  Assert-AreEqual $NewTrigger._rid $Trigger._rid
  Assert-AreEqual $NewTrigger._ts $Trigger._ts
  Assert-AreEqual $NewTrigger._etag $Trigger._etag

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
  Assert-AreEqual $NewDatabase.SqlDatabaseGetResultsId $Database.SqlDatabaseGetResultsId
  Assert-AreEqual $NewDatabase._rid $Database._rid
  Assert-AreEqual $NewDatabase._ts $Database._ts
  Assert-AreEqual $NewDatabase._etag $Database._etag
  Assert-AreEqual $NewDatabase._colls $Database._colls
  Assert-AreEqual $NewDatabase._users $Database._users

  $Container = Get-AzCosmosDBSqlContainer -InputObject $NewDatabase -Name $ContainerName
  Assert-AreEqual $NewContainer.Id $Container.Id
  Assert-AreEqual $NewContainer.Name $Container.Name
  Assert-AreEqual $NewContainer.SqlContainerGetResultsId $Container.SqlContainerGetResultsId
  Assert-AreEqual $NewContainer._rid $Container._rid
  Assert-AreEqual $NewContainer._ts $Container._ts
  Assert-AreEqual $NewContainer._etag $Container._etag

  $StoredProcedure = Get-AzCosmosDBSqlStoredProcedure -InputObject $NewContainer -Name $StoredProcedureName
  Assert-AreEqual $NewStoredProcedure.Id $StoredProcedure.Id
  Assert-AreEqual $NewStoredProcedure.Name $StoredProcedure.Name
  Assert-AreEqual $NewStoredProcedure.SqlStoredProcedureGetResultsId $StoredProcedure.SqlStoredProcedureGetResultsId
  Assert-AreEqual $NewStoredProcedure.Body $StoredProcedure.Body
  Assert-AreEqual $NewStoredProcedure._rid $StoredProcedure._rid
  Assert-AreEqual $NewStoredProcedure._ts $StoredProcedure._ts
  Assert-AreEqual $NewStoredProcedure._etag $StoredProcedure._etag
  
  $UDF = Get-AzCosmosDBSqlUserDefinedFunction -InputObject $NewContainer -Name $UDFName
  Assert-AreEqual $NewUDF.Id $UDF.Id
  Assert-AreEqual $NewUDF.Name $UDF.Name
  Assert-AreEqual $NewUDF.SqlUserDefinedFunctionGetResultsId $UDF.SqlUserDefinedFunctionGetResultsId
  Assert-AreEqual $NewUDF.Body $UDF.Body
  Assert-AreEqual $NewUDF._rid $UDF._rid
  Assert-AreEqual $NewUDF._ts $UDF._ts
  Assert-AreEqual $NewUDF._etag $UDF._etag

  $Trigger = Get-AzCosmosDBSqlTrigger -InputObject $NewContainer -Name $TriggerName
  Assert-AreEqual $NewTrigger.Id $Trigger.Id
  Assert-AreEqual $NewTrigger.Name $Trigger.Name
  Assert-AreEqual $NewTrigger.SqlTriggerGetResultsId $Trigger.SqlTriggerGetResultsId
  Assert-AreEqual $NewTrigger.Body $Trigger.Body
  Assert-AreEqual $NewTrigger.TriggerType $Trigger.TriggerType
  Assert-AreEqual $NewTrigger.TriggerOperation $Trigger.TriggerOperation
  Assert-AreEqual $NewTrigger._rid $Trigger._rid
  Assert-AreEqual $NewTrigger._ts $Trigger._ts
  Assert-AreEqual $NewTrigger._etag $Trigger._etag

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