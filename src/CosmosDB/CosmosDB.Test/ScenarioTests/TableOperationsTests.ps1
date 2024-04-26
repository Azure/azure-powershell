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
  $AccountName = "table-db2501"
  $rgName = "CosmosDBResourceGroup01"
  $TableName = "table1"
  $TableName2 = "table2"
  $apiKind = "Table"
  $ThroughputValue = 500
  $location = "East US"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0
  $UpdatedThroughputValue = 600

  Try{

      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -EnableAutomaticFailover:$true

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
  $AccountName = "table-db2502"
  $rgName = "CosmosDBResourceGroup02"
  $apiKind = "Table"
  $consistencyLevel = "Session"
  $location = "East US 2"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0
  $TableName = "table1"
  $TableName2 = "table2"
  $ThroughputValue = 500
  $UpdatedThroughputValue = 600

  Try{

      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -EnableAutomaticFailover:$true

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
  $AccountName = "table-db2503"
  $rgName = "CosmosDBResourceGroup03"
  $TableName = "tableName3"
  $apiKind = "Table"
  $consistencyLevel = "Session"
  $location = "East US"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0
  $ThroughputValue = 1200
  $UpdatedThroughputValue = 1100
  $UpdatedThroughputValue2 = 1000
  $UpdatedThroughputValue3 = 900

  Try{
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -EnableAutomaticFailover:$true

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

<#
.SYNOPSIS
Test Cassandra migrate throughput cmdlets 
#>
function Test-TableMigrateThroughputCmdlets
{
  $AccountName = "table-db2504"
  $rgName = "CosmosDBResourceGroup04"
  $TableName = "tableName4"
  $apiKind = "Table"
  $consistencyLevel = "Session"
  $location = "East US"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  $ThroughputValue = 1200
  $TableThroughputValue = 800

  $Autoscale = "Autoscale"
  $Manual = "Manual"

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -EnableAutomaticFailover:$true

      $NewTable =  New-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName -Throughput  $ThroughputValue
      $Throughput = Get-AzCosmosDBTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue
      Assert-AreEqual $Throughput.AutoscaleSettings.MaxThroughput 0

      $AutoscaleThroughput = Invoke-AzCosmosDBTableThroughputMigration -InputObject $NewTable -ThroughputType $Autoscale
      Assert-AreNotEqual $AutoscaleThroughput.AutoscaleSettings.MaxThroughput 0

      $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName #get parent object
      $ManualThroughput = Invoke-AzCosmosDBTableThroughputMigration -ParentObject $CosmosDBAccount -Name $TableName -ThroughputType $Manual
      Assert-AreEqual $ManualThroughput.AutoscaleSettings.MaxThroughput 0

      Remove-AzCosmosDBTable -InputObject $NewTable 
  }
  Finally{
      Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
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
function Test-TableInAccountCoreFunctionalityNoTimestampBasedRestoreCmdletsV2
{
    $AccountName = "dbaccount-table-ntbr4"
    $rgName = "CosmosDBResourceGroup66"
    $DatabaseName = "iar-table-ntbrtest"
    $ContainerName = "container1"
    $location = "West US"
    $DatabaseName2 = "dbName2"
    $ContainerName2 = "container2"
    $apiKind = "Table"
    $PartitionKeyPathValue = "/foo/bar"
    $PartitionKeyKindValue = "Hash"

    $locations = @()
    $locations += New-AzCosmosDBLocationObject -LocationName "West US" -FailoverPriority 0 -IsZoneRedundant 0
    Try {
        $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location
        $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -BackupPolicyType Continuous

        # 1. Create a new database
        $NewDatabase = New-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-AreEqual $NewDatabase.Name $DatabaseName

        # 3. Get a database
        $Database = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-AreEqual $NewDatabase.Id $Database.Id
        Assert-AreEqual $NewDatabase.Name $Database.Name
        Assert-NotNull($Database)

        Start-TestSleep -s 50

        # 8. Delete database
        Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 100

        # list databases
        $ListDatabases = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName
        Assert-Null($ListDatabases)

        # 10. Restore deleted database
        Restore-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 50

        # list databases
        $ListDatabases = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName
        Assert-NotNull($ListDatabases)

        Start-TestSleep -s 50

        # 13. Delete database
        Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 100

        # list databases
        $ListDatabases = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName
        Assert-Null($ListDatabases)

        # 14. Restore non-existent database - expect failure
        $InvalidDatabaseName = "InvalidDatabaseName"
        $RestoreInvalidDatabase = Restore-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $InvalidDatabaseName
        Assert-Null $RestoreInvalidDatabase


        # 15. Restore database
        Restore-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName

        Start-TestSleep -s 50

        # list databases
        $ListDatabases = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName
        Assert-NotNull($ListDatabases)

        # 16. Restore database again - expect failure (database already exists)
        $SecondInAccountDatabaseRestore = Restore-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
        Assert-Null $SecondInAccountDatabaseRestore
  }
  Catch {
        Write-Output "Error: $_"
        throw $_
  }
  Finally {
       Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $DatabaseName
  }
}

<#
.SYNOPSIS
Test Table InAccount Restore operations
#>
function Test-TableInAccountRestoreOperationsCmdlets
{
  $AccountName = "table-db2530"
  $rgName = "CosmosDBResourceGroup40"
  $TableName = "table1"
  $apiKind = "Table"
  $ThroughputValue = 500
  $location = "East US"
  $consistencyLevel = "Session"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0
  $UpdatedThroughputValue = 600

  Try{

      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $cosmosDBAccount = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel -EnableAutomaticFailover:$true -BackupPolicyType Continuous

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

      Start-TestSleep -s 50

      # get an existing table
      $Table = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName
      Assert-AreEqual $NewTable.Id $Table.Id
      Assert-AreEqual $NewTable.Name $Table.Name
      Assert-AreEqual $NewTable.Resource.Id $Table.Resource.Id

      $restoreTimestampInUtc = [DateTime]::UtcNow.ToString('u')

      # list tables 
      $ListTables = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListTables)

      Start-TestSleep -s 50

      # delete table
      $IsTableRemoved = Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName -PassThru
      Assert-AreEqual $IsTableRemoved true

      Start-TestSleep -s 50

      # restore the deleted table
      Restore-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName -RestoreTimestampInUtc $restoreTimestampInUtc

      Start-TestSleep -s 100

      # list tables 
      $ListTables = Get-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListTables)

      Start-TestSleep -s 100

      # delete table
      $IsTableRemoved = Remove-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName -PassThru
      Assert-AreEqual $IsTableRemoved true

      Start-TestSleep -s 50

      # restore the deleted table
      Restore-AzCosmosDBTable -AccountName $AccountName -ResourceGroupName $rgName -Name $TableName

      Start-TestSleep -s 100

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