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
$ruleName = "SQRPSTestAlert"
$resourceGroupName = "PSCmdletRG"
$location = "eastus"
$description = "SQR log alert rule"
$severity = "2"
$throttlingInMin = "5"
$enabled = "true"
$emailSubject = "SQR Log alert trigger notification"
$customWebhookPayload = "{}"
$thresholdOperator = "GreaterThan"
$threshold = 5
$metricTriggerType = "Total"
$metricTriggerColumn = "timestamp"
$frequencyInMin = 5
$timeWindowInMin = 5
$query = "traces | summarize AggregatedValue = count() by bin(timestamp, 5m)"
$authorizedResources = "/subscriptions/ad825170-845c-47db-8f00-11978947b089/resourceGroups/PSCmdletRG/providers/microsoft.insights/components/PSCmdletsAI"
$dataSourceId = "/subscriptions/ad825170-845c-47db-8f00-11978947b089/resourceGroups/PSCmdletRG/providers/microsoft.insights/components/PSCmdletsAI"
$queryType = "ResultCount"
$metricTriggerThreshold = 10
$metricTriggerThresholdOperator = "GreaterThan"

$actionGroup = New-Object "System.Collections.Generic.List[System.String]"
$tags = New-Object "System.Collections.Generic.Dictionary[string, string]"


function Verify-ScheduledQueryRule($scheduledQueryRule)
{
	Assert-NotNull $scheduledQueryRule
	
	Assert-NotNull $scheduledQueryRule.Source
	Assert-NotNull $scheduledQueryRule.Schedule
	
	Assert-NotNull $scheduledQueryRule.Action
	Assert-NotNull $scheduledQueryRule.Action.Trigger
	Assert-NotNull $scheduledQueryRule.Action.Trigger.MetricTrigger
	Assert-NotNull $scheduledQueryRule.Action.AznsAction

	Assert-AreEqual $scheduledQueryRule.Name $ruleName
	Assert-AreEqual $scheduledQueryRule.Location $location
	Assert-AreEqual $scheduledQueryRule.Description $description
	
	Assert-AreEqual $scheduledQueryRule.Action.Severity $severity
	Assert-AreEqual $scheduledQueryRule.Action.ThrottlingInMin $throttlingInMin
		
	Assert-AreEqual $scheduledQueryRule.Action.Trigger.Threshold $metricTriggerThreshold
	Assert-AreEqual $scheduledQueryRule.Action.Trigger.ThresholdOperator $metricTriggerThresholdOperator

	Assert-AreEqual $scheduledQueryRule.Action.Trigger.MetricTrigger.Threshold $threshold
	Assert-AreEqual $scheduledQueryRule.Action.Trigger.MetricTrigger.ThresholdOperator $thresholdOperator
	Assert-AreEqual $scheduledQueryRule.Action.Trigger.MetricTrigger.MetricTriggerType $metricTriggerType
	Assert-AreEqual $scheduledQueryRule.Action.Trigger.MetricTrigger.MetricColumn $metricTriggerColumn
	
	Assert-AreEqual $scheduledQueryRule.Action.AznsAction.ActionGroup $actionGroup
	Assert-AreEqual $scheduledQueryRule.Action.AznsAction.EmailSubject $emailSubject
	Assert-AreEqual $scheduledQueryRule.Action.AznsAction.CustomWebhookPayload $customWebhookPayload

	Assert-AreEqual $scheduledQueryRule.Schedule.FrequencyInMinutes $frequencyInMin
	Assert-AreEqual $scheduledQueryRule.Schedule.TimeWindowInMinutes $timeWindowInMin

	Assert-AreEqual $scheduledQueryRule.Source.Query $query
	Assert-AreEqual $scheduledQueryRule.Source.DataSourceId $dataSourceId
	Assert-AreEqual $scheduledQueryRule.Source.AuthorizedResources $authorizedResources
	Assert-AreEqual $scheduledQueryRule.Source.QueryType $queryType

}

<#
.SYNOPSIS

