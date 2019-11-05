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
	Tests create and update a database with read scale option
#>
function Test-CreateUpdateDatabaseReadScale ($serverVersion = "12.0", $location = "Southeast Asia")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	
	# Create with default values
	$databaseName1 = Get-DatabaseName
	$db1 = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName1 -Edition Premium
	Assert-AreEqual $db1.DatabaseName $databaseName1
	
	try
	{
		# Alter all properties
		$db1 = Set-AzSqlDatabase -ResourceGroupName $db1.ResourceGroupName -ServerName $db1.ServerName -DatabaseName $db1.DatabaseName -ReadScale Disabled
		Assert-AreEqual Disabled $db1.ReadScale
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests Getting a database read scale option
#>
function Test-GetDatabaseReadScale ($serverVersion = "12.0", $location = "Southeast Asia")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	
	# Create with default values
	$databaseName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition Premium
	Assert-AreEqual $db.DatabaseName $databaseName

	try
	{
		$db1 = Get-AzSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db.DatabaseName
		Assert-AreEqual Enabled $db1.ReadScale
		Assert-AreEqual 1 $db1.ReadReplicaCount

		# Alter read scale properties, Premium ignores ReadReplicaCount
		$db2 = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-ReadScale Disabled -ReadReplicaCount -1
		Assert-AreEqual Disabled $db2.ReadScale
		Assert-AreEqual 0 $db2.ReadReplicaCount
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests database ReadReplicaCount option
#>
function Test-DatabaseReadReplicaCount ($serverVersion = "12.0", $location = "Southeast Asia")
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg $location
	
	# Create with default values
	$databaseName = Get-DatabaseName
	$db = New-AzSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition Hyperscale `
		-VCore 4 -ComputeGeneration Gen5
	Assert-AreEqual $db.DatabaseName $databaseName

	try
	{
		$db1 = Get-AzSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db.DatabaseName
		Assert-AreEqual Enabled $db1.ReadScale
		Assert-AreEqual 1 $db1.ReadReplicaCount

		# Alter read scale properties, Hyperscale ignores ReadScale
		$db2 = Set-AzSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-ReadScale Enabled -ReadReplicaCount 0
		Assert-AreEqual Disabled $db2.ReadScale
		Assert-AreEqual 0 $db2.ReadReplicaCount
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}