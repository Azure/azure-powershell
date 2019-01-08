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
		"ResourceGroupName" = "WIRunnersProd"; `
		"ServerName"        = "wi-runner-australia-east"; `
		"DatabaseName"      = "WIRunner"; `
		"ElasticPoolName"   = "WIRunnerPool"; `
	}
}

<#
	.SYNOPSIS
	Tests listing Server recommended actions
#>
function Test-ListServerRecommendedActions
{
	$names = GetResourceNames
	$response = Get-AzureRmSqlServerRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-AdvisorName CreateIndex
	Assert-NotNull $response
	Assert-AreEqual $response.Count 2
}

<#
	.SYNOPSIS
	Tests Getting a Server Recommended Action
#>
function Test-GetServerRecommendedAction
{
	$names = GetResourceNames
	$response = Get-AzureRmSqlServerRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-AdvisorName CreateIndex `
		-RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893
	Assert-NotNull $response
	ValidateServer $response
	ValidateRecommendedActionProperties $response
}

<#
	.SYNOPSIS
	Tests updating a Server Recommended Action
#>
function Test-UpdateServerRecommendedAction
{
	$names = GetResourceNames
	$response = Set-AzureRmSqlServerRecommendedActionState `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-AdvisorName CreateIndex `
		-RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893 `
		-State Pending
	Assert-NotNull $response
	ValidateServer $response
	ValidateRecommendedActionProperties $response 'Pending'
}

<#
	.SYNOPSIS
	Tests listing database recommended actions
#>
function Test-ListDatabaseRecommendedActions
{
	$names = GetResourceNames
	$response = Get-AzureRmSqlDatabaseRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-DatabaseName $names["DatabaseName"] `
		-AdvisorName CreateIndex
	Assert-NotNull $response
	Assert-AreEqual $response.Count 2
}

<#
	.SYNOPSIS
	Tests Getting a database recommended action
#>
function Test-GetDatabaseRecommendedAction
{
	$names = GetResourceNames
	$response = Get-AzureRmSqlDatabaseRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-DatabaseName $names["DatabaseName"] `
		-AdvisorName CreateIndex `
		-RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893
	Assert-NotNull $response
	ValidateDatabase $response
	ValidateRecommendedActionProperties $response
}

<#
	.SYNOPSIS
	Tests updating a database Recommended Action
#>
function Test-UpdateDatabaseRecommendedAction
{
	$names = GetResourceNames
	$response = Set-AzureRmSqlDatabaseRecommendedActionState `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-DatabaseName $names["DatabaseName"] `
		-AdvisorName CreateIndex `
		-RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893 `
		-State Pending
	Assert-NotNull $response
	ValidateDatabase $response
	ValidateRecommendedActionProperties $response 'Pending'
}
<#
	.SYNOPSIS
	Tests listing elastic pool recommended actions
#>
function Test-ListElasticPoolRecommendedActions
{
	$names = GetResourceNames
	$response = Get-AzureRmSqlElasticPoolRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-ElasticPoolName $names["ElasticPoolName"] `
		-AdvisorName CreateIndex
	Assert-NotNull $response
	Assert-AreEqual $response.Count 2
}

<#
	.SYNOPSIS
	Tests Getting a elastic pool recommended action
