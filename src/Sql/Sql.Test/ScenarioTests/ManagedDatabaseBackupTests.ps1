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
	Test short term retention for managed databases.
#>
function Test-ManagedLiveDatabaseShortTermRetentionPolicy
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

	# Retention shouldn't be under 7 days or over 35 days
	$invalidRetention = 45

 	try
	{
		# Create db with default values
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		$job1 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -Collation $collation -AsJob
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Collation
		Assert-NotNull $db.CreationDate

 		# Test default parameter set
		$retention = 28
		$policy = Set-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -DatabaseName $managedDatabaseName -RetentionDays $retention
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retention $policy.RetentionDays
		$policy = Get-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -DatabaseName $managedDatabaseName
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retention $policy.RetentionDays

 		# Test InputObject
		$retention = 21
		$policy = Set-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -AzureInstanceDatabaseObject $db[0] -RetentionDays $retention
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays
		$policy = Get-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -AzureInstanceDatabaseObject $db[0]
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays

 		# Test ResourceId
		$retention = 14
		$resourceId = $db.Id + "/backupShortTermRetentionPolicies/default"
		$policy = Set-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -ResourceId $resourceId -RetentionDays $retention
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays
		$policy = Get-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -ResourceId $resourceId
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays

 		# Test Piping
		$retention = 7
		$policy = $db | Set-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -RetentionDays $retention
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays
		$policy = $db | Get-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays
 	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Test LTR Policy functions for MI
#>
function Test-ManagedDeletedDatabaseShortTermRetentionPolicy
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName })[0].Id

	$managedInstance = Create-ManagedInstanceForTest $rg $subnetId

	# Retention shouldn't be under 7 days or over 35 days
	$invalidRetention = 45

 	try
	{
		# Create db with default values.
		$managedDatabaseName = Get-ManagedDatabaseName
		$collation = "SQL_Latin1_General_CP1_CI_AS"
		$job1 = New-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -Collation $collation -AsJob
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $db.Name $managedDatabaseName
		Assert-NotNull $db.Collation
		Assert-NotNull $db.CreationDate

 		# Test default parameter set.
		$retention = 35
		$policy = Set-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -DatabaseName $managedDatabaseName -RetentionDays $retention
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retention $policy.RetentionDays
		$policy = Get-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -DatabaseName $managedDatabaseName
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retention $policy.RetentionDays

		# Test remove using all parameters
		Remove-AzSqlInstanceDatabase -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -Name $managedDatabaseName -Force

		# Get deleted database
		$deletedDatabases = Get-AzSqlDeletedInstanceDatabaseBackup -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -DatabaseName $managedDatabaseName

 		# Set retention to 29, test default parameter providing.
		$retention = 29
		$policy = Set-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -DatabaseName $managedDatabaseName -DeletionDate $deletedDatabases[0].DeletionDate -RetentionDays $retention
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retention $policy.RetentionDays
		$policy = Get-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -ResourceGroupName $rg.ResourceGroupName -InstanceName $managedInstance.ManagedInstanceName -DatabaseName $managedDatabaseName -DeletionDate $deletedDatabases[0].DeletionDate
		Assert-AreEqual $policy.Count 1
		Assert-AreEqual $retention $policy.RetentionDays

 		# Test InputObject
		$retention = 21
		$policy = Set-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -AzureInstanceDatabaseObject $deletedDatabases[0] -RetentionDays $retention
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays
		$policy = Get-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -AzureInstanceDatabaseObject $deletedDatabases[0]
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays

 		# Test ResourceId
		$retention = 14
		$resourceId = $deletedDatabases[0].Id + "/backupShortTermRetentionPolicies/default"
		$policy = Set-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -ResourceId $resourceId -RetentionDays $retention
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays
		$policy = Get-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -ResourceId $resourceId
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays

 		# Test Piping
		$retention = 7
		$policy = $deletedDatabases[0] | Set-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy -RetentionDays $retention
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays
		$policy = $deletedDatabases[0] | Get-AzSqlInstanceDatabaseBackupShortTermRetentionPolicy
		Assert-AreEqual 1 $policy.Count
		Assert-AreEqual $retention $policy.RetentionDays
 	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
<#
	.SYNOPSIS
	Test long term retention for managed databases.
#>
function Test-ManagedInstanceLongTermRetentionPolicy()
{
	# Setup
	$resourceGroupName = "cl_stage_sea_cv"
	$managedInstanceName = "seageodr-gen5-gp"
	$weeklyRetention = "P1W"
	$zeroRetention = "PT0S"

	try
	{
		# create test database
		$databaseName = "ps-ltr-policy-test-1"
		$database = New-AzSqlInstanceDatabase -ResourceGroupName $resourceGroupName -InstanceName $managedInstanceName -Name $databaseName

		Set-AzSqlInstanceDatabaseBackupLongTermRetentionPolicy -ResourceGroupName $resourceGroupName -InstanceName $managedInstanceName -DatabaseName $databaseName -WeeklyRetention $weeklyRetention
		$policy = Get-AzSqlInstanceDatabaseBackupLongTermRetentionPolicy -ResourceGroup $resourceGroupName -InstanceName $managedInstanceName -DatabaseName $databaseName
		Assert-AreEqual $policy.WeeklyRetention $weeklyRetention
		Assert-AreEqual $policy.MonthlyRetention $zeroRetention
		Assert-AreEqual $policy.YearlyRetention $zeroRetention
	}
	finally
	{
		Remove-ResourceGroupForTest $resourceGroup
	}
}

<#
	.SYNOPSIS
	Test long term retention backup commands for managed databases.
#>
function Test-ManagedInstanceLongTermRetentionBackup
{

	# MANUAL INSTRUCTIONS
	# Create a server and database and fill in the appropriate information below
	# Set the weekly retention on the database so that the first backup gets picked up, for example:
	# Set-AzSqlInstanceDatabaseBackupLongTermRetentionPolicy -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName -WeeklyRetention P1W
	# Wait about 18 hours until it gets properly copied and you see the backup when run get backups, for example:
	# Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -DatabaeName $databaseName
	$resourceGroup = "cl_stage_sea_cv"
	$locationName = "southeastasia"
	$managedInstanceName = "seageodr-gen5-gp"
	$databaseName = "ps-test-1"
	$databaseWithRemovableBackup = "ps-test-2";

	# Basic Get Tests
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -DatabaseName $databaseName
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -DatabaseName $databaseName -BackupName $backups[0].BackupName
	Assert-AreNotEqual $backups.Count 0

	# Test Get Optional Parameters
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -DatabaseName $databaseName -OnlyLatestPerDatabase
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -OnlyLatestPerDatabase -DatabaseState All
	Assert-AreNotEqual $backups.Count 0

	# Test Get Piping with Optional Parameters
	$backups = Get-AzSqlInstanceDatabase -ResourceGroup $resourceGroup -InstanceName $managedInstanceName -Name $databaseName | Get-AzSqlInstanceDatabaseLongTermRetentionBackup -OnlyLatestPerDatabase
	Assert-AreNotEqual $backups.Count 0

	# Restore Test
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName
	$restoredDatabase = "ps-test-restore-2"
	$db = Restore-AzSqlInstanceDatabase -FromLongTermRetentionBackup -ResourceId $backups[0].ResourceId -TargetResourceGroupName $resourceGroup -TargetInstanceName $managedInstanceName -TargetInstanceDatabaseName $restoredDatabase
	Assert-AreEqual $db.Name $restoredDatabase

	# Test Remove Backup
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -DatabaseName $databaseWithRemovableBackup
	$initialBackups = $backups.Count
	Remove-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -DatabaseName $databaseWithRemovableBackup -BackupName $backups[0].BackupName -Force
	$backups = Get-AzSqlInstanceDatabase -ResourceGroup $resourceGroup -InstanceName $managedInstanceName -Name $databaseWithRemovableBackup | Get-AzSqlInstanceDatabaseLongTermRetentionBackup
	$expectedBackups = $initialBackups-1
	Assert-AreEqual $expectedBackups $backups.Count

	# drop the restored db
	Remove-AzSqlInstanceDatabase -ResourceGroupName $resourceGroup -InstanceName $managedInstanceName -Name $restoredDatabase -Force
}

<#
	.SYNOPSIS
	Test long term retention backup commands for managed databases (using resource group).
#>
function Test-ManagedInstanceLongTermRetentionResourceGroupBasedBackup
{
	# MANUAL INSTRUCTIONS
	# Create a server and database and fill in the appropriate information below
	# Set the weekly retention on the database so that the first backup gets picked up, for example:
	# Set-AzSqlInstanceDatabaseBackupLongTermRetentionPolicy -ResourceGroup $resourceGroup -ServerName $serverName -DatabaseName $databaseName -WeeklyRetention P1W
	# Wait about 18 hours until it gets properly copied and you see the backup when run get backups, for example:
	# Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -ServerName $serverName -DatabaeName $databaseName -ResourceGroupName $resourceGroup
	$resourceGroup = "cl_stage_sea_cv"
	$locationName = "southeastasia"
	$managedInstanceName = "seageodr-gen5-gp"
	$databaseName = "ps-test-3"

	# Basic Get Tests
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -ResourceGroupName $resourceGroup
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -ResourceGroupName $resourceGroup
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -DatabaseName $databaseName -ResourceGroupName $resourceGroup
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -DatabaseName $databaseName -BackupName $backups[0].BackupName -ResourceGroupName $resourceGroup
	Assert-AreNotEqual $backups.Count 0

	# Test Get Piping
	$backups = Get-AzSqlInstanceDatabase -ResourceGroup $resourceGroup -InstanceName $managedInstanceName -Name $databaseName | Get-AzSqlInstanceDatabaseLongTermRetentionBackup
	Assert-AreNotEqual $backups.Count 0
	$backups = Get-AzSqlInstanceDatabase -ResourceGroup $resourceGroup -InstanceName $managedInstanceName -Name $databaseName | Get-AzSqlInstanceDatabaseLongTermRetentionBackup -BackupName $backups[0].BackupName
	Assert-AreNotEqual $backups.Count 0

	# Test Get Optional Parameters
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -DatabaseName $databaseName -ResourceGroupName $resourceGroup -OnlyLatestPerDatabase
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -InstanceName $managedInstanceName -ResourceGroupName $resourceGroup -DatabaseState All
	Assert-AreNotEqual $backups.Count 0

	# Test Get Piping with Optional Parameters
	$backups = Get-AzSqlInstanceDatabase -ResourceGroup $resourceGroup -InstanceName $managedInstanceName -Name $databaseName | Get-AzSqlInstanceDatabaseLongTermRetentionBackup -OnlyLatestPerDatabase
	Assert-AreNotEqual $backups.Count 0

	# Restore Test
	$restoredDatabase = "ps-test-restore-with-rg-2"
	$backups = Get-AzSqlInstanceDatabaseLongTermRetentionBackup -Location $locationName -ResourceGroupName $resourceGroup
	$db = Restore-AzSqlInstanceDatabase -FromLongTermRetentionBackup -ResourceId $backups[0].ResourceId -TargetResourceGroupName $resourceGroup -TargetInstanceName $managedInstanceName -TargetInstanceDatabaseName $restoredDatabase
	Assert-AreEqual $db.Name $restoredDatabase

	# drop the restored db
	Remove-AzSqlInstanceDatabase -ResourceGroupName $resourceGroup -InstanceName $managedInstanceName -Name $restoredDatabase -Force
}

