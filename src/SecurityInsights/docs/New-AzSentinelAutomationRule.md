---
external help file:
Module Name: Az.SecurityInsights
online version: https://docs.microsoft.com/powershell/module/az.securityinsights/new-azsentinelautomationrule
schema: 2.0.0
---

# New-AzSentinelAutomationRule

## SYNOPSIS
Creates or updates the automation rule.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSentinelAutomationRule -ResourceGroupName <String> -WorkspaceName <String> [-Id <String>]
 [-SubscriptionId <String>] [-Action <IAutomationRuleAction[]>] [-DisplayName <String>] [-Order <Int32>]
 [-TriggeringLogicCondition <IAutomationRuleCondition[]>] [-TriggeringLogicExpirationTimeUtc <DateTime>]
 [-TriggeringLogicIsEnabled] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzSentinelAutomationRule -ResourceGroupName <String> -WorkspaceName <String>
 -AutomationRule <IAutomationRule> [-Id <String>] [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the automation rule.

## EXAMPLES

### Example 1: Create an Automation Rule using Run Playbook
```powershell
 $LogicAppResourceId = Get-AzLogicApp -ResourceGroupName "myResourceGroup" -Name "Reset-AADPassword"
 $automationRuleAction = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AutomationRuleRunPlaybookAction]::new()
 $automationRuleAction.Order = 1
 $automationRuleAction.ActionType = "RunPlaybook"
 $automationRuleAction.ActionConfigurationLogicAppResourceId = ($LogicAppResourceId.Id)
 $automationRuleAction.ActionConfigurationTenantId = (Get-AzContext).Tenant.Id
 New-AzSentinelAutomationRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Action $automationRuleAction -DisplayName "Run Playbook to reset AAD password" -Order 2 -TriggeringLogicIsEnabled
```

This command creates an Automation Rule that has an Action of Run Playbook.

### Example 2: Creates an Automation Rule that has an Action of changing the severity
```powershell
 $automationRuleAction = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AutomationRuleModifyPropertiesAction]::new()
 $automationRuleAction.Order = 1
 $automationRuleAction.ActionType = "ModifyProperties"
 $automationRuleAction.ActionConfigurationSeverity = "Low"
 New-AzSentinelAutomationRule -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Action $automationRuleAction -DisplayName "Change severity to Low" -Order 3 -TriggeringLogicIsEnabled
```

This command creates an Automation Rule that has an Action of changing the severity.

## PARAMETERS

### -Action
The actions to execute when the automation rule is triggered
To construct, see NOTES section for ACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAutomationRuleAction[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutomationRule
Represents an automation rule.
To construct, see NOTES section for AUTOMATIONRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAutomationRule
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
The display name of the automation rule

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

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
Parameter Sets: (All)
Aliases: AutomationRuleId

Required: False
Position: Named
Default value: (New-Guid).Guid
Accept pipeline input: False
Accept wildcard characters: False
```

### -Order
The order of execution of the automation rule

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TriggeringLogicCondition
The conditions to evaluate to determine if the automation rule should be triggered on a given object

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAutomationRuleCondition[]
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAutomationRule

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IAutomationRule

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ACTION <IAutomationRuleAction[]>`: The actions to execute when the automation rule is triggered
  - `ActionType <AutomationRuleActionType>`: The type of the automation rule action
  - `Order <Int32>`: The order of execution of the automation rule action

`AUTOMATIONRULE <IAutomationRule>`: Represents an automation rule.
  - `[Etag <String>]`: Etag of the azure resource
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[Action <IAutomationRuleAction[]>]`: The actions to execute when the automation rule is triggered
    - `ActionType <AutomationRuleActionType>`: The type of the automation rule action
    - `Order <Int32>`: The order of execution of the automation rule action
  - `[CreatedByEmail <String>]`: The email of the client.
  - `[CreatedByName <String>]`: The name of the client.
  - `[CreatedByObjectId <String>]`: The object id of the client.
  - `[CreatedByUserPrincipalName <String>]`: The user principal name of the client.
  - `[DisplayName <String>]`: The display name of the automation  rule
  - `[LastModifiedByEmail <String>]`: The email of the client.
  - `[LastModifiedByName <String>]`: The name of the client.
  - `[LastModifiedByObjectId <String>]`: The object id of the client.
  - `[LastModifiedByUserPrincipalName <String>]`: The user principal name of the client.
  - `[Order <Int32?>]`: The order of execution of the automation rule
  - `[TriggeringLogicCondition <IAutomationRuleCondition[]>]`: The conditions to evaluate to determine if the automation rule should be triggered on a given object
  - `[TriggeringLogicExpirationTimeUtc <DateTime?>]`: Determines when the automation rule should automatically expire and be disabled.
  - `[TriggeringLogicIsEnabled <Boolean?>]`: Determines whether the automation rule is enabled or disabled.

## RELATED LINKS

