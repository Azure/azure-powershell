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
function Get-AzSentineAlertRulelAction-ListByAlertRule
{
	
	$LogicAppResourceId = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Block-AADUser"
	$LogicAppResourceId2 = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Get-MDATPInvestigationPackage"
	
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Type Scheduled -Enabled $true -DisplayName "PoshModuleTest" -SuprressionDuration "PT5H" -SuprressionEnabled $false
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -LogicAppResourceId $LogicAppResourceId
	#Create Alert Rule Action
	$action2 = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -LogicAppResourceId $LogicAppResourceId2
	
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
		
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Type Scheduled -Enabled $true -DisplayName "PoshModuleTest" -SuprressionDuration "PT5H" -SuprressionEnabled $false
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -LogicAppResourceId $LogicAppResourceId
		
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
			
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Type Scheduled -Enabled $true -DisplayName "PoshModuleTest" -SuprressionDuration "PT5H" -SuprressionEnabled $false
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -LogicAppResourceId $LogicAppResourceId
	
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
	$LogicAppResourceId2 = "/subscriptions/1c61ccbf-70b3-45a3-a1fb-848ce46d70a6/resourceGroups/ndicola-azsposh/providers/Microsoft.Logic/workflows/Get-MDATPInvestigationPackage"
		
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Type Scheduled -Enabled $true -DisplayName "PoshModuleTest" -SuprressionDuration "PT5H" -SuprressionEnabled $false
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -LogicAppResourceId $LogicAppResourceId
	
	#update action
	$action = Set=AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -LogicAppResourceId $LogicAppResourceId2
	
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
		
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Type Scheduled -Enabled $true -DisplayName "PoshModuleTest" -SuprressionDuration "PT5H" -SuprressionEnabled $false
	#Create Alert Rule Action
	$action = New-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -LogicAppResourceId $LogicAppResourceId
	Remove-AzSentinelAlertRuleAction -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -ActionId ($action.Name)
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