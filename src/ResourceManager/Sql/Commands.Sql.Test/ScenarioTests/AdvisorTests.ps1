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
	Tests listing Server advisors
#>
function Test-ListServerAdvisors
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = SetupServer $rg

	try
	{
		$response = Get-AzureRmSqlServerAdvisor `
			-ResourceGroupName $server.ResourceGroupName `
			-ServerName $server.ServerName
		Assert-NotNull $response
		Assert-AreEqual 4 $response.Count
		foreach($advisor in $response)
		{
			ValidateServer $advisor $server
			ValidateAdvisorProperties $advisor
		}
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests listing Server advisors with recommended actions
#>
function Test-ListServerAdvisorsExpanded
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = SetupServer $rg

	try
	{
		$response = Get-AzureRmSqlServerAdvisor `
			-ResourceGroupName $server.ResourceGroupName `
			-ServerName $server.ServerName -ExpandRecommendedActions
		Assert-NotNull $response
		Assert-AreEqual 4 $response.Count
		foreach($advisor in $response)
		{
			ValidateServer $advisor $server
			ValidateAdvisorProperties $advisor
		}
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a Server advisor
#>
function Test-GetServerAdvisor
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = SetupServer $rg

	try
	{
		$response = Get-AzureRmSqlServerAdvisor `
			-ResourceGroupName $server.ResourceGroupName `
			-ServerName $server.ServerName -AdvisorName CreateIndex
		Assert-NotNull $response
		ValidateServer $response $server
		ValidateAdvisorProperties $response
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a Server advisor
#>
function Test-UpdateServerAdvisor
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$server = SetupServer $rg

	try
	{
		$response = Set-AzureRmSqlServerAdvisorAutoExecuteStatus `
			-ResourceGroupName $server.ResourceGroupName `
			-ServerName $server.ServerName `
			-AdvisorName CreateIndex `
			-AutoExecuteStatus Disabled
		Assert-NotNull $response
		ValidateServer $response $server
		ValidateAdvisorProperties $response
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests listing database advisors
#>
function Test-ListDatabaseAdvisors
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$db = SetupDatabase $rg

	try
	{
		$response = Get-AzureRmSqlDatabaseAdvisor `
			-ResourceGroupName $db.ResourceGroupName `
			-ServerName $db.ServerName `
			-DatabaseName $db.DatabaseName 
		Assert-NotNull $response
		Assert-AreEqual 4 $response.Count
		foreach($advisor in $response)
		{
			ValidateDatabase $advisor $db
			ValidateAdvisorProperties $advisor
		}
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests listing database advisors with recommended actions
#>
function Test-ListDatabaseAdvisorsExpanded
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$db = SetupDatabase $rg

	try
	{
		$response = Get-AzureRmSqlDatabaseAdvisor `
			-ResourceGroupName $db.ResourceGroupName `
			-ServerName $db.ServerName `
			-DatabaseName $db.DatabaseName `
			-ExpandRecommendedActions
		Assert-NotNull $response
		Assert-AreEqual 4 $response.Count
		foreach($advisor in $response)
		{
			ValidateDatabase $advisor $db
			ValidateAdvisorProperties $advisor
		}
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a database advisor
#>
function Test-GetDatabaseAdvisor
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$db = SetupDatabase $rg

	try
	{
		$response = Get-AzureRmSqlDatabaseAdvisor `
			-ResourceGroupName $db.ResourceGroupName `
			-ServerName $db.ServerName `
			-DatabaseName $db.DatabaseName `
			-AdvisorName CreateIndex
		Assert-NotNull $response
		ValidateDatabase $response $db
		ValidateAdvisorProperties $response
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a database advisor
#>
function Test-UpdateDatabaseAdvisor
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$db = SetupDatabase $rg

	try
	{
		$response = Set-AzureRmSqlDatabaseAdvisorAutoExecuteStatus `
			-ResourceGroupName $db.ResourceGroupName `
			-ServerName $db.ServerName `
			-DatabaseName $db.DatabaseName `
			-AdvisorName CreateIndex `
			-AutoExecuteStatus Disabled
		Assert-NotNull $response
		ValidateDatabase $response $db
		ValidateAdvisorProperties $response
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}
<#
	.SYNOPSIS
	Tests listing elastic pool advisors
#>
function Test-ListElasticPoolAdvisors
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$ep = SetupElasticPool $rg

	try
	{
		$response = Get-AzureRmSqlElasticPoolAdvisor `
			-ResourceGroupName $ep.ResourceGroupName`
			-ServerName $ep.ServerName`
			-ElasticPoolName $ep.ElasticPoolName
		Assert-NotNull $response
		Assert-AreEqual 4 $response.Count
		foreach($advisor in $response)
		{
			ValidateElasticPool $advisor $ep
			ValidateAdvisorProperties $advisor
		}
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests listing elastic pool advisors with recommended actions
#>
function Test-ListElasticPoolAdvisorsExpanded
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$ep = SetupElasticPool $rg

	try
	{
		$response = Get-AzureRmSqlElasticPoolAdvisor `
			-ResourceGroupName $ep.ResourceGroupName `
			-ServerName $ep.ServerName `
			-ElasticPoolName $ep.ElasticPoolName `
			-ExpandRecommendedActions
		Assert-NotNull $response
		Assert-AreEqual 4 $response.Count
		foreach($advisor in $response)
		{
			ValidateElasticPool $advisor $ep
			ValidateAdvisorProperties $advisor
		}
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests Getting a elastic pool advisor
#>
function Test-GetElasticPoolAdvisor
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$ep = SetupElasticPool $rg

	try
	{
		$response = Get-AzureRmSqlElasticPoolAdvisor `
			-ResourceGroupName $ep.ResourceGroupName `
			-ServerName $ep.ServerName `
			-ElasticPoolName $ep.ElasticPoolName `
			-AdvisorName CreateIndex
		Assert-NotNull $response
		ValidateElasticPool $response $ep
		ValidateAdvisorProperties $response
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Tests updating a elastic pool advisor
#>
function Test-UpdateElasticPoolAdvisor
{
	# Setup
	$rg = Create-ResourceGroupForTest
	$ep = SetupElasticPool $rg

	try
	{
		$response = Set-AzureRmSqlElasticPoolAdvisorAutoExecuteStatus `
			-ResourceGroupName $ep.ResourceGroupName `
			-ServerName $ep.ServerName `
			-ElasticPoolName $ep.ElasticPoolName `
			-AdvisorName CreateIndex `
			-AutoExecuteStatus Disabled
		Assert-NotNull $response
		ValidateElasticPool $response $ep
		ValidateAdvisorProperties $response
	}
	finally
	{
		# Cleanup
		Remove-ResourceGroupForTest $rg
	}
}

<#
	.SYNOPSIS
	Setup Server for tests
#>
function SetupServer($resourceGroup)
{
	$location = "Southeast Asia"
	$serverVersion = "12.0";
	$server = Create-ServerForTest $resourceGroup $serverVersion $location
	return $server
}

<#
	.SYNOPSIS
	Setup Database for tests
#>
function SetupDatabase($resourceGroup)
{
	$server = SetupServer $resourceGroup
	$databaseName = Get-DatabaseName
	$db = New-AzureRmSqlDatabase `
		-ResourceGroupName $server.ResourceGroupName `
		-ServerName $server.ServerName `
		-DatabaseName $databaseName `
		-Edition Basic
	return $db
}

<#
	.SYNOPSIS
	Setup Elastic pool for tests
#>
function SetupElasticPool($resourceGroup)
{
	$server = SetupServer $resourceGroup
	$poolName = Get-ElasticPoolName
	$ep = New-AzureRmSqlElasticPool `
		-ServerName $server.ServerName `
		-ResourceGroupName $server.ResourceGroupName `
		-ElasticPoolName $poolName -Edition Basic
	return $ep
}

<#
	.SYNOPSIS
	Validates server resource in Advisor response
#>
function ValidateServer($responseAdvisor, $expectedServer)
{
	Assert-AreEqual $responseAdvisor.ResourceGroupName $expectedServer.ResourceGroupName
	Assert-AreEqual $responseAdvisor.ServerName $expectedServer.ServerName
}

<#
	.SYNOPSIS
	Validates database resource in Advisor response
#>
function ValidateDatabase($responseAdvisor, $expectedDatabase)
{
	Assert-AreEqual $responseAdvisor.ResourceGroupName $expectedDatabase.ResourceGroupName
	Assert-AreEqual $responseAdvisor.ServerName $expectedDatabase.ServerName
	Assert-AreEqual $responseAdvisor.DatabaseName $expectedDatabase.DatabaseName
}

<#
	.SYNOPSIS
	Validates elastic pool resource in Advisor response
#>
function ValidateElasticPool($responseAdvisor, $expectedElasticPool)
{
	Assert-AreEqual $responseAdvisor.ResourceGroupName $expectedElasticPool.ResourceGroupName
	Assert-AreEqual $responseAdvisor.ServerName $expectedElasticPool.ServerName
	Assert-AreEqual $responseAdvisor.ElasticPoolName $expectedElasticPool.ElasticPoolName
}

<#
	.SYNOPSIS
	Validates properties in Advisor response
	Some Advisor properties are volatile and var with DB worload, so we exlude them from validation in tests.
#>
function ValidateAdvisorProperties($advisor, $expanded = $false)
{
	Assert-True {($advisor.AdvisorStatus -eq "GA") `
		-or ($advisor.AdvisorStatus -eq "PublicPreview") `
		-or ($advisor.AdvisorStatus -eq "PrivatePreview")}
	Assert-AreEqual "Disabled" $advisor.AutoExecuteStatus
	Assert-True {($advisor.AutoExecuteStatusInheritedFrom -eq "Default") -or `
		($advisor.AutoExecuteStatusInheritedFrom -eq "Server") -or `
		($advisor.AutoExecuteStatusInheritedFrom -eq "ElasticPool") -or `
		($advisor.AutoExecuteStatusInheritedFrom -eq "Database")}
}