### Example 1: Create an Automation Rule using Run Playbook
```powershell
 $LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "myResourceGroup" -Name "Reset-AADPassword"
 $automationRuleAction = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AutomationRuleRunPlaybookAction]::new()
 $automationRuleAction.Order = 1
 $automationRuleAction.ActionType = "RunPlaybook"
 $automationRuleAction.ActionConfigurationLogicAppResourceId = ($LogicAppResourceId.Id)
 $automationRuleAction.ActionConfigurationTenantId = (Get-AzContext).Tenant.Id
 New-AzSentinelAutomationRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Action $automationRuleAction -DisplayName "Run Playbook to reset AAD password" -Order 2 -TriggeringLogicIsEnabled
```

This command creates an Automation Rule that has an Action of Run Playbook.

### Example 2: Creates an Automation Rule that has an Action of changing the severity
```powershell
 $automationRuleAction = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AutomationRuleModifyPropertiesAction]::new()
 $automationRuleAction.Order = 1
 $automationRuleAction.ActionType = "ModifyProperties"
 $automationRuleAction.ActionConfigurationSeverity = "Low"
 New-AzSentinelAutomationRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Action $automationRuleAction -DisplayName "Change severity to Low" -Order 3 -TriggeringLogicIsEnabled
```

This command creates an Automation Rule that has an Action of changing the severity.

