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

function Test-TableOperationsCmdlets
{
  $AccountName = "db2527"
  $rgName = "CosmosDBResourceGroup2510"
  $TableName = "table1"

  $NewTable =  Set-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
  Assert-AreEqual $NewTable.Name $TableName

  $Table = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
  Assert-AreEqual $NewTable.Id $Table.Id
  Assert-AreEqual $NewTable.Name $Table.Name
  Assert-AreEqual $NewTable.Resource.Id $Table.Resource.Id
  Assert-AreEqual $NewTable.Resource._rid $Table.Resource._rid
  Assert-AreEqual $NewTable.Resource._ts $Table.Resource._ts
  Assert-AreEqual $NewTable.Resource._etag $Table.Resource._etag

  $ListTables = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName
  Assert-NotNull($ListTables)
  
  $IsTableRemoved = Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName -PassThru
  Assert-AreEqual $IsTableRemoved true
}

function Test-TableOperationsCmdletsUsingInputObject
{
  $AccountName = "db2527"
  $rgName = "CosmosDBResourceGroup2510"
  $TableName = "tableName2"

  $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName

  $NewTable =  Set-AzCosmosDBTable -InputObject $cosmosDBAccount -Name $TableName
  Assert-AreEqual $NewTable.Name $TableName

  $Table = Get-AzCosmosDBTable -InputObject $cosmosDBAccount -Name $TableName
  Assert-AreEqual $NewTable.Id $Table.Id
  Assert-AreEqual $NewTable.Name $Table.Name
  Assert-AreEqual $NewTable.Resource.Id $Table.Resource.Id
  Assert-AreEqual $NewTable.Resource._rid $Table.Resource._rid
  Assert-AreEqual $NewTable.Resource._ts $Table.Resource._ts
  Assert-AreEqual $NewTable.Resource._etag $Table.Resource._etag

  $ListTables = Get-AzCosmosDBTable -InputObject $cosmosDBAccount
  Assert-NotNull($ListTables)
 
  $IsTableRemoved = Remove-AzCosmosDBTable -InputObject $Table -PassThru
  Assert-AreEqual $IsTableRemoved true
}