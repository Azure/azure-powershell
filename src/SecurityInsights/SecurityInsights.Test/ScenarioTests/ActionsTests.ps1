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
	$AlertRuleId = "1b64dc0e-4bf6-43c4-a503-52cba30b5c47"
	$ActionId = "cd9f21e2-1718-4b8b-871e-b8d59c65f317"
	$ActionId2 = "ccef9243-4f96-4ec5-8042-9df44e2df452"
	$LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$TriggerUri = "https://prod-08.eastus.logic.azure.com:443/workflows/854f1fc04f50415f83a359463dd60e8b/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=D7IHsTelJf8XFdhefU6mFRYjnHaa0oHkY_xWC_wW_Vs"
	$LogicAppResourceId2 = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Get-MDATPInvestigationPackage"
	$TriggerUri2 = "https://prod-11.eastus.logic.azure.com:443/workflows/9f824303d57e4f00bea47052e4318d1b/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=2cGZz7eu3Y437r3LRHpkSFUTmD0X15XXP7uiW5_aLaA"
	
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -ActionId $ActionId -AlertRuleId ($alertRule.Name) -LogicAppResourceId $LogicAppResourceId -TriggerUri $TriggerUri
	#Create Alert Rule Action
	$action2 = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -ActionId $ActionId2 -AlertRuleId ($alertRule.Name) -LogicAppResourceId $LogicAppResourceId2 -TriggerUri $TriggerUri2
	
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
	$AlertRuleId = "77def5f7-ab37-4aaf-8711-904d1ab55787"
	$ActionId = "27dda575-93f0-4925-92b3-039ef4d89cad"
	$LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$TriggerUri = "https://prod-08.eastus.logic.azure.com:443/workflows/854f1fc04f50415f83a359463dd60e8b/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=D7IHsTelJf8XFdhefU6mFRYjnHaa0oHkY_xWC_wW_Vs"
		
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -ActionId $ActionId -LogicAppResourceId $LogicAppResourceId -TriggerUri $TriggerUri
		
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
    $AlertRuleId = "26501c9d-8f07-419d-8bcb-f9aac8ec1a7f"
	$ActionId = "10d54e5f-8c03-42fc-b1d9-1bd881535af0"
	$LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$TriggerUri = "https://prod-08.eastus.logic.azure.com:443/workflows/854f1fc04f50415f83a359463dd60e8b/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=D7IHsTelJf8XFdhefU6mFRYjnHaa0oHkY_xWC_wW_Vs"
	
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -ActionId $ActionId -LogicAppResourceId $LogicAppResourceId -TriggerUri $TriggerUri
	
	#Validate
	Validate-Action $action

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name)
}

<#
.SYNOPSIS
Update Action
#>
function Update-AzSentinelAlertRuleAction-Update
{
	$AlertRuleId = "1584e7a3-802c-435b-9178-5720a44be2f3"
	$ActionId = "91c2ea2f-f40c-4bef-ab3b-43c09e4a9699"
	$LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$TriggerUri = "https://prod-08.eastus.logic.azure.com:443/workflows/854f1fc04f50415f83a359463dd60e8b/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=D7IHsTelJf8XFdhefU6mFRYjnHaa0oHkY_xWC_wW_Vs"
	$LogicAppResourceId2 = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Get-MDATPInvestigationPackage"
	$TriggerUri2 = "https://prod-11.eastus.logic.azure.com:443/workflows/9f824303d57e4f00bea47052e4318d1b/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=2cGZz7eu3Y437r3LRHpkSFUTmD0X15XXP7uiW5_aLaA"
	
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -ActionId $ActionId -LogicAppResourceId $LogicAppResourceId -TriggerUri $TriggerUri
	
	#update action
	$action = Update-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -ActionId ($action.Name) -LogicAppResourceId $LogicAppResourceId2 -TriggerUri $TriggerUri2
	
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
	$AlertRuleId = "d1ae0250-f1d8-4cd2-9806-e2375dd7c4ae"
	$ActionId = "4044b6d3-de80-4c37-81f2-46d96dfdd78b"
	$LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$TriggerUri = "https://prod-13.westus.logic.azure.com:443/workflows/826a95b1b84c4ffbaf3af3dd88fe96b5/triggers/When_a_response_to_an_Azure_Sentinel_alert_is_triggered/paths/invoke?api-version=2018-07-01-preview&sp=%2Ftriggers%2FWhen_a_response_to_an_Azure_Sentinel_alert_is_triggered%2Frun&sv=1.0&sig=pK23xWl4uJT4RWs7zopxiP0Z7CpIfCDZEanL-mEyy1E"
		
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name) -ActionId $ActionId -LogicAppResourceId $LogicAppResourceId -TriggerUri $TriggerUri
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