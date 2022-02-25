### Example 1: {{ Add title here }}
```powershell
PS C:\>$LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "myLogicAppResourceGroupName" -Name "myLogicAppPlaybookName"
PS C:\>$LogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName "myLogicAppResourceGroupName" -Name $LogicAppResourceId.Name -TriggerName "When_a_response_to_an_Azure_Sentinel_alert_is_triggered"
PS C:\>Update-AzSentinelAlertRuleAction -ResourceGroupName "mySentinelResourceGroupName" -workspaceName "myWorkspaceName" -RuleId "48bbf86d-540b-4a7b-9fee-2bd7d810dbed" -LogicAppResourceId ($LogicAppResourceId.Id) -TriggerUri ($LogicAppTriggerUri.Value) -Id ((New-Guid).Guid)

```

This command updates an alert rule action
