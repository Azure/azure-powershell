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
	$databaseName = Get-DatabaseName
	$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition Premium -ReadScale Enabled
	Assert-AreEqual $db.DatabaseName $databaseName

	try
	{
		# Alter all properties
		$db1 = Set-AzureRmSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName -ReadScale Disabled
		Assert-AreEqual $db1.ReadScale Disabled
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
	$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition Premium
	Assert-AreEqual $db.DatabaseName $databaseName

	try
	{
		$db1 = Get-AzureRmSqlDatabase -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db.DatabaseName
		Assert-AreEqual $db1.ReadScale Disabled

		# Alter read scale properties
		$db2 = Set-AzureRmSqlDatabase -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-ReadScale Enabled
		Assert-AreEqual $db2.ReadScale Enabled
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}