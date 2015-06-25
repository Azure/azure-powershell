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
	Tests creating a database
#>
function Test-CreateDatabase
{
	Test-CreateDatabaseInternal "12.0"
}

<#
	.SYNOPSIS
	Tests creating a database
#>
function Test-CreateDatabaseV2
{
	Test-CreateDatabaseInternal "2.0" "North Central US"
}

<#
	.SYNOPSIS
	Tests creating a database
#>
function Test-CreateDatabaseInternal ($serverVersion, $location = "Japan East")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location

	try
	{
		if ($serverVersion -ne "2.0")
		{
			# Create with default values
			$databaseName = Get-DatabaseName
			$db = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
			Assert-AreEqual $db.DatabaseName $databaseName
			Assert-NotNull $db.MaxSizeBytes
			Assert-NotNull $db.Edition
			Assert-NotNull $db.CurrentServiceObjectiveName
			Assert-NotNull $db.CollationName

			# Create with default values via piping
			$databaseName = Get-DatabaseName
			$db = $server | New-AzureSqlDatabase -DatabaseName $databaseName
			Assert-AreEqual $db.DatabaseName $databaseName
			Assert-NotNull $db.MaxSizeBytes
			Assert-NotNull $db.Edition
			Assert-NotNull $db.CurrentServiceObjectiveName
			Assert-NotNull $db.CollationName
		}
		
		# Create with all parameters
		$databaseName = Get-DatabaseName
		$db = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-AreEqual $db.MaxSizeBytes 1GB
		Assert-AreEqual $db.Edition Basic
		Assert-AreEqual $db.CurrentServiceObjectiveName Basic
		Assert-AreEqual $db.CollationName "Japanese_Bushu_Kakusu_100_CS_AS"

		# Create with all parameters
		$databaseName = Get-DatabaseName
		$db = $server | New-AzureSqlDatabase -DatabaseName $databaseName `
			-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-AreEqual $db.MaxSizeBytes 1GB
		Assert-AreEqual $db.Edition Basic
		Assert-AreEqual $db.CurrentServiceObjectiveName Basic
		Assert-AreEqual $db.CollationName "Japanese_Bushu_Kakusu_100_CS_AS"
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a database
#>
function Test-UpdateDatabase
{
	Test-UpdateDatabaseInternal "12.0"
}

<#
	.SYNOPSIS
	Tests updating a database
#>
function Test-UpdateDatabaseV2
{
	Test-UpdateDatabaseInternal "2.0" "North Central US"
}

<#
	.SYNOPSIS
	Tests updating a database
#>
function Test-UpdateDatabaseInternal ($serverVersion, $location = "Japan East")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location
	
	$databaseName = Get-DatabaseName
	$db = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Standard -MaxSizeBytes 250GB -RequestedServiceObjectiveName S0
	Assert-AreEqual $db.DatabaseName $databaseName

    # Database will be Standard s0 with maxsize: 268435456000 (250GB)

	try
	{
		if($serverVersion -eq "12.0")
		{
			# Alter all properties
			$db1 = Set-AzureSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
				-MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic
			Assert-AreEqual $db1.DatabaseName $db.DatabaseName
			Assert-AreEqual $db1.MaxSizeBytes 1GB
			Assert-AreEqual $db1.Edition Basic
			Assert-AreEqual $db1.CurrentServiceObjectiveName Basic
			Assert-AreEqual $db1.CollationName $db.CollationName

			# Alter all properties using piping
			$db2 = $db1 | Set-AzureSqlDatabase -MaxSizeBytes 100GB -Edition Standard -RequestedServiceObjectiveName S1
			Assert-AreEqual $db2.DatabaseName $db.DatabaseName
			Assert-AreEqual $db2.MaxSizeBytes 100GB
			Assert-AreEqual $db2.Edition Standard
			Assert-AreEqual $db2.CurrentServiceObjectiveName S1
			Assert-AreEqual $db2.CollationName $db.CollationName
		}
		else 
		{
		
			# Alter all properties
			$db1 = Set-AzureSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
				-MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic
			Assert-AreEqual $db1.DatabaseName $db.DatabaseName
			Assert-AreEqual $db1.MaxSizeBytes 250GB
			Assert-AreEqual $db1.Edition Standard
			Assert-AreEqual $db1.CurrentServiceObjectiveName S0
			Assert-AreEqual $db1.CollationName $db.CollationName

			# Alter all properties using piping
			$db2 = $db1 | Set-AzureSqlDatabase -MaxSizeBytes 100GB -Edition Standard -RequestedServiceObjectiveName S1
			Assert-AreEqual $db2.DatabaseName $db.DatabaseName
			Assert-AreEqual $db2.MaxSizeBytes 1GB
			Assert-AreEqual $db2.Edition Basic
			Assert-AreEqual $db2.CurrentServiceObjectiveName Basic
			Assert-AreEqual $db2.CollationName $db.CollationName
		}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests Getting a database
#>
function Test-GetDatabase
{
	Test-GetDatabaseInternal "12.0"
}

<#
	.SYNOPSIS
	Tests Getting a database
#>
function Test-GetDatabaseV2
{
	Test-GetDatabaseInternal "2.0" "North Central US"
}

<#
	.SYNOPSIS
	Tests Getting a database
#>
function Test-GetDatabaseInternal  ($serverVersion, $location = "Japan East")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location
	
	# Create with default values
	$databaseName = Get-DatabaseName
	$db1 = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -MaxSizeBytes 1GB
	Assert-AreEqual $db1.DatabaseName $databaseName

    # Create database with non-defaults
	$databaseName = Get-DatabaseName
	$db2 = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic
    Assert-AreEqual $db2.DatabaseName $databaseName

	try
	{
        $gdb1 = Get-AzureSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db1.DatabaseName
        Assert-NotNull $gdb1
        Assert-AreEqual $db1.DatabaseName $gdb1.DatabaseName
        Assert-AreEqual $db1.Edition $gdb1.Edition
        Assert-AreEqual $db1.CollationName $gdb1.CollationName
        Assert-AreEqual $db1.CurrentServiceObjectiveName $gdb1.CurrentServiceObjectiveName
        Assert-AreEqual $db1.MaxSizeBytes $gdb1.MaxSizeBytes

        $gdb2 = $db2 | Get-AzureSqlDatabase
        Assert-NotNull $gdb2
        Assert-AreEqual $db2.DatabaseName $gdb2.DatabaseName
        Assert-AreEqual $db2.Edition $gdb2.Edition
        Assert-AreEqual $db2.CollationName $gdb2.CollationName
        Assert-AreEqual $db2.CurrentServiceObjectiveName $gdb2.CurrentServiceObjectiveName
        Assert-AreEqual $db2.MaxSizeBytes $gdb2.MaxSizeBytes

        $all = $server | Get-AzureSqlDatabase
        Assert-AreEqual $all.Count 3 # 3 because master database is included
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests Deleting a database
#>
function Test-RemoveDatabase
{
	Test-RemoveDatabaseInternal "12.0"
}

<#
	.SYNOPSIS
	Tests Deleting a database
#>
function Test-RemoveDatabaseV2
{
	Test-RemoveDatabaseInternal "2.0" "North Central US"
}

<#
	.SYNOPSIS
	Tests Deleting a database
#>
function Test-RemoveDatabaseInternal  ($serverVersion, $location = "Japan East")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $serverVersion $location
	
	# Create with default values
	$databaseName = Get-DatabaseName
	$db1 = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -MaxSizeBytes 1GB
	Assert-AreEqual $db1.DatabaseName $databaseName

    # Create database with non-defaults
	$databaseName = Get-DatabaseName
	$db2 = New-AzureSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic
    Assert-AreEqual $db2.DatabaseName $databaseName

	try
	{
        $all = $server | Get-AzureSqlDatabase
        Assert-AreEqual $all.Count 3 # 3 because master database is included

        Remove-AzureSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db1.DatabaseName -Force

        $db2 | Remove-AzureSqlDatabase -Force

        $all = $server | Get-AzureSqlDatabase
        Assert-AreEqual $all.Count 1 # 1 because master database is included
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}