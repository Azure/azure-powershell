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
	Tests database failover.  Issues command with both -AsJob and without extra parameters
	
	Also tests failing over twice to verify first failover went through which causes second failover to hit a recent failover
	exception (aka too many failovers in the given period of time).
#>
function Test-FailoverDatabase
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Southeast Asia"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create database
		$databaseName = Get-DatabaseName
		New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

		# Failover database with -AsJob
		$job = Invoke-AzSqlDatabaseFailover -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -AsJob
		$job | Wait-Job
		
		# Failover database with no extra switch parameters.  Tests for exception to verify the first failover went through correctly as this second
		# failover will cause a recent failover exception
		try {
			Invoke-AzSqlDatabaseFailover -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
		} catch {
			$ErrorMessage = $_.Exception.Message
			Assert-AreEqual True $ErrorMessage.Contains("There was a recent failover on the database or pool")
		}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests database failover with passthru
#>
function Test-FailoverDatabasePassThru
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Southeast Asia"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create database
		$databaseName = Get-DatabaseName
		New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

		# Failover database with -PassThru
		$output = Invoke-AzSqlDatabaseFailover -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -PassThru
		Assert-True { $output }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests database failover using piping for database.
#>
function Test-FailoverDatabaseWithDatabasePiping
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Southeast Asia"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create database
		$databaseName = Get-DatabaseName
		New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

		# Failover database using piping for database
		Get-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName | Invoke-AzSqlDatabaseFailover
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests database failover using piping for server.
#>
function Test-FailoverDatabaseWithServerPiping
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Southeast Asia"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create database
		$databaseName = Get-DatabaseName
		New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName

		# Failover database using piping for server
		Get-AzSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName | Invoke-AzSqlDatabaseFailover -DatabaseName $databaseName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests failover readable secondary replica of database.  Issues command with both -AsJob and without extra parameters
	
	Also tests failing over twice to verify first failover went through which causes second failover to hit a recent failover
	exception (aka too many failovers in the given period of time).
#>
function Test-FailoverDatabaseReadableSecondary
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Southeast Asia"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create database
		$databaseName = Get-DatabaseName
		New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition "BusinessCritical" -Vcore 4 -ComputeGeneration "Gen5"

		# Failover readable secondary replica of database with -AsJob
		$job = Invoke-AzSqlDatabaseFailover -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -ReadableSecondary -AsJob
		$job | Wait-Job
		
		# Failover database with no extra switch parameters.  Tests for exception to verify the first failover went through correctly as this second
		# failover will cause a recent failover exception
		try {
			Invoke-AzSqlDatabaseFailover -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -ReadableSecondary 
		} catch {
			$ErrorMessage = $_.Exception.Message
			Assert-AreEqual True $ErrorMessage.Contains("There was a recent failover on the database or pool")
		}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests failover readable secondary replica of standard database throws errors.
#>
function Test-FailoverStandardDatabaseReadableSecondary
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Southeast Asia"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create database
		$databaseName = Get-DatabaseName
		New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition "GeneralPurpose" -Vcore 4 -ComputeGeneration "Gen5"

		# Failover readable secondary replica of standard database.  Tests that expected not supported on given SKU message it thrown
		try {
			Invoke-AzSqlDatabaseFailover -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -ReadableSecondary 
		} catch {
			$ErrorMessage = $_.Exception.Message
			Assert-AreEqual True $ErrorMessage.Contains("This type of customer initiated failover is not supported on the given SKU")
		}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests elastic pool failover.  Issues command with both -AsJob and without extra parameters
	
	Also tests failing over twice to verify first failover went through which causes second failover to hit a recent failover
	exception (aka too many failovers in the given period of time).
#>
function Test-FailoverElasticPool
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Southeast Asia"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create elastic pool
		$poolName = Get-ElasticPoolName
		New-AzSqlElasticPool  -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -ElasticPoolName $poolName

		# Create database in elastic pool
		$databaseName = Get-DatabaseName
		New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -ElasticPoolName $poolName

		# Failover elastic pool with -AsJob
		$job = Invoke-AzSqlElasticPoolFailover -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -ElasticPoolName $poolName -AsJob
		$job | Wait-Job

		# Failover elastic pool with no extra switch parameters.  Tests for exception to verify the first failover went through correctly as this second
		# failover will cause a recent failover exception
		try {
			Invoke-AzSqlElasticPoolFailover -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -ElasticPoolName $poolName
		} catch {
			$ErrorMessage = $_.Exception.Message
			Assert-AreEqual True $ErrorMessage.Contains("There was a recent failover on the elastic pool")
		}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests elastic pool failover with passthru
#>
function Test-FailoverElasticPoolPassThru
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Southeast Asia"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create elastic pool
		$poolName = Get-ElasticPoolName
		New-AzSqlElasticPool  -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -ElasticPoolName $poolName

		# Create database in elastic pool
		$databaseName = Get-DatabaseName
		New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -ElasticPoolName $poolName

		# Failover elastic pool with -PassThru
		$output = Invoke-AzSqlElasticPoolFailover -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -ElasticPoolName $poolName -PassThru
		Assert-True { $output }
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests elastic pool failover using piping for pool.
#>
function Test-FailoverElasticPoolWithPoolPiping
{
	# Setup
	$location = Get-Location "Microsoft.Sql" "operations" "Southeast Asia"
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create elastic pool
		$poolName = Get-ElasticPoolName
		New-AzSqlElasticPool  -ServerName $server.ServerName -ResourceGroupName $rg.ResourceGroupName -ElasticPoolName $poolName

		# Create database in elastic pool
		$databaseName = Get-DatabaseName
		New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -ElasticPoolName $poolName

		# Failover elastic pool using piping for pool
		Get-AzSqlElasticPool -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -ElasticPoolName $poolName | Invoke-AzSqlElasticPoolFailover
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}