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
	Tests creating a server
#>
function Test-CreateServer
{
	# Setup
	$rg = Create-ResourceGroupForTest
	 	
	$serverName = "sql-ps-test-server-" + [System.Guid]::NewGuid().ToString()
	$version = "12.0"
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force)) 

	try
	{
		# With all parameters
		$serverName = "sql-ps-test-server-" + [System.Guid]::NewGuid().ToString()
		$server1 = New-AzureSqlDatabaseServer -ResourceGroupName $resourceGroup.Name -ServerName $serverName -Location $resourceGroup.location -ServerVersion $version -SqlAdminCredentials $credentials
		Assert-AreEqual $server1.ServerName $serverName
		Assert-AreEqual $server1.ServerVersion $version
		Assert-AreEqual $server1.SqlAdminUserName $serverLogin
	
		# Without server version
		$serverName = "sql-ps-test-server-" + [System.Guid]::NewGuid().ToString()
		$server2 = New-AzureSqlDatabaseServer -ResourceGroupName $resourceGroup.Name -ServerName $serverName -Location $resourceGroup.location -SqlAdminCredentials $credentials
		Assert-AreEqual $server2.ServerName $serverName
		Assert-AreEqual $server2.ServerVersion $version
		Assert-AreEqual $server2.SqlAdminUserName $serverLogin
	
		# With piping
		$serverName = "sql-ps-test-server-" + [System.Guid]::NewGuid().ToString()
		$server1.ServerName = $serverName
		$server1 | New-AzureSqlDatabaseServer -SqlAdminCredentials $credentials
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a server
#>
function Test-UpdateServer
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg

	$serverPassword = "n3wc00lP@55w0rd"
	try
	{
		# Test using parameters
		$server1 = Set-AzureSqlDatabaseServer -ResourceGroupName $resourceGroup.Name -ServerName $serverName -SqlAdminPassword $serverPassword
		Assert-AreEqual $server1.ServerName $server.ServerName
		Assert-AreEqual $server1.ServerVersion $server.ServerVersion
		Assert-AreEqual $server1.SqlAdminUserName $server.SqlAdminUserName
		
		# Test piping
		$serverPassword = "n3wc00lP@55w0rd!!!"
		$server2 = $server | Set-AzureSqlDatabaseServer -SqlAdminPassword $serverPassword
		Assert-AreEqual $server1.ServerName $server.ServerName
		Assert-AreEqual $server1.ServerVersion $server.ServerVersion
		Assert-AreEqual $server1.SqlAdminUserName $server.SqlAdminUserName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a server
#>
function Test-GetServer
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server1 = Create-ServerForTest $rg
	$server2 = Create-ServerForTest $rg

	try
	{
		# Test using parameters
		$resp1 = Get-AzureSqlDatabaseServer -ResourceGroupName $rg.Name -ServerName $server1.ServerName
		Assert-AreEqual $server1.ServerName $resp1.ServerName
		Assert-AreEqual $server1.ServerVersion $resp1.ServerVersion
		Assert-AreEqual $server1.SqlAdminUserName $resp1.SqlAdminUserName
		
		# Test piping
		$resp2 = $server2 | Get-AzureSqlDatabaseServer
		Assert-AreEqual $server2.ServerName $resp2.ServerName
		Assert-AreEqual $server2.ServerVersion $resp2.ServerVersion
		Assert-AreEqual $server2.SqlAdminUserName $resp2.SqlAdminUserName

		$all = Get-AzureSqlDatabaseServer -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $all.Length 2
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Removing a server
#>
function Test-RemoveServer
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server1 = Create-ServerForTest $rg
	$server2 = Create-ServerForTest $rg

	try
	{
		# Test using parameters
		Remove-AzureSqlDatabaseServer -ResourceGroupName $rg.Name -ServerName $server1.ServerName
		
		# Test piping
		$server2 | Remove-AzureSqlDatabaseServer

		$all = Get-AzureSqlDatabaseServer -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $all.Length 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

