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
Test Cassandra CRUD cmdlets using Name paramter set
#>
function Test-CassandraCreateUpdateGetCmdlets
{
  # using a pre-created CosmosDB Account, since account provisioning takes some time
  $AccountName = "cassandra-db2749"
  $rgName = "CosmosDBResourceGroup49"
  $KeyspaceName = "keyspace1"
  $TableName = "table"
  $KeyspaceName2 = "keyspace2"
  $TableName2 = "table2"
  $ThroughputValue = 500
  $UpdatedThroughputValue = 600
  $apiKind = "Cassandra"
  $consistencyLevel = "Session"
  $location = "East US"
  $ThroughputValue = 500
  $UpdatedThroughputValue = 600
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try {

      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location      
      $account = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

      # create a new keyspace
      $NewKeyspace =  New-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName -Throughput $ThroughputValue
      Assert-AreEqual $NewKeyspace.Name $KeyspaceName

      # create an existing keyspace
      Try {
          $NewDuplicateKeyspace = New-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $KeyspaceName + " already exists.")
      }

      #create columns
      $Column1 = New-AzCosmosDBCassandraColumn -Name "ColumnA" -Type "int"
      $Column2 = New-AzCosmosDBCassandraColumn -Name "ColumnB" -Type "ascii"
      $Column3 = New-AzCosmosDBCassandraColumn -Name "ColumnC" -Type "int"
      $Column4 = New-AzCosmosDBCassandraColumn -Name "ColumnD" -Type "ascii"

      #create clusterkeys
      $clusterkey1 = New-AzCosmosDBCassandraClusterKey -Name "ColumnB" -OrderBy "Asc"
      $clusterkey2 = New-AzCosmosDBCassandraClusterKey -Name "ColumnA" -OrderBy "Asc"

      #create schema
      $schema = New-AzCosmosDBCassandraSchema -Column $Column1,$Column2 -ClusterKey $clusterkey1 -PartitionKey "ColumnA"

      #create a new table
      $NewTable = New-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName -Schema $schema
      Assert-AreEqual $NewTable.Name $TableName
      Validate-EqualSchemaObjects $NewTable.Resource.Schema $schema

      #create an existing table
      Try {
            $NewDuplicateTable = New-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName -Schema $schema
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $TableName + " already exists.")
      }

      #get an existing keyspace
      $Keyspace = Get-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName
      Assert-AreEqual $NewKeyspace.Id $Keyspace.Id
      Assert-AreEqual $NewKeyspace.Name $Keyspace.Name
      Assert-AreEqual $NewKeyspace.Resource.Id $Keyspace.Resource.Id
      Assert-AreEqual $NewKeyspace.Resource._rid $Keyspace.Resource._rid
      Assert-AreEqual $NewKeyspace.Resource._ts $Keyspace.Resource._ts
      Assert-AreEqual $NewKeyspace.Resource._etag $Keyspace.Resource._etag

      #get an existing table
      $Table = Get-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName
      Assert-AreEqual $NewTable.Id $Table.Id
      Assert-AreEqual $NewTable.Name $Table.Name
      Assert-AreEqual $NewTable.Resource.Id $Table.Resource.Id
      Assert-AreEqual $NewTable.Resource._rid $Table.Resource._rid
      Assert-AreEqual $NewTable.Resource._ts $Table.Resource._ts
      Assert-AreEqual $NewTable.Resource._etag $Table.Resource._etag
      Validate-EqualSchemaObjects $NewTable.Resource.Schema $Table.Resource.Schema

      #update a non existing keyspace and table
      Try {
          $UpdatedKeyspace = Update-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $KeyspaceName2 + " does not exist.")
      }

      Try {
          $UpdatedTable = Update-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName2 
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Resource with Name " + $TableName2 + " does not exist.")
      }

      #update an existing keyspace
      $UpdatedKeyspace = Update-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName -Throughput 600
      $Throughput = Get-AzCosmosDBCassandraKeyspaceThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName
      Assert-AreEqual $UpdatedKeyspace.Name $KeyspaceName
      Assert-AreEqual $Throughput.Resource.Throughput $UpdatedTableThroughputValue

      #create an new schema
      $schema = New-AzCosmosDBCassandraSchema -Column $Column1,$Column2,$Column3,$Column4 -ClusterKey $clusterkey1 -PartitionKey "ColumnA"
      #update an existing table
      $UpdatedTable = Update-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName -Schema $schema
      Assert-AreEqual $UpdatedTable.Name $TableName
      Validate-EqualSchemaObjects $UpdatedTable.Resource.Schema $schema

      #list all tables under a keyspace
      $ListTables = Get-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName
      Assert-NotNull($ListTables)

      #list all keyspaces under the account
      $ListKeyspaces = Get-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull($ListKeyspaces)
  
      #delete a table
      $IsTableRemoved =  Remove-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName -PassThru
      Assert-AreEqual $IsTableRemoved true
       
      #delete a keyspace
      $IsKeyspaceRemoved = Remove-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName -PassThru
      Assert-AreEqual $IsKeyspaceRemoved true
    }

    Finally {
        Remove-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName
        Remove-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName
	}
}

