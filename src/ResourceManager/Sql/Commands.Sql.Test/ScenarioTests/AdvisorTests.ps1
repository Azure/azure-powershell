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
	Tests listing database advisors
#>
function Test-ListDatabaseAdvisors
{
	$response = Get-AzureRmSqlDatabaseAdvisor -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -DatabaseName WIRunner 
	Assert-NotNull $response
	Assert-AreEqual $response.Count 4
	foreach($advisor in $response)
	{
		ValidateDatabase $advisor
		ValidateAdvisorProperties $advisor
	}
}

<#
	.SYNOPSIS
	Tests listing database advisors with recommended actions
#>
function Test-ListDatabaseAdvisorsExpanded
{
	$response = Get-AzureRmSqlDatabaseAdvisor -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -DatabaseName WIRunner -ExpandRecommendedActions
	Assert-NotNull $response
	Assert-AreEqual $response.Count 4
	$response > output.txt
	foreach($advisor in $response)
	{
		ValidateDatabase $advisor
		ValidateAdvisorProperties $advisor true
	}
}

<#
	.SYNOPSIS
	Tests Getting a database advisor
#>
function Test-GetDatabaseAdvisor
{
	$response = Get-AzureRmSqlDatabaseAdvisor -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -DatabaseName WIRunner -AdvisorName CreateIndex
	Assert-NotNull $response
	ValidateDatabase $response
	ValidateAdvisorProperties $response
}

<#
	.SYNOPSIS
	Tests updating a database advisor
#>
function Test-UpdateDatabaseAdvisor
{
	$response = Set-AzureRmSqlDatabaseAdvisorAutoExecuteStatus -ResourceGroupName WIRunnersProd -ServerName wi-runner-australia-east -DatabaseName WIRunner -AdvisorName CreateIndex -AutoExecuteStatus Disabled
	Assert-NotNull $response
	ValidateDatabase $response
	ValidateAdvisorProperties $response
}

<#
	.SYNOPSIS
	Validates server resource in Advisor response
#>
function ValidateServer($advisor)
{
	Assert-AreEqual $advisor.ResourceGroupName "WIRunnersProd"
	Assert-AreEqual $advisor.ServerName "wi-runner-australia-east"
}

<#
	.SYNOPSIS
	Validates database resource in Advisor response
#>
function ValidateDatabase($advisor)
{
	ValidateServer $advisor
	Assert-AreEqual $advisor.DatabaseName "WIRunner"
}

<#
	.SYNOPSIS
	Validates elastic pool resource in Advisor response
#>
function ValidateElasticPool($advisor)
{
	ValidateServer $advisor
	Assert-AreEqual $advisor.ElasticPoolName "WIRunnerPool"
}

<#
	.SYNOPSIS
	Validates properties in Advisor response
#>
function ValidateAdvisorProperties($advisor, $expanded = $false)
{
		$countOfRecommendedActions = 0

		if($advisor.AdvisorName -eq "CreateIndex")
		{
			if($expanded){ $countOfRecommendedActions = 10 }
			Assert-AreEqual $advisor.AdvisorStatus "GA"
			Assert-AreEqual $advisor.AutoExecuteStatus "Disabled"
			Assert-AreEqual $advisor.AutoExecuteStatusInheritedFrom "Database"
			Assert-AreEqual $advisor.LastChecked "6/23/2016 3:57:09 AM"
			Assert-AreEqual $advisor.RecommendationsStatus "Ok"
			Assert-AreEqual $advisor.RecommendedActions.Count $countOfRecommendedActions
		}

		elseif($advisor.AdvisorName -eq "DropIndex")
		{
			if($expanded){ $countOfRecommendedActions = 10 }
			Assert-AreEqual $advisor.AdvisorStatus "PublicPreview"
			Assert-AreEqual $advisor.AutoExecuteStatus "Disabled"
			Assert-AreEqual $advisor.AutoExecuteStatusInheritedFrom "Database"
			Assert-AreEqual $advisor.LastChecked "6/22/2016 6:34:42 PM"
			Assert-AreEqual $advisor.RecommendationsStatus "Ok"
			Assert-AreEqual $advisor.RecommendedActions.Count $countOfRecommendedActions
		}

		elseif($advisor.AdvisorName -eq "DbParameterization")
		{
			Assert-AreEqual $advisor.AdvisorStatus "PublicPreview"
			Assert-AreEqual $advisor.AutoExecuteStatus "Disabled"
			Assert-AreEqual $advisor.AutoExecuteStatusInheritedFrom "Subscription"
			Assert-AreEqual $advisor.LastChecked "6/21/2016 10:04:57 PM"
			Assert-AreEqual $advisor.RecommendationsStatus "NoDbParameterizationIssue"
			Assert-AreEqual $advisor.RecommendedActions.Count $countOfRecommendedActions
		}

		elseif($advisor.AdvisorName -eq "SchemaIssue")
		{
			Assert-AreEqual $advisor.AdvisorStatus "PublicPreview"
			Assert-AreEqual $advisor.AutoExecuteStatus "Disabled"
			Assert-AreEqual $advisor.AutoExecuteStatusInheritedFrom "Subscription"
			Assert-AreEqual $advisor.LastChecked "6/23/2016 10:20:59 AM"
			Assert-AreEqual $advisor.RecommendationsStatus "SchemaIsConsistent"
			Assert-AreEqual $advisor.RecommendedActions.Count $countOfRecommendedActions
		}

		else
		{
			throw "Unexpected advisor name"
		}
}