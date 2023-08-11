### Example 1: Add a Logic App Playbook as an action to an existing analytics rule
```powershell
$LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "si-jj-test" -Name "myLogicApp"
$LogicAppTriggerUri = Get-AzLogicAppTriggerCallbackUrl -ResourceGroupName "si-jj-test" -Name $LogicAppResourceId.Name -TriggerName "Microsoft_Sentinel_alert"
New-AzSentinelAlertRuleAction -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -RuleId "727fde97-bd0a-4b6d-a730-9d77fbcdb786" -LogicAppResourceId ($LogicAppResourceId.Id) -TriggerUri ($LogicAppTriggerUri.Value)
```

```output
Etag                         : 
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/alertRules/727fde97-bd0a-4b6d-a730-9d77fbcdb786/actions/830f0b57-f450-48d2-8930-45e8a8657385
LogicAppResourceId           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.Logic/workflows/myLogicApp
Name                         : 830f0b57-f450-48d2-8930-45e8a8657385
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/alertRules/actions
WorkflowId                   : 71ed151a52fb4db8b40b43ef4b71ef32
```

This command adds an existing Logic App Playbook to an existing analytics rule