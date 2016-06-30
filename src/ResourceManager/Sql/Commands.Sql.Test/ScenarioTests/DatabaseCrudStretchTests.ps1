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
	Tests creating a stretch database on V12.0 server
#>
function Test-CreateStretchDatabase
{
	$rplocation = Get-ProviderLocation "Microsoft.Sql/servers"
	Test-CreateDatabaseInternal "12.0" $rplocation
}

<#
	.SYNOPSIS
	Helper for testing creating a database
#>
function Test-CreateDatabaseInternal ($serverVersion, $location = "Japan East")
{
	# Setup
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $serverVersion $location

	try
	{
		# Create stretch database with all parameters
		$databaseName = Get-DatabaseName
		$collationName = "SQL_Latin1_General_CP1_CI_AS"
		$maxSizeBytes = 250GB
		$strechdb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
				-CollationName $collationName -MaxSizeBytes $maxSizeBytes -Edition Stretch -RequestedServiceObjectiveName DS100
		Assert-AreEqual $databaseName $strechdb.DatabaseName 
		Assert-AreEqual $maxSizeBytes $strechdb.MaxSizeBytes 
		Assert-AreEqual Stretch $strechdb.Edition 
		Assert-AreEqual DS100 $strechdb.CurrentServiceObjectiveName
		Assert-AreEqual $collationName $strechdb.CollationName 
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a stretch database on V12.0 server
#>
function Test-UpdateStretchDatabase
{
	$rplocation = Get-ProviderLocation "Microsoft.Sql/servers"
	Test-UpdateDatabaseInternal "12.0" $rplocation
}

<#
	.SYNOPSIS
	Helper for testing updating a database
#>
function Test-UpdateDatabaseInternal ($serverVersion, $location = "Japan East")
{
	# Setup
		$rg = Create-ResourceGroupForTest $location
		$server = Create-ServerForTest $rg $serverVersion $location
	try {
		# Create stretch database
		$databaseName = Get-DatabaseName
		$collationName = "SQL_Latin1_General_CP1_CI_AS"
		$maxSizeBytes = 250GB
		$strechdb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-CollationName $collationName -MaxSizeBytes $maxSizeBytes -Edition Stretch -RequestedServiceObjectiveName DS100

		# Alter stretch database properties
		$strechdb2 = Set-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $strechdb.DatabaseName `
		-MaxSizeBytes $maxSizeBytes -Edition Stretch -RequestedServiceObjectiveName DS200
		Assert-AreEqual $strechdb.DatabaseName $strechdb2.DatabaseName
		Assert-AreEqual $maxSizeBytes $strechdb2.MaxSizeBytes
		Assert-AreEqual Stretch $strechdb2.Edition
		Assert-AreEqual DS200 $strechdb2.CurrentServiceObjectiveName
		Assert-AreEqual $collationName $strechdb2.CollationName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests Getting a stretch database on V12.0 server
#>
function Test-GetStretchDatabase
{
	$rplocation = Get-ProviderLocation "Microsoft.Sql/servers"
	Test-GetDatabaseInternal "12.0" $rplocation
}

<#
	.SYNOPSIS
	Helper for testing getting a database
#>
function Test-GetDatabaseInternal  ($serverVersion, $location = "Japan East")
{
	# Setup
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $serverVersion $location

	try
	{
		# Create stretch database and get-database to compare
		$databaseName = Get-DatabaseName
		$strechdb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
				-CollationName SQL_Latin1_General_CP1_CI_AS -MaxSizeBytes 250GB -Edition Stretch -RequestedServiceObjectiveName DS100
		$strechdb2 = Get-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $strechdb.DatabaseName
		Assert-AreEqual $strechdb.DatabaseName $strechdb2.DatabaseName
		Assert-AreEqual $strechdb.MaxSizeBytes $strechdb2.MaxSizeBytes
		Assert-AreEqual $strechdb.Edition $strechdb2.Edition
		Assert-AreEqual $strechdb.CurrentServiceObjectiveName $strechdb2.CurrentServiceObjectiveName
		Assert-AreEqual $strechdb.CollationName $strechdb2.CollationName

		# Check total number of databases
		$all = $server | Get-AzureRmSqlDatabase
		Assert-AreEqual $all.Count 2 # 2 because master database is included
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests Deleting a stretch database on V12.0 server
#>
function Test-RemoveStretchDatabase
{
	$rplocation = Get-ProviderLocation "Microsoft.Sql/servers"
	Test-RemoveDatabaseInternal "12.0" $rplocation
}

<#
	.SYNOPSIS
	Helper for testing deleting a database
#>
function Test-RemoveDatabaseInternal  ($serverVersion, $location = "Japan East")
{
	# Setup
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $serverVersion $location

	try
	{
		# Create stretch database
		$databaseName = Get-DatabaseName
		$stretchdb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-CollationName "SQL_Latin1_General_CP1_CI_AS" -MaxSizeBytes 250GB -Edition Stretch -RequestedServiceObjectiveName DS100
		Assert-AreEqual $databaseName $stretchdb.DatabaseName

		# Remove stretch databse
		Remove-AzureRmSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $stretchdb.DatabaseName -Force
		
		# Check total number of databases after removal 
		$all = $server | Get-AzureRmSqlDatabase
		Assert-AreEqual $all.Count 1 # 1 because master database is included
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}