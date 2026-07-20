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

      # try updating non existing table
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

<#
.SYNOPSIS
Test Table Roles cmdlets using all parameter sets
#>
function Test-TableRoleCmdlets
{
  $AccountName = "managedidentity-table-armtestaccount"
  $rgName = "table-connection-demo-livesite"  
  $location = "UK South"
  $locations = @()
  $locations += New-AzCosmosDBLocationObject -LocationName "UK South" -FailoverPriority 0 -IsZoneRedundant 0

  $TableName = "table1"
  $TableName2 = "table2"
  $apiKind = "Table"
  $ThroughputValue = 500
  $consistencyLevel = "Session"
  $UpdatedThroughputValue = 600
  
  $subscriptionId = "2bcd91eb-97a9-4868-bf40-662ce8ef8cb0" #$(getVariable "SubscriptionId")
  
  $PrincipalId = "d006e945-a621-4973-8113-b0a705061e33"
  $PrincipalId2 = "5af9fd41-fffc-4c7a-9fd8-bed87ae38ac3"
    
  $RoleName = "roleDefinitionName12"
  $RoleName2 = "roleDefinitionName2"
  $RoleName3 = "roleDefinitionName3"
  $RoleName4 = "roleDefinitionName4"
  $RoleName5 = "roleDefinitionName5"
  $RoleName6 = "roleDefinitionName6"

  $DataActionRead =     "Microsoft.DocumentDB/databaseAccounts/tables/containers/entities/read"
  $DataActionCreate =   "Microsoft.DocumentDB/databaseAccounts/tables/containers/entities/create"
  $DataActionReplace =  "Microsoft.DocumentDB/databaseAccounts/tables/containers/entities/replace"
  $DataActionInvalid =  "Microsoft.DocumentDB/databaseAccounts/tables/containers/entities/invalid-action"
    
  $Scope = "/"
  $FullyQualifiedScope = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName"
  $Scope2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/dbs/dbName"
    
  $RoleDefinitionId = "df31c3a1-20f5-4ff1-bdd0-5e0782617e22"
  $FullyQualifiedRoleDefinitionId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/tableRoleDefinitions/df31c3a1-20f5-4ff1-bdd0-5e0782617e22"
  $RoleDefinitionId2 = "a36e56a5-9afc-4819-aa78-3a8083a3ee74"
  $FullyQualifiedRoleDefinitionId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/tableRoleDefinitions/a36e56a5-9afc-4819-aa78-3a8083a3ee74"
  $RoleDefinitionId3 = "9ee200b5-73fd-4779-b36a-e2a31f9244f3"
  $FullyQualifiedRoleDefinitionId3 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/tableRoleDefinitions/9ee200b5-73fd-4779-b36a-e2a31f9244f3"
  $RoleDefinitionId6 = "7ff311a6-73fd-4779-b36a-e2a31f9244f3"  

  $RoleAssignmentId = "a2ccaf94-3c39-4728-b892-95edeef0e754"
  $FullyQualifiedRoleAssignmentId = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/tableRoleAssignments/a2ccaf94-3c39-4728-b892-95edeef0e754"
  $RoleAssignmentId2 = "8f3f78c4-a8df-4088-9cbb-a3947e27076b"
  $FullyQualifiedRoleAssignmentId2 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/tableRoleAssignments/8f3f78c4-a8df-4088-9cbb-a3947e27076b"
  $RoleAssignmentId3 = "e7a0b8a5-b381-495d-a020-5467c534e619"
  $FullyQualifiedRoleAssignmentId3 = "/subscriptions/$subscriptionId/resourceGroups/$rgName/providers/Microsoft.DocumentDB/databaseAccounts/$AccountName/tableRoleAssignments/e7a0b8a5-b381-495d-a020-5467c534e619"


  Try{

      $DatabaseAccount = Get-AzCosmosDBAccount -Name $AccountName -ResourceGroupName $rgName
      
      # update non-existing role definition, role assignment
      Try {
          $UpdatedRoleDefinition = Update-AzCosmosDBTableRoleDefinition -Type "CustomRole" -RoleName "RoleName3" -DataAction $DataActionCreate -AssignableScope $Scope2 -Id "00000000-0000-0000-0000-000000000000" -AccountName $AccountName -ResourceGroupName $rgName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Role Definition with Id [00000000-0000-0000-0000-000000000000] does not exist.")
      }
      Try {
          $UpdatedRoleAssignment = Update-AzCosmosDBTableRoleAssignment -RoleDefinitionName "RoleName4" -Id "11111111-1111-1111-1111-111111111111" -AccountName $AccountName -ResourceGroupName $rgName
      }
      Catch {
          Assert-AreEqual $_.Exception.Message ("Role Assignment with Name [RoleName4] does not exist.")
      }
      
      #role def tests
      # create a new role definition - using parent object and permission
      $Permissions = New-AzCosmosDBPermission -DataAction $DataActionRead
      $NewRoleDefinitionFromParentObject = New-AzCosmosDBTableRoleDefinition -Type "CustomRole" -RoleName $RoleName -Permission $Permissions -AssignableScope $Scope -Id $RoleDefinitionId -ParentObject $DatabaseAccount
      Assert-AreEqual $NewRoleDefinitionFromParentObject.RoleName $RoleName
      Assert-AreEqual $NewRoleDefinitionFromParentObject.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromParentObject.Id $FullyQualifiedRoleDefinitionId
      Assert-NotNull $NewRoleDefinitionFromParentObject.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromParentObject.Permissions
      
      # create a new role definition - using fields and data actions
      $NewRoleDefinitionFromFields = New-AzCosmosDBTableRoleDefinition -Type "CustomRole" -RoleName $RoleName2 -DataAction $DataActionCreate -AssignableScope $Scope2 -Id $RoleDefinitionId2 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleDefinitionFromFields.RoleName $RoleName2
      Assert-AreEqual $NewRoleDefinitionFromFields.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromFields.Id $FullyQualifiedRoleDefinitionId2
      Assert-NotNull $NewRoleDefinitionFromFields.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromFields.Permissions

      $NewRoleDefinitionFromFields2 = New-AzCosmosDBTableRoleDefinition -Type "CustomRole" -RoleName $RoleName3 -DataAction $DataActionCreate -AssignableScope $Scope -Id $RoleDefinitionId3 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleDefinitionFromFields2.RoleName $RoleName3
      Assert-AreEqual $NewRoleDefinitionFromFields2.Type "CustomRole"
      Assert-AreEqual $NewRoleDefinitionFromFields2.Id $FullyQualifiedRoleDefinitionId3
      Assert-NotNull $NewRoleDefinitionFromFields2.AssignableScopes
      Assert-NotNull $NewRoleDefinitionFromFields2.Permissions
      
      # get a role definition
      $RoleDefinition = Get-AzCosmosDBTableRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId
      Assert-AreEqual $RoleDefinition.RoleName $RoleName
      Assert-AreEqual $RoleDefinition.Type "CustomRole"
      Assert-NotNull $RoleDefinition.AssignableScopes
      Assert-NotNull $RoleDefinition.Permissions
            
      # update role definition by parent object and data actions
      $UpdatedRoleDefinition = Update-AzCosmosDBTableRoleDefinition -Type "CustomRole" -RoleName $RoleName4 -DataAction $DataActionReplace -AssignableScope $Scope -Id $RoleDefinitionId -ParentObject $DatabaseAccount
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName4
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions
      
      # update role definition by fields and permissions
      $UpdatedRoleDefinition = Update-AzCosmosDBTableRoleDefinition -Type "CustomRole" -RoleName $RoleName5 -Permission $Permissions -AssignableScope $Scope -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.Id $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleDefinition.RoleName $RoleName5
      Assert-NotNull $UpdatedRoleDefinition.AssignableScopes
      Assert-NotNull $UpdatedRoleDefinition.Permissions
      
      # list Role Definitions
      $ListRoleDefinitions = Get-AzCosmosDBTableRoleDefinition -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull $ListRoleDefinitions
            
      #role assignment tests
      # create a new role assignment from name
      $NewRoleAssignmentFromName = New-AzCosmosDBTableRoleAssignment -RoleDefinitionName $RoleName5 -Scope $Scope -PrincipalId $PrincipalId -Id $RoleAssignmentId2 -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $NewRoleAssignmentFromName.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $NewRoleAssignmentFromName.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromName.PrincipalId $PrincipalId
      Assert-AreEqual $NewRoleAssignmentFromName.Id $FullyQualifiedRoleAssignmentId2
           
      # create a new role assignment from parent object
      $NewRoleAssignmentFromParentObject = New-AzCosmosDBTableRoleAssignment -ParentObject $NewRoleDefinitionFromFields2 -Scope $Scope -PrincipalId $PrincipalId2 -Id $RoleAssignmentId3
      Assert-AreEqual $NewRoleAssignmentFromParentObject.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $NewRoleAssignmentFromParentObject.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromParentObject.PrincipalId $PrincipalId2
      Assert-AreEqual $NewRoleAssignmentFromParentObject.Id $FullyQualifiedRoleAssignmentId3
               
      # create a new role assignment from Id
      $NewRoleAssignmentFromId3 = New-AzCosmosDBTableRoleAssignment -RoleDefinitionId $RoleDefinitionId -Scope $Scope -PrincipalId $PrincipalId -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Assert-AreEqual $NewRoleAssignmentFromId3.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $NewRoleAssignmentFromId3.Scope $FullyQualifiedScope
      Assert-AreEqual $NewRoleAssignmentFromId3.PrincipalId $PrincipalId
      Assert-NotNull $NewRoleAssignmentFromId3.Id
      
      # get a role assignment
      $RoleAssignment = Get-AzCosmosDBTableRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Assert-AreEqual $RoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $RoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $RoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $RoleAssignment.Id $FullyQualifiedRoleAssignmentId
      
      # update role assignment by role definition name
      $UpdatedRoleAssignment = Update-AzCosmosDBTableRoleAssignment -RoleDefinitionName $RoleName3 -Id $RoleAssignmentId -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignment by role definition id
      $UpdatedRoleAssignment = Update-AzCosmosDBTableRoleAssignment -RoleDefinitionId $RoleDefinitionId -Id $RoleAssignmentId -AccountName $AccountName -ResourceGroupName $rgName
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId

      # update role assignment by input object
      $UpdatedRoleAssignment.RoleDefinitionId = $FullyQualifiedRoleDefinitionId3
      $UpdatedRoleAssignment = Update-AzCosmosDBTableRoleAssignment -InputObject $UpdatedRoleAssignment
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId3
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId
            
      # update role assignment by parent object
      $UpdatedRoleAssignment = Update-AzCosmosDBTableRoleAssignment -Id $RoleAssignmentId -ParentObject $UpdatedRoleDefinition
      Assert-AreEqual $UpdatedRoleAssignment.RoleDefinitionId $FullyQualifiedRoleDefinitionId
      Assert-AreEqual $UpdatedRoleAssignment.Scope $FullyQualifiedScope
      Assert-AreEqual $UpdatedRoleAssignment.PrincipalId $PrincipalId
      Assert-AreEqual $UpdatedRoleAssignment.Id $FullyQualifiedRoleAssignmentId
    
      # list Role Assignments
      $ListRoleAssignments = Get-AzCosmosDBTableRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName
      Assert-NotNull $ListRoleAssignments
      
      # check for correct error propagation
      $PermissionsInvalid = New-AzCosmosDBPermission -DataAction $DataActionInvalid
      $ScriptBlockRoleDef = { New-AzCosmosDBTableRoleDefinition -Type "CustomRole" -RoleName $RoleName6 -Permission $PermissionsInvalid -AssignableScope $Scope -Id $RoleDefinitionId6 -ParentObject $DatabaseAccount }
      Assert-ThrowsContains $ScriptBlockRoleDef "BadRequest"
  }
  Finally {
      $DatabaseAccount = Get-AzCosmosDBAccount -Name $AccountName -ResourceGroupName $rgName

      Remove-AzCosmosDBTableRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId
      Remove-AzCosmosDBTableRoleAssignment -AccountName $AccountName -ResourceGroupName $rgName -Id $RoleAssignmentId2
      Remove-AzCosmosDBTableRoleAssignment -ParentObject $DatabaseAccount -Id $RoleAssignmentId3

      Remove-AzCosmosDBTableRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId
      Remove-AzCosmosDBTableRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId2
      Remove-AzCosmosDBTableRoleDefinition -ParentObject $DatabaseAccount -Id $RoleDefinitionId3
  }
}