<#
.SYNOPSIS
Test Cassandra CRUD cmdlets using Parent Object and InputObject paramter set
#>
function Test-CassandraCreateUpdateGetCmdletsByPiping
{
  $AccountName = "cassandra-db2745"
  $rgName = "CosmosDBResourceGroup45"
  $location = "East US"
  $KeyspaceName = "db2"
  $TableName = "table"
  $apiKind = "Cassandra"
  $consistencyLevel = "Session"
  $ThroughputValue = 500
  $UpdatedThroughputValue = 600
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
      #get the CosmosDBAccount object
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location

      $account = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel
      $cosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName

      #create a new keyspace
      $NewKeyspace =  New-AzCosmosDBCassandraKeyspace -ParentObject $cosmosDBAccount -Name $KeyspaceName -Throughput $ThroughputValue
      Assert-AreEqual $NewKeyspace.Name $KeyspaceName

      #update the keyspace using ParentObject
      $UpdatedKeyspace =  Update-AzCosmosDBCassandraKeyspace -ParentObject $cosmosDBAccount -Name $KeyspaceName -Throughput $UpdatedTableThroughputValue
      Assert-AreEqual $UpdatedKeyspace.Name $KeyspaceName

      #update the keyspace using InputObject
      $UpdatedKeyspace2 =  Update-AzCosmosDBCassandraKeyspace -InputObject $UpdatedKeyspace -Throughput $ThroughputValue
      Assert-AreEqual $UpdatedKeyspace2.Name $KeyspaceName

      #create columns, clusterkeys and schema
      $Column1 = New-AzCosmosDBCassandraColumn -Name "ColumnA" -Type "int"
      $Column2 = New-AzCosmosDBCassandraColumn -Name "ColumnB" -Type "ascii"
      $Column3 = New-AzCosmosDBCassandraColumn -Name "ColumnC" -Type "int"
      $Column4 = New-AzCosmosDBCassandraColumn -Name "ColumnD" -Type "ascii"

      $clusterkey1 = New-AzCosmosDBCassandraClusterKey -Name "ColumnB" -OrderBy "Asc"
      $schema = New-AzCosmosDBCassandraSchema -Column $Column1,$Column2 -ClusterKey $clusterkey1 -PartitionKey "ColumnA"

      #create a new table
      $NewTable = New-AzCosmosDBCassandraTable -ParentObject $NewKeyspace -Name $TableName -Schema $schema
      Assert-AreEqual $NewTable.Name $TableName
      Validate-EqualSchemaObjects $NewTable.Resource.Schema $schema

      #create an new schema
      $schema = New-AzCosmosDBCassandraSchema -Column $Column1,$Column2,$Column3,$Column4 -ClusterKey $clusterkey1 -PartitionKey "ColumnA"
      
      #update the table using ParentObject
      $UpdatedTable = Update-AzCosmosDBCassandraTable -ParentObject $NewKeyspace -Name $TableName -Schema $schema
      Assert-AreEqual $UpdatedTable.Name $TableName
      Validate-EqualSchemaObjects $UpdatedTable.Resource.Schema $schema

      #update the table using InputObject
      $UpdatedTable2 = Update-AzCosmosDBCassandraTable -InputObject $NewTable -Schema $schema
      Assert-AreEqual $UpdatedTable.Name $TableName
      Validate-EqualSchemaObjects $UpdatedTable2.Resource.Schema $schema

      #get the keyspace
      $Keyspace = Get-AzCosmosDBCassandraKeyspace -ParentObject $cosmosDBAccount -Name $KeyspaceName
      Assert-AreEqual $NewKeyspace.Id $Keyspace.Id
      Assert-AreEqual $NewKeyspace.Name $Keyspace.Name
      Assert-AreEqual $NewKeyspace.Resource.Id $Keyspace.Resource.Id

      #get the table
      $Table = Get-AzCosmosDBCassandraTable -ParentObject $NewKeyspace -Name $TableName
      Assert-AreEqual $NewTable.Id $Table.Id
      Assert-AreEqual $NewTable.Name $Table.Name
      Assert-AreEqual $NewTable.Resource.Id $Table.Resource.Id

      #list tables
      $ListTables = Get-AzCosmosDBCassandraTable -ParentObject $NewKeyspace
      Assert-NotNull($ListTables)

      #list keyspaces
      $ListKeyspaces = Get-AzCosmosDBCassandraKeyspace -ParentObject $cosmosDBAccount
      Assert-NotNull($ListKeyspaces)

      #delete table
      $IsTableRemoved =  Remove-AzCosmosDBCassandraTable -InputObject $NewTable -PassThru
      Assert-AreEqual $IsTableRemoved true
  
      #delete keyspace
      $IsKeyspaceRemoved = Remove-AzCosmosDBCassandraKeyspace -InputObject $NewKeyspace -PassThru
      Assert-AreEqual $IsKeyspaceRemoved true
  }

  Finally{
    Remove-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName
    Remove-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName
  }
}

