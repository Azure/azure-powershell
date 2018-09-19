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
	Tests creating a server dns alias
#>

function Test-CreateServerDNSAlias
{
	# Setup
	$location = "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $location

	$serverDnsAliasName = Get-ServerDnsAliasName

	try
	{
		$job = New-AzureRmSqlServerDnsAlias -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DnsAliasName $serverDnsAliasName -AsJob
		$job | Wait-Job
		$serverDnsAlias = $job.Output

		Assert-AreEqual $serverDnsAlias.ServerName $server.ServerName
		Assert-AreEqual $serverDnsAlias.DnsAliasName $serverDnsAliasName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests getting server dns alias
#>

function Test-GetServerDNSAlias
{
	# Setup
	$location = "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $location

	$serverDnsAliasName = Get-ServerDnsAliasName
	$serverDnsAliasName2 = Get-ServerDnsAliasName

	try
	{
		# Create server dns alias 1
		$serverDnsAlias = New-AzureRmSqlServerDnsAlias -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DnsAliasName $serverDnsAliasName
		Assert-AreEqual $serverDnsAlias.ServerName $server.ServerName
		Assert-AreEqual $serverDnsAlias.DnsAliasName $serverDnsAliasName

		# Create server dns alias 2
		$serverDnsAlias = New-AzureRmSqlServerDnsAlias -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DnsAliasName $serverDnsAliasName2
		Assert-AreEqual $serverDnsAlias.ServerName $server.ServerName
		Assert-AreEqual $serverDnsAlias.DnsAliasName $serverDnsAliasName2

		# Get server dns alias
		$resp = Get-AzureRmSqlServerDnsAlias -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DnsAliasName $serverDnsAliasName
		Assert-AreEqual $resp.ServerName $server.ServerName
		Assert-AreEqual $resp.DnsAliasName $serverDnsAliasName

		# Get list of server dns aliases for server
		$resp = Get-AzureRmSqlServerDnsAlias -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $resp.Count 2
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests removing server dns alias
#>

function Test-RemoveServerDNSAlias
{
	# Setup
	$location = "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $location

	$serverDnsAliasName = Get-ServerDnsAliasName

	try
	{
		# Create Server DNS Alias
		$serverDnsAlias = New-AzureRmSqlServerDnsAlias -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DnsAliasName $serverDnsAliasName
		Assert-AreEqual $serverDnsAlias.ServerName $server.ServerName
		Assert-AreEqual $serverDnsAlias.DnsAliasName $serverDnsAliasName

		# Remove Server DNS Alias
		$job = Remove-AzureRmSqlServerDnsAlias -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DnsAliasName $serverDnsAliasName -Force -AsJob
		$job | Wait-Job
		$resp = $job.Output

		$all = Get-AzureRmSqlServerDNSAlias -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating server dns alias
#>

function Test-UpdateServerDNSAlias
{
	# Setup
	$location = "East US 2 EUAP"
	$rg = Create-ResourceGroupForTest $location 	
	$server = Create-ServerForTest $rg $location
	$server2 = Create-ServerForTest $rg $location

	$serverDnsAliasName = Get-ServerDnsAliasName

	try
	{
		# Create Server DNS Alias
		$serverDnsAlias = New-AzureRmSqlServerDnsAlias -ResourceGroupName $rg.ResourceGroupName -ServerName $server.ServerName -DnsAliasName $serverDnsAliasName
		Assert-AreEqual $serverDnsAlias.ServerName $server.ServerName
		Assert-AreEqual $serverDnsAlias.DnsAliasName $serverDnsAliasName

		# Get current subscription id
		$subId = (Get-AzureRmContext).Subscription.Id

		# Update Server DNS Alias
		$job = Set-AzureRmSqlServerDnsAlias -ResourceGroupName $rg.ResourceGroupName -SourceServerName $server.ServerName -DnsAliasName $serverDnsAliasName `
			-TargetServerName $server2.ServerName -SourceServerResourceGroupName $rg.ResourceGroupName -SourceServerSubscriptionId $subId -AsJob
		$job | Wait-Job

		$resp = Get-AzureRmSqlServerDnsAlias -ResourceGroupName $rg.ResourceGroupName -ServerName $server2.ServerName -DnsAliasName $serverDnsAliasName
		Assert-AreEqual $resp.ServerName $server2.ServerName
		Assert-AreEqual $resp.DnsAliasName $serverDnsAliasName
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}