---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/new-azsentinelautomationrule
schema: 2.0.0
---

# New-AzSentinelAutomationRule

## SYNOPSIS
Create the automation rule.

## SYNTAX

### CreateViaIdentityExpanded (Default)
```
New-AzSentinelAutomationRule -InputObject <ISecurityInsightsIdentity> -Action <IAutomationRuleAction[]>
 -DisplayName <String> -Order <Int32> -TriggeringLogicIsEnabled -TriggeringLogicTriggersOn <String>
 -TriggeringLogicTriggersWhen <String> [-TriggeringLogicCondition <IAutomationRuleCondition[]>]
 [-TriggeringLogicExpirationTimeUtc <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzSentinelAutomationRule -ResourceGroupName <String> -WorkspaceName <String>
 -Action <IAutomationRuleAction[]> -DisplayName <String> -Order <Int32> -TriggeringLogicIsEnabled
 -TriggeringLogicTriggersOn <String> -TriggeringLogicTriggersWhen <String> [-Id <String>]
 [-SubscriptionId <String>] [-TriggeringLogicCondition <IAutomationRuleCondition[]>]
 [-TriggeringLogicExpirationTimeUtc <DateTime>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityWorkspaceExpanded
```
New-AzSentinelAutomationRule -WorkspaceInputObject <ISecurityInsightsIdentity>
 -Action <IAutomationRuleAction[]> -DisplayName <String> -Order <Int32> -TriggeringLogicIsEnabled
 -TriggeringLogicTriggersOn <String> -TriggeringLogicTriggersWhen <String> [-Id <String>]
 [-TriggeringLogicCondition <IAutomationRuleCondition[]>] [-TriggeringLogicExpirationTimeUtc <DateTime>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create the automation rule.

## EXAMPLES

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

## PARAMETERS

### -Action
The actions to execute when the automation rule is triggered.
To construct, see NOTES section for ACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IAutomationRuleAction[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DisplayName
The display name of the automation rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Automation rule ID

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityWorkspaceExpanded
Aliases: AutomationRuleId

Required: False
Position: Named
Default value: (New-Guid).Guid
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Order
The order of execution of the automation rule.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggeringLogicCondition
The conditions to evaluate to determine if the automation rule should be triggered on a given object.
To construct, see NOTES section for TRIGGERINGLOGICCONDITION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IAutomationRuleCondition[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggeringLogicExpirationTimeUtc
Determines when the automation rule should automatically expire and be disabled.

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggeringLogicIsEnabled
Determines whether the automation rule is enabled or disabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggeringLogicTriggersOn
.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggeringLogicTriggersWhen
.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter
To construct, see NOTES section for WORKSPACEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: CreateViaIdentityWorkspaceExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
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

