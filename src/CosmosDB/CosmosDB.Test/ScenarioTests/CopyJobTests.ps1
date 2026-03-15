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

# Helper function to create CosmosDB account with disableLocalAuth via REST API
function Create-CosmosDBAccountViaRest {
  param(
    [string]$ResourceGroupName,
    [string]$AccountName,
    [string]$Location,
    [string]$ApiKind = "Sql",
    [switch]$EnableContinuousBackup,
    [switch]$EnableOnlineCopy
  )

  $subscriptionId = (Get-AzContext).Subscription.Id
  $path = "/subscriptions/$subscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.DocumentDB/databaseAccounts/${AccountName}?api-version=2025-11-01-preview"

  $capabilities = @()
  $kind = "GlobalDocumentDB"
  if ($ApiKind -eq "Cassandra") {
    $capabilities = @(@{ name = "EnableCassandra" })
  }
  if ($ApiKind -eq "MongoDB") {
    $kind = "MongoDB"
    $capabilities = @(@{ name = "EnableMongo" })
  }

  $properties = @{
    databaseAccountOfferType = "Standard"
    locations = @(
      @{
        locationName = $Location
        failoverPriority = 0
        isZoneRedundant = $false
      }
    )
    disableLocalAuth = $true
    capabilities = $capabilities
  }

  if ($EnableContinuousBackup) {
    $properties["backupPolicy"] = @{
      type = "Continuous"
      continuousModeProperties = @{
        tier = "Continuous7Days"
      }
    }
  }

  # Don't add EnableOnlineContainerCopy during creation - requires AllVersionsAndDeletesChangeFeed first
  $needOnlineCopySetup = $EnableOnlineCopy.IsPresent

  $body= @{
    location = $Location
    kind = $kind
    properties = $properties
  } | ConvertTo-Json -Depth 10

  $response = Invoke-AzRestMethod -Path $path -Method PUT -Payload $body
  if (($response.StatusCode -ne 200) -and ($response.StatusCode -ne 201) -and ($response.StatusCode -ne 202)) {
    throw "Failed to create CosmosDB account: $($response.Content)"
  }

  # Poll until provisioning is complete
  $maxRetries = 60
  for ($i = 0; $i -lt $maxRetries; $i++) {
    Start-TestSleep -s 30
    $getResponse = Invoke-AzRestMethod -Path $path -Method GET
    $account = $getResponse.Content | ConvertFrom-Json
    if ($account.properties.provisioningState -eq "Succeeded") {
      if ($needOnlineCopySetup) {
        # Step 2: Enable AllVersionsAndDeletesChangeFeed (must be done separately)
        $patchBody = @{
          properties = @{
            enableAllVersionsAndDeletesChangeFeed = $true
          }
        } | ConvertTo-Json -Depth 5
        $patchResponse = Invoke-AzRestMethod -Path $path -Method PATCH -Payload $patchBody
        if (($patchResponse.StatusCode -ne 200) -and ($patchResponse.StatusCode -ne 201) -and ($patchResponse.StatusCode -ne 202)) {
          throw "Failed to enable AllVersionsAndDeletesChangeFeed: $($patchResponse.Content)"
        }
        for ($j = 0; $j -lt 60; $j++) {
          Start-TestSleep -s 30
          $getResp = Invoke-AzRestMethod -Path $path -Method GET
          $acct = $getResp.Content | ConvertFrom-Json
          if ($acct.properties.provisioningState -eq "Succeeded") { break }
        }

        # Step 3: Add EnableOnlineContainerCopy capability (retry with try/catch for lock conflicts)
        Start-TestSleep -s 120  # Extra wait for internal lock release
        $existingCaps = @()
        if ($acct.properties.capabilities) {
          $existingCaps = @($acct.properties.capabilities | ForEach-Object { @{ name = $_.name } })
        }
        $existingCaps += @{ name = "EnableOnlineContainerCopy" }
        $capBody = @{
          properties = @{
            capabilities = $existingCaps
          }
        } | ConvertTo-Json -Depth 5
        $capSuccess = $false
        for ($retry = 0; $retry -lt 15; $retry++) {
          try {
            $capResponse = Invoke-AzRestMethod -Path $path -Method PATCH -Payload $capBody
            if ($capResponse.StatusCode -eq 200) { $capSuccess = $true; break }
            if ($capResponse.Content -like "*exclusive lock*") {
              Start-TestSleep -s 60
            } else {
              throw "Failed to enable OnlineContainerCopy capability: $($capResponse.Content)"
            }
          } catch {
            if ($_.Exception.Message -like "*exclusive lock*") {
              Start-TestSleep -s 60
            } else {
              throw
            }
          }
        }
        if (-not $capSuccess) { throw "Failed to add EnableOnlineContainerCopy capability after retries" }
        for ($k = 0; $k -lt 60; $k++) {
          Start-TestSleep -s 30
          $getResp2 = Invoke-AzRestMethod -Path $path -Method GET
          $acct2 = $getResp2.Content | ConvertFrom-Json
          if ($acct2.properties.provisioningState -eq "Succeeded") { return $acct2 }
        }
        throw "Account update for OnlineContainerCopy capability timed out"
      }
      return $account
    }
  }
  throw "Account provisioning timed out"
}

