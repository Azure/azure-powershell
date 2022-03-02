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
Test Alert Processing Rule Operations
#>
function Test-GetAlertProcessingRulesByResourceGroupName
{
	$resourceGroupName = "abc"
	$alertProcessingRules = Get-AzAlertProcessingRule -ResourceGroupName $resourceGroupName

	Assert-NotNull $alertProcessingRules.Count
}

function Test-CreateUpdateAndDeleteSuppressionRule
{
	try
	{
		$resourceGroupName = Get-TestResourceGroupName "suppression"
		$location = Get-ProviderLocation ResourceManagement
		$alertProcessingRuleName = Get-TestAlertProcessingRuleName "suppression"

		#Create Resource Group
		New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

		$createdAlertProcessingRule = Set-AzAlertProcessingRule -ResourceGroupName $resourceGroupName -Name $alertProcessingRuleName -Scope "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/alertslab","/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/Test-VMs" -FilterSeverity "Equals:Sev0,Sev1" -FilterMonitorCondition "NotEquals:Resolved" -Description "Test description" -Enabled "True" -AlertProcessingRuleType "RemoveAllActionGroups" -ScheduleReccurenceType "Daily" -ScheduleStartDateTime "2022-03-21 12:30:11" -ScheduleEndDateTime "2022-03-25 14:30:00" -ScheduleReccurenceStartTime "02:30:00" -ScheduleReccurenceEndTime "04:30:00"

		Assert-NotNull $createdAlertProcessingRule 

		# Update Enabled Status of Alert Processing Rule
		$updatedAlertProcessingRule = Update-AzAlertProcessingRule -ResourceGroupName $resourceGroupName -Name $alertProcessingRuleName -Enabled "False"
		Assert-NotNull $updatedAlertProcessingRule 
		Assert-AreEqual "False" $updatedAlertProcessingRule.Enabled
	}
	finally
	{
		CleanUp $resourceGroupName $alertProcessingRuleName
	}
}

function Test-CreateUpdateAndDeleteActionGroupRule
{
	try
	{
		$resourceGroupName = Get-TestResourceGroupName "actiongroup"
		$location = Get-ProviderLocation ResourceManagement
		$alertProcessingRuleName = Get-TestAlertProcessingRuleName "actiongroup"

		#Create Resource Group
		New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

		$createdAlertProcessingRule = Set-AzAlertProcessingRule -ResourceGroupName $resourceGroupName -Name $alertProcessingRuleName -Scope "/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/alertslab","/subscriptions/dd91de05-d791-4ceb-b6dc-988682dc7d72/resourceGroups/Test-VMs" -FilterSeverity "Equals:Sev0,Sev1" -FilterMonitorCondition "NotEquals:Resolved" -Description "Test description" -AlertPRocessingRuleType "AddActionGroups" -ActionGroupId "/subscriptions/1e3ff1c0-771a-4119-a03b-be82a51e232d/resourceGroups/alertscorrelationrg/providers/Microsoft.insights/actiongroups/testAG"

		Assert-NotNull $createdAlertProcessingRule 

		# Update Enabled Status of Alert Processing Rule
		$updatedAlertProcessingRule = Update-AzAlertProcessingRule -ResourceGroupName $resourceGroupName -Name $alertProcessingRuleName -Enabled "False"
		Assert-NotNull $updatedAlertProcessingRule 
		Assert-AreEqual "False" $updatedAlertProcessingRule.Enabled
	}
	finally
	{
		CleanUp $resourceGroupName $alertProcessingRuleName
	}
}