#>
function Test-NewGetUpdateSetRemoveScheduledQueryRule
{
	Write-Output "Starting Test-NewGetUpdateSetRemoveScheduledQueryRule"
	
	try
	{
		
		$aznsActionGroup = New-AzScheduledQueryRuleAznsActionGroup -ActionGroup $actionGroup -EmailSubject $emailSubject -CustomWebhookPayload $customWebhookPayload

		$metricTrigger = New-AzScheduledQueryRuleLogMetricTrigger -ThresholdOperator $metricTriggerthresholdOperator -Threshold $metricTriggerThreshold -MetricTriggerType $metricTriggerType -MetricColumn $metricTriggerColumn

		$triggerCondition = New-AzScheduledQueryRuleTriggerCondition -ThresholdOperator $thresholdOperator -Threshold $threshold -MetricTrigger $metricTrigger

		$alertingAction = New-AzScheduledQueryRuleAlertingAction -AznsAction $aznsActionGroup -Severity $severity -ThrottlingInMin $throttlingInMin -Trigger $triggerCondition

		$schedule = New-AzScheduledQueryRuleSchedule -FrequencyInMinutes $frequencyInMin -TimeWindowInMinutes $timeWindowInMin

		$source = New-AzScheduledQueryRuleSource -Query $query -DataSourceId $dataSourceId -AuthorizedResources $authorizedResources -QueryType $queryType

		$scheduledQueryRule = New-AzScheduledQueryRule -Location $location -RuleName $ruleName -ResourceGroupName $resourceGroupName -Action $alertingAction -Source $source -Enabled $enabled -Description $description -Schedule $schedule -Tags $tags

        Verify-ScheduledQueryRule $scheduledQueryRule
				
		Write-Verbose " ****** Getting the Scheduled Query Rule by name"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -RuleName $ruleName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Verify-ScheduledQueryRule $retrieved[0]
		
		Write-Verbose " ****** Getting the Scheduled Query Rule by subscriptionId"
		$retrieved = Get-AzScheduledQueryRule
		Assert-NotNull $retrieved
		
		Write-Verbose " ****** Getting the Scheduled Query Rule by resource group"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroupName $resourceGroupName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Verify-ScheduledQueryRule $retrieved[0]


		# testing Set-* cmdlet with same parameters as they were setup, as it is similar to New-*

		Write-Verbose " ****** Updating Scheduled Query Rule by name (PUT semantics)"
		$updated = Set-AzScheduledQueryRule -Location $location -RuleName $ruleName -ResourceGroupName $resourceGroupName -Action $alertingAction -Source $source -Enabled "true" -Description $description -Schedule $schedule -Tags $tags
		Verify-ScheduledQueryRule $scheduledQueryRule

		Write-Verbose " ****** Updating Scheduled Query Rule by resource Id (PUT semantics)"
		$updated = Set-AzScheduledQueryRule -ResourceId $scheduledQueryRule.Id -Location $location -Action $alertingAction -Source $source -Enabled "true" -Description $description -Schedule $schedule -Tags $tags
		Verify-ScheduledQueryRule $scheduledQueryRule

		Write-Verbose " ****** Updating Scheduled Query Rule by InputObject (PUT semantics)"
		$updated = Set-AzScheduledQueryRule -InputObject $scheduledQueryRule -Location $location -Action $alertingAction -Source $source -Enabled "true" -Description $description -Schedule $schedule -Tags $tags
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

		#call get again to make sure rule got deleted
		$retrieved = Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -RuleName $ruleName
        Assert-Null $retrieved
		

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
		$aznsActionGroup = New-AzScheduledQueryRuleAznsActionGroup -ActionGroup $actionGroup -EmailSubject $emailSubject -CustomWebhookPayload $customWebhookPayload

		$metricTrigger = New-AzScheduledQueryRuleLogMetricTrigger -ThresholdOperator $metricTriggerthresholdOperator -Threshold $metricTriggerThreshold -MetricTriggerType $metricTriggerType -MetricColumn $metricTriggerColumn

		$triggerCondition = New-AzScheduledQueryRuleTriggerCondition -ThresholdOperator $thresholdOperator -Threshold $threshold -MetricTrigger $metricTrigger

		$alertingAction = New-AzScheduledQueryRuleAlertingAction -AznsAction $aznsActionGroup -Severity $severity -ThrottlingInMin $throttlingInMin -Trigger $triggerCondition

		$schedule = New-AzScheduledQueryRuleSchedule -FrequencyInMinutes $frequencyInMin -TimeWindowInMinutes $timeWindowInMin

		$source = New-AzScheduledQueryRuleSource -Query $query -DataSourceId $dataSourceId -AuthorizedResources $authorizedResources -QueryType $queryType

		$scheduledQueryRule = New-AzScheduledQueryRule -Location $location -RuleName $ruleName -ResourceGroupName $resourceGroupName -Action $alertingAction -Source $source -Enabled $enabled -Description $description -Schedule $schedule -Tags $tags

        Verify-ScheduledQueryRule $scheduledQueryRule
        $resourceId = $scheduledQueryRule.Id

		Write-Verbose " ****** Updating Scheduled Query Rule by name"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -RuleName $ruleName | Update-AzScheduledQueryRule -Enabled "false"

		Verify-ScheduledQueryRule $retrieved
		Assert-AreEqual $retrieved.Enabled "false"

		$retrieved = Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -RuleName $ruleName | Set-AzScheduledQueryRule
		Verify-ScheduledQueryRule $retrieved
		
		Write-Verbose " ****** Updating Scheduled Query Rule by Resource Id"
		$retrieved = Get-AzScheduledQueryRule -ResourceId $resourceId | Update-AzScheduledQueryRule -Enabled "true"
		Assert-AreEqual $retrieved.Enabled "true"
		Verify-ScheduledQueryRule $retrieved
		
        $retrieved = Get-AzScheduledQueryRule -ResourceId $resourceId | Set-AzScheduledQueryRule
		Verify-ScheduledQueryRule $retrieved

		Write-Verbose " ****** Removing Scheduled Query Rule by name"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -RuleName $ruleName | Remove-AzScheduledQueryRule
		Verify-ScheduledQueryRule $retrieved
		
		Write-Verbose " ****** Removing Scheduled Query Rule by Resource Id"
		$retrieved = Get-AzScheduledQueryRule -ResourceId $resourceId | Remove-AzScheduledQueryRule
		Assert-Null $retrieved

		Write-Verbose " ****** Removing Scheduled Query Rules in ResourceGroup"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroupName $resourceGroupName | Remove-AzScheduledQueryRule
		Assert-Null $retrieved

		#commenting for now to prevent deleting all alert rules in the subscription
		#Write-Verbose " ****** Removing Scheduled Query Rules in the current subscription"
		#Get-AzScheduledQueryRule | Remove-AzScheduledQueryRule
		
	}
	catch
	{
		Write-Output $_
	}
	finally
	{
	
	}
}

