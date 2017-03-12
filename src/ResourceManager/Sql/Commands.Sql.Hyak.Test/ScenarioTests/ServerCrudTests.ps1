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
	 	
	$serverName = Get-ServerName
	$version = "12.0"
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force)) 

	try
	{
		# With all parameters
		$server1 = New-AzureRmSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $serverName -Location $rg.Location -ServerVersion $version -SqlAdministratorCredentials $credentials
		Assert-AreEqual $server1.ServerName $serverName
		Assert-AreEqual $server1.ServerVersion $version
		Assert-AreEqual $server1.SqlAdministratorLogin $serverLogin
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

	try
	{
		# Test using parameters
		$serverPassword = "n3wc00lP@55w0rd"
		$secureString = ConvertTo-SecureString $serverPassword -AsPlainText -Force

		$server1 = Set-AzureRmSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -SqlAdministratorPassword $secureString
		Assert-AreEqual $server1.ServerName $server.ServerName
		Assert-AreEqual $server1.ServerVersion $server.ServerVersion
		Assert-AreEqual $server1.SqlAdministratorLogin $server.SqlAdministratorLogin
		
		# Test piping
		$serverPassword = "n3wc00lP@55w0rd!!!"
		$secureString = ConvertTo-SecureString $serverPassword -AsPlainText -Force

		$server2 = $server | Set-AzureRmSqlServer -SqlAdministratorPassword $secureString
		Assert-AreEqual $server2.ServerName $server.ServerName
		Assert-AreEqual $server2.ServerVersion $server.ServerVersion
		Assert-AreEqual $server2.SqlAdministratorLogin $server.SqlAdministratorLogin
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
		$resp1 = Get-AzureRmSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server1.ServerName
		Assert-AreEqual $server1.ServerName $resp1.ServerName
		Assert-AreEqual $server1.ServerVersion $resp1.ServerVersion
		Assert-AreEqual $server1.SqlAdministratorLogin $resp1.SqlAdministratorLogin
		
		# Test piping
		$resp2 = $server2 | Get-AzureRmSqlServer
		Assert-AreEqual $server2.ServerName $resp2.ServerName
		Assert-AreEqual $server2.ServerVersion $resp2.ServerVersion
		Assert-AreEqual $server2.SqlAdministratorLogin $resp2.SqlAdministratorLogin

		$all = Get-AzureRmSqlServer -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $all.Count 2
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
		Remove-AzureRmSqlServer -ResourceGroupName $rg.ResourceGroupName -ServerName $server1.ServerName -Force
		
		# Test piping
		$server2 | Remove-AzureRmSqlServer -Force

		$all = Get-AzureRmSqlServer -ResourceGroupName $rg.ResourceGroupName
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

