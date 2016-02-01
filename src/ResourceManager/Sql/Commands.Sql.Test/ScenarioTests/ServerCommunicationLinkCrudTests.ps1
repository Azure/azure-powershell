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
	Tests creating a server communication link
#>
function Test-CreateServerCommunicationLink
{
	# Setup 
	$locationOverride = "North Europe"
	$serverVersion = "12.0"
	$rg = Create-ResourceGroupForTest $locationOverride
	$server1 = Create-ServerForTest $rg $serverVersion $locationOverride
	$server2 = Create-ServerForTest $rg $serverVersion $locationOverride

	try
	{
		$linkName = Get-ElasticPoolName
		$ep1 = New-AzureRmSqlServerCommunicationLink -ServerName $server1.ServerName -ResourceGroupName $rg.ResourceGroupName `
			-LinkName $linkName -PartnerServer $server2.ServerName

		Assert-NotNull $ep1
		Assert-AreEqual $linkName $ep1.Name
		Assert-AreEqual $server2.ServerName $ep1.PartnerServer
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<# 
	.SYNOPSIS
	Tests getting a server communication link
#>
function Test-GetServerCommunicationLink
{
	# Setup 
	$locationOverride = "North Europe"
	$serverVersion = "12.0"
	$rg = Create-ResourceGroupForTest $locationOverride
	$server1 = Create-ServerForTest $rg $serverVersion $locationOverride
	$server2 = Create-ServerForTest $rg $serverVersion $locationOverride

	$linkName = Get-ElasticPoolName
	$ep1 = New-AzureRmSqlServerCommunicationLink -ServerName $server1.ServerName -ResourceGroupName $rg.ResourceGroupName `
		-LinkName $linkName -PartnerServer $server2.ServerName
	Assert-NotNull $ep1
	Assert-AreEqual $linkName $ep1.Name
	Assert-AreEqual $server2.ServerName $ep1.PartnerServer
	
	try
	{
		$gep1 = Get-AzureRmSqlServerCommunicationLink -ServerName $server1.ServerName -ResourceGroupName $rg.ResourceGroupName `
			-LinkName $ep1.Name 
		Assert-NotNull $gep1
		Assert-AreEqual $linkName $gep1.Name
		Assert-AreEqual $server2.ServerName $gep1.PartnerServer

		$all = $server1 | Get-AzureRmSqlServerCommunicationLink
		Assert-AreEqual $all.Count 1
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}

<# 
	.SYNOPSIS
	Tests removing a server communication link
#>
function Test-RemoveServerCommunicationLink
{
	# Setup 
	$locationOverride = "North Europe"
	$serverVersion = "12.0"
	$rg = Create-ResourceGroupForTest $locationOverride
	$server1 = Create-ServerForTest $rg $serverVersion $locationOverride
	$server2 = Create-ServerForTest $rg $serverVersion $locationOverride

	$linkName = Get-ElasticPoolName
	$ep1 = New-AzureRmSqlServerCommunicationLink -ServerName $server1.ServerName -ResourceGroupName $rg.ResourceGroupName `
		-LinkName $linkName -PartnerServer $server2.ServerName
	Assert-NotNull $ep1
	
	try
	{
		Remove-AzureRmSqlServerCommunicationLink -ServerName $server1.ServerName -ResourceGroupName $rg.ResourceGroupName -LinkName $ep1.Name -Force
		
		$all = $server1 | Get-AzureRmSqlServerCommunicationLink
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
