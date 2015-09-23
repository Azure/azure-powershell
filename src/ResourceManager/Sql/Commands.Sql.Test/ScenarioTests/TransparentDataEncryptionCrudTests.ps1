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
	Tests updating a database transparent data encryption
#>
function Test-UpdateTransparentDataEncryption
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg
	
	# Create with default values
	$databaseName = Get-DatabaseName
	$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
	Assert-AreEqual $db.DatabaseName $databaseName

	#Default database will be Standard s0 with maxsize: 268435456000 (250GB)

	try
	{
		# Alter all properties
		$tde1 = Set-AzureRmSqlDatabaseTransparentDataEncryption -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-State Enabled 
		Assert-AreEqual $tde1.State Enabled
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}


<#
	.SYNOPSIS
	Tests Getting a database transparent data encryption
#>
function Test-GetTransparentDataEncryption
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg
	
	# Create with default values
	$databaseName = Get-DatabaseName
	$db = New-AzureRmSqlDatabase -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName
	Assert-AreEqual $db.DatabaseName $databaseName

	try
	{
		$tde1 = Get-AzureRmSqlDatabaseTransparentDataEncryption -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db.DatabaseName
		Assert-AreEqual $tde1.State Disabled

		$tde2 = $tde1 | Get-AzureRmSqlDatabaseTransparentDataEncryption
		Assert-AreEqual $tde2.State Disabled

		# Alter all properties
		$tde3 = Set-AzureRmSqlDatabaseTransparentDataEncryption -ResourceGroupName $db.ResourceGroupName -ServerName $db.ServerName -DatabaseName $db.DatabaseName `
			-State Enabled 
		Assert-AreEqual $tde3.State Enabled

		$tdeActivity = Get-AzureRmSqlDatabaseTransparentDataEncryptionActivity -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db.DatabaseName
		Assert-AreEqual $tdeActivity.Status Encrypting

		$tde4 = Get-AzureRmSqlDatabaseTransparentDataEncryption -ResourceGroupName $server.ResourceGroupname -ServerName $server.ServerName -DatabaseName $db.DatabaseName
		Assert-AreEqual $tde4.State Enabled
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
