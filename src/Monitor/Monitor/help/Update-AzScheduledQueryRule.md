---
external help file: Az.ScheduledQueryRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/az.monitor/update-azscheduledqueryrule
schema: 2.0.0
---

# Update-AzScheduledQueryRule

## SYNOPSIS
Update a scheduled query rule.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzScheduledQueryRule -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ActionCustomProperty <Hashtable>] [-ActionGroupResourceId <String[]>] [-AutoMitigate]
 [-CheckWorkspaceAlertsStorageConfigured] [-CriterionAllOf <ICondition[]>] [-Description <String>]
 [-DisplayName <String>] [-Enabled] [-EvaluationFrequency <TimeSpan>] [-MuteActionsDuration <TimeSpan>]
 [-OverrideQueryTimeRange <TimeSpan>] [-Scope <String[]>] [-Severity <Int64>] [-SkipQueryValidation]
 [-Tag <Hashtable>] [-TargetResourceType <String[]>] [-WindowSize <TimeSpan>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzScheduledQueryRule -InputObject <IScheduledQueryRuleIdentity> [-ActionCustomProperty <Hashtable>]
 [-ActionGroupResourceId <String[]>] [-AutoMitigate] [-CheckWorkspaceAlertsStorageConfigured]
 [-CriterionAllOf <ICondition[]>] [-Description <String>] [-DisplayName <String>] [-Enabled]
 [-EvaluationFrequency <TimeSpan>] [-MuteActionsDuration <TimeSpan>] [-OverrideQueryTimeRange <TimeSpan>]
 [-Scope <String[]>] [-Severity <Int64>] [-SkipQueryValidation] [-Tag <Hashtable>]
 [-TargetResourceType <String[]>] [-WindowSize <TimeSpan>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a scheduled query rule.

## EXAMPLES

### Example 1: Update scheduled query rule
```powershell
$subscriptionId=(Get-AzContext).Subscription.Id
Update-AzScheduledQueryRule -Name test-rule -ResourceGroupName test-group -Scope "/subscriptions/$subscriptionId/resourceGroups/test-group/providers/Microsoft.Compute/virtualMachines/test-vm" -ActionGroupResourceId "/subscriptions/$subscriptionId/resourceGroups/test-group/providers/microsoft.insights/actionGroups/test-action-group" -AutoMitigate:$false
```

Update scheduled query rule

## PARAMETERS

### -ActionCustomProperty
The properties of an alert payload.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ActionGroupResourceId
Action Group resource Ids to invoke when the alert fires.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoMitigate
The flag that indicates whether the alert should be automatically resolved or not.
The default is true.
Relevant only for rules of the kind LogAlert.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CheckWorkspaceAlertsStorageConfigured
The flag which indicates whether this scheduled query rule should be stored in the customer's storage.
The default is false.
Relevant only for rules of the kind LogAlert.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CriterionAllOf
A list of conditions to evaluate against the specified scopes
To construct, see NOTES section for CRITERIONALLOF properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.Api20210801.ICondition[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -Description
The description of the scheduled query rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display name of the alert rule

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Enabled
The flag which indicates whether this scheduled query rule is enabled.
Value should be true or false

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EvaluationFrequency
How often the scheduled query rule is evaluated represented in ISO 8601 duration format.
Relevant and required only for rules of the kind LogAlert.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.IScheduledQueryRuleIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MuteActionsDuration
Mute actions for the chosen period of time (in ISO 8601 duration format) after the alert is fired.
Relevant only for rules of the kind LogAlert.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the rule.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OverrideQueryTimeRange
If specified then overrides the query time range (default is WindowSize*NumberOfEvaluationPeriods).
Relevant only for rules of the kind LogAlert.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The list of resource id's that this scheduled query rule is scoped to.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity
Severity of the alert.
Should be an integer between [0-4].
Value of 0 is severest.
Relevant and required only for rules of the kind LogAlert.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipQueryValidation
The flag which indicates whether the provided query should be validated or not.
The default is false.
Relevant only for rules of the kind LogAlert.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceType
List of resource type of the target resource(s) on which the alert is created/updated.
For example if the scope is a resource group and targetResourceTypes is Microsoft.Compute/virtualMachines, then a different alert will be fired for each virtual machine in the resource group which meet the alert criteria.
Relevant only for rules of the kind LogAlert

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowSize
The period of time (in ISO 8601 duration format) on which the Alert query will be executed (bin size).
Relevant and required only for rules of the kind LogAlert.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.IScheduledQueryRuleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ScheduledQueryRule.Models.Api20210801.IScheduledQueryRuleResource

## NOTES

## RELATED LINKS