<#
.SYNOPSIS
Test Copy Job NoSQL CRUD operations
#>

function Test-CopyJobSqlCmdlets{
  $resourceGroupName = "cdbrg-copyjob-sql"
  $accountName = "cdbacct-copyjob-sql"
  $location = "East US 2"
  $sourceDatabaseName = "srcdb1"
  $sourceContainerName = "srccol1"
  $destDatabaseName = "destdb1"
  $destContainerName = "destcol1"
  $jobName = "copyjob-sql-test"

  Try
  {
    # Setup: create account, databases, and containers
    New-AzResourceGroup -ResourceGroupName $resourceGroupName -Location $location
    Create-CosmosDBAccountViaRest -ResourceGroupName $resourceGroupName -AccountName $accountName -Location $location -ApiKind "Sql"

    New-AzCosmosDBSqlDatabase -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $sourceDatabaseName
    New-AzCosmosDBSqlContainer -ResourceGroupName $resourceGroupName -AccountName $accountName -DatabaseName $sourceDatabaseName -Name $sourceContainerName -PartitionKeyPath "/pk" -PartitionKeyKind "Hash"

    New-AzCosmosDBSqlDatabase -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $destDatabaseName
    New-AzCosmosDBSqlContainer -ResourceGroupName $resourceGroupName -AccountName $accountName -DatabaseName $destDatabaseName -Name $destContainerName -PartitionKeyPath "/pk" -PartitionKeyKind "Hash"

    # Test: Create copy job
    $copyJob = New-AzCosmosDBCopyJob `
      -ResourceGroupName $resourceGroupName `
      -SourceAccountName $accountName `
      -DestinationAccountName $accountName `
      -JobName $jobName `
      -SourceSqlDatabaseName $sourceDatabaseName `
      -SourceSqlContainerName $sourceContainerName `
      -DestinationSqlDatabaseName $destDatabaseName `
      -DestinationSqlContainerName $destContainerName `
      -Mode "Offline"

    Assert-NotNull $copyJob
    Assert-AreEqual $copyJob.Name $jobName

    # Test: Get copy job
    $getJob = Get-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-NotNull $getJob
    Assert-AreEqual $getJob.Name $jobName

    # Test: List copy jobs
    $jobs = Get-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName
    Assert-NotNull $jobs

    # Test: Cancel copy job
    $cancelResult = Stop-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-NotNull $cancelResult
    Assert-AreEqual $cancelResult.Name $jobName
  }
  Finally
  {
    try { Remove-AzCosmosDBAccount -ResourceGroupName $resourceGroupName -Name $accountName -ErrorAction SilentlyContinue } catch {}
    try { Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue } catch {}
  }
}

<#
.SYNOPSIS
Test Copy Job Cassandra operations
#>

function Test-CopyJobCassandraCmdlets{
  $resourceGroupName = "cdbrg-copyjob-cas"
  $accountName = "cdbacct-copyjob-cas"
  $location = "East US 2"
  $sourceKeyspace = "srcks1"
  $sourceTable = "srctbl1"
  $destKeyspace = "destks1"
  $destTable = "desttbl1"
  $jobName = "copyjob-cassandra-test"

  Try
  {
    New-AzResourceGroup -ResourceGroupName $resourceGroupName -Location $location
    Create-CosmosDBAccountViaRest -ResourceGroupName $resourceGroupName -AccountName $accountName -Location $location -ApiKind "Cassandra"

    # Create source and destination keyspaces and tables
    New-AzCosmosDBCassandraKeyspace -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $sourceKeyspace
    $column = New-AzCosmosDBCassandraColumn -Name "pk" -Type "text"
    $schema = New-AzCosmosDBCassandraSchema -Column $column -PartitionKey "pk"
    New-AzCosmosDBCassandraTable -ResourceGroupName $resourceGroupName -AccountName $accountName -KeyspaceName $sourceKeyspace -Name $sourceTable -Schema $schema

    New-AzCosmosDBCassandraKeyspace -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $destKeyspace
    New-AzCosmosDBCassandraTable -ResourceGroupName $resourceGroupName -AccountName $accountName -KeyspaceName $destKeyspace -Name $destTable -Schema $schema

    # Test: Create Cassandra copy job
    $copyJob = New-AzCosmosDBCopyJob `
      -ResourceGroupName $resourceGroupName `
      -SourceAccountName $accountName `
      -DestinationAccountName $accountName `
      -JobName $jobName `
      -SourceKeyspaceName $sourceKeyspace `
      -SourceTableName $sourceTable `
      -DestinationKeyspaceName $destKeyspace `
      -DestinationTableName $destTable

    Assert-NotNull $copyJob
    Assert-AreEqual $copyJob.Name $jobName
  }
  Finally
  {
    try { Remove-AzCosmosDBAccount -ResourceGroupName $resourceGroupName -Name $accountName -ErrorAction SilentlyContinue } catch {}
    try { Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue } catch {}
  }
}

<#
.SYNOPSIS
Test Copy Job MongoDB operations
#>

function Test-CopyJobMongoCmdlets{
  $resourceGroupName = "cdbrg-copyjob-mongo"
  $accountName = "cdbacct-copyjob-mongo"
  $location = "East US 2"
  $sourceDatabase = "srcmongodb1"
  $sourceCollection = "srccol1"
  $destDatabase = "destmongodb1"
  $destCollection = "destcol1"
  $jobName = "copyjob-mongo-test"

  Try
  {
    New-AzResourceGroup -ResourceGroupName $resourceGroupName -Location $location
    Create-CosmosDBAccountViaRest -ResourceGroupName $resourceGroupName -AccountName $accountName -Location $location -ApiKind "MongoDB"

    # Create source and destination databases and collections
    New-AzCosmosDBMongoDBDatabase -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $sourceDatabase
    New-AzCosmosDBMongoDBCollection -ResourceGroupName $resourceGroupName -AccountName $accountName -DatabaseName $sourceDatabase -Name $sourceCollection -Shard "pk"

    New-AzCosmosDBMongoDBDatabase -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $destDatabase
    New-AzCosmosDBMongoDBCollection -ResourceGroupName $resourceGroupName -AccountName $accountName -DatabaseName $destDatabase -Name $destCollection -Shard "pk"

    # Test: Create MongoDB copy job
    $copyJob = New-AzCosmosDBCopyJob `
      -ResourceGroupName $resourceGroupName `
      -SourceAccountName $accountName `
      -DestinationAccountName $accountName `
      -JobName $jobName `
      -SourceMongoDatabaseName $sourceDatabase `
      -SourceCollectionName $sourceCollection `
      -DestinationMongoDatabaseName $destDatabase `
      -DestinationCollectionName $destCollection

    Assert-NotNull $copyJob
    Assert-AreEqual $copyJob.Name $jobName
  }
  Finally
  {
    try { Remove-AzCosmosDBAccount -ResourceGroupName $resourceGroupName -Name $accountName -ErrorAction SilentlyContinue } catch {}
    try { Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue } catch {}
  }
}

<#
.SYNOPSIS
Test Copy Job lifecycle (create, get, pause, resume, cancel)
Note: Complete-AzCosmosDBCopyJob requires Online mode which needs:
  - Continuous backup enabled on the account
  - AllVersionsAndDeletesChangeFeed enabled (PATCH post-creation, takes 30+ min)
  - EnableOnlineContainerCopy capability added (PATCH post-creation)
  This test uses Offline mode to test pause/resume/cancel operations.
#>

function Test-CopyJobLifecycleCmdlets{
  $resourceGroupName = "cdbrg-copyjob-lc5"
  $accountName = "cdbacct-copyjob-lc5"
  $location = "East US 2"
  $sourceDatabaseName = "srcdb1"
  $sourceContainerName = "srccol1"
  $destDatabaseName = "destdb1"
  $destContainerName = "destcol1"
  $jobName = "copyjob-lifecycle-test"

  Try
  {
    # Setup - Use Offline mode for pause/resume/cancel testing
    New-AzResourceGroup -ResourceGroupName $resourceGroupName -Location $location
    Create-CosmosDBAccountViaRest -ResourceGroupName $resourceGroupName -AccountName $accountName -Location $location -ApiKind "Sql"

    New-AzCosmosDBSqlDatabase -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $sourceDatabaseName
    New-AzCosmosDBSqlContainer -ResourceGroupName $resourceGroupName -AccountName $accountName -DatabaseName $sourceDatabaseName -Name $sourceContainerName -PartitionKeyPath "/pk" -PartitionKeyKind "Hash"

    New-AzCosmosDBSqlDatabase -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $destDatabaseName
    New-AzCosmosDBSqlContainer -ResourceGroupName $resourceGroupName -AccountName $accountName -DatabaseName $destDatabaseName -Name $destContainerName -PartitionKeyPath "/pk" -PartitionKeyKind "Hash"

    # Create Offline copy job
    $copyJob = New-AzCosmosDBCopyJob `
      -ResourceGroupName $resourceGroupName `
      -SourceAccountName $accountName `
      -DestinationAccountName $accountName `
      -JobName $jobName `
      -SourceSqlDatabaseName $sourceDatabaseName `
      -SourceSqlContainerName $sourceContainerName `
      -DestinationSqlDatabaseName $destDatabaseName `
      -DestinationSqlContainerName $destContainerName `
      -Mode "Offline"

    Assert-NotNull $copyJob
    Assert-AreEqual $copyJob.Name $jobName

    # Pause the job
    $pauseResult = Suspend-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-NotNull $pauseResult
    Assert-AreEqual $pauseResult.Name $jobName

    # Get job and verify paused status
    $pausedJob = Get-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-NotNull $pausedJob

    # Resume the job
    $resumeResult = Resume-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-NotNull $resumeResult
    Assert-AreEqual $resumeResult.Name $jobName

    # Cancel the job
    $cancelResult = Stop-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-NotNull $cancelResult
    Assert-AreEqual $cancelResult.Name $jobName
  }
  Finally
  {
    try { Remove-AzCosmosDBAccount -ResourceGroupName $resourceGroupName -Name $accountName -ErrorAction SilentlyContinue } catch {}
    try { Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue } catch {}
  }
}

