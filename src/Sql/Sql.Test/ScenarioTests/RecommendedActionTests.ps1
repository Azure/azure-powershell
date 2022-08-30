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


# ============================================================
# A NOTE ON (LACK OF) TEST SETUP FOR RECOMMENDED ACTIONS TESTS
# ============================================================
# Recommended actions are generated based on database workload and new database won't get any recommended actions.
# It's hard to generate mock recommendations on a new server, database or elastic pool from this code as well, as the process is Microsoft Internal.
# For now, Tests have to use recorded responses on some specific database that already has recommended actions.

# Follow below steps for recording tests:
# =======================================
# 1. If you already have necessary resources (a server, elastic Pool and database), replace resource names with your resources in "GetResourceNames()" function
# 2. If you don't have existing resources, "SetupResources()" function will create necessary resources for you on your subscription.
# 3. Send a mail to "mdcsworkloadinsight@microsoft.com" with your server/elastic pool/database details requesting to add mock recommendations for your resources.
#    Provide your subscription along with resource details and mention that you are contributing to Azure Powershell cmdlets.

<#
	.SYNOPSIS
	Get Resource names for tests
#>
function GetResourceNames()
{
	return @{ `
		"Location"          = "Australia East"
		"ResourceGroupName" = "WiPowershellTestRg"; `
		"ServerName"        = "wipowershelltestserver"; `
		"DatabaseName"      = "WiPowershellTestDb"; `
		"ElasticPoolName"   = "WiPowershellTestEp"; `
	}
}

<#
	.SYNOPSIS
	Tests listing Server recommended actions
#>
function Test-ListServerRecommendedActions
{
	$names = GetResourceNames
	$response = Get-AzSqlServerRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-AdvisorName CreateIndex
	Assert-NotNull $response
	Assert-AreEqual $response.Count 3
}

<#
	.SYNOPSIS
	Tests Getting a Server Recommended Action
#>
function Test-GetServerRecommendedAction
{
	$names = GetResourceNames
	$responseList = Get-AzSqlServerRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-AdvisorName CreateIndex | Where-Object {$_.State.currentValue -eq "Active"}
	$response = Get-AzSqlServerRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-AdvisorName CreateIndex `
		-RecommendedActionName $responseList[0].RecommendedActionName
	Assert-NotNull $response
	ValidateServer $response
	ValidateRecommendedActionProperties $response $responseList[0] 'Active'
}

<#
	.SYNOPSIS
	Tests updating a Server Recommended Action
#>
function Test-UpdateServerRecommendedAction
{
	$names = GetResourceNames
	$responseList = Get-AzSqlServerRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-AdvisorName CreateIndex | Where-Object {$_.State.currentValue -eq "Active"}
	try
	{
		$response = Set-AzSqlServerRecommendedActionState `
			-ResourceGroupName $names["ResourceGroupName"] `
			-ServerName $names["ServerName"] `
			-AdvisorName CreateIndex `
			-RecommendedActionName $responseList[0].RecommendedActionName `
			-State Pending
		$response1 = Get-AzSqlServerRecommendedAction `
			-ResourceGroupName $names["ResourceGroupName"] `
			-ServerName $names["ServerName"] `
			-AdvisorName CreateIndex `
			-RecommendedActionName $responseList[0].RecommendedActionName
		Assert-NotNull $response
		ValidateDatabase $response
		ValidateRecommendedActionProperties $response $response1 'Pending'
	}
	finally
	{
		Set-AzSqlServerRecommendedActionState `
			-ResourceGroupName $names["ResourceGroupName"] `
			-ServerName $names["ServerName"] `
			-AdvisorName CreateIndex `
			-RecommendedActionName $responseList[0].RecommendedActionName `
			-State Active
	}
}

<#
	.SYNOPSIS
	Tests listing database recommended actions
#>
function Test-ListDatabaseRecommendedActions
{
	$names = GetResourceNames
	$response = Get-AzSqlDatabaseRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-DatabaseName $names["DatabaseName"] `
		-AdvisorName CreateIndex
	Assert-NotNull $response
	Assert-AreEqual $response.Count 3
}

<#
	.SYNOPSIS
	Tests Getting a database recommended action
#>
function Test-GetDatabaseRecommendedAction
{
	$names = GetResourceNames
	$responseList = Get-AzSqlDatabaseRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-DatabaseName $names["DatabaseName"] `
		-AdvisorName CreateIndex | Where-Object {$_.State.currentValue -eq "Active"}
	$response = Get-AzSqlDatabaseRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-DatabaseName $names["DatabaseName"] `
		-AdvisorName CreateIndex `
		-RecommendedActionName $responseList[0].RecommendedActionName
	Assert-NotNull $response
	ValidateDatabase $response
	ValidateRecommendedActionProperties $response $responseList[0] 'Active'
}

<#
	.SYNOPSIS
	Tests updating a database Recommended Action
#>
function Test-UpdateDatabaseRecommendedAction
{
	$names = GetResourceNames
	$responseList = Get-AzSqlDatabaseRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-DatabaseName $names["DatabaseName"] `
		-AdvisorName CreateIndex | Where-Object {$_.State.currentValue -eq "Active"}
	try
	{
		$response = Set-AzSqlDatabaseRecommendedActionState `
			-ResourceGroupName $names["ResourceGroupName"] `
			-ServerName $names["ServerName"] `
			-DatabaseName $names["DatabaseName"] `
			-AdvisorName CreateIndex `
			-RecommendedActionName $responseList[0].RecommendedActionName `
			-State Pending
		$response1 = Get-AzSqlDatabaseRecommendedAction `
			-ResourceGroupName $names["ResourceGroupName"] `
			-ServerName $names["ServerName"] `
			-DatabaseName $names["DatabaseName"] `
			-AdvisorName CreateIndex `
			-RecommendedActionName $responseList[0].RecommendedActionName
		Assert-NotNull $response
		ValidateDatabase $response
		ValidateRecommendedActionProperties $response $response1 'Pending'
	}
	finally
	{
		Set-AzSqlDatabaseRecommendedActionState `
			-ResourceGroupName $names["ResourceGroupName"] `
			-ServerName $names["ServerName"] `
			-DatabaseName $names["DatabaseName"] `
			-AdvisorName CreateIndex `
			-RecommendedActionName $responseList[0].RecommendedActionName `
			-State Active
	}
}
<#
	.SYNOPSIS
	Tests listing elastic pool recommended actions
