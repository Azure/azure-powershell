### Example 1: Updates an automation rule
```powershell
 $LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "myResourceGroup" -Name "Reset-AADPassword"
 $automationRuleAction = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AutomationRuleRunPlaybookAction]::new()
 $automationRuleAction.Order = 1
 $automationRuleAction.ActionType = "RunPlaybook"
 $automationRuleAction.ActionConfigurationLogicAppResourceId = ($LogicAppResourceId.Id)
 $automationRuleAction.ActionConfigurationTenantId = (Get-AzContext).Tenant.Id
 Update-AzSentinelAutomationRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Action $automationRuleAction -DisplayName "Run Playbook to reset AAD password" -Order 2 -TriggeringLogicIsEnabled
```

This command updates an automation rule