<#
.SYNOPSIS
Test Cassandra Throughput cmdlets using all paramter sets
#>
function Test-CassandraThroughputCmdlets
{
  $AccountName = "cassandra-db2748"
  $rgName = "CosmosDBResourceGroup48"
  $KeyspaceName = "KeyspaceName"
  $TableName = "tableName"
  $apiKind = "Cassandra"
  $consistencyLevel = "Session"
  $location = "East US"
  $ThroughputValue = 500
  $UpdatedThroughputValue = 600
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  Try{
  $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
  $account = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel
      
  $Column1 = New-AzCosmosDBCassandraColumn -Name "ColumnA" -Type "int"
  $Column2 = New-AzCosmosDBCassandraColumn -Name "ColumnB" -Type "ascii"
  $clusterkey1 = New-AzCosmosDBCassandraClusterKey -Name "ColumnB" -OrderBy "Asc"
  $schema = New-AzCosmosDBCassandraSchema -Column $Column1,$Column2 -ClusterKey $clusterkey1 -PartitionKey "ColumnA"

  $ThroughputValue = 1200
  $UpdatedThroughputValue = 1100
  $UpdatedThroughputValue2 = 1000
  $UpdatedThroughputValue3 = 900

  $TableThroughputValue = 800
  $UpdatedTableThroughputValue = 700
  $UpdatedTableThroughputValue2 = 600
  $UpdatedTableThroughputValue3 = 500

  $NewKeyspace =  New-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName -Throughput  $ThroughputValue
  $Throughput = Get-AzCosmosDBCassandraKeyspaceThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName
  Assert-AreEqual $Throughput.Throughput $ThroughputValue

  $UpdatedThroughput = Update-AzCosmosDBCassandraKeyspaceThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName -Throughput $UpdatedThroughputValue
  Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue

  $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName
  $UpdatedThroughput = Update-AzCosmosDBCassandraKeyspaceThroughput -ParentObject $CosmosDBAccount -Name $KeyspaceName -Throughput $UpdatedThroughputValue2
  Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue2

  $UpdatedThroughput = Update-AzCosmosDBCassandraKeyspaceThroughput -InputObject $NewKeyspace -Throughput $UpdatedThroughputValue3
  Assert-AreEqual $UpdatedThroughput.Throughput $UpdatedThroughputValue3

  $NewTable = New-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName -Schema $schema -Throughput $TableThroughputValue
  $TableThroughput = Get-AzCosmosDBCassandraTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName
  Assert-AreEqual $TableThroughput.Throughput $TableThroughputValue

  $UpdatedTableThroughput = Update-AzCosmosDBCassandraTableThroughput -InputObject $NewTable -Throughput $UpdatedTableThroughputValue
  Assert-AreEqual $UpdatedTableThroughput.Throughput $UpdatedTableThroughputValue

  $UpdatedTableThroughput = Update-AzCosmosDBCassandraTableThroughput -ParentObject $NewKeyspace -Name $TableName -Throughput $UpdatedTableThroughputValue2
  Assert-AreEqual $UpdatedTableThroughput.Throughput $UpdatedTableThroughputValue2

  $UpdatedTableThroughput = Update-AzCosmosDBCassandraTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName -Throughput $UpdatedTableThroughputValue3
  Assert-AreEqual $UpdatedTableThroughput.Throughput $UpdatedTableThroughputValue3

  Remove-AzCosmosDBCassandraTable -InputObject $NewTable 
  Remove-AzCosmosDBCassandraKeyspace -InputObject $NewKeyspace 
  }
  Finally{
      Remove-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName
      Remove-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName
  }
}

