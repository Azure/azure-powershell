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
	$location = "southeastasia"
	$serverVersion = "12.0";
	$rg = Create-ResourceGroupForTest

	try
	{
		$server = Create-ServerForTest $rg $location

		# Create data warehouse database with all parameters.
		$databaseName = Get-DatabaseName
		$dwdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100c -Force

		$databaseName = Get-DatabaseName
		$standarddb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition Standard -RequestedServiceObjectiveName S0 -Force

		# Get restore points from data warehouse database.
		$restorePoints = Get-AzSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName
		Assert-Null $restorePoints # Since the data warehouse database has just been created, it should not have any discrete restore points.

		# Get restore points from standard database through pipe.
		$restorePoints = $standarddb | Get-AzSqlDatabaseRestorePoint 
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
	$location = "west europe"
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
	$location = "southeastasia"
	$serverVersion = "12.0"
	$rg = Create-ResourceGroupForTest
	$restoredDbName = "powershell_db_deleted"
	$restoredVcoreDbName = "powershell_db_deleted_vcore"

	try
	{
		$server = Create-ServerForTest $rg $location
	
		# Create a new sql database
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition GeneralPurpose -RequestedServiceObjectiveName GP_Gen5_2
	
		# Note: Uncomment below sleep if you are recording so that DB lives long enough to take full backup
		# Start-Sleep -s 600

		Remove-AzSqlDatabase -DatabaseName $databaseName -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -Force:$true
	
		$deletedDb = Get-AzSqlDeletedDatabaseBackup -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
	
		# restore to a db same as the deleted db
		Restore-AzSqlDatabase -FromDeletedDatabaseBackup -TargetDatabaseName $restoredDbName -DeletionDate $deletedDb[0].DeletionDate -ResourceGroupName $deletedDb[0].ResourceGroupName -ServerName $deletedDb[0].ServerName -ResourceId $deletedDb[0].ResourceId
	
		# restore to a vcore db
		Restore-AzSqlDatabase -FromDeletedDatabaseBackup -TargetDatabaseName $restoredVcoreDbName -DeletionDate $deletedDb[0].DeletionDate -ResourceGroupName $deletedDb[0].ResourceGroupName -ServerName $deletedDb[0].ServerName -ResourceId $deletedDb[0].ResourceId -Edition "GeneralPurpose" -VCore 2 -ComputeGeneration "Gen5"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

function Test-RestorePointInTimeBackup
{
	# Setup
	$location = "west europe"
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
	$location = "west europe"
	$serverVersion = "12.0"
	$rg = Get-AzResourceGroup -ResourceGroupName "brandong-test"
	$server = Get-AzSqlServer -ServerName "brandong-ltr-test" -ResourceGroupName $rg.ResourceGroupName
	$restoredDbName = "powershell_db_restored_ltr"
	$recoveryPointResourceId = "/subscriptions/e5e8af86-2d93-4ebd-8eb5-3b0184daa9de/resourceGroups/hchung/providers/Microsoft.RecoveryServices/vaults/hchung-testvault/backupFabrics/Azure/protectionContainers/AzureSqlContainer;Sql;hchung;hchung-testsvr/protectedItems/AzureSqlDb;dsName;hchung-testdb;fbf5641f-77f8-43b7-8fd7-5338ec293213/recoveryPoints/1731556986347"

    Restore-AzSqlDatabase -FromLongTermRetentionBackup -ResourceId $recoveryPointResourceId -TargetDatabaseName $restoredDbName `
		-ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
}

function Test-LongTermRetentionV2Policy($location = "southeastasia")
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "servers" "west europe"
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	$weeklyRetention1 = "P1W"
	$weeklyRetention2 = "P2W"
	$emptyRetention = "PT0S"

	try
	{
		# Create with default values
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Force

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

function Test-LongTermRetentionV2Backup($location = "southeastasia")
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "servers" "west europe"
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create with default values
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Force
		
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

function Test-LongTermRetentionV2ResourceGroupBasedBackup($location = "southeastasia")
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "servers" "west europe"
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create with default values
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Force
		
		# Basic Get Tests
		Get-AzSqlDatabaseLongTermRetentionBackup -Location $db.Location -ResourceGroupName $server.ResourceGroupName
		# Can't assert because we can't guarantee that the subscription won't have any backups in the location.
		$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $db.Location -ServerName $server.ServerName -ResourceGroupName $server.ResourceGroupName
		$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $db.Location -ServerName $server.ServerName -DatabaseName $databaseName -BackupName * -ResourceGroupName $server.ResourceGroupName
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
	$resourceGroup = "brandong-test"
	$locationName = "eastus"
	$serverName = "brandong-ltr-test"
	$databaseName = "testltr"
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

function Test-LongTermRetentionV2ResourceGroupBased
{

	# MANUAL INSTRUCTIONS
	# Create a server and database and fill in the appropriate information below
	# Set the weekly retention on the database so that the first backup gets picked up, for example:
	# Set-AzSqlDatabaseLongTermRetentionPolicy -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName -WeeklyRetention P1W
	# Wait about 18 hours until it gets properly copied and you see the backup when run get backups, for example:
	# Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaeName $databaseName -ResourceGroupName $resourceGroup
	$resourceGroup = "brandong-test"
	$locationName = "eastus"
	$serverName = "brandong-ltr-test"
	$databaseName = "testltr"
	$restoredDatabase = "mydb_restore"
	$databaseWithRemovableBackup = "testdb";

	# Basic Get Tests
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ResourceGroupName $resourceGroup
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -ResourceGroupName $resourceGroup
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseName -ResourceGroupName $resourceGroup
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseName -BackupName $backups[0].BackupName -ResourceGroupName $resourceGroup
	Assert-AreNotEqual $backups.Count 0

	# Test Get Piping
	$backups = Get-AzSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName | Get-AzSqlDatabaseLongTermRetentionBackup
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName | Get-AzSqlDatabaseLongTermRetentionBackup -BackupName $backups[0].BackupName
	Assert-AreNotEqual $backups.Count 0

	# Test Get Optional Parameters
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseName -ResourceGroupName $resourceGroup -OnlyLatestPerDatabase -DatabaseState All
	Assert-AreNotEqual $backups.Count 0

	# Test Get Piping with Optional Parameters
	$backups = Get-AzSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName | Get-AzSqlDatabaseLongTermRetentionBackup -OnlyLatestPerDatabase
	Assert-AreNotEqual $backups.Count 0

	# Restore Test
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ResourceGroupName $resourceGroup
	$db = Restore-AzSqlDatabase -FromLongTermRetentionBackup -ResourceId $backups[0].ResourceId -ResourceGroupName $resourceGroup -ServerName $serverName -TargetDatabaseName $restoredDatabase
	Assert-AreEqual $db.DatabaseName $restoredDatabase

	# Test Remove with Piping
	Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseWithRemovableBackup -BackupName $backups[0].BackupName -ResourceGroupName $resourceGroup | Remove-AzSqlDatabaseLongTermRetentionBackup -Force

	# drop the restored db
	Remove-AzSqlDatabase -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $restoredDatabase -Force
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
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100c
			
		New-AzSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -RestorePointLabel $label

		# Get restore points from data warehouse database.
		$restorePoints = Get-AzSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName

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
	$location = Get-Location "Microsoft.Sql" "servers" "west europe"
	$serverVersion = "12.0";
	$label = "label01";
	$rg = Create-ResourceGroupForTest

	try
	{
		$server = Create-ServerForTest $rg $location

		# Create data warehouse database with all parameters.
		$databaseName = Get-DatabaseName
		$dwdb = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100 -Force
			
		New-AzSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -RestorePointLabel $label

		# Get restore points from data warehouse database.
		$restorePoints = Get-AzSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName

		# We just created a restore point
		Assert-AreEqual $restorePoints.Count 1
		$restorePoint = $restorePoints[0]
		Assert-AreEqual $restorePoint.RestorePointType DISCRETE
		Assert-Null $restorePoint.EarliestRestoreDate
		Assert-AreEqual $restorePoint.RestorePointCreationDate.Kind Utc

		Remove-AzSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -RestorePointCreationDate $restorePoint.RestorePointCreationDate

		Wait-Seconds 60
	    # Get restore points from data warehouse database.
		$restorePoints = Get-AzSqlDatabaseRestorePoint -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName

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
	$location = "westus2"
	$rg = "WestUS2ResourceGroup"
	$server = "lillian-westus2-server"

 	try
	{
		# Create db with default values
		$databaseName = Get-DatabaseName
		$db = New-AzSqlDatabase -ResourceGroupName $rg -ServerName $server -DatabaseName $databaseName -Force:$true

		# Test GET default values. 
		$defaultRetention = 7
		# After we configure Backup Service's default DiffBackupIntervalInHours to 24 hours for new created databases, $defaultDiffbackupinterval should be changed to 24.
		$defaultDiffbackupinterval = 12
		$policy = Get-AzSqlDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg -ServerName $server -DatabaseName $databaseName
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $defaultRetention $policy[0].RetentionDays
		Assert-AreEqual $defaultDiffbackupinterval $policy[0].DiffBackupIntervalInHours

 		# Test SET
		$retention = 6
		$diffbackupinterval = 24
		$policy = Set-AzSqlDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg -ServerName $server -DatabaseName $databaseName -RetentionDays $retention -DiffBackupIntervalInHours $diffbackupinterval
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retention $policy[0].RetentionDays
		Assert-AreEqual $diffbackupinterval $policy[0].DiffBackupIntervalInHours

		$retentionOnly = 5
		$policy = Set-AzSqlDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg -ServerName $server -DatabaseName $databaseName -RetentionDays $retentionOnly
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retentionOnly $policy[0].RetentionDays
		Assert-AreEqual $diffbackupinterval $policy[0].DiffBackupIntervalInHours

		$diffbackupintervalOnly = 12
		$policy = Set-AzSqlDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg -ServerName $server -DatabaseName $databaseName -DiffBackupIntervalInHours $diffbackupintervalOnly
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retentionOnly $policy[0].RetentionDays
		Assert-AreEqual $diffbackupintervalOnly $policy[0].DiffBackupIntervalInHours
		
 		# Test InputObject
		$retention = 7
		$diffbackupinterval = 24
		$policy = Set-AzSqlDatabaseBackupShortTermRetentionPolicy -AzureSqlDatabase $db -RetentionDays $retention -DiffBackupIntervalInHours $diffbackupinterval
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays
		Assert-AreEqual $diffbackupinterval $policy[0].DiffBackupIntervalInHours
		$policy = Get-AzSqlDatabaseBackupShortTermRetentionPolicy -AzureSqlDatabase $db
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays
		Assert-AreEqual $diffbackupinterval $policy[0].DiffBackupIntervalInHours

 		# Test ResourceId
		$retention = 6
		$diffbackupinterval = 12
		$resourceId = $db.ResourceId + "/backupShortTermRetentionPolicies/default"
		$policy = Set-AzSqlDatabaseBackupShortTermRetentionPolicy -ResourceId $resourceId -RetentionDays $retention -DiffBackupIntervalInHours $diffbackupinterval
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays
		Assert-AreEqual $diffbackupinterval $policy[0].DiffBackupIntervalInHours
		$policy = Get-AzSqlDatabaseBackupShortTermRetentionPolicy -ResourceId $resourceId
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays
		Assert-AreEqual $diffbackupinterval $policy[0].DiffBackupIntervalInHours

 		# Test Piping
		$retention = 7
		$diffbackupinterval = 24
		$policy = $db | Set-AzSqlDatabaseBackupShortTermRetentionPolicy -RetentionDays $retention -DiffBackupIntervalInHours $diffbackupinterval
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays
		Assert-AreEqual $diffbackupinterval $policy[0].DiffBackupIntervalInHours
		$policy = $db | Get-AzSqlDatabaseBackupShortTermRetentionPolicy
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy[0].RetentionDays
		Assert-AreEqual $diffbackupinterval $policy[0].DiffBackupIntervalInHours
 	}
	finally
	{
		Remove-AzSqlDatabase -ResourceGroupName $rg -ServerName $server -DatabaseName $databaseName
	}
}

function Test-CopyLongTermRetentionBackup
{
	# MANUAL INSTRUCTIONS
	# Create a server and database and fill in the appropriate information below
	# Set the weekly retention on the database so that the first backup gets picked up, for example:
	# Set-AzSqlDatabaseLongTermRetentionPolicy -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName -WeeklyRetention P1W
	# Wait about 18 hours until it gets properly copied and you see the backup when run get backups, for example:
	# Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaseName $databaseName -ResourceGroupName $resourceGroup
	$sourceResourceGroupName = "testrg"
	$targetResourceGroupName = "testrg"
	$sourceLocationName = "eastasia"
	$sourceServerName = "ayang-eas"
	$targetLocationName = "southeastasia"
	$targetServerName= "ayang-stage-seas"
	$targetDatabaseName = "tgt-ltr1"

	# Retrieve a backup to copy
	$sourceBackups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $sourceLocationName 
	Assert-AreNotEqual $sourceBackups.Count 0
	$sourceBackup = $sourceBackups[0]

	# Copy backup
	$copyBackupResults = Copy-AzSqlDatabaseLongTermRetentionBackup -Location $sourceLocationName -ServerName $sourceBackup.ServerName -DatabaseName $sourceBackup.DatabaseName -BackupName $sourceBackup.BackupName -ResourceGroupName $sourceResourceGroupName -TargetDatabaseName $targetDatabaseName -TargetServerName $TargetServerName -TargetSubscriptionId '01c4ec88-e179-44f7-9eb0-e9719a5087ab' -TargetResourceGroupName $targetResourceGroupName
	$targetBackup = Get-AzSqlDatabaseLongTermRetentionBackup -Location $copyBackupResults.TargetLocation -ResourceGroup $copyBackupResults.TargetResourceGroupName -ServerName $copyBackupResults.TargetServerName -DatabaseName $copyBackupResults.TargetDatabaseName -BackupName $copyBackupResults.TargetBackupName
	Assert-AreEqual $targetDatabaseName $targetBackup.DatabaseName 
	Assert-AreEqual $targetServerName $targetBackup.ServerName
}

function Test-UpdateLongTermRetentionBackup
{
	# MANUAL INSTRUCTIONS
	# Create a server and database and fill in the appropriate information below
	# Set the weekly retention on the database so that the first backup gets picked up, for example:
	# Set-AzSqlDatabaseLongTermRetentionPolicy -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName -WeeklyRetention P1W
	# Wait about 18 hours until it gets properly copied and you see the backup when run get backups, for example:
	# Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaeName $databaseName -ResourceGroupName $resourceGroup
	$resourceGroupName = "testrg"
	$locationName = "eastasia"
	$serverName = "ayang-eas"
	$databaseName = "ltr1"

	# Fetch a backup
	$backups = Get-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ResourceGroupName $resourceGroupName -ServerName $serverName -DatabaseName $databaseName
	$backup = $backups[0]

	# Change backup storage redundancy of database, so LTR backup's backup storage redundancy can be changed 
	# LTR backup's backup storage redundancy must match database's backup storage redundancy
	# Use a backup storage redundancy different from the CurrentBackupStorageRedundancy value in Get-AzSqlDatabase
	Set-AzSqlDatabase -DatabaseName $databaseName -ServerName $serverName -ResourceGroupName $resourceGroupName -BackupStorageRedundancy Local

	# Change backup's backup storage redundancy 
	$backupAfterSet = Update-AzSqlDatabaseLongTermRetentionBackup -Location $locationName -ServerName $backup.ServerName -DatabaseName $backup.DatabaseName -BackupName $backup.BackupName -ResourceGroupName $backup.ResourceGroupName -BackupStorageRedundancy Local

	# Update-AzSqlDatabaseLongTermRetentionBackup returns after target BSR is set
	Assert-AreEqual "Local" $backupAfterSet.BackupStorageRedundancy 
}

<#
	.SYNOPSIS
	Tests restoring a vldb with source zone redundant == false
	1. Restore source vldb passing in zone redundant == true and backup storage redundancy == Zone,
	   Verify restored vldb has zone redundant == true and backup storage redundancy == Zone
	2. Restore source vldb with no parameters passed in,
	   Verify restored vldb has zone redundant == false and backup storage redundancy == Geo
#>
function Test-CreateRestoreRegularAndZoneRedundantDatabaseWithSourceNotZoneRedundant()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$sourceNonZRDatabaseName = Get-DatabaseName + "-non-zr"

	$restoreTrueZRParamDatabaseName = $sourceNonZRDatabaseName + "-source-non-zr-restore-zr-true"
	$restoreNoZRParamDatabaseName = $sourceNonZRDatabaseName + "-source-non-zr-restore-no-zr-param"

	try
	{
		# Create source vldb
		$sourceNonZRDatabase = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceNonZRDatabaseName `
		 -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType "LicenseIncluded"

		# Verify created source vldb has correct values (specifically zone redundancy == false and backup storage redundancy == Geo)
		Assert-AreEqual $sourceNonZRDatabase.ServerName $server.ServerName
		Assert-AreEqual $sourceNonZRDatabase.DatabaseName $sourceNonZRDatabaseName
		Assert-AreEqual $sourceNonZRDatabase.Edition "Hyperscale"
		Assert-AreEqual $sourceNonZRDatabase.CurrentBackupStorageRedundancy "Geo"
		Assert-NotNull  $sourceNonZRDatabase.ZoneRedundant 
		Assert-False    { $sourceNonZRDatabase.ZoneRedundant }

		# Get current time for PITR
		$time = Get-Date
		$utcTime = $Time.ToUniversalTime()
		$pitrTime = $utcTime.ToString("yyyy-MM-ddTHH:mm:ssZ")

		# Restore source vldb with zone redundancy == true and backup storage redundancy == Zone
		$restoreTrueZRParamDatabase = Restore-AzSqlDatabase -FromPointInTimeBackup -PointInTime $pitrTime -TargetDatabaseName $restoreTrueZRParamDatabaseName -ResourceGroupName $rg.ResourceGroupName `
		-ServerName $server.ServerName -ResourceId $sourceNonZRDatabase.ResourceId -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -BackupStorageRedundancy "Zone" -ZoneRedundant

		# Verify restored vldb has correct values (specifically zone redundancy == true and backup storage redundancy == Zone)
		Assert-AreEqual $restoreTrueZRParamDatabase.ServerName $server.ServerName
		Assert-AreEqual $restoreTrueZRParamDatabase.DatabaseName $restoreTrueZRParamDatabaseName
		Assert-AreEqual $restoreTrueZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $restoreTrueZRParamDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $restoreTrueZRParamDatabase.ZoneRedundant 
		Assert-True     { $restoreTrueZRParamDatabase.ZoneRedundant }

		# Restore source vldb with no parameters passed in
		$restoreNoZRParamDatabase = Restore-AzSqlDatabase -FromPointInTimeBackup -PointInTime $pitrTime -TargetDatabaseName $restoreNoZRParamDatabaseName -ResourceGroupName $rg.ResourceGroupName `
		-ServerName $server.ServerName -ResourceId $sourceNonZRDatabase.ResourceId

		# Verify restored vldb has correct values (specifically zone redundancy == false and backup storage redundancy == Geo)
		Assert-AreEqual $restoreNoZRParamDatabase.ServerName $server.ServerName
		Assert-AreEqual $restoreNoZRParamDatabase.DatabaseName $restoreNoZRParamDatabaseName
		Assert-AreEqual $restoreNoZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $restoreNoZRParamDatabase.CurrentBackupStorageRedundancy "Geo"
		Assert-NotNull  $restoreNoZRParamDatabase.ZoneRedundant 
		Assert-False    { $restoreNoZRParamDatabase.ZoneRedundant }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests restoring a vldb with source zone redundant == true and backup storage redundancy == Zone
	1. Restore source vldb passing in zone redundant == false and backup storage redundancy == Zone,
	   Verify restored vldb has zone redundant == false and backup storage redundancy == Zone
	2. Restore source vldb with no parameters passed in,
	   Verify restored vldb has zone redundant == true and backup storage redundancy == Zone
#>
function Test-CreateRestoreRegularAndZoneRedundantDatabaseWithSourceZoneRedundant()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$sourceZRDatabaseName = Get-DatabaseName + "-zr"

	$restoreFalseZRParamDatabaseName = $sourceZRDatabaseName + "-source-zr-restore-zr-false"
	$restoreNoZRParamDatabaseName = $sourceZRDatabaseName + "-source-zr-restore-no-zr-param"

	try
	{
		# Create source vldb with zone redundancy == true and backup storage redundancy == Zone
		$sourceZRDatabase = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceZRDatabaseName `
		 -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType "LicenseIncluded" -BackupStorageRedundancy "Zone" -ZoneRedundant

		# Verify created source vldb has correct values (specifically zone redundancy == true and backup storage redundancy == Zone)
		Assert-AreEqual $sourceZRDatabase.ServerName $server.ServerName
		Assert-AreEqual $sourceZRDatabase.DatabaseName $sourceZRDatabaseName
		Assert-AreEqual $sourceZRDatabase.Edition "Hyperscale"
		Assert-AreEqual $sourceZRDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $sourceZRDatabase.ZoneRedundant 
		Assert-True     { $sourceZRDatabase.ZoneRedundant }

		# Get current time for PITR
		$time = Get-Date
		$utcTime = $Time.ToUniversalTime()
		$pitrTime = $utcTime.ToString("yyyy-MM-ddTHH:mm:ssZ")

		# Copy source vldb with zone redundancy == false
		$restoreFalseZRParamDatabase = Restore-AzSqlDatabase -FromPointInTimeBackup -PointInTime $pitrTime -TargetDatabaseName $restoreFalseZRParamDatabaseName -ResourceGroupName $rg.ResourceGroupName `
		-ServerName $server.ServerName -ResourceId $sourceZRDatabase.ResourceId -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -ZoneRedundant:$false
		
		# Verify restored vldb has correct values (specifically zone redundancy == false and backup storage redundancy == Zone)
		Assert-AreEqual $restoreFalseZRParamDatabase.ServerName $server.ServerName
		Assert-AreEqual $restoreFalseZRParamDatabase.DatabaseName $restoreFalseZRParamDatabaseName
		Assert-AreEqual $restoreFalseZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $restoreFalseZRParamDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $restoreFalseZRParamDatabase.ZoneRedundant 
		Assert-False    { $restoreFalseZRParamDatabase.ZoneRedundant }

		# Restore source vldb with no parameters passed in
		$restoreNoZRParamDatabase = Restore-AzSqlDatabase -FromPointInTimeBackup -PointInTime $pitrTime -TargetDatabaseName $restoreNoZRParamDatabaseName -ResourceGroupName $rg.ResourceGroupName `
		-ServerName $server.ServerName -ResourceId $sourceZRDatabase.ResourceId

		# Verify restored vldb has correct values (specifically zone redundancy == true and backup storage redundancy == Zone)
		Assert-AreEqual $restoreNoZRParamDatabase.ServerName $server.ServerName
		Assert-AreEqual $restoreNoZRParamDatabase.DatabaseName $restoreNoZRParamDatabaseName
		Assert-AreEqual $restoreNoZRParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $restoreNoZRParamDatabase.CurrentBackupStorageRedundancy "Zone"
		Assert-NotNull  $restoreNoZRParamDatabase.ZoneRedundant 
		Assert-True     { $restoreNoZRParamDatabase.ZoneRedundant }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	1. Restore source vldb with source backup storage redundancy == Zone passing in backup storage redundancy == GeoZone,
	   Verify restored vldb has backup storage redundancy == GeoZone
	2. Restore source vldb with source backup storage redundancy == GeoZone without passing in backup storage redundancy,
	   Verify restored vldb has backup storage redundancy == GeoZone
#>
function Test-CreateRestoreWithZonetoGeoZoneBackupStorageRedundancy()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Brazil South"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$db = Get-DatabaseName
	$sourceZoneDatabaseName = $db + "-zrs"
	$sourceGeoZoneDatabaseName = $db + "-ragzrs"

	$restoreZonetoGeoZoneDatabaseName = $sourceZoneDatabaseName + "-restore-zrs"
	$restoreGeoZoneToNoneDatabaseName = $sourceGeoZoneDatabaseName + "-restore-ragzrs"

	try
	{
		# Test 1
		# Create source vldb with and backup storage redundancy == Zone
		$sourceZoneDatabase = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceZoneDatabaseName `
		 -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType "LicenseIncluded" -BackupStorageRedundancy "Zone"

		# Verify created source vldb has correct values
		Assert-AreEqual $sourceZoneDatabase.ServerName $server.ServerName
		# Assert-AreEqual $sourceZoneDatabase.name $sourceZRDatabaseName
		Assert-AreEqual $sourceZoneDatabase.Edition "Hyperscale"
		Assert-AreEqual $sourceZoneDatabase.CurrentBackupStorageRedundancy "Zone"

		# Get current time for PITR
		$time = Get-Date
		$utcTime = $Time.ToUniversalTime()
		$pitrTime = $utcTime.ToString("yyyy-MM-ddTHH:mm:ssZ")

		# Copy source vldb
		$restoreZonetoGeoZoneParamDatabase = Restore-AzSqlDatabase -FromPointInTimeBackup -PointInTime $pitrTime -TargetDatabaseName $restoreZonetoGeoZoneDatabaseName -ResourceGroupName $rg.ResourceGroupName `
		-ServerName $server.ServerName -ResourceId $sourceZoneDatabase.ResourceId -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -BackupStorageRedundancy "GeoZone"
		
		# Verify restored vldb has correct values 
		Assert-AreEqual $restoreZonetoGeoZoneParamDatabase.ServerName $server.ServerName
		# Assert-AreEqual $restoreZonetoGeoZoneParamDatabase.DatabaseName $restoreFalseZRParamDatabaseName
		Assert-AreEqual $restoreZonetoGeoZoneParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $restoreZonetoGeoZoneParamDatabase.CurrentBackupStorageRedundancy "GeoZone"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	1. Restore source vldb with source backup storage redundancy == GeoZone without passing in backup storage redundancy,
	   Verify restored vldb has backup storage redundancy == GeoZone
#>
function Test-CreateRestoreWithGeoZoneBackupStorageRedundancy()
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Brazil South"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	$db = Get-DatabaseName
	$sourceZoneDatabaseName = $db + "-zrs"
	$sourceGeoZoneDatabaseName = $db + "-ragzrs"

	$restoreZonetoGeoZoneDatabaseName = $sourceZoneDatabaseName + "-restore-zrs"
	$restoreGeoZoneToNoneDatabaseName = $sourceGeoZoneDatabaseName + "-restore-ragzrs"

	try
	{
		# Create source vldb with and backup storage redundancy == GeoZone
		$sourceGeoZoneDatabase = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $sourceGeoZoneDatabaseName `
		 -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale -LicenseType "LicenseIncluded" -BackupStorageRedundancy "GeoZone"

		# Verify created source vldb has correct values
		Assert-AreEqual $sourceGeoZoneDatabase.ServerName $server.ServerName
		# Assert-AreEqual $sourceGeoZoneDatabase.DatabaseName $sourceZRDatabaseName
		Assert-AreEqual $sourceGeoZoneDatabase.Edition "Hyperscale"
		Assert-AreEqual $sourceGeoZoneDatabase.CurrentBackupStorageRedundancy "GeoZone"

		# Get current time for PITR
		$time = Get-Date
		$utcTime = $Time.ToUniversalTime()
		$pitrTime = $utcTime.ToString("yyyy-MM-ddTHH:mm:ssZ")

		# Copy source vldb
		$restoreGeoZonetoNoneParamDatabase = Restore-AzSqlDatabase -FromPointInTimeBackup -PointInTime $pitrTime -TargetDatabaseName $restoreGeoZoneToNoneDatabaseName -ResourceGroupName $rg.ResourceGroupName `
		-ServerName $server.ServerName -ResourceId $sourceGeoZoneDatabase.ResourceId -VCore 2 -ComputeGeneration Gen5 -Edition Hyperscale
		
		# Verify restored vldb has correct values
		Assert-AreEqual $restoreGeoZonetoNoneParamDatabase.ServerName $server.ServerName
		# Assert-AreEqual $restoreGeoZonetoNoneParamDatabase.DatabaseName $restoreFalseZRParamDatabaseName
		Assert-AreEqual $restoreGeoZonetoNoneParamDatabase.Edition "Hyperscale"
		Assert-AreEqual $restoreGeoZonetoNoneParamDatabase.CurrentBackupStorageRedundancy "GeoZone"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}