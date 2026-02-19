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
Test Cassandra CRUD cmdlets using Name parameter set
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
Test Cassandra CRUD cmdlets using Parent Object and InputObject parameter set
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
Test Cassandra Throughput cmdlets using all parameter sets
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
  $AccountName = "cassandra-db2747"
  $rgName = "CosmosDBResourceGroup47"
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

<#
.SYNOPSIS
Test Cassandra Roles cmdlets using all parameter sets
#>
function Test-CassandraRoleCmdlets
{
  $AccountName = "yayi-cassandra-test-1"
  $rgName = "yayi-test"  
  $location = "UK South"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "UK South" -FailoverPriority 0 -IsZoneRedundant 0

  $CassandraName = "cassandra1"
  $CassandraName2 = "cassandra2"
  $apiKind = "Cassandra"
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

  $DataActionRead =     "Microsoft.DocumentDB/databaseAccounts/cassandra/containers/entities/read"
  $DataActionCreate =   "Microsoft.DocumentDB/databaseAccounts/cassandra/containers/entities/create"
  $DataActionReplace =  "Microsoft.DocumentDB/databaseAccounts/cassandra/containers/entities/replace"
  $DataActionInvalid =  "Microsoft.DocumentDB/databaseAccounts/cassandra/containers/entities/invalid-action"

  $Scope = "/"
  $FullyQualifiedScope = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName"
  $Scope2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/dbs/dbName"

  $RoleDefinitionId = "df31c3a1-20f5-4ff1-bdd0-5e0782617e22"
  $FullyQualifiedRoleDefinitionId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/cassandraRoleDefinitions/df31c3a1-20f5-4ff1-bdd0-5e0782617e22"
  $RoleDefinitionId2 = "a36e56a5-9afc-4819-aa78-3a8083a3ee74"
  $FullyQualifiedRoleDefinitionId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/cassandraRoleDefinitions/a36e56a5-9afc-4819-aa78-3a8083a3ee74"
  $RoleDefinitionId3 = "9ee200b5-73fd-4779-b36a-e2a31f9244f3"
  $FullyQualifiedRoleDefinitionId3 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/cassandraRoleDefinitions/9ee200b5-73fd-4779-b36a-e2a31f9244f3"
  $RoleDefinitionId6 = "7ff311a6-73fd-4779-b36a-e2a31f9244f3"  

  $RoleAssignmentId = "a2ccaf94-3c39-4728-b892-95edeef0e754"
  $FullyQualifiedRoleAssignmentId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/cassandraRoleAssignments/a2ccaf94-3c39-4728-b892-95edeef0e754"
  $RoleAssignmentId2 = "8f3f78c4-a8df-4088-9cbb-a3947e27076b"
  $FullyQualifiedRoleAssignmentId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/cassandraRoleAssignments/8f3f78c4-a8df-4088-9cbb-a3947e27076b"
  $RoleAssignmentId3 = "e7a0b8a5-b381-495d-a020-5467c534e619"
  $FullyQualifiedRoleAssignmentId3 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/cassandraRoleAssignments/e7a0b8a5-b381-495d-a020-5467c534e619"


  Try{

      $DatabaseAccount = Get-AzCosmosDBAccount -Name $AccountName -ResourceGroupName $rgName

      # update non-existing role definition, role assignment
      Try {
          $UpdatedRoleDefinition = Update-AzCosmosDBCassandraRoleDefinition -Type "CustomRole" -RoleName "RoleName3" -DataAction $DataActionCreate -AssignableScope $Scope2 -Id "00000000-0000-0000-0000-000000000000" -AccountName $AccountName -ResourceGroupName $rgName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Role Definition with Id [00000000-0000-0000-0000-000000000000] does not exist.")
      }
      Try {
          $UpdatedRoleAssignment = Update-AzCosmosDBCassandraRoleAssignment -RoleDefinitionName "RoleName4" -Id "11111111-1111-1111-1111-111111111111" -AccountName $AccountName -ResourceGroupName $rgName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Role Assignment with Name [RoleName4] does not exist.")
      }

      #role def tests
      # create a new role definition - using parent object and permission
      $Permissions = New-AzCosmosDBPermission -DataAction $DataActionRead
      $NewRoleDefinitionFromParentObject = New-AzCosmosDBCassandraRoleDefinition -Type "CustomRole" -RoleName $RoleName -Permission $Permissions -AssignableScope $Scope -Id $RoleDefinitionId -ParentObject $DatabaseAccount
      Assert-AreEqual $NewRoleDefinitionFromParentObject.RoleName $RoleName
      Assert-AreEqual $NewRoleDefinitionFromParentObject.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromParentObject.Id $FullyQualifiedRoleDefinitionId
      Assert-NotNull $NewRoleDefinitionFromParentObject.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromParentObject.Permissions

      # create a new role definition - using fields and data actions
      $NewRoleDefinitionFromFields = New-AzCosmosDBCassandraRoleDefinition -Type "CustomRole" -RoleName $RoleName2 -DataAction $DataActionCreate -AssignableScope $Scope2 -Id $RoleDefinitionId2 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleDefinitionFromFields.RoleName $RoleName2
      Assert-AreEqual $NewRoleDefinitionFromFields.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromFields.Id $FullyQualifiedRoleDefinitionId2
      Assert-NotNull $NewRoleDefinitionFromFields.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromFields.Permissions

      $NewRoleDefinitionFromFields2 = New-AzCosmosDBCassandraRoleDefinition -Type "CustomRole" -RoleName $RoleName3 -DataAction $DataActionCreate -AssignableScope $Scope -Id $RoleDefinitionId3 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleDefinitionFromFields2.RoleName $RoleName3
      Assert-AreEqual $NewRoleDefinitionFromFields2.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromFields2.Id $FullyQualifiedRoleDefinitionId3
      Assert-NotNull $NewRoleDefinitionFromFields2.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromFields2.Permissions

      # get a role definition
      $RoleDefinition = Get-AzCosmosDBCassandraRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId
      Assert-AreEqual $RoleDefinition.RoleName $RoleName
      Assert-AreEqual $RoleDefinition.Type "CustomRole"
      Assert-NotNull $RoleDefinition.AssignableScopes
      Assert-NotNull $RoleDefinition.Permissions

      # update role definition by parent object and data actions
      $UpdatedRoleDefinition = Update-AzCosmosDBCassandraRoleDefinition -Type "CustomRole" -RoleName $RoleName4 -DataAction $DataActionReplace -AssignableScope $Scope -Id $RoleDefinitionId -ParentObject $DatabaseAccount
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName4
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions

      # update role definition by fields and permissions
      $UpdatedRoleDefinition = Update-AzCosmosDBCassandraRoleDefinition -Type "CustomRole" -RoleName $RoleName5 -Permission $Permissions -AssignableScope $Scope -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName5
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions

      # list Role Definitions
      $ListRoleDefinitions = Get-AzCosmosDBCassandraRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull $ListRoleDefinitions

      #role assignment tests
      # create a new role assignment from name
      $NewRoleAssignmentFromName = New-AzCosmosDBCassandraRoleAssignment -RoleDefinitionName $RoleName5 -Scope $Scope -PrincipalId $PrincipalId -Id $RoleAssignmentId2 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleAssignmentFromName.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $NewRoleAssignmentFromName.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromName.PrincipalId $PrincipalId
      Assert-AreEqual $NewRoleAssignmentFromName.Id $FullyQualifiedRoleAssignmentId2

      # create a new role assignment from parent object
      $NewRoleAssignmentFromParentObject = New-AzCosmosDBCassandraRoleAssignment -ParentObject $NewRoleDefinitionFromFields2 -Scope $Scope -PrincipalId $PrincipalId2 -Id $RoleAssignmentId3
      Assert-AreEqual $NewRoleAssignmentFromParentObject.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $NewRoleAssignmentFromParentObject.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromParentObject.PrincipalId $PrincipalId2
      Assert-AreEqual $NewRoleAssignmentFromParentObject.Id $FullyQualifiedRoleAssignmentId3

      # create a new role assignment from Id
      $NewRoleAssignmentFromId3 = New-AzCosmosDBCassandraRoleAssignment -RoleDefinitionId $RoleDefinitionId -Scope $Scope -PrincipalId $PrincipalId -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Assert-AreEqual $NewRoleAssignmentFromId3.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $NewRoleAssignmentFromId3.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromId3.PrincipalId $PrincipalId
      Assert-NotNull $NewRoleAssignmentFromId3.Id

      # get a role assignment
      $RoleAssignment = Get-AzCosmosDBCassandraRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Assert-AreEqual $RoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $RoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $RoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $RoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignment by role definition name
      $UpdatedRoleAssignment = Update-AzCosmosDBCassandraRoleAssignment -RoleDefinitionName $RoleName3 -Id $RoleAssignmentId -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by role definition id
      $UpdatedRoleAssignment = Update-AzCosmosDBCassandraRoleAssignment -RoleDefinitionId $RoleDefinitionId -Id $RoleAssignmentId -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by input object
      $UpdatedRoleAssignment.RoleDefinitionId = $FullyQualifiedRoleDefinitionId3
      $UpdatedRoleAssignment = Update-AzCosmosDBCassandraRoleAssignment -InputObject $UpdatedRoleAssignment
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignmnent by parent object
      $UpdatedRoleAssignment = Update-AzCosmosDBCassandraRoleAssignment -Id $RoleAssignmentId -ParentObject $UpdatedRoleDefinition
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # list Role Assignments
      $ListRoleAssignments = Get-AzCosmosDBCassandraRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull $ListRoleAssignments

      # check for correct error propagation
      $PermissionsInvalid = New-AzCosmosDBPermission -DataAction $DataActionInvalid
      $ScriptBlockRoleDef = { New-AzCosmosDBCassandraRoleDefinition -Type "CustomRole" -RoleName $RoleName6 -Permission $PermissionsInvalid -AssignableScope $Scope -Id $RoleDefinitionId6 -ParentObject $DatabaseAccount }
      Assert-ThrowsContains $ScriptBlockRoleDef "BadRequest"
  }
  Finally {
      $DatabaseAccount = Get-AzCosmosDBAccount -Name $AccountName -ResourceGroupName $rgName

      Remove-AzCosmosDBCassandraRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Remove-AzCosmosDBCassandraRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId2
      Remove-AzCosmosDBCassandraRoleAssignment -ParentObject $DatabaseAccount -Id $RoleAssignmentId3

      Remove-AzCosmosDBCassandraRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId
      Remove-AzCosmosDBCassandraRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId2
      Remove-AzCosmosDBCassandraRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId3
  }
}