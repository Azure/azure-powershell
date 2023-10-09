### Example 1: List all Automation Rules
```powershell
Get-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws"
```
```output
Action                           : {{
                                     "order": 1,
                                     "actionType": "ModifyProperties",
                                     "actionConfiguration": {
                                       "severity": "High"
                                     }
                                   }}
CreatedByEmail                   : v-jiaji@microsoft.com
CreatedByName                    : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId                : 6205f759-1234-453c-9712-34d7671bceff
CreatedByUserPrincipalName       : v-jiaji@microsoft.com
CreatedTimeUtc                   : 8/4/2023 10:07:55 AM
DisplayName                      : Change severity to High
Etag                             : "0b009c21-0000-0100-0000-64cccdfb0000"
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AutomationRules/240357d9-583c-4889-ae96-a8372d62349a
LastModifiedByEmail              : v-jiaji@microsoft.com
LastModifiedByName               : Joyer Jin (Wicresoft North America Ltd)
LastModifiedByObjectId           : 6205f759-1234-453c-9712-34d7671bceff
LastModifiedByUserPrincipalName  : v-jiaji@microsoft.com
LastModifiedTimeUtc              : 8/4/2023 10:07:55 AM
Name                             : 240357d9-583c-4889-ae96-a8372d62349a
Order                            : 3
ResourceGroupName                : si-jj-test
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
TriggeringLogicCondition         : {{
                                     "conditionType": "PropertyChanged",
                                     "conditionProperties": {
                                       "propertyName": "IncidentStatus",
                                       "changeType": "ChangedTo",
                                       "operator": "Equals",
                                       "propertyValues": [ "Active" ]
                                     }
                                   }}
TriggeringLogicExpirationTimeUtc : 
TriggeringLogicIsEnabled         : True
TriggeringLogicTriggersOn        : Incidents
TriggeringLogicTriggersWhen      : Updated
Type                             : Microsoft.SecurityInsights/AutomationRules
```

This command lists all Automation Rules under a Microsoft Sentinel workspace.

### Example 2: Get an Automation Rule
```powershell
 Get-AzSentinelAutomationRule -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id "240357d9-583c-4889-ae96-a8372d62349a"
```
```output
Action                           : {{
                                     "order": 1,
                                     "actionType": "ModifyProperties",
                                     "actionConfiguration": {
                                       "severity": "High"
                                     }
                                   }}
CreatedByEmail                   : v-jiaji@microsoft.com
CreatedByName                    : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId                : 6205f759-1234-453c-9712-34d7671bceff
CreatedByUserPrincipalName       : v-jiaji@microsoft.com
CreatedTimeUtc                   : 8/4/2023 10:07:55 AM
DisplayName                      : Change severity to High
Etag                             : "0b009c21-0000-0100-0000-64cccdfb0000"
Id                               : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/ 
                                   providers/Microsoft.SecurityInsights/AutomationRules/240357d9-583c-4889-ae96-a8372d62349a
LastModifiedByEmail              : v-jiaji@microsoft.com
LastModifiedByName               : Joyer Jin (Wicresoft North America Ltd)
LastModifiedByObjectId           : 6205f759-1234-453c-9712-34d7671bceff
LastModifiedByUserPrincipalName  : v-jiaji@microsoft.com
LastModifiedTimeUtc              : 8/4/2023 10:07:55 AM
Name                             : 240357d9-583c-4889-ae96-a8372d62349a
Order                            : 3
ResourceGroupName                : si-jj-test
SystemDataCreatedAt              : 
SystemDataCreatedBy              : 
SystemDataCreatedByType          : 
SystemDataLastModifiedAt         : 
SystemDataLastModifiedBy         : 
SystemDataLastModifiedByType     : 
TriggeringLogicCondition         : {{
                                     "conditionType": "PropertyChanged",
                                     "conditionProperties": {
                                       "propertyName": "IncidentStatus",
                                       "changeType": "ChangedTo",
                                       "operator": "Equals",
                                       "propertyValues": [ "Active" ]
                                     }
                                   }}
TriggeringLogicExpirationTimeUtc : 
TriggeringLogicIsEnabled         : True
TriggeringLogicTriggersOn        : Incidents
TriggeringLogicTriggersWhen      : Updated
Type                             : Microsoft.SecurityInsights/AutomationRules
```

This command gets an Automation Rule.