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
Test Action Rule Operations
#>
function Test-GetActionRulesFilteredByParameters
{
	$severityFilter = "Sev3"
	$monitorService = "Platform"
	$actionRules = Get-AzActionRule -Severity $severityFilter -MonitorService $monitorService
}

function Test-CreateAndDeleteActionRule
{
    $summary = Measure-AzAlertStatistic -GroupBy "severity,alertstate"

	Assert-AreEqual "severity" $summary.GroupBy
	Assert-NotNull $summary.TotalAlerts

	ForEach ($item in $summary.AggregatedCounts.Content){
		Assert-AreEqual "alertState" $item.GroupedBy
		Assert-NotNull $item.Count
	}
} 

function Test-CreateAndUpdateActionRule
{
	$resourceGroupName = "ActionRules-Powershell-Test"
    $actionRuleName = "ScenarioTest-ActionRule"
	$actionRuleJson = "{\""properties\"":{\""actionGroupId\"":\""/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/actionrules-powershell-test/providers/microsoft.insights/actionGroups/powershell-test-ag\"",\""scope\"":{\""scopeType\"":\""ResourceGroup\"",\""values\"":[\""/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/alertslab\"",\""/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/Test-VMs\""]},\""conditions\"":{\""severity\"":{\""operator\"":\""Equals\"",\""values\"":[\""Sev2\""]},\""monitorService\"":null,\""monitorCondition\"":null,\""targetResourceType\"":null,\""alertRuleId\"":null,\""description\"":null,\""alertContext\"":null},\""description\"":\""Test Supression Rule\"",\""createdAt\"":null,\""lastModifiedAt\"":null,\""createdBy\"":null,\""lastModifiedBy\"":null,\""status\"":\""Enabled\""},\""location\"":\""Global\"",\""tags\"":{}}"

	$createdActionRule = Set-AzActionRule -ResourceGroupName $resourceGroupName -Name $actionRuleName 
		-ScopeType "ResourceGroup" -ScopeValues "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/alertslab,/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/Test-VMs"
		-SeverityCondition "Equals:Sev0,Sev1"
	
	Assert.NotNull $createdActionRule
}