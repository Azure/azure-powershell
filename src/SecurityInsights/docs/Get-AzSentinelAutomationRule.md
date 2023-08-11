---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelautomationrule
schema: 2.0.0
---

# Get-AzSentinelAutomationRule

## SYNOPSIS
Gets the automation rule.

## SYNTAX

### List (Default)
```
Get-AzSentinelAutomationRule -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSentinelAutomationRule -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelAutomationRule -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzSentinelAutomationRule -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the automation rule.

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Automation rule ID

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityWorkspace
Aliases: AutomationRuleId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter
To construct, see NOTES section for WORKSPACEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IAutomationRule

## NOTES

## RELATED LINKS

