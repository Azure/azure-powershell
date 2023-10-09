### Example 1: Updates an alert rule action
```powershell
$LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "si-jj-test" -Name "myLogicApp"
$LogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName "si-jj-test" -Name $LogicAppResourceId.Name -TriggerName "Microsoft_Sentinel_alert"
Update-AzSentinelAlertRuleAction -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -RuleId "727fde97-bd0a-4b6d-a730-9d77fbcdb786" -LogicAppResourceId ($LogicAppResourceId.Id) -TriggerUri ($LogicAppTriggerUri.Value) -Id ((New-Guid).Guid)
```

This command updates an alert rule action.
