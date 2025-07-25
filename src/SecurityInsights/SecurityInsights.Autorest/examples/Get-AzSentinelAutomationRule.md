### Example 1: List all Automation Rules
```powershell
 Get-AzSentinelAutomationRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
DisplayName                 : VIP automation rule
CreatedByEmail              : luke@contoso.com
CreatedByUserPrincipalName  : luke@contoso.com
TriggeringLogicIsEnabled    : True
TriggeringLogicTriggersOn   : Incidents
TriggeringLogicTriggersWhen : Created
Name                       	: 2f32af32-ad13-4fbb-9fbc-e19e0e7ff767

```

This command lists all Automation Rules under a Microsoft Sentinel workspace.

### Example 2: Get an Automation Rule
```powershell
 Get-AzSentinelAutomationRule -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "2f32af32-ad13-4fbb-9fbc-e19e0e7ff767"
```
```output
DisplayName                 : VIP automation rule
CreatedByEmail              : luke@contoso.com
CreatedByUserPrincipalName  : luke@contoso.com
TriggeringLogicIsEnabled    : True
TriggeringLogicTriggersOn   : Incidents
TriggeringLogicTriggersWhen : Created
Name                       	: 2f32af32-ad13-4fbb-9fbc-e19e0e7ff767
```

This command gets an Automation Rule.