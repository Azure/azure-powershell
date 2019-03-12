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

# Setup
$ruleName = 
$resourceGroupName =
$location =
$description =
$severity =
$throttlingInMin =
$actionGroup =
$emailSubject = 
$customWebhookPayload = 
$thresholdOperator = 
$threshold = 
$metricTriggerType =
$metricColumn =
$frequencyInMin = 
$timeWindowInMin = 
$query =
$authorizedResources = 
$dataSourceId = 
$queryType = 
$metricTriggerThreshold = 
$metricTriggerThresholdOperator =

$tags = New-Object "System.Collections.Generic.Dictionary``2[System.String,System.String]"
$tags.Add('key', 'value')


function Create-NewAznsActionGroup
{
	$aznsActionGroup = New-AzScheduledQueryRuleAznsActionGroup -ActionGroup $actionGroup -EmailSubject $emailSubject -CustomWebhookPayload $customWebhookPayload
	Assert-NotNull $aznsActionGroup
	Assert-AreEqual $aznsActionGroup.ActionGroup $actionGroup
	Assert-AreEqual $aznsActionGroup.EmailSubject $emailSubject
	Assert-AreEqual $aznsActionGroup.CustomWebhookPayload $customWebhookPayload

	return $aznsActionGroup
}

function Create-NewLogMetricTrigger
{
	$metricTrigger = New-AzScheduledQueryRuleLogMetricTrigger -ThresholdOperator $metricTriggerThresholdOperator -Threshold $metricTriggerThreshold -MetricTriggerType $metricTriggerType -MetricColumn $metricColumn

	Assert-NotNull $metricTrigger
	Assert-AreEqual $metricTrigger.ThresholdOperator $metricTriggerThreshold
	Assert-AreEqual $metricTrigger.Threshold $metricTriggerThreshold
	Assert-AreEqual $metricTrigger.MetricTriggerType $metricTriggerType
	Assert-AreEqual $metricTrigger.MetricColumn $metricColumn

	return $metricTrigger
}

function Create-NewTriggerCondition
{
	$metricTrigger = Create-NewLogMetricTrigger
	$triggerCondition = New-AzScheduledQueryRuleTriggerCondition -ThresholdOperator $thresholdOperator -Threshold $threshold -MetricTrigger $metricTrigger
	
	Assert-NotNull $triggerCondition
	Assert-AreEqual $triggerCondition.Threshold $threshold
	Assert-AreEqual $triggerCondition.ThresholdOperator $thresholdOperator
	Assert-AreEqual $triggerCondition.MetricTrigger $metricTrigger

	return $triggerCondition
}

function Create-NewAlertingAction
{
	$aznsActionGroup = Create-NewAznsActionGroup
	$$triggerCondition = Create-NewTriggerCondition
	$alertingAction = New-AzScheduledQueryRuleAlertingAction -AznsAction $aznsActionGroup -Severity $severity -ThrottlingInMin $throttlingInMin -Trigger $triggerCondition

	Assert-NotNull $alertingAction
	Assert-AreEqual $alertingAction.AznsAction $aznsActionGroup
	Assert-AreEqual $alertingAction.Severity $severity
	Assert-AreEqual $alertingAction.ThrottlingInMin $throttlingInMin
	Assert-AreEqual $alertingAction.Trigger $triggerCondition

	return $alertingAction
}

function Create-NewSchedule
{
	$schedule = New-AzScheduledQueryRuleSchedule -FrequencyInMinutes $frequencyInMin -TimeWindowInMinutes $timeWindowInMin
	Assert-NotNull $schedule
	Assert-AreEqual $schedule.FrequencyInMinutes $frequencyInMin
	Assert-AreEqual $schedule.TimeWindowInMinutes $timeWindowInMin

	return $schedule
}

function Create-NewSource
{
	$source = New-AzScheduledQueryRuleSource -Query $query -DataSourceId $dataSourceId -AuthorizedResources $authorizedResources -QueryType $queryType
	Assert-NotNull $source
	Assert-AreEqual $source.Query $query
	Assert-AreEqual $source.DataSourceId $dataSourceId
	Assert-AreEqual $source.AuthorizedResources $authorizedResources

	return $source
}

function Create-NewScheduledQueryRule
{
	Write-Verbose " ****** Creating a new alerting action"
		$alertingAction = Create-NewAlertingAction
		
		Write-Verbose " ****** Creating a new Schedule"
		$schedule = Create-NewSchedule

		Write-Verbose " ****** Creating a new Source"
		$source = Create-NewSource
		
		Write-Verbose " ****** Creating a new Scheduled Query Rule"
		$scheduledQueryRule = New-AzScheduledQueryRule -Location $location -RuleName $ruleName -ResourceGroupName $resourceGroupName -Action $alertingAction -Source $source -Enabled "true" -Description $description -Schedule $schedule -Tags $tags

		return $scheduledQueryRule
}

function Verify-ScheduledQueryRule($scheduledQueryRule)
{
	Assert-NotNull $scheduledQueryRule
	Assert-AreEqual $scheduledQueryRule.RuleName $ruleName
	Assert-AreEqual $scheduledQueryRule.ResourceGroupName $resourceGroupName
	Assert-AreEqual $scheduledQueryRule.Location $location
}

<#
.SYNOPSIS

