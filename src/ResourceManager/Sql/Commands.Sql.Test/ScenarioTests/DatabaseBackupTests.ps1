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
		$server = Create-ServerForTest $rg $serverVersion $location

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
		Assert-True { $restorePoint.EarliestRestoreDate -le [DateTime]::UtcNow }
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

	Get-AzureRmSqlDatabaseGeoBackup -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -DatabaseName $db.DatabaseName | Restore-AzureRmSqlDatabase -FromGeoBackup -TargetDatabaseName $restoredDbName
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

	Get-AzureRmSqlDeletedDatabaseBackup -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -DatabaseName $droppedDbName -DeletionDate "2016-02-23T00:21:22.847Z" | Restore-AzureRmSqlDatabase -FromDeletedDatabaseBackup -TargetDatabaseName $restoredDbName
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

	Get-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $db.DatabaseName | Restore-AzureRmSqlDatabase -FromPointInTimeBackup -PointInTime "2016-02-20T00:06:00Z" -TargetDatabaseName $restoredDbName
}