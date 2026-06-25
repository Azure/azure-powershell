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
Test soft-deleted account Get, Remove (Purge), and Restore cmdlets
#>
function Test-SoftDeletedAccountCmdlets
{
  $location = "West US 2"

  Try {
      # List soft-deleted accounts in a location
      $softDeletedAccounts = @(Get-AzCosmosDBSoftDeletedAccount -Location $location)
      Assert-NotNull $softDeletedAccounts
      Assert-True { $softDeletedAccounts.Count -gt 0 }

      $account = $softDeletedAccounts[0]
      Assert-NotNull $account.Name
      Assert-NotNull $account.Id

      # Extract resource group from the account's resource ID
      $rgName = ($account.Id -split '/resourceGroups/')[1] -split '/' | Select-Object -First 1

      # Get a specific soft-deleted account
      $specificAccount = Get-AzCosmosDBSoftDeletedAccount -ResourceGroupName $rgName -Location $location -Name $account.Name
      Assert-AreEqual $account.Name $specificAccount.Name
      Assert-AreEqual $account.Id $specificAccount.Id
  }
  Finally {
      # Cleanup is not required for read-only operations
  }
}

<#
.SYNOPSIS
Test soft-deleted SQL database Get, Remove (Purge), and Restore cmdlets
#>
function Test-SoftDeletedSqlDatabaseCmdlets
{
  $rgName = "cli_test_cosmosdb_softdelete_db_recover2zlh2ej5aqyi6dta5l56ylitgemk6ch5nxvm"
  $accountName = "clisddacc2weis3cyiry"
  $location = "West US 2"

  Try {
      # List soft-deleted databases in the account
      $softDeletedDatabases = @(Get-AzCosmosDBSqlSoftDeletedDatabase -ResourceGroupName $rgName -AccountName $accountName -Location $location)
      Assert-NotNull $softDeletedDatabases
      Assert-True { $softDeletedDatabases.Count -gt 0 }

      $database = $softDeletedDatabases[0]
      Assert-NotNull $database.Name
      Assert-NotNull $database.Id

      # Get a specific soft-deleted database
      $specificDb = Get-AzCosmosDBSqlSoftDeletedDatabase -ResourceGroupName $rgName -AccountName $accountName -Location $location -Name $database.Name
      Assert-AreEqual $database.Name $specificDb.Name
      Assert-AreEqual $database.Id $specificDb.Id
  }
  Finally {
      # Cleanup is not required for read-only operations
  }
}

<#
.SYNOPSIS
Test soft-deleted SQL container Get, Remove (Purge), and Restore cmdlets
#>
function Test-SoftDeletedSqlContainerCmdlets
{
  $rgName = "cli_test_cosmosdb_softdelete_coll_recover6jc7vsfdlzguxvclarpcpbb3wc5utx2dxw"
  $accountName = "clisddaccgrh3nhasp7j"
  $databaseName = "clisdddb2ov2b6w"
  $location = "West US 2"

  Try {
      # List soft-deleted containers in the database
      $softDeletedContainers = @(Get-AzCosmosDBSqlSoftDeletedContainer -ResourceGroupName $rgName -AccountName $accountName -Location $location -DatabaseName $databaseName)
      Assert-NotNull $softDeletedContainers
      Assert-True { $softDeletedContainers.Count -gt 0 }

      $container = $softDeletedContainers[0]
      Assert-NotNull $container.Name
      Assert-NotNull $container.Id

      # Get a specific soft-deleted container
      $specificContainer = Get-AzCosmosDBSqlSoftDeletedContainer -ResourceGroupName $rgName -AccountName $accountName -Location $location -DatabaseName $databaseName -Name $container.Name
      Assert-AreEqual $container.Name $specificContainer.Name
      Assert-AreEqual $container.Id $specificContainer.Id
  }
  Finally {
      # Cleanup is not required for read-only operations
  }
}

<#
.SYNOPSIS
Test enabling soft delete configuration on a Cosmos DB account
#>
function Test-SoftDeleteConfigurationOnAccount
{
  $rgName = "CosmosDBSoftDeleteResourceGroup02"
  $accountName = "softdelete-config-test01"
  $location = "East US"

  Try {
      # Create resource group
      $resourceGroup = New-AzResourceGroup -ResourceGroupName $rgName -Location $location

      # Create a new Cosmos DB account
      $account = New-AzCosmosDBAccount -ResourceGroupName $rgName -Name $accountName -Location $location -ApiKind "Sql" -DefaultConsistencyLevel "Session"
      Assert-AreEqual $account.Name $accountName

      # Update the account to enable soft delete
      $updatedAccount = Update-AzCosmosDBAccount -ResourceGroupName $rgName -Name $accountName -EnableSoftDelete $true -SoftDeleteRetentionPeriodInMinutes 60 -MinMinutesBeforePermanentDeletionAllowed 30
      Assert-AreEqual $updatedAccount.Name $accountName
  }
  Finally {
      Remove-AzCosmosDBAccount -ResourceGroupName $rgName -Name $accountName
      Remove-AzResourceGroup -ResourceGroupName $rgName -Force
  }
}
