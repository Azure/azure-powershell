### Example 1: {{ Add title here }}
```powershell
PS C:\> $LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "myResourceGroup" -Name "Reset-AADPassword"
PS C:\> $automationRuleAction = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AutomationRuleRunPlaybookAction]::new()
PS C:\> $automationRuleAction.Order = 1
PS C:\> $automationRuleAction.ActionType = "RunPlaybook"
PS C:\> $automationRuleAction.ActionConfigurationLogicAppResourceId = ($LogicAppResourceId.Id)
PS C:\> $automationRuleAction.ActionConfigurationTenantId = (Get-AzContext).Tenant.Id
PS C:\> Update-AzSentinelAutomationRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Action $automationRuleAction -DisplayName "Run Playbook to reset AAD password" -Order 2 -TriggeringLogicIsEnabled


```
This command updates an automation rule

