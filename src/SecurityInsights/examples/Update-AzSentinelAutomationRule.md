### Example 1: Updates an automation rule
```powershell
$LogicAppResource = Get-AzLogicApp -ResourceGroupName "si-jj-test" -Name "IncidentLogicApp"
$automationRuleAction = New-AzSentinelAutomationRuleActionObject -ActionType RunPlaybook -Order 1 -LogicAppResourceId $LogicAppResource.Id -TenantId (Get-AzContext).Tenant.Id
Update-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws3" -Id ((New-Guid).Guid) -Action $automationRuleAction -DisplayName "Run Playbook to Incident create" -Order 2 -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn Incidents -TriggeringLogicTriggersWhen Created
```

```output
Action                           : {{
                                     "order": 1,
                                     "actionType": "RunPlaybook",
                                     "actionConfiguration": {
                                       "logicAppResourceId":
                                   "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.Logic/workflows/IncidentLogicApp",
                                       "tenantId": "72f988bf-86f1-41af-91ab-2d7cd011db47"
                                     }
                                   }}
CreatedByEmail                   : v-jiaji@microsoft.com
CreatedByName                    : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId                : 6205f759-1234-453c-9712-34d7671bceff
CreatedByUserPrincipalName       : v-jiaji@microsoft.com
CreatedTimeUtc                   : 8/9/2023 1:58:17 AM
DisplayName                      : Run Playbook to Incident create
Etag                             : "4e005720-0000-0100-0000-64d2f2b90000"
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws3/providers/Micros 
                                   oft.SecurityInsights/AutomationRules/e9b32c90-071e-4db7-b1d2-a931d895a6c3
LastModifiedByEmail              : v-jiaji@microsoft.com
LastModifiedByName               : Joyer Jin (Wicresoft North America Ltd)
LastModifiedByObjectId           : 6205f759-1234-453c-9712-34d7671bceff
LastModifiedByUserPrincipalName  : v-jiaji@microsoft.com
LastModifiedTimeUtc              : 8/9/2023 1:58:17 AM
Name                             : e9b32c90-071e-4db7-b1d2-a931d895a6c3
Order                            : 2
ResourceGroupName                : si-jj-test
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
TriggeringLogicCondition         : {}
TriggeringLogicExpirationTimeUtc : 
TriggeringLogicIsEnabled         : True
TriggeringLogicTriggersOn        : Incidents
TriggeringLogicTriggersWhen      : Created
Type                             : Microsoft.SecurityInsights/AutomationRules
```

This command updates an automation rule