<#
.SYNOPSIS
Test Cassandra migrate throughput cmdlets 
#>
function Test-CassandraMigrateThroughputCmdlets
{
  $AccountName = "cassandra-db2745"
  $rgName = "CosmosDBResourceGroup45"
  $KeyspaceName = "KeyspaceName3"
  $TableName = "tableName"
  $apiKind = "Cassandra"
  $consistencyLevel = "Session"
  $location = "East US"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "East Us" -FailoverPriority 0 -IsZoneRedundant 0

  $ThroughputValue = 1200
  $TableThroughputValue = 800

  $Autoscale = "Autoscale"
  $Manual = "Manual"

  Try{
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName  -Location   $location
      $account = New-AzCosmosDBAccount -ResourceGroupName $rgName -LocationObject $locations -Name $AccountName -ApiKind $apiKind -DefaultConsistencyLevel $consistencyLevel

      $Column1 = New-AzCosmosDBCassandraColumn -Name "ColumnA" -Type "int"
      $Column2 = New-AzCosmosDBCassandraColumn -Name "ColumnB" -Type "ascii"
      $clusterkey1 = New-AzCosmosDBCassandraClusterKey -Name "ColumnB" -OrderBy "Asc"
      $schema = New-AzCosmosDBCassandraSchema -Column $Column1,$Column2 -ClusterKey $clusterkey1 -PartitionKey "ColumnA"

      $NewKeyspace =  New-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName -Throughput $ThroughputValue
      $Throughput = Get-AzCosmosDBCassandraKeyspaceThroughput -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName
      Assert-AreEqual $Throughput.Throughput $ThroughputValue
      Assert-AreEqual $Throughput.AutoscaleSettings.MaxThroughput 0

      $AutoscaleThroughput = Invoke-AzCosmosDBCassandraKeyspaceThroughputMigration -InputObject $NewKeyspace -ThroughputType $Autoscale
      Assert-AreNotEqual $AutoscaleThroughput.AutoscaleSettings.MaxThroughput 0

      $CosmosDBAccount = Get-AzCosmosDBAccount -ResourceGroupName $rgName -Name $AccountName #get parent object
      $ManualThroughput = Invoke-AzCosmosDBCassandraKeyspaceThroughputMigration -ParentObject $CosmosDBAccount -Name $KeyspaceName -ThroughputType $Manual
      Assert-AreEqual $ManualThroughput.AutoscaleSettings.MaxThroughput 0

      $NewTable = New-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName -Schema $schema -Throughput $TableThroughputValue
      $TableThroughput = Get-AzCosmosDBCassandraTableThroughput -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName
      Assert-AreEqual $TableThroughput.Throughput $TableThroughputValue

      $AutoscaledTableThroughput = Invoke-AzCosmosDBCassandraTableThroughputMigration -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName -ThroughputType $Autoscale
      Assert-AreNotEqual $AutoscaledTableThroughput.AutoscaleSettings.MaxThroughput 0

      $ManuaTableThroughput = Invoke-AzCosmosDBCassandraTableThroughputMigration -InputObject $NewTable -ThroughputType $Manual
      Assert-AreEqual $ManuaTableThroughput.AutoscaleSettings.MaxThroughput 0

      Remove-AzCosmosDBCassandraTable -InputObject $NewTable 
      Remove-AzCosmosDBCassandraKeyspace -InputObject $NewKeyspace
  }
  Finally{
      Remove-AzCosmosDBCassandraTable -AccountName $AccountName -ResourceGroupName $rgName -KeyspaceName $KeyspaceName -Name $TableName
      Remove-AzCosmosDBCassandraKeyspace -AccountName $AccountName -ResourceGroupName $rgName -Name $KeyspaceName
  }
}

function Validate-EqualColumns($Column1, $Column2)
{
    Assert-AreEqual $Column1.Name $Column2.Name
    Assert-AreEqual $Column1.Type $Column2.Type
}

function Validate-EqualClusterKeys($Clusterkey1, $Clusterkey2)
{
    Assert-AreEqual $Clusterkey1.Name $Clusterkey2.Name
    Assert-AreEqual $Clusterkey1.OrderBy $Clusterkey2.OrderBy
}

function Validate-EqualPartitionKeys($PartitionKey1, $PartitionKey2)
{
    Assert-AreEqual $PartitionKey1.Name $PartitionKey2.Name
}

function Validate-EqualSchemaObjects($obj1, $obj2)
{
    Assert-AreEqual $obj1.Columns.Count $obj2.Columns.Count
    $i = 0
    foreach($column in $obj1.Columns)
    {
        Validate-EqualColumns $obj1.Columns[$i] $obj2.Columns[$i]
        $i = $i + 1
	}

    Assert-AreEqual $obj1.ClusterKeys.Count $obj2.ClusterKeys.Count
    $i = 0
    foreach($clusterKey in $obj1.ClusterKeys)
    {
        Validate-EqualClusterKeys $obj1.ClusterKeys[$i] $obj2.ClusterKeys[$i]
        $i = $i + 1
	}

    Assert-AreEqual $obj1.PartitionKeys.Count $obj2.PartitionKeys.Count
    $i = 0
    foreach($partitionKey in $obj1.PartitionKeys)
    {
        Validate-EqualPartitionKeys $obj1.PartitionKeys[$i] $obj2.PartitionKeys[$i]
        $i = $i + 1
	}
}