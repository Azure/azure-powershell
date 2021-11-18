### Example 1: Create an Automation Rule using Run Playbook
```powershell
PS C:\> $LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "myResourceGroup" -Name "Reset-AADPassword"
PS C:\> $automationRuleAction = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AutomationRuleRunPlaybookAction]::new()
PS C:\> $automationRuleAction.Order = 1
PS C:\> $automationRuleAction.ActionType = "RunPlaybook"
PS C:\> $automationRuleAction.ActionConfigurationLogicAppResourceId = ($LogicAppResourceId.Id)
PS C:\> $automationRuleAction.ActionConfigurationTenantId = (Get-AzContext).Tenant.Id
PS C:\> New-AzSentinelAutomationRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Action $automationRuleAction -DisplayName "Run Playbook to reset AAD password" -Order 2 -TriggeringLogicIsEnabled

{{ Add output here }}
```

This command creates an Automation Rule that has an Action of Run Playbook.

### Example 2: {{ Add title here }}
```powershell
PS C:\> $automationRuleAction = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AutomationRuleModifyPropertiesAction]::new()
PS C:\> $automationRuleAction.Order = 1
PS C:\> $automationRuleAction.ActionType = "ModifyProperties"
PS C:\> $automationRuleAction.ActionConfigurationSeverity = "Low"
PS C:\> New-AzSentinelAutomationRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Action $automationRuleAction -DisplayName "Change severity to Low" -Order 3 -TriggeringLogicIsEnabled

{{ Add output here }}
```

This command creates an Automation Rule that has an Action of changing the severity.

