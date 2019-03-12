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
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

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

function Test-ManagedDeletedDatabaseShortTermRetentionPolicy
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$vnetName = "cl_initial"
	$subnetName = "Cool"

	# Setup VNET 
	$virtualNetwork1 = CreateAndGetVirtualNetworkForManagedInstance $vnetName $subnetName $rg.Location
	$subnetId = $virtualNetwork1.Subnets.where({ $_.Name -eq $subnetName }).Id

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