#>
function Test-ListElasticPoolRecommendedActions
{
	$names = GetResourceNames
	$response = Get-AzSqlElasticPoolRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-ElasticPoolName $names["ElasticPoolName"] `
		-AdvisorName CreateIndex
	Assert-NotNull $response
	Assert-AreEqual $response.Count 3
}

<#
	.SYNOPSIS
	Tests Getting a elastic pool recommended action
#>
function Test-GetElasticPoolRecommendedAction
{
	$names = GetResourceNames
	$responseList = Get-AzSqlElasticPoolRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-ElasticPoolName $names["ElasticPoolName"] `
		-AdvisorName CreateIndex | Where-Object {$_.State.currentValue -eq "Active"}
	$response = Get-AzSqlElasticPoolRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-ElasticPoolName $names["ElasticPoolName"] `
		-AdvisorName CreateIndex `
		-RecommendedActionName $responseList[0].RecommendedActionName
	Assert-NotNull $response
	ValidateElasticPool $response
	ValidateRecommendedActionProperties $response $responseList[0] 'Active'
}

<#
	.SYNOPSIS
	Tests updating a elastic pool recommended action
#>
function Test-UpdateElasticPoolRecommendedAction
{
	$names = GetResourceNames
	$responseList = Get-AzSqlElasticPoolRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-ElasticPoolName $names["ElasticPoolName"] `
		-AdvisorName CreateIndex | Where-Object {$_.State.currentValue -eq "Active"}
	try
	{
		$response = Set-AzSqlElasticPoolRecommendedActionState `
			-ResourceGroupName $names["ResourceGroupName"] `
			-ServerName $names["ServerName"] `
			-ElasticPoolName $names["ElasticPoolName"] `
			-AdvisorName CreateIndex `
			-RecommendedActionName $responseList[0].RecommendedActionName `
			-State Pending
		$response1 = Get-AzSqlElasticPoolRecommendedAction `
			-ResourceGroupName $names["ResourceGroupName"] `
			-ServerName $names["ServerName"] `
			-ElasticPoolName $names["ElasticPoolName"] `
			-AdvisorName CreateIndex `
			-RecommendedActionName $responseList[0].RecommendedActionName
		Assert-NotNull $response
		ValidateElasticPool $response
		ValidateRecommendedActionProperties $response $response1 'Pending'
	}
	finally
	{
		$response = Set-AzSqlElasticPoolRecommendedActionState `
			-ResourceGroupName $names["ResourceGroupName"] `
			-ServerName $names["ServerName"] `
			-ElasticPoolName $names["ElasticPoolName"] `
			-AdvisorName CreateIndex `
			-RecommendedActionName $responseList[0].RecommendedActionName `
			-State Active
	}
}

<#
	.SYNOPSIS
	Validates server resource in RecommendedAction response
#>
function ValidateServer($recommendedAction)
{
	Assert-AreEqual $recommendedAction.ResourceGroupName $names["ResourceGroupName"]
	Assert-AreEqual $recommendedAction.ServerName $names["ServerName"]
	Assert-AreEqual $recommendedAction.AdvisorName "CreateIndex"
}

<#
	.SYNOPSIS
	Validates database resource in RecommendedAction response
#>
function ValidateDatabase($recommendedAction)
{
	ValidateServer $recommendedAction
	Assert-AreEqual $recommendedAction.DatabaseName $names["DatabaseName"]
}

<#
	.SYNOPSIS
	Validates elastic pool resource in RecommendedAction response
