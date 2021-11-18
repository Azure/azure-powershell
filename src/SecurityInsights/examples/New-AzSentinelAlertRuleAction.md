### Example 1: Create a Alert Rule Action
```powershell
PS C:\> $LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "myResourceGroup" -Name "Reset-AADPassword"
PS C:\> $LogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName "myResourceGroup" -Name "Reset-AADPassword" -TriggerName "When_a_response_to_an_Azure_Sentinel_alert_is_triggered"
PS C:\> New-AzSentinelAlertRuleAction -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -AlertRuleId "myAlertRuleId" -LogicAppResourceId ($LogicAppResourceId.Id) -TriggerUri ($LogicAppTriggerUri.Value

{{ Add output here }}
```

This command creates an Alert Rule Action using the Logic App properties.