#>
function Test-GetElasticPoolRecommendedAction
{
	$names = GetResourceNames
	$response = Get-AzureRmSqlElasticPoolRecommendedAction `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-ElasticPoolName $names["ElasticPoolName"] `
		-AdvisorName CreateIndex `
		-RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893
	Assert-NotNull $response
	ValidateElasticPool $response
	ValidateRecommendedActionProperties $response
}

<#
	.SYNOPSIS
	Tests updating a elastic pool recommended action
#>
function Test-UpdateElasticPoolRecommendedAction
{
	$names = GetResourceNames
	$response = Set-AzureRmSqlElasticPoolRecommendedActionState `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName wi-runner-australia-east `
		-ElasticPoolName $names["ElasticPoolName"] `
		-AdvisorName CreateIndex `
		-RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893 `
		-State Pending
	Assert-NotNull $response
	ValidateElasticPool $response
	ValidateRecommendedActionProperties $response 'Pending'
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
function ValidateRecommendedActionProperties($recommendedAction, $expectedState = "Success")
{
	Assert-AreEqual $recommendedAction.RecommendedActionName "IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893"
	Assert-AreEqual $recommendedAction.ExecuteActionDuration "PT1M"
	Assert-AreEqual $recommendedAction.ExecuteActionInitiatedBy "User"
	Assert-AreEqual $recommendedAction.ExecuteActionInitiatedTime "4/21/2016 3:24:47 PM"
	Assert-AreEqual $recommendedAction.ExecuteActionStartTime "4/21/2016 3:24:47 PM"
	Assert-AreEqual $recommendedAction.IsArchivedAction $false
	Assert-AreEqual $recommendedAction.IsExecutableAction $true
	Assert-AreEqual $recommendedAction.IsRevertableAction $true
	Assert-AreEqual $recommendedAction.LastRefresh "4/21/2016 3:24:47 PM"
	Assert-AreEqual $recommendedAction.RecommendationReason ""
	Assert-Null $recommendedAction.RevertActionDuration
	Assert-Null $recommendedAction.RevertActionInitiatedBy
	Assert-Null $recommendedAction.RevertActionInitiatedTime
	Assert-Null $recommendedAction.RevertActionStartTime
	Assert-AreEqual $recommendedAction.Score 2
	Assert-AreEqual $recommendedAction.ValidSince "4/21/2016 3:24:47 PM"
	
	ValidateRecommendedActionState $recommendedAction.State $expectedState
	ValidateRecommendedActionImplInfo $recommendedAction.ImplementationDetails
	Assert-Null $recommendedAction.ErrorDetails.ErrorCode
	Assert-AreEqual $recommendedAction.EstimatedImpact.Count 2
	Assert-AreEqual $recommendedAction.ObservedImpact.Count 1
	Assert-AreEqual $recommendedAction.TimeSeries.Count 0
	Assert-AreEqual $recommendedAction.LinkedObjects.Count 0
	ValidateRecommendedActionDetails $recommendedAction.Details
}

<#
	.SYNOPSIS
	Validates state in RecommendedAction response
#>
function ValidateRecommendedActionState($state, $expectedState)
{
	Assert-AreEqual $state.ActionInitiatedBy "User"
	Assert-AreEqual $state.CurrentValue $expectedState
	Assert-AreEqual $state.LastModified "4/21/2016 3:24:47 PM"
}

<#
	.SYNOPSIS
	Validates implementation info in RecommendedAction response
#>
function ValidateRecommendedActionImplInfo($implInfo)
{
	Assert-AreEqual $implInfo.Method "TSql"
	Assert-AreEqual $implInfo.Script "CREATE NONCLUSTERED INDEX [nci_wi_test_table_0.0361551_6C7AE8CC9C87E7FD5893] ON [test_schema].[test_table_0.0361551] ([index_1],[index_2],[index_3]) INCLUDE ([included_1]) WITH (ONLINE = ON)"
}

<#
	.SYNOPSIS
	Validates implementation info in RecommendedAction response
#>
function ValidateRecommendedActionDetails($details)
{
	Assert-AreEqual $details.Item("indexName") "nci_wi_test_table_0.0361551_6C7AE8CC9C87E7FD5893"
	Assert-AreEqual $details.Item("indexType") "NONCLUSTERED"
	Assert-AreEqual $details.Item("schema") "[test_schema]"
	Assert-AreEqual $details.Item("table") "[test_table_0.0361551]"
	Assert-AreEqual $details.Item("indexColumns") "[index_1],[index_2],[index_3]"
	Assert-AreEqual $details.Item("benefit") "2"
	Assert-AreEqual $details.Item("includedColumns") "[included_1]"
	Assert-AreEqual $details.Item("indexActionStartTime") "04/21/2016 15:24:47"
	Assert-AreEqual $details.Item("indexActionDuration") "00:01:00"
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
	New-AzureRmResourceGroup -Name $names["ResourceGroupName"] -Location $names["Location"]
	
	# Create Server
	$serverLogin = "testusername"
	$serverPassword = "t357ingP@s5w0rd!"
	$credentials = new-object System.Management.Automation.PSCredential($serverLogin `
		, ($serverPassword | ConvertTo-SecureString -asPlainText -Force)) 
	
	New-AzureRmSqlServer -ResourceGroupName  $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-Location $names["Location"] `
		-ServerVersion "12.0" `
		-SqlAdministratorCredentials $credentials

	# Create database
	New-AzureRmSqlDatabase `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-DatabaseName $names["DatabaseName"] `
		-Edition Basic

	# Create elastic pool
	New-AzureRmSqlElasticPool `
		-ResourceGroupName $names["ResourceGroupName"] `
		-ServerName $names["ServerName"] `
		-ElasticPoolName $names["ElasticPoolName"] `
		-Edition Basic
}
