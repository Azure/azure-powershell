﻿# ----------------------------------------------------------------------------------
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
Test Table CRUD operations
#>
function Test-TableOperationsCmdlets
{
  $AccountName = "db2527"
  $rgName = "CosmosDBResourceGroup2510"
  $TableName = "table1"
  $TableName2 = "table2"
  $ThroughputValue = 500
  $UpdatedThroughputValue = 600

  Try{
      # create a new table
      $NewTable = New-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName -Throughput $ThroughputValue
      Assert-AreEqual $NewTable.Name $TableName

      $Throughput = Get-AzCosmosDBTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue

      # create an existing database
      Try {
          $NewDuplicateTable = New-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $TableName + " already exists.")
      }

      # get an existing table
      $Table = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
      Assert-AreEqual $NewTable.Id $Table.Id
      Assert-AreEqual $NewTable.Name $Table.Name
      Assert-AreEqual $NewTable.Resource.Id $Table.Resource.Id

      # update existing table
      $UpdatedTable =  Update-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName -Throughput $UpdatedThroughputValue
      $Throughput = Get-AzCosmosDBTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
      Assert-AreEqual $Throughput.Throughput $UpdatedThroughputValue

      # try updating non existant table
      Try {
          $UpdatedTable = Update-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $TableName2 + " does not exist.")
      }

      # list tables 
      $ListTables = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListTables)
  
      # delete table
      $IsTableRemoved = Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName -PassThru
      Assert-AreEqual $IsTableRemoved true
  }
  Finally {
      Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
  }
}

<#
.SYNOPSIS
Test Table CRUD operations using InputObject and ParentObject parameter set
#>
function Test-TableOperationsCmdletsUsingInputObject
{
  $AccountName = "db2527"
  $rgName = "CosmosDBResourceGroup2510"
  $TableName = "table1"
  $TableName2 = "table2"
  $ThroughputValue = 500
  $UpdatedThroughputValue = 600

  Try{
      # get the cosmosDBAccount object
      $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName

      # create a new table
      $NewTable = New-AzCosmosDBTable -ParentObject $cosmosDBAccount -Name $TableName -Throughput $ThroughputValue
      Assert-AreEqual $NewTable.Name $TableName

      $Throughput = Get-AzCosmosDBTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue

      # get an existing table
      $Table = Get-AzCosmosDBTable -ParentObject $cosmosDBAccount -Name $TableName
      Assert-AreEqual $NewTable.Id $Table.Id
      Assert-AreEqual $NewTable.Name $Table.Name
      Assert-AreEqual $NewTable.Resource.Id $Table.Resource.Id

      # update existing table using parent object
      $UpdatedTable =  Update-AzCosmosDBTable -ParentObject $cosmosDBAccount -Name $TableName -Throughput $UpdatedThroughputValue
      $Throughput = Get-AzCosmosDBTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
      Assert-AreEqual $Throughput.Throughput $UpdatedThroughputValue

      # update existing table using input object
      $UpdatedTable2 =  Update-AzCosmosDBTable -InputObject $UpdatedTable -Throughput $ThroughputValue
      $Throughput = Get-AzCosmosDBTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue

      # list tables 
      $ListTables = Get-AzCosmosDBTable -ParentObject $cosmosDBAccount
      Assert-NotNull($ListTables)
  
      # delete table
      $IsTableRemoved = Remove-AzCosmosDBTable -InputObject $UpdatedTable -PassThru
      Assert-AreEqual $IsTableRemoved true
  }
  Finally {
      Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
  }
}

<#
.SYNOPSIS
Test Table throughput cmdlets using all parameter sets
#>
function Test-TableThroughputCmdlets
{
  $AccountName = "db2527"
  $rgName = "CosmosDBResourceGroup2510"
  $TableName = "tableName3"

  $ThroughputValue = 1200
  $UpdatedThroughputValue = 1100
  $UpdatedThroughputValue2 = 1000
  $UpdatedThroughputValue3 = 900

  Try{
  $NewTable =  New-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName -Throughput  $ThroughputValue
  $Throughput = Get-AzCosmosDBTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
  Assert-AreEqual $Throughput.Throughput $ThroughputValue

  $UpdatedThroughput = Update-AzCosmosDBTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName -Throughput $UpdatedThroughputValue
  Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue

  $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName
  $UpdatedThroughput = Update-AzCosmosDBTableThroughput -ParentObject $CosmosDBAccount -Name $TableName -Throughput $UpdatedThroughputValue2
  Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue2

  $UpdatedThroughput = Update-AzCosmosDBTableThroughput -InputObject $NewTable -Throughput $UpdatedThroughputValue3
  Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue3

  Remove-AzCosmosDBTable -InputObject $NewTable 
  }
  Finally{
      Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
  }
}