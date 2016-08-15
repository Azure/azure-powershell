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

<#
	.SYNOPSIS
	Tests listing Server recommended actions
#>
function Test-ListServerRecommendedActions
{
	$response = Get-AzureRmSqlServerRecommendedAction -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -AdvisorName CreateIndex
	Assert-NotNull $response
	Assert-AreEqual $response.Count 2
}

<#
	.SYNOPSIS
	Tests Getting a Server Recommended Action
#>
function Test-GetServerRecommendedAction
{
	$response = Get-AzureRmSqlServerRecommendedAction -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -AdvisorName CreateIndex -RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893
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
	$response = Set-AzureRmSqlServerRecommendedActionState -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -AdvisorName CreateIndex -RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893 -State Pending
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
	$response = Get-AzureRmSqlDatabaseRecommendedAction -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -DatabaseName WIRunner -AdvisorName CreateIndex
	Assert-NotNull $response
	Assert-AreEqual $response.Count 2
}

<#
	.SYNOPSIS
	Tests Getting a database recommended action
#>
function Test-GetDatabaseRecommendedAction
{
	$response = Get-AzureRmSqlDatabaseRecommendedAction -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -DatabaseName WIRunner -AdvisorName CreateIndex -RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893
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
	$response = Set-AzureRmSqlDatabaseRecommendedActionState -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -DatabaseName WIRunner -AdvisorName CreateIndex -RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893 -State Pending
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
	$response = Get-AzureRmSqlElasticPoolRecommendedAction -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -ElasticPoolName WIRunnerPool -AdvisorName CreateIndex
	Assert-NotNull $response
	Assert-AreEqual $response.Count 2
}

<#
	.SYNOPSIS
	Tests Getting a elastic pool recommended action
#>
function Test-GetElasticPoolRecommendedAction
{
	$response = Get-AzureRmSqlElasticPoolRecommendedAction -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -ElasticPoolName WIRunnerPool -AdvisorName CreateIndex -RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893
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
	$response = Set-AzureRmSqlElasticPoolRecommendedActionState -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -ElasticPoolName WIRunnerPool -AdvisorName CreateIndex -RecommendedActionName IR_[test_schema]_[test_table_0.0361551]_6C7AE8CC9C87E7FD5893 -State Pending
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
	Assert-AreEqual $recommendedAction.ResourceGroupName "WIRunnersProd"
	Assert-AreEqual $recommendedAction.ServerName "wi-runner-australia-east"
	Assert-AreEqual $recommendedAction.AdvisorName "CreateIndex"
}

<#
	.SYNOPSIS
	Validates database resource in RecommendedAction response
#>
function ValidateDatabase($recommendedAction)
{
	ValidateServer $recommendedAction
	Assert-AreEqual $recommendedAction.DatabaseName "WIRunner"
}

<#
	.SYNOPSIS
	Validates elastic pool resource in RecommendedAction response
#>
function ValidateElasticPool($recommendedAction)
{
	ValidateServer $recommendedAction
	Assert-AreEqual $recommendedAction.ElasticPoolName "WIRunnerPool"
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
