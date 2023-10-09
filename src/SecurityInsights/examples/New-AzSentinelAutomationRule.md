### Example 1: Create an Automation Rule using Run Playbook
```powershell
$LogicAppResource = Get-AzLogicApp -ResourceGroupName "si-jj-test" -Name "AlertLogicApp"
$automationRuleAction = New-AzSentinelAutomationRuleActionObject -ActionType RunPlaybook -Order 1 -LogicAppResourceId $LogicAppResource.Id -TenantId (Get-AzContext).Tenant.Id
New-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws3" -Action $automationRuleAction -DisplayName "Run Playbook to create alerts" -Order 2 -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn Alerts -TriggeringLogicTriggersWhen Created
```

```output
Action                           : {{
                                     "order": 1,
                                     "actionType": "RunPlaybook",
                                     "actionConfiguration": {
                                       "logicAppResourceId":
                                   "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.Logic/workflows/myLogicApp",
                                       "tenantId": "72f988bf-86f1-41af-91ab-2d7cd011db47"
                                     }
                                   }}
CreatedByEmail                   : v-jiaji@microsoft.com
CreatedByName                    : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId                : 6205f759-1234-453c-9712-34d7671bceff
CreatedByUserPrincipalName       : v-jiaji@microsoft.com
CreatedTimeUtc                   : 8/4/2023 10:57:22 AM
DisplayName                      : Run Playbook to reset AAD password
Etag                             : "0b0032b0-0000-0100-0000-64ccd9920000"
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AutomationRules/ed8c40f0-af1c-4774-82c3-e86e79f33ff8
LastModifiedByEmail              : v-jiaji@microsoft.com
LastModifiedByName               : Joyer Jin (Wicresoft North America Ltd)
LastModifiedByObjectId           : 6205f759-1234-453c-9712-34d7671bceff
LastModifiedByUserPrincipalName  : v-jiaji@microsoft.com
LastModifiedTimeUtc              : 8/4/2023 10:57:22 AM
Name                             : ed8c40f0-af1c-4774-82c3-e86e79f33ff8
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
TriggeringLogicTriggersOn        : Alerts
TriggeringLogicTriggersWhen      : Created
Type                             : Microsoft.SecurityInsights/AutomationRules
```

This command creates an Automation Rule that has an Action of Run Playbook.

### Example 2: Creates an Automation Rule that has an Action of changing the severity
```powershell
$automationRuleAction2 = New-AzSentinelAutomationRuleActionObject -ActionType ModifyProperties -Order 1 -Severity High
# Condition document link https://learn.microsoft.com/en-us/azure/sentinel/create-manage-use-automation-rules#define-conditions
$triggeringLogicCondition = New-AzSentinelAutomationRuleActionCondition -Type PropertyChanged -ChangedPropertyName IncidentOwner
New-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws3" -Action $automationRuleAction2 -DisplayName "Change severity to High" -Order 3 -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn Incidents -TriggeringLogicTriggersWhen Updated -TriggeringLogicCondition $triggeringLogicCondition
```

This command creates an Automation Rule that has an Action of changing the severity.