#>
function ValidateElasticPool($recommendedAction)
{
	ValidateServer $recommendedAction
	Assert-AreEqual $recommendedAction.ElasticPoolName $names["ElasticPoolName"]
}

<#
	.SYNOPSIS
	Validates properties in RecommendedAction response
#>
function ValidateRecommendedActionProperties($recommendedAction, $expectedAction, $expectedState = "Success")
{
	Assert-AreEqual $recommendedAction.RecommendedActionName $expectedAction.RecommendedActionName
	Assert-AreEqual $recommendedAction.ExecuteActionDuration $expectedAction.ExecuteActionDuration
	Assert-AreEqual $recommendedAction.ExecuteActionInitiatedBy $expectedAction.ExecuteActionInitiatedBy
	Assert-AreEqual $recommendedAction.ExecuteActionInitiatedTime $expectedAction.ExecuteActionInitiatedTime
	Assert-AreEqual $recommendedAction.ExecuteActionStartTime $expectedAction.ExecuteActionStartTime
	Assert-AreEqual $recommendedAction.IsArchivedAction $expectedAction.IsArchivedAction
	Assert-AreEqual $recommendedAction.IsExecutableAction $expectedAction.IsExecutableAction
	Assert-AreEqual $recommendedAction.IsRevertableAction $expectedAction.IsRevertableAction
	Assert-AreEqual $recommendedAction.LastRefresh $expectedAction.LastRefresh
	Assert-AreEqual $recommendedAction.RecommendationReason $expectedAction.RecommendationReason
	Assert-Null $recommendedAction.RevertActionDuration 
	Assert-Null $recommendedAction.RevertActionInitiatedBy
	Assert-Null $recommendedAction.RevertActionInitiatedTime
	Assert-Null $recommendedAction.RevertActionStartTime
	Assert-AreEqual $recommendedAction.Score $expectedAction.Score
	Assert-AreEqual $recommendedAction.ValidSince $expectedAction.ValidSince
	
	ValidateRecommendedActionState $recommendedAction.State $expectedState
	ValidateRecommendedActionImplInfo $recommendedAction.ImplementationDetails $expectedAction.ImplementationDetails
	Assert-Null $recommendedAction.ErrorDetails.ErrorCode
	Assert-AreEqual $recommendedAction.EstimatedImpact.Count $expectedAction.EstimatedImpact.Count
	Assert-AreEqual $recommendedAction.ObservedImpact.Count $expectedAction.ObservedImpact.Count
	Assert-AreEqual $recommendedAction.TimeSeries.Count $expectedAction.TimeSeries.Count
	Assert-AreEqual $recommendedAction.LinkedObjects.Count $expectedAction.LinkedObjects.Count
	ValidateRecommendedActionDetails $recommendedAction.Details $expectedAction.Details
}

<#
	.SYNOPSIS
	Validates state in RecommendedAction response
#>
function ValidateRecommendedActionState($state, $expectedState)
{
	Assert-AreEqual $state.CurrentValue $expectedState
}

<#
	.SYNOPSIS
	Validates implementation info in RecommendedAction response
#>
function ValidateRecommendedActionImplInfo($implInfo, $expectedInfo)
{
	Assert-AreEqual $implInfo.Method $expectedInfo.Method
	Assert-AreEqual $implInfo.Script $expectedInfo.Script
}

<#
	.SYNOPSIS
	Validates implementation info in RecommendedAction response
#>
function ValidateRecommendedActionDetails($details, $expectedDetails)
{
	Assert-AreEqual $details.Item("indexName") $expectedDetails.Item("indexName")
	Assert-AreEqual $details.Item("indexType") $expectedDetails.Item("indexType")
	Assert-AreEqual $details.Item("schema") $expectedDetails.Item("schema")
	Assert-AreEqual $details.Item("table") $expectedDetails.Item("table")
	Assert-AreEqual $details.Item("indexColumns") $expectedDetails.Item("indexColumns")
	Assert-AreEqual $details.Item("includedColumns") $expectedDetails.Item("includedColumns")
}

<#
	.SYNOPSIS
	Sets up necessary resources for these tests. This won't be run as a part of
	tests. See the note at the top of this file. 
#>
function SetupResources()
{
	$names = GetResourceNames

	# Create Resource Group
	New-AzResourceGroup -Name $names["ResourceGroupName"] -Location $names["Location"]
	
	# Create Server
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin `
		, ($serverPassword | ConvertTo-SecureString -asPlainText -Force)) 
	
	New-AzSqlServer -ResourceGroupName  $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-Location $names["Location"] `
		-ServerVersion "12.0" `
		-SqlAdministratorCredentials $credentials

	# Create database
	New-AzSqlDatabase `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-DatabaseName $names["DatabaseName"] `
		-Edition Basic

	# Create elastic pool
	New-AzSqlElasticPool `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-ElasticPoolName $names["ElasticPoolName"] `
		-Edition Basic
}