#>
function Test-NewGetUpdateSetRemoveScheduledQueryRule
{
	Write-Output "Starting Test-NewGetUpdateSetRemoveScheduledQueryRule"
	
	try
	{
		
		$scheduledQueryRule = Create-NewScheduledQueryRule
		Verify-ScheduledQueryRule $scheduledQueryRule
				
		Write-Verbose " ****** Getting the Scheduled Query Rule by name"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -RuleName $ruleName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Verify-ScheduledQueryRule $retrieved[0]
		
		Write-Verbose " ****** Getting the Scheduled Query Rule by subscriptionId"
		$retrieved = Get-AzScheduledQueryRule
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Verify-ScheduledQueryRule $retrieved[0]
		
		Write-Verbose " ****** Getting the Scheduled Query Rule by resource group"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroupName $resourceGroupName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Verify-ScheduledQueryRule $retrieved[0]


		# testing Set-* cmdlet with same parameters as they were setup, as it is similar to New-*

		Write-Verbose " ****** Updating Scheduled Query Rule by name (PUT semantics)"
		$updated = New-AzScheduledQueryRule -Location $location -RuleName $ruleName -ResourceGroupName $resourceGroupName -Action $alertingAction -Source $source -Enabled "true" -Description $description -Schedule $schedule -Tags $tags
		Verify-ScheduledQueryRule $scheduledQueryRule

		Write-Verbose " ****** Updating Scheduled Query Rule by resource Id (PUT semantics)"
		$updated = New-AzScheduledQueryRule -ResourceId $scheduledQueryRule.Id -Location $location -Action $alertingAction -Source $source -Enabled "true" -Description $description -Schedule $schedule -Tags $tags
		Verify-ScheduledQueryRule $scheduledQueryRule

		Write-Verbose " ****** Updating Scheduled Query Rule by InputObject (PUT semantics)"
		$updated = New-AzScheduledQueryRule -InputObject $scheduledQueryRule -Location $location -Action $alertingAction -Source $source -Enabled "true" -Description $description -Schedule $schedule -Tags $tags
		Verify-ScheduledQueryRule $scheduledQueryRule


		Write-Verbose " ****** Updating Scheduled Query Rule by name (PATCH semantics)"
		$updated = Update-AzScheduledQueryRule -ResourceGroupName $resourceGroupName -RuleName $ruleName -Enabled "false"
		Verify-ScheduledQueryRule $updated
		Assert-AreEqual $updated.Enabled "false"

		Write-Verbose " ****** Updating Scheduled Query Rule by resource Id (PATCH semantics)"
		$updated = Update-AzScheduledQueryRule -ResourceId $scheduledQueryRule.Id -Enabled "false"
		Verify-ScheduledQueryRule $updated
		Assert-AreEqual $updated.Enabled "false"

		Write-Verbose " ****** Updating Scheduled Query Rule by InputObject (PATCH semantics)"
		$updated = Update-AzScheduledQueryRule -InputObject $scheduledQueryRule -Enabled "false"
		Verify-ScheduledQueryRule $updated
		Assert-AreEqual $updated.Enabled "false"

		Write-Verbose " ****** Removing Scheduled Query Rule by name"
		Remove-AzScheduledQueryRule -ResourceGroup $resourceGroupName -RuleName $ruleName

		Write-Verbose " ****** Removing Scheduled Query Rule by resource Id"
		Remove-AzScheduledQueryRule -ResourceId $scheduledQueryRule.Id

		Write-Verbose " ****** Removing Scheduled Query Rule by InputObject"
		Remove-AzScheduledQueryRule -InputObject $scheduledQueryRule
    }
	catch
	{
		Write-Output $_
	}
    finally
    {
        # Cleanup
        # No cleanup needed for now
    }
}

function Test-PipingRemoveSetUpdateScheduledQueryRule
{
	Write-Output "Starting Test-PipingRemoveSetUpdateScheduledQueryRule"
	try
	{
		$scheduledQueryRule = Create-NewScheduledQueryRule
		Verify-ScheduledQueryRule $scheduledQueryRule

		Write-Verbose " ****** Updating Scheduled Query Rule by name"
		Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -RuleName $ruleName | Update-AzScheduledQueryRule -Enabled "false"
		Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -RuleName $ruleName | Set-AzScheduledQueryRule
		
		Write-Verbose " ****** Updating Scheduled Query Rule by Resource Id"
		Get-AzScheduledQueryRule -ResourceId $resourceId | Update-AzScheduledQueryRule -Enabled "false"
		Get-AzScheduledQueryRule -ResourceId $resourceId | Set-AzScheduledQueryRule


		Write-Verbose " ****** Removing Scheduled Query Rule by name"
		Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -RuleName $ruleName | Remove-AzScheduledQueryRule
		
		Write-Verbose " ****** Removing Scheduled Query Rule by Resource Id"
		Get-AzScheduledQueryRule -ResourceId $resourceId | Remove-AzScheduledQueryRule

		Write-Verbose " ****** Removing Scheduled Query Rules in ResourceGroup"
		Get-AzScheduledQueryRule -ResourceGroupName $resourceGroupName | Remove-AzScheduledQueryRule

		Write-Verbose " ****** Removing Scheduled Query Rules in the current subscription"
		Get-AzScheduledQueryRule | Remove-AzScheduledQueryRule
		
	}
	catch
	{
		Write-Output $_
	}
	finally
	{
	
	}
}
