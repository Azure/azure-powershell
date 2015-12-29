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
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg "Japan East"
	$server2 = Create-ServerForTest $rg "Japan East"

	try
	{
		$linkName = Get-ElasticPoolName
		$ep1 = New-AzureRmSqlServerCommunicationLink -ServerName $server1.ServerName -ResourceGroupName $rg.ResourceGroupName `
			-LinkName $linkName -PartnerServer $server2.ServerName

		Assert-NotNull $ep1
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
	$rg = Create-ResourceGroupForTest
	$server = Create-ServerForTest $rg "Japan East"
	$server2 = Create-ServerForTest $rg "Japan East"

	$linkName = Get-ElasticPoolName
	$ep1 = New-AzureRmSqlServerCommunicationLink -ServerName $server1.ServerName -ResourceGroupName $rg.ResourceGroupName `
		-LinkName $linkName -PartnerServer $server2.ServerName
	Assert-NotNull $ep1
	
	try
	{
		$gep1 = Get-AzureRmSqlServerCommunicationLink -ServerName $server1.ServerName -ResourceGroupName $rg.ResourceGroupName `
			-LinkName $ep1.LinkName 
		Assert-NotNull $ep1
		Assert-AreEqual $server2.ServerName $ep1.PartnerServer

		$all = $server | Get-AzureRmSqlServerCommunicationLink
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
	$rg = Create-ResourceGroupForTest
	$server1 = Create-ServerForTest $rg "Japan East"
	$server2 = Create-ServerForTest $rg "Japan East"

	$linkName = Get-ElasticPoolName
	$ep1 = New-AzureRmSqlServerCommunicationLink -ServerName $server1.ServerName -ResourceGroupName $rg.ResourceGroupName `
		-LinkName $linkName -PartnerServer $server2.ServerName
	Assert-NotNull $ep1
	
	try
	{
		Remove-AzureRmSqlServerCommunicationLink -ServerName $server1.ServerName -ResourceGroupName $rg.ResourceGroupName -LinkName $ep1.LinkName -Force
		
		$all = $server | Get-AzureRmSqlServerCommunicationLink
		Assert-AreEqual $all.Count 0
	}
	finally
	{
		Remove-ResourceGroupForTest $rg
	}
}
