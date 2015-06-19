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
	Test getting restore points from databases.
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
		$dwdb = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100

		$databaseName = Get-DatabaseName
		$standarddb = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition Standard -RequestedServiceObjectiveName S0

		# Get restore points from data warehouse database. There should be none.
		$restorePoints =  Get-AzureSqlDatabaseRestorePoints -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName
		Assert-True $restorePoints.IsEmpty

		# Get restore points from standard database.There should be 1.
		$restorePoints = Resume-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $standarddb.DatabaseName
		$restorePoint = $restorePoints[0]
		Assert-AreEqual $restorePoint.RestorePointType Continuous
		Assert-Null $restorePoint.RestorePointCreationDate
		Assert-NotNull $restorePoint.EarliestRestoreDate 
		Assert-AreEqual $restorePoint.SizeBytes 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Test getting restore points from databases via piped cmdlets.
#>
function Test-ListDatabaseRestorePointsPiped
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
		$dwdb = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition DataWarehouse -RequestedServiceObjectiveName DW100

		$databaseName = Get-DatabaseName
		$standarddb = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-Edition Standard -RequestedServiceObjectiveName S0

		# Get restore points from data warehouse database.
		Assert-True $restorePoints.IsEmpty

		# Get restore points from standard database.
		$restorePoints = $standarddb | Resume-AzureSqlDatabase
		$restorePoint = $restorePoints[0]
		Assert-AreEqual $restorePoint.RestorePointType Continuous
		Assert-Null $restorePoint.RestorePointCreationDate
		Assert-NotNull $restorePoint.EarliestRestoreDate 
		Assert-AreEqual $restorePoint.SizeBytes 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}