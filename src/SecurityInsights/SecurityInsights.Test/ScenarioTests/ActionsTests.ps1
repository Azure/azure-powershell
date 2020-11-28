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
List Actions by Alert Rule
#>
function Get-AzSentinelAlertRuleAction-ListByAlertRule
{
	
	$LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$TriggerUri = "https://prod-13.westus.logic.azure.com:443/workflows/826a95b1b84c4ffbaf3af3dd88fe96b5/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=pK23xWl4uJT4RWs7zopxiP0Z7CpIfCDZEanL-mEyy1E"
	$LogicAppResourceId2 = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Get-MDATPInvestigationPackage"
	$TriggerUri2 = "https://prod-16.westus.logic.azure.com:443/workflows/18c75599cf3742c998d14af0f89cf3b1/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=rREdJWoN3PNCmhqwMz0KRy8apQDt8DQbZZuvlm1l4Oo"
	
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -LogicAppResourceId $LogicAppResourceId -TriggerUri $TriggerUri
	#Create Alert Rule Action
	$action2 = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -LogicAppResourceId $LogicAppResourceId2 -TriggerUri $TriggerUri2
	
	#Get Alert Rule Actions
    $actions = Get-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name)
	# Validate
	Validate-Actions $actions

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name)
}

<#
.SYNOPSIS
Get Action
#>
function Get-AzSentinelAlertRuleAction-GetAction
{
	
	$LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$TriggerUri = "https://prod-13.westus.logic.azure.com:443/workflows/826a95b1b84c4ffbaf3af3dd88fe96b5/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=pK23xWl4uJT4RWs7zopxiP0Z7CpIfCDZEanL-mEyy1E"
		
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -LogicAppResourceId $LogicAppResourceId -TriggerUri $TriggerUri
		
	#Get Alert Rule Action
    $action = Get-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -ActionId ($action.Name)
	# Validate
	Validate-Action $action

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name)
}

<#
.SYNOPSIS
Create Action
#>
function New-AzSentinelAlertRuleAction-Create
{
    $LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$TriggerUri = "https://prod-13.westus.logic.azure.com:443/workflows/826a95b1b84c4ffbaf3af3dd88fe96b5/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=pK23xWl4uJT4RWs7zopxiP0Z7CpIfCDZEanL-mEyy1E"
	
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -LogicAppResourceId $LogicAppResourceId -TriggerUri $TriggerUri
	
	#Validate
	Validate-Action $action

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name)
}

<#
.SYNOPSIS
Update Action
#>
function Set-AzSentinelAlertRuleAction-Update
{
	$LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$TriggerUri = "https://prod-13.westus.logic.azure.com:443/workflows/826a95b1b84c4ffbaf3af3dd88fe96b5/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=pK23xWl4uJT4RWs7zopxiP0Z7CpIfCDZEanL-mEyy1E"
	$LogicAppResourceId2 = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Get-MDATPInvestigationPackage"
	$TriggerUri2 = "https://prod-16.westus.logic.azure.com:443/workflows/18c75599cf3742c998d14af0f89cf3b1/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=rREdJWoN3PNCmhqwMz0KRy8apQDt8DQbZZuvlm1l4Oo"
	
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -LogicAppResourceId $LogicAppResourceId -TriggerUri $TriggerUri
	
	#update action
	$action = Set-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -ActionId ($action.Name) -LogicAppResourceId $LogicAppResourceId2 -TriggerUri $TriggerUri2
	
	# Validate
	Validate-Action $action

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name)
}

<#
.SYNOPSIS
Delete Action
#>
function Remove-AzSentinelAlertRuleAction-Delete
{
	$LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$TriggerUri = "https://prod-13.westus.logic.azure.com:443/workflows/826a95b1b84c4ffbaf3af3dd88fe96b5/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=pK23xWl4uJT4RWs7zopxiP0Z7CpIfCDZEanL-mEyy1E"
			
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -LogicAppResourceId $LogicAppResourceId -TriggerUri $TriggerUri
	#delete
	Remove-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -ActionId ($action.Name) -AlertRuleId ($alertRule.Name)
	# Validate
	Validate-Action $action

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name)
}

<#
.SYNOPSIS
Validates a list of actions
#>
function Validate-Actions
{
	param($actions)

    Assert-True { $actions.Count -gt 0 }

	Foreach($action in $actions)
	{
		Validate-Action $action
	}
}

<#
.SYNOPSIS
Validates a single action
#>
function Validate-Action
{
	param($action)

	Assert-NotNull $action
}