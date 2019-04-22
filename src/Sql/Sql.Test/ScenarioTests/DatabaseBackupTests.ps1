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
	$location = "Southeast Asia"
	$serverVersion = "12.0";
	$rg = Create-ResourceGroupForTest

	try
	{
		$server = Create-ServerForTest $rg $location

		# Create data warehouse database with all parameters.
		$databaseName = Get-DatabaseName
		$dwdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100

		$databaseName = Get-DatabaseName
		$standarddb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition Standard -RequestedServiceObjectiveName S0

		# Get restore points from data warehouse database.
		$restorePoints = Get-AzSqlDatabaseRestorePoints -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName
		Assert-Null $restorePoints # Since the data warehouse database has just been created, it should not have any discrete restore points.

		# Get restore points from standard database through pipe.
		$restorePoints = $standarddb | Get-AzSqlDatabaseRestorePoints 
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
	$rg = Get-AzResourceGroup -ResourceGroupName payi-test
	$server = Get-AzSqlServer -ServerName payi-testsvr -ResourceGroupName $rg.ResourceGroupName
	$db = Get-AzSqlDatabase -ServerName $server.ServerName -DatabaseName payi-testdb-geo2 -ResourceGroupName $rg.ResourceGroupName
	$restoredDbName = "powershell_db_georestored2"
	$restoredVcoreDbName = "powershell_db_georestored_vcore"

	$geobackup = Get-AzSqlDatabaseGeoBackup -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -DatabaseName $db.DatabaseName 
	# Restore to a same db as it in geo backup
	$job = Restore-AzSqlDatabase -FromGeoBackup -TargetDatabaseName $restoredDbName -ResourceGroupName $geobackup.ResourceGroupName `
		-ServerName $geobackup.ServerName -ResourceId $geobackup.ResourceId -AsJob
	$job | Wait-Job

	# restore to a vcore db using geobackup
	Restore-AzSqlDatabase -FromGeoBackup -TargetDatabaseName $restoredVcoreDbName -ResourceGroupName $geobackup.ResourceGroupName `
		-ServerName $geobackup.ServerName -ResourceId $geobackup.ResourceId -Edition "GeneralPurpose" -VCore 2 -ComputeGeneration "Gen4"
}

function Test-RestoreDeletedDatabaseBackup
{
	# Setup
	$location = "Southeast Asia"
	$serverVersion = "12.0"
	$rg = Get-AzResourceGroup -ResourceGroupName payi-test
	$server = Get-AzSqlServer -ServerName payi-testsvr -ResourceGroupName $rg.ResourceGroupName
	$droppedDbName = "powershell_db_georestored"
	$restoredDbName = "powershell_db_deleted"
	$restoredVcoreDbName = "powershell_db_deleted_vcore"

	# this Get command has regression in MS when specifying Deletiondate. Fix should be in Prod by 5/7/2018. so currently use another way to do testing
	$deletedDb = Get-AzSqlDeletedDatabaseBackup -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName `
		-DatabaseName $droppedDbName #-DeletionDate "2018-04-20 20:21:37.397Z" 

	# restore to a db same as the deleted db
	Restore-AzSqlDatabase -FromDeletedDatabaseBackup -TargetDatabaseName $restoredDbName -DeletionDate "2018-04-20 20:21:37.397Z" `
		-ResourceGroupName $deletedDb[0].ResourceGroupName -ServerName $deletedDb[0].ServerName -ResourceId $deletedDb[0].ResourceId
	
	# restore to a vcore db
	Restore-AzSqlDatabase -FromDeletedDatabaseBackup -TargetDatabaseName $restoredVcoreDbName -DeletionDate "2018-04-20 20:21:37.397Z" `
		-ResourceGroupName $deletedDb[0].ResourceGroupName -ServerName $deletedDb[0].ServerName -ResourceId $deletedDb[0].ResourceId -Edition "GeneralPurpose" `
		-VCore 2 -ComputeGeneration "Gen4"
}

function Test-RestorePointInTimeBackup
{
	# Setup
	$location = "Southeast Asia"
	$serverVersion = "12.0"
	$rg = Get-AzResourceGroup -ResourceGroupName payi-test
	$server = Get-AzSqlServer -ServerName payi-testsvr -ResourceGroupName $rg.ResourceGroupName
	$db = Get-AzSqlDatabase -ServerName $server.ServerName -DatabaseName payi-testdb -ResourceGroupName $rg.ResourceGroupName
	$restoredDbName = "powershell_db_restored"
	$restoredVcoreDbName = "powershell_db_restored_vcore"

	# Restore to same with source db
	Restore-AzSqlDatabase -FromPointInTimeBackup -PointInTime "2018-04-18T20:20:00Z" -TargetDatabaseName $restoredDbName -ResourceGroupName $db.ResourceGroupName `
	-ServerName $db.ServerName -ResourceId $db.ResourceId

	# Restore to a Vcore db
	Restore-AzSqlDatabase -FromPointInTimeBackup -PointInTime "2018-04-18T20:20:00Z" -TargetDatabaseName $restoredVcoreDbName -ResourceGroupName $db.ResourceGroupName `
		-ServerName $db.ServerName -ResourceId $db.ResourceId -Edition 'GeneralPurpose' -VCore 2 -ComputeGeneration 'Gen4'
}

