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
function Test-setup
{
	$global:ruleName = Get-ResourceName
	$global:resourceGroupName = Get-ResourceGroupName
	$global:location = Get-ProviderLocation("microsoft.insights")
	$global:description = "SQR log alert rule"
	$global:severity = "2"
	$global:throttlingInMin = "5"
	$global:enabled = 1
	$global:emailSubject = "SQR Log alert trigger notification"
	$global:customWebhookPayload = "{}"
	$global:thresholdOperator = "GreaterThan"
	$global:threshold = 5
	$global:metricTriggerType = "Total"
	$global:metricTriggerColumn = "timestamp"
	$global:frequencyInMin = 5
	$global:timeWindowInMin = 5
	$global:query = "traces | summarize AggregatedValue = count() by bin(timestamp, 5m)"

	# Create resource group
	New-AzResourceGroup -Name $resourceGroupName -Location $location -Force

	$appInsightsResourceName = Get-ResourceName

	# Create the App Insights Resource
	$appInsightsResource = New-AzureRmApplicationInsights `
	-Name $appInsightsResourceName `
	-ResourceGroupName $resourceGroupName `
	-Location $location

	# Create Action group
	$actionGroupName = Get-ResourceName
	$email = New-AzActionGroupReceiver -Name 'user1' -EmailReceiver -EmailAddress 'user1@example.com'
	$newActionGroup =  Set-AzureRmActionGroup -Name $actionGroupName -ResourceGroup $resourceGroupName -ShortName ASTG -Receiver $email
	$actionGroupResource = New-AzActionGroup -ActionGroupId $newActionGroup.Id
	$global:actionGroup = @($newActionGroup.Id)
	
	$global:subscription = (Get-AzureRmContext).Subscription
	$global:authorizedResources = "/subscriptions/" + $subscription + "/resourceGroups/" + $resourceGroupName + "/providers/microsoft.insights/components/" + $appInsightsResourceName
	$global:dataSourceId = $authorizedResources
	$global:queryType = "ResultCount"
	$global:metricTriggerThreshold = 10
	$global:metricTriggerThresholdOperator = "GreaterThan"

	$global:tags = @{}
}

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
	#Assert-AreEqual $scheduledQueryRule.Location $location
	Assert-AreEqual $scheduledQueryRule.Description $description
	
	Assert-AreEqual $scheduledQueryRule.Action.Severity $severity
	Assert-AreEqual $scheduledQueryRule.Action.ThrottlingInMin $throttlingInMin
		
	Assert-AreEqual $scheduledQueryRule.Action.Trigger.Threshold $threshold
	Assert-AreEqual $scheduledQueryRule.Action.Trigger.ThresholdOperator $thresholdOperator

	Assert-AreEqual $scheduledQueryRule.Action.Trigger.MetricTrigger.Threshold $metricTriggerThreshold
	Assert-AreEqual $scheduledQueryRule.Action.Trigger.MetricTrigger.ThresholdOperator $metricTriggerThresholdOperator
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
	Write-Debug "Starting Test-NewGetUpdateSetRemoveScheduledQueryRule"
	Test-setup
	try
	{
		$aznsActionGroup = New-AzScheduledQueryRuleAznsActionGroup -ActionGroup $actionGroup -EmailSubject $emailSubject -CustomWebhookPayload $customWebhookPayload

		$metricTrigger = New-AzScheduledQueryRuleLogMetricTrigger -ThresholdOperator $metricTriggerthresholdOperator -Threshold $metricTriggerThreshold -MetricTriggerType $metricTriggerType -MetricColumn $metricTriggerColumn

		$triggerCondition = New-AzScheduledQueryRuleTriggerCondition -ThresholdOperator $thresholdOperator -Threshold $threshold -MetricTrigger $metricTrigger

		$alertingAction = New-AzScheduledQueryRuleAlertingAction -AznsAction $aznsActionGroup -Severity $severity -ThrottlingInMinutes $throttlingInMin -Trigger $triggerCondition

		$schedule = New-AzScheduledQueryRuleSchedule -FrequencyInMinutes $frequencyInMin -TimeWindowInMinutes $timeWindowInMin

		$source = New-AzScheduledQueryRuleSource -Query $query -DataSourceId $dataSourceId -AuthorizedResource $authorizedResources -QueryType $queryType

		$scheduledQueryRule = New-AzScheduledQueryRule -Location $location -Name $ruleName -ResourceGroupName $resourceGroupName -Action $alertingAction -Source $source -Enabled $enabled -Description $description -Schedule $schedule -Tag $tags

        Verify-ScheduledQueryRule $scheduledQueryRule
				
		Write-Debug " ****** Getting the Scheduled Query Rule by name"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -Name $ruleName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Verify-ScheduledQueryRule $retrieved[0]
		
		Write-Debug " ****** Getting the Scheduled Query Rule by subscriptionId"
		$retrieved = Get-AzScheduledQueryRule
		Assert-NotNull $retrieved
		
		Write-Debug " ****** Getting the Scheduled Query Rule by resource group"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroupName $resourceGroupName
		Assert-NotNull $retrieved
		Assert-AreEqual 1 $retrieved.Length
		Verify-ScheduledQueryRule $retrieved[0]

		# testing Set-* cmdlet with same parameters as they were setup, as it is similar to New-*

		Write-Debug " ****** Updating Scheduled Query Rule by name (PUT semantics)"
		$updated = Set-AzScheduledQueryRule -Location $location -Name $ruleName -ResourceGroupName $resourceGroupName -Action $alertingAction -Source $source -Enabled 1 -Description $description -Schedule $schedule -Tag $tags
		Verify-ScheduledQueryRule $scheduledQueryRule

		Write-Debug " ****** Updating Scheduled Query Rule by resource Id (PUT semantics)"
		$updated = Set-AzScheduledQueryRule -ResourceId $scheduledQueryRule.Id -Location $location -Action $alertingAction -Source $source -Enabled 1 -Description $description -Schedule $schedule -Tag $tags
		Verify-ScheduledQueryRule $scheduledQueryRule

		Write-Debug " ****** Updating Scheduled Query Rule by InputObject (PUT semantics)"
		$updated = Set-AzScheduledQueryRule -InputObject $scheduledQueryRule -Location $location -Action $alertingAction -Source $source -Enabled 1 -Description $description -Schedule $schedule -Tag $tags
		Verify-ScheduledQueryRule $scheduledQueryRule

		Write-Debug " ****** Updating Scheduled Query Rule by name (PATCH semantics)"
		$updated = Update-AzScheduledQueryRule -ResourceGroupName $resourceGroupName -Name $ruleName -Enabled 0
		Verify-ScheduledQueryRule $updated
		Assert-AreEqual $updated.Enabled false

		Write-Debug " ****** Updating Scheduled Query Rule by resource Id (PATCH semantics)"
		$updated = Update-AzScheduledQueryRule -ResourceId $scheduledQueryRule.Id -Enabled 0
		Verify-ScheduledQueryRule $updated
		Assert-AreEqual $updated.Enabled false

		Write-Debug " ****** Updating Scheduled Query Rule by InputObject (PATCH semantics)"
		$updated = Update-AzScheduledQueryRule -InputObject $scheduledQueryRule -Enabled 0
		Verify-ScheduledQueryRule $updated
		Assert-AreEqual $updated.Enabled false

		Write-Debug " ****** Removing Scheduled Query Rule by name"
		Remove-AzScheduledQueryRule -ResourceGroup $resourceGroupName -Name $ruleName

		Write-Debug " ****** Removing Scheduled Query Rule by resource Id"
		Remove-AzScheduledQueryRule -ResourceId $scheduledQueryRule.Id

		Write-Debug " ****** Removing Scheduled Query Rule by InputObject"
		Remove-AzScheduledQueryRule -InputObject $scheduledQueryRule
    }
	catch
	{
		#Write-Debug $_
		throw $_
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup($resourceGroupName)
    }
}

function Test-PipingRemoveSetUpdateScheduledQueryRule
{
	Write-Debug "Starting Test-PipingRemoveSetUpdateScheduledQueryRule"
	Test-setup
	try
	{
		$aznsActionGroup = New-AzScheduledQueryRuleAznsActionGroup -ActionGroup $actionGroup -EmailSubject $emailSubject -CustomWebhookPayload $customWebhookPayload

		$metricTrigger = New-AzScheduledQueryRuleLogMetricTrigger -ThresholdOperator $metricTriggerthresholdOperator -Threshold $metricTriggerThreshold -MetricTriggerType $metricTriggerType -MetricColumn $metricTriggerColumn

		$triggerCondition = New-AzScheduledQueryRuleTriggerCondition -ThresholdOperator $thresholdOperator -Threshold $threshold -MetricTrigger $metricTrigger

		$alertingAction = New-AzScheduledQueryRuleAlertingAction -AznsAction $aznsActionGroup -Severity $severity -ThrottlingInMinutes $throttlingInMin -Trigger $triggerCondition

		$schedule = New-AzScheduledQueryRuleSchedule -FrequencyInMinutes $frequencyInMin -TimeWindowInMinutes $timeWindowInMin

		$source = New-AzScheduledQueryRuleSource -Query $query -DataSourceId $dataSourceId -AuthorizedResource $authorizedResources -QueryType $queryType

		$scheduledQueryRule = New-AzScheduledQueryRule -Location $location -Name $ruleName -ResourceGroupName $resourceGroupName -Action $alertingAction -Source $source -Enabled $enabled -Description $description -Schedule $schedule -Tag $tags

        Verify-ScheduledQueryRule $scheduledQueryRule
        $resourceId = $scheduledQueryRule.Id

		Write-Debug " ****** Updating Scheduled Query Rule by name"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -Name $ruleName | Update-AzScheduledQueryRule -Enabled 0

		Verify-ScheduledQueryRule $retrieved
		Assert-AreEqual $retrieved.Enabled false

		$retrieved = Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -Name $ruleName | Set-AzScheduledQueryRule
		Verify-ScheduledQueryRule $retrieved
		
		Write-Debug " ****** Updating Scheduled Query Rule by Resource Id"
		$retrieved = Get-AzScheduledQueryRule -ResourceId $resourceId | Update-AzScheduledQueryRule -Enabled 1
		Assert-AreEqual $retrieved.Enabled true
		Verify-ScheduledQueryRule $retrieved
		
        $retrieved = Get-AzScheduledQueryRule -ResourceId $resourceId | Set-AzScheduledQueryRule
		Verify-ScheduledQueryRule $retrieved

		Write-Debug " ****** Removing Scheduled Query Rule by name"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroup $resourceGroupName -Name $ruleName | Remove-AzScheduledQueryRule
		Assert-Null $retrieved
		
		$scheduledQueryRule = New-AzScheduledQueryRule -Location $location -Name $ruleName -ResourceGroupName $resourceGroupName -Action $alertingAction -Source $source -Enabled $enabled -Description $description -Schedule $schedule -Tag $tags
		Verify-ScheduledQueryRule $scheduledQueryRule

		Write-Debug " ****** Removing Scheduled Query Rule by Resource Id"
		$retrieved = Get-AzScheduledQueryRule -ResourceId $resourceId | Remove-AzScheduledQueryRule
		Assert-Null $retrieved

		$scheduledQueryRule = New-AzScheduledQueryRule -Location $location -Name $ruleName -ResourceGroupName $resourceGroupName -Action $alertingAction -Source $source -Enabled $enabled -Description $description -Schedule $schedule -Tag $tags
		Verify-ScheduledQueryRule $scheduledQueryRule
		Write-Debug " ****** Removing Scheduled Query Rules in ResourceGroup"
		$retrieved = Get-AzScheduledQueryRule -ResourceGroupName $resourceGroupName | Remove-AzScheduledQueryRule
		Assert-Null $retrieved

		#commenting for now to prevent deleting all alert rules in the subscription
		#Write-Debug " ****** Removing Scheduled Query Rules in the current subscription"
		#Get-AzScheduledQueryRule | Remove-AzScheduledQueryRule
		
	}
	catch
	{
		#Write-Debug $_
		throw $_
	}
	finally
	{
		Clean-ResourceGroup($resourceGroupName)
	}
}