<#
.SYNOPSIS
Test Online Copy Job lifecycle including Complete-AzCosmosDBCopyJob.
Creates an account with continuous backup and EnableOnlineContainerCopy capability,
then tests create (Online mode), pause, resume, and complete operations.
#>

function Test-CopyJobOnlineCompleteCmdlets{
  $resourceGroupName = "cdbrg-copyjob-oc1"
  $accountName = "cdbacct-copyjob-oc1"
  $location = "East US 2"
  $sourceDatabaseName = "srcdb1"
  $sourceContainerName = "srccol1"
  $destDatabaseName = "destdb1"
  $destContainerName = "destcol1"
  $jobName = "copyjob-online-complete-test"

  Try
  {
    # Setup - Create account with continuous backup and online copy capability
    New-AzResourceGroup -ResourceGroupName $resourceGroupName -Location $location
    Create-CosmosDBAccountViaRest -ResourceGroupName $resourceGroupName -AccountName $accountName -Location $location -ApiKind "Sql" -EnableContinuousBackup -EnableOnlineCopy

    New-AzCosmosDBSqlDatabase -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $sourceDatabaseName
    New-AzCosmosDBSqlContainer -ResourceGroupName $resourceGroupName -AccountName $accountName -DatabaseName $sourceDatabaseName -Name $sourceContainerName -PartitionKeyPath "/pk" -PartitionKeyKind "Hash"

    New-AzCosmosDBSqlDatabase -ResourceGroupName $resourceGroupName -AccountName $accountName -Name $destDatabaseName
    New-AzCosmosDBSqlContainer -ResourceGroupName $resourceGroupName -AccountName $accountName -DatabaseName $destDatabaseName -Name $destContainerName -PartitionKeyPath "/pk" -PartitionKeyKind "Hash"

    # Create Online copy job
    $copyJob = New-AzCosmosDBCopyJob `
      -ResourceGroupName $resourceGroupName `
      -SourceAccountName $accountName `
      -DestinationAccountName $accountName `
      -JobName $jobName `
      -SourceSqlDatabaseName $sourceDatabaseName `
      -SourceSqlContainerName $sourceContainerName `
      -DestinationSqlDatabaseName $destDatabaseName `
      -DestinationSqlContainerName $destContainerName `
      -Mode "Online"

    Assert-NotNull $copyJob
    Assert-AreEqual $copyJob.Name $jobName
    Assert-AreEqual $copyJob.Mode "Online"

    # Wait for the job to reach Running state
    $maxRetries = 30
    $jobRunning = $false
    for ($i = 0; $i -lt $maxRetries; $i++) {
      Start-TestSleep -s 20
      $job = Get-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
      if ($job.Status -eq "Running") { $jobRunning = $true; break }
    }
    Assert-True { $jobRunning } "Job should reach Running state"

    # Pause the online job
    $pauseResult = Suspend-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-NotNull $pauseResult
    Assert-AreEqual $pauseResult.Name $jobName

    # Verify paused
    $pausedJob = Get-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-AreEqual $pausedJob.Status "Paused"

    # Resume the online job
    $resumeResult = Resume-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-NotNull $resumeResult
    Assert-AreEqual $resumeResult.Name $jobName

    # Wait for Running again
    for ($i = 0; $i -lt $maxRetries; $i++) {
      Start-TestSleep -s 20
      $job = Get-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
      if ($job.Status -eq "Running") { break }
    }

    # Complete the online job
    $completeResult = Complete-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-NotNull $completeResult
    Assert-AreEqual $completeResult.Name $jobName

    # Verify completed
    Start-TestSleep -s 10
    $completedJob = Get-AzCosmosDBCopyJob -ResourceGroupName $resourceGroupName -AccountName $accountName -JobName $jobName
    Assert-AreEqual $completedJob.Status "Completed"
  }
  Finally
  {
    try { Remove-AzCosmosDBAccount -ResourceGroupName $resourceGroupName -Name $accountName -ErrorAction SilentlyContinue } catch {}
    try { Remove-AzResourceGroup -Name $resourceGroupName -Force -ErrorAction SilentlyContinue } catch {}
  }
}
