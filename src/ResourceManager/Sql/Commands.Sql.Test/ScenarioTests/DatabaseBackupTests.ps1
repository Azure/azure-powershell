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
	Test getting restore points from databases via piped cmdlets.
#>
function Test-ListDatabaseRestorePoints
{
	# Setup
	$location = "Japan East"
	$serverVersion = "12.0";
	$rg = Create-ResourceGroupForTest

	try
	{
		$server = Create-ServerForTest $rg $location

		# Create data warehouse database with all parameters.
		$databaseName = Get-DatabaseName
		$dwdb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100

		$databaseName = Get-DatabaseName
		$standarddb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition Standard -RequestedServiceObjectiveName S0

		# Get restore points from data warehouse database.
		$restorePoints = Get-AzureRmSqlDatabaseRestorePoints -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName
		Assert-Null $restorePoints # Since the data warehouse database has just been created, it should not have any discrete restore points.

		# Get restore points from standard database through pipe.
		$restorePoints = $standarddb | Get-AzureRmSqlDatabaseRestorePoints 
		Assert-AreEqual $restorePoints.Count 1 # Standard databases should only have 1 continuous restore point.
		$restorePoint = $restorePoints[0]
		Assert-AreEqual $restorePoint.RestorePointType Continuous
		Assert-Null $restorePoint.RestorePointCreationDate
		Assert-AreEqual $restorePoint.EarliestRestoreDate.Kind Utc
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-RestoreGeoBackup
{
	# Setup
	$location = "Southeast Asia"
	$serverVersion = "12.0"
	$rg = Get-AzureRmResourceGroup -ResourceGroupName hchung-test2
	$server = Get-AzureRmSqlServer -ServerName hchung-testsvr2 -ResourceGroupName $rg.ResourceGroupName
	$db = Get-AzureRmSqlDatabase -ServerName $server.ServerName -DatabaseName hchung-testdb-geo2 -ResourceGroupName $rg.ResourceGroupName
	$restoredDbName = "powershell_db_georestored"

	$geobackup = Get-AzureRmSqlDatabaseGeoBackup -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -DatabaseName $db.DatabaseName 
	$job = $geobackup | Restore-AzureRmSqlDatabase -FromGeoBackup -TargetDatabaseName $restoredDbName -AsJob
	$job | Wait-Job
}

function Test-RestoreDeletedDatabaseBackup
{
	# Setup
	$location = "Southeast Asia"
	$serverVersion = "12.0"
	$rg = Get-AzureRmResourceGroup -ResourceGroupName hchung-test2
	$server = Get-AzureRmSqlServer -ServerName hchung-testsvr2 -ResourceGroupName $rg.ResourceGroupName
	$droppedDbName = "powershell_db_georestored"
	$restoredDbName = "powershell_db_deleted"

	$deletedDb = Get-AzureRmSqlDeletedDatabaseBackup -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName `
		-DatabaseName $droppedDbName -DeletionDate "2016-02-23T00:21:22.847Z" 
	$deletedDb | Restore-AzureRmSqlDatabase -FromDeletedDatabaseBackup -TargetDatabaseName $restoredDbName
}

function Test-RestorePointInTimeBackup
{
	# Setup
	$location = "Southeast Asia"
	$serverVersion = "12.0"
	$rg = Get-AzureRmResourceGroup -ResourceGroupName hchung-test
	$server = Get-AzureRmSqlServer -ServerName hchung-testsvr -ResourceGroupName $rg.ResourceGroupName
	$db = Get-AzureRmSqlDatabase -ServerName $server.ServerName -DatabaseName hchung-testdb -ResourceGroupName $rg.ResourceGroupName
	$restoredDbName = "powershell_db_restored"

	Get-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $db.DatabaseName | 
	Restore-AzureRmSqlDatabase -FromPointInTimeBackup -PointInTime "2016-02-20T00:06:00Z" -TargetDatabaseName $restoredDbName
}

function Test-ServerBackupLongTermRetentionVault
{
	$location = "North Europe"
	$serverVersion = "12.0"
	$rg = Get-AzureRmResourceGroup -ResourceGroupName hchung
	$server = Get-AzureRmSqlServer -ServerName hchung-testsvr -ResourceGroupName $rg.ResourceGroupName
	$vaultResourceId = "/subscriptions/e5e8af86-2d93-4ebd-8eb5-3b0184daa9de/resourceGroups/hchung/providers/Microsoft.RecoveryServices/vaults/hchung-testvault"

	# set
	Set-AzureRmSqlServerBackupLongTermRetentionVault -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -ResourceId $vaultResourceId
	# get
	$result = Get-AzureRmSqlServerBackupLongTermRetentionVault -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName
	#verify
	Assert-True { $result.RecoveryServicesVaultResourceId -eq $vaultResourceId }
}

function Test-DatabaseBackupLongTermRetentionPolicy
{
	$location = "North Europe"
	$serverVersion = "12.0"
	$rg = Get-AzureRmResourceGroup -ResourceGroupName hchung
	$server = Get-AzureRmSqlServer -ServerName hchung-testsvr -ResourceGroupName $rg.ResourceGroupName
	$db = Get-AzureRmSqlDatabase -ServerName $server.ServerName -DatabaseName hchung-testdb -ResourceGroupName $rg.ResourceGroupName
	$policyResourceId = "/subscriptions/e5e8af86-2d93-4ebd-8eb5-3b0184daa9de/resourceGroups/hchung/providers/Microsoft.RecoveryServices/vaults/hchung-testvault/backupPolicies/hchung-testpolicy"

	# set
	Set-AzureRmSqlDatabaseBackupLongTermRetentionPolicy -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName `
		-DatabaseName $db.DatabaseName -State "Enabled" -ResourceId $policyResourceId
	# get
	$result = Get-AzureRmSqlDatabaseBackupLongTermRetentionPolicy -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -DatabaseName $db.DatabaseName
	#verify
	Assert-True { $result.RecoveryServicesBackupPolicyResourceId -eq $policyResourceId }
}

function Test-RestoreLongTermRetentionBackup
{
	$location = "North Europe"
	$serverVersion = "12.0"
	$rg = Get-AzureRmResourceGroup -ResourceGroupName hchung
	$server = Get-AzureRmSqlServer -ServerName hchung-testsvr -ResourceGroupName $rg.ResourceGroupName
	$restoredDbName = "powershell_db_restored_ltr"
	$recoveryPointResourceId = "/subscriptions/e5e8af86-2d93-4ebd-8eb5-3b0184daa9de/resourceGroups/hchung/providers/Microsoft.RecoveryServices/vaults/hchung-testvault/backupFabrics/Azure/protectionContainers/AzureSqlContainer;Sql;hchung;hchung-testsvr/protectedItems/AzureSqlDb;dsName;hchung-testdb;fbf5641f-77f8-43b7-8fd7-5338ec293213/recoveryPoints/1731556986347"

    Restore-AzureRmSqlDatabase -FromLongTermRetentionBackup -ResourceId $recoveryPointResourceId -TargetDatabaseName $restoredDbName `
		-ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
}

function Test-LongTermRetentionV2Policy($location = "westcentralus")
{
	# Setup
	$location = Get-Location Microsoft.Sql "servers" $location
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	$weeklyRetention1 = "P1W"
	$weeklyRetention2 = "P2W"
	$emptyRetention = "PT0S"

	try
	{
		# Create with default values
		$databaseName = Get-DatabaseName
		$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

		# Basic Policy Test
		Set-AzureRmSqlDatabaseLongTermRetentionPolicy -ResourceGroup $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -WeeklyRetention $weeklyRetention2
		$policy = Get-AzureRmSqlDatabaseLongTermRetentionPolicy -ResourceGroup $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Current
		Assert-AreEqual $policy.WeeklyRetention $weeklyRetention2
		Assert-AreEqual $policy.MonthlyRetention $emptyRetention
		Assert-AreEqual $policy.YearlyRetention $emptyRetention

		# Alias Policy Test
		Set-AzureRmSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroup $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -WeeklyRetention $weeklyRetention1
		$policy = Get-AzureRmSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroup $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Current
		Assert-AreEqual $policy.WeeklyRetention $weeklyRetention1
		Assert-AreEqual $policy.MonthlyRetention $emptyRetention
		Assert-AreEqual $policy.YearlyRetention $emptyRetention
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-LongTermRetentionV2Backup($location = "westcentralus")
{
	# Setup
	$location = Get-Location Microsoft.Sql "servers" $location
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create with default values
		$databaseName = Get-DatabaseName
		$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
		
		# Basic Get Tests
		Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $db.Location
		# Can't assert because we can't guarantee that the subscription won't have any backups in the location.
		$backups = Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $db.Location -ServerName $server.ServerName
		Assert-AreEqual $backups.Count 0
		$backups = Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $db.Location -ServerName $server.ServerName -DatabaseName $databaseName
		Assert-AreEqual $backups.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-LongTermRetentionV2
{

	# MANUAL INSTRUCTIONS
	# Create a server and database and fill in the appropriate information below
	# Set the weekly retention on the database so that the first backup gets picked up, for example:
	# Set-AzureRmSqlDatabaseLongTermRetentionPolicy -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName -WeeklyRetention P1W
	# Wait about 18 hours until it gets properly copied and you see the backup when run get backups, for example:
	# Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaeName $databaseName
	$resourceGroup = "Default-SQL-WestCentralUS"
	$locationName = "westcentralus"
	$serverName = "trgrie-ltr-server"
	$databaseName = "testdb2"
	$weeklyRetention1 = "P1W"
	$weeklyRetention2 = "P2W"
	$restoredDatabase = "testdb3"
	$databaseWithRemovableBackup = "testdb";

	# Basic Get Tests
	$backups = Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $locationName
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseName
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseName -BackupName $backups[0].BackupName
	Assert-AreNotEqual $backups.Count 0

	# Test Get Piping
	$backups = Get-AzureRmSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName | Get-AzureRmSqlDatabaseLongTermRetentionBackup
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzureRmSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName | Get-AzureRmSqlDatabaseLongTermRetentionBackup -BackupName $backups[0].BackupName
	Assert-AreNotEqual $backups.Count 0

	# Test Get Optional Parameters
	$backups = Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseName -OnlyLatestPerDatabase -DatabaseState All
	Assert-AreNotEqual $backups.Count 0

	# Test Get Piping with Optional Parameters
	$backups = Get-AzureRmSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName | Get-AzureRmSqlDatabaseLongTermRetentionBackup -OnlyLatestPerDatabase
	Assert-AreNotEqual $backups.Count 0

	# Restore Test
	$backups = Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $locationName
	$db = Restore-AzureRmSqlDatabase -FromLongTermRetentionBackup -ResourceId $backups[0].ResourceId -ResourceGroupName $resourceGroup -ServerName $serverName -TargetDatabaseName $restoredDatabase
	Assert-AreEqual $db.DatabaseName $restoredDatabase

	# Test Remove with Piping
	#Get-AzureRmSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $removalDatabase -BackupName $backups[0].BackupName | Remove-AzureRmSqlDatabaseLongTermRetentionBackup
	$backups = Get-AzureRmSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseWithRemovableBackup | Get-AzureRmSqlDatabaseLongTermRetentionBackup -OnlyLatestPerDatabase
	Assert-AreEqual $backups.Count 0
}

function Test-DatabaseGeoBackupPolicy
{
	$rg = Get-AzureRmResourceGroup -ResourceGroupName alazad-rg
	$server = Get-AzureRmSqlServer -ServerName testsvr-alazad -ResourceGroupName $rg.ResourceGroupName
	$db = Get-AzureRmSqlDatabase -ServerName $server.ServerName -DatabaseName testdwdb -ResourceGroupName $rg.ResourceGroupName

	# Enable and verify
	Set-AzureRmSqlDatabaseGeoBackupPolicy -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -DatabaseName $db.DatabaseName -State Enabled
	$result = Get-AzureRmSqlDatabaseGeoBackupPolicy -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -DatabaseName $db.DatabaseName
	Assert-True { $result.State -eq "Enabled" }

	# Disable and verify
	Set-AzureRmSqlDatabaseGeoBackupPolicy -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -DatabaseName $db.DatabaseName -State Disabled
	$result = Get-AzureRmSqlDatabaseGeoBackupPolicy -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -DatabaseName $db.DatabaseName
	Assert-True { $result.State -eq "Disabled" }
}

function Test-NewDatabaseRestorePoint
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "servers" "West US 2"
	$serverVersion = "12.0";
	$label = "label01";
	$rg = Create-ResourceGroupForTest

	try
	{
		$server = Create-ServerForTest $rg $location

		# Create data warehouse database with all parameters.
		$databaseName = Get-DatabaseName
		$dwdb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100
			
		New-AzureRmSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -RestorePointLabel $label

		# Get restore points from data warehouse database.
		$restorePoints = Get-AzureRmSqlDatabaseRestorePoints -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName

		# We just created a restore point
		Assert-AreEqual $restorePoints.Count 1
		$restorePoint = $restorePoints[0]
		Assert-AreEqual $restorePoint.RestorePointType DISCRETE
		Assert-Null $restorePoint.EarliestRestoreDate
		Assert-AreEqual $restorePoint.RestorePointCreationDate.Kind Utc
		Assert-AreEqual $restorePoint.RestorePointLabel $label
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-RemoveDatabaseRestorePoint
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "servers" "West central US"
	$serverVersion = "12.0";
	$label = "label01";
	$rg = Create-ResourceGroupForTest

	try
	{
		$server = Create-ServerForTest $rg $location

		# Create data warehouse database with all parameters.
		$databaseName = Get-DatabaseName
		$dwdb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100
			
		New-AzureRmSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -RestorePointLabel $label

		# Get restore points from data warehouse database.
		$restorePoints = Get-AzureRmSqlDatabaseRestorePoints -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName

		# We just created a restore point
		Assert-AreEqual $restorePoints.Count 1
		$restorePoint = $restorePoints[0]
		Assert-AreEqual $restorePoint.RestorePointType DISCRETE
		Assert-Null $restorePoint.EarliestRestoreDate
		Assert-AreEqual $restorePoint.RestorePointCreationDate.Kind Utc

		Remove-AzureRmSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -RestorePointCreationDate $restorePoint.RestorePointCreationDate

	    # Get restore points from data warehouse database.
		$restorePoints = Get-AzureRmSqlDatabaseRestorePoints -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName

		# We just created a restore point
		Assert-AreEqual $restorePoints.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}