# LTR-V1 restore tests need to be removed once the service is retired completely
# TODO update for LTRv2 backup
function Test-RestoreLongTermRetentionBackup
{
	$location = "North Europe"
	$serverVersion = "12.0"
	$rg = Get-AzResourceGroup -ResourceGroupName hchung
	$server = Get-AzSqlServer -ServerName hchung-testsvr -ResourceGroupName $rg.ResourceGroupName
	$restoredDbName = "powershell_db_restored_ltr"
	$recoveryPointResourceId = "/subscriptions/e5e8af86-2d93-4ebd-8eb5-3b0184daa9de/resourceGroups/hchung/providers/Microsoft.RecoveryServices/vaults/hchung-testvault/backupFabrics/Azure/protectionContainers/AzureSqlContainer;Sql;hchung;hchung-testsvr/protectedItems/AzureSqlDb;dsName;hchung-testdb;fbf5641f-77f8-43b7-8fd7-5338ec293213/recoveryPoints/1731556986347"

    Restore-AzSqlDatabase -FromLongTermRetentionBackup -ResourceId $recoveryPointResourceId -TargetDatabaseName $restoredDbName `
		-ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
}

function Test-LongTermRetentionV2Policy($location = "westcentralus")
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "servers" "West central US"
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	$weeklyRetention1 = "P1W"
	$weeklyRetention2 = "P2W"
	$emptyRetention = "PT0S"

	try
	{
		# Create with default values
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

		# Basic Policy Test
		Set-AzSqlDatabaseLongTermRetentionPolicy -ResourceGroup $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -WeeklyRetention $weeklyRetention2
		$policy = Get-AzSqlDatabaseLongTermRetentionPolicy -ResourceGroup $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
		Assert-AreEqual $policy.WeeklyRetention $weeklyRetention2
		Assert-AreEqual $policy.MonthlyRetention $emptyRetention
		Assert-AreEqual $policy.YearlyRetention $emptyRetention

		# Alias Policy Test
		Set-AzSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroup $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -WeeklyRetention $weeklyRetention1
		$policy = Get-AzSqlDatabaseBackupLongTermRetentionPolicy -ResourceGroup $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
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
	$location = Get-Location "Microsoft.Sql" "servers" "West central US"
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create with default values
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
		
		# Basic Get Tests
		Get-AzSqlDatabaseLongTermRetentionBackup -Location $db.Location
		# Can't assert because we can't guarantee that the subscription won't have any backups in the location.
		$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $db.Location -ServerName $server.ServerName
		Assert-AreEqual $backups.Count 0
		$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $db.Location -ServerName $server.ServerName -DatabaseName $databaseName -BackupName *
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
	# Set-AzSqlDatabaseLongTermRetentionPolicy -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName -WeeklyRetention P1W
	# Wait about 18 hours until it gets properly copied and you see the backup when run get backups, for example:
	# Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaeName $databaseName
	$resourceGroup = "Default-SQL-WestCentralUS"
	$locationName = "westcentralus"
	$serverName = "trgrie-ltr-server"
	$databaseName = "testdb2"
	$weeklyRetention1 = "P1W"
	$weeklyRetention2 = "P2W"
	$restoredDatabase = "testdb5"
	$databaseWithRemovableBackup = "testdb";

	# Basic Get Tests
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseName
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseName -BackupName $backups[0].BackupName
	Assert-AreNotEqual $backups.Count 0

	# Test Get Piping
	$backups = Get-AzSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName | Get-AzSqlDatabaseLongTermRetentionBackup
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName | Get-AzSqlDatabaseLongTermRetentionBackup -BackupName $backups[0].BackupName
	Assert-AreNotEqual $backups.Count 0

	# Test Get Optional Parameters
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseName -OnlyLatestPerDatabase -DatabaseState All
	Assert-AreNotEqual $backups.Count 0

	# Test Get Piping with Optional Parameters
	$backups = Get-AzSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName | Get-AzSqlDatabaseLongTermRetentionBackup -OnlyLatestPerDatabase
	Assert-AreNotEqual $backups.Count 0

	# Restore Test
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName
	$db = Restore-AzSqlDatabase -FromLongTermRetentionBackup -ResourceId $backups[0].ResourceId -ResourceGroupName $resourceGroup -ServerName $serverName -TargetDatabaseName $restoredDatabase
	Assert-AreEqual $db.DatabaseName $restoredDatabase

	# Test Remove with Piping
	#Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseWithRemovableBackup -BackupName $backups[0].BackupName | Remove-AzSqlDatabaseLongTermRetentionBackup
	$backups = Get-AzSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseWithRemovableBackup | Get-AzSqlDatabaseLongTermRetentionBackup -OnlyLatestPerDatabase
	Assert-AreEqual $backups.Count 0

	# drop the restored db
	Remove-AzSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $restoredDatabase
}

function Test-DatabaseGeoBackupPolicy
{
	$rg = Get-AzResourceGroup -ResourceGroupName payi-test
	$server = Get-AzSqlServer -ServerName payi-testsvr -ResourceGroupName $rg.ResourceGroupName
	$db = Get-AzSqlDatabase -ServerName $server.ServerName -DatabaseName testdwdb -ResourceGroupName $rg.ResourceGroupName

	# Enable and verify
	Set-AzSqlDatabaseGeoBackupPolicy -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -DatabaseName $db.DatabaseName -State Enabled
	$result = Get-AzSqlDatabaseGeoBackupPolicy -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -DatabaseName $db.DatabaseName
	Assert-True { $result.State -eq "Enabled" }

	# Disable and verify
	Set-AzSqlDatabaseGeoBackupPolicy -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -DatabaseName $db.DatabaseName -State Disabled
	$result = Get-AzSqlDatabaseGeoBackupPolicy -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -DatabaseName $db.DatabaseName
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
		$dwdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100
			
		New-AzSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -RestorePointLabel $label

		# Get restore points from data warehouse database.
		$restorePoints = Get-AzSqlDatabaseRestorePoints -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName

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
		$dwdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100
			
		New-AzSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -RestorePointLabel $label

		# Get restore points from data warehouse database.
		$restorePoints = Get-AzSqlDatabaseRestorePoints -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName

		# We just created a restore point
		Assert-AreEqual $restorePoints.Count 1
		$restorePoint = $restorePoints[0]
		Assert-AreEqual $restorePoint.RestorePointType DISCRETE
		Assert-Null $restorePoint.EarliestRestoreDate
		Assert-AreEqual $restorePoint.RestorePointCreationDate.Kind Utc

		Remove-AzSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -RestorePointCreationDate $restorePoint.RestorePointCreationDate

		Wait-Seconds 60
	    # Get restore points from data warehouse database.
		$restorePoints = Get-AzSqlDatabaseRestorePoints -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName

		# We just created a restore point
		Assert-AreEqual $restorePoints.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
	
function Test-ShortTermRetentionPolicy
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "servers" "West US 2"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

 	# Not divisible by 7, client should error
	$invalidRetention = 20

 	try
	{
		# Create db with default values
		$databaseName = Get-DatabaseName
		$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

 		# Test default parameter set
		$retention = 28
		$policy = Set-AzureRmSqlDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -RetentionDays $retention
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retention $policy[0].RetentionDays
		$policy = Get-AzureRmSqlDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retention $policy[0].RetentionDays

 		# Test InputObject
		$retention = 21
		$policy = Set-AzureRmSqlDatabaseBackupShortTermRetentionPolicy -AzureSqlDatabase $db -RetentionDays $retention
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays
		$policy = Get-AzureRmSqlDatabaseBackupShortTermRetentionPolicy -AzureSqlDatabase $db
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays

 		# Test ResourceId
		$retention = 14
		$resourceId = $db.ResourceId + "/backupShortTermRetentionPolicies/default"
		$policy = Set-AzureRmSqlDatabaseBackupShortTermRetentionPolicy -ResourceId $resourceId -RetentionDays $retention
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays
		$policy = Get-AzureRmSqlDatabaseBackupShortTermRetentionPolicy -ResourceId $resourceId
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays

 		# Test Piping
		$retention = 7
		$policy = $db | Set-AzureRmSqlDatabaseBackupShortTermRetentionPolicy -RetentionDays $retention
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays
		$policy = $db | Get-AzureRmSqlDatabaseBackupShortTermRetentionPolicy
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays

 		# Test client-side error handling
		try {
			$db | Set-AzureRmSqlDatabaseBackupShortTermRetentionPolicy -RetentionDays $invalidRetention
		}
		catch [System.Management.Automation.PSArgumentException] {
			# We expect an error here
			Assert-AreEqual $_.Count 1
		}
 	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}