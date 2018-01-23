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
	Test-CreateDatabaseInternal "Southeast Asia"
}

<#
	.SYNOPSIS
	Tests creating a database
#>
function Test-CreateDatabaseInternal ($location = "westcentralus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	try
	{
		# Create with default values
		$databaseName = Get-DatabaseName
		$job1 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -AsJob
		$job1 | Wait-Job
		$db = $job1.Output

		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.MaxSizeBytes
		Assert-NotNull $db.Edition
		Assert-NotNull $db.CurrentServiceObjectiveName
		Assert-NotNull $db.CollationName

		# Create with default values via piping
		$databaseName = Get-DatabaseName
		$db = $server | New-AzureRmSqlDatabase -DatabaseName $databaseName
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.MaxSizeBytes
		Assert-NotNull $db.Edition
		Assert-NotNull $db.CurrentServiceObjectiveName
		Assert-NotNull $db.CollationName

		# Create data warehouse database with all parameters.
		$databaseName = Get-DatabaseName
		$collationName = "SQL_Latin1_General_CP1_CI_AS"
		$maxSizeBytes = 250GB
		$job2 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
				-CollationName $collationName -MaxSizeBytes $maxSizeBytes -Edition DataWarehouse -RequestedServiceObjectiveName DW100 -AsJob
		$job2 | Wait-Job
		$dwdb  = $job2.Output

		Assert-AreEqual $dwdb.DatabaseName $databaseName
		Assert-AreEqual $dwdb.MaxSizeBytes $maxSizeBytes
		Assert-AreEqual $dwdb.Edition DataWarehouse
		Assert-AreEqual $dwdb.CurrentServiceObjectiveName DW100
		Assert-AreEqual $dwdb.CollationName $collationName
		
		# Create with all parameters
		$databaseName = Get-DatabaseName
		$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic -Tags @{"tag_key"="tag_value"}
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-AreEqual $db.MaxSizeBytes 1GB
		Assert-AreEqual $db.Edition Basic
		Assert-AreEqual $db.CurrentServiceObjectiveName Basic
		Assert-AreEqual $db.CollationName "Japanese_Bushu_Kakusu_100_CS_AS"
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_value" $db.Tags["tag_key"]

		# Create with all parameters
		$databaseName = Get-DatabaseName
		$db = $server | New-AzureRmSqlDatabase -DatabaseName $databaseName `
			-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic -Tags @{"tag_key"="tag_value"}
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-AreEqual $db.MaxSizeBytes 1GB
		Assert-AreEqual $db.Edition Basic
		Assert-AreEqual $db.CurrentServiceObjectiveName Basic
		Assert-AreEqual $db.CollationName "Japanese_Bushu_Kakusu_100_CS_AS"
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_value" $db.Tags["tag_key"]
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with sample name.
#>
function Test-CreateDatabaseWithSampleName
{
	# Setup
	$location = "westcentralus"
	$rg = Create-ResourceGroupForTest
	try
	{
		$server = Create-ServerForTest $rg $location

		# Create with samplename
		$databaseName = Get-DatabaseName
		$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -SampleName "AdventureWorksLT" -RequestedServiceObjectiveName Basic `
			-Tags @{"tag_key"="tag_value"}
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-AreEqual $db.CurrentServiceObjectiveName Basic
		Assert-NotNull $db.MaxSizeBytes
		Assert-NotNull $db.Edition
		Assert-NotNull $db.CurrentServiceObjectiveName
		Assert-NotNull $db.CollationName
		Assert-NotNull $db.Tags
		Assert-AreEqual True $db.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_value" $db.Tags["tag_key"]
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests creating a database with zone redundancy.
#>
function Test-CreateDatabaseWithZoneRedundancy
{
	# Setup
	$location = "eastus2"
	$rg = Create-ResourceGroupForTest $location
	try
	{
		$server = Create-ServerForTest $rg $location

		# Create database with no zone redundancy set
		$databaseName = Get-DatabaseName
		$job = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -AsJob
		$job | Wait-Job
		$db = $job.Output

		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.Edition
		Assert-NotNull $db.ZoneRedundant
		Assert-AreEqual "false" $db.ZoneRedundant

		# Create database with zone redundancy true
		$databaseName = Get-DatabaseName
		$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -ZoneRedundant
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.Edition
		Assert-NotNull $db.ZoneRedundant
		Assert-AreEqual "true" $db.ZoneRedundant

		# Create database with zone redundancy false
		$databaseName = Get-DatabaseName
		$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -ZoneRedundant:$false
		Assert-AreEqual $db.DatabaseName $databaseName
		Assert-NotNull $db.Edition
		Assert-NotNull $db.ZoneRedundant
		Assert-AreEqual "false" $db.ZoneRedundant
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
	Test-UpdateDatabaseInternal "Southeast Asia"
}

<#
	.SYNOPSIS
	Tests updating a database
#>
function Test-UpdateDatabaseInternal ($location = "westcentralus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	
	$databaseName = Get-DatabaseName
	$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Standard -MaxSizeBytes 250GB -RequestedServiceObjectiveName S0
	Assert-AreEqual $db.DatabaseName $databaseName

    # Database will be Standard s0 with maxsize: 268435456000 (250GB)

	try
	{
		# Alter all properties
		$job = Set-AzureRmSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic -Tags @{"tag_key"="tag_new_value"} -AsJob
		$job | Wait-Job
		$db1 = $job.Output

		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.MaxSizeBytes 1GB
		Assert-AreEqual $db1.Edition Basic
		Assert-AreEqual $db1.CurrentServiceObjectiveName Basic
		Assert-AreEqual $db1.CollationName $db.CollationName
		Assert-NotNull $db1.Tags
		Assert-AreEqual True $db1.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_new_value" $db1.Tags["tag_key"]

		# Alter all properties using piping
		$db2 = $db1 | Set-AzureRmSqlDatabase -MaxSizeBytes 100GB -Edition Standard -RequestedServiceObjectiveName S1 -Tags @{"tag_key"="tag_new_value2"}
		Assert-AreEqual $db2.DatabaseName $db.DatabaseName
		Assert-AreEqual $db2.MaxSizeBytes 100GB
		Assert-AreEqual $db2.Edition Standard
		Assert-AreEqual $db2.CurrentServiceObjectiveName S1
		Assert-AreEqual $db2.CollationName $db.CollationName
		Assert-NotNull $db2.Tags
		Assert-AreEqual True $db2.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_new_value2" $db2.Tags["tag_key"]

		# Create and alter data warehouse database.
		$databaseName = Get-DatabaseName
		$collationName = "SQL_Latin1_General_CP1_CI_AS"
		$maxSizeBytes = 250GB
		$dwdb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-CollationName $collationName -MaxSizeBytes $maxSizeBytes -Edition DataWarehouse -RequestedServiceObjectiveName DW100

		$job = Set-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName `
				-MaxSizeBytes $maxSizeBytes -RequestedServiceObjectiveName DW200 -Edition DataWarehouse -AsJob
		$job | Wait-Job
		$dwdb2 = $job.Output

		Assert-AreEqual $dwdb2.DatabaseName $dwdb.DatabaseName
		Assert-AreEqual $dwdb2.MaxSizeBytes $maxSizeBytes
		Assert-AreEqual $dwdb2.Edition DataWarehouse
		Assert-AreEqual $dwdb2.CurrentServiceObjectiveName DW200
		Assert-AreEqual $dwdb2.CollationName $collationName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a database with zone redundancy
#>
function Test-UpdateDatabaseWithZoneRedundant ()
{
	# Setup
	$location = "eastus2" 
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	
	$databaseName = Get-DatabaseName
	$db1 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Premium
	Assert-AreEqual $db1.DatabaseName $databaseName
	Assert-NotNull $db1.ZoneRedundant
	Assert-AreEqual "false" $db1.ZoneRedundant

	$databaseName = Get-DatabaseName
	$db2 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Premium -ZoneRedundant
	Assert-AreEqual $db2.DatabaseName $databaseName
	Assert-NotNull $db2.ZoneRedundant
	Assert-AreEqual "true" $db2.ZoneRedundant

	try
	{
		# Alter database with zone redundancy to true
		$sdb1 = Set-AzureRmSqlDatabase -ResourceGroupName $db1.ResourceGroupName -ServerName $db1.ServerName -DatabaseName $db1.DatabaseName `
			-ZoneRedundant
		Assert-AreEqual $sdb1.DatabaseName $db1.DatabaseName
		Assert-NotNull $sdb1.ZoneRedundant
		Assert-AreEqual "true" $sdb1.ZoneRedundant

		# Alter database with zone redundancy to false
		$sdb2 = Set-AzureRmSqlDatabase -ResourceGroupName $db2.ResourceGroupName -ServerName $db2.ServerName -DatabaseName $db2.DatabaseName `
			-ZoneRedundant:$false
		Assert-AreEqual $sdb2.DatabaseName $db2.DatabaseName
		Assert-NotNull $sdb2.ZoneRedundant
		Assert-AreEqual "false" $sdb2.ZoneRedundant
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a database with zone redundancy not specified
#>
function Test-UpdateDatabaseWithZoneRedundantNotSpecified ()
{
	# Setup
	$location = "eastus2" 
	$rg = Create-ResourceGroupForTest $location
	$server = Create-ServerForTest $rg $location
	
	$databaseName = Get-DatabaseName
	$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Premium -ZoneRedundant
	Assert-AreEqual $db.DatabaseName $databaseName
	Assert-NotNull $db.ZoneRedundant
	Assert-AreEqual "true" $db.ZoneRedundant

	try
	{
		# Alter database with no zone redundancy set
		$db1 = Set-AzureRmSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-Tags @{"tag_key"="tag_new_value2"}
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual True $db1.Tags.ContainsKey("tag_key")
		Assert-AreEqual "tag_new_value2" $db1.Tags["tag_key"]
		Assert-NotNull $db1.ZoneRedundant
		Assert-AreEqual "true" $db1.ZoneRedundant
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests renaming a database
#>
function Test-RenameDatabase
{
	# Setup
	$rg = Create-ResourceGroupForTest

	try
	{
		$location = "westcentralus"
		$server = Create-ServerForTest $rg $location
	
		# Create with default values
		$databaseName = Get-DatabaseName
		$db1 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -MaxSizeBytes 1GB
		Assert-AreEqual $db1.DatabaseName $databaseName

		# Rename with params
		$name2 = "name2"
		$db2 = Set-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -NewName $name2
		Assert-AreEqual $db2.DatabaseName $name2

		Assert-ThrowsContains -script { $db1 | Get-AzureRmSqlDatabase } -message "not found"
		$db2 | Get-AzureRmSqlDatabase

		# Rename with piping
		$name3 = "name3"
		$db3 = $db2 | Set-AzureRmSqlDatabase -NewName $name3
		Assert-AreEqual $db3.DatabaseName $name3

		Assert-ThrowsContains -script { $db1 | Get-AzureRmSqlDatabase } -message "not found"
		Assert-ThrowsContains -script { $db2 | Get-AzureRmSqlDatabase } -message "not found"
		$db3 | Get-AzureRmSqlDatabase
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
	Test-GetDatabaseInternal "Southeast Asia"
}

<#
	.SYNOPSIS
	Tests Getting a database
#>
function Test-GetDatabaseInternal  ($location = "westcentralus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	
	# Create with default values
	$databaseName = Get-DatabaseName
	$db1 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -MaxSizeBytes 1GB
	Assert-AreEqual $db1.DatabaseName $databaseName

    # Create database with non-defaults
	$databaseName = Get-DatabaseName
	$db2 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic
    Assert-AreEqual $db2.DatabaseName $databaseName

	try
	{
		# Create data warehouse database.
		$databaseName = Get-DatabaseName
		$dwdb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
				-CollationName SQL_Latin1_General_CP1_CI_AS -MaxSizeBytes 250GB -Edition DataWarehouse -RequestedServiceObjectiveName DW100
		$dwdb2 = Get-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName
		Assert-AreEqual $dwdb2.DatabaseName $dwdb.DatabaseName
		Assert-AreEqual $dwdb2.MaxSizeBytes $dwdb.MaxSizeBytes
		Assert-AreEqual $dwdb2.Edition $dwdb.Edition
		Assert-AreEqual $dwdb2.CurrentServiceObjectiveName $dwdb.CurrentServiceObjectiveName
		Assert-AreEqual $dwdb2.CollationName $dwdb.CollationName

		$all = $server | Get-AzureRmSqlDatabase
		Assert-AreEqual $all.Count 4 # 4 because master database is included

        $gdb1 = Get-AzureRmSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db1.DatabaseName
        Assert-NotNull $gdb1
        Assert-AreEqual $db1.DatabaseName $gdb1.DatabaseName
        Assert-AreEqual $db1.Edition $gdb1.Edition
        Assert-AreEqual $db1.CollationName $gdb1.CollationName
        Assert-AreEqual $db1.CurrentServiceObjectiveName $gdb1.CurrentServiceObjectiveName
        Assert-AreEqual $db1.MaxSizeBytes $gdb1.MaxSizeBytes

        $gdb2 = $db2 | Get-AzureRmSqlDatabase
        Assert-NotNull $gdb2
        Assert-AreEqual $db2.DatabaseName $gdb2.DatabaseName
        Assert-AreEqual $db2.Edition $gdb2.Edition
        Assert-AreEqual $db2.CollationName $gdb2.CollationName
        Assert-AreEqual $db2.CurrentServiceObjectiveName $gdb2.CurrentServiceObjectiveName
        Assert-AreEqual $db2.MaxSizeBytes $gdb2.MaxSizeBytes
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests getting a database with zone redundancy.
#>
function Test-GetDatabaseWithZoneRedundancy
{
	# Setup
	$location = "eastus2"
	$rg = Create-ResourceGroupForTest $location
	try
	{
		$server = Create-ServerForTest $rg $location

		# Create database with no zone redundancy set
		$databaseName = Get-DatabaseName
		$db1 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium -ZoneRedundant

		$gdb1 = Get-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db1.DatabaseName
		Assert-AreEqual $gdb1.DatabaseName $db1.DatabaseName
		Assert-AreEqual "true" $gdb1.ZoneRedundant

		# Create database with zone redundancy true
		$databaseName = Get-DatabaseName
		$db2 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName `
			-DatabaseName $databaseName -Edition Premium

		$gdb2 = Get-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db2.DatabaseName
		Assert-AreEqual $gdb2.DatabaseName $db2.DatabaseName
		Assert-AreEqual "false" $gdb2.ZoneRedundant
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
	Test-RemoveDatabaseInternal "Southeast Asia"
}

<#
	.SYNOPSIS
	Tests Deleting a database
#>
function Test-RemoveDatabaseInternal  ($location = "westcentralus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	
	# Create with default values
	$databaseName = Get-DatabaseName
	$db1 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -MaxSizeBytes 1GB
	Assert-AreEqual $db1.DatabaseName $databaseName

    # Create database with non-defaults
	$databaseName = Get-DatabaseName
	$db2 = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 1GB -Edition Basic -RequestedServiceObjectiveName Basic
    Assert-AreEqual $db2.DatabaseName $databaseName

	try
	{
		# Create data warehouse database
		$databaseName = Get-DatabaseName
		$dwdb = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
			-CollationName "SQL_Latin1_General_CP1_CI_AS" -MaxSizeBytes 250GB -Edition DataWarehouse -RequestedServiceObjectiveName DW100
		Assert-AreEqual $dwdb.DatabaseName $databaseName

		Remove-AzureRmSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $dwdb.DatabaseName -Force
		
		$all = $server | Get-AzureRmSqlDatabase
		Assert-AreEqual $all.Count 3 # 3 because master database is included
        
        Remove-AzureRmSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db1.DatabaseName -Force

        $db2 | Remove-AzureRmSqlDatabase -Force

        $all = $server | Get-AzureRmSqlDatabase
        Assert-AreEqual $all.Count 1 # 1 because master database is included
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests listing and cancelling a database operation
#>
function Test-CancelDatabaseOperation
{
	Test-CancelDatabaseOperationInternal
}

<#
	.SYNOPSIS
	Tests listing and cancelling a database operation
#>
function Test-CancelDatabaseOperationInternal ($location = "westcentralus")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location

	$databaseName = Get-DatabaseName
	$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName `
		-Edition Standard -MaxSizeBytes 250GB -RequestedServiceObjectiveName S0
	Assert-AreEqual $db.DatabaseName $databaseName

	# Database will be Standard s0 with maxsize: 268435456000 (250GB)

	try
	{
		# Alter all properties
		$db1 = Set-AzureRmSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-Edition Standard -RequestedServiceObjectiveName S1
		Assert-AreEqual $db1.DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.Edition Standard
		Assert-AreEqual $db1.CurrentServiceObjectiveName S1

		# list and cancel a database operation
		$dbactivity = Get-AzureRmSqlDatabaseActivity -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName
		Assert-AreEqual $dbactivity.DatabaseName $db.DatabaseName
		Assert-AreEqual $dbactivity.Operation "UpdateLogicalDatabase"

		$dbactivityId = $dbactivity.OperationId
		try
		{
			$dbactivityCancel = Stop-AzureRmSqlDatabaseActivity -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -OperationId $dbactivityId
		}
		Catch
		{
			$ErrorMessage = $_.Exception.Message
			Assert-AreEqual True $ErrorMessage.Contains("Cannot cancel database management operation '" + $dbactivityId + "' in the current state")
		}
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}